using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace NUnitProject.Pages
{
    public class EmployeePage : BasePage
    {
        private By NameInput = By.Id("name");
        private By EmailInput = By.Id("email");
        private By CityInput = By.XPath("//*[@ng-model=\"city\"]");
        private By StateInput = By.Id("state");
        private By PostcodeInput = By.Id("postcode");
        private By AddressInput = By.Id("address");
        private By PhoneInput = By.Id("phoneNumber");
        private By AddButtonButton = By.Id("addButton");
        private By FormEmployee = By.Id("gridEmployee");
        private By SuccessAlert = By.Id("success-alert");
        private By ErrorAlert = By.Id("danger-alert");
        private By LogOutButton = By.XPath("//*[@id=\"contentEmployee\"]/h4/span");

        public EmployeePage(IWebDriver webDriver)
            : base(webDriver)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(15));
            wait.Until(drv => drv.FindElement(NameInput));
        }

        public void AddEmployee(String name, String email, String address, String phone, String city, String state,
                            String postcode)
        {
            WebDriver.FindElement(NameInput).SendKeys(name);
            WebDriver.FindElement(CityInput).SendKeys(city);
            WebDriver.FindElement(StateInput).SendKeys(state);
            WebDriver.FindElement(PostcodeInput).SendKeys(postcode);
            WebDriver.FindElement(EmailInput).SendKeys(email);
            WebDriver.FindElement(AddressInput).SendKeys(address);
            WebDriver.FindElement(PhoneInput).SendKeys(phone);
            WebDriver.FindElement(AddButtonButton).Click();
        }

        public bool IsEmployeePageDisplayed()
        {
            IWebElement element = WebDriver.FindElement(FormEmployee);
            return element.Displayed;
        }

        public bool IsSuccessAlertVisible()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(3));
                wait.Until(drv => drv.FindElement(SuccessAlert).Displayed);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsErrorAlertVisible()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(3));
                wait.Until(drv => drv.FindElement(ErrorAlert).Displayed);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public LoginPage ClickOnLogOutButton()
        {
            WebDriver.FindElement(LogOutButton).Click();
            return new LoginPage(WebDriver);
        }

        public String GetUserNameText()
        {
            return WebDriver.FindElement(LogOutButton).Text;
        }
    }
}