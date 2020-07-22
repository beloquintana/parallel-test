using OpenQA.Selenium;

namespace NUnitProject.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver WebDriver;

        public BasePage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }
    }
}
