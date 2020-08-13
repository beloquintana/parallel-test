package base;

import factory.WebDriverFactory;
import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.BeforeEach;
import org.openqa.selenium.WebDriver;

public abstract class BaseTest {

    protected WebDriver webDriver;
    private String url = "https://testfaceclub.com/login-employee-v2/";

    public BaseTest(){
        System.out.println("BaseTest Thread-id: " + Thread.currentThread().getId());
    }

    @BeforeAll
    public static void setUpBaseTest(){
        System.out.println("setUpBaseTest Thread-id: " + Thread.currentThread().getId());
    }

    @BeforeEach
    public void setUp() throws Exception {
        System.out.println("setUp Thread-id: " + Thread.currentThread().getId());

        webDriver = WebDriverFactory.getDriver("chrome", "");
        webDriver.get(url);
        webDriver.manage().window().maximize();
    }

    @AfterEach
    public void tearDown(){
        if(webDriver != null){
            webDriver.quit();
        }
    }
}
