using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace w3schoollAutomation
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }
        public static string BaseURL { get { return "https://www.w3schools.com/"; } }

        public static void Initialize()
        {
            // InitFireforDriver();
            InitChromeDriver();
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Instance.Manage().Window.Maximize();
        }

        public static void InitChromeDriver()
        {
            Instance = new ChromeDriver(@"c:\tools");
        }

        public static void InitFireforDriver()
        {
            //Give the path of the geckodriver.exe    
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"c:\tools", "geckodriver.exe");
            //Give the path of the Firefox Browser        
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            Instance = new FirefoxDriver(service);
        }

        public static void Close()
        {
            Instance.Quit();
        }
    }
}
