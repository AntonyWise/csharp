using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase // наследование не от TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            appManager.Groups.Remove(1);

            //navigationHelper.GoToGroupsPage();
            //groupHelper.SelectGroup(1); // всегда первая группа
            //groupHelper.RemoveGroup();
            //groupHelper.ReturnToGroupsPage();
            //driver.FindElement(By.LinkText("Logout")).Click();
        }

    }
}
