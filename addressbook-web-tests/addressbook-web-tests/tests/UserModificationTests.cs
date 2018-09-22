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
            //если нет юзера - создаю
            if (!appManager.User.UserIsAvailable())
            {
                UserData user = new UserData("antonyNEW");
                user.LastName = "wise";
                user.Address = "russia, spb";
                user.Telephone = "89005555555";
                user.Email = "test@mail.ru";
                appManager.User.Create(user);
            }
            else
            {
                //если есть юзер - модификация
                UserData newUser = new UserData("antonyNEW");
                newUser.LastName = "Wise";
                newUser.Address = "SPB";
                newUser.Telephone = "8888";
                newUser.Email = "test_new@mail.ru";

                List<UserData> oldUsers = appManager.User.GetUserList();
                UserData oldUser = oldUsers[0];
                appManager.User.Modify(0, newUser);

                Console.Out.Write("add check");
                int count = appManager.User.GetUserCount();
                Assert.AreEqual(oldUsers.Count, appManager.User.GetUserCount()); // ожидаемое и фактическое значение

                List<UserData> newUsers = appManager.User.GetUserList();
                oldUsers[0].LastName = newUser.LastName;
                oldUsers[0].FirstName = newUser.FirstName;

                oldUsers.Sort();
                newUsers.Sort();

                Assert.AreEqual(oldUsers, newUsers);

                foreach (UserData user in newUsers)
                {
                    if (user.Id == oldUser.Id)
                    {
                        Assert.AreEqual(newUser.LastName, user.LastName);
                        Assert.AreEqual(newUser.FirstName, user.FirstName);
                    }
                }
            }

            /*if (appManager.User.UserIsAvailable())
            {
                UserData newUser = new UserData("antonyNEW");
                newUser.LastName = "Wise";
                newUser.Address = "SPB";
                newUser.Telephone = "8800";
                newUser.Email = "test_new@mail.ru";
                appManager.User.Modify(0, newUser);
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
                appManager.User.Modify(0, newUser);

            }*/
        }

    }
}
