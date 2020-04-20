namespace VisualisationData.VisualSettingForms
{
    partial class DataSettingForm
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
            this.closeBtn = new System.Windows.Forms.Button();
            this.acceptBtn = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.firstGB = new System.Windows.Forms.GroupBox();
            this.tableL1 = new System.Windows.Forms.TableLayoutPanel();
            this.firstLbl = new System.Windows.Forms.Label();
            this.firstCB = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.colorBtn = new System.Windows.Forms.Button();
            this.secondLbl = new System.Windows.Forms.Label();
            this.firstGB.SuspendLayout();
            this.tableL1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.closeBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeBtn.Location = new System.Drawing.Point(8, 123);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(81, 23);
            this.closeBtn.TabIndex = 18;
            this.closeBtn.Text = "Закрыть";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // acceptBtn
            // 
            this.acceptBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.acceptBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.acceptBtn.Location = new System.Drawing.Point(645, 123);
            this.acceptBtn.Name = "acceptBtn";
            this.acceptBtn.Size = new System.Drawing.Size(81, 23);
            this.acceptBtn.TabIndex = 19;
            this.acceptBtn.Text = "Принять";
            this.acceptBtn.UseVisualStyleBackColor = true;
            this.acceptBtn.Click += new System.EventHandler(this.acceptBtn_Click);
            // 
            // firstGB
            // 
            this.firstGB.Controls.Add(this.tableL1);
            this.firstGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.firstGB.Location = new System.Drawing.Point(5, 5);
            this.firstGB.Name = "firstGB";
            this.firstGB.Size = new System.Drawing.Size(724, 111);
            this.firstGB.TabIndex = 19;
            this.firstGB.TabStop = false;
            this.firstGB.Text = "Настройка фона";
            // 
            // tableL1
            // 
            this.tableL1.ColumnCount = 1;
            this.tableL1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 718F));
            this.tableL1.Controls.Add(this.firstLbl, 0, 0);
            this.tableL1.Controls.Add(this.firstCB, 0, 1);
            this.tableL1.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.tableL1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableL1.Location = new System.Drawing.Point(3, 16);
            this.tableL1.Name = "tableL1";
            this.tableL1.RowCount = 3;
            this.tableL1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableL1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableL1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableL1.Size = new System.Drawing.Size(718, 92);
            this.tableL1.TabIndex = 0;
            // 
            // firstLbl
            // 
            this.firstLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.firstLbl.AutoSize = true;
            this.firstLbl.Location = new System.Drawing.Point(3, 8);
            this.firstLbl.Name = "firstLbl";
            this.firstLbl.Size = new System.Drawing.Size(35, 13);
            this.firstLbl.TabIndex = 1;
            this.firstLbl.Text = "label1";
            // 
            // firstCB
            // 
            this.firstCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.firstCB.FormattingEnabled = true;
            this.firstCB.Location = new System.Drawing.Point(3, 33);
            this.firstCB.Name = "firstCB";
            this.firstCB.Size = new System.Drawing.Size(712, 21);
            this.firstCB.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.colorBtn, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.secondLbl, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 63);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(712, 26);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // colorBtn
            // 
            this.colorBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorBtn.Location = new System.Drawing.Point(3, 3);
            this.colorBtn.Name = "colorBtn";
            this.colorBtn.Size = new System.Drawing.Size(24, 20);
            this.colorBtn.TabIndex = 0;
            this.colorBtn.UseVisualStyleBackColor = true;
            this.colorBtn.Click += new System.EventHandler(this.colorBtn_Click);
            // 
            // secondLbl
            // 
            this.secondLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.secondLbl.AutoSize = true;
            this.secondLbl.Location = new System.Drawing.Point(33, 6);
            this.secondLbl.Name = "secondLbl";
            this.secondLbl.Size = new System.Drawing.Size(35, 13);
            this.secondLbl.TabIndex = 1;
            this.secondLbl.Text = "label1";
            // 
            // DataSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 154);
            this.Controls.Add(this.firstGB);
            this.Controls.Add(this.acceptBtn);
            this.Controls.Add(this.closeBtn);
            this.Name = "DataSettingForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Настройка данных";
            this.Load += new System.EventHandler(this.DataSettingForm_Load);
            this.firstGB.ResumeLayout(false);
            this.tableL1.ResumeLayout(false);
            this.tableL1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button acceptBtn;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.GroupBox firstGB;
        private System.Windows.Forms.TableLayoutPanel tableL1;
        private System.Windows.Forms.Label firstLbl;
        private System.Windows.Forms.ComboBox firstCB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button colorBtn;
        private System.Windows.Forms.Label secondLbl;
    }
}