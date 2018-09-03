using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class UserModificationTests : TestBase
    {
        [Test]
        public void UserModificationTest()
        {
            UserData newUser = new UserData("antonyNEW");
            newUser.LastName = "Wise";
            newUser.Address = "SPB";
            newUser.Telephone = "8800";
            newUser.Email = "test_new@mail.ru";

            appManager.User.Modify(1, newUser);
        }

    }
}
