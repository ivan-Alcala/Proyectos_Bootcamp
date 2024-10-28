using System.Windows.Forms;
using WinFormGestionHospital.Class;

namespace WinFormGestionHospital.Forms
{
    public partial class UserControlMedicalRecord : UserControl
    {
        private readonly Hospital _hospital;

        public UserControlMedicalRecord(Hospital hospital)
        {
            InitializeComponent();
            this._hospital = hospital;
        }
    }
}
