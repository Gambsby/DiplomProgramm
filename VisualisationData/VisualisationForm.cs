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
using VisualisationData.SettingsForm;

namespace VisualisationData
{
    public partial class VisualisationForm : Form
    {
        private List<ExcelQuestion> selectedQuestions;
        private ExcelProfile selectedProfile;
        private ExcelDocument selectedDocument;
        private SeriesChartType diagramType;

        public VisualisationForm(List<ExcelQuestion> selectedQuestions, ExcelProfile selectedProfile, ExcelDocument selectedDocument, SeriesChartType diagramType)
        {
            InitializeComponent();
            this.selectedDocument = selectedDocument;
            this.selectedProfile = selectedProfile;
            this.selectedQuestions = selectedQuestions;
            this.diagramType = diagramType;
        }

        private void VisualisationForm_Load(object sender, EventArgs e)
        {
            foreach (var selectedQuestionItem in selectedQuestions)
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

        private void BGSettingBtn_Click(object sender, EventArgs e)
        {
            AppearanceSettingForm appearanceSettingForm = new AppearanceSettingForm(visualChart, "Настройка фона", "background");
            appearanceSettingForm.Show();
        }

        private void diagramBGSettingRtn_Click(object sender, EventArgs e)
        {
            AppearanceSettingForm appearanceSettingForm = new AppearanceSettingForm(visualChart, "Настройка фона", "diagram");
            appearanceSettingForm.Show();
        }

        private void borderSettingBtn_Click(object sender, EventArgs e)
        {
            AppearanceSettingForm appearanceSettingForm = new AppearanceSettingForm(visualChart, "Настройка рамки", "border");
            appearanceSettingForm.Show();
        }

        private void signatureSettingBtn_Click(object sender, EventArgs e)
        {
            if (signatureSettingBtn.Checked)
            {
                signatureSettingBtn.Checked = false;
            }
            else
            {
                signatureSettingBtn.Checked = true;
            }
            foreach (var seriesItem in visualChart.Series)
            {
                seriesItem.IsValueShownAsLabel = signatureSettingBtn.Checked;
            }
        }

        private void mode3DSettingBtn_Click(object sender, EventArgs e)
        {
            if (mode3DSettingBtn.Checked)
            {
                mode3DSettingBtn.Checked = false;
            }
            else
            {
                mode3DSettingBtn.Checked = true;
            }
            visualChart.ChartAreas[0].Area3DStyle.Enable3D = mode3DSettingBtn.Checked;
        }

        private void diagramTypeSettingBtn_Click(object sender, EventArgs e)
        {
            DataSettingForm dataSettingForm = new DataSettingForm(visualChart, "Настройка типа диаграммы", "diagramType");
            dataSettingForm.Show();
        }

        private void titleSettingBtn_Click(object sender, EventArgs e)
        {
            string title = string.Empty;
            if (visualChart.Titles.Count > 0)
            {
                title = visualChart.Titles[0].Text;
            }
            TextDialog textDialog = new TextDialog("Введите желаемый заголовок:", title);
            textDialog.ShowDialog();
            if (textDialog.DialogResult == DialogResult.OK)
            {
                visualChart.Titles.Clear();
                visualChart.Titles.Add(textDialog.Result);
            }
            
        }

        private void seriesSettingBtn_Click(object sender, EventArgs e)
        {
            DataSettingForm dataSettingForm = new DataSettingForm(visualChart, "Настройка цвета серии данных", "seriesColor");
            dataSettingForm.Show();
        }

        private void pointsSettingBtn_Click(object sender, EventArgs e)
        {
            DataSettingForm dataSettingForm = new DataSettingForm(visualChart, "Настройка цвета элементов серии", "pointColor");
            dataSettingForm.Show();
        }

        private void savaDiagramBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Сохранить изображение как ...";
                sfd.Filter = "*.bmp|*.bmp;|*.png|*.png;|*.jpg|*.jpg";
                sfd.AddExtension = true;
                sfd.FileName = "graphicImage";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    switch (sfd.FilterIndex)
                    {
                        case 1: visualChart.SaveImage(sfd.FileName,ChartImageFormat.Bmp); break;
                        case 2: visualChart.SaveImage(sfd.FileName, ChartImageFormat.Png); break;
                        case 3: visualChart.SaveImage(sfd.FileName, ChartImageFormat.Jpeg); break;
                    }
                }
            }
        }
    }
}
