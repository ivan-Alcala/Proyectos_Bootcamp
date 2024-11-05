using ConexionBBDD.Class;
using ConexionBBDD.Class.Model;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ConexionBBDD.Forms
{
    public partial class CRUDJob : UserControl
    {
        BBDDConnect bbddConnect;
        Job _job = new Job();

        public CRUDJob(BBDDConnect bbddConnect)
        {
            this.bbddConnect = bbddConnect;
            InitializeComponent();
            InitStyleComponent();
            LoadJobs();
        }

        #region Style
        private void InitStyleComponent()
        {
            SelectedButtonStyle(btShowDataJobs);

            // DataGridView de Persons
            DataGridViewCellStyle selectedRowStyle = dtGdVwShowData.RowsDefaultCellStyle;
            selectedRowStyle.SelectionBackColor = ColorTranslator.FromHtml("#d6e0ef");
            selectedRowStyle.SelectionForeColor = ColorTranslator.FromHtml("#282b3e");
            // Establecer el estilo para las filas pares
            dtGdVwShowData.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#e9eff6");
            // Establecer el estilo para las filas impares
            dtGdVwShowData.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#ffffff");
            dtGdVwShowData.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#f3f6fa");
        }

        private void UnselectedButtonStyle(Button button)
        {
            // Limpia los paneles agregados anteriormente
            button.Controls.Clear();

            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = Color.Transparent;
            button.ForeColor = ColorTranslator.FromHtml("#9baaba");

            // Aplica negrita solo si no está en negrita
            if (button.Font.Style != FontStyle.Bold)
            {
                button.Font = new Font(button.Font, FontStyle.Bold);
            }

            button.FlatAppearance.BorderSize = 0;

            // Crea el borde inferior y agrégalo
            Panel borderBottom = new Panel
            {
                Height = 1,
                Dock = DockStyle.Bottom,
                BackColor = ColorTranslator.FromHtml("#edeef2")
            };

            button.Controls.Add(borderBottom);
        }

        private void SelectedButtonStyle(Button button)
        {
            // Limpia los paneles agregados anteriormente
            button.Controls.Clear();

            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = Color.Transparent;
            button.ForeColor = ColorTranslator.FromHtml("#3579fe");

            // Aplica negrita solo si no está en negrita
            if (button.Font.Style != FontStyle.Bold)
            {
                button.Font = new Font(button.Font, FontStyle.Bold);
            }

            button.FlatAppearance.BorderSize = 0;

            // Crea el borde inferior y agrégalo
            Panel borderBottom = new Panel
            {
                Height = 1,
                Dock = DockStyle.Bottom,
                BackColor = ColorTranslator.FromHtml("#1361fe")
            };

            button.Controls.Add(borderBottom);
        }
        #endregion

        private void LoadJobs()
        {
            if (bbddConnect.IsConnected())
            {
                List<Job> jobs = _job.GetJobs(bbddConnect.connection);
                dtGdVwShowData.DataSource = jobs;
            }
            else
            {
                MessageBox.Show("Debe estar conectado a la base de datos para cargar los trabajos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btShowDataJobs_Click(object sender, System.EventArgs e)
        {
            bbddConnect.Connect();
            LoadJobs();
        }
    }
}
