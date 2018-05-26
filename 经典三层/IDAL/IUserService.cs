using System;
using System.Collections.Generic;
using Model;

namespace IDAL
{
    /// <summary>
    /// 用户数据访问接口
    /// 约束不同数据访问类实现相同的方法
    /// </summary>
    public interface IUserService
    {
       /// <summary>
       /// 查询所有用户
       /// </summary>
       /// <returns></returns>
        List<User> Select();

        /// <summary>
        /// 查询指定ID的用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User Select(int id);
    }
}
