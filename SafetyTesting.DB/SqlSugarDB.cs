using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafetyTesting.DB
{
    public class SqlSugarDB<T> : SimpleClient<T> where T : class, new()
    {
        public SqlSugarDB(ISqlSugarClient context = null) : base(context)
        {
            if (context == null)
            {
                base.Context = new SqlSugarClient(new ConnectionConfig()
                {
                    DbType = SqlSugar.DbType.SqlServer,
                    InitKeyType = InitKeyType.Attribute,
                    IsAutoCloseConnection = true,
                    ConnectionString = Config.ConnectionString
                });
                base.Context.CodeFirst.InitTables(typeof(Entity.User));
                base.Context.CodeFirst.InitTables(typeof(Entity.db_CarModule));
                base.Context.CodeFirst.InitTables(typeof(Entity.db_IOModule));
                base.Context.CodeFirst.InitTables(typeof(Entity.db_CarVinCode));
                base.Context.CodeFirst.InitTables(typeof(Entity.db_TestingConfig));
                base.Context.CodeFirst.InitTables(typeof(Entity.db_TestingData));
                //base.Context.CodeFirst.InitTables(typeof(Entity.db_Posture));
            }
        }

    }
}
