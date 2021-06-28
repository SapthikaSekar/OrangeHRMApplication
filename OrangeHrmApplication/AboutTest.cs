using Maveric.OrangeHrmApplication.OrangeHrmBase;
using Maveric.OrangeHrmApplication.OrangeHrmPages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OrangeHrmApplication.OrangeHrmPages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maveric.OrangeHrmApplication
{
    class AboutTest : WebDriverWrapper
    {
        [Test]
        public void AboutSectionTest()
        {
            LoginPage.EnterUsername(driver, "Admin");
            LoginPage.EnterPassword(driver, "admin123");
            LoginPage.ClickOnLogin(driver);

            OrangePortalPage.ClickOnProfileIcon(driver);
            OrangePortalPage.ClickOnAbout(driver);
            string actualValue = OrangePortalPage.GetAboutSectionDetail(driver);
            Console.WriteLine(actualValue);
            Assert.True(actualValue.Contains("BTG Knitwear Ltd"));
            Assert.True(actualValue.Contains("Version: Orangehrm OS 4.8"));
            Assert.True(actualValue.Contains("Active Employees: 61"));
            Assert.True(actualValue.Contains("Employees Terminated: 0"));
           
        }
    }
}
