using NUnit.Framework;
using w3schoollAutomation;

namespace w3schoollTests
{
    public abstract class BaseUITest
    {

        [OneTimeSetUp]
        public void Init()
        {
            Driver.Initialize();
        }


        //This method will executed after each test cases
        [OneTimeTearDown]
        public void TeardownTest()
        {
            //closing browser
            Driver.Close();
        }


        [SetUp]
        public abstract void InitTestPage();
    }
}
