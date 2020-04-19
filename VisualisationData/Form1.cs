using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using VisualisationData.DataSettingForms;
using VisualisationData.Excel;
using VisualisationData.Models;
using VisualisationData.Services;
using VisualisationData.VisualSettingForms;

namespace VisualisationData
{
    public partial class Form1 : Form
    {
        public static Dictionary<string, Color> CompanyColor = new Dictionary<string, Color>
        {
            { "Бордовый", Color.FromArgb(120, 28, 51) },
            { "Малахит", Color.FromArgb(15, 71, 54) },
            { "Рубиновый", Color.FromArgb(189, 0, 64) },
            { "Изумрудный", Color.FromArgb(15, 130, 89) },
            { "Красный", Color.FromArgb(242, 15, 56) },
             { "Зеленый", Color.FromArgb(0, 204, 115) },
            { "Коралловый", Color.FromArgb(255, 77, 89) },
             { "Аврора", Color.FromArgb(66, 227, 163) },
            { "Желтый", Color.FromArgb(255, 171, 0) },
            { "Голубой", Color.FromArgb(5, 150, 214) },
            { "Песочный", Color.FromArgb(242, 204, 161) },
            { "Асфальт", Color.FromArgb(28, 59, 66) },
            { "Синий", Color.FromArgb(3, 74, 125) },
            { "Лазурь", Color.FromArgb(158, 235, 252) },
            { "Темное золото", Color.FromArgb(140, 102, 77) }
        };

        private ExcelDocument Document { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        private void loadDataExcelBtn_Click(object sender, EventArgs e)//+
        {
            try
            {
                string filePath = CommonService.OpenFilePath("*.xlsx|*.xlsx", "физвоспитание анкета");
                if (string.IsNullOrEmpty(filePath))
                {
                    return;
                }
                string fileName = Path.GetFileNameWithoutExtension(filePath);

                string infoFileName = string.Empty;
                string resultFileName = string.Empty;
                Dictionary<string, string> excelProfileMap = null;

                using (SheetsSettigsForm ssf = new SheetsSettigsForm())
                {
                    ssf.Type = "load";
                    ssf.FilePath = filePath;
                    ssf.ShowDialog();
                    if (ssf.Status)
                    {
                        infoFileName = ssf.InfoFileName;
                        resultFileName = ssf.ResultFileName;
                        excelProfileMap = ssf.ExcelSheetMap;
                    }
                    else
                    {
                        return;
                    }

                    Document = SortDocument(DataService.LoadMainProfileExcel(filePath, infoFileName, resultFileName, excelProfileMap));
                    if (Document!= null)
                    {
                        ShowOnTabControl(Document);
                        saveBtn.Enabled = true;
                        closeProfileBtn.Enabled = true;
                        visDataBtn.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadDataDBBtn_Click(object sender, EventArgs e)//+
        {
            try
            {
                MainProfile mainProfile = null;
                using (ChooseMainProfileForm cmp = new ChooseMainProfileForm())
                {
                    cmp.Type = "load";
                    cmp.ShowDialog();
                    if (cmp.Status)
                    {
                        mainProfile = cmp.SelectedMainProfiles[0];
                        Document = SortDocument(DataService.LoadMainProfileDB(mainProfile));
                        if (Document != null)
                        {
                            ShowOnTabControl(Document);
                            saveBtn.Enabled = true;
                            closeProfileBtn.Enabled = true;
                            visDataBtn.Enabled = true;
                            MessageBox.Show("Данные успешно загружены.");
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Исправте ошибки и попытайтесь снова!");
                return;
            }
        }

        private void saveCSVBtn_Click(object sender, EventArgs e)//+
        {
            try
            {
                string infoFileName = string.Empty;
                string resultFileName = string.Empty;
                Dictionary<string, ExcelProfile> excelProfileMap = null;

                using (SheetsSettigsForm ssf = new SheetsSettigsForm())
                {
                    ssf.Type = "save";
                    ssf.Format = "csv";
                    ssf.Document = Document;
                    ssf.ShowDialog();
                    if (ssf.Status)
                    {
                        infoFileName = ssf.InfoFileName;
                        resultFileName = ssf.ResultFileName;
                        excelProfileMap = ssf.ExcelProfileMap;
                    }
                    else
                    {
                        return;
                    }
                }

                DataService.SaveCSV(infoFileName, resultFileName, excelProfileMap, Document);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void saveExcelBtn_Click(object sender, EventArgs e)//+
        {
            try
            {
                string infoFileName = string.Empty;
                string resultFileName = string.Empty;
                Dictionary<string, ExcelProfile> excelProfileMap  = null;

                using (SheetsSettigsForm ssf = new SheetsSettigsForm())
                {
                    ssf.Type = "save";
                    ssf.Format = "excel";
                    ssf.Document = Document;
                    ssf.ShowDialog();
                    if (ssf.Status)
                    {
                        infoFileName = ssf.InfoFileName;
                        resultFileName = ssf.ResultFileName;
                        excelProfileMap = ssf.ExcelProfileMap;
                    }
                    else
                    {
                        return;
                    }
                }

                DataService.SaveExcel(infoFileName, resultFileName, excelProfileMap, Document);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void saveDBBtn_Click(object sender, EventArgs e)//+
        {
            try
            {
                using (profileContext db = new profileContext())
                {
                    using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction tr = db.Database.BeginTransaction())
                    {
                        try
                        {
                            try
                            {
                                DataService.SaveProfileToDB(db, tr, Document);
                                tr.Commit();
                            }
                            catch (Exception ex)
                            {
                                tr.Rollback();
                                MessageBox.Show(ex.Message);
                                return;
                            }
                            DataService.SaveResultToDB(db, tr, Document);
                        }
                        catch (Exception ex)
                        {
                            MainProfile mainProfile = db.MainProfile.SingleOrDefault(p => p.Name == Document.DocumentName);
                            if (mainProfile != null)
                            {
                                db.MainProfile.Remove(mainProfile);
                                db.SaveChanges();
                            }
                            MessageBox.Show(ex.Message);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteDataBtn_Click(object sender, EventArgs e)//+
        {
            try
            {
                List<MainProfile> mainProfiles = null;
                using (ChooseMainProfileForm dsf = new ChooseMainProfileForm())
                {
                    dsf.Type = "delete";
                    dsf.ShowDialog();
                    if (dsf.Status)
                    {
                        mainProfiles = dsf.SelectedMainProfiles;
                        DataService.DeleteMainProfile(mainProfiles);
                        MessageBox.Show("Данные успешно удалены.");
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void closeProfileBtn_Click(object sender, EventArgs e)//+
        {
            mainTab.TabPages.Clear();
            Document = null;
            saveBtn.Enabled = false;
            closeProfileBtn.Enabled = false;
            visDataBtn.Enabled = false;
        }

        private void columnDiagramBtn_Click(object sender, EventArgs e)//+
        {
            try
            {
                DiagramStart(SeriesChartType.Column);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при создании диаграммы.");
            }
        }

        private void barDiagramBtn_Click(object sender, EventArgs e)//+
        {
            try
            {
                DiagramStart(SeriesChartType.Bar);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при создании диаграммы.");
            }
        }

        private void pieDiagramBtn_Click(object sender, EventArgs e)//+
        {
            try
            {
                DiagramStart(SeriesChartType.Pie);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при создании диаграммы.");
            }
        }

        private void allColumnDiagramBtn_Click(object sender, EventArgs e)//+
        {
            string dirPath = CommonService.GetFolderPath();
            if (dirPath != null)
            {
                VisualisationService.GroupDiagramSave(Document, dirPath, SeriesChartType.Column);
            }
        }

        private void allPieDiagramBtn_Click(object sender, EventArgs e)//+
        {
            string dirPath = CommonService.GetFolderPath();
            if (dirPath != null)
            {
                VisualisationService.GroupDiagramSave(Document, dirPath, SeriesChartType.Pie);
            }
        }

        private void allDoughnoutDiagramBtn_Click(object sender, EventArgs e)//+
        {
            string dirPath = CommonService.GetFolderPath();
            if (dirPath != null)
            {
                VisualisationService.GroupDiagramSave(Document, dirPath, SeriesChartType.Doughnut);
            }
        }

        private void allBarDiagramBtn_Click(object sender, EventArgs e)//+
        {
            string dirPath = CommonService.GetFolderPath();
            if (dirPath != null)
            {
                VisualisationService.GroupDiagramSave(Document, dirPath, SeriesChartType.Bar);
            }
        }

        private void InitDataGrid(string type, DataGridView dataGrid)
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
            dataGrid.Columns.Add(CommonService.CreateTextColumn("Возможные ответы", "answers", true));
        }

        private void DiagramStart(SeriesChartType type)
        {
            List<ExcelQuestion> selectedQuestions = new List<ExcelQuestion>();
            var currentTab = mainTab.SelectedTab;
            var infoDG = currentTab.Controls[currentTab.Text + "DG"] as DataGridView;
            var selectedQuestion = infoDG.SelectedRows.Cast<DataGridViewRow>().ToList()[0].Cells["question"].Value as ExcelQuestion;
            var selectedProfile = Document.ProfilesListContent.SingleOrDefault(p => p.Name == currentTab.Text);

            VisualisationForm visualisationForm = new VisualisationForm(selectedQuestion, selectedProfile, Document, type);
            visualisationForm.Show();
        }

        private ExcelDocument SortDocument(ExcelDocument document)
        {
            document.ProfilesListContent = document.ProfilesListContent.OrderBy(x => x.Id).ToList();
            foreach (var profileItem in document.ProfilesListContent)
            {
                profileItem.Questions = profileItem.Questions.OrderBy(x => x.Id).ToList();
            }

            return document;
        }

        private void ShowOnTabControl(ExcelDocument document)
        {
            foreach (var profileItem in document.ProfilesListContent)
            {
                DataGridView infoDG = new DataGridView();
                infoDG.Name = profileItem.Name + "DG";
                infoDG.Anchor = AnchorStyles.Top;
                infoDG.Anchor = AnchorStyles.Right;
                infoDG.Anchor = AnchorStyles.Bottom;
                infoDG.Anchor = AnchorStyles.Left;
                infoDG.Dock = DockStyle.Fill;
                infoDG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                infoDG.MultiSelect = false;
                infoDG.AllowUserToAddRows = false;

                TabPage tabPage = new TabPage();
                tabPage.Text = profileItem.Name;
                tabPage.Name = profileItem.Name + "Tab";

                tabPage.Controls.Add(infoDG);
                mainTab.TabPages.Add(tabPage);

                InitDataGrid(profileItem.Type, infoDG);

                foreach (var questionItem in profileItem.Questions)
                {
                    switch (profileItem.Type)
                    {
                        case "range":
                            {
                                infoDG.Rows.Add(questionItem.Id, questionItem, questionItem.LeftLimit, questionItem.RightLimit, profileItem.Answers);
                                break;
                            }
                        case "radio":
                            {
                                infoDG.Rows.Add(questionItem.Id, questionItem, profileItem.Answers);
                                break;
                            }
                        case "checkbox":
                            {
                                infoDG.Rows.Add(questionItem.Id, questionItem, profileItem.Answers);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }
}
