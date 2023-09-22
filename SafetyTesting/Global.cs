using System;
using System.Collections.Generic;
using System.Text;

namespace SafetyTesting
{
    class Global
    {
        public static string UserName { get; set; }

        public static int Level { get; set; }


        public static bool IsStop = false; //是否有急停

        public static bool IsSettingComm = false;//是否是设置通讯

        public static string TypeCarModule { get; set; }//车型样式
    }
}
