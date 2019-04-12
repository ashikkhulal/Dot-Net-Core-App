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

        [OneTimeSetUp]
        public void Setup()
        {
            appURL = new DataConfigurationStub().GetValue("AppUrl", Assembly.GetExecutingAssembly());
            driver = new ChromeDriver(".");
            new ZDataLoader().LoadLocalData();
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }

        [TestCase("000001", TestName = "Should add new expense report numbered '000001'")]
        [TestCase("000010", TestName = "Should add new expense report numbered '000010'")]
        [TestCase("000100", TestName = "Should add new expense report numbered '000100'")]
        [TestCase("001000", TestName = "Should add new expense report numbered '001000'")]
        [TestCase("010000", TestName = "Should add new expense report numbered '010000'")]
        [TestCase("100000", TestName = "Should add new expense report numbered '100000'")]
        public void ShouldBeAbleToAddNewExpenseReport(string expenseReportNumber)
        {
            void ClickLink(string linkText)
            {
                driver.FindElement(By.LinkText(linkText)).Click();
            }

            void TypeText(string elementName, string text)
            {
                var numberTextBox = driver.FindElement(By.Name(elementName));
                numberTextBox.SendKeys(text);
            }

            Console.WriteLine($"Navigating to {appURL}");
            driver.Navigate().GoToUrl(appURL + "/");
            TakeScreenshot($"{expenseReportNumber}-Step1Arrange.png");

            ClickLink("Add New");
            
            TypeText(nameof(ExpenseReport.Number), expenseReportNumber);
            TypeText(nameof(ExpenseReport.Title), "some title");
            TypeText(nameof(ExpenseReport.Description), "some desc");
            
            TakeScreenshot($"{expenseReportNumber}-Step2Act.png");

            driver.FindElement(By.TagName("button")).Click();
            
            var numberCells = driver.FindElements(
                By.CssSelector($"td[data-expensereport-property=\"{nameof(ExpenseReport.Number)}\"][data-value=\"{expenseReportNumber}\"]"));
            numberCells.Count.ShouldBeGreaterThan(0);
            numberCells[0].Text.ShouldBe(expenseReportNumber);
            
            TakeScreenshot($"{expenseReportNumber}-Step3Assert.png");
        }

        private void TakeScreenshot(string fileName)
        {
            ((ChromeDriver) driver).GetScreenshot().SaveAsFile(fileName);
        }
    }
}