using System;
using System.Collections.Generic;

using System.Text;
using System.Data;//
using System.Data.SqlClient;//

public class testDAL
{
    private SqlHelper s = null;
    public testDAL()
    {
        s = new SqlHelper();
    }
    public IList<T> Get<T>(string sql)
    {
        return DBUtility.DisposeSqlHelp.ReaderToList<T>(DBUtility.SqlHelper.SelectReader(sql));
    }
    /// <summary>
    /// 获取学生信息
    /// </summary>
    /// <returns></returns>
    public List<Model.Student> GetStudent()
    {
        List<Model.Student> lms = new List<Model.Student>();
        string sql = @"select * from student";
        DataTable dt = s.ExecuteQuery(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Model.Student ms = new Model.Student();
                ms.sId = Convert.ToInt32(dt.Rows[i]["sId"]);
                ms.Name = dt.Rows[i]["Name"].ToString();
                ms.Age = dt.Rows[i]["Age"].ToString();
                lms.Add(ms);
            }
        }
        return lms;
    }
    public IList<Model.Student> GetStudentNew()
    {
        string sql = @"select * from student ";
        return DBUtility.DisposeSqlHelp.ReaderToList<Model.Student>(DBUtility.SqlHelper.SelectReader(sql));
    }
    /// <summary>
    /// 添加学生
    /// </summary>
    /// <param name="ms"></param>
    /// <returns></returns>
    public bool addStudent(Model.Student ms)
    {
        bool flag = false;
        string sql = @"insert into student values(@Name,@Age)";
        SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@Name", ms.Name),
                new SqlParameter("@Age", ms.Age)
            };
        int res = s.ExecuteNonQuery(sql, paras);
        if (res > 0)
        {
            flag = true;
        }
        return flag;
    }
    public bool add(Model.Student ms)
    {
        bool flag = false;
        int res = DBUtility.SqlHelper.ExecuteSingleSql(DBUtility.DisposeSqlHelp.ReturnSql<Model.Student>(ms));
        if (res > 0)
        {
            flag = true;
        }
        return flag;
    }
    /// <summary>
    /// 删除学生
    /// </summary>
    /// <param name="id">学生的id</param>
    /// <returns></returns>
    public bool Delete(string id)
    {
        bool flag = false;
        string sql = @"delete student where sid=@id";
        SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@id", id)
            };
        int res = s.ExecuteNonQuery(sql, paras);
        if (res > 0)
        {
            flag = true;
        }
        return flag;
    }  
    /// <summary>
    ///编辑学生信息
    /// </summary>
    /// <returns>成功返回真</returns>
    public bool EditStudent(Model.Student ms)
    {
        bool flag = false;
        string sql = @"update student set Name=@Name,Age=@Age where sid=@sid";
        SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@sid", ms.sId),
                new SqlParameter("@Name", ms.Name),
                new SqlParameter("@Age", ms.Age)
            };
        int res = s.ExecuteNonQuery(sql, paras);
        if (res > 0)
        {
            flag = true;
        }
        return flag;
    }
    /// <summary>
    /// 调用存储过程获取学生信息
    /// </summary>
    /// <param name="ms"></param>
    /// <returns></returns>
    public DataSet GetStudent(Model.Student ms)
    {
        DataSet ds = new DataSet();
        string storeProcName = "P_Student";
        SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@Name", ms.Name),
                new SqlParameter("@Age", ms.Age)
            };
        ds = DBUtility.SqlHelper.SelectProcDataSet(storeProcName, paras);
        return ds;
    }
    public bool Edit(Model.Student ms)
    {
        bool flag = false;
        int res = DBUtility.SqlHelper.ExecuteSingleSql(DBUtility.DisposeSqlHelp.ReturnUpdateSql<Model.Student>(ms));
        if (res > 0)
        {
            flag = true;
        }
        return flag;
    }
}

