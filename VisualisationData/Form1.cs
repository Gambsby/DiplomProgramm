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
using System.IO;
using MySql.Data.MySqlClient;
using Z.BulkOperations;
using System.Windows.Forms.DataVisualization.Charting;
using VisualisationData.Models;
using ExcelLibrary.SpreadSheet;
using OfficeOpenXml;
using VisualisationData.SettingsForm;

namespace VisualisationData
{
    public partial class Form1 : Form
    {
        private ExcelDocument Document { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)//1
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            infoDG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            infoDG.MultiSelect = true;
        }

        private void loadDataBtn_Click(object sender, EventArgs e)//2
        {
            #region Load Data
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filePath = openFileDialog.FileName;
            string fileName = Path.GetFileNameWithoutExtension(openFileDialog.SafeFileName);

            DownloadSettingForm downloadSettingForm = new DownloadSettingForm(filePath);
            downloadSettingForm.ShowDialog();
            switch (downloadSettingForm.DialogResult)
            {
                case DialogResult.OK:
                    {
                        Document = downloadSettingForm.Document;
                        MessageBox.Show("Данные успешно загруженны");
                        break;
                    }
                case DialogResult.Cancel:
                    {
                        break;
                    }
            }
            #endregion

            profilesCB.Items.AddRange(Document.ProfilesListContent.Select(p => p).ToArray());
            profilesCB.SelectedIndex = 0;
        }

        private void profilesCB_SelectedIndexChanged(object sender, EventArgs e)//3
        {
            var selectedProfile = profilesCB.SelectedItem as ExcelProfile;

            InitDataGrid(selectedProfile.Type, infoDG);

            foreach (var questionItem in selectedProfile.Questions)
            {
                switch (selectedProfile.Type)
                {
                    case "range":
                        {
                            infoDG.Rows.Add(questionItem.Id, questionItem.Content, questionItem.LeftLimit, questionItem.RightLimit, selectedProfile.Answers);
                            break;
                        }
                    case "radio":
                        {
                            infoDG.Rows.Add(questionItem.Id, questionItem.Content, selectedProfile.Answers);
                            break;
                        }
                    case "checkbox":
                        {
                            infoDG.Rows.Add(questionItem.Id, questionItem.Content, selectedProfile.Answers);
                            break;
                        }
                    default:
                        break;
                }
            }

        }

        private void InitDataGrid(string type, DataGridView dataGrid)
        {
            dataGrid.Columns.Clear();
            dataGrid.Rows.Clear();

            dataGrid.Columns.Add(CommonService.CreateTextColumn("Номер вопроса", "serielNumber"));
            dataGrid.Columns.Add(CommonService.CreateTextColumn("Вопрос", "question", true));

            switch (type)
            {
                case "range":
                    {
                        dataGrid.Columns.Add(CommonService.CreateTextColumn("Левая граница", "leftLimit", true));
                        dataGrid.Columns.Add(CommonService.CreateTextColumn("Правая граница", "rightLimit", true));
                        break;
                    }
            }
            dataGrid.Columns.Add(CommonService.CreateTextColumn("Возможные ответы", "answers"));
        }

        private void columnDiagramBtn_Click(object sender, EventArgs e)
        {
            List<ExcelQuestion> selectedQuestions = new List<ExcelQuestion>();
            foreach (var rowItem in infoDG.SelectedRows.Cast<DataGridViewRow>())
            {
                var question = new ExcelQuestion
                {
                    Id = Convert.ToInt32(rowItem.Cells["serielNumber"].Value),
                    Content = rowItem.Cells["question"].Value.ToString()
                };
                selectedQuestions.Add(question);
            }
            //var selectedQuestion = new ExcelQuestion { 
            //    Id = Convert.ToInt32(infoDG.SelectedRows[0].Cells["serielNumber"].Value), 
            //    Content = infoDG.SelectedRows[0].Cells["question"].Value.ToString() 
            //};
            var selectedProfile = profilesCB.SelectedItem as ExcelProfile;

            VisualisationForm visualisationForm = new VisualisationForm(selectedQuestions, selectedProfile, Document, SeriesChartType.Column);
            visualisationForm.Show();
        }

        private void barDiagramBtn_Click(object sender, EventArgs e)
        {
            List<ExcelQuestion> selectedQuestions = new List<ExcelQuestion>();
            foreach (var rowItem in infoDG.SelectedRows.Cast<DataGridViewRow>())
            {
                var question = new ExcelQuestion
                {
                    Id = Convert.ToInt32(rowItem.Cells["serielNumber"].Value),
                    Content = rowItem.Cells["question"].Value.ToString()
                };
                selectedQuestions.Add(question);
            }
            //var selectedQuestion = new ExcelQuestion
            //{
            //    Id = Convert.ToInt32(infoDG.SelectedRows[0].Cells["serielNumber"].Value),
            //    Content = infoDG.SelectedRows[0].Cells["question"].Value.ToString()
            //};
            var selectedProfile = profilesCB.SelectedItem as ExcelProfile;

            VisualisationForm visualisationForm = new VisualisationForm(selectedQuestions, selectedProfile, Document, SeriesChartType.Bar);
            visualisationForm.Show();
        }

        private void pieDiagramBtn_Click(object sender, EventArgs e)
        {
            List<ExcelQuestion> selectedQuestions = new List<ExcelQuestion>();
            foreach (var rowItem in infoDG.SelectedRows.Cast<DataGridViewRow>())
            {
                var question = new ExcelQuestion
                {
                    Id = Convert.ToInt32(rowItem.Cells["serielNumber"].Value),
                    Content = rowItem.Cells["question"].Value.ToString()
                };
                selectedQuestions.Add(question);
            }
            //var selectedQuestion = new ExcelQuestion
            //{
            //    Id = Convert.ToInt32(infoDG.SelectedRows[0].Cells["serielNumber"].Value),
            //    Content = infoDG.SelectedRows[0].Cells["question"].Value.ToString()
            //};
            var selectedProfile = profilesCB.SelectedItem as ExcelProfile;

            VisualisationForm visualisationForm = new VisualisationForm(selectedQuestions, selectedProfile, Document, SeriesChartType.Pie);
            visualisationForm.Show();
        }






        private void saveDBBtn_Click(object sender, EventArgs e)
        {
            using (profilesContext db = new profilesContext())
            {
                using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction tr = db.Database.BeginTransaction())
                {
                    try
                    {
                        //SaveProfileToDB(db, tr);
                        tr.Commit();
                        //SaveResultToDB(db, tr);
                    }
                    catch (Exception ex)
                    {
                        tr.Rollback();
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        /*private void SaveProfileToDB(profilesContext db, Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction tr)
        {
            Dictionary<string, Profile> profileMap = new Dictionary<string, Profile>();

            Dictionary<string, Questiontype> questionTypeMap = new Dictionary<string, Questiontype>();
            questionTypeMap = db.Questiontype.Select(q => q).ToDictionary(q => q.Type, q => q);

            Questiontype questionType;
            MainProfile mainProfile;
            Profile profile;
            Question question;

            List<QuestionAnswer> questionAnswers = new List<QuestionAnswer>();

            mainProfile = db.MainProfile.SingleOrDefault(m => m.Name == Document.DocumentName);
            if (mainProfile == null)
            {
                mainProfile = new MainProfile { Name = Document.DocumentName };
            }
            else
            {
                throw new Exception("Файл с таким именем уже был сохранен!");
            }

            foreach (var profileItem in Document.ProfilesListContent)
            {
                if (questionTypeMap.ContainsKey(profileItem.Type))
                {
                    questionType = questionTypeMap[profileItem.Type];
                }
                else
                {
                    questionType = new Questiontype { Type = profileItem.Type };
                }

                if (!profileMap.ContainsKey(profileItem.Name))
                {
                    profile = new Profile { Name = profileItem.Name, SerialNumber = profileItem.Id, MainProfile = mainProfile };
                    profileMap.Add(profile.Name, profile);
                }
                else
                {
                    throw new Exception("В файле не может содержаться несколько анкет с одинаковым именем!");
                }

                List<Answer> answers = new List<Answer>();
                foreach (var answerItem in profileItem.Answers)
                {
                    answers.Add(new Answer { Content = answerItem, Profile = profile });
                }

                foreach (var questionItem in profileItem.Questions)
                {
                    if (questionType.Type == "range")
                    {
                        question = new Question
                        {
                            Content = questionItem.Content,
                            SerialNumber = questionItem.Id,
                            Profile = profile,
                            Type = questionType,
                            Limits = new Limits { 
                                Start = questionItem.leftLimit, 
                                End = questionItem.rightLimit, 
                                Profile = profile 
                            }
                        };
                    }
                    else
                    {
                        question = new Question { 
                            Content = questionItem.Content, 
                            SerialNumber = questionItem.Id, 
                            Profile = profile, 
                            Type = questionType, 
                            Limits = null 
                        };
                    }

                    foreach (var answerItem in answers)
                    {
                        questionAnswers.Add(new QuestionAnswer { Question = question, Answer = answerItem });
                    }
                }
            }
            db.QuestionAnswer.AddRange(questionAnswers);
            db.SaveChanges();
            Application.DoEvents();
        }*/

        /*private void SaveResultToDB(profilesContext db, Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction tr)
        {
            MainProfile mainProfile = db.MainProfile.SingleOrDefault(m => m.Name == Document.DocumentName);
            List<Profile> profiles = db.Profile.Where(p => p.MainProfile == mainProfile).ToList();
            List<QuestionAnswer> questionAnswers = db.QuestionAnswer.Where(q => profiles.Contains(q.Question.Profile) && profiles.Contains(q.Answer.Profile)).ToList();

            Dictionary<string, Questioned> questionedMap = new Dictionary<string, Questioned>();

            foreach (var answerItem in Document.AnswerListContent)
            {
                if (!questionedMap.ContainsKey(answerItem.Id))
                {
                    questionedMap.Add(answerItem.Id, new Questioned { Number = answerItem.Id, MainProfile = mainProfile });
                }
            }

            DataTable questionedDT = new DataTable();
            questionedDT.Columns.Add(new DataColumn("id"));
            questionedDT.Columns.Add(new DataColumn("number"));
            questionedDT.Columns.Add(new DataColumn("main_profile_id"));

            foreach (var questionedItem in questionedMap.Values)
            {
                DataRow row = questionedDT.NewRow();
                row["id"] = null;
                row["number"] = questionedItem.Number;
                row["main_profile_id"] = questionedItem.MainProfile.Id;
                questionedDT.Rows.Add(row);
            }
            BulkWriteToDB(questionedDT, "questioned");
            Application.DoEvents();

            questionedMap = db.Questioned.Where(q => q.MainProfile == mainProfile).ToDictionary(q => q.Number, q => q);

            DataTable resultDT = new DataTable();
            resultDT.Columns.Add(new DataColumn("id"));
            resultDT.Columns.Add(new DataColumn("questioned_id"));
            resultDT.Columns.Add(new DataColumn("question_answer_id"));
            resultDT.Columns.Add(new DataColumn("profile_id"));
            foreach (var answerItem in Document.AnswerListContent)
            {
                Profile profile = profiles.SingleOrDefault(p => p.SerialNumber == answerItem.ProfileNum);
                QuestionAnswer questionAnswer = questionAnswers.SingleOrDefault(q => q.Answer.Profile == profile &&
                                                                                q.Question.Profile == profile &&
                                                                                q.Question.SerialNumber == answerItem.QuestionNum &&
                                                                                q.Answer.Content == answerItem.Answers[0]);
                Questioned questioned = questionedMap[answerItem.Id];

                DataRow row = resultDT.NewRow();
                row["id"] = null;
                row["questioned_id"] = questioned.Id;
                row["question_answer_id"] = questionAnswer.Id;
                row["profile_id"] = profile.Id;
                resultDT.Rows.Add(row);

                if (resultDT.Rows.Count == 30000)
                {
                    BulkWriteToDB(resultDT, "result");
                    resultDT.Rows.Clear();
                    Application.DoEvents();
                }
            }
            if (resultDT.Rows.Count != 0)
            {
                BulkWriteToDB(resultDT, "result");
            }
        }*/

        private void BulkWriteToDB(DataTable dataTable, string tableName)
        {
            try
            {

                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();
                using (var bulk = new BulkOperation(conn))
                {
                    bulk.DestinationTableName = tableName;

                    bulk.BulkInsert(dataTable);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void closeProfileBtn_Click(object sender, EventArgs e)
        {
            profilesCB.Items.Clear();
            infoDG.Rows.Clear();
            infoDG.Columns.Clear();
            Document = null;
        }

        private void saveExcelBtn_Click(object sender, EventArgs e)
        {
            SaveSettingForm saveSettingForm = new SaveSettingForm(Document, "excel");
            saveSettingForm.ShowDialog();
            switch (saveSettingForm.DialogResult)
            {
                case DialogResult.OK:
                    {
                        MessageBox.Show("Данные успешно сохранены");
                        break;
                    }
                case DialogResult.Cancel:
                    {
                        break;
                    }
            }
        }

        private void saveCSVBtn_Click(object sender, EventArgs e)
        {
            SaveSettingForm saveSettingForm = new SaveSettingForm(Document, "csv");
            saveSettingForm.ShowDialog();
            switch (saveSettingForm.DialogResult)
            {
                case DialogResult.OK:
                    {
                        MessageBox.Show("Данные успешно сохранены");
                        break;
                    }
                case DialogResult.Cancel:
                    {
                        break;
                    }
            }
        }
    }
}
