
using System;
using System.Windows.Forms;

namespace Lab4_MIP
{
    public partial class KeywordForm : Form
    {
        public string Keyword
        {
            get { return keyword_textbox.Text.Trim(); }
        }

        public KeywordForm()
        {
            InitializeComponent();

            ok_btn.DialogResult = DialogResult.None;
            cancel_btn.DialogResult = DialogResult.Cancel;

            AcceptButton = ok_btn;
            CancelButton = cancel_btn;

            ok_btn.Click -= ok_btn_Click;
            ok_btn.Click += ok_btn_Click;
        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Keyword))
            {
                MessageBox.Show(
                    "Adj meg egy kulcsszot!",
                    "Hiba",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                keyword_textbox.Focus();
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void KeywordForm_Load(object sender, EventArgs e)
        {
        }

        private void label_keyword_Click(object sender, EventArgs e)
        {
        }
    }
}



