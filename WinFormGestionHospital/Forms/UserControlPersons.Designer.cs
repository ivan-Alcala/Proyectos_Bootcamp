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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btAddPerson = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btShowDataPatient = new System.Windows.Forms.Button();
            this.btShowDataDoctor = new System.Windows.Forms.Button();
            this.btShowDataAdminStaff = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 2);
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(405, 64);
            this.dataGridView1.TabIndex = 12;
            // 
            // btAddPerson
            // 
            this.btAddPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddPerson.Location = new System.Drawing.Point(7, 0);
            this.btAddPerson.Margin = new System.Windows.Forms.Padding(0);
            this.btAddPerson.Name = "btAddPerson";
            this.btAddPerson.Size = new System.Drawing.Size(37, 36);
            this.btAddPerson.TabIndex = 9;
            this.btAddPerson.Text = "+";
            this.btAddPerson.UseVisualStyleBackColor = true;
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
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(411, 120);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btAddPerson);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(364, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(44, 44);
            this.flowLayoutPanel2.TabIndex = 11;
            // 
            // UserControlPersons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UserControlPersons";
            this.Size = new System.Drawing.Size(411, 120);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btAddPerson;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btShowDataPatient;
        private System.Windows.Forms.Button btShowDataDoctor;
        private System.Windows.Forms.Button btShowDataAdminStaff;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}
