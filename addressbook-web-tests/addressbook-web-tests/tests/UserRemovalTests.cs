using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class UserRemovalTests : AuthTestBase // не от TestBase
    {
        [Test]
        public void UserRemovalTest()
        {
            //если юзера нет - создаем
            if (!appManager.User.UserIsAvailable())
            {
                UserData user = new UserData("CreateFromRemove");
                user.LastName = "wise";
                user.Address = "russia, spb";
                user.Telephone = "89005555555";
                user.Email = "test@mail.ru";
                appManager.User.Create(user);
            }
            //если есть - удаляем
            else
            {
                appManager.User.Remove(0);
            }

            /*if (appManager.User.UserIsAvailable())
            {
                appManager.User.Remove(0);
            }
            else
            {
                UserData user = new UserData("antonyNEW");
                user.LastName = "wise";
                user.Address = "russia, spb";
                user.Telephone = "89005555555";
                user.Email = "test@mail.ru";
                appManager.User.Create(user);

                appManager.User.Remove(0);
            }*/
        }

    }
}
