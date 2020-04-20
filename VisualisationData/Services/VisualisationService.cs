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
        public static Dictionary<string, Dictionary<string, int>> GetVisualData(List<ExcelQuestion> selectedQuestions, ExcelProfile selectedProfile, ExcelDocument selectedDocument)
        {
            Dictionary<string, Dictionary<string, int>> result = new Dictionary<string, Dictionary<string, int>>();
            foreach (var selectedQuestionItem in selectedQuestions)
            {
                Dictionary<string, int> visualDataQuestion = new Dictionary<string, int>();
                var answersList = selectedProfile.GetProfileAnswers();
                int openAnswerCount = 0;
                foreach (var answerItem in answersList)
                {
                    if (answerItem == "другое")
                    {
                        var currentResults = selectedDocument.AnswerListContent.Where(a => a.ProfileNum == selectedProfile.Id && a.QuestionNum == selectedQuestionItem.Id).ToList();
                        foreach (var resultItem in currentResults)
                        {
                            var a = resultItem.GetAnswers(selectedProfile.Type).Except(answersList).ToList();
                            if (a.Count != 0)
                            {
                                openAnswerCount++;
                            }
                        }
                        visualDataQuestion.Add(answerItem, openAnswerCount);
                    }
                    else
                    {
                        var countCurrentAnswers = selectedDocument.AnswerListContent.Where(a => a.ProfileNum == selectedProfile.Id && a.QuestionNum == selectedQuestionItem.Id && a.GetAnswers(selectedProfile.Type).Contains(answerItem)).Count();
                        visualDataQuestion.Add(answerItem, countCurrentAnswers);
                    }
                }
                result.Add(selectedQuestionItem.GetForSeries(), visualDataQuestion);

            }

            return result;
        }

        public static void GroupDiagramSave(ExcelDocument document, string dirPath, SeriesChartType type)
        {
            dirPath += "\\" + document.DocumentName;
            foreach (var profileItem in document.ProfilesListContent)
            {
                var visualData = VisualisationService.GetVisualData(profileItem.Questions, profileItem, document);
                string dirName = dirPath + "\\" + profileItem.Name;
                Directory.CreateDirectory(dirName);
                int chartNum = 1;
                foreach (var chartItem in visualData)
                {
                    Chart currentChart = new Chart();
                    currentChart.Width = 1920;
                    currentChart.Height = 1080;

                    ChartArea chartArea = new ChartArea();
                    Legend legend = new Legend();
                    chartArea.Name = "ChartArea1";
                    currentChart.ChartAreas.Add(chartArea);
                    legend.Name = "Legend1";
                    currentChart.Legends.Add(legend);

                    currentChart.Series.Add(chartItem.Key);

                    currentChart.Series[chartItem.Key].ChartType = type;
                    currentChart.Series[chartItem.Key].Color = Form1.CompanyColor.Values.ToList()[0];
                    currentChart.Series[chartItem.Key].IsValueShownAsLabel = true;
                    currentChart.Series[chartItem.Key].Font = new Font("Arial", 20f);
                    if (type == SeriesChartType.Pie || type == SeriesChartType.Doughnut)
                    {
                        currentChart.Titles.Add(chartItem.Key);
                        currentChart.Titles[0].Font = new Font("Arial", 14f);
                        currentChart.Series[chartItem.Key].LabelForeColor = Color.White;
                    }
                    else
                    {
                        currentChart.Series[chartItem.Key].LabelForeColor = Color.Black;
                    }
                    currentChart.Legends["Legend1"].Font = new Font("Arial", 14f);
                    currentChart.ChartAreas["ChartArea1"].AxisX.LabelAutoFitMinFontSize = 14;
                    currentChart.ChartAreas["ChartArea1"].AxisY.LabelAutoFitMinFontSize = 14;
                    currentChart.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                    currentChart.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;

                    foreach (var item in chartItem.Value)
                    {
                        currentChart.Series[chartItem.Key].Points.AddXY(item.Key, item.Value);
                        if (item.Value == 0)
                        {
                            currentChart.Series[chartItem.Key].Points[currentChart.Series[chartItem.Key].Points.Count - 1].LabelForeColor = Color.Transparent;
                        }
                    }

                    if (type == SeriesChartType.Pie || type == SeriesChartType.Doughnut)
                    {
                        int colorIndex = 0;
                        foreach (var item in currentChart.Series[chartItem.Key].Points)
                        {
                            item.Color = Form1.CompanyColor.Values.ToList()[colorIndex];
                            colorIndex++;
                        }
                    }

                    currentChart.SaveImage(dirName + "\\Chart" + chartNum + ".png", ChartImageFormat.Png);
                    chartNum++;
                }
            }
        }
    }
}
