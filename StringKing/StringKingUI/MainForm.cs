using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;

using Commanding;
using ObjectGraphML;
using EventAggregation;
using Infrastructure;
using Library.Gui.ExternalTools;

using StringKingProcessor;
using StringKing.Infrastructure;
using StringKing.StringFunctionInterface;
using Resources;

namespace StringKingUI
{
    public partial class MainForm : Form
    {
        private const int MaxNumberOfInputTabPages = 9;
        private const string InputString = "Input";
        private const string Space = " ";

        private Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();

        private MacroRecorder macroRecorder = new MacroRecorder();
        private string macroFileExtension = "macro";
        private string macroDirectory = "macros";

        private ExternalToolManager externalToolManager;
        private string externalToolssettingsFile;
        private const string externalToolssettingsFileName = "ExternalTools.xml";

        private List<StringFunctionItem> listOfFunctions = null;

        public MainForm()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            InitializeComponent();
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception)
            {
                Exception ex = (Exception)e.ExceptionObject;
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RegisterCommands();

            Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            RenderToolStrip(menuStripMain, @"Definitions\MenuStripMain.xml", commands);
            RenderToolStrip(toolStripMain, @"Definitions\ToolStripMain.xml", commands);
            RenderMacroMenu();
            AssingCommandsToButtons();
            SetCommandEnablement();

            InitExternalToolManager();

            SetupEventAggregation();

            checkBoxMoveResultToLeft.Checked = true;
            FillFunctionList();
        }

        private void SetupEventAggregation()
        {
            Singleton<EventAggregator>.Instance.Subscribe(argumentsControl);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode >= Keys.NumPad1 && e.KeyCode <= Keys.NumPad9)
                {
                    SwitchToInputTabPage(e.KeyCode);
                }
                else if (e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D9)
                {
                    SwitchToInputTabPage(e.KeyCode);
                }
                else if (e.KeyCode == Keys.F5)
                {
                    SetStatusText();
                }
            }
        }

        private static void RenderToolStrip(ToolStrip toolStrip, string xmlDefinitionFile, Dictionary<string, ICommand> commandDictionary)
        {
            toolStrip.Items.Clear();
            var renderEngine = new Engine(commandDictionary);
            renderEngine.RenderControl(toolStrip, xmlDefinitionFile, toolStrip.Parent);
        }

        private void RegisterCommands()
        {
            // Entwicklung:
            // commands.Add(CommandKeys.StartRecordingMacro, new Command<MainForm>(this, f => f.StartRecordingMacro()));
            // commands.Add(CommandKeys.StartRecordingMacro, new Command<MainForm>(this, a => ExecuteCommand<MainForm>(this, f => f.StartRecordingMacro())));
            // aktuell: RegisterCommand(CommandKeys.StartRecordingMacro, f => f.StartRecordingMacro());

            RegisterCommand(CommandKeys.Exit, f => f.Close());
            RegisterCommand(CommandKeys.AddInputTab, f => f.AddInputTab());
            RegisterCommand(CommandKeys.RemoveInputTab, f => f.RemoveInputTab());
            RegisterCommand(CommandKeys.PasteTestData, f => f.PasteTestData());
            RegisterCommand(CommandKeys.ShowAboutBox, f => f.ShowAboutBox());
            RegisterCommand(CommandKeys.MoveTextFromOutputToInput, f => f.MoveTextFromOutputToInput());
            RegisterCommand(CommandKeys.ExecuteStringFunction, f => f.ExecuteSelectedFunction());
            RegisterCommand(CommandKeys.StartRecordingMacro, f => f.StartRecordingMacro());
            RegisterCommand(CommandKeys.StopRecordingMacro, f => f.StopRecordingMacro());
            RegisterCommand(CommandKeys.ShowRunMacroDialog, f => f.ShowRunMacroDialog());
            RegisterCommand(CommandKeys.ManageExternalTools, f => f.ManageExternalTools());
        }

        private void RegisterCommand(string commandKey, Action<MainForm> command)
        {
            commands.Add(commandKey, new Command<MainForm>(this, a => ExecuteCommand<MainForm>(this, command)));
        }

        private void ExecuteCommand<T>(T target, Action<T> command)
        {
            command(target);
            SetCommandEnablement();
        }

        private void SetCommandEnablement()
        {
            commands[CommandKeys.AddInputTab].CanExecute = tabControlInput.TabPages.Count < MaxNumberOfInputTabPages;
            commands[CommandKeys.RemoveInputTab].CanExecute = tabControlInput.TabPages.Count > 1;
            commands[CommandKeys.StartRecordingMacro].CanExecute = macroRecorder.Mode == MacroRecorder.Modes.NotRecording;
            commands[CommandKeys.StopRecordingMacro].CanExecute = macroRecorder.Mode == MacroRecorder.Modes.Recording;
            commands[CommandKeys.ShowRunMacroDialog].CanExecute = macroRecorder.Mode == MacroRecorder.Modes.NotRecording;
        }

        private void AssingCommandsToButtons()
        {
            buttonAddTab.AssignCommand(commands[CommandKeys.AddInputTab]);
            buttonRemoveTab.AssignCommand(commands[CommandKeys.RemoveInputTab]);
            buttonMoveTextToLeft.AssignCommand(commands[CommandKeys.MoveTextFromOutputToInput]);
            buttonExecute.AssignCommand(commands[CommandKeys.ExecuteStringFunction]);
        }

        private void FillFunctionList()
        {
            listOfFunctions = Processor.GetListOfFunctions();

            listBoxFunction.Items.Clear();
            listBoxFunction.DisplayMember = "DisplayName";
            listBoxFunction.ValueMember = "FunctionType";
            listBoxFunction.DataSource = listOfFunctions;

            if (listBoxFunction.Items.Count > 0)
            {
                listBoxFunction.SelectedIndex = 0;
            }
        }

        private void ManageExternalTools()
        {
            externalToolManager.ShowDialog();
        }

        private void ExecuteSelectedFunction()
        {
            if (listBoxFunction.SelectedValue != null)
            {
                Dictionary<string, object> arguments = new Dictionary<string, object>();

                if (IsArgumentExisting)
                {
                    arguments = argumentsControl.ComposeArgumentList();
                }

                IStringFunction stringFunction = Processor.GetStringFunctionInstance((Type)listBoxFunction.SelectedValue);

                if (macroRecorder.Mode == MacroRecorder.Modes.Recording)
                {
                    macroRecorder.Record(stringFunction, arguments);
                }

                string result = string.Empty;

                try
                {
                    string[] inputArray = GetInputTextArray();
                    result = Processor.InvokeStringFunction(stringFunction, inputArray, arguments);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                SetOutputText(result);
            }
        }

        private void SetOutputText(string text)
        {
            if (text != null)
            {
                textBoxControlOutput.Text = text;
                if (checkBoxMoveResultToLeft.Checked)
                {
                    MoveTextFromOutputToInput();
                }
            }
        }

        private void StartRecordingMacro()
        {
            macroRecorder.Record();
        }

        private void StopRecordingMacro()
        {
            macroRecorder.StopRecording();
            Macro newMacro = macroRecorder.NewMacro;

            if (newMacro.Commands.Count == 0)
            {
                return;
            }

            string macroName = newMacro.Commands[0].Substring(0, newMacro.Commands[0].IndexOf('('));
            string macroFileFullPath = string.Empty;

            while (true)
            {
                using (Library.Gui.InputBoxDialog inputBox = new Library.Gui.InputBoxDialog())
                {
                    inputBox.Prompt = "Macro name:";
                    inputBox.DefaultValue = macroName;
                    if (inputBox.ShowDialog() == DialogResult.OK)
                    {
                        macroName = inputBox.UserInput;
                    }
                    else
                    {
                        macroName = string.Empty;
                    }
                }

                if (string.IsNullOrEmpty(macroName))
                {
                    break;
                }

                macroName = Library.FileSystem.RemoveInvalidCharsFromFileName(macroName);
                string fileName = macroName + "." + macroFileExtension;
                macroFileFullPath = Path.Combine(macroDirectory, fileName);
                if (!File.Exists(macroFileFullPath))
                {
                    break;
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show(string.Format(Resource.OverwriteExistingMacroFile, macroName), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        break;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        continue;
                    }
                }
            };

            if (!string.IsNullOrEmpty(macroName))
            {
                if (!Directory.Exists(macroDirectory))
                {
                    Directory.CreateDirectory(macroDirectory);
                }
                newMacro.Save(macroFileFullPath);
                RenderMacroMenu();
            }
        }

        private void RenderMacroMenu()
        {
            ToolStripMenuItem macroMenuItem = MainMenuStrip.Items["menuItemMacro"] as ToolStripMenuItem;
            ToolStripSeparator menuSparator = macroMenuItem.DropDownItems["menuItemMacroSeparator"] as ToolStripSeparator;

            Dictionary<string, string> macroFiles = GetMacroFiles();
            menuSparator.Visible = macroFiles.Count > 0;

            const string macroMenuItemPrefix = "newMacroMenuItem";

            macroMenuItem.DropDownItems.OfType<ToolStripMenuItem>().Where(m => m.Name.StartsWith(macroMenuItemPrefix)).ToList().ForEach(m => macroMenuItem.DropDownItems.Remove(m));

            int macroCounter = 0;
            foreach (KeyValuePair<string, string> macroFile in macroFiles)
            {
                macroCounter++;
                ToolStripMenuItem newMenuItem = new ToolStripMenuItem();
                newMenuItem.Name = macroMenuItemPrefix + macroCounter.ToString();
                newMenuItem.Text = macroFile.Key;
                newMenuItem.Tag = macroFile.Value;
                newMenuItem.Click += MacroFileMenuItem_Click;
                macroMenuItem.DropDownItems.Add(newMenuItem);
            }
        }

        void MacroFileMenuItem_Click(object sender, EventArgs e)
        {
            string macroFilePath = ((ToolStripMenuItem)sender).Tag.ToString();
            RunMacro(macroFilePath);
        }

        private void RunMacro(string macroFilePath)
        {
            string[] inputArray = GetInputTextArray();
            string input = string.Empty;
            if (inputArray.Length == 0)
            {
                input = string.Empty;
            }
            else if (inputArray.Length >= 1)
            {
                input = inputArray[0];
            }

            string result = MacroProcessor.RunMacro(input, macroFilePath);
            SetOutputText(result);
        }

        private Dictionary<string, string> GetMacroFiles()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (FileInfo fileInfo in new DirectoryInfo(macroDirectory).GetFiles("*." + macroFileExtension))
            {
                dict.Add(Path.GetFileNameWithoutExtension(fileInfo.Name), fileInfo.FullName);
            }
            return dict;
        }

        private void ShowRunMacroDialog()
        {
            macroRecorder.ShowRunMacroDialog();
        }

        private string GetFirstInputText()
        {
            return textBoxControlInput1.Text;
        }

        private string[] GetInputTextArray()
        {
            var inputList = new List<string>();

            foreach (TabPage tabPage in tabControlInput.TabPages)
            {
                string text = tabPage.Controls.OfType<TextBoxControl>().Single().Text;
                if (!string.IsNullOrEmpty(text))
                {
                    inputList.Add(text);
                }
            }

            return inputList.ToArray();
        }

        private bool IsArgumentExisting
        {
            get
            {
                return argumentsControl.ComposeArgumentList().Count > 0;
            }
        }

        private void MoveTextFromOutputToInput()
        {
            if (!string.IsNullOrEmpty(textBoxControlOutput.Text))
            {
                SetInputText(textBoxControlOutput.Text);
                textBoxControlOutput.Text = string.Empty;
            }
        }

        public void PasteTestData()
        {
            SetInputText(Processor.GetTestString((Type)listBoxFunction.SelectedValue));
        }

        public void ShowAboutBox()
        {
            using (var aboutBox = new Library.Gui.AboutBox() )
            {
                aboutBox.ShowDialog();
            }
        }

        private void listBoxFunction_DoubleClick(object sender, EventArgs e)
        {
            ExecuteSelectedFunction();
        }

        private void listBoxFunction_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                ExecuteSelectedFunction();
            }
        }

        private void listBoxFunction_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBoxFunction.SelectedValue != null)
            {
                Singleton<EventAggregator>.Instance.Publish(new StringFunctionSelectedMessage() { StringFunctionType = (Type)listBoxFunction.SelectedValue });
            }
        }

        private void ClearArgumentBox()
        {
            argumentsControl.Clear();
        }

        public void AddInputTab()
        {
            if (tabControlInput.TabPages.Count == MaxNumberOfInputTabPages)
            {
                return;
            }

            TabPage newInputTabPage = new TabPage();
            newInputTabPage.Name = "";
            TextBoxControl textBoxControl = new TextBoxControl();
            textBoxControl.Name = string.Concat("textBoxControlInput1", tabControlInput.TabPages.Count);
            newInputTabPage.Controls.Add(textBoxControl);
            textBoxControl.Dock = DockStyle.Fill;
            textBoxControl.Margin = new Padding(3);
            newInputTabPage.Padding = new Padding(3);
            tabControlInput.TabPages.Add(newInputTabPage);

            RenumberInputTabPages();

            tabControlInput.SelectedTab = newInputTabPage;
        }

        public void RemoveInputTab()
        {
            if (tabControlInput.SelectedTab != null && tabControlInput.TabPages.Count > 1)
            {
                int indexToRemove = tabControlInput.SelectedIndex;

                if (indexToRemove == tabControlInput.TabPages.Count - 1)
                {
                    tabControlInput.SelectedTab = tabControlInput.TabPages[indexToRemove - 1];
                }
                else
                {
                    tabControlInput.SelectedTab = tabControlInput.TabPages[indexToRemove + 1];
                }

                tabControlInput.TabPages.RemoveAt(indexToRemove);
                RenumberInputTabPages();
            }
        }

        private void RenumberInputTabPages()
        {
            for (int i = 1; i <= tabControlInput.TabPages.Count; i++)
            {
                tabControlInput.TabPages[i - 1].Text = string.Concat(InputString, Space, i);
            }
        }

        private void SwitchToInputTabPage(Keys key)
        {
            TabPage tabPage = (from TabPage t in tabControlInput.TabPages
                               where t.Text == string.Concat(InputString, Space, ExtractDigitFromKey(key))
                               select t).SingleOrDefault();

            if (tabPage != null)
            {
                tabControlInput.SelectedTab = tabPage;
            }
        }

        private int ExtractDigitFromKey(Keys key)
        {
            string keyAsString = key.ToString();
            return int.Parse(keyAsString.Substring(keyAsString.Length - 1));
        }

        private void SetInputText(string text)
        {
            GetActiveTextBoxControl().Text = text;
        }

        private string GetInputText()
        {
            return GetActiveTextBoxControl().Text;
        }

        private string GetOutputText()
        {
            return textBoxControlOutput.Text;
        }

        private TextBoxControl GetActiveTextBoxControl()
        {
            return tabControlInput.SelectedTab.Controls.OfType<TextBoxControl>().Single();
        }

        #region External Tools
        private void InitExternalToolManager()
        {
            externalToolssettingsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, externalToolssettingsFileName);

            ToolStripMenuItem menuItemExtras = MainMenuStrip.Items["menuItemExtras"] as ToolStripMenuItem;
            ToolStripMenuItem externalToolsMenuItem = menuItemExtras.DropDownItems["menuItemExtrasExternalTools"] as ToolStripMenuItem;

            externalToolManager = new ExternalToolManager(externalToolssettingsFile, externalToolsMenuItem);
            externalToolManager.OnRequestUpToDateValues += new ExternalToolManager.RequestUpToDateValuesEventHandler(externalToolManager_OnRequestUpToDateValues);
        }

        void externalToolManager_OnRequestUpToDateValues(object sender, RequestUpToDateValuesEventArgs args)
        {
            // aktuelle Werte zusammenstellen
            args.UpToDateArguments = ArrangeExternalToolArguments();
            args.UpToDateInitialDirectories = ArrangeExternalToolInitialDirectories();
        }

        private List<ArgumentEntry> ArrangeExternalToolArguments()
        {
            List<ArgumentEntry> arguments = new List<ArgumentEntry>();
            arguments.Add(new ArgumentEntry("Left", "Left", GetLeftTempFile()));
            arguments.Add(new ArgumentEntry("Right", "Right", GetRightTempFile()));
            return arguments;
        }

        private List<InitDirEntry> ArrangeExternalToolInitialDirectories()
        {
            List<InitDirEntry> initialDirectories = new List<InitDirEntry>();
            initialDirectories.Add(new InitDirEntry("AppDir", "Application directory", AppDomain.CurrentDomain.BaseDirectory));
            return initialDirectories;
        }

        private void externalToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            externalToolManager.ShowDialog();
        }

        private void StartExternalTool(ExternalToolEntry externalTool)
        {
            externalToolManager.ExecuteCommand(externalTool);
        }
        #endregion

        private string GetLeftTempFile()
        {
            return GetTempFile(GetInputText());
        }

        private string GetRightTempFile()
        {
            return GetTempFile(GetOutputText());
        }

        private string GetTempFile(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                string tempFilePath = Path.Combine(Path.GetTempPath(), Path.GetTempFileName());
                File.WriteAllText(tempFilePath, text);
                return tempFilePath;
            }
            return string.Empty;
        }

        private void textBoxFilterStringFunction_TextChanged(object sender, EventArgs e)
        {
            listBoxFunction.DataSource = (from f in listOfFunctions
                                          where f.DisplayName.ToLower().Contains(textBoxFilterStringFunction.Text.ToLower())
                                          select f).ToList();
        }

        private void SetStatusText()
        {
            statusStripInput.Items[0].Text = string.Format("length: {0}  lines: {1}", GetActiveTextBoxControl().Text.Length, GetLineCount(GetActiveTextBoxControl()));
        }

        private int GetLineCount(TextBoxControl textBox)
        {
            return textBox.Lines.Length;
        }
    }
}
