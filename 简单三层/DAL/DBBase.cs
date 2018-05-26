using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace MySchoolDAL
{
    public abstract class DBBase<T>
    {
        //连接字符串
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        //通过读取器生成实体对象
        protected abstract T ReadEntity(SqlDataReader sdr);

        //获取Command对象
        private SqlCommand GetCmd(string cmdText,CommandType type=CommandType.Text,params SqlParameter[] paras)
        {
            SqlCommand cmd = new SqlCommand(cmdText);
            cmd.Connection = new SqlConnection(connStr);
            cmd.CommandType = type;
            if (paras != null && paras.Length > 0)
            {
                cmd.Parameters.AddRange(paras);
            }
            return cmd;
        }

        /// <summary>
        /// 执行sql语句或存储过程
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="type"></param>
        /// <param name="paras"></param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNonQuery(string cmdText, CommandType type = CommandType.Text, params SqlParameter[] paras)
        {
            int row = 0;
            using (SqlCommand cmd = GetCmd(cmdText, type, paras))
            {
                using (cmd.Connection)
                {
                    cmd.Connection.Open();
                    row = cmd.ExecuteNonQuery();
                }
            }
            return row;
        }

        /// <summary>
        /// 执行sql语句或存储过程
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="type"></param>
        /// <param name="paras"></param>
        /// <returns>首行首列</returns>
        public object ExecuteScalar(string cmdText, CommandType type = CommandType.Text, params SqlParameter[] paras)
        {
            object obj = null;
            using (SqlCommand cmd = GetCmd(cmdText, type, paras))
            {
                using (cmd.Connection)
                {
                    cmd.Connection.Open();
                    obj = cmd.ExecuteScalar();
                }
            }
            return obj;
        }

        /// <summary>
        /// 执行sql语句或存储过程
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="type"></param>
        /// <param name="paras"></param>
        /// <returns>实体对象</returns>
        public T GetEntity(string cmdText, CommandType type = CommandType.Text, params SqlParameter[] paras)
        {
            T t = default(T);
            using (SqlCommand cmd = GetCmd(cmdText, type, paras))
            {
                using (cmd.Connection)
                {
                    cmd.Connection.Open();
                    SqlDataReader ddr = cmd.ExecuteReader();
                    if (ddr.Read())
                    {
                        t = ReadEntity(ddr);
                    }
                }
            }
            return t;
        }

        /// <summary>
        /// 执行sql语句或存储过程
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="type"></param>
        /// <param name="paras"></param>
        /// <returns>对象集合</returns>
        public List<T> GetList(string cmdText, CommandType type = CommandType.Text, params SqlParameter[] paras)
        {
            List<T> list = new List<T>();
            using (SqlCommand cmd = GetCmd(cmdText, type, paras))
            {
                using (cmd.Connection)
                {
                    cmd.Connection.Open();
                    SqlDataReader ddr = cmd.ExecuteReader();
                    while (ddr.Read())
                    {
                        T t = ReadEntity(ddr);
                        list.Add(t);
                    }
                }
            }
            return list;
        }
    }
}
