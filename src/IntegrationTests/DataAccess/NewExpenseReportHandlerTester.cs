using System.Linq;
using ClearMeasure.OnionDevOpsArchitecture.Core.Features.ExpenseReports;
using ClearMeasure.OnionDevOpsArchitecture.Core.Model;
using ClearMeasure.OnionDevOpsArchitecture.DataAccess;
using NUnit.Framework;
using Shouldly;

namespace ClearMeasure.OnionDevOpsArchitecture.IntegrationTests.DataAccess
{
    public class NewExpenseReportsHandlerTester
    {
        [Test]
        public void ShouldSaveExpenseReport()
        {
            new DatabaseTester().Clean();
            var report = new ExpenseReport
            {
                Title = "TestExpense",
                Description = "This is an ",
                Number = "000000",
                Status = ExpenseReportStatus.Cancelled
            };
            var handler = new NewExpenseReportsHandler(new StubbedDataContextFactory().GetContext());

            var command = new NewExpenseReportCommand(report);
            var newReport = handler.Handle(command);

            using (var context = new StubbedDataContextFactory().GetContext())
            {
                var savedReport = context.Set<ExpenseReport>()
                    .Single(expenseReport => expenseReport.Number == "000000");
                savedReport.Number.ShouldBe(newReport.Number);
            }

        }
    }
}