namespace VisualisationData.VisualSettingForms
{
    partial class QuestionInfoForm
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
            this.infoDG = new System.Windows.Forms.DataGridView();
            this.questionLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.infoDG)).BeginInit();
            this.SuspendLayout();
            // 
            // infoDG
            // 
            this.infoDG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.infoDG.Location = new System.Drawing.Point(12, 110);
            this.infoDG.Name = "infoDG";
            this.infoDG.Size = new System.Drawing.Size(660, 192);
            this.infoDG.TabIndex = 0;
            // 
            // questionLbl
            // 
            this.questionLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.questionLbl.Location = new System.Drawing.Point(14, 14);
            this.questionLbl.Margin = new System.Windows.Forms.Padding(5);
            this.questionLbl.Name = "questionLbl";
            this.questionLbl.Size = new System.Drawing.Size(656, 88);
            this.questionLbl.TabIndex = 1;
            this.questionLbl.Text = "label1";
            // 
            // QuestionInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 314);
            this.Controls.Add(this.questionLbl);
            this.Controls.Add(this.infoDG);
            this.Name = "QuestionInfoForm";
            this.Text = "Информация о вопросе";
            this.Load += new System.EventHandler(this.QuestionInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.infoDG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView infoDG;
        private System.Windows.Forms.Label questionLbl;
    }
}