using Maveric.OrangeHrmApplication.OrangeHrmBase;
using Maveric.OrangeHrmApplication.OrangeHrmPages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maveric.OrangeHrmApplication
{
    class LoginTest : WebDriverWrapper
    {
        [Test]
        public void ValidCredentialTest()
        {
            LoginPage.EnterUsername(driver, "Admin");
            LoginPage.EnterPassword(driver, "admin123");
            LoginPage.ClickOnLogin(driver);

            string actualValue = DashboardMenuPage.GetEmployeeDistributionByUnitHeader(driver);
            Assert.AreEqual("Employee Distribution by Subunit", actualValue);
        }

        [Test]
        public void InvalidCredentialTest()
        {
            LoginPage.EnterUsername(driver, "admin123");
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
