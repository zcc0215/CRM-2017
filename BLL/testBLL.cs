using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class testBLL
    {
        private static testDAL _dal;
        private static testDAL dal
        {
            get
            {
                if (_dal == null)
                {
                    _dal = new testDAL();
                }
                return _dal;
            }
        }
        /// <summary>
        /// 获取学生信息
        /// </summary>
        /// <param name="sId">学生Id</param>
        /// <returns></returns>
        public static List<Model.Student> GetStudent()
        {
            return dal.GetStudent();
        }
        /// <summary>
        /// 添加学生
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        public static bool addStudent(Model.Student ms)
        {
            return dal.addStudent(ms);
        }
        /// <summary>
        /// 删除学生
        /// </summary>
        /// <param name="id">学生的id</param>
        /// <returns></returns>
        public static bool Delete(string id)
        {
            return dal.Delete(id);
        }
        /// <summary>
        ///编辑学生信息
        /// </summary>
        /// <returns>成功返回真</returns>
        public static bool EditStudent(Model.Student ms)
        {
            return dal.EditStudent(ms);
        }
        public static IList<T> Get<T>(string sql)
        {
            return dal.Get<T>(sql);
        }
    }
}
