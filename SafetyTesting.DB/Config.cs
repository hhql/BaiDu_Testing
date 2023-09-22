using System;
using System.Collections.Generic;
using System.Text;

namespace SafetyTesting.DB
{
    public class Config
    {
        private static string GetCurrentProjectPath
        {

            get
            {
                return Environment.CurrentDirectory;//获取具体路径
            }
        }
        public static string ConnectionString = ("Data Source =.;Initial Catalog = SafetyTesting;Integrated Security = SSPI");
    }

}
