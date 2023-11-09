using November2023SpecFlowPOM.Drivers;
using OpenQA.Selenium.Chrome;

namespace November2023SpecFlowPOM.BaseHook
{
    [Binding]
    
    public sealed class Hooks : DriverHelper
    {
  

        [BeforeScenario]
        public void BeforeScenario()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized", "--incognito");
            //options.AddArguments("--headless");
            //options.AddArguments("--no-sandbox");
            //options.AddArguments("--disable-dev-shm-usage");
            options.AddArguments("disable-infobars");
            options.AddExcludedArguments("enable-automation");
            Driver = new ChromeDriver(options);
            
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Driver.Quit();
        }
    }
}
