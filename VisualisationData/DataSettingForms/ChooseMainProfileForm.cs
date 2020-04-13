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
            switch (type)
            {
                case "delete":
                    {
                        DeleteMainProfile();
                        break;
                    }
                case "load":
                    {
                        LoadMainProfile();
                        break;
                    }
                default:
                    break;
            }
        }

        private void DeleteMainProfile()
        {
            var deletedMainProfiles = deleteLB.SelectedItems.Cast<MainProfile>().ToList();
            using (profileContext db = new profileContext())
            {
                foreach (var mainProfileItem in deletedMainProfiles)
                {
                    db.MainProfile.Remove(mainProfileItem);
                }
                db.SaveChanges();
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
                foreach (var profileItem in mainProfile.Profile)
                {
                    db.Entry(profileItem).Collection(t => t.Answer).Load();
                    db.Entry(profileItem).Collection(t => t.Question).Load();
                    db.Entry(profileItem).Collection(t => t.Result).Load();
                    db.Entry(profileItem).Reference(t => t.Type).Load();
                    List<ExcelQuestion> questions = new List<ExcelQuestion>();
                    foreach (var questionItem in profileItem.Question)
                    {
                        db.Entry(questionItem).Reference(t => t.Limits).Load();
                        if (questionItem.Limits == null)
                        {
                            questions.Add(new ExcelQuestion { Id = questionItem.SerialNumber, Content = questionItem.Content, LeftLimit = "", RightLimit = "" });
                        }
                        else
                        {
                            questions.Add(new ExcelQuestion { Id = questionItem.SerialNumber, Content = questionItem.Content, LeftLimit = questionItem.Limits.LeftLimit, RightLimit = questionItem.Limits.RightLimit });
                        }
                    }
                    ExcelProfile excelProfile = new ExcelProfile { Id = profileItem.SerialNumber, Answers = profileItem.GetAnswersStr(), Name = profileItem.Name, Type = profileItem.Type.Name, Questions = questions };
                    profilesListContent.Add(excelProfile);

                    var a = profileItem.Result.GroupBy(x => new { x.QuestionedId, x.ProfileId, x.QuestionId });
                    foreach (var resultItem in profileItem.Result)
                    {

                        ExcelResult excelResult = new ExcelResult { Id = resultItem.Questioned.Number, 
                            ProfileNum = resultItem.Profile.SerialNumber, 
                            QuestionNum = resultItem.Question.SerialNumber, 
                            Answer = resultItem.Answer.Content 
                        };
                    }
                }

                

                foreach (var questionedItem in mainProfile.Questioned)
                {
                    db.Entry(questionedItem).Collection(t => t.Result).Load();
                    foreach (var resultItem in questionedItem.Result)
                    {
                        ExcelResult excelResult = new ExcelResult { Id = resultItem.Questioned.Number, ProfileNum = resultItem.Profile.SerialNumber, QuestionNum = resultItem.Question.SerialNumber, Answer = resultItem.Answer.Content };
                        answerListContent.Add(excelResult);
                    }
                }
                ExcelDocument excelDocument = new ExcelDocument { DocumentName = mainProfile.Name, AnswerListContent = answerListContent, ProfilesListContent = profilesListContent };
            }
        }
    }
}
