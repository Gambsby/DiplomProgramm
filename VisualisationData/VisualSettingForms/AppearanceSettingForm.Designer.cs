namespace VisualisationData.VisualSettingForms
{
    partial class AppearanceSettingForm
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
            this.borderStyleCB = new System.Windows.Forms.ComboBox();
            this.borderStyleLbl = new System.Windows.Forms.Label();
            this.gradientTypeCB = new System.Windows.Forms.ComboBox();
            this.gradientLbl = new System.Windows.Forms.Label();
            this.secondColorBtn = new System.Windows.Forms.Button();
            this.secondColorLbl = new System.Windows.Forms.Label();
            this.firstColorLbl = new System.Windows.Forms.Label();
            this.firstColorBtn = new System.Windows.Forms.Button();
            this.acceptBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.settingGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingGB
            // 
            this.settingGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingGB.Controls.Add(this.borderStyleCB);
            this.settingGB.Controls.Add(this.borderStyleLbl);
            this.settingGB.Controls.Add(this.gradientTypeCB);
            this.settingGB.Controls.Add(this.gradientLbl);
            this.settingGB.Controls.Add(this.secondColorBtn);
            this.settingGB.Controls.Add(this.secondColorLbl);
            this.settingGB.Controls.Add(this.firstColorLbl);
            this.settingGB.Controls.Add(this.firstColorBtn);
            this.settingGB.Location = new System.Drawing.Point(12, 12);
            this.settingGB.Name = "settingGB";
            this.settingGB.Size = new System.Drawing.Size(462, 93);
            this.settingGB.TabIndex = 11;
            this.settingGB.TabStop = false;
            this.settingGB.Text = "Настройка фона";
            // 
            // borderStyleCB
            // 
            this.borderStyleCB.FormattingEnabled = true;
            this.borderStyleCB.Location = new System.Drawing.Point(6, 108);
            this.borderStyleCB.Name = "borderStyleCB";
            this.borderStyleCB.Size = new System.Drawing.Size(450, 21);
            this.borderStyleCB.TabIndex = 16;
            this.borderStyleCB.Visible = false;
            // 
            // borderStyleLbl
            // 
            this.borderStyleLbl.AutoSize = true;
            this.borderStyleLbl.Location = new System.Drawing.Point(6, 91);
            this.borderStyleLbl.Name = "borderStyleLbl";
            this.borderStyleLbl.Size = new System.Drawing.Size(72, 13);
            this.borderStyleLbl.TabIndex = 15;
            this.borderStyleLbl.Text = "Стиль рамки";
            this.borderStyleLbl.Visible = false;
            // 
            // gradientTypeCB
            // 
            this.gradientTypeCB.FormattingEnabled = true;
            this.gradientTypeCB.Location = new System.Drawing.Point(6, 63);
            this.gradientTypeCB.Name = "gradientTypeCB";
            this.gradientTypeCB.Size = new System.Drawing.Size(450, 21);
            this.gradientTypeCB.TabIndex = 14;
            // 
            // gradientLbl
            // 
            this.gradientLbl.AutoSize = true;
            this.gradientLbl.Location = new System.Drawing.Point(6, 46);
            this.gradientLbl.Name = "gradientLbl";
            this.gradientLbl.Size = new System.Drawing.Size(81, 13);
            this.gradientLbl.TabIndex = 13;
            this.gradientLbl.Text = "Тип градиента";
            // 
            // secondColorBtn
            // 
            this.secondColorBtn.Location = new System.Drawing.Point(122, 19);
            this.secondColorBtn.Name = "secondColorBtn";
            this.secondColorBtn.Size = new System.Drawing.Size(20, 20);
            this.secondColorBtn.TabIndex = 12;
            this.secondColorBtn.UseVisualStyleBackColor = true;
            this.secondColorBtn.Click += new System.EventHandler(this.secondColorBtn_Click);
            // 
            // secondColorLbl
            // 
            this.secondColorLbl.AutoSize = true;
            this.secondColorLbl.Location = new System.Drawing.Point(148, 23);
            this.secondColorLbl.Name = "secondColorLbl";
            this.secondColorLbl.Size = new System.Drawing.Size(98, 13);
            this.secondColorLbl.TabIndex = 7;
            this.secondColorLbl.Text = "Второй цвет фона";
            // 
            // firstColorLbl
            // 
            this.firstColorLbl.AutoSize = true;
            this.firstColorLbl.Location = new System.Drawing.Point(32, 23);
            this.firstColorLbl.Name = "firstColorLbl";
            this.firstColorLbl.Size = new System.Drawing.Size(61, 13);
            this.firstColorLbl.TabIndex = 5;
            this.firstColorLbl.Text = "Цвет фона";
            // 
            // firstColorBtn
            // 
            this.firstColorBtn.Location = new System.Drawing.Point(6, 19);
            this.firstColorBtn.Name = "firstColorBtn";
            this.firstColorBtn.Size = new System.Drawing.Size(20, 20);
            this.firstColorBtn.TabIndex = 4;
            this.firstColorBtn.UseVisualStyleBackColor = true;
            this.firstColorBtn.Click += new System.EventHandler(this.firstColorBtn_Click);
            // 
            // acceptBtn
            // 
            this.acceptBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.acceptBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.acceptBtn.Location = new System.Drawing.Point(393, 113);
            this.acceptBtn.Name = "acceptBtn";
            this.acceptBtn.Size = new System.Drawing.Size(81, 23);
            this.acceptBtn.TabIndex = 16;
            this.acceptBtn.Text = "Принять";
            this.acceptBtn.UseVisualStyleBackColor = true;
            this.acceptBtn.Click += new System.EventHandler(this.acceptBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.closeBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeBtn.Location = new System.Drawing.Point(12, 113);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(81, 23);
            this.closeBtn.TabIndex = 17;
            this.closeBtn.Text = "Закрыть";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // AppearanceSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 147);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.acceptBtn);
            this.Controls.Add(this.settingGB);
            this.Name = "AppearanceSettingForm";
            this.Text = "AppearanceSettingForm";
            this.Load += new System.EventHandler(this.AppearanceSettingForm_Load);
            this.settingGB.ResumeLayout(false);
            this.settingGB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox settingGB;
        private System.Windows.Forms.ComboBox gradientTypeCB;
        private System.Windows.Forms.Label gradientLbl;
        private System.Windows.Forms.Button secondColorBtn;
        private System.Windows.Forms.Label secondColorLbl;
        private System.Windows.Forms.Label firstColorLbl;
        private System.Windows.Forms.Button firstColorBtn;
        private System.Windows.Forms.Button acceptBtn;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ComboBox borderStyleCB;
        private System.Windows.Forms.Label borderStyleLbl;
    }
}