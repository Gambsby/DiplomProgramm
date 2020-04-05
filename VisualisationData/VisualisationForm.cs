using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using VisualisationData.Excel;

namespace VisualisationData
{
    public partial class VisualisationForm : Form
    {
        private List<ExcelQuestion> selectedQuestion;
        private ExcelProfile selectedProfile;
        private ExcelDocument selectedDocument;
        private SeriesChartType diagramType;

        public VisualisationForm(List<ExcelQuestion> selectedQuestion, ExcelProfile selectedProfile, ExcelDocument selectedDocument, SeriesChartType diagramType)
        {
            InitializeComponent();
            this.selectedDocument = selectedDocument;
            this.selectedProfile = selectedProfile;
            this.selectedQuestion = selectedQuestion;
            this.diagramType = diagramType;
        }

        private void VisualisationForm_Load(object sender, EventArgs e)
        {
            foreach (var selectedQuestionItem in selectedQuestion)
            {
                visualChart.Series.Add(selectedQuestionItem.Content);
                visualChart.Series[selectedQuestionItem.Content].ChartType = diagramType;

                foreach (var answerItem in selectedProfile.Answers)
                {
                    var countCurrentAnswers = selectedDocument.AnswerListContent.Where(a => a.ProfileNum == selectedProfile.Id && a.QuestionNum == selectedQuestionItem.Id && a.Answer == answerItem).Count();
                    visualChart.Series[selectedQuestionItem.Content].Points.AddXY(answerItem, countCurrentAnswers);

                    //visualChart.Series[answerItem]["PointWidth"] = "0.1";
                }
            }
        }

        private void settingDiagramBtn_Click(object sender, EventArgs e)
        {
            SettingChartDataWindow settingChartDataForm = new SettingChartDataWindow(visualChart);
            settingChartDataForm.Show();
        }
    }
}
