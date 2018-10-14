using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using System.Collections.Generic;

namespace address_book_test_autoit
{
    [TestFixture]
    public class GroupRemovedTest : TestBase
    {
        [Test]
        public void TestGroupRemove()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData newGroup = new GroupData()
            {
                Name = "TestGroup"
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
