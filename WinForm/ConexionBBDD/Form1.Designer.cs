namespace ConexionBBDD
{
    partial class Form1
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
            this.btBBDDConect = new System.Windows.Forms.Button();
            this.btBBDDDisconect = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbBBDDConnectionStates = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnJobsView = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btBBDDConect
            // 
            this.btBBDDConect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btBBDDConect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btBBDDConect.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBBDDConect.Location = new System.Drawing.Point(0, 52);
            this.btBBDDConect.Margin = new System.Windows.Forms.Padding(0, 7, 7, 0);
            this.btBBDDConect.Name = "btBBDDConect";
            this.btBBDDConect.Size = new System.Drawing.Size(275, 38);
            this.btBBDDConect.TabIndex = 0;
            this.btBBDDConect.Text = "Conectar";
            this.btBBDDConect.UseVisualStyleBackColor = true;
            this.btBBDDConect.Click += new System.EventHandler(this.btBBDDConect_Click);
            // 
            // btBBDDDisconect
            // 
            this.btBBDDDisconect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btBBDDDisconect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btBBDDDisconect.Enabled = false;
            this.btBBDDDisconect.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBBDDDisconect.Location = new System.Drawing.Point(289, 52);
            this.btBBDDDisconect.Margin = new System.Windows.Forms.Padding(7, 7, 0, 0);
            this.btBBDDDisconect.Name = "btBBDDDisconect";
            this.btBBDDDisconect.Size = new System.Drawing.Size(275, 38);
            this.btBBDDDisconect.TabIndex = 1;
            this.btBBDDDisconect.Text = "Desconectar";
            this.btBBDDDisconect.UseVisualStyleBackColor = true;
            this.btBBDDDisconect.Click += new System.EventHandler(this.btBBDDDisconect_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lbBBDDConnectionStates, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btBBDDDisconect, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btBBDDConect, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 15);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(564, 100);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // lbBBDDConnectionStates
            // 
            this.lbBBDDConnectionStates.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tableLayoutPanel1.SetColumnSpan(this.lbBBDDConnectionStates, 2);
            this.lbBBDDConnectionStates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbBBDDConnectionStates.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBBDDConnectionStates.Location = new System.Drawing.Point(0, 0);
            this.lbBBDDConnectionStates.Margin = new System.Windows.Forms.Padding(0, 0, 0, 7);
            this.lbBBDDConnectionStates.Name = "lbBBDDConnectionStates";
            this.lbBBDDConnectionStates.Size = new System.Drawing.Size(564, 38);
            this.lbBBDDConnectionStates.TabIndex = 4;
            this.lbBBDDConnectionStates.Text = "Closed";
            this.lbBBDDConnectionStates.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(15, 115);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 1);
            this.panel1.TabIndex = 4;
            // 
            // pnJobsView
            // 
            this.pnJobsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnJobsView.Location = new System.Drawing.Point(15, 116);
            this.pnJobsView.Name = "pnJobsView";
            this.pnJobsView.Size = new System.Drawing.Size(564, 243);
            this.pnJobsView.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(594, 374);
            this.Controls.Add(this.pnJobsView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conexsion a SQL";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btBBDDConect;
        private System.Windows.Forms.Button btBBDDDisconect;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbBBDDConnectionStates;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnJobsView;
    }
}

