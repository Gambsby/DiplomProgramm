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
using VisualisationData.Services;

namespace VisualisationData.VisualSettingForms
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
            int colorIndex = 0;
            showGridBtn.Checked = visualChart.ChartAreas[0].AxisX.MajorGrid.Enabled;
            showAxisXBtn.Checked = true;
            showAxisYBtn.Checked = true;

            var visualData = VisualisationService.GetVisualData(selectedQuestions, selectedProfile, selectedDocument);
            Dictionary<ExcelQuestion, int> allCountQuestionAnswer = new Dictionary<ExcelQuestion, int>();
            foreach (var questionItem in selectedQuestions)
            {
                var allQuestioned = selectedDocument.AnswerListContent.Where(a => a.ProfileNum == selectedProfile.Id && a.QuestionNum == questionItem.Id && a.Answer != "").Count();
                allCountQuestionAnswer.Add(questionItem, allQuestioned);
            }
            //var allQuestioned = selectedDocument.AnswerListContent.Where(a => a.ProfileNum == selectedProfile.Id && a.QuestionNum == selectedQuestion.Id).ToList();
            foreach (var seriesItem in visualData)
            {
                visualChart.Series.Add(seriesItem.Key);
                visualChart.Series[seriesItem.Key].ChartType = diagramType;
                if (Form1.CompanyColor.Count > colorIndex)
                {
                    visualChart.Series[seriesItem.Key].Color = Form1.CompanyColor.Values.ToList()[colorIndex];
                    colorIndex++;
                }

                foreach (var item in seriesItem.Value)
                {
                    visualChart.Series[seriesItem.Key].Points.AddXY(item.Key, item.Value);
                }

                if (visualChart.Series[seriesItem.Key].ChartType == SeriesChartType.Pie || visualChart.Series[seriesItem.Key].ChartType == SeriesChartType.Doughnut)
                {
                    colorIndex = 0;
                    foreach (var item in visualChart.Series[seriesItem.Key].Points)
                    {
                        item.Color = Form1.CompanyColor.Values.ToList()[colorIndex];
                        colorIndex++;
                    }
                }
            }

            //Legend legend = new Legend();
            //legend.Name = "Legend2";
            //visualChart.Legends.Add(legend);
            //foreach (var item in allCountQuestionAnswer)
            //{
            //    LegendItem legendItem = new LegendItem();
            //    legendItem.Color = visualChart.Series[item.Key.GetForSeries()].Color;
            //    legendItem.Cells[1].Text = "Всего " + item.Value;
            //    visualChart.Legends["Legend2"].CustomItems.Add(legendItem);
            //    //visualChart.Legends["Legend2"].CustomItems.Add(new LegendItem("Всего " + item.Value, color, ))
            //}
        }

        private void BGSettingBtn_Click(object sender, EventArgs e)
        {
            using (AppearanceSettingForm asf = new AppearanceSettingForm(visualChart))
            {
                asf.NameGroupBox = "Настройка фона";
                asf.TypeSettings = "background";
                asf.ShowDialog();
            }
        }

        private void diagramBGSettingRtn_Click(object sender, EventArgs e)
        {
            using (AppearanceSettingForm asf = new AppearanceSettingForm(visualChart))
            {
                asf.NameGroupBox = "Настройка фона";
                asf.TypeSettings = "diagram";
                asf.ShowDialog();
            }
        }

        private void borderSettingBtn_Click(object sender, EventArgs e)
        {
            using (AppearanceSettingForm asf = new AppearanceSettingForm(visualChart))
            {
                asf.NameGroupBox = "Настройка рамки";
                asf.TypeSettings = "border";
                asf.ShowDialog();
            }
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
            using (DataSettingForm dsf = new DataSettingForm(visualChart))
            {
                dsf.NameGroupBox = "Настройка типа диаграммы";
                dsf.TypeSettings = "diagramType";
                dsf.ShowDialog();
            }
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
            using (DataSettingForm dsf = new DataSettingForm(visualChart))
            {
                dsf.NameGroupBox = "Настройка цвета серии данных";
                dsf.TypeSettings = "seriesColor";
                dsf.ShowDialog();
            }
        }

        private void pointsSettingBtn_Click(object sender, EventArgs e)
        {
            using (DataSettingForm dsf = new DataSettingForm(visualChart))
            {
                dsf.NameGroupBox = "Настройка цвета элементов серии";
                dsf.TypeSettings = "pointColor";
                dsf.ShowDialog();
            }
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

        private void showGridBtn_Click(object sender, EventArgs e)
        {
            if (showGridBtn.Checked)
            {
                showGridBtn.Checked = false;
            }
            else
            {
                showGridBtn.Checked = true;
            }
            visualChart.ChartAreas[0].AxisX.MajorGrid.Enabled = showGridBtn.Checked;
            visualChart.ChartAreas[0].AxisY.MajorGrid.Enabled = showGridBtn.Checked;
        }

        private void showAxisXBtn_Click(object sender, EventArgs e)
        {
            if (showAxisXBtn.Checked)
            {
                showAxisXBtn.Checked = false;
                visualChart.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            }
            else
            {
                showAxisXBtn.Checked = true;
                visualChart.ChartAreas[0].AxisX.Enabled = AxisEnabled.True;
            }
        }

        private void showAxisYBtn_Click(object sender, EventArgs e)
        {
            if (showAxisYBtn.Checked)
            {
                showAxisYBtn.Checked = false;
                visualChart.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
            }
            else
            {
                showAxisYBtn.Checked = true;
                visualChart.ChartAreas[0].AxisY.Enabled = AxisEnabled.True;
            }
        }

        private void legendFontBtn_Click(object sender, EventArgs e)
        {
            using (FontDialog fd = new FontDialog())
            {
                fd.ShowColor = true;
                fd.Font = visualChart.Legends[0].Font;
                fd.Color = visualChart.Legends[0].ForeColor;
                if (fd.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    visualChart.Legends[0].Font = fd.Font;
                    visualChart.Legends[0].ForeColor = fd.Color;
                }
            }
        }

        private void titleFontBtn_Click(object sender, EventArgs e)
        {
            if (visualChart.Titles.Count != 0)
            {
                using (FontDialog fd = new FontDialog())
                {
                    fd.ShowColor = true;
                    fd.Font = visualChart.Titles[0].Font;
                    fd.Color = visualChart.Titles[0].ForeColor;
                    if (fd.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    else
                    {
                        visualChart.Titles[0].Font = fd.Font;
                        visualChart.Titles[0].ForeColor = fd.Color;
                    }
                }
            }
            else
            {
                MessageBox.Show("Нет заголовка чтобы задать им шрифт.");
            }
        }

        private void markerFontBtn_Click(object sender, EventArgs e)
        {
            using (FontDialog fd = new FontDialog())
            {
                fd.ShowColor = true;
                fd.Font = visualChart.Series[0].Font;
                fd.Color = visualChart.Series[0].LabelForeColor;
                if (fd.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    foreach (var seriesItem in visualChart.Series)
                    {
                        seriesItem.Font = fd.Font;
                        seriesItem.LabelForeColor = fd.Color;
                    }
                }
            }
        }
    }
}
