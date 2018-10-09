using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using System.Collections.Generic;
using NUnit.Framework;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Linq;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider() //static для NUnit
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(12)) //30 длина рандомной строки
                {
                    Header = GenerateRandomString(12),
                    Footer = GenerateRandomString(12)
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            //List<GroupData> groups = new List<GroupData>();

            return (List<GroupData>) //приведение типа к List<GroupData>
                new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader(@"groups.xml"));

            //return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"groups.json"));
        }

        [Test, TestCaseSource("GroupDataFromJsonFile")] //данные для теста из другого метода
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

        [Test]
        public void TestDBConnect()
        {
            DateTime start = DateTime.Now;
            List<GroupData> fromUI = appManager.Groups.GetGroupList();
            DateTime end = DateTime.Now;

            Console.Out.Write(end.Subtract(start)); //из конца вычитаем начало интервала

            start = DateTime.Now;
            /*using (AddressBookDB db = new AddressBookDB()) //перенесли метод в GroupData
            {
                return List < GroupData > fromDB = (from g in db.Groups select g).ToList();
                //db.Close(); //используя using метод выполняется автоматически
            }*/
            List<GroupData> fromDB = GroupData.GetAll();
            end = DateTime.Now;

            Console.Out.Write(end.Subtract(start));
        }

    }
}
