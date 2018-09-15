using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class LoginTests : TestBase // не требуется входа, наследуем от TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            // для теста возможно потребуется вход, выполняем Logout
            appManager.Auth.Logout();
            
            // логинимся с нужнымы данными
            AccountData account = new AccountData("admin", "secret");
            appManager.Auth.Login(account);

            // проверка, что зашли под учеткой
            Assert.IsTrue(appManager.Auth.IsLoggedIn(account));
            Console.Out.Write("пароль админа");
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            // для теста возможно потребуется вход, выполняем Logout
            appManager.Auth.Logout();

            // логинимся с нужнымы данными
            AccountData account = new AccountData("admin", "secretNEW");
            appManager.Auth.Login(account);

            // проверка, что зашли под учеткой
            Assert.IsFalse(appManager.Auth.IsLoggedIn(account));
            Console.Out.Write("пароль не админа");
        }
    }
}