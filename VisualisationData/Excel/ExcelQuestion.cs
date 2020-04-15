using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualisationData.Excel
{
    public class ExcelQuestion
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string LeftLimit { get; set; }
        public string RightLimit { get; set; }

        public string GetId()
        {
            //return "\"" + Id + "\"";
            return Id.ToString();
        }
        
        public string GetContent()
        {
            //return "\"" + Content + "\"";
            return Content;
        }
        
        public string GetLeftLimit()
        {
            if (!string.IsNullOrEmpty(LeftLimit))
            {
                //return "\"" + LeftLimit + "\"";
                return LeftLimit;
            }
            else
            {
                return string.Empty;
            }
        }
        
        public string GetRightLimit()
        {
            if (!string.IsNullOrEmpty(RightLimit))
            {
                //return "\"" + RightLimit + "\"";
                return RightLimit;
            }
            else
            {
                return string.Empty;
            }
        }

        public override string ToString()
        {
            return Content;
        }
    }
}
