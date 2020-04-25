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
        public ExcelQuestion Question { get; set; }
        public Dictionary<string, int> Points { get; set; }
        public int RespondedCount { get; set; }
        public int QuestionedCount { get; set; }

        public QuestionInfoForm()
        {
            InitializeComponent();
        }

        private void QuestionInfoForm_Load(object sender, EventArgs e)
        {
            infoDG.AllowUserToAddRows = false;
            infoDG.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            infoDG.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;

            questionLbl.Text = Question.GetForSeries();

            infoDG.Columns.Add(CommonService.CreateTextColumn("Вариант ответа", "answer", true));
            infoDG.Columns.Add(CommonService.CreateTextColumn("Количество", "count"));
            infoDG.Columns.Add(CommonService.CreateTextColumn("Число ответивших", "respondedCount"));
            infoDG.Columns.Add(CommonService.CreateTextColumn("Число принявших участие", "questionedCount"));

            foreach (var pointItem in Points)
            {
                infoDG.Rows.Add(pointItem.Key, pointItem.Value, RespondedCount, QuestionedCount);
            }
        }
    }
}
