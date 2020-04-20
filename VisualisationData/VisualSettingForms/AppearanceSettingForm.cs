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
            { "Отсутствие градиента", GradientStyle.None },
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


        public string NameGroupBox { get; set; }
        public string TypeSettings { get; set; }
        public Chart VisualChart { get; set; }

        public bool Status { get; set; } = false;
        public Color FirstColor { get; set; }
        public Color SecondColor { get; set; }
        public GradientStyle GradientStyle { get; set; }
        public ChartDashStyle ChartDashStyle { get; set; }
        public BorderSkinStyle BorderSkinStyle { get; set; }

        public AppearanceSettingForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void AppearanceSettingForm_Load(object sender, EventArgs e)
        {
            settingGB.Text = NameGroupBox;
            switch (TypeSettings)
            {
                case "background":
                    {
                        firstColorBtn.BackColor = VisualChart.BackColor;
                        secondColorBtn.BackColor = VisualChart.BackSecondaryColor;
                        gradientTypeCB.Items.AddRange(gradientStyleMap.Keys.ToArray());

                        gradientTypeCB.SelectedItem = gradientStyleMap.Where(x => x.Value == VisualChart.BackGradientStyle).SingleOrDefault().Key;
                        break;
                    }
                case "diagram":
                    {
                        firstColorBtn.BackColor = VisualChart.ChartAreas[0].BackColor;
                        secondColorBtn.BackColor = VisualChart.ChartAreas[0].BackSecondaryColor;
                        gradientTypeCB.Items.AddRange(gradientStyleMap.Keys.ToArray());
                        gradientTypeCB.SelectedItem = gradientStyleMap.Where(x => x.Value == VisualChart.ChartAreas[0].BackGradientStyle).SingleOrDefault().Key;
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

                        firstColorBtn.BackColor = VisualChart.BorderlineColor;
                        gradientTypeCB.Items.AddRange(borderTypeMap.Keys.ToArray());
                        gradientTypeCB.SelectedItem = borderTypeMap.Where(x => x.Value == VisualChart.BorderlineDashStyle).SingleOrDefault().Key;
                        borderStyleCB.Items.AddRange(borderStyleMap.Keys.ToArray());
                        borderStyleCB.SelectedItem = borderStyleMap.Where(x => x.Value == VisualChart.BorderSkin.SkinStyle).SingleOrDefault().Key;
                        break;
                    }
                default:
                    break;
            }
        }

        private void acceptBtn_Click(object sender, EventArgs e)
        {
            switch (TypeSettings)
            {
                case "background":
                    {
                        FirstColor = firstColorBtn.BackColor;
                        SecondColor = secondColorBtn.BackColor;
                        GradientStyle = gradientStyleMap[gradientTypeCB.SelectedItem.ToString()];
                        //visualChart.BackColor = firstColorBtn.BackColor;
                        //visualChart.BackSecondaryColor = secondColorBtn.BackColor;
                        //visualChart.BackGradientStyle = gradientStyleMap[gradientTypeCB.SelectedItem.ToString()];
                        Status = true;
                        break;
                    }
                case "diagram":
                    {
                        FirstColor = firstColorBtn.BackColor;
                        SecondColor = secondColorBtn.BackColor;
                        GradientStyle = gradientStyleMap[gradientTypeCB.SelectedItem.ToString()];
                        //visualChart.ChartAreas[0].BackColor = firstColorBtn.BackColor;
                        //visualChart.ChartAreas[0].BackSecondaryColor = secondColorBtn.BackColor;
                        //visualChart.ChartAreas[0].BackGradientStyle = gradientStyleMap[gradientTypeCB.SelectedItem.ToString()];
                        Status = true;
                        break;
                    }
                case "border":
                    {
                        FirstColor = firstColorBtn.BackColor;
                        ChartDashStyle = borderTypeMap[gradientTypeCB.SelectedItem.ToString()];
                        BorderSkinStyle = borderStyleMap[borderStyleCB.SelectedItem.ToString()];
                        //visualChart.BorderlineColor = firstColorBtn.BackColor;
                        //visualChart.BorderlineDashStyle = borderTypeMap[gradientTypeCB.SelectedItem.ToString()];
                        //visualChart.BorderSkin.SkinStyle = borderStyleMap[borderStyleCB.SelectedItem.ToString()];
                        Status = true;
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
