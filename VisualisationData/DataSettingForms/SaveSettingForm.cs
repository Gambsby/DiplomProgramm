using CsvHelper;
using CsvHelper.Configuration;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualisationData.Excel;
using VisualisationData.Services;

namespace VisualisationData.DataSettingForms
{
    public partial class SaveSettingForm : Form
    {
        public bool Status { get; set; }
        private ExcelDocument Document { get; set; }
        private string type;
        public SaveSettingForm(ExcelDocument excelDocument, string type)
        {
            InitializeComponent();
            this.Document = excelDocument;
            this.type = type;
        }

        private void SaveSettingForm_Load(object sender, EventArgs e)
        {
            chooseDG.Columns.Add(CommonService.CreateTextColumn("Анкета", "profile", true));
            switch (type)
            {
                case "excel":
                    {
                        infoLbl.Text = "Введите название листа с информацией о возможных ответах:";
                        resultLbl.Text = "Ведите название листа с результатами анкетирования:";
                        chooseDG.Columns.Add(CommonService.CreateTextColumn("Название листа", "sheetName", true, false));
                        break;
                    }
                case "csv":
                    {
                        infoLbl.Text = "Введите название файла с информацией о возможных ответах:";
                        resultLbl.Text = "Ведите название файла с результатами анкетирования:";
                        chooseDG.Columns.Add(CommonService.CreateTextColumn("Название файла", "sheetName", true, false));
                        break;
                    }
                default:
                    break;
            }

            foreach (var profileEtem in Document.ProfilesListContent)
            {
                chooseDG.Rows.Add(profileEtem);
            }
        }

        private void acceptBtn_Click(object sender, EventArgs e)
        {
            Dictionary<string, ExcelProfile> excelProfileMap = new Dictionary<string, ExcelProfile>();
            string infoFileName = null;
            string resultFileName = null;

            try
            {
                infoFileName = profileInfoTB.Text;
                if (string.IsNullOrEmpty(infoFileName))
                {
                    throw new Exception("Пропущено поле с названием файла с информацией об анкетах.");
                }
                resultFileName = resultInfoTB.Text;
                if (string.IsNullOrEmpty(resultFileName))
                {
                    throw new Exception("Пропущено поле с названием файла с результатами анкетирования.");
                }
                foreach (DataGridViewRow rowItem in chooseDG.Rows)
                {
                    ExcelProfile profile = rowItem.Cells["profile"].Value as ExcelProfile;
                    if (rowItem.Cells["sheetName"].Value == null)
                    {
                        throw new Exception("Пропущено поле с названием файла с вопросами для анкеты \"" + profile.Name + "\".");
                    }
                    string sheetName = rowItem.Cells["sheetName"].Value.ToString();
                    if (string.IsNullOrEmpty(sheetName))
                    {
                        throw new Exception("Пропущено поле с названием файла с вопросами для анкеты \"" + profile.Name + "\".");
                    }
                    else
                    {
                        excelProfileMap.Add(sheetName, profile);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }


            try
            {
                switch (type)
                {
                    case "excel":
                        {
                            SaveService.SaveExcel(infoFileName, resultFileName, excelProfileMap, Document);
                            break;
                        }
                    case "csv":
                        {
                            SaveService.SaveCSV(infoFileName, resultFileName, excelProfileMap, Document);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при сохранении.");
                return;
            }

            Status = true;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Status = false;
            this.Close();
        }
    }
}
