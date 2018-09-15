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
            appManager.User.Remove(1);
        }

    }
}
