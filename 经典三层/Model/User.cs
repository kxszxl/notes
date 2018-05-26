using System;
namespace Model
{
    /// <summary>
    /// “用户”实体类
    /// </summary>
    [Serializable]
    public class User
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id
        { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Username
        { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        { get; set; }
    }
}
