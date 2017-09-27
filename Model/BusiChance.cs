using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BusiChance
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int? bcId { get; set; }
        /// <summary>
        /// 关联销售计划
        /// </summary>
        public int? bcfkspId { get; set; }
        /// <summary>
        /// 业务机会名称
        /// </summary>
        public string bcName { get; set; }
        /// <summary>
        /// 存储过程操作类型
        /// </summary>
        public string bcType { get; set; }
    }
}
