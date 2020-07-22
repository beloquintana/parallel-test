using NUnit.Framework;
using NUnitProject.Pages;
using NUnitProject.Tests.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace NUnitProject.Tests
{
    public class EmployeeTests : BaseTest
    {
        public EmployeeTests()
        {
            Logger.Instance.Info("EmployeeTests Thread-id: " + Thread.CurrentThread.ManagedThreadId);
        }

        [TestCaseSource("DataProviderEmployee")]
        public void TestAddEmployee(String name)
        {
            Logger.Instance.Info("testAddEmployee Thread-id: " + Thread.CurrentThread.ManagedThreadId);

            LoginPage loginPage = new LoginPage(WebDriver);
            EmployeePage employeePage = loginPage.LoginAs("admin", "admin123");
            employeePage.AddEmployee(name, "Juan@gmail.com", "MTZ", "522255",
                    "Montevideo", "Uruguay", "11523");
            Assert.IsTrue(employeePage.IsSuccessAlertVisible());
        }

        static IEnumerable<string> DataProviderEmployee()
        {
            Logger.Instance.Info("testAddEmployee data-provider Thread-id: " + Thread.CurrentThread.ManagedThreadId);
            yield return "Juan";
            yield return "Pedro";
        }
    }
}
