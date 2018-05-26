using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MySchoolModels;

namespace MySchoolDAL
{
    public class StudentsService:DBBase<Students>
    {
        //ReadEntity方法
        protected override Students ReadEntity(SqlDataReader reader)
        {
            return new Students() {
                Id=Convert.ToInt32(reader["Id"]),
                Name=reader["Name"].ToString(),
                ClassId=reader["ClassId"] == DBNull.Value ? default(int) : Convert.ToInt32(reader["ClassId"])
            };
        }
        
        //插入新数据
        public int Insert(Students students)
        {
            string cmdText = "SP_I_Students";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@Name", students.Name),
                new SqlParameter("@ClassId", students.ClassId)
            };
            return ExecuteNonQuery(cmdText, CommandType.StoredProcedure,paras);
        }
        
        //查询所有
        public List<Students> Select()
        {
            string cmdText = "SP_S_Students";
            return GetList(cmdText, CommandType.StoredProcedure);
        }
    }
}
