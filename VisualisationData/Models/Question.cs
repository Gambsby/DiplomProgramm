using System;
using System.Collections.Generic;

namespace VisualisationData.Models
{
    public partial class Question
    {
        public Question()
        {
            Result = new HashSet<Result>();
        }

        public int Id { get; set; }
        public int SerialNumber { get; set; }
        public string Content { get; set; }
        public int? LimitsId { get; set; }
        public int ProfileId { get; set; }

        public virtual Limits Limits { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual ICollection<Result> Result { get; set; }
    }
}
