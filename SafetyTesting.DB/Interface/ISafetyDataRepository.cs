using SafetyTesting.DB.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafetyTesting.DB.Interface
{
    public interface ISafetyDataRepository
    {
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <typeparam name="ChangeType"></typeparam>
        /// <returns></returns>
        public List<ChangeType> GetData<ChangeType>() where ChangeType : class, new();

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <typeparam name="ChangeType"></typeparam>
        /// <param name="c"></param>
        /// <returns></returns>
        public int Insert<ChangeType>(ChangeType c) where ChangeType : class, new();

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <typeparam name="ChangeType"></typeparam>
        /// <param name="c"></param>
        /// <returns></returns>
        public int Delete<ChangeType>(ChangeType c) where ChangeType : class, new();

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <typeparam name="ChangeType"></typeparam>
        /// <param name="c"></param>
        /// <returns></returns>
        public int Updates(List<db_IOModule> c);

        public int Update<T>(T c) where T : class, new();
        public int Inserts<T>(List<T> c) where T : class, new();

    }
}
