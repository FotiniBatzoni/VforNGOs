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

        [Test, Description("Reguister a User")]
        public void RegisterAUser()
        {
            driver.Navigate().GoToUrl("https://localhost:7211/");
            Assert.Pass();
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                //IWebElement AreUOrg = driver.FindElement(By.Id("ruorg"));
                //AreUOrg.Click();
                //Console.WriteLine("lala");
             

        }

        [OneTimeTearDown]
        public void CloseTest()
        {
          // driver.Close();
        }
    }
}
