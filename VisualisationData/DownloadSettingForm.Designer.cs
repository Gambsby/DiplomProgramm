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
            this.correlateProfileDG = new System.Windows.Forms.DataGridView();
            this.sheetName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.answer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.correlateProfileDG)).BeginInit();
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
            this.nextBtn.Location = new System.Drawing.Point(713, 415);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(75, 23);
            this.nextBtn.TabIndex = 2;
            this.nextBtn.Text = "Далее";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // correlateProfileDG
            // 
            this.correlateProfileDG.AllowUserToAddRows = false;
            this.correlateProfileDG.AllowUserToDeleteRows = false;
            this.correlateProfileDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.correlateProfileDG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.profileName,
            this.answer,
            this.sheetName});
            this.correlateProfileDG.Location = new System.Drawing.Point(15, 39);
            this.correlateProfileDG.Name = "correlateProfileDG";
            this.correlateProfileDG.ReadOnly = true;
            this.correlateProfileDG.Size = new System.Drawing.Size(773, 370);
            this.correlateProfileDG.TabIndex = 3;
            // 
            // sheetName
            // 
            this.sheetName.HeaderText = "Название листа";
            this.sheetName.Name = "sheetName";
            this.sheetName.ReadOnly = true;
            // 
            // answer
            // 
            this.answer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.answer.HeaderText = "Возможные ответы";
            this.answer.Name = "answer";
            this.answer.ReadOnly = true;
            // 
            // profileName
            // 
            this.profileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.profileName.HeaderText = "Название анкеты";
            this.profileName.Name = "profileName";
            this.profileName.ReadOnly = true;
            // 
            // id
            // 
            this.id.HeaderText = "Идентификатор";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // DownloadSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.correlateProfileDG);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chooseInfoSheetCB);
            this.Name = "DownloadSettingForm";
            this.Text = "DownloadSettingForm";
            this.Load += new System.EventHandler(this.DownloadSettingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.correlateProfileDG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox chooseInfoSheetCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.DataGridView correlateProfileDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn profileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn answer;
        private System.Windows.Forms.DataGridViewComboBoxColumn sheetName;
    }
}