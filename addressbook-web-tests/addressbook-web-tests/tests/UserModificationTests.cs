using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class UserModificationTests : UserTestBase // не от TestBase
    {
        [Test]
        public void UserModificationTest()
        {
            //юзера нет - создаем
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
                //юзер есть - изменяем
                UserData newUser = new UserData("antonyNEW");
                newUser.LastName = "Wise";
                newUser.Address = "SPB";
                newUser.Telephone = "8888";
                newUser.Email = "test_new@mail.ru";

                List<UserData> oldUsers = UserData.GetAll();
                UserData oldUser = oldUsers[0];
                appManager.User.Modify(0, newUser);

                Console.Out.Write("add check");
                int count = appManager.User.GetUserCount();
                Assert.AreEqual(oldUsers.Count, count); // ожидаемое и фактическое значение

                List<UserData> newUsers = UserData.GetAll();
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
