using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace VforNGOss.Tests.UITests
{
    [TestFixture, Description("Display")]
    public class Display
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void StartChrome()
        {
            driver = new ChromeDriver();
        }

        [Test, Description("Display an Organization")]
        public void DisplayAnOrganization()
        {
            driver.Navigate().GoToUrl("https://localhost:7211");
            IWebElement Display = driver.FindElement(By.Id("display"));
            Display.Click();
            IWebElement Org = driver.FindElement(By.Id("org"));
            Org.Click();
            Assert.Pass();
        }

        [Test, Description("Display a Volunteer")]
        public void DisplayAVolunteer()
        {
            driver.Navigate().GoToUrl("https://localhost:7211");
            IWebElement Display = driver.FindElement(By.Id("display"));
            Display.Click();
            IWebElement Vol = driver.FindElement(By.Id("vol"));
            Vol.Click();
            Assert.Pass();
        }

        [OneTimeTearDown]
        public void CloseTest()
        {
          driver.Close();
        }
    }
}
