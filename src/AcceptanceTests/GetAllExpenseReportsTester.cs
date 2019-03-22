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
            appURL = "http://localhost:54626/api/values";
            driver = new ChromeDriver(".");
        }

        [Test]
        public void Test1()
        {
            
            driver.Navigate().GoToUrl(appURL + "/");
            Debug.WriteLine(driver.PageSource);
            ExpenseReport[] reports = JsonConvert.DeserializeObject<ExpenseReport[]>(driver.PageSource);
        }
    }
}