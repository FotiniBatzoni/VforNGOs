using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace VforNGOss.Tests.UITests
{
    [TestFixture, Description("Edit")]
    public class Edit
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void StartChrome()
        {
            driver = new ChromeDriver();
        }

        [Test, Description("Edit an Organization")]
        public void EditAnOrganization()
        {
            //driver.Navigate().GoToUrl("https://localhost:7211");
            //IWebElement AreUOrg = driver.FindElement(By.Id("ruorg"));
            //AreUOrg.Click();
            //driver.FindElement(By.Id("email")).SendKeys("testorgtest@mail.com");
            //IWebElement passwordField = driver.FindElement(By.Id("password"));
            //passwordField.SendKeys("progressnet");
            //passwordField.Submit();
            //Assert.Pass();
        }

        //[Test, Description("Create a Volunteer")]
        //public void CreateAVolunteer()
        //{
        //    driver.Navigate().GoToUrl("https://localhost:7211");
        //    IWebElement AreUVol = driver.FindElement(By.Id("ruvol"));
        //    AreUVol.Click();
        //    driver.FindElement(By.Id("email")).SendKeys("testvoltest@mail.com");
        //    IWebElement passwordField = driver.FindElement(By.Id("password"));
        //    passwordField.SendKeys("progressnet");
        //    passwordField.Submit();
        //    Assert.Pass();
        //}

        [OneTimeTearDown]
        public void CloseTest()
        {
          driver.Close();
        }
    }
}
