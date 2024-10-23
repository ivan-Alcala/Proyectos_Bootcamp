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
            cbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCriticity.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPercentComplete.DropDownStyle = ComboBoxStyle.DropDownList;

            // Establece el primer elemento como seleccionado en cada ComboBox
            cbLocation.SelectedIndex = 0;
            cbType.SelectedIndex = 0;
            cbCriticity.SelectedIndex = 0;
            cbStatus.SelectedIndex = 0;
            cbPercentComplete.SelectedIndex = 0;
        }

        private void BtSubmit_Click(object sender, EventArgs e)
        {
            // Verifica que los campos obligatorios no estén vacíos
            if (string.IsNullOrWhiteSpace(tbTitle.Text) ||
                string.IsNullOrWhiteSpace(rtbDescription.Text) ||
                clbEnviroment.CheckedItems.Count == 0)
            {
                MessageBox.Show("Los campos de Título, Descripción y uno de los entornos deben estar completos.",
                    "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Construye el mensaje con los campos no vacíos
            string message = "Campos completados:\n";

            if (!string.IsNullOrWhiteSpace(tbTitle.Text))
                message += $"- Título: {tbTitle.Text}\n";

            if (!string.IsNullOrWhiteSpace(cbLocation.Text))
                message += $"- Ubicación: {cbLocation.Text}\n";

            if (!string.IsNullOrWhiteSpace(cbType.Text))
                message += $"- Tipo: {cbType.Text}\n";

            if (!string.IsNullOrWhiteSpace(cbCriticity.Text))
                message += $"- Criticidad: {cbCriticity.Text}\n";

            if (!string.IsNullOrWhiteSpace(rtbDescription.Text))
                message += $"- Descripción: {rtbDescription.Text}\n";

            if (!string.IsNullOrWhiteSpace(dtpStartDate.Text))
                message += $"- Fecha de inicio: {dtpStartDate.Text}\n";

            if (nudDurationH.Value > 0)
                message += $"- Duración: {nudDurationH.Value} horas\n";

            if (!string.IsNullOrWhiteSpace(cbStatus.Text))
                message += $"- Estado: {cbStatus.Text}\n";

            if (!string.IsNullOrWhiteSpace(cbPercentComplete.Text))
                message += $"- Porcentaje completado: {cbPercentComplete.Text}\n";

            // Entornos seleccionados
            if (clbEnviroment.CheckedItems.Count > 0)
            {
                message += "- Entornos seleccionados:\n";
                foreach (var item in clbEnviroment.CheckedItems)
                {
                    message += $"  - {item}\n";
                }
            }

            if (cbSendEmail.Checked)
                message += "- Se enviará un correo electrónico\n";

            // Mostrar el mensaje en un MessageBox
            MessageBox.Show(message, "Información ingresada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btNewForm_Click(object sender, EventArgs e)
        {
            FormMain formNew = new FormMain();
            formNew.Show();
        }
    }
}