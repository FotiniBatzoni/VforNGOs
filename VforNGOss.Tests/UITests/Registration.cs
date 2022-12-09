using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace VforNGOss.Tests.UITests
{
    [TestFixture, Description("Registration Process")]
    public class Registration
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void StartChrome()
        {
            driver = new ChromeDriver();
        }

        [Test, Description("Register an Organization")]
        public void RegisterAnOrganization()
        {
            driver.Navigate().GoToUrl("https://localhost:7211");
            IWebElement AreUOrg = driver.FindElement(By.Id("ruorg"));
            AreUOrg.Click();
            Assert.Pass();
        }

        [Test, Description("Register a Volunteer")]
        public void RegisterAVolunteer()
        {
            driver.Navigate().GoToUrl("https://localhost:7211");
            IWebElement AreUVol = driver.FindElement(By.Id("ruvol"));
            AreUVol.Click();
            Assert.Pass();
        }

        [OneTimeTearDown]
        public void CloseTest()
        {
          driver.Close();
        }
    }
}
