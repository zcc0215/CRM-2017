using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ExportDAL
    {
        /// <summary>
        /// 业务分析
        /// </summary>
        /// <returns></returns>
        public DataTable BusiAnalysis()
        {
            string sql = "select * from SaleProject s left join BusiChance b on s.spId=b.bcfkspId"+
                            " left join OrderManage o on b.bcId = o.omfkbcId"+
                            " left join ContractManage c on o.omId = c.cmfkomId"+
                            " left join Role r on s.spfkRole = r.rId"+
                            " left join ActivityManage am on s.spfkamId = am.amId"+
                            " left join TargetCustomers tc on s.spfktcId = tc.tcId";
            DataTable dt = DBUtility.SqlHelper.SelectDataSet(sql).Tables[0];
            return dt;
        }
    }
}
