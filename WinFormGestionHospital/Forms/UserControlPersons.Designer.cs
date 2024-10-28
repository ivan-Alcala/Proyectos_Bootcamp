namespace WinFormGestionHospital.Forms
{
    partial class UserControlPersons
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.fwLtPnHospitalOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.btShowDataPatient = new System.Windows.Forms.Button();
            this.btShowDataDoctor = new System.Windows.Forms.Button();
            this.btShowDataAdminStaff = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Height = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assignedDoctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.condition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.admissionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fwLtPnHospitalOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // fwLtPnHospitalOptions
            // 
            this.fwLtPnHospitalOptions.BackColor = System.Drawing.Color.Transparent;
            this.fwLtPnHospitalOptions.Controls.Add(this.btShowDataPatient);
            this.fwLtPnHospitalOptions.Controls.Add(this.btShowDataDoctor);
            this.fwLtPnHospitalOptions.Controls.Add(this.btShowDataAdminStaff);
            this.fwLtPnHospitalOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.fwLtPnHospitalOptions.Location = new System.Drawing.Point(0, 0);
            this.fwLtPnHospitalOptions.Margin = new System.Windows.Forms.Padding(0);
            this.fwLtPnHospitalOptions.Name = "fwLtPnHospitalOptions";
            this.fwLtPnHospitalOptions.Size = new System.Drawing.Size(1053, 54);
            this.fwLtPnHospitalOptions.TabIndex = 7;
            // 
            // btShowDataPatient
            // 
            this.btShowDataPatient.Location = new System.Drawing.Point(0, 0);
            this.btShowDataPatient.Margin = new System.Windows.Forms.Padding(0);
            this.btShowDataPatient.Name = "btShowDataPatient";
            this.btShowDataPatient.Size = new System.Drawing.Size(86, 39);
            this.btShowDataPatient.TabIndex = 1;
            this.btShowDataPatient.Text = "Pacientes";
            this.btShowDataPatient.UseVisualStyleBackColor = true;
            // 
            // btShowDataDoctor
            // 
            this.btShowDataDoctor.Location = new System.Drawing.Point(86, 0);
            this.btShowDataDoctor.Margin = new System.Windows.Forms.Padding(0);
            this.btShowDataDoctor.Name = "btShowDataDoctor";
            this.btShowDataDoctor.Size = new System.Drawing.Size(94, 39);
            this.btShowDataDoctor.TabIndex = 2;
            this.btShowDataDoctor.Text = "Doctores";
            this.btShowDataDoctor.UseVisualStyleBackColor = true;
            // 
            // btShowDataAdminStaff
            // 
            this.btShowDataAdminStaff.Location = new System.Drawing.Point(180, 0);
            this.btShowDataAdminStaff.Margin = new System.Windows.Forms.Padding(0);
            this.btShowDataAdminStaff.Name = "btShowDataAdminStaff";
            this.btShowDataAdminStaff.Size = new System.Drawing.Size(177, 39);
            this.btShowDataAdminStaff.TabIndex = 4;
            this.btShowDataAdminStaff.Text = "Personal administrativo";
            this.btShowDataAdminStaff.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPerson,
            this.Name,
            this.DateOfBirth,
            this.Height,
            this.Weight,
            this.assignedDoctor,
            this.condition,
            this.admissionDate});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1053, 67);
            this.dataGridView1.TabIndex = 8;
            // 
            // idPerson
            // 
            this.idPerson.HeaderText = "ID";
            this.idPerson.MinimumWidth = 6;
            this.idPerson.Name = "idPerson";
            this.idPerson.ReadOnly = true;
            this.idPerson.Width = 125;
            // 
            // Name
            // 
            this.Name.HeaderText = " Nombre";
            this.Name.MinimumWidth = 6;
            this.Name.Name = "Name";
            this.Name.Width = 125;
            // 
            // DateOfBirth
            // 
            this.DateOfBirth.HeaderText = "Fecha de Nacimiento";
            this.DateOfBirth.MinimumWidth = 6;
            this.DateOfBirth.Name = "DateOfBirth";
            this.DateOfBirth.Width = 125;
            // 
            // Height
            // 
            this.Height.HeaderText = "Altura";
            this.Height.MinimumWidth = 6;
            this.Height.Name = "Height";
            this.Height.Width = 125;
            // 
            // Weight
            // 
            this.Weight.HeaderText = "Peso";
            this.Weight.MinimumWidth = 6;
            this.Weight.Name = "Weight";
            this.Weight.Width = 125;
            // 
            // assignedDoctor
            // 
            this.assignedDoctor.HeaderText = "Médico Asignado";
            this.assignedDoctor.MinimumWidth = 6;
            this.assignedDoctor.Name = "assignedDoctor";
            this.assignedDoctor.Width = 125;
            // 
            // condition
            // 
            this.condition.HeaderText = "Condición";
            this.condition.MinimumWidth = 6;
            this.condition.Name = "condition";
            this.condition.Width = 125;
            // 
            // admissionDate
            // 
            this.admissionDate.HeaderText = "Fecha de Admisión";
            this.admissionDate.MinimumWidth = 6;
            this.admissionDate.Name = "admissionDate";
            this.admissionDate.ReadOnly = true;
            this.admissionDate.Width = 125;
            // 
            // UsCtPersons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.fwLtPnHospitalOptions);
            this.Name = null;
            this.Size = new System.Drawing.Size(1053, 121);
            this.fwLtPnHospitalOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel fwLtPnHospitalOptions;
        private System.Windows.Forms.Button btShowDataPatient;
        private System.Windows.Forms.Button btShowDataDoctor;
        private System.Windows.Forms.Button btShowDataAdminStaff;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn Height;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn assignedDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn condition;
        private System.Windows.Forms.DataGridViewTextBoxColumn admissionDate;
    }
}
