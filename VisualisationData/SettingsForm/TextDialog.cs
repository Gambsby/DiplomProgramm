using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualisationData.SettingsForm
{
    public partial class TextDialog : Form
    {
        private string result = string.Empty;

        private string contentLabel;
        private string contentTextBox;

        public TextDialog(string contentLabel, string contentTextBox)
        {
            InitializeComponent();
            this.contentLabel = contentLabel;
            this.contentTextBox = contentTextBox;
        }

        public string Result { get => result; }

        private void acceptBtn_Click(object sender, EventArgs e)
        {
            result = inputTB.Text;
        }

        private void TextDialog_Load(object sender, EventArgs e)
        {
            infoLbl.Text = contentLabel;
            inputTB.Text = contentTextBox;
        }
    }
}
