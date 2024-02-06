using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSystem.Utility
{
    internal class DBConnection
    {
        private static IConfiguration _iConfiguration;
        static DBConnection()
        {
            GetAppSettingFile();
        }
        private static void GetAppSettingFile()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("F:\\VS File\\HospitalManagementSystemChallenge\\HMSystem\\appsettings.json");
            _iConfiguration = builder.Build();
        }
        public static string GetConnectionString()
        {
            return _iConfiguration.GetConnectionString("LocalConnString");
        }
    }
}
