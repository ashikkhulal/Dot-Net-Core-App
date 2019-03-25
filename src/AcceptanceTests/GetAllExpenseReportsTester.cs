using System;
using System.Diagnostics;
using System.IO;
using ClearMeasure.OnionDevOpsArchitecture.Core.Model;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ClearMeasure.OnionDevOpsArchitecture.AcceptanceTests
{
    public class GetAllExpenseReportsTester
    {
        private TestContext testContextInstance;
        private IWebDriver driver;
        private string appURL;

        [SetUp]
        public void Setup()
        {
            appURL = "http://localhost:54626";
            driver = new ChromeDriver(".");
        }

        [Test]
        public void Test1()
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

        }
    }
}