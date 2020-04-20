using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace VisualisationData.Services
{
    class CommonService
    {

        public static DataGridViewTextBoxColumn CreateTextColumn(string nameCol, string nameVar, bool fill = false, bool readOnly = true)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = nameCol;
            column.Name = nameVar;
            column.ReadOnly = readOnly;
            if (fill)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            return column;
        }

        public static DataGridViewCheckBoxColumn CreateCheckColumn(string nameCol, string nameVar, bool fill = false, bool readOnly = true)
        {
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            column.HeaderText = nameCol;
            column.Name = nameVar;
            column.ReadOnly = readOnly;
            if (fill)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            return column;
        }

        public static DataGridViewComboBoxColumn CreateComboColumn(string nameCol, string nameVar, bool fill = false, bool readOnly = true)
        {
            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
            column.HeaderText = nameCol;
            column.Name = nameVar;
            column.ReadOnly = readOnly;
            if (fill)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            return column;
        }

        public static Title CreateTitle(string name, string text)
        {
            Title title = new Title();
            title.Name = name;
            title.Text = text;

            return title;
        }

        public static Legend CreateLegend(Series series, string name)
        {
            Legend legend = new Legend();
            legend.Name = name;

            for (int i = 0; i < series.Points.Count; i++)
            {
                DataPoint dataPointItem = series.Points[i];

                LegendItem newItem = new LegendItem();
                newItem.SeriesPointIndex = i;
                newItem.ImageStyle = LegendImageStyle.Rectangle;
                newItem.Color = dataPointItem.Color;
                newItem.Cells.Add(LegendCellType.SeriesSymbol, "", ContentAlignment.MiddleLeft); // Symbol
                newItem.Cells.Add(LegendCellType.Text, dataPointItem.AxisLabel, ContentAlignment.MiddleLeft); // Series Name
                legend.CustomItems.Add(newItem);
            }

            return legend;
        }

        public static Color ChooseColor(ColorDialog colorDialog, Color oldColor)
        {
            colorDialog.FullOpen = false;
            colorDialog.CustomColors = GetIntColors(Form1.CompanyColor);
            colorDialog.Color = oldColor;

            if (colorDialog.ShowDialog() == DialogResult.Cancel)
                return oldColor;
            else
                return colorDialog.Color;
        }
        
        private static int[] GetIntColors(Dictionary<string, Color> colors)
        {
            List<int> intColors = new List<int>();
            foreach (var colorItem in colors.Values)
            {
                intColors.Add(ColorTranslator.ToOle(colorItem));
            }

            return intColors.ToArray();
        }
    
        public static string GetFolderPath()
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                var res = fbd.ShowDialog();
                if (res == DialogResult.OK)
                    return fbd.SelectedPath;
                else 
                {
                    return null;
                }
            }
        }
        
        public static string OpenFilePath(string filter, string fileName = "")
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Открыть файл ...";
                ofd.Filter = filter;
                ofd.AddExtension = true;
                ofd.FileName = fileName;
                if (ofd.ShowDialog() == DialogResult.OK)
                    return ofd.FileName; 
                else
                {
                    return null;
                }
            }
        }
    
        public static string SaveFilePath(string filter, string fileName = "")
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Сохранить файл как ...";
                sfd.Filter = filter;
                sfd.AddExtension = true;
                sfd.FileName = fileName;
                var res = sfd.ShowDialog();
                if (res == DialogResult.OK)
                {
                    return sfd.FileName;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
