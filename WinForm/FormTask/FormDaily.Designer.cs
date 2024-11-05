namespace IntroducionWinForm
{
    partial class FormDaily
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
            this.lbNombre = new System.Windows.Forms.Label();
            this.txtbNombre = new System.Windows.Forms.TextBox();
            this.btShowName = new System.Windows.Forms.Button();
            this.lbDaily = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.Location = new System.Drawing.Point(23, 32);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(59, 16);
            this.lbNombre.TabIndex = 0;
            this.lbNombre.Text = "Nombre:";
            // 
            // txtbNombre
            // 
            this.txtbNombre.Location = new System.Drawing.Point(88, 29);
            this.txtbNombre.Name = "txtbNombre";
            this.txtbNombre.Size = new System.Drawing.Size(192, 22);
            this.txtbNombre.TabIndex = 1;
            // 
            // btShowName
            // 
            this.btShowName.Location = new System.Drawing.Point(180, 168);
            this.btShowName.Name = "btShowName";
            this.btShowName.Size = new System.Drawing.Size(100, 31);
            this.btShowName.TabIndex = 2;
            this.btShowName.Text = "Mostrar";
            this.btShowName.UseVisualStyleBackColor = true;
            this.btShowName.Click += new System.EventHandler(this.btShowName_Click);
            // 
            // lbDaily
            // 
            this.lbDaily.FormattingEnabled = true;
            this.lbDaily.ItemHeight = 16;
            this.lbDaily.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miercoles",
            "Jueves",
            "Viernes",
            "Sabado",
            "Domingo"});
            this.lbDaily.Location = new System.Drawing.Point(26, 67);
            this.lbDaily.Name = "lbDaily";
            this.lbDaily.Size = new System.Drawing.Size(120, 132);
            this.lbDaily.TabIndex = 3;
            this.lbDaily.SelectedIndexChanged += new System.EventHandler(this.lbDaily_SelectedIndexChanged);
            // 
            // FormDaily
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 226);
            this.Controls.Add(this.lbDaily);
            this.Controls.Add(this.btShowName);
            this.Controls.Add(this.txtbNombre);
            this.Controls.Add(this.lbNombre);
            this.Name = "FormDaily";
            this.Text = "FormDaily";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.TextBox txtbNombre;
        private System.Windows.Forms.Button btShowName;
        private System.Windows.Forms.ListBox lbDaily;
    }
}

