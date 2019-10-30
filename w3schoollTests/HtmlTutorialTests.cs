using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace w3schoollTests
{
    [TestFixture]
    public class HtmlTutorialTests
    {
          private IWebDriver driver;

        [OneTimeSetUp]
         public void Init()
        {
            //Give the path of the firefox driver geckodriver.exe    
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"c:\tools", "geckodriver.exe");

            //Give the path of the Firefox Browser        
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";

            //inot driver varibale
            driver = new FirefoxDriver(service);

            // driver = new ChromeDriver(@"c:\tools");

            //added ImplicitWait to webdriver, webdriver will wailt 30 seconds for page loading etc.
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            //For maximize browser
            driver.Manage().Window.Maximize();
            //Webdriver will open this URL
            driver.Url = "https://www.w3schools.com/default.asp";
        }

        //this method will esecuted before each testcases
        [SetUp]
        public void SetupTest()
        {
           
            driver.Navigate().GoToUrl("https://www.w3schools.com/default.asp");
        }


        //This method will executed after each test cases
        [OneTimeTearDown]
        public void TeardownTest()
        {
            //closing browser
            driver.Quit();
        }


        //Test method
        [Test]
        public void UserCanOpenHTMLTutorialsPage()
        {
            /* Test Case:
            - Open https://www.w3schools.com
            - click on link Learn HTML
            - Verify "HTML Tutorial" page opened
             */

            //Find link on page
           
            //Check  "Learn HTML" text on link

            //Click on link

            //Check that page has correct title

        }


        [Test]
        public void User_Can_Click_Next_From_HTMLTutorial_Page()
        {
            /* Test Case:
            - Open https://www.w3schools.com
            - click on link Learn HTML
            - Click on "Next >" button
            - Verify HTML Introduction  page opened
             */
            
        }

        [Test]
        public void User_Can_Click_Home_From_HTMLTutorial_Page()
        {
            /* Test Case:
            - Open https://www.w3schools.com
            - click on link Learn HTML
            - Click on "< Home" button
            - Verify Home page opened
             */
            
        }
    }
}
