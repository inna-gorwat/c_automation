using OpenQA.Selenium;

namespace w3schoollAutomation.Pages
{
    public abstract class W3SchoolsPage<T> : IW3SchollPage
    {
        public void OpenPage(string LinkText)
        {
            var pageLink = Driver.Instance.FindElement(By.LinkText(LinkText));
            pageLink.Click();
        }

        public abstract T Init();

        object IW3SchollPage.Init()
        {
          Driver.Instance.Navigate().GoToUrl(Driver.BaseURL);
            return this; // Calls the generic GetContent method.
        }
    }
}
