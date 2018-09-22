using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase //наследование не от TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            if (!appManager.Groups.GroupIsAvailable())
            {
                GroupData group = new GroupData("name");
                group.Header = "header";
                group.Footer = "footer";
                appManager.Groups.Create(group);
                Console.Out.Write("group added");
                appManager.Groups.Remove(0);

                //редко необходимая проверка
                int count = appManager.Groups.GetGroupCount();
                Console.Out.Write("group deleted");               
            }
            else //если группы нет - создаем перед удалением
            {
                List<GroupData> oldGroups = appManager.Groups.GetGroupList(); //читаем начальное количество элементов групп
                appManager.Groups.Remove(0); //передаем 0, а не 1 т.к поправили XPath

                //редко необходимая проверка
                int count = appManager.Groups.GetGroupCount();
                Assert.AreEqual(oldGroups.Count - 1, count);

                Console.Out.Write("group deleted");
                List<GroupData> newGroups = appManager.Groups.GetGroupList(); //читаем значение после выполнения удаления группы

                GroupData toBeRemoved = oldGroups[0];
                oldGroups.RemoveAt(0); //удаляем элемент
                Assert.AreEqual(oldGroups, newGroups); //сравнение списков

                foreach (GroupData group in newGroups)
                {
                    Assert.AreNotEqual(group.Id, toBeRemoved.Id);
                }

            }
        }

    }
}
