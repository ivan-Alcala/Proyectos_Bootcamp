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
            this.dtGdVwShowPersons = new System.Windows.Forms.DataGridView();
            this.btAddPerson = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btShowDataPatient = new System.Windows.Forms.Button();
            this.btShowDataDoctor = new System.Windows.Forms.Button();
            this.btShowDataAdminStaff = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btSavePerson = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtGdVwShowPersons)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtGdVwShowPersons
            // 
            this.dtGdVwShowPersons.AllowUserToAddRows = false;
            this.dtGdVwShowPersons.AllowUserToDeleteRows = false;
            this.dtGdVwShowPersons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dtGdVwShowPersons, 2);
            this.dtGdVwShowPersons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGdVwShowPersons.Location = new System.Drawing.Point(3, 53);
            this.dtGdVwShowPersons.Name = "dtGdVwShowPersons";
            this.dtGdVwShowPersons.RowHeadersVisible = false;
            this.dtGdVwShowPersons.RowHeadersWidth = 51;
            this.dtGdVwShowPersons.RowTemplate.Height = 24;
            this.dtGdVwShowPersons.Size = new System.Drawing.Size(438, 64);
            this.dtGdVwShowPersons.TabIndex = 12;
            this.dtGdVwShowPersons.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGdVwShowPersons_CellValueChanged);
            // 
            // btAddPerson
            // 
            this.btAddPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddPerson.Location = new System.Drawing.Point(40, 0);
            this.btAddPerson.Margin = new System.Windows.Forms.Padding(0);
            this.btAddPerson.Name = "btAddPerson";
            this.btAddPerson.Size = new System.Drawing.Size(37, 36);
            this.btAddPerson.TabIndex = 9;
            this.btAddPerson.Text = "+";
            this.btAddPerson.UseVisualStyleBackColor = true;
            this.btAddPerson.Click += new System.EventHandler(this.btAddPerson_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.btShowDataPatient);
            this.flowLayoutPanel1.Controls.Add(this.btShowDataDoctor);
            this.flowLayoutPanel1.Controls.Add(this.btShowDataAdminStaff);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(361, 50);
            this.flowLayoutPanel1.TabIndex = 10;
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtGdVwShowPersons, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(444, 120);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btAddPerson);
            this.flowLayoutPanel2.Controls.Add(this.btSavePerson);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(364, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(77, 44);
            this.flowLayoutPanel2.TabIndex = 11;
            // 
            // btSavePerson
            // 
            this.btSavePerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSavePerson.Location = new System.Drawing.Point(3, 0);
            this.btSavePerson.Margin = new System.Windows.Forms.Padding(0);
            this.btSavePerson.Name = "btSavePerson";
            this.btSavePerson.Size = new System.Drawing.Size(37, 36);
            this.btSavePerson.TabIndex = 10;
            this.btSavePerson.Text = "->";
            this.btSavePerson.UseVisualStyleBackColor = true;
            this.btSavePerson.Click += new System.EventHandler(this.BtSavePerson_Click);
            // 
            // UserControlPersons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UserControlPersons";
            this.Size = new System.Drawing.Size(444, 120);
            ((System.ComponentModel.ISupportInitialize)(this.dtGdVwShowPersons)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGdVwShowPersons;
        private System.Windows.Forms.Button btAddPerson;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btShowDataPatient;
        private System.Windows.Forms.Button btShowDataDoctor;
        private System.Windows.Forms.Button btShowDataAdminStaff;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btSavePerson;
    }
}
