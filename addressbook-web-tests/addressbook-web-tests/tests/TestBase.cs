using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace WebAddressBookTests
{
    //public class TestBase : ApplicationManager // было так?
    public class TestBase
    {
        protected ApplicationManager appManager;
 
            [SetUp]
            public void SetupApplicationManager()
            {
            //appManager = TestSuiteFixture.app; // из TestSuiteFixture
            appManager = ApplicationManager.GetInstance();
            //appManager.Auth.Login(new AccountData("admin", "secret")); // всегда логинимся // убрали в AuthTestBase

            // перемещаем данный код в общую инициализацию TestSuiteFixture
            //appManager.Navi.OpenHomePage(); // всегда открываем стартовую страницу
            //appManager.Auth.Login(new AccountData("admin", "secret")); // всегда логинимся
        }

        // перемещаем останов в TestSuiteFixture
        /*[TearDown]
        public void TearDownTest()
        {
            appManager.Stop(); // метод закрытия драйвера
        }*/

    }
}
