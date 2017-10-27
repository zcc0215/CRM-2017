using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DBUtility.KeyID(ID = "rbId")]
    public class RoleButton
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int? rbId { get; set; }
        /// <summary>
        /// 按钮名称
        /// </summary>
        public string rbName { get; set; }
        /// <summary>
        /// 按钮路径地址
        /// </summary>
        public string rbHref { get; set; }
        /// <summary>
        /// 按钮显示名称
        /// </summary>
        public string rbHrefName { get; set; }
        /// <summary>
        /// 按钮代码
        /// </summary>
        public string rbCode { get; set; }
    }
}
