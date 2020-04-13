using System;
using System.Collections.Generic;

namespace VisualisationData.Models
{
    public partial class Result
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int QuestionId { get; set; }
        public int? AnswerId { get; set; }
        public int QuestionedId { get; set; }
        public string OpenAnswer { get; set; }

        public virtual Answer Answer { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual Question Question { get; set; }
        public virtual Questioned Questioned { get; set; }
    }
}
