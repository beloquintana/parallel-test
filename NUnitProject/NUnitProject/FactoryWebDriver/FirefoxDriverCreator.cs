using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace NUnitProject.FactoryWebDriver
{
    public class FirefoxDriverCreator : ChromeDriverCreator
    {
        public override IWebDriver CreateWebDriver()
        {
            return new FirefoxDriver();
        }
    }
}
