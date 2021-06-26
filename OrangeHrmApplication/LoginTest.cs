using Maveric.OrangeHrmApplication.OrangeHrmPages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maveric.OrangeHrmApplication
{
    class LoginTest
    {
        IWebDriver driver;
        //Browser Launch
        [SetUp]
        public void OrangeSetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://opensource-demo.orangehrmlive.com/";
        }

        //Browser End Activities
        [TearDown]
        public void OrangeTearDown()
        {
            driver.Quit();
        }

        [Test]
        public void ValidCredentialTest()
        {
            LoginPage.EnterUsername(driver,"Admin");
            LoginPage.EnterPassword(driver, "admin123");
            LoginPage.ClickOnLogin(driver);

            string actualValue=DashboardPage.GetEmployeeDistributionByUnitHeader(driver);
            Assert.AreEqual("Employee Distribution by Subunit", actualValue);
        }

        [Test]
        public void InvalidCredentialTest()
        {
            LoginPage.EnterUsername(driver,"admin123");
            LoginPage.EnterPassword(driver, "admin123");
            LoginPage.ClickOnLogin(driver);

            Assert.AreEqual("Invalid credentials", LoginPage.GetErrorMessage(driver));
        }

        [Test]
        public void EmptyCredentialTest()
        {
            driver.FindElement(By.Id("btnLogin")).Click();
            Assert.AreEqual("Username cannot be empty", driver.FindElement(By.Id("spanMessage")).Text);
        }

        //emptyusername
        //emptypassword
        //
    }
}
