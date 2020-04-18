namespace VisualisationData.VisualSettingForms
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
            this.savaDiagramBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.appearanceSettingBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.BGSettingBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.diagramBGSettingRtn = new System.Windows.Forms.ToolStripMenuItem();
            this.borderSettingBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.showGridBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.showAxisBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.showAxisXBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.showAxisYBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.markerFontBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.legendFontBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.titleFontBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSettingsBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.signatureSettingBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.mode3DSettingBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.diagramTypeSettingBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.titleSettingBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.seriesSettingBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.pointsSettingBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.visualChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visualChart)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.appearanceSettingBtn,
            this.dataSettingsBtn});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.savaDiagramBtn});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // savaDiagramBtn
            // 
            this.savaDiagramBtn.Name = "savaDiagramBtn";
            this.savaDiagramBtn.Size = new System.Drawing.Size(132, 22);
            this.savaDiagramBtn.Text = "Сохранить";
            this.savaDiagramBtn.Click += new System.EventHandler(this.savaDiagramBtn_Click);
            // 
            // appearanceSettingBtn
            // 
            this.appearanceSettingBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BGSettingBtn,
            this.diagramBGSettingRtn,
            this.borderSettingBtn,
            this.showGridBtn,
            this.showAxisBtn,
            this.markerFontBtn,
            this.legendFontBtn,
            this.titleFontBtn});
            this.appearanceSettingBtn.Name = "appearanceSettingBtn";
            this.appearanceSettingBtn.Size = new System.Drawing.Size(164, 20);
            this.appearanceSettingBtn.Text = "Настройка внешнего вида";
            // 
            // BGSettingBtn
            // 
            this.BGSettingBtn.Name = "BGSettingBtn";
            this.BGSettingBtn.Size = new System.Drawing.Size(183, 22);
            this.BGSettingBtn.Text = "Фон ";
            this.BGSettingBtn.Click += new System.EventHandler(this.BGSettingBtn_Click);
            // 
            // diagramBGSettingRtn
            // 
            this.diagramBGSettingRtn.Name = "diagramBGSettingRtn";
            this.diagramBGSettingRtn.Size = new System.Drawing.Size(183, 22);
            this.diagramBGSettingRtn.Text = "Фон диаграммы";
            this.diagramBGSettingRtn.Click += new System.EventHandler(this.diagramBGSettingRtn_Click);
            // 
            // borderSettingBtn
            // 
            this.borderSettingBtn.Name = "borderSettingBtn";
            this.borderSettingBtn.Size = new System.Drawing.Size(183, 22);
            this.borderSettingBtn.Text = "Рамка";
            this.borderSettingBtn.Click += new System.EventHandler(this.borderSettingBtn_Click);
            // 
            // showGridBtn
            // 
            this.showGridBtn.Name = "showGridBtn";
            this.showGridBtn.Size = new System.Drawing.Size(183, 22);
            this.showGridBtn.Text = "Отображение сетки";
            this.showGridBtn.Click += new System.EventHandler(this.showGridBtn_Click);
            // 
            // showAxisBtn
            // 
            this.showAxisBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showAxisXBtn,
            this.showAxisYBtn});
            this.showAxisBtn.Name = "showAxisBtn";
            this.showAxisBtn.Size = new System.Drawing.Size(183, 22);
            this.showAxisBtn.Text = "Отображение осей";
            // 
            // showAxisXBtn
            // 
            this.showAxisXBtn.Name = "showAxisXBtn";
            this.showAxisXBtn.Size = new System.Drawing.Size(105, 22);
            this.showAxisXBtn.Text = "Ось X";
            this.showAxisXBtn.Click += new System.EventHandler(this.showAxisXBtn_Click);
            // 
            // showAxisYBtn
            // 
            this.showAxisYBtn.Name = "showAxisYBtn";
            this.showAxisYBtn.Size = new System.Drawing.Size(105, 22);
            this.showAxisYBtn.Text = "Ось Y";
            this.showAxisYBtn.Click += new System.EventHandler(this.showAxisYBtn_Click);
            // 
            // markerFontBtn
            // 
            this.markerFontBtn.Name = "markerFontBtn";
            this.markerFontBtn.Size = new System.Drawing.Size(183, 22);
            this.markerFontBtn.Text = "Шрифт маркеров";
            this.markerFontBtn.Click += new System.EventHandler(this.markerFontBtn_Click);
            // 
            // legendFontBtn
            // 
            this.legendFontBtn.Name = "legendFontBtn";
            this.legendFontBtn.Size = new System.Drawing.Size(183, 22);
            this.legendFontBtn.Text = "Шрифт легенды";
            this.legendFontBtn.Click += new System.EventHandler(this.legendFontBtn_Click);
            // 
            // titleFontBtn
            // 
            this.titleFontBtn.Name = "titleFontBtn";
            this.titleFontBtn.Size = new System.Drawing.Size(183, 22);
            this.titleFontBtn.Text = "Шрифт заголовка";
            this.titleFontBtn.Click += new System.EventHandler(this.titleFontBtn_Click);
            // 
            // dataSettingsBtn
            // 
            this.dataSettingsBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.signatureSettingBtn,
            this.mode3DSettingBtn,
            this.diagramTypeSettingBtn,
            this.titleSettingBtn,
            this.seriesSettingBtn,
            this.pointsSettingBtn});
            this.dataSettingsBtn.Name = "dataSettingsBtn";
            this.dataSettingsBtn.Size = new System.Drawing.Size(121, 20);
            this.dataSettingsBtn.Text = "Настройка данных";
            // 
            // signatureSettingBtn
            // 
            this.signatureSettingBtn.Name = "signatureSettingBtn";
            this.signatureSettingBtn.Size = new System.Drawing.Size(188, 22);
            this.signatureSettingBtn.Text = "Подписи на графике";
            this.signatureSettingBtn.Click += new System.EventHandler(this.signatureSettingBtn_Click);
            // 
            // mode3DSettingBtn
            // 
            this.mode3DSettingBtn.Name = "mode3DSettingBtn";
            this.mode3DSettingBtn.Size = new System.Drawing.Size(188, 22);
            this.mode3DSettingBtn.Text = "3D Режим";
            this.mode3DSettingBtn.Click += new System.EventHandler(this.mode3DSettingBtn_Click);
            // 
            // diagramTypeSettingBtn
            // 
            this.diagramTypeSettingBtn.Name = "diagramTypeSettingBtn";
            this.diagramTypeSettingBtn.Size = new System.Drawing.Size(188, 22);
            this.diagramTypeSettingBtn.Text = "Тип диаграммы";
            this.diagramTypeSettingBtn.Click += new System.EventHandler(this.diagramTypeSettingBtn_Click);
            // 
            // titleSettingBtn
            // 
            this.titleSettingBtn.Name = "titleSettingBtn";
            this.titleSettingBtn.Size = new System.Drawing.Size(188, 22);
            this.titleSettingBtn.Text = "Заголовок";
            this.titleSettingBtn.Click += new System.EventHandler(this.titleSettingBtn_Click);
            // 
            // seriesSettingBtn
            // 
            this.seriesSettingBtn.Name = "seriesSettingBtn";
            this.seriesSettingBtn.Size = new System.Drawing.Size(188, 22);
            this.seriesSettingBtn.Text = "Серии";
            this.seriesSettingBtn.Click += new System.EventHandler(this.seriesSettingBtn_Click);
            // 
            // pointsSettingBtn
            // 
            this.pointsSettingBtn.Name = "pointsSettingBtn";
            this.pointsSettingBtn.Size = new System.Drawing.Size(188, 22);
            this.pointsSettingBtn.Text = "Элементы серии";
            this.pointsSettingBtn.Click += new System.EventHandler(this.pointsSettingBtn_Click);
            // 
            // visualChart
            // 
            this.visualChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.visualChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.visualChart.Legends.Add(legend1);
            this.visualChart.Location = new System.Drawing.Point(13, 28);
            this.visualChart.Name = "visualChart";
            this.visualChart.Size = new System.Drawing.Size(959, 521);
            this.visualChart.TabIndex = 1;
            this.visualChart.Text = "visualChart";
            // 
            // VisualisationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.visualChart);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "VisualisationForm";
            this.Text = "Настройка диаграмм";
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
        private System.Windows.Forms.ToolStripMenuItem savaDiagramBtn;
        private System.Windows.Forms.ToolStripMenuItem appearanceSettingBtn;
        private System.Windows.Forms.ToolStripMenuItem BGSettingBtn;
        private System.Windows.Forms.ToolStripMenuItem diagramBGSettingRtn;
        private System.Windows.Forms.ToolStripMenuItem borderSettingBtn;
        private System.Windows.Forms.ToolStripMenuItem dataSettingsBtn;
        private System.Windows.Forms.ToolStripMenuItem signatureSettingBtn;
        private System.Windows.Forms.ToolStripMenuItem mode3DSettingBtn;
        private System.Windows.Forms.ToolStripMenuItem diagramTypeSettingBtn;
        private System.Windows.Forms.ToolStripMenuItem titleSettingBtn;
        private System.Windows.Forms.ToolStripMenuItem seriesSettingBtn;
        private System.Windows.Forms.ToolStripMenuItem pointsSettingBtn;
        private System.Windows.Forms.ToolStripMenuItem showGridBtn;
        private System.Windows.Forms.ToolStripMenuItem showAxisBtn;
        private System.Windows.Forms.ToolStripMenuItem showAxisXBtn;
        private System.Windows.Forms.ToolStripMenuItem showAxisYBtn;
        private System.Windows.Forms.ToolStripMenuItem markerFontBtn;
        private System.Windows.Forms.ToolStripMenuItem legendFontBtn;
        private System.Windows.Forms.ToolStripMenuItem titleFontBtn;
    }
}