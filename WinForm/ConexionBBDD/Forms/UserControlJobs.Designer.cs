namespace ConexionBBDD.Forms
{
    partial class UserControlJobs
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btShowDataJobs = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btAddJob = new System.Windows.Forms.Button();
            this.btSaveJob = new System.Windows.Forms.Button();
            this.btRemoveJob = new System.Windows.Forms.Button();
            this.dtGdVwShowJobs = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGdVwShowJobs)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtGdVwShowJobs, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(233, 111);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.btShowDataJobs);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 10);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(103, 38);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // btShowDataJobs
            // 
            this.btShowDataJobs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btShowDataJobs.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btShowDataJobs.Location = new System.Drawing.Point(0, 0);
            this.btShowDataJobs.Margin = new System.Windows.Forms.Padding(0);
            this.btShowDataJobs.Name = "btShowDataJobs";
            this.btShowDataJobs.Size = new System.Drawing.Size(84, 28);
            this.btShowDataJobs.TabIndex = 1;
            this.btShowDataJobs.Text = "Jobs";
            this.btShowDataJobs.UseVisualStyleBackColor = true;
            this.btShowDataJobs.Click += new System.EventHandler(this.btShowDataJobs_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btAddJob);
            this.flowLayoutPanel2.Controls.Add(this.btSaveJob);
            this.flowLayoutPanel2.Controls.Add(this.btRemoveJob);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(106, 13);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(124, 32);
            this.flowLayoutPanel2.TabIndex = 11;
            // 
            // btAddJob
            // 
            this.btAddJob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddJob.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAddJob.FlatAppearance.BorderSize = 0;
            this.btAddJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAddJob.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAddJob.Image = global::ConexionBBDD.Properties.Resources.agregar;
            this.btAddJob.Location = new System.Drawing.Point(87, 0);
            this.btAddJob.Margin = new System.Windows.Forms.Padding(0);
            this.btAddJob.Name = "btAddJob";
            this.btAddJob.Size = new System.Drawing.Size(37, 32);
            this.btAddJob.TabIndex = 9;
            this.btAddJob.UseVisualStyleBackColor = true;
            // 
            // btSaveJob
            // 
            this.btSaveJob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveJob.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSaveJob.Enabled = false;
            this.btSaveJob.FlatAppearance.BorderSize = 0;
            this.btSaveJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSaveJob.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSaveJob.Image = global::ConexionBBDD.Properties.Resources.disco;
            this.btSaveJob.Location = new System.Drawing.Point(50, 0);
            this.btSaveJob.Margin = new System.Windows.Forms.Padding(0);
            this.btSaveJob.Name = "btSaveJob";
            this.btSaveJob.Size = new System.Drawing.Size(37, 32);
            this.btSaveJob.TabIndex = 10;
            this.btSaveJob.UseVisualStyleBackColor = true;
            this.btSaveJob.Click += new System.EventHandler(this.btSaveJob_Click);
            // 
            // btRemoveJob
            // 
            this.btRemoveJob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRemoveJob.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btRemoveJob.Enabled = false;
            this.btRemoveJob.FlatAppearance.BorderSize = 0;
            this.btRemoveJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRemoveJob.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRemoveJob.Image = global::ConexionBBDD.Properties.Resources.basura;
            this.btRemoveJob.Location = new System.Drawing.Point(13, 0);
            this.btRemoveJob.Margin = new System.Windows.Forms.Padding(0);
            this.btRemoveJob.Name = "btRemoveJob";
            this.btRemoveJob.Size = new System.Drawing.Size(37, 32);
            this.btRemoveJob.TabIndex = 11;
            this.btRemoveJob.UseVisualStyleBackColor = true;
            this.btRemoveJob.Click += new System.EventHandler(this.btRemoveJob_Click);
            // 
            // dtGdVwShowJobs
            // 
            this.dtGdVwShowJobs.AllowUserToAddRows = false;
            this.dtGdVwShowJobs.AllowUserToDeleteRows = false;
            this.dtGdVwShowJobs.AllowUserToResizeColumns = false;
            this.dtGdVwShowJobs.AllowUserToResizeRows = false;
            this.dtGdVwShowJobs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtGdVwShowJobs.BackgroundColor = System.Drawing.Color.White;
            this.dtGdVwShowJobs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtGdVwShowJobs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtGdVwShowJobs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGdVwShowJobs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGdVwShowJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dtGdVwShowJobs, 2);
            this.dtGdVwShowJobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGdVwShowJobs.Location = new System.Drawing.Point(3, 51);
            this.dtGdVwShowJobs.Name = "dtGdVwShowJobs";
            this.dtGdVwShowJobs.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGdVwShowJobs.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtGdVwShowJobs.RowHeadersVisible = false;
            this.dtGdVwShowJobs.RowHeadersWidth = 51;
            this.dtGdVwShowJobs.RowTemplate.Height = 24;
            this.dtGdVwShowJobs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGdVwShowJobs.Size = new System.Drawing.Size(227, 57);
            this.dtGdVwShowJobs.TabIndex = 12;
            this.dtGdVwShowJobs.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGdVwShowJobs_CellValueChanged);
            this.dtGdVwShowJobs.SelectionChanged += new System.EventHandler(this.dtGdVwShowJobs_SelectionChanged);
            // 
            // UserControlJobs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UserControlJobs";
            this.Size = new System.Drawing.Size(233, 111);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGdVwShowJobs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btShowDataJobs;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btAddJob;
        private System.Windows.Forms.Button btSaveJob;
        private System.Windows.Forms.Button btRemoveJob;
        private System.Windows.Forms.DataGridView dtGdVwShowJobs;
    }
}
