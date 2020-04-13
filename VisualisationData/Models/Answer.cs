using System;
using System.Collections.Generic;

namespace VisualisationData.Models
{
    public partial class Answer
    {
        public Answer()
        {
            Result = new HashSet<Result>();
        }

        public int Id { get; set; }
        public string Content { get; set; }
        public int PeopleId { get; set; }

        public virtual Profile People { get; set; }
        public virtual ICollection<Result> Result { get; set; }
    }
}
