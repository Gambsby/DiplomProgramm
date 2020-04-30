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
            this.mainTC = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // mainTC
            // 
            this.mainTC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTC.Location = new System.Drawing.Point(0, 0);
            this.mainTC.Name = "mainTC";
            this.mainTC.SelectedIndex = 0;
            this.mainTC.Size = new System.Drawing.Size(684, 314);
            this.mainTC.TabIndex = 0;
            // 
            // QuestionInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 314);
            this.Controls.Add(this.mainTC);
            this.Name = "QuestionInfoForm";
            this.Text = "Информация о вопросе";
            this.Load += new System.EventHandler(this.QuestionInfoForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTC;
    }
}