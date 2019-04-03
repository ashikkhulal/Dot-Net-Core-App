using System.Net;
using System.Net.Mime;
using ClearMeasure.OnionDevOpsArchitecture.Core;
using ClearMeasure.OnionDevOpsArchitecture.Core.Features.ExpenseReports;
using ClearMeasure.OnionDevOpsArchitecture.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace ClearMeasure.OnionDevOpsArchitecture.UI.Controllers
{
    [Route("[controller]")]
    public class HealthCheckController : Controller
    {
        private Bus _bus;

        public HealthCheckController(Bus bus)
        {
            _bus = bus;
        }
        // GET
        public IActionResult Index()
        {
            var command = new ListExpenseReportsCommand();
            ExpenseReport[] reports = _bus.Send(command);

            return Content("Success");
        }
    }
}