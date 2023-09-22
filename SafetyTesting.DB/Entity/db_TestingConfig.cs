using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafetyTesting.DB.Entity
{
    /// <summary>
    /// 配置表
    /// </summary>
    [SugarTable("TestingConfig")]
    public class db_TestingConfig
    {

        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string SettingName { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }



    }
}
