using System.Reflection;

namespace ClearMeasure.OnionDevOpsArchitecture.Core
{
    public interface IDataConfiguration
    {
        string GetConnectionString();
        string GetValue(string key, Assembly configAssembly);
    }
}