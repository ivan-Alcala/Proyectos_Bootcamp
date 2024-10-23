namespace FormTask
{
    partial class FormMain
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
            this.lbTitle = new System.Windows.Forms.Label();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.btSubmit = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.cbLocation = new System.Windows.Forms.ComboBox();
            this.lbLocation = new System.Windows.Forms.Label();
            this.clbEnviroment = new System.Windows.Forms.CheckedListBox();
            this.lbType = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.lbEnvironment = new System.Windows.Forms.Label();
            this.cbCriticity = new System.Windows.Forms.ComboBox();
            this.lbCriticity = new System.Windows.Forms.Label();
            this.lbDescription = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.lbStartDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.nudDurationH = new System.Windows.Forms.NumericUpDown();
            this.lbDurationH = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.lbStatus = new System.Windows.Forms.Label();
            this.cbPercentComplete = new System.Windows.Forms.ComboBox();
            this.lbPercentComplete = new System.Windows.Forms.Label();
            this.cbSendEmail = new System.Windows.Forms.CheckBox();
            this.btNewForm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudDurationH)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(9, 13);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(38, 16);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Title";
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(12, 32);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(226, 22);
            this.tbTitle.TabIndex = 1;
            // 
            // btSubmit
            // 
            this.btSubmit.BackColor = System.Drawing.SystemColors.Highlight;
            this.btSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btSubmit.ForeColor = System.Drawing.SystemColors.Control;
            this.btSubmit.Location = new System.Drawing.Point(420, 451);
            this.btSubmit.Name = "btSubmit";
            this.btSubmit.Size = new System.Drawing.Size(75, 31);
            this.btSubmit.TabIndex = 2;
            this.btSubmit.Text = "Submit";
            this.btSubmit.UseVisualStyleBackColor = false;
            this.btSubmit.Click += new System.EventHandler(this.BtSubmit_Click);
            // 
            // btCancel
            // 
            this.btCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btCancel.Location = new System.Drawing.Point(339, 451);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 31);
            this.btCancel.TabIndex = 3;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // cbLocation
            // 
            this.cbLocation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbLocation.FormattingEnabled = true;
            this.cbLocation.Items.AddRange(new object[] {
            "Barcelona",
            "Cataluña",
            "Otros"});
            this.cbLocation.Location = new System.Drawing.Point(269, 32);
            this.cbLocation.Name = "cbLocation";
            this.cbLocation.Size = new System.Drawing.Size(226, 24);
            this.cbLocation.TabIndex = 4;
            // 
            // lbLocation
            // 
            this.lbLocation.AutoSize = true;
            this.lbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLocation.Location = new System.Drawing.Point(266, 13);
            this.lbLocation.Name = "lbLocation";
            this.lbLocation.Size = new System.Drawing.Size(66, 16);
            this.lbLocation.TabIndex = 5;
            this.lbLocation.Text = "Location";
            // 
            // clbEnviroment
            // 
            this.clbEnviroment.BackColor = System.Drawing.SystemColors.MenuBar;
            this.clbEnviroment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbEnviroment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clbEnviroment.FormattingEnabled = true;
            this.clbEnviroment.Items.AddRange(new object[] {
            "Prod",
            "Preprod",
            "Demo"});
            this.clbEnviroment.Location = new System.Drawing.Point(375, 94);
            this.clbEnviroment.Name = "clbEnviroment";
            this.clbEnviroment.Size = new System.Drawing.Size(120, 68);
            this.clbEnviroment.TabIndex = 6;
            // 
            // lbType
            // 
            this.lbType.AutoSize = true;
            this.lbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbType.Location = new System.Drawing.Point(9, 75);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(43, 16);
            this.lbType.TabIndex = 7;
            this.lbType.Text = "Type";
            // 
            // cbType
            // 
            this.cbType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Incident",
            "Pendent",
            "Refused"});
            this.cbType.Location = new System.Drawing.Point(12, 94);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(149, 24);
            this.cbType.TabIndex = 8;
            // 
            // lbEnvironment
            // 
            this.lbEnvironment.AutoSize = true;
            this.lbEnvironment.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEnvironment.Location = new System.Drawing.Point(372, 75);
            this.lbEnvironment.Name = "lbEnvironment";
            this.lbEnvironment.Size = new System.Drawing.Size(92, 16);
            this.lbEnvironment.TabIndex = 11;
            this.lbEnvironment.Text = "Environment";
            // 
            // cbCriticity
            // 
            this.cbCriticity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbCriticity.FormattingEnabled = true;
            this.cbCriticity.Items.AddRange(new object[] {
            "Minor",
            "Major"});
            this.cbCriticity.Location = new System.Drawing.Point(196, 94);
            this.cbCriticity.Name = "cbCriticity";
            this.cbCriticity.Size = new System.Drawing.Size(149, 24);
            this.cbCriticity.TabIndex = 13;
            // 
            // lbCriticity
            // 
            this.lbCriticity.AutoSize = true;
            this.lbCriticity.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCriticity.Location = new System.Drawing.Point(196, 75);
            this.lbCriticity.Name = "lbCriticity";
            this.lbCriticity.Size = new System.Drawing.Size(58, 16);
            this.lbCriticity.TabIndex = 12;
            this.lbCriticity.Text = "Criticity";
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDescription.Location = new System.Drawing.Point(12, 155);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(86, 16);
            this.lbDescription.TabIndex = 14;
            this.lbDescription.Text = "Description";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(12, 174);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(483, 94);
            this.rtbDescription.TabIndex = 15;
            this.rtbDescription.Text = "";
            // 
            // lbStartDate
            // 
            this.lbStartDate.AutoSize = true;
            this.lbStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStartDate.Location = new System.Drawing.Point(9, 289);
            this.lbStartDate.Name = "lbStartDate";
            this.lbStartDate.Size = new System.Drawing.Size(72, 16);
            this.lbStartDate.TabIndex = 16;
            this.lbStartDate.Text = "StartDate";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(12, 308);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(228, 22);
            this.dtpStartDate.TabIndex = 17;
            this.dtpStartDate.Value = new System.DateTime(2024, 10, 23, 10, 24, 18, 0);
            // 
            // nudDurationH
            // 
            this.nudDurationH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nudDurationH.DecimalPlaces = 2;
            this.nudDurationH.Location = new System.Drawing.Point(269, 308);
            this.nudDurationH.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudDurationH.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDurationH.Name = "nudDurationH";
            this.nudDurationH.Size = new System.Drawing.Size(226, 22);
            this.nudDurationH.TabIndex = 18;
            this.nudDurationH.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbDurationH
            // 
            this.lbDurationH.AutoSize = true;
            this.lbDurationH.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDurationH.Location = new System.Drawing.Point(266, 289);
            this.lbDurationH.Name = "lbDurationH";
            this.lbDurationH.Size = new System.Drawing.Size(133, 16);
            this.lbDurationH.TabIndex = 19;
            this.lbDurationH.Text = "Duration (in hours)";
            // 
            // cbStatus
            // 
            this.cbStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "Planned",
            "Unplanned",
            "On hold"});
            this.cbStatus.Location = new System.Drawing.Point(12, 371);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(228, 24);
            this.cbStatus.TabIndex = 21;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.Location = new System.Drawing.Point(9, 352);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(50, 16);
            this.lbStatus.TabIndex = 20;
            this.lbStatus.Text = "Status";
            // 
            // cbPercentComplete
            // 
            this.cbPercentComplete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbPercentComplete.FormattingEnabled = true;
            this.cbPercentComplete.Items.AddRange(new object[] {
            "0%",
            "10%",
            "25%",
            "50%",
            "75%",
            "100%"});
            this.cbPercentComplete.Location = new System.Drawing.Point(269, 371);
            this.cbPercentComplete.Name = "cbPercentComplete";
            this.cbPercentComplete.Size = new System.Drawing.Size(226, 24);
            this.cbPercentComplete.TabIndex = 23;
            // 
            // lbPercentComplete
            // 
            this.lbPercentComplete.AutoSize = true;
            this.lbPercentComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPercentComplete.Location = new System.Drawing.Point(266, 352);
            this.lbPercentComplete.Name = "lbPercentComplete";
            this.lbPercentComplete.Size = new System.Drawing.Size(126, 16);
            this.lbPercentComplete.TabIndex = 22;
            this.lbPercentComplete.Text = "PercentComplete";
            // 
            // cbSendEmail
            // 
            this.cbSendEmail.AutoSize = true;
            this.cbSendEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbSendEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSendEmail.Location = new System.Drawing.Point(12, 415);
            this.cbSendEmail.Name = "cbSendEmail";
            this.cbSendEmail.Size = new System.Drawing.Size(301, 20);
            this.cbSendEmail.TabIndex = 24;
            this.cbSendEmail.Text = "Check here if you want to send an email";
            this.cbSendEmail.UseVisualStyleBackColor = true;
            // 
            // btNewForm
            // 
            this.btNewForm.Location = new System.Drawing.Point(12, 451);
            this.btNewForm.Name = "btNewForm";
            this.btNewForm.Size = new System.Drawing.Size(75, 31);
            this.btNewForm.TabIndex = 25;
            this.btNewForm.Text = "New form";
            this.btNewForm.UseVisualStyleBackColor = true;
            this.btNewForm.Click += new System.EventHandler(this.btNewForm_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 496);
            this.Controls.Add(this.btNewForm);
            this.Controls.Add(this.cbSendEmail);
            this.Controls.Add(this.cbPercentComplete);
            this.Controls.Add(this.lbPercentComplete);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.lbDurationH);
            this.Controls.Add(this.nudDurationH);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lbStartDate);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.cbCriticity);
            this.Controls.Add(this.lbCriticity);
            this.Controls.Add(this.lbEnvironment);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.lbType);
            this.Controls.Add(this.clbEnviroment);
            this.Controls.Add(this.lbLocation);
            this.Controls.Add(this.cbLocation);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSubmit);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.lbTitle);
            this.Name = "FormMain";
            this.Text = "Create new task";
            ((System.ComponentModel.ISupportInitialize)(this.nudDurationH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Button btSubmit;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.ComboBox cbLocation;
        private System.Windows.Forms.Label lbLocation;
        private System.Windows.Forms.CheckedListBox clbEnviroment;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label lbEnvironment;
        private System.Windows.Forms.ComboBox cbCriticity;
        private System.Windows.Forms.Label lbCriticity;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Label lbStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.NumericUpDown nudDurationH;
        private System.Windows.Forms.Label lbDurationH;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.ComboBox cbPercentComplete;
        private System.Windows.Forms.Label lbPercentComplete;
        private System.Windows.Forms.CheckBox cbSendEmail;
        private System.Windows.Forms.Button btNewForm;
    }
}

