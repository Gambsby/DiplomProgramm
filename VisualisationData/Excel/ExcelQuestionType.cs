﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VisualisationData.Excel
{
    public class ExcelQuestionType
    {
        public int Id { get; set; }
        public string ProfileName { get; set; }
        public string Answers { get; set; }
        public string Sheet { get; set; }

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
            //return "\"" + Id + "\"";
            return Id.ToString();
        }

        public string GetProfileName()
        {
            //return "\"" + ProfileName + "\"";
            return ProfileName;
        }

        public string GetAnswers()
        {
            //return "\"" + Answers + "\"";
            return Answers;
        }
    }
}
