using System;
using DAL.SqlServer;
namespace Factory
{
    public class SqlServerFactory: DataFactory
    {
        /// <summary>
        /// 创建 SqlServer 下的数据访问类
        /// </summary>
        /// <returns></returns>
        public override IDAL.IUserService CreateUserService()
        {
            ///将数据库连接字符串名称作为参数
            return new UserService(ConnctionName);
        }
    }
}
