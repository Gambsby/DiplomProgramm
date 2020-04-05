﻿using System;
using System.Collections.Generic;

namespace VisualisationData.Models
{
    public partial class MainProfile
    {
        public MainProfile()
        {
            Profile = new HashSet<Profile>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Profile> Profile { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
