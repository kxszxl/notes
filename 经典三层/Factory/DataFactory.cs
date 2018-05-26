using System;
using System.Configuration;
using IDAL;
namespace Factory
{
    /// <summary>
    /// 数据访问对象工厂
    /// </summary>
    public abstract class DataFactory
    {
        /// <summary>
        /// 数据库链接字符串名称
        /// </summary>
        protected string ConnctionName
        { get; set; }

        private static DataFactory factory = null;
        /// <summary>
        /// 数据访问工厂对象
        /// </summary>
        public static DataFactory Factory
        {
            get
            {
                if (factory == null)
                {
                    //获取默认指向的数据库连接字符串名称
                    string name = ConfigurationManager.AppSettings["Default"];

                    //获取默认数据连接字符串节点元素的 ProviderName （提供程序名称）属性
                    string provider = ConfigurationManager.ConnectionStrings[name].ProviderName;

                    //根据不同的提供程序名称，创建不同的数据工厂对象
                    if (provider == "System.Data.SqlClient")
                    {
                        factory = new SqlServerFactory();
                    }
                    else
                    {
                        factory = new AccessFactory();
                    }

                    //记录数据库连接字符串名称
                    factory.ConnctionName = name;
                }
                return factory;
            }
        }

        /// <summary>
        /// 抽象方法，获取用户访问对象
        /// </summary>
        /// <returns></returns>
        public abstract IUserService CreateUserService();


    }
}
