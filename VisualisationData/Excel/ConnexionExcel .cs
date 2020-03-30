﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToExcel;

namespace VisualisationData.Excel
{
    class ConnexionExcel
    {
        private string _pathExcelFile;
        private ExcelQueryFactory _urlConnexion;
        public ConnexionExcel(string path)
        {
            this._pathExcelFile = path;
            this._urlConnexion = new ExcelQueryFactory(_pathExcelFile);
        }
        public string PathExcelFile
        {
            get
            {
                return _pathExcelFile;
            }
        }
        public ExcelQueryFactory UrlConnexion
        {
            get
            {
                return _urlConnexion;
            }
        }
    }
}
