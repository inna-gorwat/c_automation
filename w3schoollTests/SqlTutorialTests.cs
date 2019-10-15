using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace w3schoollTests
{

    [TestFixture]
    class SqlTutorialTests
    {
        //private variable to use webdriver in tests
        private IWebDriver driver;

        //this method will esecuted before each testcases
        [SetUp]
        public void SetupTest()
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


        //This method will executed after each test cases
        [TearDown]
        public void TeardownTest()
        {
            //closing browser
            driver.Quit();
        }


        //Test method
        [Test]
        public void UserCanOpenSQLTutorialsPage()
        {
            /* Test Case:
            - Open https://www.w3schools.com
            - click on link Learn SQL
            - Verify "SQL Tutorial" page opened
             */

            //Find link on page
            IWebElement button = driver.FindElement(By.CssSelector("#mySidenav > div > a:nth-child(20)"));
            //Check  "Learn SQL" text on link
            Assert.AreEqual("Learn SQL", button.Text);
            //Click on link
            button.Click();
            //Check that page has correct title
            Assert.AreEqual("SQL Tutorial", driver.Title);
        }


        //Test method
        [Test]
        public void User_Can_Open_SQL_Editor_Page()
        {
            /* Test Case:
            - Open https://www.w3schools.com
            - click on link Learn SQL
            - Click on "Run SQL" button
            - Verify SQL Editor page opened
             */
            //Find link element
            IWebElement linkLearnSql = driver.FindElement(By.LinkText("Learn SQL"));
            //click on link
            linkLearnSql.Click();
            //Find Try It button
            IWebElement runButton = driver.FindElement(By.CssSelector("#main > div.w3-example > a"));
            string current = driver.WindowHandles[0];
            //Click on Try It buttons
            runButton.Click();
            //Swithch to new tab
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            //Verify page title is correct
            Assert.AreEqual("SQL Tryit Editor v1.6", driver.Title);
            //Swithch to first tab
            driver.SwitchTo().Window(current);
            //Verify page title is correct
            Assert.AreEqual("SQL Tutorial", driver.Title);
        }
    }
}
