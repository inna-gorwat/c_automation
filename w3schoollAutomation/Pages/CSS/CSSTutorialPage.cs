namespace w3schoollAutomation.Pages.CSS
{
    public class CSSTutorialPage: W3SchoolsPage<CSSTutorialPage>
    {
        public override CSSTutorialPage Init()
        {
            Driver.Instance.Navigate().GoToUrl(Driver.BaseURL + "css/default.asp");
            return this;
        }
    
        
    }
}
