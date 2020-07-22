using NUnit.Framework;
using NUnitProject.Pages;
using NUnitProject.Tests.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace NUnitProject.Tests
{
    public class LoginTests : BaseTest
    {
        public LoginTests()
        {
            Logger.Instance.Info("LoginTests Thread-id: " + Thread.CurrentThread.ManagedThreadId);
        }

        [TestCaseSource("DataProviderLogin")]
        public void TestSuccessfulLogin(String user, String pass)
        {
            Logger.Instance.Info("testSuccessfulLogin Thread-id: " + Thread.CurrentThread.ManagedThreadId);

            LoginPage loginPage = new LoginPage(WebDriver);
            EmployeePage employeePage = loginPage.LoginAs(user, pass);
            Assert.IsTrue(employeePage.IsEmployeePageDisplayed());
            Assert.AreEqual(employeePage.GetUserNameText(), user);
        }

        static IEnumerable<object> DataProviderLogin()
        {
            Logger.Instance.Info("testSuccessfulLogin data-provider Thread-id: " + Thread.CurrentThread.ManagedThreadId);
            yield return new object[] { "admin", "admin123" };
            yield return new object[] { "admin", "admin123" };
        }
    }
}
