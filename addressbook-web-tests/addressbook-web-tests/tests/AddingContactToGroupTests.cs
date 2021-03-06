﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using LinqToDB.Mapping;

namespace WebAddressBookTests
{
    public class AddingContactToGroupTests : AuthTestBase //AuthTestBase для входа в систему
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<UserData> oldList = group.GetContacts(); //читаем начальное значение
            UserData contact = UserData.GetAll().Except(oldList).First(); //исключаем

            appManager.User.AddContactToGroup(contact, group);

            List<UserData> newList = group.GetContacts(); //читаем начальное значение
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }

    }
}
