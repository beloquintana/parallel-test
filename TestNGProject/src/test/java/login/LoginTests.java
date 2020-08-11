package login;

import base.BaseTest;
import org.testng.Assert;
import org.testng.annotations.DataProvider;
import org.testng.annotations.Test;
import pages.EmployeePage;
import pages.LoginPage;
import webdriver.factory.threadsafe.CurrentWebDriver;

public class LoginTests extends BaseTest {

    public LoginTests(){
        System.out.println("LoginTests Thread-id: " + Thread.currentThread().getId());
    }

    @Test(dataProvider = "data-provider")
    public void testSuccessfulLogin(String user, String pass){
        System.out.println("testSuccessfulLogin Thread-id: " + Thread.currentThread().getId());

        LoginPage loginPage = new LoginPage(CurrentWebDriver.getInstance().getWebDriver());
        EmployeePage employeePage = loginPage.loginAs(user,pass);
        Assert.assertTrue(employeePage.isEmployeePageDisplayed());
        Assert.assertEquals(employeePage.getUserNameText(), user);
    }

    @DataProvider(name = "data-provider", parallel = true)
    public Object[][] dataProviderMethod() {
        System.out.println("testSuccessfulLogin data-provider Thread-id: " + Thread.currentThread().getId());
        return new Object[][] { { "admin", "admin123" },
                                { "admin", "admin123" } };
    }
}
