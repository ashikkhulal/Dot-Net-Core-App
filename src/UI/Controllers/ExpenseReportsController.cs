using System;
using System.Configuration;
using System.Linq;
using ClearMeasure.OnionDevOpsArchitecture.Core;
using ClearMeasure.OnionDevOpsArchitecture.Core.Features.ExpenseReports;
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

        [Route("")]
        public IActionResult Index()
        {
            var command = new ListExpenseReportsCommand();
            ExpenseReport[] reports = _bus.Send(command);
            var orderedReports = reports.OrderBy(report => report.Number);
            return View(orderedReports.ToArray());
        }

        [Route("New"), HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [Route("New"), HttpPost]
        public IActionResult New(ExpenseReport report)
        {
            if (ModelState.IsValid && report.Number.Length == 6)
            {
                _bus.Send(new NewExpenseReportCommand(report));
                return RedirectToAction("Index");
            }

            return RedirectToAction();
        }
    }
}