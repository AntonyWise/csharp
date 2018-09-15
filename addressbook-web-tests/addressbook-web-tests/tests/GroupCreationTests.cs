using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

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

            appManager.Groups.Create(group);

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

            appManager.Groups.Create(group);
        }

     }
}
