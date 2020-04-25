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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
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
            this.mode3DSettingBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.легендаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLegendBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.legendsBGSettingBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.legendFontBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.заголовокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showTitleMBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.titleFontBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.titlrSettingBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.allItemBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.серииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diagramTypeSettingBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.seriesSettingBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.pointsSettingBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.markerTypeBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.percentMarkerBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.valuesMarkerBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.markerFontBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.visualChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.seriesMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.seriesColorBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.pointColorBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.markFontBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.selectMarkFontDtn = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.titleMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fontTitleBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.changeTitleBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteTitleBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.legendMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLegendMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.legendsBGSettingMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.changeLegendFontBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.noneMarkerBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.legendValBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.legendColPerBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.legendColValBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.legendColNoneBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visualChart)).BeginInit();
            this.seriesMenu.SuspendLayout();
            this.titleMenu.SuspendLayout();
            this.legendMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.appearanceSettingBtn,
            this.легендаToolStripMenuItem,
            this.заголовокToolStripMenuItem,
            this.серииToolStripMenuItem});
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
            this.mode3DSettingBtn});
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
            // mode3DSettingBtn
            // 
            this.mode3DSettingBtn.Name = "mode3DSettingBtn";
            this.mode3DSettingBtn.Size = new System.Drawing.Size(183, 22);
            this.mode3DSettingBtn.Text = "3D режим";
            this.mode3DSettingBtn.Click += new System.EventHandler(this.mode3DSettingBtn_Click);
            // 
            // легендаToolStripMenuItem
            // 
            this.легендаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLegendBtn,
            this.legendsBGSettingBtn,
            this.legendFontBtn,
            this.legendValBtn});
            this.легендаToolStripMenuItem.Name = "легендаToolStripMenuItem";
            this.легендаToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.легендаToolStripMenuItem.Text = "Легенда";
            // 
            // showLegendBtn
            // 
            this.showLegendBtn.Name = "showLegendBtn";
            this.showLegendBtn.Size = new System.Drawing.Size(187, 22);
            this.showLegendBtn.Text = "Отображать легенду";
            this.showLegendBtn.Click += new System.EventHandler(this.showLegendBtn_Click);
            // 
            // legendsBGSettingBtn
            // 
            this.legendsBGSettingBtn.Name = "legendsBGSettingBtn";
            this.legendsBGSettingBtn.Size = new System.Drawing.Size(187, 22);
            this.legendsBGSettingBtn.Text = "Фон легенды";
            this.legendsBGSettingBtn.Click += new System.EventHandler(this.legendsBGSettingBtn_Click);
            // 
            // legendFontBtn
            // 
            this.legendFontBtn.Name = "legendFontBtn";
            this.legendFontBtn.Size = new System.Drawing.Size(187, 22);
            this.legendFontBtn.Text = "Шрифт легенды";
            this.legendFontBtn.Click += new System.EventHandler(this.legendFontBtn_Click);
            // 
            // заголовокToolStripMenuItem
            // 
            this.заголовокToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showTitleMBtn,
            this.titleFontBtn,
            this.titlrSettingBtn,
            this.allItemBtn});
            this.заголовокToolStripMenuItem.Name = "заголовокToolStripMenuItem";
            this.заголовокToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.заголовокToolStripMenuItem.Text = "Заголовок";
            // 
            // showTitleMBtn
            // 
            this.showTitleMBtn.Name = "showTitleMBtn";
            this.showTitleMBtn.Size = new System.Drawing.Size(200, 22);
            this.showTitleMBtn.Text = "Отображать заголовок";
            this.showTitleMBtn.Click += new System.EventHandler(this.showTitleMBtn_Click);
            // 
            // titleFontBtn
            // 
            this.titleFontBtn.Name = "titleFontBtn";
            this.titleFontBtn.Size = new System.Drawing.Size(200, 22);
            this.titleFontBtn.Text = "Шрифт заголовка";
            this.titleFontBtn.Click += new System.EventHandler(this.titleFontBtn_Click);
            // 
            // titlrSettingBtn
            // 
            this.titlrSettingBtn.Name = "titlrSettingBtn";
            this.titlrSettingBtn.Size = new System.Drawing.Size(200, 22);
            this.titlrSettingBtn.Text = "Изменить заголовок";
            this.titlrSettingBtn.Click += new System.EventHandler(this.titleSettingBtn_Click);
            // 
            // allItemBtn
            // 
            this.allItemBtn.Name = "allItemBtn";
            this.allItemBtn.Size = new System.Drawing.Size(200, 22);
            this.allItemBtn.Text = "Элемент \"Всего\"";
            this.allItemBtn.Click += new System.EventHandler(this.allItemBtn_Click);
            // 
            // серииToolStripMenuItem
            // 
            this.серииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.diagramTypeSettingBtn,
            this.seriesSettingBtn,
            this.pointsSettingBtn,
            this.markerTypeBtn,
            this.markerFontBtn});
            this.серииToolStripMenuItem.Name = "серииToolStripMenuItem";
            this.серииToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.серииToolStripMenuItem.Text = "Серии";
            // 
            // diagramTypeSettingBtn
            // 
            this.diagramTypeSettingBtn.Name = "diagramTypeSettingBtn";
            this.diagramTypeSettingBtn.Size = new System.Drawing.Size(180, 22);
            this.diagramTypeSettingBtn.Text = "Тип серии";
            this.diagramTypeSettingBtn.Click += new System.EventHandler(this.diagramTypeSettingBtn_Click);
            // 
            // seriesSettingBtn
            // 
            this.seriesSettingBtn.Name = "seriesSettingBtn";
            this.seriesSettingBtn.Size = new System.Drawing.Size(180, 22);
            this.seriesSettingBtn.Text = "Цвет серии";
            this.seriesSettingBtn.Click += new System.EventHandler(this.seriesSettingBtn_Click);
            // 
            // pointsSettingBtn
            // 
            this.pointsSettingBtn.Name = "pointsSettingBtn";
            this.pointsSettingBtn.Size = new System.Drawing.Size(180, 22);
            this.pointsSettingBtn.Text = "Цвет точек";
            this.pointsSettingBtn.Click += new System.EventHandler(this.pointsSettingBtn_Click);
            // 
            // markerTypeBtn
            // 
            this.markerTypeBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.percentMarkerBtn,
            this.valuesMarkerBtn,
            this.noneMarkerBtn});
            this.markerTypeBtn.Name = "markerTypeBtn";
            this.markerTypeBtn.Size = new System.Drawing.Size(180, 22);
            this.markerTypeBtn.Text = "Тип подписей";
            // 
            // percentMarkerBtn
            // 
            this.percentMarkerBtn.Name = "percentMarkerBtn";
            this.percentMarkerBtn.Size = new System.Drawing.Size(180, 22);
            this.percentMarkerBtn.Text = "Проценты";
            this.percentMarkerBtn.Click += new System.EventHandler(this.percentMarkerBtn_Click);
            // 
            // valuesMarkerBtn
            // 
            this.valuesMarkerBtn.Name = "valuesMarkerBtn";
            this.valuesMarkerBtn.Size = new System.Drawing.Size(180, 22);
            this.valuesMarkerBtn.Text = "Значения";
            this.valuesMarkerBtn.Click += new System.EventHandler(this.valuesMarkerBtn_Click);
            // 
            // markerFontBtn
            // 
            this.markerFontBtn.Name = "markerFontBtn";
            this.markerFontBtn.Size = new System.Drawing.Size(180, 22);
            this.markerFontBtn.Text = "Шрифт подписей";
            this.markerFontBtn.Click += new System.EventHandler(this.markerFontBtn_Click);
            // 
            // visualChart
            // 
            this.visualChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea4.Name = "ChartArea1";
            this.visualChart.ChartAreas.Add(chartArea4);
            this.visualChart.Location = new System.Drawing.Point(13, 28);
            this.visualChart.Name = "visualChart";
            this.visualChart.Size = new System.Drawing.Size(959, 521);
            this.visualChart.TabIndex = 1;
            this.visualChart.Text = "visualChart";
            // 
            // seriesMenu
            // 
            this.seriesMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seriesColorBtn,
            this.pointColorBtn,
            this.markFontBtn,
            this.selectMarkFontDtn});
            this.seriesMenu.Name = "seriesMenu";
            this.seriesMenu.Size = new System.Drawing.Size(292, 92);
            // 
            // seriesColorBtn
            // 
            this.seriesColorBtn.Name = "seriesColorBtn";
            this.seriesColorBtn.Size = new System.Drawing.Size(291, 22);
            this.seriesColorBtn.Text = "Изменить цвет серии";
            this.seriesColorBtn.Click += new System.EventHandler(this.seriesColorBtn_Click);
            // 
            // pointColorBtn
            // 
            this.pointColorBtn.Name = "pointColorBtn";
            this.pointColorBtn.Size = new System.Drawing.Size(291, 22);
            this.pointColorBtn.Text = "Изменить цвет точки";
            this.pointColorBtn.Click += new System.EventHandler(this.pointColorBtn_Click);
            // 
            // markFontBtn
            // 
            this.markFontBtn.Name = "markFontBtn";
            this.markFontBtn.Size = new System.Drawing.Size(291, 22);
            this.markFontBtn.Text = "Изменить шрифт маркеров";
            this.markFontBtn.Click += new System.EventHandler(this.markFontBtn_Click);
            // 
            // selectMarkFontDtn
            // 
            this.selectMarkFontDtn.Name = "selectMarkFontDtn";
            this.selectMarkFontDtn.Size = new System.Drawing.Size(291, 22);
            this.selectMarkFontDtn.Text = "Изменить шрифт выбранного маркерв";
            this.selectMarkFontDtn.Click += new System.EventHandler(this.selectMarkFontDtn_Click);
            // 
            // titleMenu
            // 
            this.titleMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontTitleBtn,
            this.changeTitleBtn,
            this.deleteTitleBtn});
            this.titleMenu.Name = "seriesMenu";
            this.titleMenu.Size = new System.Drawing.Size(188, 70);
            // 
            // fontTitleBtn
            // 
            this.fontTitleBtn.Name = "fontTitleBtn";
            this.fontTitleBtn.Size = new System.Drawing.Size(187, 22);
            this.fontTitleBtn.Text = "Изменить шрифт";
            this.fontTitleBtn.Click += new System.EventHandler(this.fontTitleBtn_Click);
            // 
            // changeTitleBtn
            // 
            this.changeTitleBtn.Name = "changeTitleBtn";
            this.changeTitleBtn.Size = new System.Drawing.Size(187, 22);
            this.changeTitleBtn.Text = "Изменить заголовок";
            this.changeTitleBtn.Click += new System.EventHandler(this.changeTtileBtn_Click);
            // 
            // deleteTitleBtn
            // 
            this.deleteTitleBtn.Name = "deleteTitleBtn";
            this.deleteTitleBtn.Size = new System.Drawing.Size(187, 22);
            this.deleteTitleBtn.Text = "Удалить";
            this.deleteTitleBtn.Click += new System.EventHandler(this.deleteTitleBtn_Click);
            // 
            // legendMenu
            // 
            this.legendMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLegendMenuBtn,
            this.legendsBGSettingMenuBtn,
            this.changeLegendFontBtn});
            this.legendMenu.Name = "seriesMenu";
            this.legendMenu.Size = new System.Drawing.Size(188, 70);
            // 
            // showLegendMenuBtn
            // 
            this.showLegendMenuBtn.Name = "showLegendMenuBtn";
            this.showLegendMenuBtn.Size = new System.Drawing.Size(187, 22);
            this.showLegendMenuBtn.Text = "Отображать легенду";
            this.showLegendMenuBtn.Click += new System.EventHandler(this.showLegendBtn_Click);
            // 
            // legendsBGSettingMenuBtn
            // 
            this.legendsBGSettingMenuBtn.Name = "legendsBGSettingMenuBtn";
            this.legendsBGSettingMenuBtn.Size = new System.Drawing.Size(187, 22);
            this.legendsBGSettingMenuBtn.Text = "Фон легенды";
            this.legendsBGSettingMenuBtn.Click += new System.EventHandler(this.legendsBGSettingBtn_Click);
            // 
            // changeLegendFontBtn
            // 
            this.changeLegendFontBtn.Name = "changeLegendFontBtn";
            this.changeLegendFontBtn.Size = new System.Drawing.Size(187, 22);
            this.changeLegendFontBtn.Text = "Изменить шрифт";
            this.changeLegendFontBtn.Click += new System.EventHandler(this.legendFontBtn_Click);
            // 
            // noneMarkerBtn
            // 
            this.noneMarkerBtn.Name = "noneMarkerBtn";
            this.noneMarkerBtn.Size = new System.Drawing.Size(180, 22);
            this.noneMarkerBtn.Text = "Отсутствие";
            this.noneMarkerBtn.Click += new System.EventHandler(this.noneMarkerBtn_Click);
            // 
            // legendValBtn
            // 
            this.legendValBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.legendColPerBtn,
            this.legendColValBtn,
            this.legendColNoneBtn});
            this.legendValBtn.Name = "legendValBtn";
            this.legendValBtn.Size = new System.Drawing.Size(187, 22);
            this.legendValBtn.Text = "Значения в легенде";
            // 
            // legendColPerBtn
            // 
            this.legendColPerBtn.Name = "legendColPerBtn";
            this.legendColPerBtn.Size = new System.Drawing.Size(180, 22);
            this.legendColPerBtn.Text = "Проценты";
            this.legendColPerBtn.Click += new System.EventHandler(this.legendColPerBtn_Click);
            // 
            // legendColValBtn
            // 
            this.legendColValBtn.Name = "legendColValBtn";
            this.legendColValBtn.Size = new System.Drawing.Size(180, 22);
            this.legendColValBtn.Text = "Значения";
            this.legendColValBtn.Click += new System.EventHandler(this.legendColValBtn_Click);
            // 
            // legendColNoneBtn
            // 
            this.legendColNoneBtn.Name = "legendColNoneBtn";
            this.legendColNoneBtn.Size = new System.Drawing.Size(180, 22);
            this.legendColNoneBtn.Text = "Отсутствуют";
            this.legendColNoneBtn.Click += new System.EventHandler(this.legendColNoneBtn_Click);
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
            this.seriesMenu.ResumeLayout(false);
            this.titleMenu.ResumeLayout(false);
            this.legendMenu.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem showGridBtn;
        private System.Windows.Forms.ToolStripMenuItem showAxisBtn;
        private System.Windows.Forms.ToolStripMenuItem showAxisXBtn;
        private System.Windows.Forms.ToolStripMenuItem showAxisYBtn;
        private System.Windows.Forms.ContextMenuStrip seriesMenu;
        private System.Windows.Forms.ToolStripMenuItem seriesColorBtn;
        private System.Windows.Forms.ToolStripMenuItem pointColorBtn;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ContextMenuStrip titleMenu;
        private System.Windows.Forms.ToolStripMenuItem changeTitleBtn;
        private System.Windows.Forms.ToolStripMenuItem deleteTitleBtn;
        private System.Windows.Forms.ToolStripMenuItem fontTitleBtn;
        private System.Windows.Forms.ToolStripMenuItem markFontBtn;
        private System.Windows.Forms.ContextMenuStrip legendMenu;
        private System.Windows.Forms.ToolStripMenuItem changeLegendFontBtn;
        private System.Windows.Forms.ToolStripMenuItem showLegendMenuBtn;
        private System.Windows.Forms.ToolStripMenuItem легендаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem legendFontBtn;
        private System.Windows.Forms.ToolStripMenuItem showLegendBtn;
        private System.Windows.Forms.ToolStripMenuItem legendsBGSettingBtn;
        private System.Windows.Forms.ToolStripMenuItem заголовокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem titleFontBtn;
        private System.Windows.Forms.ToolStripMenuItem titlrSettingBtn;
        private System.Windows.Forms.ToolStripMenuItem showTitleMBtn;
        private System.Windows.Forms.ToolStripMenuItem allItemBtn;
        private System.Windows.Forms.ToolStripMenuItem серииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem markerFontBtn;
        private System.Windows.Forms.ToolStripMenuItem diagramTypeSettingBtn;
        private System.Windows.Forms.ToolStripMenuItem markerTypeBtn;
        private System.Windows.Forms.ToolStripMenuItem percentMarkerBtn;
        private System.Windows.Forms.ToolStripMenuItem valuesMarkerBtn;
        private System.Windows.Forms.ToolStripMenuItem seriesSettingBtn;
        private System.Windows.Forms.ToolStripMenuItem pointsSettingBtn;
        private System.Windows.Forms.ToolStripMenuItem mode3DSettingBtn;
        private System.Windows.Forms.ToolStripMenuItem legendsBGSettingMenuBtn;
        private System.Windows.Forms.ToolStripMenuItem selectMarkFontDtn;
        private System.Windows.Forms.ToolStripMenuItem noneMarkerBtn;
        private System.Windows.Forms.ToolStripMenuItem legendValBtn;
        private System.Windows.Forms.ToolStripMenuItem legendColPerBtn;
        private System.Windows.Forms.ToolStripMenuItem legendColValBtn;
        private System.Windows.Forms.ToolStripMenuItem legendColNoneBtn;
    }
}