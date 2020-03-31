using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
