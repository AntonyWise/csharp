using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using LinqToDB.Mapping;

namespace WebAddressBookTests
{
    public class RemoveContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemoveContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<UserData> oldList = group.GetContactsInGroup(); //читаем начальное значение
            UserData contact = UserData.GetAll().Except(oldList).First(); //исключаем

            appManager.User.RemoveContactToGroup(contact, group);

            List<UserData> newList = group.GetContacts(); //читаем начальное значение
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }

    }
}
