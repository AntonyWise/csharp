using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("modify1");
            newData.Header = "modify2";
            newData.Footer = "modify3";

            appManager.Groups.Modify(1, newData);
        }

    }
}
