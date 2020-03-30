using System;
using System.Collections.Generic;
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

            ConnexionExcel ConxObject = new ConnexionExcel(pathToExcelFile);
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

        public static List<ExcelProfile> GetProfiles(string pathToExcelFile, string sheetName, string profileType)
        {
            List<ExcelProfile> excelProfile = new List<ExcelProfile>();

            ConnexionExcel ConxObject = new ConnexionExcel(pathToExcelFile);
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
                    ExcelProfile profile;
                    if (leftLimits == null && rightLimits == null)
                    {
                        profile = new ExcelProfile()
                        {
                            Id = id,
                            Content = GetClearString(question[i].ToString()),
                            leftLimit = null,
                            rightLimit = null
                        };
                    }
                    else
                    {
                        profile = new ExcelProfile()
                        {
                            Id = id,
                            Content = GetClearString(question[i].ToString()),
                            leftLimit = GetClearString(leftLimits[i].ToString()),
                            rightLimit = GetClearString(rightLimits[i].ToString())
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

        public static List<ExcelAnswer> GetAnswers(string pathToExcelFile, string sheetName)
        {
            List<ExcelAnswer> excelAnswer = new List<ExcelAnswer>();

            ConnexionExcel ConxObject = new ConnexionExcel(pathToExcelFile);
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

                    ExcelAnswer answer = new ExcelAnswer()
                    {
                        Id = ids[i].ToString(),
                        ProfileNum = profileNum,
                        QuestionNum = questionNum,
                        Answer = answers[i].ToString()
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
