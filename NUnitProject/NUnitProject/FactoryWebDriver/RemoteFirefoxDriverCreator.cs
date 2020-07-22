using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;

namespace NUnitProject.FactoryWebDriver
{
    public class RemoteFirefoxDriverCreator : WebDriverCreator
    {
        private String Url;

        public RemoteFirefoxDriverCreator(String url)
        {
            Url = url;
        }

        public override IWebDriver CreateWebDriver()
        {
            return new RemoteWebDriver(new Uri(Url), new FirefoxOptions());
        }
    }
}
