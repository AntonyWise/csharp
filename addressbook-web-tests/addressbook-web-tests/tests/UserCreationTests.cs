using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class UserCreationTests : TestBase
    {
        [Test]
        public void UserCreationTest()
        {
            UserData user = new UserData("antonyNEW");
            user.LastName = "wise";
            user.Address = "russia, spb";
            user.Telephone = "89005555555";
            user.Email = "test@mail.ru";

            appManager.User.Create(user);
        }

    }
}
