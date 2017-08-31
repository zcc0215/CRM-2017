using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 活动结果
    /// </summary>
    public enum amResult
    {

        未评价 = 0,

        一般 = 1,

        中等 = 2,

        好评 = 3

    }
    [DBUtility.KeyID(ID = "amId")]
    public class ActivityManage
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int? amId { get; set; }
        /// <summary>
        /// 活动名称
        /// </summary>
        public string amName { get; set; }
        /// <summary>
        /// 指派角色
        /// </summary>
        public int? amfkRole { get; set; }
        /// <summary>
        /// 预算
        /// </summary>
        public dynamic amBudget { get; set; }
        /// <summary>
        /// 活动评价
        /// </summary>
        public int? amResult { get; set; }
        /// <summary>
        /// 活动开始时间
        /// </summary>
        public DateTime? amBeginTime { get; set; }
        /// <summary>
        /// 活动结束时间
        /// </summary>
        public DateTime? amEndTime { get; set; }

        #region 视图模型
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
        #endregion
    }
}
