using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using VisualisationData.Services;
using Microsoft.VisualBasic;

namespace VisualisationData
{
    public partial class SettingChartDataWindow : Form
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
        private Dictionary<string, GradientStyle> gradientStyleMap = new Dictionary<string, GradientStyle>
        {
            { "Отсутсвие градиента", GradientStyle.None },
            { "Градиент слева на право", GradientStyle.LeftRight },
            { "Градиент сверху в низ", GradientStyle.TopBottom },
            { "Градиент от центра к краям", GradientStyle.Center },
            { "Градиент по диагонали слева направо", GradientStyle.DiagonalLeft },
            { "Градиент по диагонали справа налево", GradientStyle.DiagonalRight },
            { "Градиент по горизонтали от центра к краям", GradientStyle.HorizontalCenter },
            { "Градиент по вертикали от центра к краям", GradientStyle.VerticalCenter }
        };
        private Dictionary<string, ChartDashStyle> borderTypeMap = new Dictionary<string, ChartDashStyle>
        {
            { "Отсутсвие границы", ChartDashStyle.NotSet },
            { "Пунктирная линия", ChartDashStyle.Dash },
            { "Тире-точка линия", ChartDashStyle.DashDot },
            { "Тире-точка-точка линия", ChartDashStyle.DashDotDot },
            { "Точка-точка линия", ChartDashStyle.Dot },
            { "Сплошная линия", ChartDashStyle.Solid }
        };
        private Dictionary<string, BorderSkinStyle> borderStyleMap = new Dictionary<string, BorderSkinStyle>
        {
            { "Без эффектов", BorderSkinStyle.None },
            { "Эффект приподнятости", BorderSkinStyle.Emboss },
            { "Эффект утопления", BorderSkinStyle.Sunken },
            { "Эффект поднятия", BorderSkinStyle.Raised }
        };

        private Chart visualChart;

        public SettingChartDataWindow(Chart chart)
        {
            InitializeComponent();
            this.visualChart = chart;
        }

        private Color ChooseColor(Color oldColor)
        {
            colorDialog.FullOpen = true;
            colorDialog.Color = oldColor;

            if (colorDialog.ShowDialog() == DialogResult.Cancel)
                return oldColor;

            return colorDialog.Color;
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            #region All chart setting
            visualChart.BackColor = BGColorBtn.BackColor;
            visualChart.BackSecondaryColor = secondBGColorBtn.BackColor;
            visualChart.BackGradientStyle = gradientStyleMap[gradientTypeCB.SelectedItem.ToString()];
            #endregion

            #region Diagramm setting
            visualChart.ChartAreas[0].BackColor = diagramBGColorBtn.BackColor;
            visualChart.ChartAreas[0].BackSecondaryColor = diagramSecondBGColorBtn.BackColor;
            visualChart.ChartAreas[0].BackGradientStyle = gradientStyleMap[diagramGradientTypeCB.SelectedItem.ToString()];
            #endregion

            #region Border setting
            visualChart.BorderlineColor = borderColorBtn.BackColor;
            visualChart.BorderlineDashStyle = borderTypeMap[borderTypeCB.SelectedItem.ToString()];
            visualChart.BorderSkin.SkinStyle = borderStyleMap[borderStyleCB.SelectedItem.ToString()];
            #endregion

            #region Signature diagram
            foreach (var seriesItem in visualChart.Series)
            {
                seriesItem.IsValueShownAsLabel = signatureCheck.Checked;
            }
            #endregion

            #region 3D Mode setting
            visualChart.ChartAreas[0].Area3DStyle.Enable3D = mode3DCheck.Checked;
            #endregion

            #region Diagram Type Setting
            var selectedChartType = seriesTypeMap[typeDiagramCB.SelectedItem.ToString()];
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
                    seriesItem.ChartType = seriesTypeMap[typeDiagramCB.SelectedItem.ToString()];
                }                   
            }

            seriesCB.Items.Clear();
            foreach (var seriesItem in visualChart.Series)
            {
                seriesCB.Items.Add(seriesItem.Name);
            }
            seriesCB.SelectedIndex = 0;
            #endregion

            #region Diagram Title Setting
            if (!string.IsNullOrEmpty(titleTB.Text))
            {
                visualChart.Titles.Clear();
                visualChart.Titles.Add(titleTB.Text);
            }
            #endregion

            #region Series Color Setting
            visualChart.Series.FindByName(seriesCB.SelectedItem.ToString()).Color = seriesColorBtn.BackColor;
            #endregion

            #region Points Color Setting
            if (pointColorCheck.Checked)
            {
                var selectedPointLabel = pointsCB.SelectedItem.ToString();
                var selectedSeries = visualChart.Series.FindByName(seriesCB.SelectedItem.ToString());
                DataPoint selectedPoint = null;
                foreach (var pointItem in selectedSeries.Points)
                {
                    if (pointItem.AxisLabel == selectedPointLabel)
                    {
                        selectedPoint = pointItem;
                    }
                }
                selectedPoint.Color = pointColorBtn.BackColor;
            }
            #endregion
        }

        private void SettingChartDataForm_Load(object sender, EventArgs e)
        {

            seriesCB.DrawMode = DrawMode.OwnerDrawFixed;
            seriesCB.DrawItem += SeriesCB_DrawItem;


            #region All chart setting
            BGColorBtn.BackColor = visualChart.BackColor;
            secondBGColorBtn.BackColor = visualChart.BackSecondaryColor;
            gradientTypeCB.Items.AddRange(gradientStyleMap.Keys.ToArray());

            gradientTypeCB.SelectedItem = gradientStyleMap.Where(x => x.Value == visualChart.BackGradientStyle).SingleOrDefault().Key;
            #endregion

            #region Diagramm setting
            diagramBGColorBtn.BackColor = visualChart.ChartAreas[0].BackColor;
            diagramSecondBGColorBtn.BackColor = visualChart.ChartAreas[0].BackSecondaryColor;
            diagramGradientTypeCB.Items.AddRange(gradientStyleMap.Keys.ToArray());
            diagramGradientTypeCB.SelectedItem = gradientStyleMap.Where(x => x.Value == visualChart.ChartAreas[0].BackGradientStyle).SingleOrDefault().Key;
            #endregion

            #region Border setting
            borderColorBtn.BackColor = visualChart.BorderlineColor;
            borderTypeCB.Items.AddRange(borderTypeMap.Keys.ToArray());
            borderTypeCB.SelectedItem = borderTypeMap.Where(x => x.Value == visualChart.BorderlineDashStyle).SingleOrDefault().Key;
            borderStyleCB.Items.AddRange(borderStyleMap.Keys.ToArray());
            borderStyleCB.SelectedItem = borderStyleMap.Where(x => x.Value == visualChart.BorderSkin.SkinStyle).SingleOrDefault().Key;
            #endregion

            #region Signature diagram
            foreach (var seriesItem in visualChart.Series)
            {
                signatureCheck.Checked = seriesItem.IsValueShownAsLabel;
                if (signatureCheck.Checked)
                {
                    break;
                } 
            }
            #endregion

            #region 3D Mode setting
            mode3DCheck.Checked = visualChart.ChartAreas[0].Area3DStyle.Enable3D;
            #endregion

            #region Diagram Type Setting
            typeDiagramCB.Items.AddRange(seriesTypeMap.Keys.ToArray());
            typeDiagramCB.SelectedItem = seriesTypeMap.Where(x => x.Value == visualChart.Series[0].ChartType).SingleOrDefault().Key;
            #endregion

            #region Diagram Title Setting
            if (visualChart.Titles.Count > 0)
            {
                titleTB.Text = visualChart.Titles[0].Text;
            }
            #endregion

            #region Series Color Setting
            foreach (var seriesItem in visualChart.Series)
            {
                seriesCB.Items.Add(seriesItem.Name);
            }
            seriesCB.SelectedIndex = 0;
            #endregion

            #region Points Color Setting
            /*var selectedSeries = visualChart.Series.FindByName(seriesCB.SelectedItem.ToString());
            foreach (var pointItem in selectedSeries.Points)
            {
                pointsCB.Items.Add(pointItem.AxisLabel);
            }
            pointsCB.SelectedIndex = 0;*/
            #endregion
        }

        private void seriesCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedSeries = visualChart.Series.FindByName(seriesCB.SelectedItem.ToString());
            seriesColorBtn.BackColor = selectedSeries.Color;

            if (pointColorCheck.Checked)
            {
                foreach (var pointItem in selectedSeries.Points)
                {
                    pointsCB.Items.Add(pointItem.AxisLabel);
                }
                pointsCB.SelectedIndex = 0;
            }
        }

        private void pointsCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedPointLabel = pointsCB.SelectedItem.ToString();
            var selectedSeries = visualChart.Series.FindByName(seriesCB.SelectedItem.ToString());
            DataPoint selectedPoint = null;
            foreach (var pointItem in selectedSeries.Points)
            {
                if (pointItem.AxisLabel == selectedPointLabel)
                {
                    selectedPoint = pointItem;
                }
            }

            pointColorBtn.BackColor = selectedPoint.Color;
        }

        private void BGColorBtn_Click(object sender, EventArgs e)
        {
            BGColorBtn.BackColor = ChooseColor(BGColorBtn.BackColor);
        }

        private void secondBGColorBtn_Click(object sender, EventArgs e)
        {
            secondBGColorBtn.BackColor = ChooseColor(secondBGColorBtn.BackColor);
        }

        private void diagramBGColorBtn_Click(object sender, EventArgs e)
        {
            diagramBGColorBtn.BackColor = ChooseColor(diagramBGColorBtn.BackColor);
        }

        private void diagramSecondBGColorBtn_Click(object sender, EventArgs e)
        {
            secondBGColorBtn.BackColor = ChooseColor(secondBGColorBtn.BackColor);
        }

        private void borderColorBtn_Click(object sender, EventArgs e)
        {
            borderColorBtn.BackColor = ChooseColor(borderColorBtn.BackColor);
        }

        private void seriesColorBtn_Click(object sender, EventArgs e)
        {
            seriesColorBtn.BackColor = ChooseColor(seriesColorBtn.BackColor);
        }

        private void pointColorBtn_Click(object sender, EventArgs e)
        {
            pointColorBtn.BackColor = ChooseColor(pointColorBtn.BackColor);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SeriesCB_DrawItem(object sender, DrawItemEventArgs e)
        {
            string text = this.seriesCB.GetItemText(seriesCB.Items[e.Index]);
            e.DrawBackground();
            using (SolidBrush br = new SolidBrush(e.ForeColor))
            {
                e.Graphics.DrawString(text, e.Font, br, e.Bounds);
            }

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                if (text.Length > Math.Round(Convert.ToDecimal(this.seriesCB.Size.Width / 8)))
                {
                    this.toolTip1.Show(text, seriesCB, e.Bounds.Right, e.Bounds.Bottom);
                }
            }
            else
            {
                this.toolTip1.Hide(seriesCB);
            }
            e.DrawFocusRectangle();
        }

        private void poinColorCheck_CheckedChanged(object sender, EventArgs e)
        {
            pointColorBtn.Enabled = pointColorCheck.Checked;
            pointsCB.Enabled = pointColorCheck.Checked;
        }
    }
}
