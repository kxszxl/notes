using System;
using DAL.Access;
namespace Factory
{
    public class AccessFactory : DataFactory
    {
        /// <summary>
        /// 创建 Access 下的数据访问类
        /// </summary>
        /// <returns></returns>
        public override IDAL.IUserService CreateUserService()
        {
            return new UserService(ConnctionName);
        }
    }
}
