using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace BestString
{
    public static class QueryHelper
    {
        static object _syncRoot = new object();
        static string _param = string.Empty;
        static string[] _datas = null;
        static Action<string, string[], TimeSpan> _callback;
        static ManualResetEvent _eventWaitHandle;

        static QueryHelper()
        {
            _eventWaitHandle = new ManualResetEvent(false);

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                string param;
                string[] datas;
                Action<string, string[], TimeSpan> callback;
                Stopwatch watch = new Stopwatch();
                string[] result;
                while (true)
                {
                    _eventWaitHandle.WaitOne();
                    _eventWaitHandle.Reset();
                    lock (_syncRoot)
                    {
                        param = _param;
                        datas = _datas;
                        callback = _callback;
                        _param = null;
                        _datas = null;
                        _callback = null;
                    }

                    watch.Restart();
                    result = SearchHelper.Search(param, datas);
                    watch.Stop();

                    if (callback != null)
                        callback(param, result, watch.Elapsed);

                    GC.Collect();
                }
            }).Start();
        }

        public static void Query(string param, string[] datas, Action<string, string[], TimeSpan> callback)
        {
            lock (_syncRoot)
            {
                _param = param;
                _datas = datas;
                _callback = callback;
            }
            _eventWaitHandle.Set();
        }
    }
}
