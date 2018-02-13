using System;
using System.Windows.Forms;

namespace StringKingUI
{
    public partial class ArgumentControl : UserControl
    {
        public string ArgumentKey { get; set; }

        public string LabelText
        {
            get
            {
                return labelArgument.Text;
            }

            set
            {
                labelArgument.Text = value;
            }
        }
        public object Value
        {
            get
            {
                return textBoxValue.Text;
            }

            set
            {
                textBoxValue.Text = value.ToString();
            }
        }

        public ArgumentControl()
        {
            InitializeComponent();
            textBoxValue.GotFocus += textBoxValue_GotFocus;
        }

        void textBoxValue_GotFocus(object sender, EventArgs e)
        {
            textBoxValue.SelectAll();
        }
    }
}
