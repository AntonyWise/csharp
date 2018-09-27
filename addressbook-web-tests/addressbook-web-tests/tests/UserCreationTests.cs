﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class UserCreationTests : AuthTestBase // не от TestBase
    {
        public static IEnumerable<UserData> RandomGroupDataProvider() //static для NUnit
        {
            List<UserData> users = new List<UserData>();
            for (int i = 0; i < 5; i++)
            {
                users.Add(new UserData(GenerateRandomString(12)) //30 длина рандомной строки
                {
                    LastName = GenerateRandomString(12),
                    Address = GenerateRandomString(12),
                    Email = GenerateRandomString(12),
                    AllPhones = GenerateRandomString(12)
                });
            }
            return users;
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void UserCreationTest(UserData user)
        {
            //UserData user = new UserData("firstname");
            //user.LastName = "lastname";
            //user.Address = "russia, spb";
            //user.Telephone = "89005555555";
            //user.Email = "test@mail.ru";

            List<UserData> oldUsers = appManager.User.GetUserList();
            appManager.User.Create(user);

            Console.Out.Write("add check");
            int count = appManager.User.GetUserCount();
            Assert.AreEqual(oldUsers.Count + 1, count); // ожидаемое и фактическое значение

            List<UserData> newUsers = appManager.User.GetUserList();
            oldUsers.Add(user); // добавляем для сравнения списков
            
            //сортировка групп перед сравнением
            oldUsers.Sort();
            newUsers.Sort();

            Assert.AreEqual(oldUsers, newUsers); // ожидаемое и фактическое значение
            Console.Out.Write("user created");
        }

    }
}
