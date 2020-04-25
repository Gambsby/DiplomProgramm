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
        private Title allTitle;
        private Legend legend;
        private Title mainTitle;
        private Dictionary<string, int> points;
        private int responded;

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
            var questionInfo = ProccesingDataService.GetQuestionInfo(selectedQuestion, selectedProfile, selectedDocument);
            points = questionInfo.Item1;
            responded = questionInfo.Item2;

            visualChart = ProccesingDataService.CreateDefaultChart(visualChart, questionInfo, selectedQuestion, diagramType);
            visualChart = ProccesingDataService.SettingDefaultChart(visualChart, selectedQuestion);
            allTitle = visualChart.Titles["allTitle"];
            legend = visualChart.Legends["mainLegend"];
            mainTitle = visualChart.Titles["mainTitle"];

            showGridBtn.Checked = (visualChart.ChartAreas[0].AxisX.MajorGrid.Enabled && visualChart.ChartAreas[0].AxisY.MajorGrid.Enabled);
            if (visualChart.ChartAreas[0].AxisX.Enabled == AxisEnabled.False)
            {
                showAxisXBtn.Checked = false;
            }
            else
            {
                showAxisXBtn.Checked = true;
            }
            if (visualChart.ChartAreas[0].AxisY.Enabled == AxisEnabled.False)
            {
                showAxisYBtn.Checked = false;
            }
            else
            {
                showAxisYBtn.Checked = true;
            }
            mode3DSettingBtn.Checked = visualChart.ChartAreas[0].Area3DStyle.Enable3D;
            showLegendBtn.Checked = visualChart.Legends.Select(x => x.Name).Contains("mainLegend");
            allItemBtn.Checked = visualChart.Titles.Select(x => x.Name).Contains("allTitle");
            showTitleMBtn.Checked = visualChart.Titles.Select(x => x.Name).Contains("mainTitle");
            if (visualChart.Series[selectedQuestion.GetForSeries()].Label == "#PERCENT")
            {
                percentMarkerBtn.Checked = true;
            }
            else if (visualChart.Series[selectedQuestion.GetForSeries()].Label == "#VAL")
            {
                valuesMarkerBtn.Checked = true;
            }
            else
            {
                noneMarkerBtn.Checked = true;
            }
            legendColValBtn.Checked = true;

            if (points.ContainsKey("другое"))
            {
                showOpenAnswersBtn.Visible = true;
            }

            visualChart.MouseClick += VisualChart_MouseClick;
        }

        private void BGSettingBtn_Click(object sender, EventArgs e)//+
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

        private void diagramBGSettingRtn_Click(object sender, EventArgs e)//+
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

        private void borderSettingBtn_Click(object sender, EventArgs e)//+
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

        private void showGridBtn_Click(object sender, EventArgs e)//+
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

        private void showAxisXBtn_Click(object sender, EventArgs e)//+
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

        private void showAxisYBtn_Click(object sender, EventArgs e)//+
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

        private void mode3DSettingBtn_Click(object sender, EventArgs e)//+
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

        //---------------------------------------------------------------------

        private void showLegendBtn_Click(object sender, EventArgs e)//+
        {
            if (showLegendBtn.Checked)
            {
                showLegendBtn.Checked = false;
                showLegendMenuBtn.Checked = false;

                visualChart.Legends.Remove(legend);
            }
            else
            {
                showLegendBtn.Checked = true;
                showLegendMenuBtn.Checked = true;

                visualChart.Legends.Add(legend);
            }
        }

        private void legendsBGSettingBtn_Click(object sender, EventArgs e)//+
        {
            using (AppearanceSettingForm asf = new AppearanceSettingForm())
            {
                asf.NameGroupBox = "Настройка фона легенды";
                asf.TypeSettings = "legend";
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

        private void legendFontBtn_Click(object sender, EventArgs e)//+
        {
            if (visualChart.Legends.Select(x => x.Name).Contains("mainLegend"))
            {
                Legend legend = visualChart.Legends["mainLegend"];

                LegendFont(legend);
            }
        }

        private void legendColPerBtn_Click(object sender, EventArgs e)//+
        {
            if (visualChart.Legends.Select(x => x.Name).Contains("mainLegend"))
            {
                foreach (ToolStripMenuItem item in legendValBtn.DropDownItems)
                {
                    item.Checked = false;
                }
                legendColPerBtn.Checked = true;

                Legend legend = visualChart.Legends["mainLegend"];

                foreach (var legendItem in legend.CustomItems)
                {
                    double a = points[legendItem.Cells[1].Text];
                    legendItem.Cells[2].Text = Math.Round((a / responded),3) * 100 + "%";
                }
            }
        }

        private void legendColValBtn_Click(object sender, EventArgs e)//+
        {
            if (visualChart.Legends.Select(x => x.Name).Contains("mainLegend"))
            {
                foreach (ToolStripMenuItem item in legendValBtn.DropDownItems)
                {
                    item.Checked = false;
                }
                legendColValBtn.Checked = true;

                Legend legend = visualChart.Legends["mainLegend"];

                foreach (var legendItem in legend.CustomItems)
                {
                    double a = points[legendItem.Cells[1].Text];
                    legendItem.Cells[2].Text = a.ToString();
                }
            }
        }

        private void legendColNoneBtn_Click(object sender, EventArgs e)//+
        {
            if (visualChart.Legends.Select(x => x.Name).Contains("mainLegend"))
            {
                foreach (ToolStripMenuItem item in legendValBtn.DropDownItems)
                {
                    item.Checked = false;
                }
                legendColNoneBtn.Checked = true;

                Legend legend = visualChart.Legends["mainLegend"];

                foreach (var legendItem in legend.CustomItems)
                {
                    legendItem.Cells[2].Text = "";
                }
            }
        }

        //---------------------------------------------------------------------

        private void showTitleMBtn_Click(object sender, EventArgs e)//+
        {
            if (showTitleMBtn.Checked)
            {
                showTitleMBtn.Checked = false;

                visualChart.Titles.Remove(mainTitle);
            }
            else
            {
                showTitleMBtn.Checked = true;

                visualChart.Titles.Add(mainTitle);
            }
        }

        private void titleFontBtn_Click(object sender, EventArgs e)//+
        {
            if (visualChart.Titles.Select(x => x.Name).Contains("mainTitle"))
            {
                Title title = visualChart.Titles["mainTitle"];

                TitleFont(title);
            }
            else
            {
                MessageBox.Show("Нет заголовка чтобы задать ему шрифт.");
            }
        }

        private void titleSettingBtn_Click(object sender, EventArgs e)//+
        {
            Title title;
            if (visualChart.Titles.Select(t => t.Name).Contains("mainTitle"))
            {
                title = visualChart.Titles["mainTitle"];

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
        }

        private void allItemBtn_Click(object sender, EventArgs e)//+
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

                    visualChart.Titles.Add(allTitle);
                }
            }
        }

        //---------------------------------------------------------------------

        private void diagramTypeSettingBtn_Click(object sender, EventArgs e)//+
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

        private void seriesSettingBtn_Click(object sender, EventArgs e)//+
        {
            Series series = visualChart.Series[selectedQuestion.GetForSeries()];
            
            SeriesColor(series);
        }

        private void pointsSettingBtn_Click(object sender, EventArgs e)//+
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

        private void percentMarkerBtn_Click(object sender, EventArgs e)//+
        {
            foreach (ToolStripMenuItem item in markerTypeBtn.DropDownItems)
            {
                item.Checked = false;
            }
            percentMarkerBtn.Checked = true;
            visualChart.Series[selectedQuestion.GetForSeries()].Label = "#PERCENT";
        }

        private void valuesMarkerBtn_Click(object sender, EventArgs e)//+
        {
            foreach (ToolStripMenuItem item in markerTypeBtn.DropDownItems)
            {
                item.Checked = false;
            }
            valuesMarkerBtn.Checked = true;
            visualChart.Series[selectedQuestion.GetForSeries()].Label = "#VAL";
        }

        private void noneMarkerBtn_Click(object sender, EventArgs e)//+
        {
            foreach (ToolStripMenuItem item in markerTypeBtn.DropDownItems)
            {
                item.Checked = false;
            }

            noneMarkerBtn.Checked = true;

            visualChart.Series[selectedQuestion.GetForSeries()].Label = "";
            visualChart.Series[selectedQuestion.GetForSeries()].IsValueShownAsLabel = false;
        }

        private void markerFontBtn_Click(object sender, EventArgs e)//+
        {
            Series series = visualChart.Series[selectedQuestion.GetForSeries()];

            SeriesFont(series);
        }

        //---------------------------------------------------------------------

        private void savaDiagramBtn_Click(object sender, EventArgs e)//+
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
                                changeTitleBtn.Enabled = true;
                            }
                            else
                            {
                                changeTitleBtn.Enabled = false;
                            }
                            changeTitleBtn.Tag = title;
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
                            selectMarkFontDtn.Tag = res.Series.Points[res.PointIndex];
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

        private void seriesColorBtn_Click(object sender, EventArgs e)//+
        {
            Series series = seriesColorBtn.Tag as Series;

            SeriesColor(series);
        }

        private void pointColorBtn_Click(object sender, EventArgs e)//+
        {
            DataPoint point = pointColorBtn.Tag as DataPoint;
            point.Color = CommonService.ChooseColor(colorDialog, point.Color);
            RefreshLegend();
        }

        private void markFontBtn_Click(object sender, EventArgs e)//+
        {
            Series series = markFontBtn.Tag as Series;

            SeriesFont(series);
        }

        private void changeTtileBtn_Click(object sender, EventArgs e)//+
        {
            Title title = changeTitleBtn.Tag as Title;

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

        private void deleteTitleBtn_Click(object sender, EventArgs e)//+
        {
            Title title = deleteTitleBtn.Tag as Title;

            if (title.Name == "allTitle")
            {
                allItemBtn.Checked = false;
            }
            else if (title.Name == "mainTitle")
            {
                showTitleMBtn.Checked = false;
            }
            visualChart.Titles.Remove(title);
        }

        private void fontTitleBtn_Click(object sender, EventArgs e)//+
        {
            Title title = fontTitleBtn.Tag as Title;

            TitleFont(title);
        }

        private void selectMarkFontDtn_Click(object sender, EventArgs e)//+
        {
            DataPoint point = selectMarkFontDtn.Tag as DataPoint;

            using (FontDialog fd = new FontDialog())
            {
                fd.ShowColor = true;
                fd.Font = point.Font;
                fd.Color = point.LabelForeColor;
                if (fd.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    point.Font = fd.Font;
                    point.LabelForeColor = fd.Color;
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
    
        private void LegendFont(Legend legend)
        {
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
    
        private void TitleFont(Title title)
        {
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
    
        private void SeriesColor(Series series)
        {
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
    
        private void SeriesFont(Series series)
        {
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
                    foreach (var pointItem in series.Points)
                    {
                        pointItem.Font = fd.Font;
                        pointItem.LabelForeColor = fd.Color;
                    }
                }
            }
        }

        private void showOpenAnswersBtn_Click(object sender, EventArgs e)
        {
            var questionInfo = ProccesingDataService.GetOpenInfo(selectedQuestion, selectedProfile, selectedDocument);

            var points = questionInfo.Item1;
            var respondedCount = questionInfo.Item2;
            var questionedCount = questionInfo.Item3;

            using (QuestionInfoForm qif = new QuestionInfoForm())
            {
                qif.Points = points;
                qif.RespondedCount = respondedCount;
                qif.QuestionedCount = questionedCount;
                qif.Question = selectedQuestion;
                qif.ShowDialog();
            }
        }
    }
}