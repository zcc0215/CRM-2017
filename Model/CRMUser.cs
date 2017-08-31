using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DBUtility.KeyID(ID = "uId")]
    public class CRMUser
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int? uId { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 所属部门
        /// </summary>
        public int? ufkDepart { get; set; }
        /// <summary>
        /// 所属角色
        /// </summary>
        public int? ufkRole { get; set; }

        #region 视图Model
        /// <summary>
        /// 部门名称
        /// </summary>
        public string hrdDepartName { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
        #endregion
    }
}
