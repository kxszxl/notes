using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL;
using Factory;
namespace BLL
{
    public static class UserManage
    {
        /// <summary>
        /// 通过数据访问对象工厂，得到数据访问接口
        /// </summary>
        private static readonly IUserService service = DataFactory.Factory.CreateUserService();

        public static List<User> GetAll()
        {
            return service.Select();
        }

    }
}
