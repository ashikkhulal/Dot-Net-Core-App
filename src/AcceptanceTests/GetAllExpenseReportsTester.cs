using ClearMeasure.OnionDevOpsArchitecture.Core.Model;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Shouldly;

namespace ClearMeasure.OnionDevOpsArchitecture.AcceptanceTests
{
    public class GetAllExpenseReportsTester
    {
        private string appURL;
        private IWebDriver driver;
        private TestContext testContextInstance;

        [SetUp]
        public void Setup()
        {
            appURL = "http://localhost:54626";
            driver = new ChromeDriver(".");
        }

        [TearDown]
        public void Teardown()
        {
            driver.Close();
        }

        [Test]
        public void ShouldBeAbleToAddNewExpenseReport()
        {
            driver.Navigate().GoToUrl(appURL + "/");
            var addNewLink = driver.FindElement(By.LinkText("Add New"));
            addNewLink.Click();
            var numberTextBox = driver.FindElement(By.Name(nameof(ExpenseReport.Number)));
            var titleTextBox = driver.FindElement(By.Name(nameof(ExpenseReport.Title)));
            var descriptionTextBox = driver.FindElement(By.Name(nameof(ExpenseReport.Description)));

            numberTextBox.SendKeys("000000");
            titleTextBox.SendKeys("some title");
            descriptionTextBox.SendKeys("some desc");

            var submitButton = driver.FindElement(By.TagName("button"));
            submitButton.Click();

            var numberCells = driver.FindElements(
                By.CssSelector($"td[data-testhandle={nameof(ExpenseReport.Number)}"));
            numberCells.Count.ShouldBeGreaterThan(0);
            numberCells[0].Text.ShouldBe("000000");
        }
    }
}