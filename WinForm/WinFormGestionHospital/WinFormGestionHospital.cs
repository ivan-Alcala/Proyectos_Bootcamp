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

            // Asigna los eventos de los botones
            btShowFormPerson.Click += (sender, e) => { ShowFormPersons(_hospital); };
            btShowFormAppointment.Click += (sender, e) => { ShowFormAppointments(_hospital); };
            btShowFormMedicalRecord.Click += (sender, e) => { ShowFormMedicalRecords(_hospital); };

            //WinFormGestionHospital.DefaultBackColor = DefaultBackColor.;
        }

        public void ShowFormPersons(Hospital hospital)
        {
            UserControlPersons userControlPersons = new UserControlPersons(hospital);
            ReplacePanelContent(pnMainContent, userControlPersons);
        }

        public void ShowFormAppointments(Hospital hospital)
        {
            UserControlAppointment userControlAppointment = new UserControlAppointment(hospital);
            ReplacePanelContent(pnMainContent, userControlAppointment);
        }

        public void ShowFormMedicalRecords(Hospital hospital)
        {
            UserControlMedicalRecord userControlMedicalRecord = new UserControlMedicalRecord(hospital);
            ReplacePanelContent(pnMainContent, userControlMedicalRecord);
        }

        public static void ReplacePanelContent<T>(Panel panel, T userControl) where T : UserControl
        {
            panel.Controls.Clear();
            panel.Controls.Add(userControl as Control);
            userControl.Dock = DockStyle.Fill; // Para que ocupe todo el espacio del panel
        }
    }
}
