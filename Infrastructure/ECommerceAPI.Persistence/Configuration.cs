using Microsoft.Extensions.Configuration;

namespace ECommerceAPI.Persistence;

static class Configuration
{
    /// <summary>
    /// This field reaches appsetting.json file and returns Connection String in this file
    /// </summary>
    public static string ConnectionString
    {
        get
        {
            ConfigurationManager configurationManager = new ConfigurationManager();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),
                "../../Presentation/ECommerceAPI.WebAPI"));
            configurationManager.AddJsonFile("appsettings.json");

            return configurationManager.GetConnectionString("MsSql");
        }
    }
}