using System;
using System.Collections.Generic;

namespace VisualisationData.Models
{
    public partial class Questioned
    {
        public Questioned()
        {
            Result = new HashSet<Result>();
        }

        public int Id { get; set; }
        public string Number { get; set; }

        public virtual ICollection<Result> Result { get; set; }
    }
}
