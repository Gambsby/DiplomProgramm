using CsvHelper;
using CsvHelper.Configuration;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualisationData.Excel;
using VisualisationData.Services;

namespace VisualisationData.SettingsForm
{
    public partial class SaveSettingForm : Form
    {
        private const int CountThread = 5;
        private ExcelDocument Document { get; set; }
        private string type;
        public SaveSettingForm(ExcelDocument excelDocument, string type)
        {
            InitializeComponent();
            this.Document = excelDocument;
            this.type = type;
        }

        private void SaveSettingForm_Load(object sender, EventArgs e)
        {
            chooseDG.Columns.Add(CommonService.CreateTextColumn("Анкета", "profile", true));
            switch (type)
            {
                case "excel":
                    {
                        infoLbl.Text = "Введите название листа с информацией о возможных ответах:";
                        resultLbl.Text = "Ведите название листа с результатами анкетирования:";
                        chooseDG.Columns.Add(CommonService.CreateTextColumn("Название листа", "sheetName", true, false));
                        break;
                    }
                case "csv":
                    {
                        infoLbl.Text = "Введите название файла с информацией о возможных ответах:";
                        resultLbl.Text = "Ведите название файла с результатами анкетирования:";
                        chooseDG.Columns.Add(CommonService.CreateTextColumn("Название файла", "sheetName", true, false));
                        break;
                    }
                default:
                    break;
            }

            foreach (var profileEtem in Document.ProfilesListContent)
            {
                chooseDG.Rows.Add(profileEtem);
            }
        }

        private void acceptBtn_Click(object sender, EventArgs e)
        {
            switch (type)
            {
                case "excel":
                    {
                        SaveExcel();
                        break;
                    }
                case "csv":
                    {
                        SaveCSV();
                        break;
                    }
                default:
                    break;
            }
        }

        private void SaveExcel()
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Properties.Author = "User";
                excelPackage.Workbook.Properties.Title = Document.DocumentName;
                excelPackage.Workbook.Properties.Created = DateTime.Now;

                ExcelWorksheet infoSheet = excelPackage.Workbook.Worksheets.Add(profileInfoTB.Text);
                int rowInfoNumber = 2;
                foreach (DataGridViewRow rowItem in chooseDG.Rows)
                {
                    string sheetName = rowItem.Cells["sheetName"].Value.ToString();
                    ExcelProfile profile = rowItem.Cells["profile"].Value as ExcelProfile;

                    infoSheet.Cells["A" + rowInfoNumber].Value = profile.Id;
                    infoSheet.Cells["B" + rowInfoNumber].Value = profile.Name;
                    infoSheet.Cells["F" + rowInfoNumber].Value = profile.Answers;


                    ExcelWorksheet questionSheet = excelPackage.Workbook.Worksheets.Add(sheetName);
                    int rowQuestionIndex = 1;
                    foreach (var questuionItem in profile.Questions)
                    {
                        questionSheet.Cells["A" + rowQuestionIndex].Value = questuionItem.Id;
                        questionSheet.Cells["B" + rowQuestionIndex].Value = questuionItem.Content;

                        if (!string.IsNullOrEmpty(questuionItem.LeftLimit) && !string.IsNullOrEmpty(questuionItem.RightLimit))
                        {
                            questionSheet.Cells["C" + rowQuestionIndex].Value = questuionItem.LeftLimit;
                            questionSheet.Cells["D" + rowQuestionIndex].Value = questuionItem.RightLimit;
                        }

                        rowQuestionIndex++;
                    }

                    rowInfoNumber++;
                }

                ExcelWorksheet resultSheet = excelPackage.Workbook.Worksheets.Add(resultInfoTB.Text);
                resultSheet.Cells["A1"].Value = "id";
                resultSheet.Cells["B1"].Value = "анкета";
                resultSheet.Cells["C1"].Value = "номер вопроса";
                resultSheet.Cells["D1"].Value = "ответ";

                int rowResultNumber = 2;
                foreach (var answerItem in Document.AnswerListContent)
                {
                    resultSheet.Cells["A" + rowResultNumber].Value = answerItem.Id;
                    resultSheet.Cells["B" + rowResultNumber].Value = answerItem.ProfileNum;
                    resultSheet.Cells["C" + rowResultNumber].Value = answerItem.QuestionNum;
                    resultSheet.Cells["D" + rowResultNumber].Value = answerItem.Answer;

                    rowResultNumber++;
                }

                FileInfo fi = null;
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Title = "Сохранить файл как ...";
                    sfd.Filter = "*.xlsx|*.xlsx";
                    sfd.AddExtension = true;
                    sfd.FileName = Document.DocumentName;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        fi = new FileInfo(sfd.FileName);
                    }
                }
                excelPackage.SaveAs(fi);
            }
        }
    
        private void SaveCSV()
        {

            string infoFileName = profileInfoTB.Text;
            string resultFileName = resultInfoTB.Text;
            List<List<object>> questionFiles = new List<List<object>>();
            List<string> questionFilesName = new List<string>();

            List<object> infoFile = new List<object>();
            foreach (DataGridViewRow rowItem in chooseDG.Rows)
            {
                string sheetName = rowItem.Cells["sheetName"].Value.ToString();
                ExcelProfile profile = rowItem.Cells["profile"].Value as ExcelProfile;

                infoFile.Add(new { ID = profile.GetId(), Name = profile.GetName(), Answers = profile.GetAnswers() });

                List<object> questionFile = new List<object>();
                foreach (var questuionItem in profile.Questions)
                {
                    if (!string.IsNullOrEmpty(questuionItem.LeftLimit) && !string.IsNullOrEmpty(questuionItem.RightLimit))
                    {
                        questionFile.Add(new { ID = questuionItem.GetId(), Content = questuionItem.GetContent(), LeftLimit = questuionItem.GetLeftLimit(), RightLimit = questuionItem.GetRightLimit() });
                    }
                    else
                    {
                        questionFile.Add(new { ID = questuionItem.GetId(), Content = questuionItem.GetContent() });
                    }
                }
                questionFiles.Add(questionFile);
                questionFilesName.Add(sheetName);
            }

            List<object> resultFile = new List<object>();
            resultFile.Add(new { ID = "id", Profile = "анкета", QuestionNum = "номер вопроса", Answer = "ответ" });
            foreach (var resultItem in Document.AnswerListContent)
            {
                resultFile.Add(new { ID = resultItem.GetId(), Profile = resultItem.GetProfileNum(), QuestionNum = resultItem.GetQuestionNum(), Answer = resultItem.GetAnswer() });
            }

            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                string dirName = FBD.SelectedPath + "\\" + Document.DocumentName;
                Directory.CreateDirectory(dirName);
                WriteFile(dirName + "\\" + infoFileName + ".csv", infoFile);
                WriteFile(dirName + "\\" + resultFileName + ".csv", resultFile);

                for (int i = 0; i < questionFiles.Count; i++)
                {
                    WriteFile(dirName + "\\" + questionFilesName[i] + ".csv", questionFiles[i]);
                }
            }
        }

        private void WriteFile(string path, List<object> value)
        {
            using (var writer = new StreamWriter(path))
            {
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ":", IgnoreReferences = true, HasHeaderRecord = false }))
                {
                    
                    csv.WriteRecords(value);
                }
            }
        }
    }
}
