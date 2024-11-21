using System;
using System.Web.UI;

namespace IntroduccionASP.NET
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button1.Text = TextBox1.Text;
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Button1.Text = ListBox1.SelectedItem.Text;
        }
    }
}