using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualisationData.Excel;
using VisualisationData.Services;

namespace VisualisationData.VisualSettingForms
{
    public partial class QuestionInfoForm : Form
    {
        public Dictionary<ExcelQuestion, Tuple<Dictionary<string, int>, int, int>> QuestionInfoMap { get; set; }

        public QuestionInfoForm()
        {
            InitializeComponent();
        }

        private void QuestionInfoForm_Load(object sender, EventArgs e)
        {
            int num = 1;
            foreach (var mapItem in QuestionInfoMap)
            {
                TabPage tab = new TabPage();
                tab.Text = "Вопрос " + num;

                TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
                tableLayoutPanel.Dock = DockStyle.Fill;
                tableLayoutPanel.RowCount++;
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 80));
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                Label label = new Label();
                label.AutoSize = false;
                label.Dock = DockStyle.Fill;

                DataGridView infoDG = new DataGridView();
                infoDG.Dock = DockStyle.Fill;
                infoDG.AllowUserToAddRows = false;
                infoDG.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                infoDG.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;

                infoDG.Columns.Add(CommonService.CreateTextColumn("Вариант ответа", "answer", true));
                infoDG.Columns.Add(CommonService.CreateTextColumn("Количество", "count"));
                infoDG.Columns.Add(CommonService.CreateTextColumn("Число ответивших", "respondedCount"));
                infoDG.Columns.Add(CommonService.CreateTextColumn("Число принявших участие", "questionedCount"));

                tableLayoutPanel.Controls.Add(label, 0, 0);
                tableLayoutPanel.Controls.Add(infoDG, 0, 1);
                tab.Controls.Add(tableLayoutPanel);

                mainTC.TabPages.Add(tab);
                num++;

                label.Text = mapItem.Key.GetForSeries();

                var points = mapItem.Value.Item1;
                var respondedCount = mapItem.Value.Item2;
                var questionedCount = mapItem.Value.Item3;
                foreach (var pointItem in points)
                {
                    infoDG.Rows.Add(pointItem.Key, pointItem.Value, respondedCount, questionedCount);
                }
            }
        }
    }
}
