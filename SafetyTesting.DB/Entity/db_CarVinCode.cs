using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafetyTesting.DB.Entity
{
    /// <summary>
    /// VIN码配置车型
    /// </summary>
    [SugarTable("CarVinCode")]
    public class db_CarVinCode
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 车型
        /// </summary>
        public string CarModuleName { get; set; }//VEHICLE_NO

        /// <summary>
        /// vin 码
        /// </summary>

        public string Vin { get; set; }


    }
}
