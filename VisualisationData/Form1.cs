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

namespace VisualisationData
{
    public partial class Form1 : Form
    {
        private List<ExcelQuestionType> InfoListContent { get; set; }
        private List<ExcelAnswer> AnswerListContent { get; set; }
        private List<ExcelProfile> ProfilesListContent { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private List<string> GetAnswers(List<ExcelQuestionType> infoListContent, ExcelProfile profile)
        {
            string answer = infoListContent.Where(q => q.ProfileName == profile.Name).Select(q => q.Answers).ToList()[0];
            List<string> answers = new List<string>();
            switch (profile.Type)
            {
                case "range":
                    {
                        var matches = Regex.Match(answer, "^от(-?\\d+) *до *(-?\\d+)$");
                        var a = matches.Groups[1].Value;
                        int start = Convert.ToInt32(matches.Groups[1].Value);
                        int end = Convert.ToInt32(matches.Groups[2].Value);
                        answers = new List<string>();
                        for (int i = start; i <= end; i++)
                        {
                            answers.Add(i.ToString());
                        }
                        break;
                    }
                case "radio":
                    {
                        answers = answer.Split('/').ToList();
                        break;
                    }
                case "checbox":
                    {
                        answers = answer.Split(';').ToList();
                        break;
                    }
            }

            return answers;
        }

        private void downloadDataBtn_Click(object sender, EventArgs e)
        {
            var profilesMap = new Dictionary<int, int>();
            var questionedsMap = new Dictionary<string, int>();
            var answersMap = new Dictionary<string, int>();
            var questionsMap = new Dictionary<string, int>();
            var questionAnswersMap = new Dictionary<string, int>();

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
                        InfoListContent = downloadSettingForm.infoListContent;
                        AnswerListContent = downloadSettingForm.answerListContent;
                        ProfilesListContent = downloadSettingForm.profilesListContent;
                        break;
                    }
                case DialogResult.Cancel:
                    {
                        break;
                    }
            }

            #region Add Profile
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

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("id");
            dataTable.Columns.Add("number");
           
            foreach (var answerItem in AnswerListContent)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow["id"] = null;
                dataRow["number"] = answerItem.Id;
                dataTable.Rows.Add(dataRow);
            }
            dataTable = dataTable.DefaultView.ToTable(true, new string[] { "id", "number" });

            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();
                using (var bulk = new BulkOperation(conn))
                {
                    bulk.DestinationTableName = "questioned";

                    bulk.BulkInsert(dataTable);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            using(profiletransactionContext db = new profiletransactionContext())
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
                    //var questionAnswerId = db.QuestionAnswer.SingleOrDefault(q => q.QuestionId == questionId && q.AnswerId == answerId).Id;

                    DataRow dataRow = resultsTable.NewRow();
                    dataRow["id"] = null;
                    dataRow["questioned_id"] = questionedId;
                    dataRow["question_answer_id"] = questionAnswerId;
                    dataRow["profile_id"] = profileId;
                    resultsTable.Rows.Add(dataRow);
                }
            }

            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();
                using (var bulk = new BulkOperation(conn))
                {
                    bulk.DestinationTableName = "result";

                    bulk.BulkInsert(resultsTable);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            /*foreach (var answerItem in AnswerListContent)
                        {
                            var questionedToDB = db.Questioned.SingleOrDefault(q => q.Number == answerItem.Id);
                            if (questionedToDB == null)
                            {
                                questionedToDB = new Questioned { Number = answerItem.Id };
                                db.Questioned.Add(questionedToDB);
                                db.SaveChanges();
                            }
                           
                            var profileName = InfoListContent.SingleOrDefault(i => i.Id == answerItem.ProfileNum).ProfileName;
                            var profileInDb = db.Profile.SingleOrDefault(p => p.Name == profileName);

                            var questionInDB = db.Question.SingleOrDefault(q => q.SerialNumber == answerItem.QuestionNum && q.ProfileId == profileInDb.Id);
                            var answerInDB = db.Answer.SingleOrDefault(a => a.Content == answerItem.Answer && a.ProfileId == profileInDb.Id);
                            
                            var questionAnswerToDB = db.QuestionAnswer.SingleOrDefault(qa => qa.QuestionId == questionInDB.Id && qa.AnswerId == answerInDB.Id);

                            Result resultToDB = new Result { QuestionAnswer = questionAnswerToDB, Questioned = questionedToDB, Profile = profileInDb };
                            db.Result.Add(resultToDB);
                            Application.DoEvents();

                        }

                        db.SaveChanges();*/

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
    }
}
