namespace VisualisationData.SettingsForm
{
    partial class DataSettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.settingGB = new System.Windows.Forms.GroupBox();
            this.firstCB = new System.Windows.Forms.ComboBox();
            this.firstLbl = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Button();
            this.acceptBtn = new System.Windows.Forms.Button();
            this.colorBtn = new System.Windows.Forms.Button();
            this.colorLbl = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.secondCB = new System.Windows.Forms.ComboBox();
            this.secondLbl = new System.Windows.Forms.Label();
            this.settingGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingGB
            // 
            this.settingGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingGB.Controls.Add(this.secondCB);
            this.settingGB.Controls.Add(this.secondLbl);
            this.settingGB.Controls.Add(this.colorBtn);
            this.settingGB.Controls.Add(this.colorLbl);
            this.settingGB.Controls.Add(this.firstCB);
            this.settingGB.Controls.Add(this.firstLbl);
            this.settingGB.Location = new System.Drawing.Point(10, 12);
            this.settingGB.Name = "settingGB";
            this.settingGB.Size = new System.Drawing.Size(462, 61);
            this.settingGB.TabIndex = 12;
            this.settingGB.TabStop = false;
            this.settingGB.Text = "Настройка фона";
            // 
            // firstCB
            // 
            this.firstCB.FormattingEnabled = true;
            this.firstCB.Location = new System.Drawing.Point(6, 32);
            this.firstCB.Name = "firstCB";
            this.firstCB.Size = new System.Drawing.Size(450, 21);
            this.firstCB.TabIndex = 14;
            this.firstCB.SelectedIndexChanged += new System.EventHandler(this.firstCB_SelectedIndexChanged);
            // 
            // firstLbl
            // 
            this.firstLbl.AutoSize = true;
            this.firstLbl.Location = new System.Drawing.Point(6, 16);
            this.firstLbl.Name = "firstLbl";
            this.firstLbl.Size = new System.Drawing.Size(81, 13);
            this.firstLbl.TabIndex = 13;
            this.firstLbl.Text = "Тип градиента";
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.closeBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeBtn.Location = new System.Drawing.Point(12, 82);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(81, 23);
            this.closeBtn.TabIndex = 18;
            this.closeBtn.Text = "Закрыть";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // acceptBtn
            // 
            this.acceptBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.acceptBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.acceptBtn.Location = new System.Drawing.Point(391, 82);
            this.acceptBtn.Name = "acceptBtn";
            this.acceptBtn.Size = new System.Drawing.Size(81, 23);
            this.acceptBtn.TabIndex = 19;
            this.acceptBtn.Text = "Принять";
            this.acceptBtn.UseVisualStyleBackColor = true;
            this.acceptBtn.Click += new System.EventHandler(this.acceptBtn_Click);
            // 
            // colorBtn
            // 
            this.colorBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.colorBtn.Location = new System.Drawing.Point(77, 26);
            this.colorBtn.Name = "colorBtn";
            this.colorBtn.Size = new System.Drawing.Size(20, 20);
            this.colorBtn.TabIndex = 18;
            this.colorBtn.UseVisualStyleBackColor = true;
            this.colorBtn.Visible = false;
            this.colorBtn.Click += new System.EventHandler(this.colorBtn_Click);
            // 
            // colorLbl
            // 
            this.colorLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.colorLbl.AutoSize = true;
            this.colorLbl.Location = new System.Drawing.Point(6, 30);
            this.colorLbl.Name = "colorLbl";
            this.colorLbl.Size = new System.Drawing.Size(65, 13);
            this.colorLbl.TabIndex = 17;
            this.colorLbl.Text = "Цвет серии";
            this.colorLbl.Visible = false;
            // 
            // secondCB
            // 
            this.secondCB.FormattingEnabled = true;
            this.secondCB.Location = new System.Drawing.Point(6, 78);
            this.secondCB.Name = "secondCB";
            this.secondCB.Size = new System.Drawing.Size(450, 21);
            this.secondCB.TabIndex = 20;
            this.secondCB.Visible = false;
            this.secondCB.SelectedIndexChanged += new System.EventHandler(this.secondCB_SelectedIndexChanged);
            // 
            // secondLbl
            // 
            this.secondLbl.AutoSize = true;
            this.secondLbl.Location = new System.Drawing.Point(6, 62);
            this.secondLbl.Name = "secondLbl";
            this.secondLbl.Size = new System.Drawing.Size(85, 13);
            this.secondLbl.TabIndex = 19;
            this.secondLbl.Text = "Элемени серии";
            this.secondLbl.Visible = false;
            // 
            // DataSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 117);
            this.Controls.Add(this.acceptBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.settingGB);
            this.Name = "DataSettingForm";
            this.Text = "DataSettingForm";
            this.Load += new System.EventHandler(this.DataSettingForm_Load);
            this.settingGB.ResumeLayout(false);
            this.settingGB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox settingGB;
        private System.Windows.Forms.ComboBox firstCB;
        private System.Windows.Forms.Label firstLbl;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button acceptBtn;
        private System.Windows.Forms.Button colorBtn;
        private System.Windows.Forms.Label colorLbl;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ComboBox secondCB;
        private System.Windows.Forms.Label secondLbl;
    }
}