using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace WebAddressBookTests
{
    public class UserTestBase : AuthTestBase
    {

        [TearDown]
        public void CompareGroupsUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<UserData> fromUI = appManager.User.GetUserList(); //из списка
                List<UserData> fromDB = UserData.GetAll(); //из БД

                fromUI.Sort();
                fromDB.Sort();

                Assert.AreEqual(fromUI, fromDB);
            }
        }

    }
}
