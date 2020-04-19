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
        private ExcelQuestion selectedQuestion;
        private ExcelProfile selectedProfile;
        private ExcelDocument selectedDocument;
        private SeriesChartType diagramType;
        private string allItem = string.Empty;

        public VisualisationForm(ExcelQuestion selectedQuestion, ExcelProfile selectedProfile, ExcelDocument selectedDocument, SeriesChartType diagramType)
        {
            InitializeComponent();
            this.selectedDocument = selectedDocument;
            this.selectedProfile = selectedProfile;
            this.selectedQuestion = selectedQuestion;
            this.diagramType = diagramType;
        }

        private void VisualisationForm_Load(object sender, EventArgs e)
        {
            int colorIndex = 0;
            showGridBtn.Checked = visualChart.ChartAreas[0].AxisX.MajorGrid.Enabled;
            showAxisXBtn.Checked = true;
            showAxisYBtn.Checked = true;
            allItemBtn.Checked = true;

            var visualData = VisualisationService.GetVisualData(new List<ExcelQuestion>() { selectedQuestion }, selectedProfile, selectedDocument);

            string question = visualData.Keys.ToList()[0];
            Dictionary<string, int> points = visualData[question];
            int allQuestioned = selectedDocument.AnswerListContent.Where(a => a.ProfileNum == selectedProfile.Id && a.QuestionNum == selectedQuestion.Id && a.Answer != "").Count();

            visualChart.Series.Add(question);
            visualChart.Series[question].ChartType = diagramType;
            Title mainTitle = new Title();
            mainTitle.Name = "mainTitle";
            mainTitle.Text = question;
            visualChart.Titles.Add(mainTitle);
            Title allTitle = new Title();
            allTitle.Name = "allTitle";
            allItem = "Всего " + allQuestioned + " участников";
            allTitle.Text = allItem;
            visualChart.Titles.Add(allTitle);

            visualChart.Series[question].Color = Form1.CompanyColor.Values.ToList()[colorIndex];

            foreach (var item in points)
            {
                visualChart.Series[question].Points.AddXY(item.Key, item.Value);
            }

            if (visualChart.Series[question].ChartType == SeriesChartType.Pie || visualChart.Series[question].ChartType == SeriesChartType.Doughnut)
            {
                colorIndex = 0;
                foreach (var item in visualChart.Series[question].Points)
                {
                    item.Color = Form1.CompanyColor.Values.ToList()[colorIndex];
                    colorIndex++;
                }
            }
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
            if (visualChart.Titles.Select(t => t.Name).Contains("mainTitle"))
            {
                title = visualChart.Titles["mainTitle"].Text;
            }
            TextDialog textDialog = new TextDialog("Введите желаемый заголовок:", title);
            textDialog.ShowDialog();
            if (textDialog.DialogResult == DialogResult.OK)
            {
                if (visualChart.Titles.Select(t => t.Name).Contains("mainTitle"))
                {
                    if (string.IsNullOrEmpty(textDialog.Result))
                    {
                        visualChart.Titles.Remove(visualChart.Titles["mainTitle"]);
                    }
                    else
                    {
                        visualChart.Titles["mainTitle"].Text = textDialog.Result;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(textDialog.Result))
                    {
                        Title mainTitle = new Title();
                        mainTitle.Name = "mainTitle";
                        mainTitle.Text = textDialog.Result;
                        visualChart.Titles.Add(mainTitle);

                        if (visualChart.Titles.Select(t => t.Name).Contains("allTitle"))
                        {
                            visualChart.Titles.Remove(visualChart.Titles["allTitle"]);
                            Title allTitle = new Title();
                            allTitle.Name = "allTitle";
                            allTitle.Text = allItem;
                            visualChart.Titles.Add(allTitle);
                        }
                    }
                }
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
                    fd.Font = visualChart.Titles["mainTitle"].Font;
                    fd.Color = visualChart.Titles["mainTitle"].ForeColor;
                    if (fd.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    else
                    {
                        visualChart.Titles["mainTitle"].Font = fd.Font;
                        visualChart.Titles["mainTitle"].ForeColor = fd.Color;
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

        private void allItemBtn_Click(object sender, EventArgs e)
        {
            if (allItemBtn.Checked)
            {
                allItemBtn.Checked = false;
                if (visualChart.Titles.Select(t => t.Name).Contains("allTitle"))
                {
                    visualChart.Titles.Remove(visualChart.Titles["allTitle"]);
                }
            }
            else
            {
                allItemBtn.Checked = true;
                if (!visualChart.Titles.Select(t => t.Name).Contains("allTitle"))
                {
                    Title mainTitle = new Title();
                    mainTitle.Name = "allTitle";
                    mainTitle.Text = allItem;
                    visualChart.Titles.Add(mainTitle);
                }
            }
        }
    }
}