using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using w3schoollAutomation.Pages;
using w3schoollAutomation.Pages.SQL;

namespace w3schoollAutomation
{
    public class SqlEditorPage : W3SchoolsPage<SqlEditorPage>
    {
        public bool isAt
        {
            get
            {
                return Driver.Instance.Title.Equals("SQL Tryit Editor v1.6");
            }
        }

        public SQLTutorialPage BackToTutorialsPage()
        {
            Driver.Instance.Close();
            Driver.Instance.SwitchTo().Window(Driver.Instance.WindowHandles[0]);
            return new SQLTutorialPage();
        }

        public Dictionary<string, string> GetQueryResults()
        {
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            Driver.Instance.SwitchTo().Frame(Driver.Instance.FindElement(By.Id("iframeResultSQL")));
            IWebElement queryResultDiv = Driver.Instance.FindElement(By.TagName("table"));
            var queryResults = new Dictionary<string, string>();
            var sElements = queryResultDiv.FindElements(By.TagName("tr"));
            var elementHEaders = queryResultDiv.FindElements(By.TagName("th"));
            string[] keys = new string[elementHEaders.Count];
            for (int i = 0; i < elementHEaders.Count; i++)
            {
                keys[i] = elementHEaders[i].Text;
            }
            foreach (var item in sElements)
            {
                var tt = item.Text;
                var tdElements = item.FindElements(By.TagName("td"));
                for (int i = 0; i < tdElements.Count; i++)
                {
                    queryResults.Add(keys[i], tdElements[i].Text);
                }
            }
            Driver.Instance.SwitchTo().DefaultContent();

            return queryResults;
        }

        public override SqlEditorPage Init()
        {

            Driver.Instance.Navigate().GoToUrl(Driver.BaseURL + "sql/trysql.asp?filename=trysql_select_all");
            return this;
        }
    }
}
