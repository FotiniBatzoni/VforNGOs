using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace VforNGOss.Tests.UITests
{
    [TestFixture, Description("Create")]
    public class Create
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void StartChrome()
        {
            driver = new ChromeDriver();
        }

        [Test, Description("Create an Organization")]
        public void CreateAnOrganization()
        {
            driver.Navigate().GoToUrl("https://localhost:7211");
            IWebElement AreUOrg = driver.FindElement(By.Id("ruorg"));
            AreUOrg.Click();
            driver.FindElement(By.Id("email")).SendKeys("testorgtest@mail.com");
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            passwordField.SendKeys("progressnet");
            passwordField.Submit();
            Assert.Pass();
        }

        //[Test, Description("Display a Volunteer")]
        //public void DisplayAVolunteer()
        //{
        //    driver.Navigate().GoToUrl("https://localhost:7211");
        //    IWebElement Display = driver.FindElement(By.Id("display"));
        //    Display.Click();
        //    IWebElement Vol = driver.FindElement(By.Id("vol"));
        //    Vol.Click();
        //    Assert.Pass();
        //}

        [OneTimeTearDown]
        public void CloseTest()
        {
          driver.Close();
        }
    }
}
