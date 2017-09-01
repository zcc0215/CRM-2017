using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TargetCustomers
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int? tcId { get; set; }
        /// <summary>
        /// 关联任务
        /// </summary>
        public int? tcfkamId { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string tcName { get; set; }
        /// <summary>
        /// 客户性别
        /// </summary>
        public string tcSex { get; set; }
        /// <summary>
        /// 客户电话
        /// </summary>
        public string tcPhone { get; set; }
        /// <summary>
        /// 客户邮箱
        /// </summary>
        public string tcEmail { get; set; }
    }
}
