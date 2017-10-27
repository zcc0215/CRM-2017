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
        public DataTable BusiAnalysis(int Begin = 0, int End = 0, int Type = 0)
        {
            string sql = string.Empty;

            string Select = "select  RowNo '序号',spName '销售计划名称',bcName '业务机会名称',omName '订单名称',cmName '合同名称'" +
                            ",RoleName '责任人',amName '活动名称',tcName '目标客户名称' ";

            string From = " from SaleProject s left join BusiChance b on s.spId=b.bcfkspId" +
                            " left join OrderManage o on b.bcId = o.omfkbcId" +
                            " left join ContractManage c on o.omId = c.cmfkomId" +
                            " left join Role r on s.spfkRole = r.rId" +
                            " left join ActivityManage am on s.spfkamId = am.amId" +
                            " left join TargetCustomers tc on s.spfktcId = tc.tcId";

            if (Type == 1)//获取总行数
            {
                sql = "select COUNT(1)  Total" + From;
            }
            else
            {
                if (Begin == 0 && End == 0)//不分页
                {
                    sql = "select * "+From;
                }
                else//分页
                {
                    sql = Select+ "   from (SELECT  ROW_NUMBER() OVER(ORDER BY spId) RowNo,t.* from (" +
                           "Select * "+From+
                           ") t) w where  RowNo BETWEEN " + Begin + " and " + End + "";
                }
            }
            
            DataTable dt = DBUtility.SqlHelper.SelectDataSet(sql).Tables[0];
            return dt;
        }
    }
}
