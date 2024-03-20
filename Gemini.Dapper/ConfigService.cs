using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;

namespace Gemini.Dapper
{
    public class ConfigService
    {
        private static IConfiguration configuration = GetConfiguration();

        //静态方法
        public static IConfiguration GetConfiguration()
        {
            if (configuration == null)
            {
                configuration = new
                         ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                        .Add(new JsonConfigurationSource
                        {
                            Path = "appsettings.json",
                            ReloadOnChange = true
                        })
                        .Build();
            }
            return configuration;
        }
    }
}
