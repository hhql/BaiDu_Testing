using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafetyTesting.DB.Entity
{
    /// <summary>
    /// 车型表
    /// </summary>
    [SugarTable("CarModule")]
    public class db_CarModule
    {

        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 车型号
        /// </summary>
        public string CarModuleName { get; set; }

        /// <summary>
        /// 检测名称
        /// </summary>
        public string TestName { get; set; }


        /// <summary>
        /// 范围值
        /// </summary>
        public string Range { get; set; }

        /// <summary>
        /// 通道
        /// </summary>
        public string Pass { get; set; }



    }
}
