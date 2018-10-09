using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LinqToDB;

namespace WebAddressBookTests
{
    public class AddressBookDB : LinqToDB.Data.DataConnection
    {
        public AddressBookDB() : base("AddressBook") { } //конструктор "AddressBook" - название БД

        public ITable<GroupData> Groups { get { return GetTable<GroupData>(); } }

        public ITable<UserData> Users { get { return GetTable<UserData>(); } }
    }
}
