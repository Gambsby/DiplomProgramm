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
using System.IO;
using MySql.Data.MySqlClient;
using Z.BulkOperations;
using System.Windows.Forms.DataVisualization.Charting;
using OfficeOpenXml;
using VisualisationData.Models;
using VisualisationData.Excel;
using VisualisationData.Services;
using VisualisationData.VisualSettingForms;
using VisualisationData.DataSettingForms;
using System.Data.Common;

namespace VisualisationData
{
    public partial class Form1 : Form
    {
        public static Dictionary<string, Color> CompanyColor = new Dictionary<string, Color>
        {
            { "Бордовый", Color.FromArgb(120, 28, 51) },
            { "Рубиновый", Color.FromArgb(189, 0, 64) },
            { "Красный", Color.FromArgb(242, 15, 56) },
            { "Коралловый", Color.FromArgb(255, 77, 89) },
            { "Желтый", Color.FromArgb(255, 171, 0) },
            { "Малахит", Color.FromArgb(15, 71, 54) },
            { "Изумрудный", Color.FromArgb(15, 130, 89) },
            { "Зеленый", Color.FromArgb(0, 204, 115) },
            { "Аврора", Color.FromArgb(66, 227, 163) },
            { "Песочный", Color.FromArgb(242, 204, 161) },
            { "Асфальт", Color.FromArgb(28, 59, 66) },
            { "Синий", Color.FromArgb(3, 74, 125) },
            { "Голубой", Color.FromArgb(5, 150, 214) },
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
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            infoDG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            infoDG.MultiSelect = true;
        }

        private void loadDataExcelBtn_Click(object sender, EventArgs e)//Обработка ошибок
        {
            string filePath;
            string fileName;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Открыть файл ...";
                ofd.Filter = "*.xlsx|*.xlsx";
                ofd.AddExtension = true;
                ofd.FileName = "физвоспитание анкета";
                if (ofd.ShowDialog() == DialogResult.Cancel)
                    return;
                else
                {
                    filePath = ofd.FileName;
                    fileName = Path.GetFileNameWithoutExtension(filePath);
                }
            }

            try
            {
                LoadSettingForm loadSettingForm = new LoadSettingForm(filePath);
                loadSettingForm.ShowDialog();
                switch (loadSettingForm.DialogResult)
                {
                    case DialogResult.OK:
                        {
                            Document = SortDocument(loadSettingForm.Document);
                            profilesCB.Items.AddRange(Document.ProfilesListContent.Select(p => p).ToArray());
                            profilesCB.SelectedIndex = 0;
                            break;
                        }
                    case DialogResult.Cancel:
                        {
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Исправте ошибки и попытайтесь снова!");
                return;
            }
        }

        private void loadDataDBBtn_Click(object sender, EventArgs e)//Обработка ошибок
        {
            try
            {
                ChooseMainProfileForm chooseMainProfileForm = new ChooseMainProfileForm("load");
                chooseMainProfileForm.ShowDialog();
                if (chooseMainProfileForm.Status)
                {
                    Document = SortDocument(chooseMainProfileForm.Document);
                    profilesCB.Items.AddRange(Document.ProfilesListContent.Select(p => p).ToArray());
                    profilesCB.SelectedIndex = 0;
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Исправте ошибки и попытайтесь снова!");
                return;
            }
        }

        private void saveCSVBtn_Click(object sender, EventArgs e)//Обработка ошибок
        {
            try
            {
                SaveSettingForm saveSettingForm = new SaveSettingForm(Document, "csv");
                saveSettingForm.ShowDialog();
                if (saveSettingForm.Status)
                {
                    MessageBox.Show("Данные успешно сохранены");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void saveExcelBtn_Click(object sender, EventArgs e)//Обработка ошибок
        {
            try
            {
                SaveSettingForm saveSettingForm = new SaveSettingForm(Document, "excel");
                saveSettingForm.ShowDialog();
                if (saveSettingForm.Status)
                {
                    MessageBox.Show("Данные успешно сохранены");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void saveDBBtn_Click(object sender, EventArgs e)//Обработка ошибок
        {
            using (profileContext db = new profileContext())
            {
                using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction tr = db.Database.BeginTransaction())
                {
                    try
                    {
                        try
                        {
                            SaveService.SaveProfileToDB(db, tr, Document);
                            tr.Commit();
                        }
                        catch (Exception ex)
                        {
                            tr.Rollback();
                            throw ex;
                        }
                        SaveService.SaveResultToDB(db, tr, Document);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void deleteDataBtn_Click(object sender, EventArgs e)//Обработка ошибок
        {
            try
            {
                ChooseMainProfileForm deleteSettingForm = new ChooseMainProfileForm("delete");
                deleteSettingForm.ShowDialog();
                if (deleteSettingForm.Status)
                {
                    MessageBox.Show("Данные успешно удалены");
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void closeProfileBtn_Click(object sender, EventArgs e)
        {
            profilesCB.Items.Clear();
            infoDG.Rows.Clear();
            infoDG.Columns.Clear();
            Document = null;
        }

        private void columnDiagramBtn_Click(object sender, EventArgs e)//Обработка ошибок
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

        private void barDiagramBtn_Click(object sender, EventArgs e)//Обработка ошибок
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

        private void pieDiagramBtn_Click(object sender, EventArgs e)//Обработка ошибок
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

        private void profilesCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedProfile = profilesCB.SelectedItem as ExcelProfile;

            InitDataGrid(selectedProfile.Type, infoDG);

            foreach (var questionItem in selectedProfile.Questions)
            {
                switch (selectedProfile.Type)
                {
                    case "range":
                        {
                            infoDG.Rows.Add(questionItem.Id, questionItem, questionItem.LeftLimit, questionItem.RightLimit, selectedProfile.Answers);
                            break;
                        }
                    case "radio":
                        {
                            infoDG.Rows.Add(questionItem.Id, questionItem, selectedProfile.Answers);
                            break;
                        }
                    case "checkbox":
                        {
                            infoDG.Rows.Add(questionItem.Id, questionItem, selectedProfile.Answers);
                            break;
                        }
                    default:
                        break;
                }
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
            foreach (var rowItem in infoDG.SelectedRows.Cast<DataGridViewRow>())
            {
                var question = rowItem.Cells["question"].Value as ExcelQuestion;
                selectedQuestions.Add(question);
            }
            var selectedProfile = profilesCB.SelectedItem as ExcelProfile;

            VisualisationForm visualisationForm = new VisualisationForm(selectedQuestions, selectedProfile, Document, type);
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

    }
}
