package employee;

import base.BaseTest;
import org.testng.Assert;
import org.testng.annotations.DataProvider;
import org.testng.annotations.Test;
import pages.EmployeePage;
import pages.LoginPage;
import webdriver.factory.threadsafe.CurrentWebDriver;

public class EmployeeTests extends BaseTest {

    public EmployeeTests(){
        System.out.println("EmployeeTests Thread-id: " + Thread.currentThread().getId());
    }

    @Test(dataProvider = "data-provider")
    public void testAddEmployee(String name){
        System.out.println("testAddEmployee Thread-id: " + Thread.currentThread().getId());

        LoginPage loginPage = new LoginPage(CurrentWebDriver.getInstance().getWebDriver());
        EmployeePage employeePage = loginPage.loginAs("admin","admin123");
        employeePage.addEmployee(name,"Juan@gmail.com","MTZ","522255",
                "Montevideo", "Uruguay", "11523");
        Assert.assertTrue(employeePage.isSuccessAlertVisible());
    }

    @DataProvider(name = "data-provider", parallel = true)
    public Object[][] dataProviderMethod() {
        System.out.println("testAddEmployee data-provider Thread-id: " + Thread.currentThread().getId());
        return new Object[][] { {"Juan"},
                                {"Pedro"} };
    }
}
