using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualisationData.Excel;
using VisualisationData.Services;

namespace VisualisationData.DataSettingForms
{
    public partial class SheetsSettigsForm : Form
    {
        public string Type { get; set; } = "load";
        public string Format { get; set; } = "excel";
        public ExcelDocument Document { get; set; }
        public string FilePath { get; set; }

        public string InfoFileName { get; set; } = string.Empty;
        public string ResultFileName { get; set; } = string.Empty;
        public Dictionary<string, ExcelProfile> ExcelProfileMap { get; set; } = null;
        public Dictionary<string, string> ExcelSheetMap { get; set; } = null;

        public bool Status { get; set; } = false;

        private List<string> worksheetNames;

        public SheetsSettigsForm()
        {
            InitializeComponent();
        }

        private void acceptBtn_Click(object sender, EventArgs e)
        {
            try
            {
                switch (Type)
                {
                    case "load":
                        {
                            if (acceptBtn.Text == "Далее")
                            {
                                LoadFunctionNext();
                                return;
                            }
                            if (acceptBtn.Text == "Принять")
                            {
                                LoadFunctionAccept();
                            }
                            if (Status)
                            {
                                this.Close();
                            }
                            else
                            {
                                return;
                            }
                            break;
                        }
                    case "save":
                        {
                            SaveFunctionAccept();
                            if (Status)
                            {
                                this.Close();
                            }
                            else
                            {
                                return;
                            }
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SheetsSettigsForm_Load(object sender, EventArgs e)
        {
            InitForm();

            switch (Type)
            {
                case "load":
                    {
                        LoadFunctionLoad();
                        break;
                    }
                case "save":
                    {
                        SaveFunctionLoad();
                        break;
                    }
            }
        }

        private void InitForm()
        {

            chooseDG.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            chooseDG.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;

            switch (Type)
            {
                case "load":
                    {
                        ComboBox firstControl = new ComboBox();
                        firstControl.Name = "firstControl";
                        firstControl.Anchor = AnchorStyles.Left;
                        firstControl.Dock = DockStyle.Fill;
                        tableL2.Controls.Add(firstControl, 1, 0);

                        ComboBox secondControl = new ComboBox();
                        secondControl.Name = "secondControl";
                        secondControl.Anchor = AnchorStyles.Left;
                        secondControl.Dock = DockStyle.Fill;
                        tableL2.Controls.Add(secondControl, 1, 1);

                        break;
                    }
                case "save":
                    {
                        TextBox firstControl = new TextBox();
                        firstControl.Name = "firstControl";
                        firstControl.Anchor = AnchorStyles.Left;
                        firstControl.Dock = DockStyle.Fill;
                        tableL2.Controls.Add(firstControl, 1, 0);

                        TextBox secondControl = new TextBox();
                        secondControl.Name = "secondControl";
                        secondControl.Anchor = AnchorStyles.Left;
                        secondControl.Dock = DockStyle.Fill;
                        tableL2.Controls.Add(secondControl, 1, 1);

                        break;
                    }
            }
        }
        
        private void SaveFunctionLoad()
        {
            chooseDG.Columns.Add(CommonService.CreateTextColumn("Анкета", "profile", true));
            switch (Format)
            {
                case "excel":
                    {
                        firstInfoLbl.Text = "Введите название листа с информацией о возможных ответах:";
                        secondInfoLbl.Text = "Введите название листа с результатами анкетирования:";
                        chooseDG.Columns.Add(CommonService.CreateTextColumn("Название листа", "sheetName", true, false));
                        break;
                    }
                case "csv":
                    {
                        firstInfoLbl.Text = "Введите название файла с информацией о возможных ответах:";
                        secondInfoLbl.Text = "Введите название файла с результатами анкетирования:";
                        chooseDG.Columns.Add(CommonService.CreateTextColumn("Название файла", "sheetName", true, false));
                        break;
                    }
            }
            foreach (var profileEtem in Document.ProfilesListContent)
            {
                chooseDG.Rows.Add(profileEtem);
            }
        }
    
        private void SaveFunctionAccept()
        {
            Dictionary<string, ExcelProfile> excelProfileMap = new Dictionary<string, ExcelProfile>();

            try
            {
                InfoFileName = tableL2.Controls["firstControl"].Text;
                if (string.IsNullOrEmpty(InfoFileName))
                {
                    throw new Exception("Пропущено поле с названием файла с информацией об анкетах.");
                }
                ResultFileName = tableL2.Controls["secondControl"].Text;
                if (string.IsNullOrEmpty(ResultFileName))
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
                ExcelProfileMap = excelProfileMap;

                Status = true;
            }
            catch (Exception ex)
            {
                Status = false;
                MessageBox.Show(ex.Message);
            }
        }
    
        private void LoadFunctionLoad()
        {
            firstInfoLbl.Text = "Выберите лист с информацией о возможных ответах:";
            secondInfoLbl.Text = "Выберите лист с результатами анкетирования:";
            acceptBtn.Text = "Далее";
            using (var excelPack = new ExcelPackage())
            {
                using (var stream = File.OpenRead(FilePath))
                {
                    excelPack.Load(stream);
                }
                worksheetNames = excelPack.Workbook.Worksheets.Select(w => w.Name).ToList();
            }
            if (worksheetNames.Count == 0)
            {
                throw new Exception("Неудалось получить список листов из выбранного файла.");
            }
            else
            {
                (tableL2.Controls["firstControl"] as ComboBox).Items.AddRange(worksheetNames.ToArray());
                (tableL2.Controls["secondControl"] as ComboBox).Items.AddRange(worksheetNames.ToArray());
            }
        }
    
        private void LoadFunctionNext()
        {
            List<ExcelQuestionType> infoListContent;
            InfoFileName = (tableL2.Controls["firstControl"] as ComboBox).SelectedItem.ToString();
            ResultFileName = (tableL2.Controls["secondControl"] as ComboBox).SelectedItem.ToString();
            try
            {
                infoListContent = GetExcelService.GetProfileNamesEP(FilePath, InfoFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            chooseDG.Columns.Add(CommonService.CreateTextColumn("Идентификатор", "id"));
            chooseDG.Columns.Add(CommonService.CreateTextColumn("Название части анкеты", "profileName", true));
            chooseDG.Columns.Add(CommonService.CreateTextColumn("Возможные ответы", "answers", true));
            chooseDG.Columns.Add(CommonService.CreateComboColumn("Название листа", "sheetName", false, false));

            List<string> profileSheets = worksheetNames.Where(x => x != InfoFileName && x != ResultFileName).ToList();
            foreach (var item in infoListContent)
            {
                chooseDG.Rows.Add(item.Id, item.ProfileName, item.Answers);
                (chooseDG["sheetName", chooseDG.RowCount - 1] as DataGridViewComboBoxCell).Items.AddRange(profileSheets.ToArray());
                int index = 0;
                for (int i = 0; i < (chooseDG["sheetName", chooseDG.RowCount - 1] as DataGridViewComboBoxCell).Items.Count; i++)
                {
                    if ((chooseDG["sheetName", chooseDG.RowCount - 1] as DataGridViewComboBoxCell).Items[i].ToString() == item.Sheet)
                    {
                        index = i;
                        break;
                    }
                }
                chooseDG["sheetName", chooseDG.RowCount - 1].Value = (chooseDG["sheetName", chooseDG.RowCount - 1] as DataGridViewComboBoxCell).Items[index];
            }

            (tableL2.Controls["firstControl"] as ComboBox).Enabled = false;
            (tableL2.Controls["secondControl"] as ComboBox).Enabled = false;
            acceptBtn.Text = "Принять";
        }

        private void LoadFunctionAccept()
        {
            Dictionary<string, string> excelProfileMap = new Dictionary<string, string>();

            for (int i = 0; i < chooseDG.RowCount; i++)
            {
                string profileName = chooseDG["profileName", i].Value.ToString();
                string sheetName = chooseDG["sheetName", i].Value.ToString();

                excelProfileMap.Add(profileName, sheetName);
            }
            ExcelSheetMap = excelProfileMap;

            Status = true;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
