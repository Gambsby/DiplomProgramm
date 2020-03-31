using System;
using System.Collections.Generic;

namespace VisualisationData.Models
{
    public partial class Questiontype
    {
        public Questiontype()
        {
            Question = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Question> Question { get; set; }
    }
}
