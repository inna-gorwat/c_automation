using NUnit.Framework;
using OpenQA.Selenium;
using w3schoollAutomation;
using w3schoollAutomation.Pages.HTML;

namespace w3schoollTests
{
    [TestFixture]
    public class HtmlTutorialTests : BaseUITest
    {
        private HTMLTutorialPage page = new HTMLTutorialPage();

        public override void InitTestPage()
        {
            page.Init();
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

            Assert.True(page.isAt, "Html tutorial page not opened");
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
            page.ClickNext();
            //Verify title correct
            Assert.AreEqual("Introduction to HTML", page.GetTitle());
            //Verify main page header correct
            Assert.AreEqual("HTML Introduction", page.GetPageHeader());
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
            page.ClickHome();
            //Verify title correct
            Assert.AreEqual("W3Schools Online Web Tutorials", page.GetTitle());

        }
    }
}
