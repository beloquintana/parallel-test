package login;

import base.BaseTest;
import org.testng.Assert;
import org.testng.annotations.DataProvider;
import org.testng.annotations.Test;
import pages.EmployeePage;
import pages.LoginPage;

public class LoginTests extends BaseTest {

    public LoginTests(){
        System.out.println("LoginTests Thread-id: " + Thread.currentThread().getId());
    }

    @Test(dataProvider = "data-provider")
    public void testSuccessfulLogin(String user, String pass){
        System.out.println("testSuccessfulLogin Thread-id: " + Thread.currentThread().getId());

        LoginPage loginPage = new LoginPage(webDriverThread.get());
        EmployeePage employeePage = loginPage.loginAs("admin","admin123");
        Assert.assertTrue(employeePage.isEmployeePageDisplayed());
        Assert.assertEquals(employeePage.getUserNameText(), "admin");
    }

    @DataProvider(name = "data-provider", parallel = true)
    public Object[][] dataProviderMethod() {
        System.out.println("testSuccessfulLogin data-provider Thread-id: " + Thread.currentThread().getId());
        return new Object[][] { { "admin", "admin123" },
                                { "admin", "admin123" } };
    }
}
