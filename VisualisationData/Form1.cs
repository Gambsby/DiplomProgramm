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
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filePath = openFileDialog.FileName;
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

            using (profilesfiscContext db = new profilesfiscContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var profile in ProfilesListContent)
                        {
                            #region Add Profiles
                            var profileInDB = db.Profile.SingleOrDefault(p => p.Name == profile.Name);
                            if (profileInDB == null)
                            {
                                Profile profileToDB = new Profile { Name = profile.Name };
                                db.Profile.Add(profileToDB);
                                db.SaveChanges();
                            }
                            #endregion

                            #region Add QuestionsType
                            var typeInDB = db.Questiontype.SingleOrDefault(t => t.Type == profile.Type);
                            if (typeInDB == null)
                            {
                                Questiontype typeToDB = new Questiontype { Type = profile.Type };
                                db.Questiontype.Add(typeToDB);
                                db.SaveChanges();
                            }
                            #endregion

                            #region Add Answers
                            List<string> answers = GetAnswers(InfoListContent, profile);
                            foreach (var answerItem in answers)
                            {
                                var answerInDB = db.Answer.SingleOrDefault(a => a.Content == answerItem);
                                if (answerInDB == null)
                                {
                                    Answer answerToDB = new Answer { Content = answerItem };
                                    db.Answer.Add(answerToDB);
                                    db.SaveChanges();
                                }
                            }
                            #endregion

                            #region Add Questions
                            foreach (var questionItem in profile.Questions)
                            {
                                Limits limitsToDB = null;
                                typeInDB = db.Questiontype.SingleOrDefault(t => t.Type == profile.Type);
                                Question questionInDB;
                                if (typeInDB.Type == "range")
                                {
                                    limitsToDB = new Limits { Start = questionItem.leftLimit, End = questionItem.rightLimit };
                                    questionInDB = db.Question.SingleOrDefault(q => q.Content == questionItem.Content && q.Limits.Start == limitsToDB.Start && q.Limits.End == limitsToDB.End);
                                }
                                else
                                {
                                    questionInDB = db.Question.SingleOrDefault(q => q.Content == questionItem.Content);
                                }

                                if (questionInDB == null)
                                {
                                    profileInDB = db.Profile.SingleOrDefault(p => p.Name == profile.Name);
                                    Question questionToDb = new Question
                                    {
                                        Content = questionItem.Content,
                                        Profile = profileInDB,
                                        SerialNumber = questionItem.Id,
                                        Type = typeInDB,
                                        Limits = limitsToDB
                                    };

                                    foreach (var answerItem in answers)
                                    {
                                        var answerToDB = db.Answer.SingleOrDefault(a => a.Content == answerItem);
                                        QuestionAnswer questionAnswerToDB = new QuestionAnswer { Question = questionToDb, Answer = answerToDB };
                                        db.QuestionAnswer.Add(questionAnswerToDB);
                                        db.SaveChanges();
                                    }
                                }
                            }
                            #endregion

                        }

                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {

                        transaction.Rollback();
                    }
                }
            }
        }

        private void deleteDataBtn_Click(object sender, EventArgs e)
        {
            using (profilesfiscContext db = new profilesfiscContext())
            {
                List<Profile> deleteProfiles;
                var profilesInDB = db.Profile.Select(p => p).ToList();
                DeleteSettingForm deleteSettingForm = new DeleteSettingForm(profilesInDB);
                deleteSettingForm.ShowDialog();
                switch (deleteSettingForm.DialogResult)
                {
                    case DialogResult.OK:
                        {
                            deleteProfiles = deleteSettingForm.deleteProfiles;
                            //Тут должно быть удаление
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
