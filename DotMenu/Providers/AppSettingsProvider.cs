using System.IO;
using Microsoft.Extensions.Configuration;

namespace DotMenu.Providers
{
    public class AppSettingsProvider
    {
        private static AppSettingsProvider _appSettings;

        private string AppSettingValue { get; set; }

        public static string AppSetting(string key)
        {
            _appSettings = GetCurrentSettings(key);
            return _appSettings.AppSettingValue;
        }

        public AppSettingsProvider(IConfiguration config, string key)
        {
            this.AppSettingValue = config.GetValue<string>(key);
        }
        
        public static AppSettingsProvider GetCurrentSettings(string key)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();

            var settings = new AppSettingsProvider(configuration.GetSection("ApplicationSettings"), key);

            return settings;
        }
    }
}