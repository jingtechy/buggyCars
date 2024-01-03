using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BuggyCars.Specs.Drivers
{
    public class BrowserDriver : IDisposable
    {
        private readonly Lazy<IWebDriver> currentWebDriverLazy;
        private bool isDisposed;
    
        public BrowserDriver()
        {
            currentWebDriverLazy = new Lazy<IWebDriver>(CreateWebDriver);
        }
       
        // Selenium web driver instance
        public IWebDriver Current => currentWebDriverLazy.Value;
        
        // Creates the Selenium web driver (open the chrome browser)
        private IWebDriver CreateWebDriver()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
    
            var chromeOptions = new ChromeOptions();
    
            var chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions);
    
            return chromeDriver;
        }
        
        // The browser will be automatically closed after the scenario finished
    
        public void Dispose()
        {
            if (isDisposed)
            {
                return;
            }
    
            if (currentWebDriverLazy.IsValueCreated)
            {
                Current.Quit();
            }
    
            isDisposed = true;
        }
    }
}


