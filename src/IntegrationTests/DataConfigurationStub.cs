using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using ClearMeasure.OnionDevOpsArchitecture.Core;

namespace ClearMeasure.OnionDevOpsArchitecture.IntegrationTests
{
    public class DataConfigurationStub : IDataConfiguration
    {
        public string GetConnectionString()
        {
            return GetValue("ConnectionString", Assembly.GetExecutingAssembly());   
        }

        public string GetValue(string key, Assembly configAssembly)
        {
            return ConfigurationManager
                .OpenExeConfiguration(new FileInfo(configAssembly.Location).Name)
                .AppSettings.Settings[key].Value;
        }
    }
}