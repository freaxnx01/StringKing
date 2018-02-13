namespace StringKingUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.toolStripStatusLabelInput = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonExecute = new CommandingWinForms.Button();
            this.listBoxFunction = new System.Windows.Forms.ListBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.statusStripInput = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControlInput = new System.Windows.Forms.TabControl();
            this.tabPageInput1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonRemoveTab = new CommandingWinForms.Button();
            this.checkBoxMoveResultToLeft = new System.Windows.Forms.CheckBox();
            this.buttonAddTab = new CommandingWinForms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.statusStripOutput = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelOutput = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonMoveTextToLeft = new CommandingWinForms.Button();
            this.tabControlOutput = new System.Windows.Forms.TabControl();
            this.tabPageOutput = new System.Windows.Forms.TabPage();
            this.textBoxFilterStringFunction = new System.Windows.Forms.TextBox();
            this.argumentsControl = new StringKingUI.ArgumentsControl();
            this.textBoxControlInput1 = new StringKingUI.TextBoxControl();
            this.textBoxControlOutput = new StringKingUI.TextBoxControl();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStripInput.SuspendLayout();
            this.tabControlInput.SuspendLayout();
            this.tabPageInput1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.statusStripOutput.SuspendLayout();
            this.tabControlOutput.SuspendLayout();
            this.tabPageOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(1057, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // toolStripStatusLabelInput
            // 
            this.toolStripStatusLabelInput.Name = "toolStripStatusLabelInput";
            this.toolStripStatusLabelInput.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripMain
            // 
            this.toolStripMain.Location = new System.Drawing.Point(0, 24);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(1057, 25);
            this.toolStripMain.TabIndex = 1;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1057, 699);
            this.splitContainer1.SplitterDistance = 222;
            this.splitContainer1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxFilterStringFunction);
            this.panel1.Controls.Add(this.argumentsControl);
            this.panel1.Controls.Add(this.buttonExecute);
            this.panel1.Controls.Add(this.listBoxFunction);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1057, 222);
            this.panel1.TabIndex = 0;
            // 
            // buttonExecute
            // 
            this.buttonExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExecute.Location = new System.Drawing.Point(869, 3);
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.Size = new System.Drawing.Size(182, 23);
            this.buttonExecute.TabIndex = 1;
            this.buttonExecute.Text = "&Execute";
            this.buttonExecute.UseVisualStyleBackColor = true;
            // 
            // listBoxFunction
            // 
            this.listBoxFunction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxFunction.FormattingEnabled = true;
            this.listBoxFunction.Location = new System.Drawing.Point(12, 46);
            this.listBoxFunction.Name = "listBoxFunction";
            this.listBoxFunction.Size = new System.Drawing.Size(256, 173);
            this.listBoxFunction.TabIndex = 0;
            this.listBoxFunction.SelectedIndexChanged += new System.EventHandler(this.listBoxFunction_SelectedValueChanged);
            this.listBoxFunction.DoubleClick += new System.EventHandler(this.listBoxFunction_DoubleClick);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(6);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(6);
            this.splitContainer2.Size = new System.Drawing.Size(1057, 473);
            this.splitContainer2.SplitterDistance = 525;
            this.splitContainer2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.statusStripInput, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tabControlInput, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(513, 461);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // statusStripInput
            // 
            this.statusStripInput.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStripInput.Location = new System.Drawing.Point(0, 439);
            this.statusStripInput.Name = "statusStripInput";
            this.statusStripInput.Size = new System.Drawing.Size(513, 22);
            this.statusStripInput.TabIndex = 8;
            this.statusStripInput.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // tabControlInput
            // 
            this.tabControlInput.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControlInput.Controls.Add(this.tabPageInput1);
            this.tabControlInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlInput.Location = new System.Drawing.Point(3, 33);
            this.tabControlInput.Name = "tabControlInput";
            this.tabControlInput.SelectedIndex = 0;
            this.tabControlInput.Size = new System.Drawing.Size(507, 403);
            this.tabControlInput.TabIndex = 5;
            // 
            // tabPageInput1
            // 
            this.tabPageInput1.Controls.Add(this.textBoxControlInput1);
            this.tabPageInput1.Location = new System.Drawing.Point(4, 4);
            this.tabPageInput1.Name = "tabPageInput1";
            this.tabPageInput1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInput1.Size = new System.Drawing.Size(499, 377);
            this.tabPageInput1.TabIndex = 0;
            this.tabPageInput1.Text = "Input 1";
            this.tabPageInput1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.Controls.Add(this.buttonRemoveTab, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.checkBoxMoveResultToLeft, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonAddTab, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(513, 30);
            this.tableLayoutPanel3.TabIndex = 9;
            // 
            // buttonRemoveTab
            // 
            this.buttonRemoveTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRemoveTab.Location = new System.Drawing.Point(481, 3);
            this.buttonRemoveTab.Name = "buttonRemoveTab";
            this.buttonRemoveTab.Size = new System.Drawing.Size(29, 24);
            this.buttonRemoveTab.TabIndex = 7;
            this.buttonRemoveTab.Text = "-";
            this.buttonRemoveTab.UseVisualStyleBackColor = true;
            // 
            // checkBoxMoveResultToLeft
            // 
            this.checkBoxMoveResultToLeft.AutoSize = true;
            this.checkBoxMoveResultToLeft.Location = new System.Drawing.Point(3, 3);
            this.checkBoxMoveResultToLeft.Name = "checkBoxMoveResultToLeft";
            this.checkBoxMoveResultToLeft.Size = new System.Drawing.Size(128, 17);
            this.checkBoxMoveResultToLeft.TabIndex = 5;
            this.checkBoxMoveResultToLeft.Text = "&Move result to the left";
            this.checkBoxMoveResultToLeft.UseVisualStyleBackColor = true;
            // 
            // buttonAddTab
            // 
            this.buttonAddTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddTab.Location = new System.Drawing.Point(446, 3);
            this.buttonAddTab.Name = "buttonAddTab";
            this.buttonAddTab.Size = new System.Drawing.Size(29, 24);
            this.buttonAddTab.TabIndex = 6;
            this.buttonAddTab.Text = "+";
            this.buttonAddTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.statusStripOutput, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.buttonMoveTextToLeft, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tabControlOutput, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(516, 461);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // statusStripOutput
            // 
            this.statusStripOutput.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelOutput});
            this.statusStripOutput.Location = new System.Drawing.Point(0, 439);
            this.statusStripOutput.Name = "statusStripOutput";
            this.statusStripOutput.Size = new System.Drawing.Size(516, 22);
            this.statusStripOutput.TabIndex = 5;
            this.statusStripOutput.Text = "statusStrip2";
            // 
            // toolStripStatusLabelOutput
            // 
            this.toolStripStatusLabelOutput.Name = "toolStripStatusLabelOutput";
            this.toolStripStatusLabelOutput.Size = new System.Drawing.Size(0, 17);
            // 
            // buttonMoveTextToLeft
            // 
            this.buttonMoveTextToLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMoveTextToLeft.Location = new System.Drawing.Point(3, 3);
            this.buttonMoveTextToLeft.Name = "buttonMoveTextToLeft";
            this.buttonMoveTextToLeft.Size = new System.Drawing.Size(75, 24);
            this.buttonMoveTextToLeft.TabIndex = 3;
            this.buttonMoveTextToLeft.Text = "<<";
            this.buttonMoveTextToLeft.UseVisualStyleBackColor = true;
            // 
            // tabControlOutput
            // 
            this.tabControlOutput.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControlOutput.Controls.Add(this.tabPageOutput);
            this.tabControlOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlOutput.Location = new System.Drawing.Point(3, 33);
            this.tabControlOutput.Name = "tabControlOutput";
            this.tabControlOutput.SelectedIndex = 0;
            this.tabControlOutput.Size = new System.Drawing.Size(510, 403);
            this.tabControlOutput.TabIndex = 4;
            // 
            // tabPageOutput
            // 
            this.tabPageOutput.Controls.Add(this.textBoxControlOutput);
            this.tabPageOutput.Location = new System.Drawing.Point(4, 4);
            this.tabPageOutput.Name = "tabPageOutput";
            this.tabPageOutput.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOutput.Size = new System.Drawing.Size(502, 377);
            this.tabPageOutput.TabIndex = 0;
            this.tabPageOutput.Text = "Output";
            this.tabPageOutput.UseVisualStyleBackColor = true;
            // 
            // textBoxFilterStringFunction
            // 
            this.textBoxFilterStringFunction.Location = new System.Drawing.Point(12, 20);
            this.textBoxFilterStringFunction.Name = "textBoxFilterStringFunction";
            this.textBoxFilterStringFunction.Size = new System.Drawing.Size(256, 20);
            this.textBoxFilterStringFunction.TabIndex = 3;
            this.textBoxFilterStringFunction.TextChanged += new System.EventHandler(this.textBoxFilterStringFunction_TextChanged);
            // 
            // argumentsControl
            // 
            this.argumentsControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.argumentsControl.BackColor = System.Drawing.SystemColors.Control;
            this.argumentsControl.Location = new System.Drawing.Point(268, 3);
            this.argumentsControl.Name = "argumentsControl";
            this.argumentsControl.Size = new System.Drawing.Size(595, 209);
            this.argumentsControl.TabIndex = 2;
            // 
            // textBoxControlInput1
            // 
            this.textBoxControlInput1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxControlInput1.Location = new System.Drawing.Point(3, 3);
            this.textBoxControlInput1.Name = "textBoxControlInput1";
            this.textBoxControlInput1.Size = new System.Drawing.Size(493, 371);
            this.textBoxControlInput1.TabIndex = 0;
            // 
            // textBoxControlOutput
            // 
            this.textBoxControlOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxControlOutput.Location = new System.Drawing.Point(3, 3);
            this.textBoxControlOutput.Name = "textBoxControlOutput";
            this.textBoxControlOutput.Size = new System.Drawing.Size(496, 371);
            this.textBoxControlOutput.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 748);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.menuStripMain);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StringKing";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusStripInput.ResumeLayout(false);
            this.statusStripInput.PerformLayout();
            this.tabControlInput.ResumeLayout(false);
            this.tabPageInput1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.statusStripOutput.ResumeLayout(false);
            this.statusStripOutput.PerformLayout();
            this.tabControlOutput.ResumeLayout(false);
            this.tabPageOutput.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelInput;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private ArgumentsControl argumentsControl;
        private CommandingWinForms.Button buttonExecute;
        private System.Windows.Forms.ListBox listBoxFunction;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.StatusStrip statusStripInput;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabControl tabControlInput;
        private System.Windows.Forms.TabPage tabPageInput1;
        private TextBoxControl textBoxControlInput1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private CommandingWinForms.Button buttonRemoveTab;
        private System.Windows.Forms.CheckBox checkBoxMoveResultToLeft;
        private CommandingWinForms.Button buttonAddTab;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.StatusStrip statusStripOutput;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelOutput;
        private CommandingWinForms.Button buttonMoveTextToLeft;
        private System.Windows.Forms.TabControl tabControlOutput;
        private System.Windows.Forms.TabPage tabPageOutput;
        private TextBoxControl textBoxControlOutput;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.TextBox textBoxFilterStringFunction;
    }
}

