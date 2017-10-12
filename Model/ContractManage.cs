using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ContractManage
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int? cmId { get; set; }
        /// <summary>
        /// 关联订单
        /// </summary>
        public int? cmfkomId { get; set; }
        /// <summary>
        /// 合同名称
        /// </summary>
        public string cmName { get; set; }
    }
}
