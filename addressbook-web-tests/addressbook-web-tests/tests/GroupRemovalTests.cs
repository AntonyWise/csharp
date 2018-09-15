using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase // наследование не от TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            if (appManager.Groups.GroupIsAvailable())
            {
                appManager.Groups.Remove(1);
                Console.Out.Write("group deleted");
            }
            else
            {
                GroupData group = new GroupData("name");
                group.Header = "header";
                group.Footer = "footer";
                appManager.Groups.Create(group);
                Console.Out.Write("group added");
                appManager.Groups.Remove(1);
                Console.Out.Write("group deleted");
            }
        }

    }
}
