using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            appManager.Navi.GoToGroupsPage();
            //navigationHelper.GoToGroupsPage();

            appManager.Groups.InitGroupCreation();
            //groupHelper.InitGroupCreation();
            //FillGroupForm(new GroupData("name", "header", "footer"));
            GroupData group = new GroupData("name");
            group.Header = "header";
            group.Footer = "footer";
            appManager.Groups.FillGroupForm(group);
            //groupHelper.FillGroupForm(group);

            appManager.Groups.SubmitGroupCreation();
            //groupHelper.SubmitGroupCreation();
            appManager.Groups.ReturnToGroupsPage();
            //groupHelper.ReturnToGroupsPage();
            //driver.FindElement(By.LinkText("Logout")).Click();
        }

    }
}
