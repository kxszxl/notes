using System;
using System.Data.Common;
using System.Data.OleDb;

namespace DAL.Access
{
    public abstract class Access<T>: DBBase<T>
    {
        public Access(string name)
            : base(name)
        { }

        protected override DbCommand CreateCommand()
        {
            return new OleDbCommand();
        }

        protected override DbConnection CreateConneciton(string connectionString)
        {
            return new OleDbConnection(connectionString);
        }
    }
}
