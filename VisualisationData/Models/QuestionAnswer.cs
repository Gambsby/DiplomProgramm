using System;
using System.Collections.Generic;

namespace VisualisationData.Models
{
    public partial class QuestionAnswer
    {
        public QuestionAnswer()
        {
            Result = new HashSet<Result>();
        }

        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }

        public virtual Answer Answer { get; set; }
        public virtual Question Question { get; set; }
        public virtual ICollection<Result> Result { get; set; }
    }
}
