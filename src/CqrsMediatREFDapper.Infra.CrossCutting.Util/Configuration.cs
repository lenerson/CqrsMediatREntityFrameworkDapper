using Microsoft.Extensions.Configuration;
using System.IO;

namespace CqrsMediatREFDapper.Infra.CrossCutting.Util
{
    public static class Configuration
    {
        public static string GetDefaultConnectionString()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            return config.GetConnectionString("DefaultConnection");
        }
    }
}
