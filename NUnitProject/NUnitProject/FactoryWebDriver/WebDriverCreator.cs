using OpenQA.Selenium;

namespace NUnitProject.FactoryWebDriver
{
    public abstract class WebDriverCreator
    {
        public abstract IWebDriver CreateWebDriver();
    }
}
