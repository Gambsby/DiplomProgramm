namespace VisualisationData.DataSettingForms
{
    partial class SheetsSettigsForm
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
            this.tableL1 = new System.Windows.Forms.TableLayoutPanel();
            this.chooseDG = new System.Windows.Forms.DataGridView();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.acceptBtn = new System.Windows.Forms.Button();
            this.tableL2 = new System.Windows.Forms.TableLayoutPanel();
            this.firstInfoLbl = new System.Windows.Forms.Label();
            this.secondInfoLbl = new System.Windows.Forms.Label();
            this.tableL1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chooseDG)).BeginInit();
            this.tableL2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableL1
            // 
            this.tableL1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableL1.ColumnCount = 1;
            this.tableL1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableL1.Controls.Add(this.chooseDG, 0, 1);
            this.tableL1.Controls.Add(this.tableL2, 0, 0);
            this.tableL1.Location = new System.Drawing.Point(13, 13);
            this.tableL1.Name = "tableL1";
            this.tableL1.RowCount = 2;
            this.tableL1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.86146F));
            this.tableL1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.13854F));
            this.tableL1.Size = new System.Drawing.Size(775, 397);
            this.tableL1.TabIndex = 0;
            // 
            // chooseDG
            // 
            this.chooseDG.AllowUserToAddRows = false;
            this.chooseDG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.chooseDG.Location = new System.Drawing.Point(3, 61);
            this.chooseDG.Name = "chooseDG";
            this.chooseDG.Size = new System.Drawing.Size(769, 333);
            this.chooseDG.TabIndex = 12;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelBtn.Location = new System.Drawing.Point(13, 417);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // acceptBtn
            // 
            this.acceptBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.acceptBtn.Location = new System.Drawing.Point(713, 417);
            this.acceptBtn.Name = "acceptBtn";
            this.acceptBtn.Size = new System.Drawing.Size(75, 23);
            this.acceptBtn.TabIndex = 2;
            this.acceptBtn.Text = "Принять";
            this.acceptBtn.UseVisualStyleBackColor = true;
            this.acceptBtn.Click += new System.EventHandler(this.acceptBtn_Click);
            // 
            // tableL2
            // 
            this.tableL2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableL2.ColumnCount = 2;
            this.tableL2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableL2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableL2.Controls.Add(this.firstInfoLbl, 0, 0);
            this.tableL2.Controls.Add(this.secondInfoLbl, 0, 1);
            this.tableL2.Location = new System.Drawing.Point(3, 3);
            this.tableL2.Name = "tableL2";
            this.tableL2.RowCount = 2;
            this.tableL2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableL2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableL2.Size = new System.Drawing.Size(769, 52);
            this.tableL2.TabIndex = 13;
            // 
            // firstInfoLbl
            // 
            this.firstInfoLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.firstInfoLbl.AutoSize = true;
            this.firstInfoLbl.Location = new System.Drawing.Point(346, 6);
            this.firstInfoLbl.Name = "firstInfoLbl";
            this.firstInfoLbl.Size = new System.Drawing.Size(35, 13);
            this.firstInfoLbl.TabIndex = 0;
            this.firstInfoLbl.Text = "label1";
            // 
            // secondInfoLbl
            // 
            this.secondInfoLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.secondInfoLbl.AutoSize = true;
            this.secondInfoLbl.Location = new System.Drawing.Point(346, 32);
            this.secondInfoLbl.Name = "secondInfoLbl";
            this.secondInfoLbl.Size = new System.Drawing.Size(35, 13);
            this.secondInfoLbl.TabIndex = 1;
            this.secondInfoLbl.Text = "label2";
            // 
            // SheetsSettigsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.acceptBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.tableL1);
            this.Name = "SheetsSettigsForm";
            this.Text = "SheetsSettigsForm";
            this.Load += new System.EventHandler(this.SheetsSettigsForm_Load);
            this.tableL1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chooseDG)).EndInit();
            this.tableL2.ResumeLayout(false);
            this.tableL2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableL1;
        private System.Windows.Forms.DataGridView chooseDG;
        private System.Windows.Forms.TableLayoutPanel tableL2;
        private System.Windows.Forms.Label firstInfoLbl;
        private System.Windows.Forms.Label secondInfoLbl;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button acceptBtn;
    }
}