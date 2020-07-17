package employee;

import base.BaseTest;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.ValueSource;
import pages.EmployeePage;
import pages.LoginPage;

public class EmployeeTests extends BaseTest {

    public EmployeeTests(){
        System.out.println("EmployeeTests Thread-id: " + Thread.currentThread().getId());
    }

    @ParameterizedTest
    @ValueSource(strings = { "Juan", "Pedro" })
    public void testAddEmployee(String name){
        System.out.println("testAddEmployee Thread-id: " + Thread.currentThread().getId());
        System.out.println("testAddEmployee Thread-id: " + testVar);

        LoginPage loginPage = new LoginPage(webDriver);
        EmployeePage employeePage = loginPage.loginAs("admin","admin123");
        employeePage.addEmployee(name,"Juan@gmail.com","MTZ","522255",
                "Montevideo", "Uruguay", "11523");
        Assertions.assertTrue(employeePage.isSuccessAlertVisible());
    }
}
