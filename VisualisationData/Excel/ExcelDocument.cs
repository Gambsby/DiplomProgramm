using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualisationData.Excel
{
    public class ExcelDocument
    {
        public string DocumentName { get; set; }
        public List<ExcelResult> AnswerListContent { get; set; } = new List<ExcelResult>();
        public List<ExcelProfile> ProfilesListContent { get; set; } = new List<ExcelProfile>();
    }
}
