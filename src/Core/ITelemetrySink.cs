using System;
using System.Collections.Generic;
using System.Text;

namespace ClearMeasure.OnionDevOpsArchitecture.Core
{
    public interface ITelemetrySink
    {
        void RecordCall<TResponse>(IRequest<TResponse> request, TResponse response);
    }
}
