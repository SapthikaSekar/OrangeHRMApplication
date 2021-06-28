using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maveric.OrangeHrmApplication.OrangeHrmBase
{
    class WebDriverWrapper
    {
        protected IWebDriver driver;
        //Browser Launch
        [SetUp]
        public void OrangeSetUp()
        {
            string browser = "ff";

            if (browser.ToLower().Equals("ff"))
            {
                driver = new FirefoxDriver();
            }
            else if(browser.ToLower().Equals("ie"))
            {
                driver = new InternetExplorerDriver();
            }
            else
            {
                driver = new ChromeDriver();
            }
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
    }
}
