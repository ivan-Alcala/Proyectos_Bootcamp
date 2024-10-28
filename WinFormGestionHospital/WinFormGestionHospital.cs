using System.Windows.Forms;
using WinFormGestionHospital.Forms;

namespace WinFormGestionHospital
{
    public partial class WinFormGestionHospital : Form
    {
        public WinFormGestionHospital()
        {
            InitializeComponent();
            ShowFormPersons();
        }

        public void ShowFormPersons()
        {
            UserControlPersons userControlPersons = new UserControlPersons();
            ReplacePanelContent(pnMainContent, userControlPersons);
        }

        public static void ReplacePanelContent<T>(Panel panel, T userControl) where T : UserControl
        {
            panel.Controls.Clear();
            panel.Controls.Add(userControl as Control);
            userControl.Dock = DockStyle.Fill; // Para que ocupe todo el espacio del panel
        }
    }
}
