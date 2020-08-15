using NUnit.Framework;
using NUnitProject.FactoryWebDriver;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Threading;

namespace NUnitProject.Tests.Base
{
    public abstract class BaseTest
    {
        [ThreadStatic]
        protected static IWebDriver WebDriver;

        private String Url = "https://testfaceclub.com/login-employee-v2/";

        public BaseTest()
        {
            Logger.Instance.Info("BaseTest Thread-id: " + Thread.CurrentThread.ManagedThreadId);
        }

        [SetUp]
        public void SetUp()
        {
            Logger.Instance.Info("setUp Thread-id: " + Thread.CurrentThread.ManagedThreadId);

            WebDriver = WebDriverFactory.GetDriver(ConfigurationManager.AppSettings.Get("browser"),
                                                    ConfigurationManager.AppSettings.Get("seleniumGridUrl"));
            WebDriver.Navigate().GoToUrl(Url);
            WebDriver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            if (WebDriver != null)
            {
                WebDriver.Quit();
            }
        }
    }
}
