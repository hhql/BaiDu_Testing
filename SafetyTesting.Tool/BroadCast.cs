using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace SafetyTesting.Tool
{
    /// <summary>
    /// 广播
    /// </summary>
    public class BroadCast
    {
        static ConcurrentDictionary<string, Action<string>> broadcastdic = new ConcurrentDictionary<string, Action<string>>();

        //注册广播
        public static void AddBroadCast(string name, Action<string> action)
        {
            broadcastdic[name] = action;
        }
        



        //发送广播
        
        public static void SendBroadCast(string data)
        {
            foreach (var broadcast in broadcastdic)
            {
                broadcast.Value.Invoke(data);
            }
        }
       
        //删除广播
        public static void DeletBroadCast(string name)
        {

            broadcastdic.TryRemove(name, out Action<string> val);
        }

    }
}
