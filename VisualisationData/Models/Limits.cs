using System;
using System.Collections.Generic;

namespace VisualisationData.Models
{
    public partial class Limits
    {
        public Limits()
        {
            Question = new HashSet<Question>();
        }

        public int Id { get; set; }
        public int ProfileId { get; set; }
        public string LeftLimit { get; set; }
        public string RightLimit { get; set; }

        public virtual Profile Profile { get; set; }
        public virtual ICollection<Question> Question { get; set; }
    }
}
