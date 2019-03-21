using System;
using ClearMeasure.OnionDevOpsArchitecture.Core.Model;
using NUnit.Framework;

namespace ClearMeasure.OnionDevOpsArchitecture.UnitTests
{
    public class ExpenseReportTester
    {
        [Test]
        public void PropertiesShouldInitializeToProperDefaults()
        {
            var report = new ExpenseReport();
            Assert.That(report.Id, Is.EqualTo(Guid.Empty));
            Assert.That(report.Title, Is.EqualTo(string.Empty));
            Assert.That(report.Description, Is.EqualTo(string.Empty));
            Assert.That(report.Status, Is.EqualTo(ExpenseReportStatus.Draft));
            Assert.That(report.Number, Is.EqualTo(null));
        }

        [Test]
        public void ToStringShouldReturnNumber()
        {
            var report = new ExpenseReport();
            report.Number = "456";
            Assert.That(report.ToString(), Is.EqualTo("ExpenseReport 456"));
        }

        [Test]
        public void PropertiesShouldGetAndSetValuesProperly()
        {
            var report = new ExpenseReport();
            Guid guid = Guid.NewGuid();
            report.Id = guid;
            report.Title = "Title";
            report.Description = "Description";
            report.Status = ExpenseReportStatus.Approved;
            report.Number = "Number";

            Assert.That(report.Id, Is.EqualTo(guid));
            Assert.That(report.Title, Is.EqualTo("Title"));
            Assert.That(report.Description, Is.EqualTo("Description"));
            Assert.That(report.Status, Is.EqualTo(ExpenseReportStatus.Approved));
            Assert.That(report.Number, Is.EqualTo("Number"));
        }

        [Test]
        public void ShouldShowFriendlyStatusValuesAsStrings()
        {
            var report = new ExpenseReport();
            report.Status = ExpenseReportStatus.Submitted;

            Assert.That(report.FriendlyStatus, Is.EqualTo("Submitted"));
        }
    }
}
