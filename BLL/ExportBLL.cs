﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ExportBLL
    {
        /// <summary>
        /// 业务分析
        /// </summary>
        /// <returns></returns>
        public static DataTable BusiAnalysis()
        {
            DAL.ExportDAL ed = new DAL.ExportDAL();
            return ed.BusiAnalysis();
        }
    }
}
