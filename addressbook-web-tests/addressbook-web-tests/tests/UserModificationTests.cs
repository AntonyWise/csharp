using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class UserModificationTests : AuthTestBase // не от TestBase
    {
        [Test]
        public void UserModificationTest()
        {
            if (appManager.User.UserIsAvailable())
            {
                UserData newUser = new UserData("antonyNEW");
                newUser.LastName = "Wise";
                newUser.Address = "SPB";
                newUser.Telephone = "8800";
                newUser.Email = "test_new@mail.ru";
                appManager.User.Modify(1, newUser);
            }
            else
            {
                UserData user = new UserData("antonyNEW");
                user.LastName = "wise";
                user.Address = "russia, spb";
                user.Telephone = "89005555555";
                user.Email = "test@mail.ru";
                appManager.User.Create(user);

                UserData newUser = new UserData("antonyNEW");
                newUser.LastName = "Wise";
                newUser.Address = "SPB";
                newUser.Telephone = "8888";
                newUser.Email = "test_new@mail.ru";
                appManager.User.Modify(1, newUser);

            }
        }

    }
}
