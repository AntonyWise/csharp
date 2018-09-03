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
                appManager = new ApplicationManager();
                appManager.Navi.OpenHomePage(); // всегда открываем стартовую страницу
                appManager.Auth.Login(new AccountData("admin", "secret")); // всегда логинимся
        }

            [TearDown]
            public void TearDownTest()
            {
                appManager.Stop(); // метод закрытия драйвера
            }

    }
}
