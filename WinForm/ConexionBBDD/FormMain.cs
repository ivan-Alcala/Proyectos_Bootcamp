using FormEmployeeDB.Class;
using FormEmployeeDB.Forms;
using System;
using System.Windows.Forms;

namespace FormEmployeeDB
{
    public partial class FormMain : Form
    {
        private DBConnect dbConnection;

        public FormMain()
        {
            InitializeComponent();
            lbBBDDConnectionStates.Text = "Desconectado";
            btBBDDDisconect.Enabled = false;
        }

        private void btBBDDConect_Click(object sender, EventArgs e)
        {
            dbConnection = new DBConnect();

            if (dbConnection.Connect())
            {
                lbBBDDConnectionStates.Text = "Conectado";
                btBBDDConect.Enabled = false;
                btBBDDDisconect.Enabled = true;
                ShowFormJobs();
            }
            else
            {
                MessageBox.Show("Error al conectar a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbBBDDConnectionStates.Text = "Error en la conexión";
            }
        }

        private void btBBDDDisconect_Click(object sender, EventArgs e)
        {
            dbConnection.Disconnect();
            lbBBDDConnectionStates.Text = "Desconectado";
            btBBDDConect.Enabled = true;
            btBBDDDisconect.Enabled = false;

            ReplacePanelContent(pnJobsView, new UserControl());
        }

        public void ShowFormJobs()
        {
            UserControlJobs crudJob = new UserControlJobs();
            ReplacePanelContent(pnJobsView, crudJob);
        }

        public void ReplacePanelContent<T>(Panel panel, T userControl) where T : UserControl
        {
            panel.Controls.Clear();
            panel.Controls.Add(userControl as Control);
            userControl.Dock = DockStyle.Fill; // Para que ocupe todo el espacio del panel
        }
    }
}
