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
        public static bool PERFORM_LONG_UI_CHECKS = true; //используем проверки в GroupTestBase
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

        public static Random rnd = new Random(); //public для доступа в методе

        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65))); //коды символов ASCII
            }
            return builder.ToString();
        }

        // перемещаем останов в TestSuiteFixture
        /*[TearDown]
        public void TearDownTest()
        {
            appManager.Stop(); // метод закрытия драйвера
        }*/

    }
}
