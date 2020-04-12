using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VisualisationData.Excel
{
    public class ExcelQuestionType : ExcelClass
    {
        public int Id { get; set; }
        public string ProfileName { get; set; }
        public string Answers { get; set; }

        public string GetProfileType()
        {
            string type;
            if (Regex.IsMatch(Answers, "^от.+до.+$"))
            {
                type = "range";
            }
            else if (Regex.IsMatch(Answers, ";"))
            {
                type = "checkbox";
            }
            else if (Regex.IsMatch(Answers, "/"))
            {
                type = "radio";
            }
            else
            {
                type = null;
            }
            return type;
        }

        public string GetId()
        {
            return "\"" + Id + "\"";
        }

        public string GetProfileName()
        {
            return "\"" + ProfileName + "\"";
        }

        public string GetAnswers()
        {
            return "\"" + Answers + "\"";
        }

        public override string GetCsvString()
        {
            return GetId() + "," + GetProfileName() + "," + GetAnswers() + "\r\n";
        }
    }
}
