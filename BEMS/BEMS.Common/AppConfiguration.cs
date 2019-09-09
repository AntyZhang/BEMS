using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;

namespace BEMS.Common
{
    public class AppConfiguration
    {
        public static IConfiguration Configuration { get; set; }
        static AppConfiguration()
        {
            //ReloadOnChange = true 当appsettings.json被修改时重新加载            
            Configuration = new ConfigurationBuilder()
            .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
            .Build();
        }
    }
}
