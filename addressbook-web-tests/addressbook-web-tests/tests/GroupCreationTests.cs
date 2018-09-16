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
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("name");
            group.Header = "header";
            group.Footer = "footer";

            List<GroupData> oldGroups = appManager.Groups.GetGroupList();
            appManager.Groups.Create(group);

            List<GroupData> newGroups = appManager.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count +1, newGroups.Count); // ожидаемое и фактическое значение
            Console.Out.Write("group created");

            //navigationHelper.GoToGroupsPage();
            //groupHelper.InitGroupCreation();
            //FillGroupForm(new GroupData("name", "header", "footer"));
            //groupHelper.FillGroupForm(group);
            //groupHelper.SubmitGroupCreation();
            //groupHelper.ReturnToGroupsPage();
            //driver.FindElement(By.LinkText("Logout")).Click();
        }

        [Test]
        public void GroupCreationTestEmpty()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = appManager.Groups.GetGroupList();
            appManager.Groups.Create(group);

            List<GroupData> newGroups = appManager.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count); // ожидаемое и фактическое значение
            Console.Out.Write("empty group created");
        }

        [Test]
        public void BadNameGroupCreationTest() // баг пойман проверкой
        {
            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = appManager.Groups.GetGroupList();
            appManager.Groups.Create(group);

            List<GroupData> newGroups = appManager.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count); // ожидаемое и фактическое значение
        }

    }
}
