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
        public enum FileFormats { Excel, CSV};


        private ExcelDocument Document { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)//1
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            infoDG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            infoDG.MultiSelect = true;
        }

        private void loadDataExcelBtn_Click(object sender, EventArgs e)
        {
            string filePath;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Открыть файл ...";
                ofd.Filter = "*.xlsx|*.xlsx";
                ofd.AddExtension = true;
                ofd.FileName = "физвоспитание анкета";
                if (ofd.ShowDialog() == DialogResult.Cancel)
                    return;
                filePath = ofd.FileName;
            }
            string fileName = Path.GetFileNameWithoutExtension(filePath);

            DownloadSettingForm downloadSettingForm = new DownloadSettingForm(filePath);
            downloadSettingForm.ShowDialog();
            switch (downloadSettingForm.DialogResult)
            {
                case DialogResult.OK:
                    {
                        Document = downloadSettingForm.Document;
                        MessageBox.Show("Данные успешно загруженны");
                        break;
                    }
                case DialogResult.Cancel:
                    {
                        break;
                    }
            }

            profilesCB.Items.AddRange(Document.ProfilesListContent.Select(p => p).ToArray());
            profilesCB.SelectedIndex = 0;
        }

        private void loadDataDBBtn_Click(object sender, EventArgs e)
        {
            ChooseMainProfileForm deleteSettingForm = new ChooseMainProfileForm("load");
            deleteSettingForm.ShowDialog();
            switch (deleteSettingForm.DialogResult)
            {
                case DialogResult.OK:
                    {
                        MessageBox.Show("Данные успешно удалены");
                        break;
                    }
                case DialogResult.Cancel:
                    {
                        break;
                    }
            }
        }

        private void saveCSVBtn_Click(object sender, EventArgs e)
        {
            SaveSettingForm saveSettingForm = new SaveSettingForm(Document, "csv");
            saveSettingForm.ShowDialog();
            switch (saveSettingForm.DialogResult)
            {
                case DialogResult.OK:
                    {
                        MessageBox.Show("Данные успешно сохранены");
                        break;
                    }
                case DialogResult.Cancel:
                    {
                        break;
                    }
            }
        }

        private void saveExcelBtn_Click(object sender, EventArgs e)
        {
            SaveSettingForm saveSettingForm = new SaveSettingForm(Document, "excel");
            saveSettingForm.ShowDialog();
            switch (saveSettingForm.DialogResult)
            {
                case DialogResult.OK:
                    {
                        MessageBox.Show("Данные успешно сохранены");
                        break;
                    }
                case DialogResult.Cancel:
                    {
                        break;
                    }
            }
        }

        private void saveDBBtn_Click(object sender, EventArgs e)
        {
            using (profileContext db = new profileContext())
            {
                using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction tr = db.Database.BeginTransaction())
                {
                    try
                    {
                        try
                        {
                            MainService.SaveProfileToDB(db, tr, Document);
                            tr.Commit();
                        }
                        catch (Exception ex)
                        {
                            tr.Rollback();
                            throw ex;
                        }
                        MainService.SaveResultToDB(db, tr, Document);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void deleteDataBtn_Click(object sender, EventArgs e)
        {
            ChooseMainProfileForm deleteSettingForm = new ChooseMainProfileForm("delete");
            deleteSettingForm.ShowDialog();
            switch (deleteSettingForm.DialogResult)
            {
                case DialogResult.OK:
                    {
                        MessageBox.Show("Данные успешно удалены");
                        break;
                    }
                case DialogResult.Cancel:
                    {
                        break;
                    }
            }
        }

        private void closeProfileBtn_Click(object sender, EventArgs e)
        {
            profilesCB.Items.Clear();
            infoDG.Rows.Clear();
            infoDG.Columns.Clear();
            Document = null;
        }

        private void columnDiagramBtn_Click(object sender, EventArgs e)
        {
            List<ExcelQuestion> selectedQuestions = new List<ExcelQuestion>();
            foreach (var rowItem in infoDG.SelectedRows.Cast<DataGridViewRow>())
            {
                var question = new ExcelQuestion
                {
                    Id = Convert.ToInt32(rowItem.Cells["serielNumber"].Value),
                    Content = rowItem.Cells["question"].Value.ToString()
                };
                selectedQuestions.Add(question);
            }
            //var selectedQuestion = new ExcelQuestion { 
            //    Id = Convert.ToInt32(infoDG.SelectedRows[0].Cells["serielNumber"].Value), 
            //    Content = infoDG.SelectedRows[0].Cells["question"].Value.ToString() 
            //};
            var selectedProfile = profilesCB.SelectedItem as ExcelProfile;

            VisualisationForm visualisationForm = new VisualisationForm(selectedQuestions, selectedProfile, Document, SeriesChartType.Column);
            visualisationForm.Show();
        }

        private void barDiagramBtn_Click(object sender, EventArgs e)
        {
            List<ExcelQuestion> selectedQuestions = new List<ExcelQuestion>();
            foreach (var rowItem in infoDG.SelectedRows.Cast<DataGridViewRow>())
            {
                var question = new ExcelQuestion
                {
                    Id = Convert.ToInt32(rowItem.Cells["serielNumber"].Value),
                    Content = rowItem.Cells["question"].Value.ToString()
                };
                selectedQuestions.Add(question);
            }
            //var selectedQuestion = new ExcelQuestion
            //{
            //    Id = Convert.ToInt32(infoDG.SelectedRows[0].Cells["serielNumber"].Value),
            //    Content = infoDG.SelectedRows[0].Cells["question"].Value.ToString()
            //};
            var selectedProfile = profilesCB.SelectedItem as ExcelProfile;

            VisualisationForm visualisationForm = new VisualisationForm(selectedQuestions, selectedProfile, Document, SeriesChartType.Bar);
            visualisationForm.Show();
        }

        private void pieDiagramBtn_Click(object sender, EventArgs e)
        {
            List<ExcelQuestion> selectedQuestions = new List<ExcelQuestion>();
            foreach (var rowItem in infoDG.SelectedRows.Cast<DataGridViewRow>())
            {
                var question = new ExcelQuestion
                {
                    Id = Convert.ToInt32(rowItem.Cells["serielNumber"].Value),
                    Content = rowItem.Cells["question"].Value.ToString()
                };
                selectedQuestions.Add(question);
            }
            //var selectedQuestion = new ExcelQuestion
            //{
            //    Id = Convert.ToInt32(infoDG.SelectedRows[0].Cells["serielNumber"].Value),
            //    Content = infoDG.SelectedRows[0].Cells["question"].Value.ToString()
            //};
            var selectedProfile = profilesCB.SelectedItem as ExcelProfile;

            VisualisationForm visualisationForm = new VisualisationForm(selectedQuestions, selectedProfile, Document, SeriesChartType.Pie);
            visualisationForm.Show();
        }

        private void profilesCB_SelectedIndexChanged(object sender, EventArgs e)//3
        {
            var selectedProfile = profilesCB.SelectedItem as ExcelProfile;

            MainService.InitDataGrid(selectedProfile.Type, infoDG);

            foreach (var questionItem in selectedProfile.Questions)
            {
                switch (selectedProfile.Type)
                {
                    case "range":
                        {
                            infoDG.Rows.Add(questionItem.Id, questionItem.Content, questionItem.LeftLimit, questionItem.RightLimit, selectedProfile.Answers);
                            break;
                        }
                    case "radio":
                        {
                            infoDG.Rows.Add(questionItem.Id, questionItem.Content, selectedProfile.Answers);
                            break;
                        }
                    case "checkbox":
                        {
                            infoDG.Rows.Add(questionItem.Id, questionItem.Content, selectedProfile.Answers);
                            break;
                        }
                    default:
                        break;
                }
            }

        }
    }
}
