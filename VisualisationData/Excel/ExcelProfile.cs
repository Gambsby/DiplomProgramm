using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VisualisationData.Excel
{
    public class ExcelProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Answers { get; set; }
        public List<ExcelQuestion> Questions { get; set; } = new List<ExcelQuestion>();

        public List<string> GetProfileAnswers()
        {
            List<string> answers = new List<string>();
            switch (Type)
            {
                case "range":
                    {
                        var matches = Regex.Match(Answers, "^от *(-?\\d+) *до *(-?\\d+)$");
                        var a = matches.Groups[1].Value;
                        int start = Convert.ToInt32(matches.Groups[1].Value);
                        int end = Convert.ToInt32(matches.Groups[2].Value);
                        answers = new List<string>();
                        for (int i = start; i <= end; i++)
                        {
                            answers.Add(i.ToString());
                        }
                        break;
                    }
                case "radio":
                    {
                        answers = Answers.Split('/').ToList();
                        break;
                    }
                case "checkbox":
                    {
                        answers = Answers.Split(';').ToList();
                        break;
                    }
            }

            for (int i = 0; i < answers.Count; i++)
            {
                answers[i] = answers[i].ToLower();
            }

            return answers;
        }

        public override string ToString()
        {
            return Name;
        }

        public string GetId()
        {
            //return "\"" + Id + "\"";
            return Id.ToString();
        }

        public string GetName()
        {
            //return "\"" + Name + "\"";
            return Name;
        }

        public string GetAnswers()
        {
            //return "\"" + Answers + "\"";
            return Answers;
        }
    }
}
