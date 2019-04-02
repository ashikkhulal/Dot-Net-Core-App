using System;
using ClearMeasure.OnionDevOpsArchitecture.Core.Model;
using NUnit.Framework;

namespace ClearMeasure.OnionDevOpsArchitecture.IntegrationTests
{
    [TestFixture]
    public class ZDataLoader
    {
        [Test, Category("DataLoader")]
        public void LoadLocalData()
        {
            new DatabaseTester().Clean();
            

            using (var context = new StubbedDataContextFactory().GetContext())
            {
                for (int i = 0; i < 20; i++)
                {
                    var newGuid = Guid.NewGuid();
                    var report = new ExpenseReport
                    {
                        Title = "TestExpense " + newGuid,
                        Description = "This is an expense" + newGuid,
                        Number = newGuid.ToString().Substring(0, 6),
                        Status = ExpenseReportStatus.Cancelled
                    };
                    context.Add(report);
                }
                context.SaveChanges();
            }
        }
    }
}