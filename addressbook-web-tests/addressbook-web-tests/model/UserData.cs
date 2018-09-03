using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    public class UserData // без модификатора public класс не доступен в ContactHelper
    {
        private string fFirstname;
        private string fLastname = "";
        private string fAddress = "";
        private string fTelephone = "";
        private string fEmail = "";

        // конструктор
        public UserData(string firstname)
        {
            fFirstname = firstname;
        }

        public string FirstName
        {
            get { return fFirstname; }
            set { fFirstname = value; }
        }

        public string LastName
        {
            get { return fLastname; }
            set { fLastname = value; }
        }

        public string Address
        {
            get { return fAddress; }
            set { fAddress = value; }
        }

        public string Telephone
        {
            get { return fTelephone; }
            set { fTelephone = value; }
        }

        public string Email
        {
            get { return fEmail; }
            set { fEmail = value; }
        }
    }
}
