using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualisationData.Excel;
using VisualisationData.Models;
using VisualisationData.Services;

namespace VisualisationData.DataSettingForms
{
    public partial class ChooseMainProfileForm : Form
    {
        public ExcelDocument Document { get; set; }
        public bool Status { get; set; } = false;

        private string type;
        public ChooseMainProfileForm(string type)
        {
            InitializeComponent();
            this.type = type;
        }

        private void DeleteSettingForm_Load(object sender, EventArgs e)
        {
            using (profileContext db = new profileContext())
            {
                var mainProfiles = db.MainProfile.Select(x => x).ToArray();
                deleteLB.Items.AddRange(mainProfiles);
            }
            switch (type)
            {
                case "delete":
                    {
                        deleteLB.SelectionMode = SelectionMode.MultiExtended;
                        break;
                    }
                case "load":
                    {
                        deleteLB.SelectionMode = SelectionMode.One;
                        break;
                    }
                default:
                    break;
            }
        }

        private void acceptBtn_Click(object sender, EventArgs e)
        {
            try
            {
                switch (type)
                {
                    case "delete":
                        {
                            var deletedMainProfiles = deleteLB.SelectedItems.Cast<MainProfile>().ToList();
                            SaveService.DeleteMainProfile(deletedMainProfiles);
                            Status = true;
                            this.Close();
                            break;
                        }
                    case "load":
                        {
                            var mainProfile = deleteLB.SelectedItems.Cast<MainProfile>().ToList()[0];
                            Document = SaveService.LoadMainProfileDB(mainProfile);
                            Status = true;
                            this.Close();
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Document = null;
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Status = false;
            this.Close();
        }
    }
}
