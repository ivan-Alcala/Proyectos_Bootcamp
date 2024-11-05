using ConexionBBDD.Class;
using System;
using System.Windows.Forms;

namespace ConexionBBDD
{
    public partial class Form1 : Form
    {
        private BBDDConnect dbConnection;

        public Form1()
        {
            InitializeComponent();
            dbConnection = new BBDDConnect();
            lbBBDDConnectionStates.Text = "Desconectado";
            btBBDDDisconect.Enabled = false;
        }

        private void btBBDDConect_Click(object sender, EventArgs e)
        {
            if (dbConnection.Connect())
            {
                lbBBDDConnectionStates.Text = "Conectado";
                btBBDDConect.Enabled = false;
                btBBDDDisconect.Enabled = true;
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
        }
    }
}
