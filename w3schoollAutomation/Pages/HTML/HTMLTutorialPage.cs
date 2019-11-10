using OpenQA.Selenium;

namespace w3schoollAutomation.Pages.HTML
{
    public class HTMLTutorialPage : W3SchoolsPage<HTMLTutorialPage>
    {
        public override HTMLTutorialPage Init()
        {
            Driver.Instance.Navigate().GoToUrl(Driver.BaseURL + "html/default.asp");
            return this;
        }

        public HTMLTutorialPage ClickNext()
        {
            Driver.Instance.FindElement(By.CssSelector("#main > div.nextprev > a.w3-right.w3-btn"))
                .Click();
            return this;
        }

        public HTMLTutorialPage ClickHome()
        {
            Driver.Instance.FindElement(By.CssSelector("#main > div.nextprev > a.w3-left.w3-btn")).Click();
            return this;
        }

        public HTMLTutorialPage ClikPrevious()
        {
            return this;
        }


        public string GetTitle()
        {
            return Driver.Instance.Title;
        }

        public string GetPageHeader()
        {
            return Driver.Instance.FindElement(By.CssSelector("#main > h1")).Text;
        }



        public bool isAt
        {
            get
            {
                return GetTitle()
                .Equals("HTML Tutorial") && GetPageHeader().Equals("HTML Tutorial");
            }
        }
    }
}
