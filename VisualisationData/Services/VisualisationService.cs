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
    class VisualisationService
    {
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
                    var points = questionInfo.Item1;
                    var respondedCount = questionInfo.Item2;

                    Chart currentChart = new Chart();
                    currentChart.Width = 1920;
                    currentChart.Height = 1080;

                    ChartArea chartArea = new ChartArea();
                    Legend legend = new Legend();
                    chartArea.Name = "ChartArea1";
                    currentChart.ChartAreas.Add(chartArea);
                    legend.Name = "Legend1";
                    currentChart.Legends.Add(legend);

                    currentChart.Series.Add(questionItem.GetForSeries());

                    currentChart.Series[questionItem.GetForSeries()].ChartType = type;
                    currentChart.Series[questionItem.GetForSeries()].Color = Form1.CompanyColor.Values.ToList()[0];
                    currentChart.Series[questionItem.GetForSeries()].IsValueShownAsLabel = true;
                    currentChart.Series[questionItem.GetForSeries()].Font = new Font("Arial", 20f);
                    if (type == SeriesChartType.Pie || type == SeriesChartType.Doughnut)
                    {
                        currentChart.Titles.Add(questionItem.GetForSeries());
                        currentChart.Titles[0].Font = new Font("Arial", 14f);
                        currentChart.Series[questionItem.GetForSeries()].LabelForeColor = Color.White;
                    }
                    else
                    {
                        currentChart.Series[questionItem.GetForSeries()].LabelForeColor = Color.Black;
                    }
                    currentChart.Legends["Legend1"].Font = new Font("Arial", 14f);
                    currentChart.ChartAreas["ChartArea1"].AxisX.LabelAutoFitMinFontSize = 14;
                    currentChart.ChartAreas["ChartArea1"].AxisY.LabelAutoFitMinFontSize = 14;
                    currentChart.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                    currentChart.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;

                    foreach (var item in points)
                    {
                        currentChart.Series[questionItem.GetForSeries()].Points.AddXY(item.Key, item.Value);
                        if (item.Value == 0)
                        {
                            currentChart.Series[questionItem.GetForSeries()].Points[currentChart.Series[questionItem.GetForSeries()].Points.Count - 1].LabelForeColor = Color.Transparent;
                        }
                    }

                    if (type == SeriesChartType.Pie || type == SeriesChartType.Doughnut)
                    {
                        int colorIndex = 0;
                        foreach (var item in currentChart.Series[questionItem.GetForSeries()].Points)
                        {
                            item.Color = Form1.CompanyColor.Values.ToList()[colorIndex];
                            colorIndex++;
                        }
                    }

                    currentChart.SaveImage(dirName + "\\Chart" + chartNum + ".png", ChartImageFormat.Png);
                    chartNum++;
                }
            }

            return dirPath;
        }
    }
}
