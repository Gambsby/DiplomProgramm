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
            this.визуализацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnDiagramBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.barDiagramBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.pieDiagramBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.groupVisBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.profilesCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.infoDG = new System.Windows.Forms.DataGridView();
            this.allColumnDiagramBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.allPieDiagramBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.allDoughnoutDiagramBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.allBarDiagramBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.infoDG)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.визуализацияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1025, 24);
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
            this.closeProfileBtn.Name = "closeProfileBtn";
            this.closeProfileBtn.Size = new System.Drawing.Size(171, 22);
            this.closeProfileBtn.Text = "Закрыть анкету";
            this.closeProfileBtn.Click += new System.EventHandler(this.closeProfileBtn_Click);
            // 
            // визуализацияToolStripMenuItem
            // 
            this.визуализацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.columnDiagramBtn,
            this.barDiagramBtn,
            this.pieDiagramBtn,
            this.groupVisBtn});
            this.визуализацияToolStripMenuItem.Name = "визуализацияToolStripMenuItem";
            this.визуализацияToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.визуализацияToolStripMenuItem.Text = "Визуализация";
            // 
            // columnDiagramBtn
            // 
            this.columnDiagramBtn.Name = "columnDiagramBtn";
            this.columnDiagramBtn.Size = new System.Drawing.Size(229, 22);
            this.columnDiagramBtn.Text = "Столбчатая диаграмма";
            this.columnDiagramBtn.Click += new System.EventHandler(this.columnDiagramBtn_Click);
            // 
            // barDiagramBtn
            // 
            this.barDiagramBtn.Name = "barDiagramBtn";
            this.barDiagramBtn.Size = new System.Drawing.Size(229, 22);
            this.barDiagramBtn.Text = "Горизонтальная дианрамма";
            this.barDiagramBtn.Click += new System.EventHandler(this.barDiagramBtn_Click);
            // 
            // pieDiagramBtn
            // 
            this.pieDiagramBtn.Name = "pieDiagramBtn";
            this.pieDiagramBtn.Size = new System.Drawing.Size(229, 22);
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
            this.groupVisBtn.Size = new System.Drawing.Size(229, 22);
            this.groupVisBtn.Text = "Создать для всех";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "физвоспитание анкета.xlsx";
            // 
            // profilesCB
            // 
            this.profilesCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.profilesCB.FormattingEnabled = true;
            this.profilesCB.Location = new System.Drawing.Point(885, 44);
            this.profilesCB.Name = "profilesCB";
            this.profilesCB.Size = new System.Drawing.Size(131, 21);
            this.profilesCB.TabIndex = 2;
            this.profilesCB.SelectedIndexChanged += new System.EventHandler(this.profilesCB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(885, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Доступные анкеты:";
            // 
            // infoDG
            // 
            this.infoDG.AllowUserToAddRows = false;
            this.infoDG.AllowUserToDeleteRows = false;
            this.infoDG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.infoDG.Location = new System.Drawing.Point(13, 28);
            this.infoDG.Name = "infoDG";
            this.infoDG.Size = new System.Drawing.Size(866, 519);
            this.infoDG.TabIndex = 4;
            // 
            // allColumnDiagramBtn
            // 
            this.allColumnDiagramBtn.Name = "allColumnDiagramBtn";
            this.allColumnDiagramBtn.Size = new System.Drawing.Size(222, 22);
            this.allColumnDiagramBtn.Text = "Столбчатая диаграмма";
            this.allColumnDiagramBtn.Click += new System.EventHandler(this.allColumnDiagramBtn_Click);
            // 
            // allPieDiagramBtn
            // 
            this.allPieDiagramBtn.Name = "allPieDiagramBtn";
            this.allPieDiagramBtn.Size = new System.Drawing.Size(222, 22);
            this.allPieDiagramBtn.Text = "Груговая диаграмма";
            this.allPieDiagramBtn.Click += new System.EventHandler(this.allPieDiagramBtn_Click);
            // 
            // allDoughnoutDiagramBtn
            // 
            this.allDoughnoutDiagramBtn.Name = "allDoughnoutDiagramBtn";
            this.allDoughnoutDiagramBtn.Size = new System.Drawing.Size(222, 22);
            this.allDoughnoutDiagramBtn.Text = "Пончик диаграмма";
            this.allDoughnoutDiagramBtn.Click += new System.EventHandler(this.allDoughnoutDiagramBtn_Click);
            // 
            // allBarDiagramBtn
            // 
            this.allBarDiagramBtn.Name = "allBarDiagramBtn";
            this.allBarDiagramBtn.Size = new System.Drawing.Size(222, 22);
            this.allBarDiagramBtn.Text = "Горионтальная диаграмма";
            this.allBarDiagramBtn.Click += new System.EventHandler(this.allBarDiagramBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 559);
            this.Controls.Add(this.infoDG);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.profilesCB);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.infoDG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem deleteDataBtn;
        private System.Windows.Forms.ComboBox profilesCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem loadDataBtn;
        private System.Windows.Forms.DataGridView infoDG;
        private System.Windows.Forms.ToolStripMenuItem визуализацияToolStripMenuItem;
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
    }
}

