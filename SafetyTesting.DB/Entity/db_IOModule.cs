using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafetyTesting.DB.Entity
{
    /// <summary>
    /// 车型表
    /// </summary>
    [SugarTable("IOModule")]
    public class db_IOModule
    {

        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 通道
        /// </summary>
        public string Pass { get; set; }

        /// <summary>
        /// 输出1
        /// </summary>
        public string IOModule1 { get; set; }

        /// <summary>
        /// 输出2
        /// </summary>
        public string IOModule2 { get; set; }


    }
}
