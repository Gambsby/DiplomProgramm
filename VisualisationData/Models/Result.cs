using System;
using System.Collections.Generic;

namespace VisualisationData.Models
{
    public partial class Result
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int QuestionId { get; set; }
        public string Answer { get; set; }
        public int QuestionedId { get; set; }

        public virtual Profile Profile { get; set; }
        public virtual Question Question { get; set; }
        public virtual Questioned Questioned { get; set; }
    }
}
