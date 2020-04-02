using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualisationData.Models;

namespace VisualisationData
{
    public partial class DeleteSettingForm : Form
    {
        private List<MainProfile> profiles;
        public List<MainProfile> deleteProfiles;
        public DeleteSettingForm(List<MainProfile> profiles)
        {
            InitializeComponent();
            this.profiles = profiles;
        }

        private void DeleteSettingForm_Load(object sender, EventArgs e)
        {
            deleteLB.Items.AddRange(profiles.ToArray());
        }

        private void acceptBtn_Click(object sender, EventArgs e)
        {
            deleteProfiles = deleteLB.SelectedItems.Cast<MainProfile>().ToList();
        }
    }
}
