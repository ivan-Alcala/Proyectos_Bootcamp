using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntroducionWinForm
{
    public partial class FormMain : Form
    {
        public FormMain()
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
