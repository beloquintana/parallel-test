package base;

import org.openqa.selenium.WebDriver;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.BeforeSuite;
import org.testng.annotations.Parameters;
import webdriver.factory.WebDriverFactory;

public abstract class BaseTest {
    //protected WebDriver webDriver;
    protected ThreadLocal<WebDriver> webDriverThread = new ThreadLocal<>();
    private String url = "https://testfaceclub.com/login-employee-v2/";

    public BaseTest(){
        System.out.println("BaseTest Thread-id: " + Thread.currentThread().getId());
    }

    @BeforeSuite(alwaysRun = true)
    public void setUpSuite(){
        System.out.println("setUpSuite Thread-id: " + Thread.currentThread().getId());
    }

    @BeforeMethod(alwaysRun = true)
    @Parameters({"browser", "seleniumGridUrl"})
    public void setUp(String browser, String seleniumGridUrl) throws Exception {
        System.out.println("setUp Thread-id: " + Thread.currentThread().getId());

        webDriverThread.set(WebDriverFactory.getDriver(browser, seleniumGridUrl));
        webDriverThread.get().get(url);
        webDriverThread.get().manage().window().maximize();
    }

    @AfterMethod(alwaysRun = true)
    public void tearDown(){
        if(webDriverThread.get() != null){
            webDriverThread.get().quit();
            webDriverThread.remove();
        }
    }
}
