using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebAddressBookTests
{
    public class TestBase : ApplicationManager
    {
        protected ApplicationManager appManager;
 
            [SetUp]
            public void SetupTest()
            { 
                //driver = new ChromeDriver();
                //baseURL = "http://127.0.0.1";
                //verificationErrors = new StringBuilder();

                appManager = new ApplicationManager();
                appManager.Navi.OpenHomePage();
                appManager.Auth.Login(new AccountData("admin", "secret"));
        }

            [TearDown]
            public void TearDownTest()
            {
                appManager.Stop();
            }

    }
}
