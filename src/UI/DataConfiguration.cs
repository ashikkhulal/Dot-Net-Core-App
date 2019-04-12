using System.Configuration;
using System.Reflection;
using ClearMeasure.OnionDevOpsArchitecture.Core;

namespace ClearMeasure.OnionDevOpsArchitecture.UI
{
    public class DataConfiguration : IDataConfiguration
    {
        public string GetConnectionString()
        {
            return ConfigurationManager.AppSettings["ConnectionString"];
        }

        public string GetValue(string key, Assembly configAssembly)
        {
            throw new System.NotImplementedException();
        }
    }
}