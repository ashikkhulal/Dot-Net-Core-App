using System.Linq;
using ClearMeasure.OnionDevOpsArchitecture.Core;
using ClearMeasure.OnionDevOpsArchitecture.Core.Features.ExpenseReports;
using ClearMeasure.OnionDevOpsArchitecture.Core.Model;
using ClearMeasure.OnionDevOpsArchitecture.DataAccess.Mappings;

namespace ClearMeasure.OnionDevOpsArchitecture.DataAccess
{
    public class NewExpenseReportsHandler : IRequestHandler<NewExpenseReportCommand, ExpenseReport>
    {
        private DataContext _context;

        public NewExpenseReportsHandler(DataContext context)
        {
            _context = context;
        }


        public ExpenseReport Handle(NewExpenseReportCommand request)
        {
            _context.Add(request.Report);
            _context.SaveChanges();
            return request.Report;
        }
    }
}