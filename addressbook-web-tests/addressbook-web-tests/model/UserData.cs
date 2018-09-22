using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    public class UserData : IEquatable<UserData>, IComparable<UserData>// без модификатора public класс не доступен в ContactHelper
    {
        //private string fFirstname;
        //private string fLastname;
        //private string fAddress = "";
        //private string fTelephone = "";
        //private string fEmail = "";

        //конструктор
        public UserData(string firstname)
        {
            FirstName = firstname;
        }

        //перегруженный конструктор
        public UserData(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
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
            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public override int GetHashCode() // override т.к переопределяем стандартный метод GetHashCode
        {
            return FirstName.GetHashCode() + LastName.GetHashCode();
        }

        public override string ToString() // возврат строкового представления объектов типо UserData
        {
            return "lastname=" + LastName + " " + "firstname=" + FirstName;
        }

        public int CompareTo(UserData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (FirstName.CompareTo(other.FirstName) == 0)
            {
                return LastName.CompareTo(other.LastName);
            }
            else
            {
                return FirstName.CompareTo(other.FirstName);
            }
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public string Id { get; set; }
    }
}
