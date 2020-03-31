using System;
using System.Collections.Generic;

namespace VisualisationData.Models
{
    public partial class Result
    {
        public int Id { get; set; }
        public int QuestionedId { get; set; }
        public int QuestionAnswerId { get; set; }

        public virtual QuestionAnswer QuestionAnswer { get; set; }
        public virtual Questioned Questioned { get; set; }
    }
}
