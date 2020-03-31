using System;
using System.Collections.Generic;

namespace VisualisationData.Models
{
    public partial class Question
    {
        public Question()
        {
            QuestionAnswer = new HashSet<QuestionAnswer>();
        }

        public int Id { get; set; }
        public string Content { get; set; }
        public int SerialNumber { get; set; }
        public int ProfileId { get; set; }
        public int TypeId { get; set; }
        public int? LimitsId { get; set; }

        public virtual Limits Limits { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual Questiontype Type { get; set; }
        public virtual ICollection<QuestionAnswer> QuestionAnswer { get; set; }
    }
}
