namespace VisualisationData
{
    partial class DownloadSettingForm
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
            this.chooseInfoSheetCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nextBtn = new System.Windows.Forms.Button();
            this.chooseDG = new System.Windows.Forms.DataGridView();
            this.acceptBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.chooseAnswerSheetDG = new System.Windows.Forms.ComboBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chooseDG)).BeginInit();
            this.SuspendLayout();
            // 
            // chooseInfoSheetCB
            // 
            this.chooseInfoSheetCB.FormattingEnabled = true;
            this.chooseInfoSheetCB.Location = new System.Drawing.Point(302, 12);
            this.chooseInfoSheetCB.Name = "chooseInfoSheetCB";
            this.chooseInfoSheetCB.Size = new System.Drawing.Size(121, 21);
            this.chooseInfoSheetCB.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите лист с информацией о возможных ответах:";
            // 
            // nextBtn
            // 
            this.nextBtn.Location = new System.Drawing.Point(657, 262);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(75, 23);
            this.nextBtn.TabIndex = 2;
            this.nextBtn.Text = "Далее";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // chooseDG
            // 
            this.chooseDG.AllowUserToAddRows = false;
            this.chooseDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.chooseDG.Location = new System.Drawing.Point(12, 66);
            this.chooseDG.Name = "chooseDG";
            this.chooseDG.Size = new System.Drawing.Size(720, 190);
            this.chooseDG.TabIndex = 3;
            // 
            // acceptBtn
            // 
            this.acceptBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.acceptBtn.Location = new System.Drawing.Point(657, 262);
            this.acceptBtn.Name = "acceptBtn";
            this.acceptBtn.Size = new System.Drawing.Size(75, 23);
            this.acceptBtn.TabIndex = 4;
            this.acceptBtn.Text = "Принять";
            this.acceptBtn.UseVisualStyleBackColor = true;
            this.acceptBtn.Visible = false;
            this.acceptBtn.Click += new System.EventHandler(this.acceptBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Выберите лист с результатами анкетирования:";
            // 
            // chooseAnswerSheetDG
            // 
            this.chooseAnswerSheetDG.FormattingEnabled = true;
            this.chooseAnswerSheetDG.Location = new System.Drawing.Point(302, 39);
            this.chooseAnswerSheetDG.Name = "chooseAnswerSheetDG";
            this.chooseAnswerSheetDG.Size = new System.Drawing.Size(121, 21);
            this.chooseAnswerSheetDG.TabIndex = 5;
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(12, 262);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 7;
            this.cancelBtn.Text = "Отменить";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Visible = false;
            // 
            // DownloadSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 296);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chooseAnswerSheetDG);
            this.Controls.Add(this.acceptBtn);
            this.Controls.Add(this.chooseDG);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chooseInfoSheetCB);
            this.Name = "DownloadSettingForm";
            this.Text = "DownloadSettingForm";
            this.Load += new System.EventHandler(this.DownloadSettingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chooseDG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox chooseInfoSheetCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.DataGridView chooseDG;
        private System.Windows.Forms.Button acceptBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox chooseAnswerSheetDG;
        private System.Windows.Forms.Button cancelBtn;
    }
}