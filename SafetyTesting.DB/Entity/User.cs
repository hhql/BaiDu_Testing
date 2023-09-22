using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafetyTesting.DB.Entity
{
    /// <summary>
    /// 用户表
    /// </summary>
    [SugarTable("User")]
   public class User
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        [SugarColumn(Length =int.MaxValue)]//自定格式的情况 length不要设置
        public string UserPassword { get; set; }

        /// <summary>
        /// 级别
        /// </summary>
        public int level { get; set; }
    }
}
