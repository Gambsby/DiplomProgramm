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
        public string NameGroupBox { get; set; }
        public string TypeSettings { get; set; }
        public Series SeriesItem { get; set; }
        public bool Status { get; set; } = false;

        public object SelectedItem { get; set; }
        public Color Color { get; set; }


        public DataSettingForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void DataSettingForm_Load(object sender, EventArgs e)
        {
            firstGB.Text = NameGroupBox;
            switch (TypeSettings)
            {
                case "diagramType":
                    {
                        firstLbl.Text = "Выбор типа диаграммы";

                        firstCB.Items.AddRange(VisualisationForm.seriesTypeMap.Keys.ToArray());
                        firstCB.SelectedItem = VisualisationForm.seriesTypeMap.Where(x => x.Value == SeriesItem.ChartType).SingleOrDefault().Key;

                        colorBtn.Visible = false;
                        secondLbl.Visible = false;
                        break;
                    }
                case "color":
                    {
                        firstLbl.Text = "Выбор точки";

                        firstCB.Items.AddRange(SeriesItem.Points.Select(x => x.AxisLabel).ToArray());
                        firstCB.SelectedIndex = 0;
                        firstCB.SelectedIndexChanged += FirstCB_SelectedIndexChanged;

                        break;
                    }
            }
        }

        private void FirstCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedPoint = SeriesItem.Points.SingleOrDefault(x => x.AxisLabel == firstCB.SelectedItem.ToString());
            colorBtn.BackColor = selectedPoint.Color;
        }

        private void acceptBtn_Click(object sender, EventArgs e)
        {
            switch (TypeSettings)
            {
                case "diagramType":
                    {
                        SelectedItem = firstCB.SelectedItem;
                        Status = true;
                        break;
                    }
                case "color":
                    {
                        SelectedItem = firstCB.SelectedItem;
                        Color = colorBtn.BackColor;
                        Status = true;
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
