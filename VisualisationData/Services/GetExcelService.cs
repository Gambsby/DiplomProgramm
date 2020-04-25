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
    class GetExcelService
    {
        private static string GetClearString(string source)
        {
            return Regex.Replace(source, "\\r\\n", " ");
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
            var ids = GetColumn(2, 1, pathToExcelFile, sheetName);
            var profileNames = GetColumn(2, 2, pathToExcelFile, sheetName);
            var answers = GetColumn(2, 6, pathToExcelFile, sheetName);
            var sheets = GetColumn(2, 7, pathToExcelFile, sheetName);

            if (ids.Count == profileNames.Count && profileNames.Count == answers.Count)
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
                        throw new Exception("Первый столбец в листе \"" + sheetName + "\" должен содержать только цифры.");
                    }
                    string sheet = "";
                    if (i < sheets.Count)
                    {
                        sheet = sheets[i].ToString();
                    }
                    ExcelQuestionType type = new ExcelQuestionType()
                    {
                        Id = id,
                        ProfileName = profileNames[i].ToString(),
                        Answers = answers[i].ToString(),
                        Sheet = sheet
                    };
                    excelQuestionTypes.Add(type);
                }
            }
            else
            {
                throw new Exception("Лист \"" + sheetName + "\" не соответствует формату.");
            }

            return excelQuestionTypes;
        }

        public static List<ExcelQuestion> GetQuestionsEP(string pathToExcelFile, string sheetName)
        {
            List<ExcelQuestion> excelProfile = new List<ExcelQuestion>();

            var ids = GetColumn(1, 1, pathToExcelFile, sheetName);
            var question = GetColumn(1, 2, pathToExcelFile, sheetName);
            var leftLimits = GetColumn(1, 3, pathToExcelFile, sheetName);
            var rightLimits = GetColumn(1, 4, pathToExcelFile, sheetName);

            if (leftLimits.Count == 0 || rightLimits.Count == 0)
            {
                leftLimits = null;
                rightLimits = null;
            }

            if (ids.Count == question.Count)
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
                        throw new Exception("Первый столбец в листе \"" + sheetName + "\" должен содержать только цифры.");
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
                        if (leftLimits.Count != rightLimits.Count || leftLimits.Count != ids.Count || rightLimits.Count != ids.Count)
                        {
                            throw new Exception("Лист \"" + sheetName + "\" не соответствует формату.");
                        }
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
                throw new Exception("Лист \"" + sheetName + "\" не соответствует формату.");
            }

            return excelProfile;
        }

        public static List<ExcelResult> GetResultsEP(string pathToExcelFile, string sheetName)
        {
            List<ExcelResult> excelAnswer = new List<ExcelResult>();

            var ids = GetColumn(2, 1, pathToExcelFile, sheetName);
            var profileNums = GetColumn(2, 2, pathToExcelFile, sheetName);
            var questionNums = GetColumn(2, 3, pathToExcelFile, sheetName);
            var answers = GetColumn(2, 4, pathToExcelFile, sheetName);

            if (ids.Count == profileNums.Count && profileNums.Count == questionNums.Count && questionNums.Count == answers.Count())
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
                        throw new Exception("Первый столбец в листе \"" + sheetName + "\" должен содержать только цифры.");
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
                throw new Exception("Лист \"" + sheetName + "\" не соответствует формату.");
            }

            return excelAnswer;
        }
    }
}
