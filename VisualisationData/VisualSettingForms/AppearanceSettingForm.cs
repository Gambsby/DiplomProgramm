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
    public partial class AppearanceSettingForm : Form
    {
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


        private string nameGroupBox;
        private string typeSettings;
        private Chart visualChart;

        public AppearanceSettingForm(Chart visualChart, string nameGroupBox, string typeSettings)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.nameGroupBox = nameGroupBox;
            this.typeSettings = typeSettings;
            this.visualChart = visualChart;
        }

        private void AppearanceSettingForm_Load(object sender, EventArgs e)
        {
            settingGB.Text = nameGroupBox;
            switch (typeSettings)
            {
                case "background":
                    {
                        firstColorBtn.BackColor = visualChart.BackColor;
                        secondColorBtn.BackColor = visualChart.BackSecondaryColor;
                        gradientTypeCB.Items.AddRange(gradientStyleMap.Keys.ToArray());

                        gradientTypeCB.SelectedItem = gradientStyleMap.Where(x => x.Value == visualChart.BackGradientStyle).SingleOrDefault().Key;
                        break;
                    }
                case "diagram":
                    {
                        firstColorBtn.BackColor = visualChart.ChartAreas[0].BackColor;
                        secondColorBtn.BackColor = visualChart.ChartAreas[0].BackSecondaryColor;
                        gradientTypeCB.Items.AddRange(gradientStyleMap.Keys.ToArray());
                        gradientTypeCB.SelectedItem = gradientStyleMap.Where(x => x.Value == visualChart.ChartAreas[0].BackGradientStyle).SingleOrDefault().Key;
                        break;
                    }
                case "border":
                    {
                        secondColorBtn.Visible = false;
                        secondColorLbl.Visible = false;
                        borderStyleCB.Visible = true;
                        borderStyleLbl.Visible = true;
                        this.Height = 233;
                        settingGB.Height = 142;

                        firstColorBtn.BackColor = visualChart.BorderlineColor;
                        gradientTypeCB.Items.AddRange(borderTypeMap.Keys.ToArray());
                        gradientTypeCB.SelectedItem = borderTypeMap.Where(x => x.Value == visualChart.BorderlineDashStyle).SingleOrDefault().Key;
                        borderStyleCB.Items.AddRange(borderStyleMap.Keys.ToArray());
                        borderStyleCB.SelectedItem = borderStyleMap.Where(x => x.Value == visualChart.BorderSkin.SkinStyle).SingleOrDefault().Key;
                        break;
                    }
                default:
                    break;
            }
        }

        private void acceptBtn_Click(object sender, EventArgs e)
        {
            switch (typeSettings)
            {
                case "background":
                    {
                        visualChart.BackColor = firstColorBtn.BackColor;
                        visualChart.BackSecondaryColor = secondColorBtn.BackColor;
                        visualChart.BackGradientStyle = gradientStyleMap[gradientTypeCB.SelectedItem.ToString()];
                        break;
                    }
                case "diagram":
                    {
                        visualChart.ChartAreas[0].BackColor = firstColorBtn.BackColor;
                        visualChart.ChartAreas[0].BackSecondaryColor = secondColorBtn.BackColor;
                        visualChart.ChartAreas[0].BackGradientStyle = gradientStyleMap[gradientTypeCB.SelectedItem.ToString()];
                        break;
                    }
                case "border":
                    {
                        visualChart.BorderlineColor = firstColorBtn.BackColor;
                        visualChart.BorderlineDashStyle = borderTypeMap[gradientTypeCB.SelectedItem.ToString()];
                        visualChart.BorderSkin.SkinStyle = borderStyleMap[borderStyleCB.SelectedItem.ToString()];
                        break;
                    }
                default:
                    break;
            }
        }

        private void secondColorBtn_Click(object sender, EventArgs e)
        {
            secondColorBtn.BackColor = CommonService.ChooseColor(colorDialog, secondColorBtn.BackColor);
        }

        private void firstColorBtn_Click(object sender, EventArgs e)
        {
            firstColorBtn.BackColor = CommonService.ChooseColor(colorDialog, firstColorBtn.BackColor);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
