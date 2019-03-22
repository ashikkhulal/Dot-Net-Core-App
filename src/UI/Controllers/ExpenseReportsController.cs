using System.Configuration;
using ClearMeasure.OnionDevOpsArchitecture.Core;
using ClearMeasure.OnionDevOpsArchitecture.Core.Features.BrowseExpenseReports;
using ClearMeasure.OnionDevOpsArchitecture.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace ClearMeasure.OnionDevOpsArchitecture.UI.Controllers
{
    [Route("")]
    public class ExpenseReportsController : Controller
    {
        private Bus _bus;

        public ExpenseReportsController(Bus bus)
        {
            _bus = bus;
        }

        public IActionResult Index()
        {
            string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            var command = new ListExpenseReportsCommand();
            ExpenseReport[] reports = _bus.Send(command);
            reports[0].Description = connectionString;
            return View(reports);
        }
    }
}