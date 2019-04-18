using System;
using System.Diagnostics;
using ClearMeasure.OnionDevOpsArchitecture.Core;
using Microsoft.ApplicationInsights;

namespace ClearMeasure.OnionDevOpsArchitecture.UI
{
    public class StartupTask : IStartupTask
    {
        public void Run()
        {
            Trace.WriteLine("Application started");
            new TelemetryClient().TrackEvent("Application started");
        }
    }
}