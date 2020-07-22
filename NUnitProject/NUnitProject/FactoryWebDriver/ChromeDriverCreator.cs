using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitProject.FactoryWebDriver
{
    public class ChromeDriverCreator : WebDriverCreator
    {
        public override IWebDriver CreateWebDriver()
        {
            return new ChromeDriver();
        }
    }
}
