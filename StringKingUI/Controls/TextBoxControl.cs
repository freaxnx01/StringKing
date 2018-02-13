using System.Windows.Forms;

namespace StringKingUI
{
    public partial class TextBoxControl : UserControl
    {
        public TextBoxControl()
        {
            InitializeComponent();
            textBoxMain.MaxLength = int.MaxValue;
        }

        public new string Text
        {
            get
            {
                return textBoxMain.Text;
            }

            set
            {
                textBoxMain.Text = value;
            }
        }

        public new string[] Lines
        {
            get
            {
                return textBoxMain.Lines;
            }
        }

        private void textBoxMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                textBoxMain.SelectAll();
            }
        }

        private void textBoxMain_Enter(object sender, System.EventArgs e)
        {
            textBoxMain.SelectAll();
        }
    }
}
