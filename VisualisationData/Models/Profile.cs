using System;
using System.Collections.Generic;

namespace VisualisationData.Models
{
    public partial class Profile
    {
        public Profile()
        {
            Answer = new HashSet<Answer>();
            Limits = new HashSet<Limits>();
            Question = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Answer> Answer { get; set; }
        public virtual ICollection<Limits> Limits { get; set; }
        public virtual ICollection<Question> Question { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
