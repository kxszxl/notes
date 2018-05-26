using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MySchoolModels;

namespace MySchoolDAL
{
    public class ClassesService:DBBase<Classes>
    {
        //ReadEntity方法
        protected override Classes ReadEntity(SqlDataReader reader)
        {
            return new Classes() {
                Id=Convert.ToInt32(reader["Id"]),
                ClassName=reader["ClassName"].ToString(),
                Grand=Convert.ToInt32(reader["Grand"])
            };
        }
        
        //插入新数据
        public int Insert(Classes classes)
        {
            string cmdText = "SP_I_Classes";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@ClassName", classes.ClassName),
                new SqlParameter("@Grand", classes.Grand)
            };
            return ExecuteNonQuery(cmdText, CommandType.StoredProcedure,paras);
        }
        
        //查询所有
        public List<Classes> Select()
        {
            string cmdText = "SP_S_Classes";
            return GetList(cmdText, CommandType.StoredProcedure);
        }
    }
}
