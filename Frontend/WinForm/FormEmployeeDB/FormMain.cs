using FormEmployeeDB.Class.DataGridViewManager;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FormEmployeeDB
{
    public partial class FormMain : Form
    {
        DGVJob _dGVJob;
        DGVEmployee _dGVEmplyee;

        public FormMain()
        {
            InitializeComponent();
            InitStyleComponent();

            ShowDataJobs();
        }

        #region Style
        private void InitStyleComponent()
        {
            // DataGridView de Jobs
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

        private void SelectButtonStyle(Button selectedButton, params Button[] otherButtons)
        {
            // Aplica el estilo seleccionado al botón clicado
            SelectedButtonStyle(selectedButton);

            // Aplica el estilo "no seleccionado" a los otros botones
            foreach (var button in otherButtons)
            {
                UnselectedButtonStyle(button);
            }
        }
        #endregion // END - Style

        private void RemoveEvents()
        {
            if (_dGVJob != null)
            {
                // Eliminar eventos realacionados con Jobs
                btShowDataJobs.Click -= _dGVJob.btShowDataJobs_Click;
                btAdd.Click -= _dGVJob.btAddJob_Click;
                btSave.Click -= _dGVJob.btSaveJob_Click;
                btRemove.Click -= _dGVJob.btRemoveJob_Click;
                dtGdVwShowData.CellValueChanged -= _dGVJob.dtGdVwShowJobs_CellValueChanged;
                dtGdVwShowData.SelectionChanged -= _dGVJob.dtGdVwShowJobs_SelectionChanged;
            }

            if (_dGVEmplyee != null)
            {
                // Eliminar eventos realacionados con Employees
                btShowDataEmployees.Click -= _dGVEmplyee.btShowDataEmployees_Click;
                btAdd.Click -= _dGVEmplyee.btAddEmployee_Click;
                btSave.Click -= _dGVEmplyee.btSaveEmployee_Click;
                btRemove.Click -= _dGVEmplyee.btRemoveEmployee_Click;
                dtGdVwShowData.CellValueChanged -= _dGVEmplyee.dtGdVwShowEmployees_CellValueChanged;
                dtGdVwShowData.SelectionChanged -= _dGVEmplyee.dtGdVwShowEmployees_SelectionChanged;
            }
        }

        private void ShowDataJobs()
        {
            _dGVJob = new DGVJob(dtGdVwShowData, btSave, btRemove);

            RemoveEvents();

            _dGVJob.btShowDataJobs_Click(null, EventArgs.Empty); // Simula el evento 'Click' del botón 'btShowDataJobs'

            btShowDataJobs.Click += _dGVJob.btShowDataJobs_Click;
            btAdd.Click += _dGVJob.btAddJob_Click;
            btSave.Click += _dGVJob.btSaveJob_Click;
            btRemove.Click += _dGVJob.btRemoveJob_Click;
            dtGdVwShowData.CellValueChanged += _dGVJob.dtGdVwShowJobs_CellValueChanged;
            dtGdVwShowData.SelectionChanged += _dGVJob.dtGdVwShowJobs_SelectionChanged;

            // Cambia el estilo al botón seleccionado y deselecciona los otros
            SelectButtonStyle(btShowDataJobs, btShowDataEmployees);
        }

        private void ShowDataEmployees()
        {
            _dGVEmplyee = new DGVEmployee(dtGdVwShowData, btSave, btRemove);

            RemoveEvents();

            _dGVEmplyee.btShowDataEmployees_Click(null, EventArgs.Empty); // Simula el evento 'Click' del botón 'btShowDataEmployees'

            btShowDataEmployees.Click += _dGVEmplyee.btShowDataEmployees_Click;
            btAdd.Click += _dGVEmplyee.btAddEmployee_Click;
            btSave.Click += _dGVEmplyee.btSaveEmployee_Click;
            btRemove.Click += _dGVEmplyee.btRemoveEmployee_Click;
            dtGdVwShowData.CellValueChanged += _dGVEmplyee.dtGdVwShowEmployees_CellValueChanged;
            dtGdVwShowData.SelectionChanged += _dGVEmplyee.dtGdVwShowEmployees_SelectionChanged;

            // Cambia el estilo al botón seleccionado y deselecciona los otros
            SelectButtonStyle(btShowDataEmployees, btShowDataJobs);
        }

        private void btShowDataJobs_Click(object sender, EventArgs e)
        {
            ShowDataJobs();
        }

        private void btShowDataEmployees_Click(object sender, EventArgs e)
        {
            ShowDataEmployees();
        }
    }
}