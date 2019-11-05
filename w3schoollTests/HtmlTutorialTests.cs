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
            IWebElement button = driver.FindElement(By.CssSelector("#mySidenav > div > a:nth-child(2)"));
            //Check  "Learn HTML" text on link
            Assert.AreEqual("Learn HTML", button.Text);
            //Click on link
            button.Click();
            //Check that page has correct title
            Assert.AreEqual("HTML Tutorial", driver.Title);
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
             //click on link Learn HTML
            driver.FindElement(By.LinkText("Learn HTML")).Click();
            //Find Next button
            IWebElement nextButton = driver.FindElement(By.CssSelector("#main > div.nextprev > a.w3-right.w3-btn"));
            //Click next button
            nextButton.Click();
            //Verify title correct
            Assert.AreEqual("Introduction to HTML", driver.Title);
            //Verify main page header correct
            Assert.AreEqual("Introduction to HTML", driver.FindElement(By.CssSelector("#main > h1 > span")).Text);
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
            driver.FindElement(By.LinkText("Learn HTML")).Click();
            //Find Next button
            IWebElement nextButton = driver.FindElement(By.CssSelector("#main > div.nextprev > a.w3-left.w3-btn"));
            //Click next button
            nextButton.Click();
            //Verify title correct
            Assert.AreEqual("W3Schools Online Web Tutorials", driver.Title);
            
        }
    }
}
