namespace ConexionBBDD.Forms
{
    partial class UserControllJobs
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
            this.btAdd = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.btRemove = new System.Windows.Forms.Button();
            this.dtGdVwShowData = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGdVwShowData)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtGdVwShowData, 0, 1);
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
            this.flowLayoutPanel2.Controls.Add(this.btAdd);
            this.flowLayoutPanel2.Controls.Add(this.btSave);
            this.flowLayoutPanel2.Controls.Add(this.btRemove);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(106, 13);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(124, 32);
            this.flowLayoutPanel2.TabIndex = 11;
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAdd.FlatAppearance.BorderSize = 0;
            this.btAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAdd.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAdd.Image = global::ConexionBBDD.Properties.Resources.agregar;
            this.btAdd.Location = new System.Drawing.Point(87, 0);
            this.btAdd.Margin = new System.Windows.Forms.Padding(0);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(37, 32);
            this.btAdd.TabIndex = 9;
            this.btAdd.UseVisualStyleBackColor = true;
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSave.Enabled = false;
            this.btSave.FlatAppearance.BorderSize = 0;
            this.btSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSave.Image = global::ConexionBBDD.Properties.Resources.disco;
            this.btSave.Location = new System.Drawing.Point(50, 0);
            this.btSave.Margin = new System.Windows.Forms.Padding(0);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(37, 32);
            this.btSave.TabIndex = 10;
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // btRemove
            // 
            this.btRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btRemove.Enabled = false;
            this.btRemove.FlatAppearance.BorderSize = 0;
            this.btRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRemove.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRemove.Image = global::ConexionBBDD.Properties.Resources.basura;
            this.btRemove.Location = new System.Drawing.Point(13, 0);
            this.btRemove.Margin = new System.Windows.Forms.Padding(0);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(37, 32);
            this.btRemove.TabIndex = 11;
            this.btRemove.UseVisualStyleBackColor = true;
            // 
            // dtGdVwShowData
            // 
            this.dtGdVwShowData.AllowUserToAddRows = false;
            this.dtGdVwShowData.AllowUserToDeleteRows = false;
            this.dtGdVwShowData.AllowUserToResizeColumns = false;
            this.dtGdVwShowData.AllowUserToResizeRows = false;
            this.dtGdVwShowData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtGdVwShowData.BackgroundColor = System.Drawing.Color.White;
            this.dtGdVwShowData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtGdVwShowData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtGdVwShowData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGdVwShowData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGdVwShowData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dtGdVwShowData, 2);
            this.dtGdVwShowData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGdVwShowData.Location = new System.Drawing.Point(3, 51);
            this.dtGdVwShowData.Name = "dtGdVwShowData";
            this.dtGdVwShowData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGdVwShowData.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtGdVwShowData.RowHeadersVisible = false;
            this.dtGdVwShowData.RowHeadersWidth = 51;
            this.dtGdVwShowData.RowTemplate.Height = 24;
            this.dtGdVwShowData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGdVwShowData.Size = new System.Drawing.Size(227, 57);
            this.dtGdVwShowData.TabIndex = 12;
            // 
            // CRUDJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CRUDJob";
            this.Size = new System.Drawing.Size(233, 111);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGdVwShowData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btShowDataJobs;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btRemove;
        private System.Windows.Forms.DataGridView dtGdVwShowData;
    }
}
