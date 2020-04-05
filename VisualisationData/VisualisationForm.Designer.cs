namespace VisualisationData
{
    partial class VisualisationForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingDiagramBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.savaDiagramBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.visualChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visualChart)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1049, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingDiagramBtn,
            this.savaDiagramBtn});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // settingDiagramBtn
            // 
            this.settingDiagramBtn.Name = "settingDiagramBtn";
            this.settingDiagramBtn.Size = new System.Drawing.Size(196, 22);
            this.settingDiagramBtn.Text = "Настроить диаграмму";
            this.settingDiagramBtn.Click += new System.EventHandler(this.settingDiagramBtn_Click);
            // 
            // savaDiagramBtn
            // 
            this.savaDiagramBtn.Name = "savaDiagramBtn";
            this.savaDiagramBtn.Size = new System.Drawing.Size(196, 22);
            this.savaDiagramBtn.Text = "Сохранить";
            // 
            // visualChart
            // 
            chartArea1.Name = "ChartArea1";
            this.visualChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.visualChart.Legends.Add(legend1);
            this.visualChart.Location = new System.Drawing.Point(13, 28);
            this.visualChart.Name = "visualChart";
            this.visualChart.Size = new System.Drawing.Size(1024, 477);
            this.visualChart.TabIndex = 1;
            this.visualChart.Text = "visualChart";
            // 
            // VisualisationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 517);
            this.Controls.Add(this.visualChart);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "VisualisationForm";
            this.Text = "VisualisationFormcs";
            this.Load += new System.EventHandler(this.VisualisationForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visualChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DataVisualization.Charting.Chart visualChart;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingDiagramBtn;
        private System.Windows.Forms.ToolStripMenuItem savaDiagramBtn;
    }
}