﻿using CsvHelper;
using CsvHelper.Configuration;
using MySql.Data.MySqlClient;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VisualisationData.Excel;
using VisualisationData.Models;
using Z.BulkOperations;

namespace VisualisationData.Services
{
    class DataManipulationService
    {
        public static void SaveProfileToDB(profileContext db, Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction tr, Excel.ExcelDocument document)
        {
            Dictionary<string, QType> questionTypeMap = new Dictionary<string, QType>();
            questionTypeMap = db.QType.Select(q => q).ToDictionary(q => q.Type, q => q);

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
                    qType = new QType { Type = profileItem.Type };
                    questionTypeMap.Add(qType.Type, qType);
                }

                Profile profile = mainProfile.Profile.SingleOrDefault(p => p.Name == profileItem.Name);
                if (profile == null)
                {
                    profile = new Profile { SerialNumber = profileItem.Id, Name = profileItem.Name, Type = qType, Answer = profileItem.Answers, MainProfile = mainProfile };
                    mainProfile.Profile.Add(profile);
                }
                else
                {
                    throw new Exception("В файле не может содержаться несколько анкет с одинаковым именем!");
                }

                foreach (var questionItem in profileItem.Questions)
                {
                    Question question = null;
                    if (qType.Type == "range")
                    {
                        question = new Question
                        {
                            SerialNumber = questionItem.Id,
                            Content = questionItem.Content,
                            LeftLimit = questionItem.LeftLimit,
                            RightLimit = questionItem.RightLimit
                        };
                    }
                    else
                    {
                        question = new Question
                        {
                            SerialNumber = questionItem.Id,
                            Content = questionItem.Content,
                            LeftLimit = null,
                            RightLimit = null
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
                db.Entry(profileItem).Collection(t => t.Question).Load();
            }

            Dictionary<string, Questioned> questionedMap = new Dictionary<string, Questioned>();
            DataTable questionedDT = new DataTable();
            questionedDT.Columns.Add(new DataColumn("id"));
            questionedDT.Columns.Add(new DataColumn("number"));
            questionedDT.Columns.Add(new DataColumn("main_profile_id"));
            foreach (var resultItem in document.AnswerListContent)
            {
                if (!questionedMap.ContainsKey(resultItem.Id))
                {
                    questionedMap.Add(resultItem.Id, new Questioned { Number = resultItem.Id, MainProfile = mainProfile });
                    DataRow row = questionedDT.NewRow();
                    row["id"] = null;
                    row["number"] = resultItem.Id;
                    row["main_profile_id"] = mainProfile.Id;
                    questionedDT.Rows.Add(row);
                }
            }
            BulkWriteToDB(questionedDT, "questioned");
            Application.DoEvents();

            questionedMap = db.Questioned.Where(q => q.MainProfile == mainProfile).ToDictionary(q => q.Number, q => q);

            DataTable resultDT = new DataTable();
            resultDT.Columns.Add(new DataColumn("id"));
            resultDT.Columns.Add(new DataColumn("profile_id"));
            resultDT.Columns.Add(new DataColumn("question_id"));
            resultDT.Columns.Add(new DataColumn("answer"));
            resultDT.Columns.Add(new DataColumn("questioned_id"));
            foreach (var resultItem in document.AnswerListContent)
            {
                Profile profile = profiles.SingleOrDefault(p => p.SerialNumber == resultItem.ProfileNum);
                Question question = profile.Question.SingleOrDefault(q => q.SerialNumber == resultItem.QuestionNum);
                Questioned questioned = questionedMap[resultItem.Id];

                DataRow row = resultDT.NewRow();
                row["id"] = null;
                row["profile_id"] = profile.Id;
                row["question_id"] = question.Id;
                row["answer"] = resultItem.Answer;
                row["questioned_id"] = questioned.Id;
                resultDT.Rows.Add(row);

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

        public static void SaveExcel(string infoFileName, string resultFileName, Dictionary<string, ExcelProfile> excelProfileMap, ExcelDocument document, string filePath)
        {

            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Properties.Author = "User";
                excelPackage.Workbook.Properties.Title = document.DocumentName;
                excelPackage.Workbook.Properties.Created = DateTime.Now;

                ExcelWorksheet infoSheet = excelPackage.Workbook.Worksheets.Add(infoFileName);
                int rowInfoNumber = 2;
                foreach (var profileItem in excelProfileMap)
                {
                    string sheetName = profileItem.Key;
                    ExcelProfile profile = profileItem.Value;

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

                    questionSheet.Cells[questionSheet.Dimension.Address].AutoFitColumns();
                }

                ExcelWorksheet resultSheet = excelPackage.Workbook.Worksheets.Add(resultFileName);
                resultSheet.Cells["A1"].Value = "id";
                resultSheet.Cells["B1"].Value = "анкета";
                resultSheet.Cells["C1"].Value = "номер вопроса";
                resultSheet.Cells["D1"].Value = "ответ";

                int rowResultNumber = 2;
                foreach (var answerItem in document.AnswerListContent)
                {
                    resultSheet.Cells["A" + rowResultNumber].Value = answerItem.Id;
                    resultSheet.Cells["B" + rowResultNumber].Value = answerItem.ProfileNum;
                    resultSheet.Cells["C" + rowResultNumber].Value = answerItem.QuestionNum;
                    resultSheet.Cells["D" + rowResultNumber].Value = answerItem.Answer;

                    rowResultNumber++;
                }

                infoSheet.Cells[infoSheet.Dimension.Address].AutoFitColumns();
                resultSheet.Cells[resultSheet.Dimension.Address].AutoFitColumns();

                FileInfo fi = new FileInfo(filePath);

                excelPackage.SaveAs(fi);
            }
        }

        public static void SaveCSV(string infoFileName, string resultFileName, Dictionary<string, ExcelProfile> excelProfileMap, ExcelDocument document)
        {
            List<List<object>> questionFiles = new List<List<object>>();
            List<string> questionFilesName = new List<string>();

            List<object> infoFile = new List<object>();
            foreach (var profileItem in excelProfileMap)
            {
                string sheetName = profileItem.Key;
                ExcelProfile profile = profileItem.Value;

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
            foreach (var resultItem in document.AnswerListContent)
            {
                resultFile.Add(new { ID = resultItem.GetId(), Profile = resultItem.GetProfileNum(), QuestionNum = resultItem.GetQuestionNum(), Answer = resultItem.GetAnswer() });
            }

            string selectedPath = CommonService.GetFolderPath();
            string dirName = selectedPath + "\\" + document.DocumentName;

            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
            try
            {
                WriteFile(dirName + "\\" + infoFileName + ".csv", infoFile);
                WriteFile(dirName + "\\" + resultFileName + ".csv", resultFile);

                for (int i = 0; i < questionFiles.Count; i++)
                {
                    WriteFile(dirName + "\\" + questionFilesName[i] + ".csv", questionFiles[i]);
                }
            }
            catch (Exception ex)
            {
                Directory.Delete(dirName, true);
                throw ex;
            }
        }

        private static void WriteFile(string path, List<object> value)
        {
            try
            {
                using (var writer = new StreamWriter(path))
                {
                    using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ":", IgnoreReferences = true, HasHeaderRecord = false }))
                    {

                        csv.WriteRecords(value);
                    }
                }
            }
            catch (Exception)
            {

                throw new Exception("Ошибка при записи в файл!");
            }
        }

        public static void DeleteMainProfile(List<MainProfile> deletedMainProfiles)
        {
            using (profileContext db = new profileContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var mainProfileItem in deletedMainProfiles)
                        {
                            db.MainProfile.Remove(mainProfileItem);
                        }
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw new Exception("При удалении произошла ошибка. Попытайтесь снова.");
                    }
                }
            }
        }

        public static ExcelDocument LoadMainProfileDB(MainProfile mainProfile)
        {
            List<ExcelResult> answerListContent = new List<ExcelResult>();
            List<ExcelProfile> profilesListContent = new List<ExcelProfile>();

            using (profileContext db = new profileContext())
            {
                mainProfile = db.MainProfile.SingleOrDefault(p => p == mainProfile);
                db.Entry(mainProfile).Collection(t => t.Profile).Load();
                db.Entry(mainProfile).Collection(t => t.Questioned).Load();
                foreach (var profileItem in mainProfile.Profile)
                {
                    db.Entry(profileItem).Collection(t => t.Question).Load();
                    db.Entry(profileItem).Collection(t => t.Result).Load();
                    db.Entry(profileItem).Reference(t => t.Type).Load();
                    List<ExcelQuestion> questions = new List<ExcelQuestion>();
                    foreach (var questionItem in profileItem.Question)
                    {
                        if (questionItem.LeftLimit == null && questionItem.RightLimit == null)
                        {
                            questions.Add(new ExcelQuestion { Id = questionItem.SerialNumber, Content = questionItem.Content, LeftLimit = "", RightLimit = "" });
                        }
                        else
                        {
                            questions.Add(new ExcelQuestion { Id = questionItem.SerialNumber, Content = questionItem.Content, LeftLimit = questionItem.LeftLimit, RightLimit = questionItem.RightLimit });
                        }
                    }
                    ExcelProfile excelProfile = new ExcelProfile { Id = profileItem.SerialNumber, Answers = profileItem.Answer, Name = profileItem.Name, Type = profileItem.Type.Type, Questions = questions };
                    profilesListContent.Add(excelProfile);

                    foreach (var resultItem in profileItem.Result)
                    {
                        string questionedId = mainProfile.Questioned.SingleOrDefault(q => q.Id == resultItem.QuestionedId).Number;
                        ExcelResult excelResult = new ExcelResult
                        {
                            Id = questionedId,
                            ProfileNum = resultItem.Profile.SerialNumber,
                            QuestionNum = resultItem.Question.SerialNumber,
                            Answer = resultItem.Answer
                        };
                        answerListContent.Add(excelResult);
                    }
                }
                return new ExcelDocument { DocumentName = mainProfile.Name, AnswerListContent = answerListContent, ProfilesListContent = profilesListContent };
            }
        }

        public static ExcelDocument LoadMainProfileExcel(string filePath, string infoFileName, string resultFileName, Dictionary<string, string> excelProfileMap)
        {
            List<ExcelQuestionType> infoListContent;
            List<ExcelResult> answerListContent;
            List<ExcelProfile> profilesListContent = new List<ExcelProfile>();

            infoListContent = GetExcelService.GetProfileNamesEP(filePath, infoFileName);
            answerListContent = GetExcelService.GetResultsEP(filePath, resultFileName);

            foreach (var item in excelProfileMap)
            {
                ExcelQuestionType profileInfo = infoListContent.SingleOrDefault(info => info.ProfileName == item.Key);
                string profileType = profileInfo.GetProfileType();
                List<ExcelQuestion> questions = GetExcelService.GetQuestionsEP(filePath, item.Value);
                ExcelProfile excelProfile = new ExcelProfile
                {
                    Id = profileInfo.Id,
                    Name = profileInfo.ProfileName,
                    Type = profileType,
                    Answers = profileInfo.Answers,
                    Questions = questions
                };
                profilesListContent.Add(excelProfile);
            }

            string documentName = Path.GetFileNameWithoutExtension(filePath);
            return new ExcelDocument
            {
                DocumentName = documentName,
                AnswerListContent = answerListContent,
                ProfilesListContent = profilesListContent
            };
        }

        public static void SaveAllQuestionInfoExcel(ExcelDocument document, string filePath)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                int column = 0;
                excelPackage.Workbook.Properties.Author = "User";
                excelPackage.Workbook.Properties.Title = document.DocumentName;
                excelPackage.Workbook.Properties.Created = DateTime.Now;

                ExcelWorksheet infoSheet = excelPackage.Workbook.Worksheets.Add("Результаты");
                int rowInfoNumber = 1;

                foreach (var profileItem in document.ProfilesListContent)
                {
                    infoSheet.Cells[rowInfoNumber, 1].Value = profileItem.Name;
                    rowInfoNumber++;

                    bool firstRow = true;
                    foreach (var questionItem in profileItem.Questions)
                    {
                        var questionInfo = ProccesingDataService.GetQuestionInfo(questionItem, profileItem, document);
                        var points = questionInfo.Item1;
                        var respondedCount = questionInfo.Item2;
                        var questionedCount = questionInfo.Item3;

                        if (firstRow)
                        {
                            column = WriteRowExcel(new string[] { "Номер вопроса", "Вопрос", "Число ответивших", "Число прошедших" }, points.Keys.ToArray(), infoSheet, 1, rowInfoNumber);
                            if (points.ContainsKey("другое"))
                            {
                                var questionOpenInfo = ProccesingDataService.GetOpenInfo(questionItem, profileItem, document); ;
                                var openPoints = questionOpenInfo.Item1;
                                WriteRowExcel(new string[] { }, openPoints.Keys.ToArray(), infoSheet, column, rowInfoNumber);
                            }

                            rowInfoNumber++;
                            firstRow = false;
                        }

                        string[] pointsValue = points.Values.Select(x => x.ToString()).ToArray();
                        column = WriteRowExcel(new string[] { questionItem.Id.ToString(), questionItem.GetForSeries(), respondedCount.ToString(), questionedCount.ToString() }, pointsValue, infoSheet, 1, rowInfoNumber);
                        if (points.ContainsKey("другое"))
                        {
                            var questionOpenInfo = ProccesingDataService.GetOpenInfo(questionItem, profileItem, document); ;
                            var openPoints = questionOpenInfo.Item1;
                            string[] openPointsValue = openPoints.Values.Select(x => x.ToString()).ToArray();
                            column = WriteRowExcel(new string[] { }, openPointsValue, infoSheet, column, rowInfoNumber);
                        }

                        rowInfoNumber++;
                    }
                    rowInfoNumber++;
                }


                infoSheet.Cells[infoSheet.Dimension.Address].AutoFitColumns();
                infoSheet.Cells[infoSheet.Dimension.Address].AutoFitColumns();
                infoSheet.Column(2).Width = 125;
                infoSheet.Column(2).Style.WrapText = true;

                FileInfo fi = new FileInfo(filePath);

                excelPackage.SaveAs(fi);
            }
        }

        public static void SaveQuestionInfoExcel(ExcelQuestion excelQuestion, ExcelProfile excelProfile, ExcelDocument document, string filePath)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                var questionInfo = ProccesingDataService.GetQuestionInfo(excelQuestion, excelProfile, document);
                var points = questionInfo.Item1;
                var respondedCount = questionInfo.Item2;
                var questionedCount = questionInfo.Item3;

                excelPackage.Workbook.Properties.Author = "User";
                excelPackage.Workbook.Properties.Title = excelQuestion.GetForSeries();
                excelPackage.Workbook.Properties.Created = DateTime.Now;

                ExcelWorksheet infoSheet = excelPackage.Workbook.Worksheets.Add("Результаты");

                int rowInfoNumber = 1;

                infoSheet.Cells[rowInfoNumber, 1].Value = excelProfile.Name;
                rowInfoNumber++;

                int column = WriteRowExcel(new string[] { "Номер вопроса", "Вопрос", "Число ответивших", "Число прошедших" }, points.Keys.ToArray(), infoSheet, 1, rowInfoNumber);
                if (points.ContainsKey("другое"))
                {
                    var questionOpenInfo = ProccesingDataService.GetOpenInfo(excelQuestion, excelProfile, document); ;
                    var openPoints = questionOpenInfo.Item1;
                    WriteRowExcel(new string[] { }, openPoints.Keys.ToArray(), infoSheet, column, rowInfoNumber);
                }
                rowInfoNumber++;

                //-----------------------------------------------
                string[] pointsValue = points.Values.Select(x => x.ToString()).ToArray();
                column = WriteRowExcel(new string[] { excelQuestion.Id.ToString(), excelQuestion.GetForSeries(), respondedCount.ToString(), questionedCount.ToString() }, pointsValue, infoSheet, 1, rowInfoNumber);
                if (points.ContainsKey("другое"))
                {
                    var questionOpenInfo = ProccesingDataService.GetOpenInfo(excelQuestion, excelProfile, document); ;
                    var openPoints = questionOpenInfo.Item1;
                    string[] openPointsValue = openPoints.Values.Select(x => x.ToString()).ToArray();
                    column = WriteRowExcel(new string[] { }, openPointsValue, infoSheet, column, rowInfoNumber);
                }


                infoSheet.Cells[infoSheet.Dimension.Address].AutoFitColumns();
                infoSheet.Column(2).Width = 125;
                infoSheet.Column(2).Style.WrapText = true;
                FileInfo fi = new FileInfo(filePath);

                excelPackage.SaveAs(fi);
            }
        }

        private static int WriteRowExcel(string[] values, string[] points, ExcelWorksheet infoSheet, int column, int row)
        {
            if (values.Length != 0)
            {
                infoSheet.Cells[row, column].Value = values[0];
                column++;
                infoSheet.Cells[row, column].Value = values[1];
                column++;
            }

            foreach (var pointItem in points)
            {
                infoSheet.Cells[row, column].Value = pointItem;
                column++;
            }

            if (values.Length != 0)
            {
                infoSheet.Cells[row, column].Value = values[2];
                column++;
                infoSheet.Cells[row, column].Value = values[3];
                column++;
            }

            return column;
        }
    }
}
