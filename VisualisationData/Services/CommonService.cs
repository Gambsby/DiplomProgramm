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

        public static SeriesChartType? ConvertToSeriesChartType(string source)
        {
            switch (source)
            {
                case "Area":
                    {
                        return SeriesChartType.Area;
                    }
                case "SplineArea":
                    {
                        return SeriesChartType.SplineArea;
                    }
                case "StackedArea":
                    {
                        return SeriesChartType.StackedArea;
                    }
                case "StackedArea100":
                    {
                        return SeriesChartType.StackedArea100;
                    }
                case "Pie":
                    {
                        return SeriesChartType.Pie;
                    }
                case "Doughnut":
                    {
                        return SeriesChartType.Doughnut;
                    }
                case "Bar":
                    {
                        return SeriesChartType.Bar;
                    }
                case "StackedBar":
                    {
                        return SeriesChartType.StackedBar;
                    }
                case "StackedBar100":
                    {
                        return SeriesChartType.StackedBar100;
                    }
                case "Column":
                    {
                        return SeriesChartType.Column;
                    }
                case "StackedColumn":
                    {
                        return SeriesChartType.StackedColumn;
                    }
                case "StackedColumn100":
                    {
                        return SeriesChartType.StackedColumn100;
                    }
                case "Line":
                    {
                        return SeriesChartType.Line;
                    }
                case "FastLine":
                    {
                        return SeriesChartType.FastLine;
                    }
                case "Spline":
                    {
                        return SeriesChartType.Spline;
                    }
                case "FastPoint":
                    {
                        return SeriesChartType.FastPoint;
                    }
                case "Point":
                    {
                        return SeriesChartType.Point;
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        public static Color ChooseColor(ColorDialog colorDialog, Color oldColor)
        {
            colorDialog.FullOpen = true;
            colorDialog.Color = oldColor;

            if (colorDialog.ShowDialog() == DialogResult.Cancel)
                return oldColor;

            return colorDialog.Color;
        }
    }
}
