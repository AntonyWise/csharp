using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    public class UserData : IEquatable<UserData>, IComparable<UserData> // без модификатора public класс не доступен в ContactHelper
    {
        private string fFirstname;
        private string fLastname;
        private string fAddress = "";
        private string fTelephone = "";
        private string fEmail = "";

        // конструктор
        public UserData(string firstname)
        {
            fFirstname = firstname;
            //fLastname = lastname;
        }

        public bool Equals(UserData other) // стандартный метод сравнения
        {
            if (Object.ReferenceEquals(other, null)) // c null
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other)) // сам с собой
            {
                return true;
            }
            return FirstName == other.FirstName;
        }

        public override int GetHashCode() // override т.к переопределяем стандартный метод GetHashCode
        {
            return FirstName.GetHashCode();
        }

        public override string ToString() // возврат строкового представления объектов типо UserData
        {
            return "firstname=" + FirstName;
        }

        public int CompareTo(UserData other) // определили метод для сравнения IComparable<UserData>
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return FirstName.CompareTo(other.FirstName);
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
