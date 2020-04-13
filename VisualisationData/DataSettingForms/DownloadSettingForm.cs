using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualisationData.Excel;
using VisualisationData.Services;

namespace VisualisationData.DataSettingForms
{
    public partial class DownloadSettingForm : Form
    {
        public ExcelDocument Document { get; set; }

        private List<ExcelResult> answerListContent;
        private List<ExcelProfile> profilesListContent;
        private List<ExcelQuestionType> infoListContent;
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
            using (var excelPack = new ExcelPackage())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    excelPack.Load(stream);
                }
                worksheetNames = excelPack.Workbook.Worksheets.Select(w => w.Name).ToList();
            }
            chooseInfoSheetCB.Items.AddRange(worksheetNames.ToArray());
            chooseAnswerSheetDG.Items.AddRange(worksheetNames.ToArray());
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            infoSheetName = chooseInfoSheetCB.SelectedItem.ToString();
            worksheetNames.Remove(infoSheetName);
            infoListContent = ExcelService.GetProfileNamesEP(filePath, infoSheetName);

            answerSheetName = chooseAnswerSheetDG.SelectedItem.ToString();
            worksheetNames.Remove(answerSheetName);
            answerListContent = ExcelService.GetResultsEP(filePath, answerSheetName);

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
                string profileName = chooseDG["profileName", i].Value.ToString();
                ExcelQuestionType profileInfo = infoListContent.SingleOrDefault(info => info.ProfileName == profileName);
                string profileType = profileInfo.GetProfileType();

                List<ExcelQuestion> questions = ExcelService.GetQuestionsEP(filePath, chooseDG["sheetName", i].Value.ToString(), profileType);

                ExcelProfile excelProfile = new ExcelProfile { 
                    Id = profileInfo.Id, 
                    Name = profileInfo.ProfileName, 
                    Type = profileType, 
                    Answers = profileInfo.Answers, 
                    Questions = questions 
                };
                profilesListContent.Add(excelProfile);
            }

            string documentName = Path.GetFileNameWithoutExtension(filePath);
            Document = new ExcelDocument { 
                DocumentName = documentName, 
                AnswerListContent = answerListContent, 
                ProfilesListContent = profilesListContent 
            }; 

            this.Close();
        }
    }
}
