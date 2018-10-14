using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace address_book_test_autoit
{
    public class TestBase
    {
        public ApplicationManager app;

        [TestFixtureSetUp] //выполнятеся один раз перед тестовыми методами
        public void initApplication()
        {
            app = new ApplicationManager();
        }

        [TestFixtureTearDown]
        public void stopApplication()
        {
            app.Stop();
        }

    }
}
