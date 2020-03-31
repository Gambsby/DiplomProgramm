using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualisationData.Excel
{
    public class ExcelProfile
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<ExcelQuestion> Questions { get; set; } = new List<ExcelQuestion>();
    }
}
