using System;
using System.Data.Common;
using System.Data.SqlClient;
namespace DAL.SqlServer
{
    public abstract class SqlServer<T> : DBBase<T>
    {
        public SqlServer(string name)
            : base(name)
        { }

        protected override DbCommand CreateCommand()
        {
            return new SqlCommand();
        }

        protected override DbConnection CreateConneciton(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}
