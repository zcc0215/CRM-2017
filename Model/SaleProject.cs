using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SaleProject
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int? spId { get; set; }
        /// <summary>
        /// 责任人角色
        /// </summary>
        public int? spfkRole { get; set; }
        /// <summary>
        /// 关联市场活动
        /// </summary>
        public int? spfkamId { get; set; }
        /// <summary>
        /// 关联目标客户
        /// </summary>
        public int? spfktcId { get; set; }
        /// <summary>
        /// 销售计划名称
        /// </summary>
        public string spName { get; set; }
        /// <summary>
        /// 销售计划起始时间
        /// </summary>
        public DateTime? spBeginTime { get; set; }
        /// <summary>
        /// 销售计划结束时间
        /// </summary>
        public DateTime? spEndTime { get; set; }

        #region 视图模型 
        public int? bcfkspId { get; set; }
        #endregion
    }
}
