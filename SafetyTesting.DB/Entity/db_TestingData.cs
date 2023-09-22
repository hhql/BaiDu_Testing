using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafetyTesting.DB.Entity
{
    /// <summary>
    /// 检测数据
    /// </summary>
    [SugarTable("TestingData")]
    public class db_TestingData
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// VIN码
        /// </summary>
        public string Vin { get; set; }

        /// <summary>
        /// 车型
        /// </summary>
        public string carModuleCode { get; set; }


        /// <summary>
        /// 测试名称
        /// </summary>
        public string TestingName { get; set; }

        /// <summary>
        /// 范围值
        /// </summary>
        public string Range { get; set; }

        /// <summary>
        /// 数值
        /// </summary>
        public string value { get; set; }

        private string time= DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        /// <summary>
        /// 结果
        /// </summary>
        public string result { get; set; }

        public string CreateTime 
        {
            get 
            {
                return time;
            }
            set { time =string.IsNullOrEmpty(value)? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"):value; }
        }
        /// <summary>
        /// 站名称
        /// </summary>
        public string StationName { get; set; }


        /// <summary>
        /// 是否上传
        /// </summary>
        
        public string  IsUpload { get; set; }
    }
}
