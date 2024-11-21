namespace WinFormGestionHospital
{
    partial class WinFormGestionHospital
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btShowFormPerson = new System.Windows.Forms.Button();
            this.btShowFormMedicalRecord = new System.Windows.Forms.Button();
            this.btShowFormAppointment = new System.Windows.Forms.Button();
            this.fwLtPnHospitalOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.pnMainContent = new System.Windows.Forms.Panel();
            this.fwLtPnHospitalOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btShowFormPerson
            // 
            this.btShowFormPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btShowFormPerson.FlatAppearance.BorderSize = 0;
            this.btShowFormPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btShowFormPerson.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btShowFormPerson.Location = new System.Drawing.Point(0, 0);
            this.btShowFormPerson.Margin = new System.Windows.Forms.Padding(0);
            this.btShowFormPerson.Name = "btShowFormPerson";
            this.btShowFormPerson.Size = new System.Drawing.Size(215, 39);
            this.btShowFormPerson.TabIndex = 1;
            this.btShowFormPerson.Text = "Lista de Personas";
            this.btShowFormPerson.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btShowFormPerson.UseVisualStyleBackColor = true;
            // 
            // btShowFormMedicalRecord
            // 
            this.btShowFormMedicalRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btShowFormMedicalRecord.FlatAppearance.BorderSize = 0;
            this.btShowFormMedicalRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btShowFormMedicalRecord.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btShowFormMedicalRecord.Location = new System.Drawing.Point(215, 0);
            this.btShowFormMedicalRecord.Margin = new System.Windows.Forms.Padding(0);
            this.btShowFormMedicalRecord.Name = "btShowFormMedicalRecord";
            this.btShowFormMedicalRecord.Size = new System.Drawing.Size(216, 39);
            this.btShowFormMedicalRecord.TabIndex = 2;
            this.btShowFormMedicalRecord.Text = "Historiales medicos";
            this.btShowFormMedicalRecord.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btShowFormMedicalRecord.UseVisualStyleBackColor = true;
            this.btShowFormMedicalRecord.Visible = false;
            // 
            // btShowFormAppointment
            // 
            this.btShowFormAppointment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btShowFormAppointment.FlatAppearance.BorderSize = 0;
            this.btShowFormAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btShowFormAppointment.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btShowFormAppointment.Location = new System.Drawing.Point(431, 0);
            this.btShowFormAppointment.Margin = new System.Windows.Forms.Padding(0);
            this.btShowFormAppointment.Name = "btShowFormAppointment";
            this.btShowFormAppointment.Size = new System.Drawing.Size(122, 39);
            this.btShowFormAppointment.TabIndex = 4;
            this.btShowFormAppointment.Text = "Citas";
            this.btShowFormAppointment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btShowFormAppointment.UseVisualStyleBackColor = true;
            this.btShowFormAppointment.Visible = false;
            // 
            // fwLtPnHospitalOptions
            // 
            this.fwLtPnHospitalOptions.BackColor = System.Drawing.Color.Transparent;
            this.fwLtPnHospitalOptions.Controls.Add(this.btShowFormPerson);
            this.fwLtPnHospitalOptions.Controls.Add(this.btShowFormMedicalRecord);
            this.fwLtPnHospitalOptions.Controls.Add(this.btShowFormAppointment);
            this.fwLtPnHospitalOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.fwLtPnHospitalOptions.Location = new System.Drawing.Point(20, 20);
            this.fwLtPnHospitalOptions.Margin = new System.Windows.Forms.Padding(0);
            this.fwLtPnHospitalOptions.Name = "fwLtPnHospitalOptions";
            this.fwLtPnHospitalOptions.Size = new System.Drawing.Size(942, 54);
            this.fwLtPnHospitalOptions.TabIndex = 6;
            // 
            // pnMainContent
            // 
            this.pnMainContent.BackColor = System.Drawing.Color.Transparent;
            this.pnMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMainContent.Location = new System.Drawing.Point(20, 74);
            this.pnMainContent.Name = "pnMainContent";
            this.pnMainContent.Size = new System.Drawing.Size(942, 399);
            this.pnMainContent.TabIndex = 7;
            // 
            // WinFormGestionHospital
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(982, 493);
            this.Controls.Add(this.pnMainContent);
            this.Controls.Add(this.fwLtPnHospitalOptions);
            this.Name = "WinFormGestionHospital";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion del hopital - GUI";
            this.fwLtPnHospitalOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btShowFormPerson;
        private System.Windows.Forms.Button btShowFormMedicalRecord;
        private System.Windows.Forms.Button btShowFormAppointment;
        private System.Windows.Forms.FlowLayoutPanel fwLtPnHospitalOptions;
        private System.Windows.Forms.Panel pnMainContent;
    }
}

