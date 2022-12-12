using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using VforNGOss.Dapper.Repositories;


namespace VforNGOss.Tests.UITests
{

    [TestFixture, Description("Create")]
    public class Create
    {
        IOrganizationRepository _organization;
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
            driver.FindElement(By.Id("email")).SendKeys("testing-org@mail.com");
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            passwordField.SendKeys("progressnet");
            passwordField.Submit();
            Assert.Pass();
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            var organization = _organization.FindByEmail("testing-org@mail.com");
            _organization.Remove(organization.Id);
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
