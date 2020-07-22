using OpenQA.Selenium;
using System;

namespace NUnitProject.FactoryWebDriver
{
    public class WebDriverFactory
    {
        public static IWebDriver GetDriver(String browser, String seleniumGridUrl)
        {
            switch (browser)
            {
                case "chrome":
                    ChromeDriverCreator chromeDriverCreator = new ChromeDriverCreator();
                    return chromeDriverCreator.CreateWebDriver();
                case "firefox":
                    FirefoxDriverCreator firefoxDriverCreator = new FirefoxDriverCreator();
                    return firefoxDriverCreator.CreateWebDriver();
                case "chrome-remote":
                    RemoteChromeDriverCreator remoteChromeDriverCreator = new RemoteChromeDriverCreator(seleniumGridUrl);
                    return remoteChromeDriverCreator.CreateWebDriver();
                case "firefox-remote":
                    RemoteFirefoxDriverCreator remoteFirefoxDriverCreator = new RemoteFirefoxDriverCreator(seleniumGridUrl);
                    return remoteFirefoxDriverCreator.CreateWebDriver();
                default:
                    throw new Exception("Navegador " + browser + " no soportado");
            }
        }

    }
}
