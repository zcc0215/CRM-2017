using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 任务结果
    /// </summary>
    public enum aaResult
    {

        未启动 = 0,

        进行中 = 1,

        已完成 = 2

    }
    [DBUtility.KeyID(ID = "aaId")]
    public class ActivityAssignManage
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int? aaId { get; set; }
        /// <summary>
        /// 关联任务
        /// </summary>
        public int? aafkamId { get; set; }
        /// <summary>
        /// 任务名称
        /// </summary>
        public string aaName { get; set; }
        /// <summary>
        /// 任务预算
        /// </summary>
        public decimal aaBudget { get; set; }
        /// <summary>
        /// 任务责任人
        /// </summary>
        public int? aafkRole { get; set; }
        /// <summary>
        /// 任务结果
        /// </summary>
        public int? aaResult { get; set; }
        /// <summary>
        /// 任务备注
        /// </summary>
        public string aaRemark { get; set; }
        /// <summary>
        /// 活动开始时间
        /// </summary>
        public DateTime? aaBeginTime { get; set; }
        /// <summary>
        /// 活动结束时间
        /// </summary>
        public DateTime? aaEndTime { get; set; }

        #region 视图模型
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
        #endregion
    }
}
