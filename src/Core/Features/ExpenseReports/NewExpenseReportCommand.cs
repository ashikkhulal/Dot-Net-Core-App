using ClearMeasure.OnionDevOpsArchitecture.Core.Model;

namespace ClearMeasure.OnionDevOpsArchitecture.Core.Features.ExpenseReports
{
    public class NewExpenseReportCommand : IRequest<ExpenseReport>
    {
        public ExpenseReport Report { get; }

        public NewExpenseReportCommand(ExpenseReport report)
        {
            Report = report;
        }
    }
}