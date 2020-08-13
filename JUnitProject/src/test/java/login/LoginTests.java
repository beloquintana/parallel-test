package login;

import base.BaseTest;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.CsvSource;
import pages.EmployeePage;
import pages.LoginPage;

public class LoginTests extends BaseTest {

    public LoginTests(){
        System.out.println("LoginTests Thread-id: " + Thread.currentThread().getId());
    }

    @ParameterizedTest
    @CsvSource({ "admin,admin123", "admin,admin123" })
    public void testSuccessfulLogin(String user, String pass){
        System.out.println("testSuccessfulLogin Thread-id: " + Thread.currentThread().getId());

        LoginPage loginPage = new LoginPage(webDriver);
        EmployeePage employeePage = loginPage.loginAs(user,pass);
        Assertions.assertTrue(employeePage.isEmployeePageDisplayed());
        Assertions.assertEquals(employeePage.getUserNameText(), user);
    }
}
