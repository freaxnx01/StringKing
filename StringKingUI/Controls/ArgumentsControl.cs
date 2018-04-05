using System;
using System.Windows.Forms;
using System.Collections.Generic;

using EventAggregation;

using StringKing.FunctionInterface;
using StringKing.Infrastructure;
using StringKing.Core;

namespace StringKingUI
{
    public partial class ArgumentsControl : UserControl, IHandle<StringFunctionSelectedMessage>
    {
        public ArgumentsControl()
        {
            InitializeComponent();
        }

        private void RenderArgumentBox(Dictionary<string, object> args)
        {
            Clear();

            if (args != null)
            {
                foreach (string key in args.Keys)
                {
                    StringFunctionArgument sfArg = args[key] as StringFunctionArgument;
                    if (sfArg != null)
                    {
                        ArgumentControl argCtrl = new ArgumentControl();
                        argCtrl.ArgumentKey = sfArg.Name;
                        argCtrl.LabelText = sfArg.Name;
                        argCtrl.Value = sfArg.DefaultValue.ToString();
                        argCtrl.Visible = true;

                        flowLayoutPanelArgument.Controls.Add(argCtrl);
                    }
                }
            }
        }

        public Dictionary<string, object> ComposeArgumentList()
        {
            Dictionary<string, object> arguments = new Dictionary<string, object>();

            foreach (Control ctrl in flowLayoutPanelArgument.Controls)
            {
                if (ctrl is ArgumentControl)
                {
                    ArgumentControl argCtrl = ctrl as ArgumentControl;
                    StringFunctionArgument sfArg = new StringFunctionArgument(argCtrl.ArgumentKey);
                    sfArg.Value = argCtrl.Value;
                    arguments.Add(sfArg.Name, sfArg);
                }
            }

            return arguments;
        }

        public void Clear()
        {
            flowLayoutPanelArgument.Controls.Clear();
        }

        #region IHandle<StringFunctionSelectedMessage> Members

        public new void Handle(StringFunctionSelectedMessage message)
        {
            Clear();
            RenderArgumentBox(Processor.GetArgumentDictionary(message.StringFunctionType));
        }

        #endregion
    }
}
