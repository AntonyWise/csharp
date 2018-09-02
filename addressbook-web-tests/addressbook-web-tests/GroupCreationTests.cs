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
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitGroupCreation();

            //FillGroupForm(new GroupData("name", "header", "footer"));
            GroupData group = new GroupData("name");
            group.Header = "header";
            group.Footer = "footer";
            FillGroupForm(group);

            SubmitGroupCreation();
            ReturnToGroupsPage();
            //driver.FindElement(By.LinkText("Logout")).Click();
        }

    }
}
