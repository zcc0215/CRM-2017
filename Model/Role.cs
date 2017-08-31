using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DBUtility.KeyID(ID = "rId")]
    public class Role
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int? rId { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 拥有权限的按钮
        /// </summary>
        public string RoleButtons { get; set; }
    }
}
