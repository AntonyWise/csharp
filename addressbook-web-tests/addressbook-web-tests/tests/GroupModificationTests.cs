using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            if (appManager.Groups.GroupIsAvailable())
            {
                GroupData newData = new GroupData("modify1");
                newData.Header = "modify2";
                newData.Footer = "modify3";
                appManager.Groups.Modify(1, newData);
            }
            else
            {
                GroupData group = new GroupData("name");
                group.Header = "header";
                group.Footer = "footer";
                appManager.Groups.Create(group);

                GroupData newData = new GroupData("modify4");
                newData.Header = "modify5";
                newData.Footer = "modify6";
                appManager.Groups.Modify(1, newData);
            }
        }

    }
}
