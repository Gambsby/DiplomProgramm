namespace VisualisationData.SettingsForm
{
    partial class SaveSettingForm
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.resultLbl = new System.Windows.Forms.Label();
            this.acceptBtn = new System.Windows.Forms.Button();
            this.chooseDG = new System.Windows.Forms.DataGridView();
            this.infoLbl = new System.Windows.Forms.Label();
            this.profileInfoTB = new System.Windows.Forms.TextBox();
            this.resultInfoTB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chooseDG)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(12, 260);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 15;
            this.cancelBtn.Text = "Отменить";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // resultLbl
            // 
            this.resultLbl.AutoSize = true;
            this.resultLbl.Location = new System.Drawing.Point(50, 40);
            this.resultLbl.Name = "resultLbl";
            this.resultLbl.Size = new System.Drawing.Size(292, 13);
            this.resultLbl.TabIndex = 14;
            this.resultLbl.Text = "Ведите название листа с результатами анкетирования:";
            // 
            // acceptBtn
            // 
            this.acceptBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.acceptBtn.Location = new System.Drawing.Point(657, 261);
            this.acceptBtn.Name = "acceptBtn";
            this.acceptBtn.Size = new System.Drawing.Size(75, 23);
            this.acceptBtn.TabIndex = 12;
            this.acceptBtn.Text = "Принять";
            this.acceptBtn.UseVisualStyleBackColor = true;
            this.acceptBtn.Click += new System.EventHandler(this.acceptBtn_Click);
            // 
            // chooseDG
            // 
            this.chooseDG.AllowUserToAddRows = false;
            this.chooseDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.chooseDG.Location = new System.Drawing.Point(12, 64);
            this.chooseDG.Name = "chooseDG";
            this.chooseDG.Size = new System.Drawing.Size(720, 190);
            this.chooseDG.TabIndex = 11;
            // 
            // infoLbl
            // 
            this.infoLbl.AutoSize = true;
            this.infoLbl.Location = new System.Drawing.Point(12, 13);
            this.infoLbl.Name = "infoLbl";
            this.infoLbl.Size = new System.Drawing.Size(330, 13);
            this.infoLbl.TabIndex = 9;
            this.infoLbl.Text = "Введите название листа с информацией о возможных ответах:";
            // 
            // profileInfoTB
            // 
            this.profileInfoTB.Location = new System.Drawing.Point(348, 10);
            this.profileInfoTB.Name = "profileInfoTB";
            this.profileInfoTB.Size = new System.Drawing.Size(161, 20);
            this.profileInfoTB.TabIndex = 16;
            // 
            // resultInfoTB
            // 
            this.resultInfoTB.Location = new System.Drawing.Point(348, 37);
            this.resultInfoTB.Name = "resultInfoTB";
            this.resultInfoTB.Size = new System.Drawing.Size(161, 20);
            this.resultInfoTB.TabIndex = 17;
            // 
            // SaveSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 296);
            this.Controls.Add(this.resultInfoTB);
            this.Controls.Add(this.profileInfoTB);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.resultLbl);
            this.Controls.Add(this.acceptBtn);
            this.Controls.Add(this.chooseDG);
            this.Controls.Add(this.infoLbl);
            this.Name = "SaveSettingForm";
            this.Text = "SaveSettingForm";
            this.Load += new System.EventHandler(this.SaveSettingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chooseDG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label resultLbl;
        private System.Windows.Forms.Button acceptBtn;
        private System.Windows.Forms.DataGridView chooseDG;
        private System.Windows.Forms.Label infoLbl;
        private System.Windows.Forms.TextBox profileInfoTB;
        private System.Windows.Forms.TextBox resultInfoTB;
    }
}