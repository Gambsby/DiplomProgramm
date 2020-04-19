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
        public string Type { get; set; } = "delete";
        public bool Status { get; set; } = false;
        public List<MainProfile> SelectedMainProfiles { get; set; } = null;

        public ChooseMainProfileForm()
        {
            InitializeComponent();
        }

        private void DeleteSettingForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (profileContext db = new profileContext())
                {
                    var mainProfiles = db.MainProfile.Select(x => x).ToArray();
                    deleteLB.Items.AddRange(mainProfiles);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
                return;
            }

            switch (Type)
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
                switch (Type)
                {
                    case "delete":
                        {
                            SelectedMainProfiles = deleteLB.SelectedItems.Cast<MainProfile>().ToList();
                            Status = true;
                            this.Close();
                            break;
                        }
                    case "load":
                        {
                            SelectedMainProfiles = deleteLB.SelectedItems.Cast<MainProfile>().ToList();
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
