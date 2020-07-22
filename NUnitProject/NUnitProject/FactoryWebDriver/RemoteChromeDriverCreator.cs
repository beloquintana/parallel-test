using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace NUnitProject.FactoryWebDriver
{
    public class RemoteChromeDriverCreator : WebDriverCreator
    {
        private String Url;

        public RemoteChromeDriverCreator(String url)
        {
            Url = url;
        }

        public override IWebDriver CreateWebDriver()
        {
            return new RemoteWebDriver(new Uri(Url), new ChromeOptions());
        }
    }
}
