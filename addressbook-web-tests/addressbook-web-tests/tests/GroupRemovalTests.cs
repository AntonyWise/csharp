using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            appManager.Navi.GoToGroupsPage();
            //navigationHelper.GoToGroupsPage();

            appManager.Groups.SelectGroup(1);
            //groupHelper.SelectGroup(1); // всегда первая группа
            appManager.Groups.RemoveGroup();
            //groupHelper.RemoveGroup();
            appManager.Groups.ReturnToGroupsPage();
            //groupHelper.ReturnToGroupsPage();
            //driver.FindElement(By.LinkText("Logout")).Click();
        }

    }
}
