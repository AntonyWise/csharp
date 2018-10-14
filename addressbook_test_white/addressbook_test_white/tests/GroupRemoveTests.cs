using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_test_white
{
    [TestFixture]
    public class GroupRemoveTests : TestBase
    {
        [Test]
        public void TestGroupRemove()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData newGroup = new GroupData()
            {
                Name = "TestGroupWhite"
            };

            app.Groups.Remove(newGroup);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
