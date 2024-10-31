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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btShowDataPatient = new System.Windows.Forms.Button();
            this.btShowDataDoctor = new System.Windows.Forms.Button();
            this.btShowDataAdminStaff = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btRemovePerson = new System.Windows.Forms.Button();
            this.btSavePerson = new System.Windows.Forms.Button();
            this.btAddPerson = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.dtGdVwShowPersons = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGdVwShowPersons)).BeginInit();
            this.SuspendLayout();
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
            this.flowLayoutPanel1.Size = new System.Drawing.Size(495, 38);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // btShowDataPatient
            // 
            this.btShowDataPatient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btShowDataPatient.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btShowDataPatient.Location = new System.Drawing.Point(0, 0);
            this.btShowDataPatient.Margin = new System.Windows.Forms.Padding(0);
            this.btShowDataPatient.Name = "btShowDataPatient";
            this.btShowDataPatient.Size = new System.Drawing.Size(108, 28);
            this.btShowDataPatient.TabIndex = 1;
            this.btShowDataPatient.Text = "Pacientes";
            this.btShowDataPatient.UseVisualStyleBackColor = true;
            // 
            // btShowDataDoctor
            // 
            this.btShowDataDoctor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btShowDataDoctor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btShowDataDoctor.Location = new System.Drawing.Point(108, 0);
            this.btShowDataDoctor.Margin = new System.Windows.Forms.Padding(0);
            this.btShowDataDoctor.Name = "btShowDataDoctor";
            this.btShowDataDoctor.Size = new System.Drawing.Size(125, 28);
            this.btShowDataDoctor.TabIndex = 2;
            this.btShowDataDoctor.Text = "Doctores";
            this.btShowDataDoctor.UseVisualStyleBackColor = true;
            // 
            // btShowDataAdminStaff
            // 
            this.btShowDataAdminStaff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btShowDataAdminStaff.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btShowDataAdminStaff.Location = new System.Drawing.Point(233, 0);
            this.btShowDataAdminStaff.Margin = new System.Windows.Forms.Padding(0);
            this.btShowDataAdminStaff.Name = "btShowDataAdminStaff";
            this.btShowDataAdminStaff.Size = new System.Drawing.Size(233, 28);
            this.btShowDataAdminStaff.TabIndex = 4;
            this.btShowDataAdminStaff.Text = "Personal administrativo";
            this.btShowDataAdminStaff.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtGdVwShowPersons, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(625, 123);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // btRemovePerson
            // 
            this.btRemovePerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRemovePerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btRemovePerson.Enabled = false;
            this.btRemovePerson.FlatAppearance.BorderSize = 0;
            this.btRemovePerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRemovePerson.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRemovePerson.Image = global::WinFormGestionHospital.Properties.Resources.basura;
            this.btRemovePerson.Location = new System.Drawing.Point(13, 0);
            this.btRemovePerson.Margin = new System.Windows.Forms.Padding(0);
            this.btRemovePerson.Name = "btRemovePerson";
            this.btRemovePerson.Size = new System.Drawing.Size(37, 32);
            this.btRemovePerson.TabIndex = 11;
            this.btRemovePerson.UseVisualStyleBackColor = true;
            this.btRemovePerson.Click += new System.EventHandler(this.btRemovePerson_Click);
            // 
            // btSavePerson
            // 
            this.btSavePerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSavePerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSavePerson.Enabled = false;
            this.btSavePerson.FlatAppearance.BorderSize = 0;
            this.btSavePerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSavePerson.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSavePerson.Image = global::WinFormGestionHospital.Properties.Resources.disco;
            this.btSavePerson.Location = new System.Drawing.Point(50, 0);
            this.btSavePerson.Margin = new System.Windows.Forms.Padding(0);
            this.btSavePerson.Name = "btSavePerson";
            this.btSavePerson.Size = new System.Drawing.Size(37, 32);
            this.btSavePerson.TabIndex = 10;
            this.btSavePerson.UseVisualStyleBackColor = true;
            this.btSavePerson.Click += new System.EventHandler(this.BtSavePerson_Click);
            // 
            // btAddPerson
            // 
            this.btAddPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAddPerson.FlatAppearance.BorderSize = 0;
            this.btAddPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAddPerson.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAddPerson.Image = global::WinFormGestionHospital.Properties.Resources.agregar;
            this.btAddPerson.Location = new System.Drawing.Point(87, 0);
            this.btAddPerson.Margin = new System.Windows.Forms.Padding(0);
            this.btAddPerson.Name = "btAddPerson";
            this.btAddPerson.Size = new System.Drawing.Size(37, 32);
            this.btAddPerson.TabIndex = 9;
            this.btAddPerson.UseVisualStyleBackColor = true;
            this.btAddPerson.Click += new System.EventHandler(this.btAddPerson_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btAddPerson);
            this.flowLayoutPanel2.Controls.Add(this.btSavePerson);
            this.flowLayoutPanel2.Controls.Add(this.btRemovePerson);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(498, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(124, 32);
            this.flowLayoutPanel2.TabIndex = 11;
            // 
            // dtGdVwShowPersons
            // 
            this.dtGdVwShowPersons.AllowUserToAddRows = false;
            this.dtGdVwShowPersons.AllowUserToDeleteRows = false;
            this.dtGdVwShowPersons.AllowUserToResizeColumns = false;
            this.dtGdVwShowPersons.AllowUserToResizeRows = false;
            this.dtGdVwShowPersons.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtGdVwShowPersons.BackgroundColor = System.Drawing.Color.White;
            this.dtGdVwShowPersons.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtGdVwShowPersons.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtGdVwShowPersons.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGdVwShowPersons.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGdVwShowPersons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dtGdVwShowPersons, 2);
            this.dtGdVwShowPersons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGdVwShowPersons.Location = new System.Drawing.Point(3, 41);
            this.dtGdVwShowPersons.Name = "dtGdVwShowPersons";
            this.dtGdVwShowPersons.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGdVwShowPersons.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtGdVwShowPersons.RowHeadersVisible = false;
            this.dtGdVwShowPersons.RowHeadersWidth = 51;
            this.dtGdVwShowPersons.RowTemplate.Height = 24;
            this.dtGdVwShowPersons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGdVwShowPersons.Size = new System.Drawing.Size(619, 79);
            this.dtGdVwShowPersons.TabIndex = 12;
            this.dtGdVwShowPersons.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGdVwShowPersons_CellValueChanged);
            this.dtGdVwShowPersons.SelectionChanged += new System.EventHandler(this.dtGdVwShowPersons_SelectionChanged);
            // 
            // UserControlPersons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UserControlPersons";
            this.Size = new System.Drawing.Size(625, 123);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGdVwShowPersons)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btShowDataPatient;
        private System.Windows.Forms.Button btShowDataDoctor;
        private System.Windows.Forms.Button btShowDataAdminStaff;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btAddPerson;
        private System.Windows.Forms.Button btSavePerson;
        private System.Windows.Forms.Button btRemovePerson;
        private System.Windows.Forms.DataGridView dtGdVwShowPersons;
    }
}
