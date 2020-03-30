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
using VisualisationData.Excel;
using VisualisationData.Services;

namespace VisualisationData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            /*List<ExcelQuestionType> profileNames =  ExcelService.GetProfileNames(@"физвоспитание анкета.xlsx", "Опросы ФВ");
            List<ExcelProfile> firstProfile = ExcelService.GetProfiles(@"физвоспитание анкета.xlsx", "цель", "radio");
            List<ExcelProfile> secondProfile = ExcelService.GetProfiles(@"физвоспитание анкета.xlsx", "здоровье", "range");
            List<ExcelProfile> thirdProfile = ExcelService.GetProfiles(@"физвоспитание анкета.xlsx", "успех", "radio");
            List<ExcelAnswer> answers = ExcelService.GetAnswers(@"физвоспитание анкета.xlsx", "ответы");*/
        }

        private void downloadDataBtn_Click(object sender, EventArgs e)
        {
            /*List<ExcelQuestionType> profileNames = ExcelService.GetProfileNames(@"физвоспитание анкета.xlsx", "Опросы ФВ");
            List<ExcelProfile> firstProfile = ExcelService.GetProfiles(@"физвоспитание анкета.xlsx", "цель", "radio");
            List<ExcelProfile> secondProfile = ExcelService.GetProfiles(@"физвоспитание анкета.xlsx", "здоровье", "range");
            List<ExcelProfile> thirdProfile = ExcelService.GetProfiles(@"физвоспитание анкета.xlsx", "успех", "radio");
            List<ExcelAnswer> answers = ExcelService.GetAnswers(@"физвоспитание анкета.xlsx", "ответы");*/

            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filePath = openFileDialog.FileName;
            DownloadSettingForm downloadSettingForm = new DownloadSettingForm(filePath);
            downloadSettingForm.ShowDialog();
        }
    }
}
