using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase 
    {
        [Test]
        public void GroupModificationTest()
        {
            //группы нет - создаем
            if (!appManager.Groups.GroupIsAvailable())
            {
                GroupData group = new GroupData("name");
                group.Header = "header";
                group.Footer = "footer";
                appManager.Groups.Create(group);
            }
            else
            {
                //группа есть - изменяем
                GroupData newData = new GroupData("modify1");
                newData.Header = "modify2";
                newData.Footer = "modify3";

                List<GroupData> oldGroups = GroupData.GetAll();
                GroupData toBeModify = oldGroups[0];
                //GroupData oldData = oldGroups[0];
                appManager.Groups.Modify(toBeModify, newData); //передаем toBeModify для измнения за место 0

                //редко необходимая проверка
                int count = appManager.Groups.GetGroupCount();
                Assert.AreEqual(oldGroups.Count, count);

                List<GroupData> newGroups = GroupData.GetAll();
                oldGroups[0].Name = newData.Name;
                
                //сортировка групп перед сравнением
                oldGroups.Sort();
                newGroups.Sort();

                Assert.AreEqual(oldGroups, newGroups);

                foreach (GroupData group in newGroups)
                {
                    if (group.Id == toBeModify.Id) //сравнение ид
                    {
                        Assert.AreEqual(newData.Name, group.Name);
                    }
                }
            }

            /*if (appManager.Groups.GroupIsAvailable())
            {
                GroupData newData = new GroupData("modify1");
                newData.Header = "modify2";
                newData.Footer = "modify3";

                List<GroupData> oldGroups = appManager.Groups.GetGroupList();
                appManager.Groups.Modify(0, newData);

                List<GroupData> newGroups = appManager.Groups.GetGroupList();
                oldGroups[0].Name = newData.Name;
                // сортировка групп перед сравнением
                oldGroups.Sort();
                newGroups.Sort();
                Assert.AreEqual(oldGroups, newGroups); // ожидаемое и фактическое значение
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

                List<GroupData> oldGroups = appManager.Groups.GetGroupList();
                appManager.Groups.Modify(0, newData);

                List<GroupData> newGroups = appManager.Groups.GetGroupList();
                oldGroups[0].Name = newData.Name;
                // сортировка групп перед сравнением
                oldGroups.Sort();
                newGroups.Sort();
                Assert.AreEqual(oldGroups, newGroups); // ожидаемое и фактическое значение
            }*/

        }

    }
}
