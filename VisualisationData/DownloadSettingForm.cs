using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualisationData.Excel;
using VisualisationData.Services;

namespace VisualisationData
{
    public partial class DownloadSettingForm : Form
    {
        public List<ExcelQuestionType> infoListContent;
        public List<ExcelAnswer> answerListContent;
        public List<ExcelProfile> profilesListContent;

        private string filePath;
        private string infoSheetName;
        private string answerSheetName;
        private List<string> worksheetNames;

        public DownloadSettingForm(string filePath)
        {
            InitializeComponent();
            this.filePath = filePath;
        }

        private void DownloadSettingForm_Load(object sender, EventArgs e)
        {
            ConnexionExcel ConxObject = new ConnexionExcel(filePath);
            worksheetNames = ConxObject.UrlConnexion.GetWorksheetNames().ToList();
            chooseInfoSheetCB.Items.AddRange(worksheetNames.ToArray());
            chooseAnswerSheetDG.Items.AddRange(worksheetNames.ToArray());
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            infoSheetName = chooseInfoSheetCB.SelectedItem.ToString();
            worksheetNames.Remove(infoSheetName);
            infoListContent = ExcelService.GetProfileNames(filePath, infoSheetName);

            answerSheetName = chooseAnswerSheetDG.SelectedItem.ToString();
            worksheetNames.Remove(answerSheetName);
            answerListContent = ExcelService.GetAnswers(filePath, answerSheetName);

            chooseDG.Columns.Add(CommonService.CreateTextColumn("Идентификатор", "id"));
            chooseDG.Columns.Add(CommonService.CreateTextColumn("Название части анкеты", "profileName", true));
            chooseDG.Columns.Add(CommonService.CreateTextColumn("Возможные ответы", "answers", true));
            chooseDG.Columns.Add(CommonService.CreateComboColumn("Название листа", "sheetName", false, false));
            
            foreach (var item in infoListContent)
            {
                chooseDG.Rows.Add(item.Id, item.ProfileName, item.Answers);
                (chooseDG["sheetName", chooseDG.RowCount - 1] as DataGridViewComboBoxCell).Items.AddRange(worksheetNames.ToArray());
                chooseDG["sheetName", chooseDG.RowCount - 1].Value = (chooseDG["sheetName", chooseDG.RowCount - 1] as DataGridViewComboBoxCell).Items[0];
            }

            chooseInfoSheetCB.Enabled = false;
            chooseAnswerSheetDG.Enabled = false;
            nextBtn.Visible = false;
            acceptBtn.Visible = true;
        }

        private void acceptBtn_Click(object sender, EventArgs e)
        {
            profilesListContent = new List<ExcelProfile>();

            for (int i = 0; i < chooseDG.RowCount; i++)
            {
                string type = string.Empty;

                string profileName = chooseDG["profileName", i].Value.ToString();
                string answers = chooseDG["answers", i].Value.ToString();

                if (Regex.IsMatch(answers, "^от.+до.+$"))
                {
                    type = "range";
                }
                else if (Regex.IsMatch(answers, ";"))
                {
                    type = "checkbox";
                }
                else if (Regex.IsMatch(answers, "/"))
                {
                    type = "radio";
                }

                List<ExcelQuestion> questions = ExcelService.GetQuestions(filePath, chooseDG["sheetName", i].Value.ToString(), type);
                ExcelProfile excelProfile = new ExcelProfile { Name = profileName, Type = type, Questions = questions };
                profilesListContent.Add(excelProfile);
            }

            this.Close();
        }
    }
}
