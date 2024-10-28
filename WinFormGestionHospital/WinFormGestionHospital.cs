using System.Windows.Forms;
using WinFormGestionHospital.Class;
using WinFormGestionHospital.Forms;

namespace WinFormGestionHospital
{
    public partial class WinFormGestionHospital : Form
    {
        Hospital _hospital = new Hospital();

        public WinFormGestionHospital()
        {
            InitializeComponent();
            _hospital.AddTestData();
            ShowFormPersons(_hospital);
        }

        public void ShowFormPersons(Hospital hospital)
        {
            UserControlPersons userControlPersons = new UserControlPersons(hospital);
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
