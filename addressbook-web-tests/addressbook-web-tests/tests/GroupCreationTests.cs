using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider() //static для NUnit
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++ )
            {
                groups.Add(new GroupData(GenerateRandomString(12)) //30 длина рандомной строки
                {
                    Header = GenerateRandomString(12),
                    Footer = GenerateRandomString(12)
                });
            }
            return groups;
        }

        [Test, TestCaseSource("RandomGroupDataProvider")] //данные для теста из другого метода
        public void GroupCreationTest(GroupData group)
        {
            /*GroupData group = new GroupData("name");
            group.Header = "header";
            group.Footer = "footer";*/

            List<GroupData> oldGroups = appManager.Groups.GetGroupList();
            appManager.Groups.Create(group);

            //редко необходимая проверка
            int count = appManager.Groups.GetGroupCount();
            Assert.AreEqual(oldGroups.Count + 1, count);

            List<GroupData> newGroups = appManager.Groups.GetGroupList();
            oldGroups.Add(group); // добавляем для сравнения списков
            
            //сортировка групп перед сравнением
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups); // ожидаемое и фактическое значение
            Console.Out.Write("group created");
        }

        [Test]
        public void BadNameGroupCreationTest() // баг пойман проверкой
        {
            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = appManager.Groups.GetGroupList();
            appManager.Groups.Create(group);

            //редко необходимая проверка
            int count = appManager.Groups.GetGroupCount();
            Assert.AreEqual(oldGroups.Count + 1, count);

            List<GroupData> newGroups = appManager.Groups.GetGroupList();
            oldGroups.Add(group); // добавляем для сравнения списков

            //сортировка групп перед сравнением
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups); // ожидаемое и фактическое значение
            Console.Out.Write("group created");
        }

    }
}
