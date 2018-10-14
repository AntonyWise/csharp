using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoItX3Lib;

namespace address_book_test_autoit
{
    public class ApplicationManager
    {
        public static string WINTITLE = "Free Address Book";
        private AutoItX3 aux;
        private GroupHelper groupHelper; //поле

        public ApplicationManager()
        {
            aux = new AutoItX3();
            aux.Run(@"C:\Git\Repo\csharp\address_book_test_autoit\FreeAddressBookPortable\AddressBook.exe", "", aux.SW_SHOW);
            aux.WinWait(WINTITLE);
            aux.WinActivate(WINTITLE);
            aux.WinWaitActive(WINTITLE);

            groupHelper = new GroupHelper(this);
        }

        public void Stop()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d510"); //1 название окна, 2 текст кнопки, 3 идентификатор кнопки (локатор)
        }

        public AutoItX3 Aux
        {
            get
            {
                return aux;
            }
        }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }

    }
}
