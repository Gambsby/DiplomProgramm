using System;
using System.Collections.Generic;
using System.Linq;

namespace VisualisationData.Models
{
    public partial class Profile
    {
        public Profile()
        {
            Answer = new HashSet<Answer>();
            Limits = new HashSet<Limits>();
            Question = new HashSet<Question>();
            Result = new HashSet<Result>();
        }

        public int Id { get; set; }
        public int SerialNumber { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public int MainProfileId { get; set; }

        public virtual MainProfile MainProfile { get; set; }
        public virtual QType Type { get; set; }
        public virtual ICollection<Answer> Answer { get; set; }
        public virtual ICollection<Limits> Limits { get; set; }
        public virtual ICollection<Question> Question { get; set; }
        public virtual ICollection<Result> Result { get; set; }

        public string GetAnswersStr()
        {
            switch (Type.Name)
            {
                case "range":
                    {
                        int min = Answer.Min(x => Convert.ToInt32(x.Content));
                        int max = Answer.Max(x => Convert.ToInt32(x.Content));
                        return "от " + min + " до " + max;
                    }
                case "radio":
                    {
                        return string.Join("/", Answer.Select(a => a.Content).ToList());
                    }
                case "checkbox":
                    {
                        return string.Join(";", Answer.Select(a => a.Content).ToList());
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }
    }
}
