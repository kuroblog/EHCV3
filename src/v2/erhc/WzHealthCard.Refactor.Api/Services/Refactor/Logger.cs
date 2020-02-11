
namespace WzHealthCard.Refactor.Api.Services.Refactor
{
    using Newtonsoft.Json;
    using Serilog;
    using System;
    using WzHealthCard.Refactor.Api.DataAccess.Erhc;
    using WzHealthCard.Refactor.Api.Models.Refactor;
    using WzHealthCard.Refactor.Api.Repositories.Erhc;
    using WzHealthCard.Refactor.Api.UnitOfWorks;

    public interface ILogger
    {
        TResult SaveProxyLog<TResult>(Func<TResult> action);

        void SaveRequestLog(ApiArgument arg);

        void SaveRequestLog<TData>(ApiArgument<TData> arg);

        void SaveResponseLog(ApiResultEx res, string requestId);

        void SaveResponseLog<TData>(ApiResultEx<TData> res, string requestId);

        void Debug(string msg);

        void Error(Exception error, string errMsgTemplate = "ex");
    }

    public class Logger : ILogger
    {
        private readonly ConfigManager config;
        private readonly LogRepository logRepo;
        private readonly ErhcUnitOfWork erhcUow;

        public Logger(ConfigManager config, LogRepository logRepo, ErhcUnitOfWork erhcUow)
        {
            this.config = config;
            this.logRepo = logRepo;
            this.erhcUow = erhcUow;
        }

        private bool GetEnableLogToDatabase()
        {
            var setting = config.GetAppSetting("EnableLogToDatabase");
            bool.TryParse(setting, out bool isEnable);

            return isEnable;
        }

        private void SaveLog(LogEntity log)
        {
            //if (!GetEnableLogToDatabase())
            //{
            //    return;
            //}

            //logRepo.Insert(log);
            //erhcUow.Commit();
        }

        private readonly Func<LogDataType, string, string, LogEntity> GetLogData = (logType, rid, data) => new LogEntity
        {
            CreatedAt = DateTime.Now,
            DataContent = data,
            DataType = logType.ToString(),
            RequestId = rid
        };

        public TResult SaveProxyLog<TResult>(Func<TResult> action)
        {
            return action.Invoke();
        }

        public void SaveRequestLog(ApiArgument arg)
        {
            var json = JsonConvert.SerializeObject(new
            {
                header = arg.Header
            });
            var log = GetLogData(LogDataType.Request, arg.Header.RequestId, json);
            SaveLog(log);

            Debug(log.DataContent);
        }

        public void SaveRequestLog<TData>(ApiArgument<TData> arg)
        {
            var json = JsonConvert.SerializeObject(new
            {
                header = arg.Header,
                body = arg.Data
            });
            var log = GetLogData(LogDataType.Request, arg.Header.RequestId, json);
            SaveLog(log);

            Debug(log.DataContent);
        }

        public void SaveResponseLog(ApiResultEx res, string requestId)
        {
            var json = JsonConvert.SerializeObject(res);
            var log = GetLogData(LogDataType.Response, requestId, json);
            SaveLog(log);

            Debug(log.DataContent);
        }

        public void SaveResponseLog<TData>(ApiResultEx<TData> res, string requestId)
        {
            var json = JsonConvert.SerializeObject(res);
            var log = GetLogData(LogDataType.Response, requestId, json);
            SaveLog(log);

            Debug(log.DataContent);
        }

        public void Debug(string msg)
        {
            //Log.Debug(msg);
        }

        public void Error(Exception error, string errMsgTemplate = "ex")
        {
            //Log.Error(error, errMsgTemplate);
        }
    }

    public enum LogDataType
    {
        Request,
        Response
    }
}
