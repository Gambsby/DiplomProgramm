using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VisualisationData.Excel;

namespace VisualisationData.Services
{
    class ExcelService
    {
        private static string GetClearString(string source)
        {
            return Regex.Replace(source, "\\r\\n", " ");
        }

        public static List<ExcelQuestionType> GetProfileNames(string pathToExcelFile, string sheetName)
        {
            List<ExcelQuestionType> excelQuestionTypes = new List<ExcelQuestionType>();

            ConnectionExcel ConxObject = new ConnectionExcel(pathToExcelFile);
            var ids = (from e in ConxObject.UrlConnexion.WorksheetNoHeader(sheetName) select e[0].Value).ToList();
            var profileNames = (from e in ConxObject.UrlConnexion.WorksheetNoHeader(sheetName) select e[1].Value).ToList();
            var answers = (from e in ConxObject.UrlConnexion.WorksheetNoHeader(sheetName) select e[5].Value).ToList();

            if (ids.Count() == profileNames.Count() && profileNames.Count() == answers.Count())
            {
                for (int i = 0; i < ids.Count(); i++)
                {
                    int id;
                    try
                    {
                        id = Convert.ToInt32(ids[i]);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Id is not int");
                    }
                    ExcelQuestionType type = new ExcelQuestionType()
                    {
                        Id = id,
                        ProfileName = profileNames[i].ToString(),
                        Answers = answers[i].ToString()
                    };
                    excelQuestionTypes.Add(type);
                }
            }
            else
            {
                throw new Exception("Difference length");
            }

            return excelQuestionTypes;
        }

        public static List<ExcelQuestion> GetQuestions(string pathToExcelFile, string sheetName, string profileType)
        {
            List<ExcelQuestion> excelProfile = new List<ExcelQuestion>();

            ConnectionExcel ConxObject = new ConnectionExcel(pathToExcelFile);
            var ids = (from e in ConxObject.UrlConnexion.WorksheetNoHeader(sheetName) select e[0].Value).ToList();
            var question = (from e in ConxObject.UrlConnexion.WorksheetNoHeader(sheetName) select e[1].Value).ToList();
            List<object> leftLimits = null;
            List<object> rightLimits = null;
            if (profileType == "range")
            {
                leftLimits = (from e in ConxObject.UrlConnexion.WorksheetNoHeader(sheetName) select e[2].Value).ToList();
                rightLimits = (from e in ConxObject.UrlConnexion.WorksheetNoHeader(sheetName) select e[3].Value).ToList();
            }

            if (ids.Count() == question.Count())
            {
                for (int i = 0; i < ids.Count(); i++)
                {
                    int id;
                    try
                    {
                        id = Convert.ToInt32(ids[i]);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Id is not int");
                    }
                    ExcelQuestion profile;
                    if (leftLimits == null && rightLimits == null)
                    {
                        profile = new ExcelQuestion()
                        {
                            Id = id,
                            Content = GetClearString(question[i].ToString()),
                            LeftLimit = null,
                            RightLimit = null
                        };
                    }
                    else
                    {
                        profile = new ExcelQuestion()
                        {
                            Id = id,
                            Content = GetClearString(question[i].ToString()),
                            LeftLimit = GetClearString(leftLimits[i].ToString()),
                            RightLimit = GetClearString(rightLimits[i].ToString())
                        };
                    }

                    excelProfile.Add(profile);
                }
            }
            else
            {
                throw new Exception("Difference length");
            }

            return excelProfile;
        }

        public static List<ExcelResult> GetResults(string pathToExcelFile, string sheetName)
        {
            List<ExcelResult> excelAnswer = new List<ExcelResult>();

            ConnectionExcel ConxObject = new ConnectionExcel(pathToExcelFile);
            var ids = (from e in ConxObject.UrlConnexion.WorksheetNoHeader(sheetName) select e[0].Value).ToList();
            var profileNums = (from e in ConxObject.UrlConnexion.WorksheetNoHeader(sheetName) select e[1].Value).ToList();
            var questionNums = (from e in ConxObject.UrlConnexion.WorksheetNoHeader(sheetName) select e[2].Value).ToList();
            var answers = (from e in ConxObject.UrlConnexion.WorksheetNoHeader(sheetName) select e[3].Value).ToList();

            ids.RemoveAt(0);
            profileNums.RemoveAt(0);
            questionNums.RemoveAt(0);
            answers.RemoveAt(0);

            if (ids.Count() == profileNums.Count() && profileNums.Count() == questionNums.Count() && questionNums.Count() == answers.Count())
            {
                for (int i = 0; i < ids.Count(); i++)
                {
                    int profileNum;
                    int questionNum;
                    try
                    {
                        profileNum = Convert.ToInt32(profileNums[i]);
                        questionNum = Convert.ToInt32(questionNums[i]);

                    }
                    catch (Exception)
                    {
                        throw new Exception("Id is not int");
                    }

                    ExcelResult answer = new ExcelResult()
                    {
                        Id = ids[i].ToString(),
                        ProfileNum = profileNum,
                        QuestionNum = questionNum,
                        Answer = answers[i].ToString().ToLower()
                    };
                    excelAnswer.Add(answer);
                }
            }
            else
            {
                throw new Exception("Difference length");
            }

            return excelAnswer;
        }



        public static List<string> GetColumn(int startRow, int column, string pathToExcelFile, string sheetName)
        {
            List<string> columnContent = new List<string>();
            using (var excelPack = new ExcelPackage())
            {
                using (var stream = File.OpenRead(pathToExcelFile))
                {
                    excelPack.Load(stream);
                }
                var ws = excelPack.Workbook.Worksheets[sheetName];
                foreach (var rowItem in ws.Cells[startRow, column, ws.Dimension.End.Row, column])
                {
                    columnContent.Add(rowItem.Text);
                }
            }
            return columnContent;
        }

        public static List<ExcelQuestionType> GetProfileNamesEP(string pathToExcelFile, string sheetName)
        {
            List<ExcelQuestionType> excelQuestionTypes = new List<ExcelQuestionType>();

            ConnectionExcel ConxObject = new ConnectionExcel(pathToExcelFile);
            var ids = GetColumn(2, 1, pathToExcelFile, sheetName);
            var profileNames = GetColumn(2, 2, pathToExcelFile, sheetName);
            var answers = GetColumn(2, 6, pathToExcelFile, sheetName);

            if (ids.Count() == profileNames.Count() && profileNames.Count() == answers.Count())
            {
                for (int i = 0; i < ids.Count(); i++)
                {
                    int id;
                    try
                    {
                        id = Convert.ToInt32(ids[i]);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Id is not int");
                    }
                    ExcelQuestionType type = new ExcelQuestionType()
                    {
                        Id = id,
                        ProfileName = profileNames[i].ToString(),
                        Answers = answers[i].ToString()
                    };
                    excelQuestionTypes.Add(type);
                }
            }
            else
            {
                throw new Exception("Difference length");
            }

            return excelQuestionTypes;
        }

        public static List<ExcelQuestion> GetQuestionsEP(string pathToExcelFile, string sheetName, string profileType)
        {
            List<ExcelQuestion> excelProfile = new List<ExcelQuestion>();

            ConnectionExcel ConxObject = new ConnectionExcel(pathToExcelFile);
            var ids = GetColumn(1, 1, pathToExcelFile, sheetName);
            var question = GetColumn(1, 2, pathToExcelFile, sheetName);
            List<string> leftLimits = null;
            List<string> rightLimits = null;
            if (profileType == "range")
            {
                leftLimits = GetColumn(1, 3, pathToExcelFile, sheetName);
                rightLimits = GetColumn(1, 4, pathToExcelFile, sheetName);
            }

            if (ids.Count() == question.Count())
            {
                for (int i = 0; i < ids.Count(); i++)
                {
                    int id;
                    try
                    {
                        id = Convert.ToInt32(ids[i]);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Id is not int");
                    }
                    ExcelQuestion profile;
                    if (leftLimits == null && rightLimits == null)
                    {
                        profile = new ExcelQuestion()
                        {
                            Id = id,
                            Content = GetClearString(question[i].ToString()),
                            LeftLimit = null,
                            RightLimit = null
                        };
                    }
                    else
                    {
                        profile = new ExcelQuestion()
                        {
                            Id = id,
                            Content = GetClearString(question[i].ToString()),
                            LeftLimit = GetClearString(leftLimits[i].ToString()),
                            RightLimit = GetClearString(rightLimits[i].ToString())
                        };
                    }

                    excelProfile.Add(profile);
                }
            }
            else
            {
                throw new Exception("Difference length");
            }

            return excelProfile;
        }

        public static List<ExcelResult> GetResultsEP(string pathToExcelFile, string sheetName)
        {
            List<ExcelResult> excelAnswer = new List<ExcelResult>();

            ConnectionExcel ConxObject = new ConnectionExcel(pathToExcelFile);
            var ids = GetColumn(2, 1, pathToExcelFile, sheetName);
            var profileNums = GetColumn(2, 2, pathToExcelFile, sheetName);
            var questionNums = GetColumn(2, 3, pathToExcelFile, sheetName);
            var answers = GetColumn(2, 4, pathToExcelFile, sheetName);

            if (ids.Count() == profileNums.Count() && profileNums.Count() == questionNums.Count() && questionNums.Count() == answers.Count())
            {
                for (int i = 0; i < ids.Count(); i++)
                {
                    int profileNum;
                    int questionNum;
                    try
                    {
                        profileNum = Convert.ToInt32(profileNums[i]);
                        questionNum = Convert.ToInt32(questionNums[i]);

                    }
                    catch (Exception)
                    {
                        throw new Exception("Id is not int");
                    }

                    ExcelResult answer = new ExcelResult()
                    {
                        Id = ids[i].ToString(),
                        ProfileNum = profileNum,
                        QuestionNum = questionNum,
                        Answer = answers[i].ToString().ToLower()
                    };
                    excelAnswer.Add(answer);
                }
            }
            else
            {
                throw new Exception("Difference length");
            }

            return excelAnswer;
        }
    }
}
