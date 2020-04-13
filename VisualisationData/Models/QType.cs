using System;
using System.Collections.Generic;

namespace VisualisationData.Models
{
    public partial class QType
    {
        public QType()
        {
            Profile = new HashSet<Profile>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Profile> Profile { get; set; }
    }
}
