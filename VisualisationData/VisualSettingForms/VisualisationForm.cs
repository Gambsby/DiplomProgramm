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
        public static Dictionary<string, SeriesChartType> seriesTypeMap = new Dictionary<string, SeriesChartType>
        {
            { "Pie", SeriesChartType.Pie },
            { "Doughnut", SeriesChartType.Doughnut },
            { "Bar", SeriesChartType.Bar },
            { "StackedBar", SeriesChartType.StackedBar },
            { "StackedBar100", SeriesChartType.StackedBar100 },
            { "Column", SeriesChartType.Column },
            { "StackedColumn", SeriesChartType.StackedColumn },
            { "StackedColumn100", SeriesChartType.StackedColumn100 },

        };

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
            showLegendBtn.Checked = true;
            showLegendMenuBtn.Checked = true;

            visualChart.MouseClick += VisualChart_MouseClick;

            var questionInfo = ProccesingDataService.GetQuestionInfo(selectedQuestion, selectedProfile, selectedDocument);
            string question = selectedQuestion.GetForSeries();
            Dictionary<string, int> points = questionInfo.Item1;
            int respondedCount = questionInfo.Item2;

            visualChart.Series.Add(question);
            visualChart.Series[question].ChartType = diagramType;

            visualChart.Titles.Add(CommonService.CreateTitle("mainTitle", question));
            allItem = "Всего " + respondedCount + " ответивших участников";
            visualChart.Titles.Add(CommonService.CreateTitle("allTitle", allItem));

            visualChart.Series[question].Color = Form1.CompanyColor.Values.ToList()[0];

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

            Legend legend = CommonService.CreateLegend(visualChart.Series[question], "mainLegend");
            
            visualChart.Series[question].IsVisibleInLegend = false;
            visualChart.Legends.Add(legend);
        }

        private void BGSettingBtn_Click(object sender, EventArgs e)
        {
            using (AppearanceSettingForm asf = new AppearanceSettingForm())
            {
                asf.NameGroupBox = "Настройка фона";
                asf.TypeSettings = "background";
                asf.VisualChart = visualChart;
                asf.ShowDialog();
                if (asf.Status)
                {
                    visualChart.BackColor = asf.FirstColor;
                    visualChart.BackSecondaryColor = asf.SecondColor;
                    visualChart.BackGradientStyle = asf.GradientStyle;
                }
            }
        }

        private void diagramBGSettingRtn_Click(object sender, EventArgs e)
        {
            using (AppearanceSettingForm asf = new AppearanceSettingForm())
            {
                asf.NameGroupBox = "Настройка фона";
                asf.TypeSettings = "diagram";
                asf.VisualChart = visualChart;
                asf.ShowDialog();
                if (asf.Status)
                {
                    visualChart.ChartAreas[0].BackColor = asf.FirstColor;
                    visualChart.ChartAreas[0].BackSecondaryColor = asf.SecondColor;
                    visualChart.ChartAreas[0].BackGradientStyle = asf.GradientStyle;
                }
            }
        }

        private void borderSettingBtn_Click(object sender, EventArgs e)
        {
            using (AppearanceSettingForm asf = new AppearanceSettingForm())
            {
                asf.NameGroupBox = "Настройка рамки";
                asf.TypeSettings = "border";
                asf.VisualChart = visualChart;
                asf.ShowDialog();
                if (asf.Status)
                {
                    visualChart.BorderlineColor = asf.FirstColor;
                    visualChart.BorderlineDashStyle = asf.ChartDashStyle;
                    visualChart.BorderSkin.SkinStyle = asf.BorderSkinStyle;
                }
            }
        }

        private void legendsBGSettingBtn_Click(object sender, EventArgs e)
        {
            using (AppearanceSettingForm asf = new AppearanceSettingForm())
            {
                asf.NameGroupBox = "Настройка фона легенды";
                asf.TypeSettings = "diagram";
                asf.VisualChart = visualChart;
                asf.ShowDialog();
                if (asf.Status)
                {
                    if (visualChart.Legends.Select(x => x.Name).Contains("mainLegend"))
                    {
                        visualChart.Legends["mainLegend"].BackColor = asf.FirstColor;
                        visualChart.Legends["mainLegend"].BackSecondaryColor = asf.SecondColor;
                        visualChart.Legends["mainLegend"].BackGradientStyle = asf.GradientStyle;
                    }
                }
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
            using (DataSettingForm dsf = new DataSettingForm())
            {
                dsf.NameGroupBox = "Настройка типа диаграммы";
                dsf.TypeSettings = "diagramType";
                dsf.SeriesItem = visualChart.Series[selectedQuestion.GetForSeries()];
                dsf.ShowDialog();
                if (dsf.Status)
                {
                    string selectedType = dsf.SelectedItem as string;
                    visualChart.Series[selectedQuestion.GetForSeries()].ChartType = seriesTypeMap[selectedType];
                }
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
            Color oldColor = visualChart.Series[selectedQuestion.GetForSeries()].Color;
            Color selectedColor = CommonService.ChooseColor(colorDialog, oldColor);
            if (selectedColor != oldColor)
            {
                foreach (var dataPointItem in visualChart.Series[selectedQuestion.GetForSeries()].Points)
                {
                    dataPointItem.Color = selectedColor;
                }
                RefreshLegend();
            }
        }

        private void pointsSettingBtn_Click(object sender, EventArgs e)
        {
            using (DataSettingForm dsf = new DataSettingForm())
            {
                dsf.NameGroupBox = "Настройка цвета точек";
                dsf.TypeSettings = "color";
                dsf.SeriesItem = visualChart.Series[selectedQuestion.GetForSeries()];
                dsf.ShowDialog();
                if (dsf.Status)
                {
                    string selectedPointName = dsf.SelectedItem as string;
                    Color selectedColor = dsf.Color;

                    DataPoint selectedPoint = visualChart.Series[selectedQuestion.GetForSeries()].Points.SingleOrDefault(x => x.AxisLabel == selectedPointName);

                    selectedPoint.Color = selectedColor;
                    RefreshLegend();
                }
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
                    visualChart.Series[0].Font = fd.Font;
                    visualChart.Series[0].LabelForeColor = fd.Color;
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

        private void VisualChart_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var res = visualChart.HitTest(e.X, e.Y);
                switch (res.ChartElementType)
                {
                    case ChartElementType.Title:
                        {
                            Title title = res.Object as Title;
                            if (title.Name == "mainTitle")
                            {
                                changeTtileBtn.Enabled = true;
                            }
                            else
                            {
                                changeTtileBtn.Enabled = false;
                            }
                            changeTtileBtn.Tag = title;
                            deleteTitleBtn.Tag = title;
                            fontTitleBtn.Tag = title;
                            titleMenu.Show(Control.MousePosition);
                            break;
                        }
                    case ChartElementType.DataPoint:
                        {
                            seriesColorBtn.Tag = res.Series;
                            pointColorBtn.Tag = res.Series.Points[res.PointIndex];
                            markFontBtn.Tag = res.Series;
                            seriesMenu.Show(Control.MousePosition);

                            break;
                        }
                    case ChartElementType.DataPointLabel:
                        {

                            break;
                        }
                    case ChartElementType.LegendItem:
                        {
                            Legend legend = (res.Object as LegendItem).Legend;
                            changeLegendFontBtn.Tag = legend;
                            showLegendMenuBtn.Tag = legend;
                            legendMenu.Show(Control.MousePosition);

                            break;
                        }
                    default:
                        break;
                }
            }
        }

        private void seriesColorBtn_Click(object sender, EventArgs e)
        {
            Series series = seriesColorBtn.Tag as Series;
            Color oldColor = series.Color;
            Color selectedColor = CommonService.ChooseColor(colorDialog, oldColor);
            if (selectedColor != oldColor)
            {
                foreach (var dataPointItem in series.Points)
                {
                    dataPointItem.Color = selectedColor;
                }
                RefreshLegend();
            }
        }

        private void pointColorBtn_Click(object sender, EventArgs e)
        {
            DataPoint point = pointColorBtn.Tag as DataPoint;
            point.Color = CommonService.ChooseColor(colorDialog, point.Color);
            RefreshLegend();
        }

        private void markFontBtn_Click(object sender, EventArgs e)
        {
            Series series = markFontBtn.Tag as Series;
            using (FontDialog fd = new FontDialog())
            {
                fd.ShowColor = true;
                fd.Font = series.Font;
                fd.Color = series.LabelForeColor;
                if (fd.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    series.Font = fd.Font;
                    series.LabelForeColor = fd.Color;
                }
            }
        }

        private void changeTtileBtn_Click(object sender, EventArgs e)
        {
            Title title = changeTtileBtn.Tag as Title;

            using (TextDialog textDialog = new TextDialog("Введите желаемый заголовок:", title.Text))
            {
                textDialog.ShowDialog();
                if (textDialog.DialogResult == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(textDialog.Result))
                    {
                        title.Text = textDialog.Result;
                    }
                }
            }
        }

        private void deleteTitleBtn_Click(object sender, EventArgs e)
        {
            Title title = deleteTitleBtn.Tag as Title;

            if (title.Name == "allTitle")
            {
                allItemBtn.Checked = false;
            }
            visualChart.Titles.Remove(title);
        }

        private void fontTitleBtn_Click(object sender, EventArgs e)
        {
            Title title = fontTitleBtn.Tag as Title;

            using (FontDialog fd = new FontDialog())
            {
                fd.ShowColor = true;
                fd.Font = title.Font;
                fd.Color = title.ForeColor;
                if (fd.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    title.Font = fd.Font;
                    title.ForeColor = fd.Color;
                }
            }
        }

        private void showLegend_Click(object sender, EventArgs e)
        {
            if (showLegendBtn.Checked)
            {
                showLegendBtn.Checked = false;
                showLegendMenuBtn.Checked = false;

                visualChart.Legends.Remove(visualChart.Legends["mainLegend"]);
            }
            else
            {
                showLegendBtn.Checked = true;
                showLegendMenuBtn.Checked = true;

                Legend legend = CommonService.CreateLegend(visualChart.Series[selectedQuestion.GetForSeries()], "mainLegend");
                visualChart.Series[selectedQuestion.GetForSeries()].IsVisibleInLegend = false;
                visualChart.Legends.Add(legend);
            }
        }

        private void changeLegendFontBtn_Click(object sender, EventArgs e)
        {
            Legend legend = changeLegendFontBtn.Tag as Legend;

            using (FontDialog fd = new FontDialog())
            {
                fd.ShowColor = true;
                fd.Font = legend.Font;
                fd.Color = legend.ForeColor;
                if (fd.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    legend.Font = fd.Font;
                    legend.ForeColor = fd.Color;
                }
            }
        }

        private void RefreshLegend()
        {
            if (visualChart.Legends.Select(x => x.Name).Contains("mainLegend"))
            {
                for (int i = 0; i < visualChart.Series[selectedQuestion.GetForSeries()].Points.Count; i++)
                {
                    LegendItem currentLegendItem = visualChart.Legends["mainLegend"].CustomItems.SingleOrDefault(x => x.SeriesPointIndex == i);
                    currentLegendItem.Color = visualChart.Series[selectedQuestion.GetForSeries()].Points[i].Color;
                }
            }
        }
    }
}