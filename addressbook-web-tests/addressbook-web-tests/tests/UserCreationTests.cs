using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class UserCreationTests : AuthTestBase // не от TestBase
    {
        [Test]
        public void UserCreationTest()
        {
            UserData user = new UserData("firstname");
            user.LastName = "lastname";
            //user.Address = "russia, spb";
            //user.Telephone = "89005555555";
            //user.Email = "test@mail.ru";

            List<UserData> oldUsers = appManager.User.GetUserList();
            appManager.User.Create(user);

            List<UserData> newUsers = appManager.User.GetUserList();
            oldUsers.Add(user); // добавляем для сравнения списков
            
            //сортировка групп перед сравнением
            oldUsers.Sort();
            newUsers.Sort();

            Assert.AreEqual(oldUsers, newUsers); // ожидаемое и фактическое значение
            Console.Out.Write("user created");
        }

    }
}
