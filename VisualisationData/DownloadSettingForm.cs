using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualisationData.Excel;
using VisualisationData.Services;

namespace VisualisationData
{
    public partial class DownloadSettingForm : Form
    {
        private string filePath;
        private List<ExcelQuestionType> infoListContent;
        List<string> worksheetNames;
        public DownloadSettingForm(string filePath)
        {
            InitializeComponent();
            this.filePath = filePath;
        }

        private void DownloadSettingForm_Load(object sender, EventArgs e)
        {
            ConnexionExcel ConxObject = new ConnexionExcel(filePath);
            worksheetNames = ConxObject.UrlConnexion.GetWorksheetNames().ToList();
            chooseInfoSheetCB.DataSource = worksheetNames;
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            var infoSheetName = chooseInfoSheetCB.SelectedItem.ToString();
            worksheetNames.Remove(infoSheetName);
            infoListContent = ExcelService.GetProfileNames(filePath, infoSheetName);

            DataGridViewComboBoxColumn comboColumn = new DataGridViewComboBoxColumn();
            comboColumn.HeaderText = "Название листа";
            comboColumn.Name = "shettName";
            comboColumn.Items.AddRange(worksheetNames.ToArray());
            correlateProfileDG.Columns.Add(comboColumn);

            foreach (var item in infoListContent)
            {
                correlateProfileDG.Rows.Add(item.Id, item.ProfileName, item.Answers);
            }
            (correlateProfileDG.Rows[0].Cells[3] as DataGridViewComboBoxCell).Items.Add(worksheetNames[0]);
        }
    }
}
