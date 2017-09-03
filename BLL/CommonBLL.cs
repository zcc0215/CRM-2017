using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CommonBLL
    {
        private static DAL.CommonDAL _dal;
        private static DAL.CommonDAL dal
        {
            get
            {
                if (_dal == null)
                {
                    _dal = new DAL.CommonDAL();
                }
                return _dal;
            }
        }
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static bool add<T>(T Model)
        {
            return dal.add<T>(Model);
        }
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static bool Update<T>(T Model)
        {
            return dal.Update<T>(Model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static bool Delete<T>(T Model)
        {
            return dal.Delete<T>(Model);
        }
        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool BulkAdd(DataTable dt)
        {
            return dal.BulkAdd(dt);
        }
        /// <summary>
        /// 根据表名获取表信息
        /// </summary>
        /// <param name="Tablename"></param>
        /// <returns></returns>
        public static IList<Model.TableInfo> GetTableInfo(string Tablename)
        {
            IList<Model.TableInfo> lmti = new List<Model.TableInfo>();
            string CacheKey = "TableInfo_" + Tablename;
            object TableInfoObj = LIB.CacheHelper.GetCache(CacheKey);
            if (TableInfoObj != null)
            {
                lmti = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Model.TableInfo>>(TableInfoObj.ToString());
            }
            else
            {
                lmti = dal.GetTableInfo(Tablename);
                if (lmti != null)
                {
                    LIB.CacheHelper.SetCache(CacheKey, Newtonsoft.Json.JsonConvert.SerializeObject(lmti), TimeSpan.FromHours(1));
                }
            }
            return lmti;
        }
    }
}