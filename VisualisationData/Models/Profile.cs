using System;
using System.Collections.Generic;

namespace VisualisationData.Models
{
    public partial class Profile
    {
        public Profile()
        {
            Question = new HashSet<Question>();
            Result = new HashSet<Result>();
        }

        public int Id { get; set; }
        public int SerialNumber { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string Answer { get; set; }
        public int MainProfileId { get; set; }

        public virtual MainProfile MainProfile { get; set; }
        public virtual QType Type { get; set; }
        public virtual ICollection<Question> Question { get; set; }
        public virtual ICollection<Result> Result { get; set; }
    }
}
