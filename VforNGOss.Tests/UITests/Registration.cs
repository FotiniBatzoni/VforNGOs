using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace VforNGOss.Tests.UITests
{
    [TestFixture, Description("Registration Process")]
    public class Registration
    {
        [Test, Description("Reguister a User")]
        public void RegisterAUser()
        {
            using (WebDriver driver  = new ChromeDriver())
            {
               
                //driver.Url = "https://localhost:7211/";
                driver.Navigate().GoToUrl("https://localhost:7211/");
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                //IWebElement AreUOrg = driver.FindElement(By.Id("ruorg"));
                //AreUOrg.Click();
                //Console.WriteLine("lala");
            }    

        }
    }
}
