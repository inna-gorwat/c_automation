using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace w3schoollAutomation.Pages.SQL
{
    public class SQLTutorialPage : W3SchoolsPage <SQLTutorialPage>
    {
        public bool isAt
        {
            get
            {
                // IWebElement SQLTutorialLink = Driver.Instance.FindElements(By.CssSelector("#main > h1"))[0];
                return Driver.Instance.Title.Equals("SQL Tutorial") && this.GetPageHeader().Equals("SQL Tutorial");
            }
        }

        private IWebElement PageHeader
        {
            get
            {
                return Driver.Instance.FindElement(By.CssSelector("#main > h1"));
            }
        }

        private IWebElement RunSQLButton
        {
            get
            {
                return Driver.Instance.FindElement(By.CssSelector("#main > div.w3-example > a"));
            }
        }

        public string GetPageHeader(){
          return PageHeader.Text;
        }

        public SqlEditorPage OpenSqlEditor()
        {
            RunSQLButton.Click();
            Driver.Instance.SwitchTo().Window(Driver.Instance.WindowHandles[1]);
            return new SqlEditorPage();
        }

        public override SQLTutorialPage Init()
        {
           Driver.Instance.Navigate().GoToUrl(Driver.BaseURL + "sql/default.asp");
            return this;
        }
    }
}
