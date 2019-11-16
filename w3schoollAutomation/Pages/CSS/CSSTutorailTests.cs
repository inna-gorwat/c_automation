using System;
using NUnit.Framework;
using OpenQA.Selenium;
using w3schoollAutomation.Pages;
using w3schoollAutomation;

namespace w3schoollTests
{
    [TestFixture]
    public class CSSTutorailTests : BaseUITest
    {
        private IWebDriver driver;

       

        public override void InitTestPage()
        {
            driver = Driver.Instance;
            Driver.Instance.Navigate().GoToUrl("https://www.w3schools.com/css/default.asp");
        }

        [Test]
        public void verifyTitleWhenOpenCSSTutorialPage()
        {
            /*
            Steps:
            - open CSSTutorial Page 
            - verify title correct and pageHeader correct
            */
            Assert.AreEqual("CSS Tutorial", driver.Title);

        }

        [Test]
        public void verifyUserCanClickNextFromCSS()
        {
            /*
            Steps:
            - open CSSTutorial Page 
            - click Next button
            - verify title correct and pageHeader correct
            */
            IWebElement button = driver.FindElement(By.CssSelector("#main > div:nth-child(3) > a.w3-right.w3-btn"));
            button.Click();
            Assert.AreEqual("CSS Introduction", driver.Title);
           
        }

        [Test]
        public void verifyUserCanClickHomeFromCSS()
        {
            /*
            Steps:
            - open CSSTutorial Page 
            - click Home button
            - verify title correct and pageHeader correct
            */
            IWebElement button = driver.FindElement(By.CssSelector("#main > div:nth-child(3) > a.w3-left.w3-btn"));
            Assert.AreEqual("CSS Tutorial", driver.Title);
            button.Click();
        }


        [Test]
        public void verifyUserCanClickNextButtonSecondTime()
        {
            /*
            Steps:
            - open CSSTutorial Page 
            - click Next button
            - click Next button
            - verify title correct and pageHeader correct
            */
          
            IWebElement button1 = driver.FindElement(By.CssSelector("#main > div:nth-child(3) > a.w3-right.w3-btn"));
            button1.Click();
            IWebElement button2 = driver.FindElement(By.CssSelector("#main > div:nth-child(3) > a.w3-right.w3-btn"));
            button2.Click();
            Assert.AreEqual("CSS Syntax", driver.Title);
         
         
        }

        [Test]
        public void verifyUserCanClickPreviousButton()
        {
            /*
            Steps:
            - open CSSTutorial Page 
            - click Next button
            - click ❮ Previous  button 
            - verify title correct and pageHeader correct
            */
            IWebElement button1 = driver.FindElement(By.CssSelector("#main > div:nth-child(3) > a.w3-right.w3-btn"));
            button1.Click();
            IWebElement button2 = driver.FindElement(By.CssSelector("#main > div:nth-child(3) > a.w3-left.w3-btn"));
            button2.Click();
            Assert.AreEqual("CSS Tutorial", driver.Title);

        }
    }

    internal class CSSTutorialPage
    {
        internal void Init()
        {
            throw new NotImplementedException();
        }
    }
}
