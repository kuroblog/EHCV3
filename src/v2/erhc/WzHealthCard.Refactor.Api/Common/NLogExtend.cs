using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using NLog;
using WzHealthCard.Refactor.Api.Services.WRefactor;

namespace WzHealthCard.Refactor.Api.Common
{
    public static class NLogExtend
    {
        public static void Monitor(this ILogger logger, IMonitorModelScope model)
        {
            logger.Log(LogLevel.Info, model.GetMessage());
        }

        public static void MonitorWarn(this ILogger logger, IMonitorModelScope model)
        {
            logger.Log(new LogEventInfo(LogLevel.Warn, "warnErrFile", model.GetMessage()));
        }

        public static void MonitorExtend(this ILogger logger, IMonitorModelScope model, string message)
        {

        }
    }

    /// <summary>
    /// 扩展日志
    /// </summary>
    public class MonitorModel
    {
        /// <summary>
        /// 请求主键标识
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// 完整路径
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 请求方式
        /// </summary>
        public string RequestMethod { get; set; }

        /// <summary>
        /// 控制器
        /// </summary>
        public string ControllerName { get; set; }

        /// <summary>
        /// 方法名
        /// </summary>
        public string ActionName { get; set; }


        /// <summary>
        /// 记录请求头
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// 请求路由
        /// </summary>
        public string RouteUrl { get; set; }

        /// <summary>
        /// 记录参数
        /// </summary>
        public string Parameters { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// 请求结束时间
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public string StartTime { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 扩展内容
        /// </summary>
        public IList<MonitorChildren> ExtentContent { get; set; }

        public MonitorModel()
        {
            ExtentContent = new List<MonitorChildren>();
        }


        public string MonitorRunTime()
        {
            if (StartDate.HasValue&&EndDate.HasValue)
            {
                return EndDate.Value.Subtract(StartDate.Value).Duration().TotalMilliseconds.ToString(CultureInfo.InvariantCulture);
            }
            return string.Empty;
        }


        public void Add(MonitorChildren children)
        {
            if (ExtentContent != null)
            {
                ExtentContent.Add(children);
            }
        }

        public void Add(string name,MonitorChildren children)
        {
            var child = ExtentContent.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            child?.Children.Add(children);
        }

        public void Add(string name, string childName,string childMessage)
        {
            var child = ExtentContent.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            AddMessage(child, childName, childMessage);
        }

        public void Add(string name,string message, string childName, string childMessage)
        {
            var child = ExtentContent.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase)
                                                          && i.Message.Equals(message, StringComparison.OrdinalIgnoreCase));
            AddMessage(child, childName, childMessage);
        }

        private void AddMessage(MonitorChildren m, string name,string message)
        {
            if (m != null)
            {
                m.Children.Add(new MonitorChildren{Name=name,Message=message});
            }
            else
            {
                this.ExtentContent.Add(new MonitorChildren { Name = name, Message = message });
            }
        }
    }

    public class MonitorChildren
    {
        public string Message { get; set; }

        /// <summary>
        /// 标题说明
        /// </summary>
        public string Name { get; set; }

        public IList<MonitorChildren> Children { get; set; }

        public MonitorChildren()
        {
            Children = new List<MonitorChildren>();
        }

        public MonitorChildren(string name,string message):this()
        {
            Name = name;
            Message = message;
        }
    }


    public class MonitorModelScope : IMonitorModelScope, IDisposable
    {
        public MonitorModel Monitor { get; set; }

        public MonitorModelScope()
        {
            Monitor = new MonitorModel();
        }

        public void Dispose()
        {
            Monitor = null;
            GC.SuppressFinalize(this);
        }


        public string GetMessage()
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(Monitor.RequestId))
            {
                sb.AppendLine($"请求RequestId:{Monitor.RequestId}");
            }
            sb.AppendLine($"开始时间：{Monitor.StartTime}");
            sb.AppendLine($"请求地址：{Monitor.Url}\t请求方式：{Monitor.RequestMethod}");
            sb.AppendLine($"请求路由：{Monitor.RouteUrl}");
            sb.AppendLine($"控 制 器：{Monitor.ControllerName}\t方法名：{Monitor.ActionName}");
            //sb.AppendLine($"请 求 头：{Monitor.Header}");
            sb.AppendLine($"请求参数：{Monitor.Parameters}");
            sb.AppendLine($"返回结果：{Monitor.Result}");
            sb.AppendLine($"扩展说明：");

            if (Monitor.ExtentContent.Any())
            {
                GetConvertChildrenLog(Monitor.ExtentContent, sb, 0);
            }
            sb.AppendLine($"结束时间：{Monitor.EndTime}  运行时间：{Monitor.MonitorRunTime()}");
            return sb.ToString();
        }

        public void Add(string name, string message)
        {
            Monitor?.Add(new MonitorChildren(name, message));
        }

        public void Add(string name, string childName, string childMessage)
        {
            Monitor?.Add(name, childName, childMessage);
        }

        public void Add(string name,string message, string childName, string childMessage)
        {
            Monitor?.Add(name,message,childName, childMessage);
        }


        private void GetConvertChildrenLog(IList<MonitorChildren> child, StringBuilder sb, int level)
        {
            if (!child.Any())
            {
                return;
            }
            int length = child.Count;
            string levelStr = string.Empty;
            for (int l = 1; l <= level; l++)
            {
                levelStr += "  ";
            }
            foreach (var item in child)
            {
                string currLevel = $"{levelStr}┠";
                if (child.LastOrDefault() == item)
                {
                    currLevel = $"{levelStr}┕";
                }
                if (item != null)
                {
                    sb.AppendLine($"{currLevel}{item.Name}：{item.Message}");
                    if (item.Children.Any())
                    {
                        GetConvertChildrenLog(item.Children, sb, level + 1);
                    }
                }
            }
        }
    }

    public interface IMonitorModelScope : IRegisterScopeServices, IDisposable
    {
        MonitorModel Monitor { get; set; }
        string GetMessage();

        void Add(string name,string message);

        void Add(string name, string childName, string childMessage);

        void Add(string name, string message, string childName, string childMessage);
    }
}