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
                            DeleteMainProfile();
                            Status = true;
                            this.Close();
                            break;
                        }
                    case "load":
                        {
                            LoadMainProfile();
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

        private void DeleteMainProfile()
        {
            var deletedMainProfiles = deleteLB.SelectedItems.Cast<MainProfile>().ToList();
            using (profileContext db = new profileContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var mainProfileItem in deletedMainProfiles)
                        {
                            db.MainProfile.Remove(mainProfileItem);
                        }
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw new Exception("При удалении произошла ошибка. Попытайтесь снова.");
                    }
                }
            }
        }
    
        private void LoadMainProfile()
        {
            List<ExcelResult> answerListContent = new List<ExcelResult>();
            List<ExcelProfile> profilesListContent = new List<ExcelProfile>();

            var mainProfile = deleteLB.SelectedItems.Cast<MainProfile>().ToList()[0];
            using (profileContext db = new profileContext())
            {
                mainProfile = db.MainProfile.SingleOrDefault(p => p == mainProfile);
                db.Entry(mainProfile).Collection(t => t.Profile).Load();
                db.Entry(mainProfile).Collection(t => t.Questioned).Load();
                foreach (var profileItem in mainProfile.Profile)
                {
                    db.Entry(profileItem).Collection(t => t.Question).Load();
                    db.Entry(profileItem).Collection(t => t.Result).Load();
                    db.Entry(profileItem).Reference(t => t.Type).Load();
                    List<ExcelQuestion> questions = new List<ExcelQuestion>();
                    foreach (var questionItem in profileItem.Question)
                    {
                        if (questionItem.LeftLimit == null && questionItem.RightLimit == null)
                        {
                            questions.Add(new ExcelQuestion { Id = questionItem.SerialNumber, Content = questionItem.Content, LeftLimit = "", RightLimit = "" });
                        }
                        else
                        {
                            questions.Add(new ExcelQuestion { Id = questionItem.SerialNumber, Content = questionItem.Content, LeftLimit = questionItem.LeftLimit, RightLimit = questionItem.RightLimit });
                        }
                    }
                    ExcelProfile excelProfile = new ExcelProfile { Id = profileItem.SerialNumber, Answers = profileItem.Answer, Name = profileItem.Name, Type = profileItem.Type.Type, Questions = questions };
                    profilesListContent.Add(excelProfile);

                    foreach (var resultItem in profileItem.Result)
                    {
                        string questionedId = mainProfile.Questioned.SingleOrDefault(q => q.Id == resultItem.QuestionedId).Number;
                        ExcelResult excelResult = new ExcelResult { Id = questionedId, 
                            ProfileNum = resultItem.Profile.SerialNumber, 
                            QuestionNum = resultItem.Question.SerialNumber, 
                            Answer = resultItem.Answer 
                        };
                        answerListContent.Add(excelResult);
                    }
                }
                Document = new ExcelDocument { DocumentName = mainProfile.Name, AnswerListContent = answerListContent, ProfilesListContent = profilesListContent };
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Status = false;
            this.Close();
        }
    }
}
