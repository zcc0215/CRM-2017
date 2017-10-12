using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrderManage
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int? omId { get; set; }
        /// <summary>
        /// 关联业务机会
        /// </summary>
        public int omfkbcId { get; set; }
        /// <summary>
        /// 订单名称
        /// </summary>
        public string omName { get; set; }

        #region 视图模型
        public int? cmfkomId { get; set; }
        #endregion
    }
}
