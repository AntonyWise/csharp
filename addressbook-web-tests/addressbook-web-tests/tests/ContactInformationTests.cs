using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace WebAddressBookTests
{
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            UserData fromTable = appManager.User.GetContactInformationFromTable(0); //метод получения информации о контактах
            UserData fromForm = appManager.User.GetContactInformationFromEditForm(0); //берем контакт с индексом = 0

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.Email, fromForm.Email);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones); //извлекаем все телефоны

        }
    }
}
