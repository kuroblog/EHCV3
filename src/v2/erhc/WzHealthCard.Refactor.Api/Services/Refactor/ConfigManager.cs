
namespace WzHealthCard.Refactor.Api.Services.Refactor
{
    using Microsoft.Extensions.Configuration;

    public class ConfigManager
    {
        private readonly IConfiguration config;

        public ConfigManager(IConfiguration config)
        {
            this.config = config;
        }

        public string GetAppSetting(string key)
        {
            return config.GetSection("appsettings")[key];
        }
    }
}
