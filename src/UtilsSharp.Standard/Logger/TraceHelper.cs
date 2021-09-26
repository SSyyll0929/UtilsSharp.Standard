﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Logger
{
    /// <summary>
    /// 追踪帮助类
    /// </summary>
    public class TraceHelper : IDisposable
    {
        private Hashtable _ht = new Hashtable();
        private bool IsOpenTrace { get; }
        private bool _isDisposed;
        /// <summary>
        /// 追踪帮助类
        /// </summary>
        /// <param name="isOpenTrace"></param>
        public TraceHelper(bool isOpenTrace)
        {
            IsOpenTrace = isOpenTrace;
        }

        /// <summary>
        /// 添加追踪日志
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="msg">消息</param>
        /// <param name="timeFormat">时间格式</param>
        public void Add(string key, string msg, string timeFormat = "HH:mm:ss,fff")
        {
            try
            {
                if (!IsOpenTrace) return;
                var info = $"【{DateTime.Now.ToString(timeFormat)}】{msg}";
                if (_ht.ContainsKey(key))
                {
                    var hs = (HashSet<string>)_ht[key];
                    hs.Add(info);
                }
                else
                {
                    var hs = new HashSet<string> { info };
                    _ht.Add(key, hs);
                }
            }
            catch
            {
                // ignored
            }
        }

        /// <summary>
        /// 获取追踪日志
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public void Remove(string key)
        {
            try
            {
                if (!IsOpenTrace) return;
                if (_ht.ContainsKey(key))
                {
                    _ht.Remove(key);
                }
            }
            catch
            {
                // ignored
            }
        }

        /// <summary>
        /// 获取追踪日志
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public string Get(string key)
        {
            try
            {
                if (!IsOpenTrace) return "";
                return _ht.ContainsKey(key) ? string.Join("\n", (HashSet<string>)_ht[key]) : "";
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 实现IDisposable中的Dispose方法
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            //通知垃圾回收器不用再调用终结器
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// 不必要的方法，只是为了符合其他语言的规范
        /// </summary>
        public void Close()
        {
            Dispose();
        }
        /// <summary>
        /// 必须的，防止程序员忘记显示调用Dispose方法(隐式清理)
        /// </summary>
        ~TraceHelper()
        {
            Dispose(false);
        }

        /// <summary>
        /// 非密封类修饰用protected virtual，提醒子类必须实现自己的清理方法时注意到父类的清理工作
        /// </summary>
        /// <param name="isDisposing">是否销毁</param>
        protected virtual void Dispose(bool isDisposing)
        {
            if (_isDisposed)
            {
                return;
            }
            if (isDisposing)
            {
                //清理托管资源
                if (_ht != null)
                {
                    _ht.Clear();
                    _ht = null;
                }
            }
            _isDisposed = false;
        }
    }
}
