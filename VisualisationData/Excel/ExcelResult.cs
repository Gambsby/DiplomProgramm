﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualisationData.Excel
{
    public class ExcelResult : ExcelClass
    {
        public string Id { get; set; }
        public int ProfileNum { get; set; }
        public int QuestionNum { get; set; }
        public string Answer { get; set; }

        public List<string> GetAnswers()
        {
            string[] answers = Answer.Split(';');
            for (int i = 0; i < answers.Length; i++)
            {
                answers[i] = answers[i].Trim();
            }
            return answers.ToList();
        }

        public string GetId()
        {
            //return "\"" + Id + "\"";
            return Id;
        }

        public string GetProfileNum()
        {
            //return "\"" + ProfileNum + "\"";
            return ProfileNum.ToString();
        }

        public string GetQuestionNum()
        {
            //return "\"" + QuestionNum + "\"";
            return QuestionNum.ToString();
        }

        public string GetAnswer()
        {
            //return "\"" + Answer + "\"";
            return Answer;
        }

        public override string GetCsvString()
        {
            return GetId() + "," + GetProfileNum() + "," + GetQuestionNum() + "," + GetAnswer() + "\r\n";
        }
    }
}
