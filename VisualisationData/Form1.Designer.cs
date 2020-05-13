namespace VisualisationData
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDataBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDataExcelBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDataDBBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.saveBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCSVBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.saveExcelBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDBBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDataBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.closeProfileBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.visDataBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.columnDiagramBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.barDiagramBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.pieDiagramBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.groupVisBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.allColumnDiagramBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.allPieDiagramBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.allDoughnoutDiagramBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.allBarDiagramBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.helpBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTab = new System.Windows.Forms.TabControl();
            this.tableL1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.questionTB = new System.Windows.Forms.TextBox();
            this.questionBtn = new System.Windows.Forms.Button();
            this.infoMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showInfoBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.saveQuestionInfoBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllQuestionInfoBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.openAnswerInfoBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tableL1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.infoMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.visDataBtn,
            this.helpBtn});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1117, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDataBtn,
            this.saveBtn,
            this.deleteDataBtn,
            this.closeProfileBtn});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // loadDataBtn
            // 
            this.loadDataBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDataExcelBtn,
            this.loadDataDBBtn});
            this.loadDataBtn.Name = "loadDataBtn";
            this.loadDataBtn.Size = new System.Drawing.Size(171, 22);
            this.loadDataBtn.Text = "Загрузить анкету";
            // 
            // loadDataExcelBtn
            // 
            this.loadDataExcelBtn.Name = "loadDataExcelBtn";
            this.loadDataExcelBtn.Size = new System.Drawing.Size(141, 22);
            this.loadDataExcelBtn.Text = "Excel";
            this.loadDataExcelBtn.Click += new System.EventHandler(this.loadDataExcelBtn_Click);
            // 
            // loadDataDBBtn
            // 
            this.loadDataDBBtn.Name = "loadDataDBBtn";
            this.loadDataDBBtn.Size = new System.Drawing.Size(141, 22);
            this.loadDataDBBtn.Text = "База данных";
            this.loadDataDBBtn.Click += new System.EventHandler(this.loadDataDBBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveCSVBtn,
            this.saveExcelBtn,
            this.saveDBBtn});
            this.saveBtn.Enabled = false;
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(171, 22);
            this.saveBtn.Text = "Сохранить анкету";
            // 
            // saveCSVBtn
            // 
            this.saveCSVBtn.Name = "saveCSVBtn";
            this.saveCSVBtn.Size = new System.Drawing.Size(141, 22);
            this.saveCSVBtn.Text = "CSV";
            this.saveCSVBtn.Click += new System.EventHandler(this.saveCSVBtn_Click);
            // 
            // saveExcelBtn
            // 
            this.saveExcelBtn.Name = "saveExcelBtn";
            this.saveExcelBtn.Size = new System.Drawing.Size(141, 22);
            this.saveExcelBtn.Text = "Excel";
            this.saveExcelBtn.Click += new System.EventHandler(this.saveExcelBtn_Click);
            // 
            // saveDBBtn
            // 
            this.saveDBBtn.Name = "saveDBBtn";
            this.saveDBBtn.Size = new System.Drawing.Size(141, 22);
            this.saveDBBtn.Text = "База данных";
            this.saveDBBtn.Click += new System.EventHandler(this.saveDBBtn_Click);
            // 
            // deleteDataBtn
            // 
            this.deleteDataBtn.Name = "deleteDataBtn";
            this.deleteDataBtn.Size = new System.Drawing.Size(171, 22);
            this.deleteDataBtn.Text = "Удалить анкету";
            this.deleteDataBtn.Click += new System.EventHandler(this.deleteDataBtn_Click);
            // 
            // closeProfileBtn
            // 
            this.closeProfileBtn.Enabled = false;
            this.closeProfileBtn.Name = "closeProfileBtn";
            this.closeProfileBtn.Size = new System.Drawing.Size(171, 22);
            this.closeProfileBtn.Text = "Закрыть анкету";
            this.closeProfileBtn.Click += new System.EventHandler(this.closeProfileBtn_Click);
            // 
            // visDataBtn
            // 
            this.visDataBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.columnDiagramBtn,
            this.barDiagramBtn,
            this.pieDiagramBtn,
            this.groupVisBtn});
            this.visDataBtn.Name = "visDataBtn";
            this.visDataBtn.Size = new System.Drawing.Size(95, 20);
            this.visDataBtn.Text = "Визуализация";
            // 
            // columnDiagramBtn
            // 
            this.columnDiagramBtn.Name = "columnDiagramBtn";
            this.columnDiagramBtn.Size = new System.Drawing.Size(227, 22);
            this.columnDiagramBtn.Text = "Столбчатая диаграмма";
            this.columnDiagramBtn.Click += new System.EventHandler(this.columnDiagramBtn_Click);
            // 
            // barDiagramBtn
            // 
            this.barDiagramBtn.Name = "barDiagramBtn";
            this.barDiagramBtn.Size = new System.Drawing.Size(227, 22);
            this.barDiagramBtn.Text = "Горизонтальная диаграмма";
            this.barDiagramBtn.Click += new System.EventHandler(this.barDiagramBtn_Click);
            // 
            // pieDiagramBtn
            // 
            this.pieDiagramBtn.Name = "pieDiagramBtn";
            this.pieDiagramBtn.Size = new System.Drawing.Size(227, 22);
            this.pieDiagramBtn.Text = "Круговая диаграмма";
            this.pieDiagramBtn.Click += new System.EventHandler(this.pieDiagramBtn_Click);
            // 
            // groupVisBtn
            // 
            this.groupVisBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allColumnDiagramBtn,
            this.allPieDiagramBtn,
            this.allDoughnoutDiagramBtn,
            this.allBarDiagramBtn});
            this.groupVisBtn.Name = "groupVisBtn";
            this.groupVisBtn.Size = new System.Drawing.Size(227, 22);
            this.groupVisBtn.Text = "Создать для всех";
            // 
            // allColumnDiagramBtn
            // 
            this.allColumnDiagramBtn.Name = "allColumnDiagramBtn";
            this.allColumnDiagramBtn.Size = new System.Drawing.Size(227, 22);
            this.allColumnDiagramBtn.Text = "Столбчатая диаграмма";
            this.allColumnDiagramBtn.Click += new System.EventHandler(this.allColumnDiagramBtn_Click);
            // 
            // allPieDiagramBtn
            // 
            this.allPieDiagramBtn.Name = "allPieDiagramBtn";
            this.allPieDiagramBtn.Size = new System.Drawing.Size(227, 22);
            this.allPieDiagramBtn.Text = "Круговая диаграмма";
            this.allPieDiagramBtn.Click += new System.EventHandler(this.allPieDiagramBtn_Click);
            // 
            // allDoughnoutDiagramBtn
            // 
            this.allDoughnoutDiagramBtn.Name = "allDoughnoutDiagramBtn";
            this.allDoughnoutDiagramBtn.Size = new System.Drawing.Size(227, 22);
            this.allDoughnoutDiagramBtn.Text = "Пончик диаграмма";
            this.allDoughnoutDiagramBtn.Click += new System.EventHandler(this.allDoughnoutDiagramBtn_Click);
            // 
            // allBarDiagramBtn
            // 
            this.allBarDiagramBtn.Name = "allBarDiagramBtn";
            this.allBarDiagramBtn.Size = new System.Drawing.Size(227, 22);
            this.allBarDiagramBtn.Text = "Горизонтальная диаграмма";
            this.allBarDiagramBtn.Click += new System.EventHandler(this.allBarDiagramBtn_Click);
            // 
            // helpBtn
            // 
            this.helpBtn.Name = "helpBtn";
            this.helpBtn.Size = new System.Drawing.Size(65, 20);
            this.helpBtn.Text = "Справка";
            this.helpBtn.Click += new System.EventHandler(this.helpBtn_Click);
            // 
            // mainTab
            // 
            this.mainTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTab.Location = new System.Drawing.Point(3, 33);
            this.mainTab.Name = "mainTab";
            this.mainTab.SelectedIndex = 0;
            this.mainTab.Size = new System.Drawing.Size(1111, 529);
            this.mainTab.TabIndex = 4;
            // 
            // tableL1
            // 
            this.tableL1.ColumnCount = 1;
            this.tableL1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableL1.Controls.Add(this.mainTab, 0, 1);
            this.tableL1.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableL1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableL1.Location = new System.Drawing.Point(0, 24);
            this.tableL1.Name = "tableL1";
            this.tableL1.RowCount = 2;
            this.tableL1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableL1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableL1.Size = new System.Drawing.Size(1117, 565);
            this.tableL1.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.questionTB, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.questionBtn, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1117, 30);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите вопрос";
            // 
            // questionTB
            // 
            this.questionTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.questionTB.Location = new System.Drawing.Point(113, 5);
            this.questionTB.Name = "questionTB";
            this.questionTB.Size = new System.Drawing.Size(911, 20);
            this.questionTB.TabIndex = 1;
            // 
            // questionBtn
            // 
            this.questionBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.questionBtn.Enabled = false;
            this.questionBtn.Location = new System.Drawing.Point(1030, 3);
            this.questionBtn.Name = "questionBtn";
            this.questionBtn.Size = new System.Drawing.Size(84, 23);
            this.questionBtn.TabIndex = 2;
            this.questionBtn.Text = "Найти";
            this.questionBtn.UseVisualStyleBackColor = true;
            this.questionBtn.Click += new System.EventHandler(this.questionBtn_Click);
            // 
            // infoMenu
            // 
            this.infoMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInfoBtn,
            this.saveQuestionInfoBtn,
            this.saveAllQuestionInfoBtn,
            this.openAnswerInfoBtn});
            this.infoMenu.Name = "infoMenu";
            this.infoMenu.Size = new System.Drawing.Size(320, 114);
            // 
            // showInfoBtn
            // 
            this.showInfoBtn.Name = "showInfoBtn";
            this.showInfoBtn.Size = new System.Drawing.Size(304, 22);
            this.showInfoBtn.Text = "Показать информацию";
            this.showInfoBtn.Click += new System.EventHandler(this.showInfoBtn_Click);
            // 
            // saveQuestionInfoBtn
            // 
            this.saveQuestionInfoBtn.Name = "saveQuestionInfoBtn";
            this.saveQuestionInfoBtn.Size = new System.Drawing.Size(304, 22);
            this.saveQuestionInfoBtn.Text = "Сохранить информацию для выбранного";
            this.saveQuestionInfoBtn.Click += new System.EventHandler(this.saveQuestionInfoBtn_Click);
            // 
            // saveAllQuestionInfoBtn
            // 
            this.saveAllQuestionInfoBtn.Name = "saveAllQuestionInfoBtn";
            this.saveAllQuestionInfoBtn.Size = new System.Drawing.Size(304, 22);
            this.saveAllQuestionInfoBtn.Text = "Сохранить информацию для всех";
            this.saveAllQuestionInfoBtn.Click += new System.EventHandler(this.saveQuestionInfo_Click);
            // 
            // openAnswerInfoBtn
            // 
            this.openAnswerInfoBtn.Name = "openAnswerInfoBtn";
            this.openAnswerInfoBtn.Size = new System.Drawing.Size(319, 22);
            this.openAnswerInfoBtn.Text = "Показать информацию об открытых ответах";
            this.openAnswerInfoBtn.Click += new System.EventHandler(this.openAnswerInfoBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 589);
            this.Controls.Add(this.tableL1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Визуализация данных";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableL1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.infoMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveBtn;
        private System.Windows.Forms.ToolStripMenuItem deleteDataBtn;
        private System.Windows.Forms.ToolStripMenuItem loadDataBtn;
        private System.Windows.Forms.ToolStripMenuItem visDataBtn;
        private System.Windows.Forms.ToolStripMenuItem columnDiagramBtn;
        private System.Windows.Forms.ToolStripMenuItem barDiagramBtn;
        private System.Windows.Forms.ToolStripMenuItem pieDiagramBtn;
        private System.Windows.Forms.ToolStripMenuItem saveCSVBtn;
        private System.Windows.Forms.ToolStripMenuItem saveExcelBtn;
        private System.Windows.Forms.ToolStripMenuItem saveDBBtn;
        private System.Windows.Forms.ToolStripMenuItem closeProfileBtn;
        private System.Windows.Forms.ToolStripMenuItem loadDataExcelBtn;
        private System.Windows.Forms.ToolStripMenuItem loadDataDBBtn;
        private System.Windows.Forms.ToolStripMenuItem groupVisBtn;
        private System.Windows.Forms.ToolStripMenuItem allColumnDiagramBtn;
        private System.Windows.Forms.ToolStripMenuItem allPieDiagramBtn;
        private System.Windows.Forms.ToolStripMenuItem allDoughnoutDiagramBtn;
        private System.Windows.Forms.ToolStripMenuItem allBarDiagramBtn;
        private System.Windows.Forms.TabControl mainTab;
        private System.Windows.Forms.TableLayoutPanel tableL1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox questionTB;
        private System.Windows.Forms.Button questionBtn;
        private System.Windows.Forms.ToolStripMenuItem helpBtn;
        private System.Windows.Forms.ContextMenuStrip infoMenu;
        private System.Windows.Forms.ToolStripMenuItem showInfoBtn;
        private System.Windows.Forms.ToolStripMenuItem saveAllQuestionInfoBtn;
        private System.Windows.Forms.ToolStripMenuItem saveQuestionInfoBtn;
        private System.Windows.Forms.ToolStripMenuItem openAnswerInfoBtn;
    }
}

