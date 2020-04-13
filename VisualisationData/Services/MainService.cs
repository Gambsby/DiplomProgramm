using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualisationData.Models;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;
using Z.BulkOperations;

namespace VisualisationData.Services
{
    class MainService
    {
        public static void InitDataGrid(string type, DataGridView dataGrid)
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

        public static void SaveProfileToDB(profileContext db, Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction tr, Excel.ExcelDocument document)
        {
            Dictionary<string, QType> questionTypeMap = new Dictionary<string, QType>();
            questionTypeMap = db.QType.Select(q => q).ToDictionary(q => q.Name, q => q);

            MainProfile mainProfile = db.MainProfile.SingleOrDefault(m => m.Name == document.DocumentName);
            if (mainProfile == null)
            {
                mainProfile = new MainProfile { Name = document.DocumentName };
            }
            else
            {
                throw new Exception("Файл с таким именем уже был сохранен!");
            }

            foreach (var profileItem in document.ProfilesListContent)
            {
                QType qType = null;
                if (questionTypeMap.ContainsKey(profileItem.Type))
                {
                    qType = questionTypeMap[profileItem.Type];
                }
                else
                {
                    qType = new QType { Name = profileItem.Type };
                    questionTypeMap.Add(qType.Name, qType);
                }

                Profile profile = mainProfile.Profile.SingleOrDefault(p => p.Name == profileItem.Name);
                if (profile == null)
                {
                    profile = new Profile { SerialNumber = profileItem.Id, Name = profileItem.Name, Type = qType, MainProfile = mainProfile };
                    mainProfile.Profile.Add(profile);
                }
                else
                {
                    throw new Exception("В файле не может содержаться несколько анкет с одинаковым именем!");
                }

                foreach (var answerItem in profileItem.GetProfileAnswers())
                {
                    profile.Answer.Add(new Answer { Content = answerItem });
                    //answers.Add(new Answer { Content = answerItem, Profile = profile });
                }
                foreach (var questionItem in profileItem.Questions)
                {
                    Question question = null;
                    if (qType.Name == "range")
                    {
                        question = new Question
                        {
                            SerialNumber = questionItem.Id,
                            Content = questionItem.Content,
                            Limits = new Limits
                            {
                                LeftLimit = questionItem.LeftLimit,
                                RightLimit = questionItem.RightLimit,
                                Profile = profile
                            }
                        };
                    }
                    else
                    {
                        question = new Question
                        {
                            SerialNumber = questionItem.Id,
                            Content = questionItem.Content,
                            Limits = null
                        };
                    }
                    profile.Question.Add(question);
                }
            }
            db.MainProfile.Add(mainProfile);
            db.SaveChanges();
            Application.DoEvents();
        }

        public static void SaveResultToDB(profileContext db, Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction tr, Excel.ExcelDocument document)
        {
            MainProfile mainProfile = db.MainProfile.SingleOrDefault(m => m.Name == document.DocumentName);
            if (mainProfile == null)
            {
                throw new Exception("Ошибка при сохранении!");
            }

            List<Profile> profiles = db.Profile.Where(p => p.MainProfile == mainProfile).ToList();
            foreach (var profileItem in profiles)
            {
                db.Entry(profileItem).Collection(t => t.Answer).Load();
                db.Entry(profileItem).Collection(t => t.Question).Load();
            }

            Dictionary<string, Questioned> questionedMap = new Dictionary<string, Questioned>();
            DataTable questionedDT = new DataTable();
            questionedDT.Columns.Add(new DataColumn("id"));
            questionedDT.Columns.Add(new DataColumn("number"));
            questionedDT.Columns.Add(new DataColumn("main_profile_id"));
            foreach (var answerItem in document.AnswerListContent)
            {
                if (!questionedMap.ContainsKey(answerItem.Id))
                {
                    questionedMap.Add(answerItem.Id, new Questioned { Number = answerItem.Id, MainProfile = mainProfile });
                    DataRow row = questionedDT.NewRow();
                    row["id"] = null;
                    row["number"] = answerItem.Id;
                    row["main_profile_id"] = mainProfile.Id;
                    questionedDT.Rows.Add(row);
                }
            }
            BulkWriteToDB(questionedDT, "questioned");
            Application.DoEvents();

            questionedMap = db.Questioned.Where(q => q.MainProfile == mainProfile).ToDictionary(q => q.Number, q => q);

            DataTable resultDT = new DataTable();
            resultDT.Columns.Add(new DataColumn("id"));
            resultDT.Columns.Add(new DataColumn("profile_id"));//+
            resultDT.Columns.Add(new DataColumn("question_id"));//+
            resultDT.Columns.Add(new DataColumn("answer_id"));//+
            resultDT.Columns.Add(new DataColumn("questioned_id"));//++
            resultDT.Columns.Add(new DataColumn("open_answer"));
            foreach (var resultItem in document.AnswerListContent)
            {
                Profile profile = profiles.SingleOrDefault(p => p.SerialNumber == resultItem.ProfileNum);
                Question question = profile.Question.SingleOrDefault(q => q.SerialNumber == resultItem.QuestionNum);
                Questioned questioned = questionedMap[resultItem.Id];

                if (string.IsNullOrEmpty(resultItem.Answer))
                {
                    DataRow row = resultDT.NewRow();
                    row["id"] = null;
                    row["profile_id"] = profile.Id;
                    row["question_id"] = question.Id;
                    row["answer_id"] = null;
                    row["questioned_id"] = questioned.Id;
                    row["open_answer"] = null;
                    resultDT.Rows.Add(row);
                }
                else
                {
                    foreach (var answerItem in resultItem.GetAnswers())
                    {

                        Answer answer = profile.Answer.SingleOrDefault(a => a.Content == answerItem);

                        DataRow row = resultDT.NewRow();
                        row["id"] = null;
                        row["profile_id"] = profile.Id;
                        row["question_id"] = question.Id;
                        row["questioned_id"] = questioned.Id;

                        if (answer == null)
                        {
                            row["open_answer"] = answerItem;
                        }
                        else
                        {
                            row["answer_id"] = answer.Id;
                        }
                        resultDT.Rows.Add(row);
                    }
                }
                if (resultDT.Rows.Count > 30000)
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
        }

        private static void BulkWriteToDB(DataTable dataTable, string tableName)
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
    }
}
