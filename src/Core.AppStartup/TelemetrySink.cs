using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;

namespace ClearMeasure.OnionDevOpsArchitecture.Core.AppStartup
{
    public class TelemetrySink : ITelemetrySink
    {
        public void RecordCall<TResponse>(IRequest<TResponse> request, TResponse response)
        {
            var telemetryClient = new TelemetryClient();
            EventTelemetry telemetry = new EventTelemetry();
            telemetry.Name = request.GetType().Name;
            telemetryClient.TrackEvent(telemetry);
            telemetryClient.TrackTrace(request.GetType().Name + ":- " + request.ToString(), SeverityLevel.Information);
        }
    }
}
