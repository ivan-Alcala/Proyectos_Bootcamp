using System;
using System.Windows.Forms;

namespace IntroducionWinForm
{
    public partial class FormDaily : Form
    {
        public FormDaily()
        {
            InitializeComponent();
        }

        private void btShowName_Click(object sender, EventArgs e)
        {
            btShowName.Text = txtbNombre.Text;
        }

        private void lbDaily_SelectedIndexChanged(object sender, EventArgs e)
        {
            btShowName.Text = lbDaily.SelectedItem.ToString();
        }
    }
}
