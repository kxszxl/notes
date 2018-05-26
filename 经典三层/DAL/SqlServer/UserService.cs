using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using IDAL;
using Model;

namespace DAL.SqlServer
{
    public class UserService : SqlServer<User>, IUserService
    {
        protected override User ReadEntity(DbDataReader reader)
        {
            return new User()
            {
                Id = Convert.ToInt32(reader["Id"]),
                Username = reader["Username"].ToString(),
                Password = reader["Password"].ToString()
            };
        }

        public UserService(string name)
            : base(name)
        {
        }

        public List<User> Select()
        {
            return GetList("UP_S_User", CommandType.StoredProcedure);
        }

        public User Select(int id)
        {
            return GetEntity("SELECT * FROM [User] WHERE [Id]=@Id", parameters: new SqlParameter("@Id", id));
        }

    }
}
