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
using VisualisationData.Models;
using System.IO;
using MySql.Data.MySqlClient;
using Z.BulkOperations;
using System.Windows.Forms.DataVisualization.Charting;

namespace VisualisationData
{
    public partial class Form1 : Form
    {
        private ExcelDocument Document { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

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
                MessageBox.Show(ex.ToString());
            }
        }

        private DataTable GetDataTableQuestioned()
        {
            /*var questionedsMap = new Dictionary<string, int>();
            using (profiletransactionContext db = new profiletransactionContext())
            {
                var questionedsList = db.Questioned.Select(q => q).ToList();
                questionedsMap = questionedsList.ToDictionary(q => q.Number, q => q.Id, StringComparer.OrdinalIgnoreCase);
            }

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("id");
            dataTable.Columns.Add("number");

            foreach (var answerItem in AnswerListContent)
            {
                if (!questionedsMap.ContainsKey(answerItem.Id))
                {
                    DataRow dataRow = dataTable.NewRow();
                    dataRow["id"] = null;
                    dataRow["number"] = answerItem.Id;
                    dataTable.Rows.Add(dataRow);
                    questionedsMap.Add(answerItem.Id, 0);
                }
            }
            //dataTable = dataTable.DefaultView.ToTable(true, new string[] { "id", "number" });
            return dataTable;*/
            return null;
        }

        private DataTable GetDataTableResult()//Добавить проверку на наличие такой записи
        {
            /*Dictionary<int, int> profilesMap = new Dictionary<int, int>();
            Dictionary<string, int> questionedsMap = new Dictionary<string, int>();
            Dictionary<string, int> answersMap = new Dictionary<string, int>();
            Dictionary<string, int> questionsMap = new Dictionary<string, int>();
            Dictionary<string, int> questionAnswersMap = new Dictionary<string, int>();

            using (profiletransactionContext db = new profiletransactionContext())
            {
                var questionedsList = db.Questioned.Select(q => q).ToList();
                questionedsMap = questionedsList.ToDictionary(q => q.Number, q => q.Id, StringComparer.OrdinalIgnoreCase);

                var answersList = db.Answer.Select(a => a).ToList();
                answersMap = answersList.ToDictionary(a => a.ProfileId.ToString() + "-" + a.Content, a => a.Id, StringComparer.OrdinalIgnoreCase);

                var questionsList = db.Question.Select(q => q).ToList();
                questionsMap = questionsList.ToDictionary(q => q.ProfileId.ToString() + "-" + q.SerialNumber, q => q.Id, StringComparer.OrdinalIgnoreCase);

                var questionAnswersList = db.QuestionAnswer.Select(qa => qa).ToList();
                questionAnswersMap = questionAnswersList.ToDictionary(qa => qa.AnswerId.ToString() + "-" + qa.QuestionId, qa => qa.Id);

                var profilesList = db.Profile.Select(p => p).ToList();
                foreach (var infoItem in InfoListContent)
                {
                    var profileId = profilesList.SingleOrDefault(p => p.Name == infoItem.ProfileName).Id;
                    profilesMap.Add(infoItem.Id, profileId);
                }
            }

            DataTable resultsTable = new DataTable();
            resultsTable.Columns.Add("id");
            resultsTable.Columns.Add("questioned_id");
            resultsTable.Columns.Add("question_answer_id");
            resultsTable.Columns.Add("profile_id");

            using (profiletransactionContext db = new profiletransactionContext())
            {
                foreach (var answerItem in AnswerListContent)
                {
                    var questionedId = questionedsMap[answerItem.Id];
                    var profileId = profilesMap[answerItem.ProfileNum];
                    var answerId = answersMap[profileId.ToString() + "-" + answerItem.Answer];
                    var questionId = questionsMap[profileId.ToString() + "-" + answerItem.QuestionNum];
                    var questionAnswerId = questionAnswersMap[answerId.ToString() + "-" + questionId.ToString()];

                    DataRow dataRow = resultsTable.NewRow();
                    dataRow["id"] = null;
                    dataRow["questioned_id"] = questionedId;
                    dataRow["question_answer_id"] = questionAnswerId;
                    dataRow["profile_id"] = profileId;
                    resultsTable.Rows.Add(dataRow);
                }
            }

            return resultsTable;*/
            return null;
        }






        private void downloadDataBtn_Click(object sender, EventArgs e)
        {
            /*

            #region Download Data
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
                        AnswerListContent = downloadSettingForm.answerListContent;
                        ProfilesListContent = downloadSettingForm.profilesListContent;
                        break;
                    }
                case DialogResult.Cancel:
                    {
                        break;
                    }
            }
            #endregion

            #region Add Profile Сделано
            using (profiletransactionContext db = new profiletransactionContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var mainProfileToDB = db.MainProfile.SingleOrDefault(p => p.Name == fileName);
                        if (mainProfileToDB == null)
                        {
                            mainProfileToDB = new MainProfile { Name = fileName };
                        }
                        else
                        {
                            throw new Exception("Анкета с таким названием уже существует: " + fileName);
                        }
                        
                        foreach (var profile in ProfilesListContent)
                        {
                            Profile profileToDB = null;
                            Questiontype typeToDB = null;
                            List<Answer> answersToDB = null;
                            List<QuestionAnswer> questionAnswersToDB = null;

                            if (db.Profile.SingleOrDefault(p => p.Name == profile.Name) == null)
                            {
                                profileToDB = new Profile { Name = profile.Name, MainProfile = mainProfileToDB };
                            }
                            else
                            {
                                throw new Exception("Часть анкеты с таким названием уже существует: " + profile.Name);
                            }

                            typeToDB = db.Questiontype.SingleOrDefault(t => t.Type == profile.Type);
                            if (typeToDB == null)
                            {
                                typeToDB = new Questiontype { Type = profile.Type };
                            }

                            List<string> answers = GetAnswers(InfoListContent, profile);
                            answers.Add(string.Empty);
                            answersToDB = new List<Answer>();
                            foreach (var answerItem in answers)
                            {
                                answersToDB.Add(new Answer { Content = answerItem, Profile = profileToDB });
                            }

                            db.Answer.AddRange(answersToDB.ToArray());
                            db.SaveChanges();

                            foreach (var questionItem in profile.Questions)
                            {
                                Limits limitsToDB = null;
                                if (typeToDB.Type == "range")
                                {
                                    limitsToDB = new Limits { Start = questionItem.leftLimit, End = questionItem.rightLimit, Profile = profileToDB };
                                }

                                Question questionToDB = new Question 
                                { 
                                    Content = questionItem.Content, 
                                    SerialNumber = questionItem.Id, 
                                    Profile = profileToDB, 
                                    Type = typeToDB, 
                                    Limits = limitsToDB 
                                };

                                questionAnswersToDB = new List<QuestionAnswer>();
                                foreach (var answerItem in answersToDB)
                                {
                                    questionAnswersToDB.Add(new QuestionAnswer { Question = questionToDB, Answer = answerItem });
                                }
                                db.QuestionAnswer.AddRange(questionAnswersToDB.ToArray());
                            }

                            db.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            #endregion

            #region Add Questioned Сделано
            DataTable questionedDataTable = GetDataTableQuestioned();
            Application.DoEvents();
            BulkWriteToDB(questionedDataTable, "questioned");
            #endregion

            #region Add Results
            DataTable resultDataTable = GetDataTableResult();
            Application.DoEvents();
            BulkWriteToDB(resultDataTable, "result");
            #endregion*/
        }

        private void deleteDataBtn_Click(object sender, EventArgs e)
        {
            using (profiletransactionContext db = new profiletransactionContext())
            {
                List<MainProfile> deleteProfiles;
                var mainProfilesInDB = db.MainProfile.Select(p => p).ToList();
                DeleteSettingForm deleteSettingForm = new DeleteSettingForm(mainProfilesInDB);
                deleteSettingForm.ShowDialog();
                switch (deleteSettingForm.DialogResult)
                {
                    case DialogResult.OK:
                        {
                            deleteProfiles = deleteSettingForm.deleteProfiles;
                            foreach (var deleteProfilesItem in deleteProfiles)
                            {
                                db.MainProfile.Remove(deleteProfilesItem);
                            }
                            db.SaveChanges();
                            break;
                        }
                    case DialogResult.Cancel:
                        {
                            break;
                        }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            infoDG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            infoDG.MultiSelect = true;
            /*List<MainProfile> mainProfilesList;
            using (profiletransactionContext db = new profiletransactionContext())
            {
                mainProfilesList = db.MainProfile.OrderBy(p => p.Name).ToList();

                profilesCB.Items.AddRange(mainProfilesList.ToArray());
                if (profilesCB.Items.Count != 0)
                {
                    profilesCB.SelectedIndex = 0;
                }
            }*/
             
        }

        private void profilesCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedProfile = profilesCB.SelectedItem as ExcelProfile;

            infoDG.Columns.Clear();
            infoDG.Rows.Clear();

            infoDG.Columns.Add(CommonService.CreateTextColumn("Номер вопроса", "serielNumber", true));
            infoDG.Columns.Add(CommonService.CreateTextColumn("Вопрос", "question", true));
            if (selectedProfile.Type == "range")
            {
                infoDG.Columns.Add(CommonService.CreateTextColumn("Левая граница", "leftLimit", true));
                infoDG.Columns.Add(CommonService.CreateTextColumn("Правая граница", "rightLimit", true));
            }
            foreach (var answerItem in selectedProfile.Answers)
            {
                infoDG.Columns.Add(CommonService.CreateTextColumn(answerItem, answerItem));
            }
            infoDG.Columns.Add(CommonService.CreateTextColumn("Всего", "all"));
            foreach (var questionItem in selectedProfile.Questions)
            {
                if (selectedProfile.Type == "range")
                {
                    infoDG.Rows.Add(questionItem.Id, questionItem.Content, questionItem.leftLimit, questionItem.rightLimit);
                }
                else
                {
                    infoDG.Rows.Add(questionItem.Id, questionItem.Content);
                }

                int allSumm = 0;
                foreach (var answerItem in selectedProfile.Answers)
                {
                    var countCurrentAnswers = Document.AnswerListContent.Where(a => a.ProfileNum == selectedProfile.Id && a.QuestionNum == questionItem.Id && a.Answer == answerItem).Count();
                    allSumm += countCurrentAnswers;
                    infoDG[answerItem, infoDG.RowCount - 1].Value = countCurrentAnswers;
                }
                infoDG["all", infoDG.RowCount - 1].Value = allSumm;
            }
           
        }

        private void loadDataBtn_Click(object sender, EventArgs e)
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
    }
}
