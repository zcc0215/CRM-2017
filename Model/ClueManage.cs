using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DBUtility.KeyID(ID = "cmId")]
    public class ClueManage
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int? cmId { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string cmCustomerName { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string cmPhone { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string cmEmail { get; set; }
        /// <summary>
        /// 意向开始时间
        /// </summary>
        public string cmBeginTime { get; set; }
        /// <summary>
        /// 意向结束时间
        /// </summary>
        public string cmEndTime { get; set; }
    }
}
