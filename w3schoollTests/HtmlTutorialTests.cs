using System;
using NUnit.Framework;
using OpenQA.Selenium;
using w3schoollAutomation;


namespace w3schoollTests
{
    [TestFixture]
    public class HtmlTutorialTests : BaseUITest
    {
        private IWebDriver driver;

        public override void InitTestPage()
        {
            driver = Driver.Instance;
            Driver.Instance.Navigate().GoToUrl("https://www.w3schools.com/");
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
            Assert.AreEqual("HTML Introduction", driver.FindElement(By.CssSelector("#main > h1")).Text);
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
