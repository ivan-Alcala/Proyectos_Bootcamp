using IntroducionWinForm;
using System;
using System.Windows.Forms;

namespace FormTask
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            // Configura ComboBox para que no se puedan escribir
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCriticity.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPercentComplete.DropDownStyle = ComboBoxStyle.DropDownList;

            // Establece el primer elemento como seleccionado en cada ComboBox
            cmbLocation.SelectedIndex = 0;
            cmbType.SelectedIndex = 0;
            cmbCriticity.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            cmbPercentComplete.SelectedIndex = 0;

            // Inicializa el DateTimePicker para que aparezca "vacío"
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.CustomFormat = " ";
        }

        private void BtSubmit_Click(object sender, EventArgs e)
        {
            // Verifica que los campos obligatorios no estén vacíos
            if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(rtbDescription.Text) ||
                clbEnviroment.CheckedItems.Count == 0)
            {
                MessageBox.Show("Los campos de Título, Descripción y uno de los entornos deben estar completos.",
                    "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifica si el DateTimePicker tiene el formato custom
            if (dtpStartDate.Format == DateTimePickerFormat.Custom)
            {
                MessageBox.Show("Debe seleccionar una fecha de inicio.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Construye el mensaje con los campos no vacíos
            string message = "Campos completados:\n";

            if (!string.IsNullOrWhiteSpace(txtTitle.Text))
                message += $"- Título: {txtTitle.Text}\n";

            if (!string.IsNullOrWhiteSpace(cmbLocation.Text))
                message += $"- Ubicación: {cmbLocation.Text}\n";

            if (!string.IsNullOrWhiteSpace(cmbType.Text))
                message += $"- Tipo: {cmbType.Text}\n";

            if (!string.IsNullOrWhiteSpace(cmbCriticity.Text))
                message += $"- Criticidad: {cmbCriticity.Text}\n";

            if (!string.IsNullOrWhiteSpace(rtbDescription.Text))
                message += $"- Descripción: {rtbDescription.Text}\n";

            if (!string.IsNullOrWhiteSpace(dtpStartDate.Text))
                message += $"- Fecha de inicio: {dtpStartDate.Text}\n";

            if (nudDurationH.Value > 0)
                message += $"- Duración: {nudDurationH.Value} horas\n";

            if (!string.IsNullOrWhiteSpace(cmbStatus.Text))
                message += $"- Estado: {cmbStatus.Text}\n";

            if (!string.IsNullOrWhiteSpace(cmbPercentComplete.Text))
                message += $"- Porcentaje completado: {cmbPercentComplete.Text}\n";

            // Entornos seleccionados
            if (clbEnviroment.CheckedItems.Count > 0)
            {
                message += "- Entornos seleccionados:\n";
                foreach (var item in clbEnviroment.CheckedItems)
                {
                    message += $"  - {item}\n";
                }
            }

            if (chkSendEmail.Checked)
                message += "- Se enviará un correo electrónico\n";

            // Mostrar el mensaje en un MessageBox
            MessageBox.Show(message, "Información ingresada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btNewForm_Click(object sender, EventArgs e)
        {
            FormDaily formNew = new FormDaily();
            formNew.Show();
        }

        private void DtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpStartDate.Format = DateTimePickerFormat.Short;
        }
    }
}