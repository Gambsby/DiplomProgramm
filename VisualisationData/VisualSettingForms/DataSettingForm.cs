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
using VisualisationData.Services;

namespace VisualisationData.VisualSettingForms
{
    public partial class DataSettingForm : Form
    {
        private Dictionary<string, SeriesChartType> seriesTypeMap = new Dictionary<string, SeriesChartType>
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

        private string nameGroupBox;
        private string typeSettings;
        private Chart visualChart;

        public DataSettingForm(Chart visualChart, string nameGroupBox, string typeSettings)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.nameGroupBox = nameGroupBox;
            this.typeSettings = typeSettings;
            this.visualChart = visualChart;
        }

        private void acceptBtn_Click(object sender, EventArgs e)
        {
            switch (typeSettings)
            {
                case "diagramType":
                    {
                        var selectedChartType = seriesTypeMap[firstCB.SelectedItem.ToString()];
                        if (selectedChartType == SeriesChartType.Pie || selectedChartType == SeriesChartType.Doughnut)
                        {
                            var temp = visualChart.Series[0];
                            temp.ChartType = selectedChartType;
                            visualChart.Series.Clear();
                            visualChart.Series.Add(temp);
                        }
                        else
                        {
                            foreach (var seriesItem in visualChart.Series)
                            {
                                seriesItem.ChartType = seriesTypeMap[firstCB.SelectedItem.ToString()];
                            }
                        }
                        break;
                    }
                case "seriesColor":
                    {
                        var selectedSeries = visualChart.Series.FindByName(firstCB.SelectedItem.ToString());
                        foreach (var pointItem in selectedSeries.Points)
                        {
                            pointItem.Color = Color.Empty;
                        }
                        selectedSeries.Color = colorBtn.BackColor;
                        break;
                    }
                case "pointColor":
                    {
                        var selectedPointLabel = secondCB.SelectedItem.ToString();
                        var selectedSeries = visualChart.Series.FindByName(firstCB.SelectedItem.ToString());
                        DataPoint selectedPoint = null;
                        foreach (var pointItem in selectedSeries.Points)
                        {
                            if (pointItem.AxisLabel == selectedPointLabel)
                            {
                                selectedPoint = pointItem;
                            }
                        }
                        selectedPoint.Color = colorBtn.BackColor;

                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void DataSettingForm_Load(object sender, EventArgs e)
        {
            settingGB.Text = nameGroupBox;
            switch (typeSettings)
            {
                case "diagramType":
                    {
                        firstLbl.Text = "Выбор типа диаграммы";

                        firstCB.Items.AddRange(seriesTypeMap.Keys.ToArray());
                        firstCB.SelectedItem = seriesTypeMap.Where(x => x.Value == visualChart.Series[0].ChartType).SingleOrDefault().Key;
                        break;
                    }
                case "seriesColor":
                    {
                        firstLbl.Text = "Выбор серии";
                        this.Height = 193;
                        settingGB.Height = 97;
                        colorBtn.Visible = true;
                        colorLbl.Visible = true;

                        foreach (var seriesItem in visualChart.Series)
                        {
                            firstCB.Items.Add(seriesItem.Name);
                        }
                        firstCB.SelectedIndex = 0;
                        break;
                    }
                case "pointColor":
                    {
                        firstLbl.Text = "Выбор серии";
                        this.Height = 237;
                        settingGB.Height = 140;
                        colorBtn.Visible = true;
                        colorLbl.Visible = true;
                        secondCB.Visible = true;
                        secondLbl.Visible = true;

                        foreach (var seriesItem in visualChart.Series)
                        {
                            firstCB.Items.Add(seriesItem.Name);
                        }
                        firstCB.SelectedIndex = 0;

                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void firstCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (typeSettings)
            {
                case "seriesColor":
                    {
                        var selectedSeries = visualChart.Series.FindByName(firstCB.SelectedItem.ToString());
                        colorBtn.BackColor = selectedSeries.Color;
                        break;
                    }
                case "pointColor":
                    {
                        var selectedSeries = visualChart.Series.FindByName(firstCB.SelectedItem.ToString());
                        colorBtn.BackColor = selectedSeries.Color;

                        secondCB.Items.Clear();
                        foreach (var pointItem in selectedSeries.Points)
                        {
                            secondCB.Items.Add(pointItem.AxisLabel);
                        }
                        secondCB.SelectedIndex = 0;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void secondCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (typeSettings)
            {
                case "pointColor":
                    {
                        var selectedPointLabel = secondCB.SelectedItem.ToString();
                        var selectedSeries = visualChart.Series.FindByName(firstCB.SelectedItem.ToString());
                        DataPoint selectedPoint = null;
                        foreach (var pointItem in selectedSeries.Points)
                        {
                            if (pointItem.AxisLabel == selectedPointLabel)
                            {
                                selectedPoint = pointItem;
                            }
                        }

                        colorBtn.BackColor = selectedPoint.Color;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void colorBtn_Click(object sender, EventArgs e)
        {
            colorBtn.BackColor = CommonService.ChooseColor(colorDialog, colorBtn.BackColor);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
