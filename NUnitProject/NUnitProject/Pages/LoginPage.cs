using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace NUnitProject.Pages
{
    public class LoginPage : BasePage
    {
        private By UserInput = By.Id("user");
        private By PassWordInput = By.Id("pass");
        private By LoginButton = By.Id("loginButton");
        private By ErrorMessage = By.Name("errorMessage");

        public LoginPage(IWebDriver webDriver)
            : base(webDriver)
        {

        }

        public void TypeUserName(String user)
        {
            IWebElement element = WebDriver.FindElement(UserInput);
            element.SendKeys(user);
        }

        public void TypePassWord(String passWord)
        {
            IWebElement element = WebDriver.FindElement(PassWordInput);
            element.SendKeys(passWord);
        }

        public EmployeePage ClickOnLoginButton()
        {
            IWebElement element = WebDriver.FindElement(LoginButton);
            element.Click();
            return new EmployeePage(WebDriver);
        }

        public EmployeePage LoginAs(String user, String passWord)
        {
            TypeUserName(user);
            TypePassWord(passWord);
            return ClickOnLoginButton();
        }

        public bool IsErrorMessageVisible()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(3));
                wait.Until(drv => drv.FindElement(ErrorMessage).Displayed);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsLoginPageDisplayed()
        {
            return WebDriver.FindElement(LoginButton).Displayed;
        }
    }
}
