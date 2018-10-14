using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestStack.White;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;

namespace addressbook_test_white
{
    public class ApplicationManager
    {
        public static string WINTITLE = "Free Address Book";
        private GroupHelper groupHelper; //поле

        public ApplicationManager()
        {
            Application app = Application.Launch(@"C:\Git\Repo\csharp\address_book_test_autoit\FreeAddressBookPortable\AddressBook.exe");
            MainWindow =  app.GetWindow(WINTITLE);

            groupHelper = new GroupHelper(this);
        }

        public void Stop()
        {
            MainWindow.Get<Button>("uxExitAddressButton").Click();
        }

        public Window MainWindow { get; set; }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }

    }
}
