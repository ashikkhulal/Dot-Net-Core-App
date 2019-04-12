using System;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using ClearMeasure.OnionDevOpsArchitecture.Core.Model;
using ClearMeasure.OnionDevOpsArchitecture.IntegrationTests;
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
            appURL = new DataConfigurationStub().GetValue("AppUrl", Assembly.GetExecutingAssembly());
            driver = new ChromeDriver(".");
            new ZDataLoader().LoadLocalData();
        }

        [TearDown]
        public void Teardown()
        {
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void ShouldBeAbleToAddNewExpenseReport()
        {
            Console.WriteLine($"Navigating to {appURL}");
            driver.Navigate().GoToUrl(appURL + "/");
            var addNewLink = driver.FindElement(By.LinkText("Add New"));
            ((ChromeDriver)driver).GetScreenshot().SaveAsFile($"Step1Arrange.png");
            addNewLink.Click();
            var numberTextBox = driver.FindElement(By.Name(nameof(ExpenseReport.Number)));
            var titleTextBox = driver.FindElement(By.Name(nameof(ExpenseReport.Title)));
            var descriptionTextBox = driver.FindElement(By.Name(nameof(ExpenseReport.Description)));

            numberTextBox.SendKeys("000000");
            titleTextBox.SendKeys("some title");
            descriptionTextBox.SendKeys("some desc");

            var submitButton = driver.FindElement(By.TagName("button"));
            ((ChromeDriver)driver).GetScreenshot().SaveAsFile($"Step2Act.png");
            submitButton.Click();

            var numberCells = driver.FindElements(
                By.CssSelector($"td[data-testhandle={nameof(ExpenseReport.Number)}"));
            numberCells.Count.ShouldBeGreaterThan(0);
            numberCells[0].Text.ShouldBe("000000");
            ((ChromeDriver)driver).GetScreenshot().SaveAsFile($"Step3Assert.png");
        }
    }
}