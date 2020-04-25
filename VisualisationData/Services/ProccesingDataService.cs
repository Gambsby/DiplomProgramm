using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using VisualisationData.Excel;

namespace VisualisationData.Services
{
    class ProccesingDataService
    {
        public static Dictionary<string, int> GetOpenAnswers(ExcelQuestion selectedQuestion, ExcelProfile selectedProfile, ExcelDocument selectedDocument)
        {
            Dictionary<string, int> points = new Dictionary<string, int>();

            var currentResults = selectedDocument.AnswerListContent.Where(a => a.ProfileNum == selectedProfile.Id && a.QuestionNum == selectedQuestion.Id).ToList();
            foreach (var resultItem in currentResults)
            {
                var openAnswers = resultItem.GetAnswers(selectedProfile.Type).Except(selectedProfile.GetProfileAnswers()).ToList();
                if (openAnswers.Count != 0)
                {
                    foreach (var item in openAnswers)
                    {
                        if (points.ContainsKey(item))
                        {
                            points[item]++;
                        }
                        else
                        {
                            points.Add(item, 1);
                        }
                    }
                }
            }

            return points;
        }

        public static Tuple<Dictionary<string, int>, int, int> GetOpenInfo(ExcelQuestion selectedQuestion, ExcelProfile selectedProfile, ExcelDocument selectedDocument)
        {
            var points = GetOpenAnswers(selectedQuestion, selectedProfile, selectedDocument);

            int questionedCount = selectedDocument.AnswerListContent.Where(a => a.ProfileNum == selectedProfile.Id && a.QuestionNum == selectedQuestion.Id).Count();
            int respondedCount = selectedDocument.AnswerListContent.Where(a => a.ProfileNum == selectedProfile.Id && a.QuestionNum == selectedQuestion.Id && a.Answer != "").Count();

            return new Tuple<Dictionary<string, int>, int, int>(points, respondedCount, questionedCount);
        }

        private static Dictionary<string, int> GetQuestionPoints(ExcelQuestion selectedQuestion, ExcelProfile selectedProfile, ExcelDocument selectedDocument)
        {
            Dictionary<string, int> points = new Dictionary<string, int>();
            var answersList = selectedProfile.GetProfileAnswers();
            int openAnswerCount = 0;
            foreach (var answerItem in answersList)
            {
                if (answerItem == "другое")
                {
                    var currentResults = selectedDocument.AnswerListContent.Where(a => a.ProfileNum == selectedProfile.Id && a.QuestionNum == selectedQuestion.Id).ToList();
                    foreach (var resultItem in currentResults)
                    {
                        var a = resultItem.GetAnswers(selectedProfile.Type).Except(answersList).ToList();
                        if (a.Count != 0)
                        {
                            openAnswerCount++;
                        }
                    }
                    points.Add(answerItem, openAnswerCount);
                }
                else
                {
                    var countCurrentAnswers = selectedDocument.AnswerListContent.Where(a => a.ProfileNum == selectedProfile.Id && a.QuestionNum == selectedQuestion.Id && a.GetAnswers(selectedProfile.Type).Contains(answerItem)).Count();
                    points.Add(answerItem, countCurrentAnswers);
                }
            }

            return points;
        }

        public static Tuple<Dictionary<string, int>, int, int> GetQuestionInfo(ExcelQuestion selectedQuestion, ExcelProfile selectedProfile, ExcelDocument selectedDocument)
        {
            var points = GetQuestionPoints(selectedQuestion, selectedProfile, selectedDocument);

            int questionedCount = selectedDocument.AnswerListContent.Where(a => a.ProfileNum == selectedProfile.Id && a.QuestionNum == selectedQuestion.Id).Count();
            int respondedCount = selectedDocument.AnswerListContent.Where(a => a.ProfileNum == selectedProfile.Id && a.QuestionNum == selectedQuestion.Id && a.Answer != "").Count();
            
            return new Tuple<Dictionary<string, int>, int, int>(points, respondedCount, questionedCount);
        }

        public static Chart CreateDefaultChart(Chart currentChart, Tuple<Dictionary<string, int>, int, int> questionInfo, ExcelQuestion excelQuestion, SeriesChartType type)
        {
            string question = excelQuestion.GetForSeries();
            Dictionary<string, int> points = questionInfo.Item1;
            int respondedCount = questionInfo.Item2;
            int questionedCount = questionInfo.Item3;

            currentChart.Series.Add(question);
            currentChart.Series[question].ChartType = type;
            currentChart.Series[question].Color = Form1.CompanyColor.Values.ToList()[0];

            currentChart.Titles.Add(CommonService.CreateTitle("mainTitle", question));
            currentChart.Titles.Add(CommonService.CreateTitle("allTitle", "Всего " + respondedCount + " ответивших участников"));

            foreach (var item in points)
            {
                currentChart.Series[question].Points.AddXY(item.Key, item.Value);
            }

            if (currentChart.Series[question].ChartType == SeriesChartType.Pie || currentChart.Series[question].ChartType == SeriesChartType.Doughnut)
            {
                int colorIndex = 0;
                foreach (var item in currentChart.Series[question].Points)
                {
                    if (item.YValues[0] == 0)
                    {
                        item.LabelForeColor = Color.Transparent;
                    }
                    item.Color = Form1.CompanyColor.Values.ToList()[colorIndex];
                    colorIndex++;
                }

                currentChart.Series[question].LabelForeColor = Color.White;
            }
            else
            {
                currentChart.Series[question].LabelForeColor = Color.Black;
            }

            Legend legend = CommonService.CreateLegend(currentChart.Series[question], "mainLegend");

            currentChart.Legends.Add(legend);

            return currentChart;
        }

        public static Chart SettingDefaultChart(Chart currentChart, ExcelQuestion excelQuestion)
        {
            string question = excelQuestion.GetForSeries();

            currentChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            currentChart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            currentChart.Series[question].IsValueShownAsLabel = true;
            currentChart.Series[question].Label = "#PERCENT";
            currentChart.Series[question].Font = new Font("Arial", 14f);
            currentChart.Series[question].IsVisibleInLegend = false;

            currentChart.Titles["mainTitle"].Font = new Font("Arial", 14f);
            currentChart.Titles["allTitle"].Font = new Font("Arial", 14f);

            currentChart.Legends["mainLegend"].Font = new Font("Arial", 14f);

            return currentChart;
        }

        public static string GroupDiagramSave(ExcelDocument document, string dirPath, SeriesChartType type)
        {
            dirPath += "\\" + document.DocumentName;
            foreach (var profileItem in document.ProfilesListContent)
            {
                string dirName = dirPath + "\\" + profileItem.Name;
                Directory.CreateDirectory(dirName);
                int chartNum = 1;
                foreach (var questionItem in profileItem.Questions)
                {
                    var questionInfo = GetQuestionInfo(questionItem, profileItem, document);

                    Chart currentChart = new Chart();
                    currentChart.Width = 1920;
                    currentChart.Height = 1080;

                    ChartArea chartArea = new ChartArea();
                    chartArea.Name = "ChartArea1";
                    currentChart.ChartAreas.Add(chartArea);

                    currentChart = CreateDefaultChart(currentChart, questionInfo, questionItem, type);
                    currentChart = SettingDefaultChart(currentChart, questionItem);

                    currentChart.SaveImage(dirName + "\\Chart" + chartNum + ".png", ChartImageFormat.Png);
                    chartNum++;
                }
            }

            return dirPath;
        }
    }
}
