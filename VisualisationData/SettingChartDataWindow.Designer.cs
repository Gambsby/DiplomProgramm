namespace VisualisationData
{
    partial class SettingChartDataWindow
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
            this.seriesCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.typeDiagramCB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BGColorBtn = new System.Windows.Forms.Button();
            this.submitBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.signatureCheck = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gradientTypeCB = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.secondBGColorBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.diagramGradientTypeCB = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.diagramSecondBGColorBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.diagramBGColorBtn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.borderStyleCB = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.borderTypeCB = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.borderColorBtn = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pointColorBtn = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.pointsCB = new System.Windows.Forms.ComboBox();
            this.seriesColorBtn = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.titleTB = new System.Windows.Forms.TextBox();
            this.mode3DCheck = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pointColorCheck = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // seriesCB
            // 
            this.seriesCB.FormattingEnabled = true;
            this.seriesCB.Location = new System.Drawing.Point(117, 118);
            this.seriesCB.Name = "seriesCB";
            this.seriesCB.Size = new System.Drawing.Size(271, 21);
            this.seriesCB.TabIndex = 0;
            this.seriesCB.SelectedIndexChanged += new System.EventHandler(this.seriesCB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Серии данных";
            // 
            // typeDiagramCB
            // 
            this.typeDiagramCB.FormattingEnabled = true;
            this.typeDiagramCB.Location = new System.Drawing.Point(117, 65);
            this.typeDiagramCB.Name = "typeDiagramCB";
            this.typeDiagramCB.Size = new System.Drawing.Size(271, 21);
            this.typeDiagramCB.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Тип графика";
            // 
            // BGColorBtn
            // 
            this.BGColorBtn.Location = new System.Drawing.Point(6, 19);
            this.BGColorBtn.Name = "BGColorBtn";
            this.BGColorBtn.Size = new System.Drawing.Size(20, 20);
            this.BGColorBtn.TabIndex = 4;
            this.BGColorBtn.UseVisualStyleBackColor = true;
            this.BGColorBtn.Click += new System.EventHandler(this.BGColorBtn_Click);
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(725, 348);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(81, 23);
            this.submitBtn.TabIndex = 6;
            this.submitBtn.Text = "Принять";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(571, 348);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(121, 23);
            this.closeBtn.TabIndex = 7;
            this.closeBtn.Text = "Закрыть";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // signatureCheck
            // 
            this.signatureCheck.AutoSize = true;
            this.signatureCheck.Location = new System.Drawing.Point(9, 19);
            this.signatureCheck.Name = "signatureCheck";
            this.signatureCheck.Size = new System.Drawing.Size(193, 17);
            this.signatureCheck.TabIndex = 8;
            this.signatureCheck.Text = "Включить подписиси на графике";
            this.signatureCheck.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gradientTypeCB);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.secondBGColorBtn);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.BGColorBtn);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 100);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройка фона";
            // 
            // gradientTypeCB
            // 
            this.gradientTypeCB.FormattingEnabled = true;
            this.gradientTypeCB.Location = new System.Drawing.Point(6, 63);
            this.gradientTypeCB.Name = "gradientTypeCB";
            this.gradientTypeCB.Size = new System.Drawing.Size(376, 21);
            this.gradientTypeCB.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Тип градиента";
            // 
            // secondBGColorBtn
            // 
            this.secondBGColorBtn.Location = new System.Drawing.Point(122, 19);
            this.secondBGColorBtn.Name = "secondBGColorBtn";
            this.secondBGColorBtn.Size = new System.Drawing.Size(20, 20);
            this.secondBGColorBtn.TabIndex = 12;
            this.secondBGColorBtn.UseVisualStyleBackColor = true;
            this.secondBGColorBtn.Click += new System.EventHandler(this.secondBGColorBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(148, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Второй цвет фона";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Цвет фона";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.diagramGradientTypeCB);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.diagramSecondBGColorBtn);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.diagramBGColorBtn);
            this.groupBox2.Location = new System.Drawing.Point(12, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(394, 100);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Настройка фона диаграммы";
            // 
            // diagramGradientTypeCB
            // 
            this.diagramGradientTypeCB.FormattingEnabled = true;
            this.diagramGradientTypeCB.Location = new System.Drawing.Point(6, 63);
            this.diagramGradientTypeCB.Name = "diagramGradientTypeCB";
            this.diagramGradientTypeCB.Size = new System.Drawing.Size(376, 21);
            this.diagramGradientTypeCB.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Тип градиента";
            // 
            // diagramSecondBGColorBtn
            // 
            this.diagramSecondBGColorBtn.Location = new System.Drawing.Point(122, 19);
            this.diagramSecondBGColorBtn.Name = "diagramSecondBGColorBtn";
            this.diagramSecondBGColorBtn.Size = new System.Drawing.Size(20, 20);
            this.diagramSecondBGColorBtn.TabIndex = 12;
            this.diagramSecondBGColorBtn.UseVisualStyleBackColor = true;
            this.diagramSecondBGColorBtn.Click += new System.EventHandler(this.diagramSecondBGColorBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(148, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Второй цвет фона";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Цвет фона";
            // 
            // diagramBGColorBtn
            // 
            this.diagramBGColorBtn.Location = new System.Drawing.Point(6, 19);
            this.diagramBGColorBtn.Name = "diagramBGColorBtn";
            this.diagramBGColorBtn.Size = new System.Drawing.Size(20, 20);
            this.diagramBGColorBtn.TabIndex = 4;
            this.diagramBGColorBtn.UseVisualStyleBackColor = true;
            this.diagramBGColorBtn.Click += new System.EventHandler(this.diagramBGColorBtn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.borderStyleCB);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.borderTypeCB);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.borderColorBtn);
            this.groupBox3.Location = new System.Drawing.Point(13, 225);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(394, 146);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Настройка рамки";
            // 
            // borderStyleCB
            // 
            this.borderStyleCB.FormattingEnabled = true;
            this.borderStyleCB.Location = new System.Drawing.Point(6, 109);
            this.borderStyleCB.Name = "borderStyleCB";
            this.borderStyleCB.Size = new System.Drawing.Size(376, 21);
            this.borderStyleCB.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Стиль рамки";
            // 
            // borderTypeCB
            // 
            this.borderTypeCB.FormattingEnabled = true;
            this.borderTypeCB.Location = new System.Drawing.Point(6, 63);
            this.borderTypeCB.Name = "borderTypeCB";
            this.borderTypeCB.Size = new System.Drawing.Size(376, 21);
            this.borderTypeCB.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Тип рамки";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Цвет рамки";
            // 
            // borderColorBtn
            // 
            this.borderColorBtn.Location = new System.Drawing.Point(6, 19);
            this.borderColorBtn.Name = "borderColorBtn";
            this.borderColorBtn.Size = new System.Drawing.Size(20, 20);
            this.borderColorBtn.TabIndex = 4;
            this.borderColorBtn.UseVisualStyleBackColor = true;
            this.borderColorBtn.Click += new System.EventHandler(this.borderColorBtn_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pointColorCheck);
            this.groupBox4.Controls.Add(this.pointColorBtn);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.pointsCB);
            this.groupBox4.Controls.Add(this.seriesColorBtn);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.titleTB);
            this.groupBox4.Controls.Add(this.mode3DCheck);
            this.groupBox4.Controls.Add(this.signatureCheck);
            this.groupBox4.Controls.Add(this.typeDiagramCB);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.seriesCB);
            this.groupBox4.Location = new System.Drawing.Point(416, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(394, 317);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Настройка данных";
            // 
            // pointColorBtn
            // 
            this.pointColorBtn.Enabled = false;
            this.pointColorBtn.Location = new System.Drawing.Point(117, 221);
            this.pointColorBtn.Name = "pointColorBtn";
            this.pointColorBtn.Size = new System.Drawing.Size(20, 20);
            this.pointColorBtn.TabIndex = 21;
            this.pointColorBtn.UseVisualStyleBackColor = true;
            this.pointColorBtn.Click += new System.EventHandler(this.pointColorBtn_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(27, 225);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "Цвет элемента";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(19, 197);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(92, 13);
            this.label15.TabIndex = 19;
            this.label15.Text = "Элементы серии";
            // 
            // pointsCB
            // 
            this.pointsCB.Enabled = false;
            this.pointsCB.FormattingEnabled = true;
            this.pointsCB.Location = new System.Drawing.Point(117, 194);
            this.pointsCB.Name = "pointsCB";
            this.pointsCB.Size = new System.Drawing.Size(271, 21);
            this.pointsCB.TabIndex = 18;
            this.pointsCB.SelectedIndexChanged += new System.EventHandler(this.pointsCB_SelectedIndexChanged);
            // 
            // seriesColorBtn
            // 
            this.seriesColorBtn.Location = new System.Drawing.Point(117, 145);
            this.seriesColorBtn.Name = "seriesColorBtn";
            this.seriesColorBtn.Size = new System.Drawing.Size(20, 20);
            this.seriesColorBtn.TabIndex = 16;
            this.seriesColorBtn.UseVisualStyleBackColor = true;
            this.seriesColorBtn.Click += new System.EventHandler(this.seriesColorBtn_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(50, 95);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "Заголовок";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(46, 149);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "Цвет серии";
            // 
            // titleTB
            // 
            this.titleTB.Location = new System.Drawing.Point(117, 92);
            this.titleTB.Name = "titleTB";
            this.titleTB.Size = new System.Drawing.Size(271, 20);
            this.titleTB.TabIndex = 16;
            // 
            // mode3DCheck
            // 
            this.mode3DCheck.AutoSize = true;
            this.mode3DCheck.Location = new System.Drawing.Point(9, 42);
            this.mode3DCheck.Name = "mode3DCheck";
            this.mode3DCheck.Size = new System.Drawing.Size(129, 17);
            this.mode3DCheck.TabIndex = 15;
            this.mode3DCheck.Text = "Включить 3D режим";
            this.mode3DCheck.UseVisualStyleBackColor = true;
            // 
            // pointColorCheck
            // 
            this.pointColorCheck.AutoSize = true;
            this.pointColorCheck.Location = new System.Drawing.Point(9, 171);
            this.pointColorCheck.Name = "pointColorCheck";
            this.pointColorCheck.Size = new System.Drawing.Size(257, 17);
            this.pointColorCheck.TabIndex = 22;
            this.pointColorCheck.Text = "Задать цвет отдельно для каждого элемента";
            this.pointColorCheck.UseVisualStyleBackColor = true;
            this.pointColorCheck.CheckedChanged += new System.EventHandler(this.poinColorCheck_CheckedChanged);
            // 
            // SettingChartDataWindow
            // 
            this.ClientSize = new System.Drawing.Size(818, 383);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.submitBtn);
            this.Name = "SettingChartDataWindow";
            this.Load += new System.EventHandler(this.SettingChartDataForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox seriesCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ComboBox typeDiagramCB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BGColorBtn;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.CheckBox signatureCheck;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox gradientTypeCB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button secondBGColorBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox diagramGradientTypeCB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button diagramSecondBGColorBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button diagramBGColorBtn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox borderStyleCB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox borderTypeCB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button borderColorBtn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox mode3DCheck;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox titleTB;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button seriesColorBtn;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button pointColorBtn;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox pointsCB;
        private System.Windows.Forms.CheckBox pointColorCheck;
    }
}