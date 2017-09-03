using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CommonDAL
    {
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <returns></returns>
        public bool add<T>(T Model)
        {
            bool flag = false;
            int res = DBUtility.SqlHelper.ExecuteSingleSql(DBUtility.DisposeSqlHelp.ReturnSql<T>(Model));
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public bool Update<T>(T Model)
        {
            bool flag = false;
            int res = DBUtility.SqlHelper.ExecuteSingleSql(DBUtility.DisposeSqlHelp.ReturnUpdateSql<T>(Model));
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <returns></returns>
        public bool Delete<T>(T Model)
        {
            bool flag = false;
            int res = DBUtility.SqlHelper.ExecuteSingleSql(DBUtility.DisposeSqlHelp.ReturnDeleteSql<T>(Model));
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }
        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool BulkAdd(DataTable dt)
        {
            return DBUtility.SqlHelper.SqlBulkCopyByDatatable(dt);
        }
        /// <summary>
        /// 根据表名获取表信息
        /// </summary>
        /// <param name="Tablename"></param>
        /// <returns></returns>
        public IList<Model.TableInfo> GetTableInfo(string Tablename)
        {
            string sql = @"select a.name tiName,isnull(g.[value],'') tiCommentary FROM   syscolumns   a 
                          inner join   sysobjects   d   on   a.id=d.id     and   d.xtype='U'   and     d.name<>'dtproperties'
                          left join   sys.extended_properties   g   on   a.id=g.major_id   and   a.colid=g.minor_id
                          where d.name='"+ Tablename + "'   ";
            return DBUtility.DisposeSqlHelp.ReaderToList<Model.TableInfo>(DBUtility.SqlHelper.SelectReader(sql));
        }
    }
}
