using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class UserRemovalTests : UserTestBase // не от TestBase
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

                List<UserData> oldUsers = UserData.GetAll();
                UserData toBeRemoved = oldUsers[0];
                appManager.User.Remove(toBeRemoved);
                Console.Out.Write("add check");

                int count = appManager.User.GetUserCount();
                Assert.AreEqual(oldUsers.Count - 1, count); // ожидаемое и фактическое значение

                Console.Out.Write("user deleted");
                List<UserData> newUsers = UserData.GetAll();

                //UserData toBeRemoved = oldUsers[0];
                oldUsers.RemoveAt(0);
                Assert.AreEqual(oldUsers, newUsers);

                foreach (UserData user in newUsers)
                {
                    Assert.AreNotEqual(user.Id, toBeRemoved.Id);
                }
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
