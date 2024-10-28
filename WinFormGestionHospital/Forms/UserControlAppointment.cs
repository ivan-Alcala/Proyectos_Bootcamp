using System.Windows.Forms;
using WinFormGestionHospital.Class;

namespace WinFormGestionHospital.Forms
{
    public partial class UserControlAppointment : UserControl
    {
        private readonly Hospital _hospital;

        public UserControlAppointment(Hospital hospital)
        {
            InitializeComponent();
            this._hospital = hospital;
        }
    }
}
