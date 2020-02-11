
using System.Text;
using WzHealthCard.Refactor.Api.Common;

namespace WzHealthCard.Refactor.Api.Services.Refactor
{
    using Newtonsoft.Json;
    using System;


    public interface ISmsHandler
    {
        /// <summary>
        /// 发送手机短信
        /// </summary>
        /// <param name="numbers">送目的号码，多号码以空格格开。一次最多100个号码</param>
        /// <param name="user">短信内容</param>
        /// <returns>
        ///  0  正常发送
        /// -2  发送参数填定不正确
        /// -3  用户载入延迟
        /// -6  密码错误
        /// -7  用户不存在
        /// -11  发送号码数理大于最大发送数量
        /// -12  余额不足
        /// -99  内部处理错误
        /// 其他  未知错误
        /// </returns>
        void SendMsg(string numbers, string user);
    }

    public class SmsWseHandler : ISmsHandler
    {
        private readonly ConfigManager config;
        private readonly ILogger logger;
        private readonly IMonitorModelScope _monitor;

        public SmsWseHandler(ConfigManager config, ILogger logger, IMonitorModelScope monitor)
        {
            this.config = config;
            this.logger = logger;
            _monitor = monitor;
        }

        private string smsUrl => config.GetAppSetting("SMSUrl");
        private string smsUser => config.GetAppSetting("SMSUKey");
        private string smsPwd => config.GetAppSetting("SMSUValue");
        //private string smsTemplate => config.GetAppSetting("SMSTemplate");

        public void SendMsg(string numbers, string user)
        {
            try
            {
                var smsSwitchSetting = config.GetAppSetting("EnableSMSSwitch");
                bool.TryParse(smsSwitchSetting, out bool isEnable);

                if (isEnable)
                {
                    string template = config.GetAppSetting("SMSTemplate");
                    if (!template.StartsWith("【温州市电子健康卡】"))
                    {
                        template = SmsTemplate.Template;
                    }
                    var content = string.Format(template, user);

                    logger.Debug(JsonConvert.SerializeObject(new { numbers, content }));
                    _monitor.Add("短信SMS", $"{numbers} | {content}");
                    string[] Mobiles = new string[] { numbers };
                    SmsServiceProxy.MessageData[] Messagedatas = new SmsServiceProxy.MessageData[1];
                    for (int i = 0; i < Mobiles.Length; i++)
                    {
                        Messagedatas[i] = new SmsServiceProxy.MessageData
                        {
                            Content = content,
                            Phone = Mobiles[i].Trim()
                        };
                    }
                    SmsServiceProxy.WebServiceSoapClient sendmess = new SmsServiceProxy.WebServiceSoapClient();
                    //this.lblMsg.Text = sendmess.Post("XuHui_XuYG", "e10adc3949ba59abbe56e057f20f883e", this.txtphone.Text.Trim(), this.txtcontent.Text.Trim(), "").ToString();
                    SmsServiceProxy.MTPacks packs = new SmsServiceProxy.MTPacks
                    {
                        sendType = 0,
                        msgs = Messagedatas,
                        msgType = 1,
                        uuid = "0",
                        batchID = Guid.NewGuid().ToString()
                    };
                    //SmsServiceProxy.GsmsResponse getresponse = sendmess.Post("XuHui_XuYG", "123456", packs);
                    var result = sendmess.PostAsync(smsUser, smsPwd, packs).Result;
                    //this.lblMsg.Text = getresponse.result.ToString();


                    //logger.Debug(JsonConvert.SerializeObject(new { numbers, code = result.Body.PostResult, result = result.Body.PostResult.result == 0 }));
                }
                else
                {
                    _monitor.Add("短信SMS", $"功能未启用false");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

    }
}
