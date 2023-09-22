using System;
using System.Collections.Generic;
using System.Text;
using SafetyTesting.DB.Entity;
using SafetyTesting.DB.Interface;

namespace SafetyTesting.DB.Realization
{
    public class SafetyDataRepository : SqlSugarDB<User>, ISafetyDataRepository
    {
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <typeparam name="ChangeType"></typeparam>
        /// <returns></returns>
        public List<ChangeType> GetData<ChangeType>() where ChangeType : class,new ()
        {
            var db = base.Change<ChangeType>();

            return db.Context.Queryable<ChangeType>().ToList();
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <typeparam name="ChangeType"></typeparam>
        /// <param name="c"></param>
        /// <returns></returns>
        public int Insert<T>(T c) where T : class, new()
        {
            var db = base.Change<T>();
            return db.Context.Insertable(c).ExecuteCommand();
        }
        public int Inserts<T>(List<T> c) where T : class, new()
        {
            foreach (var item in c)
            {
                var db = base.Change<T>();
                 db.Context.Insertable(item).ExecuteCommand();
            }
            return 1;
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <typeparam name="ChangeType"></typeparam>
        /// <param name="c"></param>
        /// <returns></returns>
        public int Delete<ChangeType>(ChangeType c) where ChangeType : class, new() 
        {
            var db=base.Change<ChangeType>();
            return db.Context.Deleteable(c).ExecuteCommand();
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <typeparam name="ChangeType"></typeparam>
        /// <param name="c"></param>
        /// <returns></returns>
        public int Update<ChangeType>(ChangeType c) where ChangeType : class, new() 
        {
            var db = base.Change<ChangeType>();//切换仓库
            return db.Context.Updateable(c).ExecuteCommand();
        }

        public int Updates(List<db_IOModule> c)
        {
            var db = base.Change<db_IOModule>();//切换仓库

            return db.Context.Updateable(c).WhereColumns(it => it.Pass).ExecuteCommand();
            
        }
    }
}
