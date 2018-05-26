using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
namespace DAL
{
    /// <summary>
    /// 数据访问基类
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public abstract class DBBase<T>
    {
        private readonly string ConnectionString;

        protected abstract DbCommand CreateCommand();

        protected abstract DbConnection CreateConneciton(string connectionString);

        protected abstract T ReadEntity(DbDataReader reader);

        public DBBase(string name)
        {
            ConnectionString = ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        /// <summary>
        /// 获取命令对象
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="type">执行类型</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        private DbCommand GetCommand(string sql, CommandType type, params DbParameter[] parameters)
        {
            DbCommand command = CreateCommand();
            command.CommandText = sql;
            command.CommandType = type;
            if (parameters != null && parameters.Length > 0)
            { command.Parameters.AddRange(parameters); }
            command.Connection = CreateConneciton(ConnectionString);
            command.Connection.Open();
            return command;
        }

        /// <summary>
        /// 执行SQL，并返回受影响的行数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="type">执行类型</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        protected int ExecuteNonQuery(string sql, CommandType type = CommandType.Text, params DbParameter[] parameters)
        {
            int result = 0;
            using (DbCommand command = GetCommand(sql, type, parameters))
            {
                using (command.Connection)
                {
                    result = command.ExecuteNonQuery();
                }
            }
            return result;
        }

        /// <summary>
        /// 执行SQL语句，返回首行首列
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="type">执行类型</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        protected object ExecuteScalar(string sql, CommandType type = CommandType.Text, params DbParameter[] parameters)
        {
            object result = null;
            using (DbCommand command = GetCommand(sql, type, parameters))
            {
                using (command.Connection)
                {
                    result = command.ExecuteScalar();
                }
            }
            return result;
        }

        /// <summary>
        /// 返回一个实体对象
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="type">执行类型</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        protected T GetEntity(string sql, CommandType type = CommandType.Text, params DbParameter[] parameters)
        {
            T result = default(T);
            using (DbCommand command = GetCommand(sql, type, parameters))
            {
                using (command.Connection)
                {
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result = ReadEntity(reader);
                        }
                    }
                }
            }
            return result;
        }


        /// <summary>
        /// 返回实体对象集合
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="type">执行类型</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        protected List<T> GetList(string sql, CommandType type = CommandType.Text, params DbParameter[] parameters)
        {
            List<T> result = new List<T>();
            using (DbCommand command = GetCommand(sql, type, parameters))
            {
                using (command.Connection)
                {
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(ReadEntity(reader));
                        }
                    }
                }
            }
            return result;
        }
    }
}
