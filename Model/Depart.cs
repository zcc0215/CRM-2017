using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DBUtility.KeyID(ID = "hrdId")]
    public class Depart
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int? hrdId { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string hrdDepartName { get; set; }
    }
}
