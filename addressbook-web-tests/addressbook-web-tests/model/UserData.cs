using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions; //for Regex
using LinqToDB.Mapping;

namespace WebAddressBookTests
{
    [Table(Name = "addressbook")]

    public class UserData : IEquatable<UserData>, IComparable<UserData>// без модификатора public класс не доступен в ContactHelper
    {
        //private string fFirstname;
        //private string fLastname;
        //private string fAddress = "";
        //private string fTelephone = "";
        //private string fEmail = "";

        private string allPhones;

        //конструктор
        public UserData(string firstname)
        {
            FirstName = firstname; //присваивание свойства, не поля
        }

        //перегруженный конструктор
        public UserData(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        //пустой конструктор
        public UserData()
        { }

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
            return "lastname=" + LastName + "\nfirstname=" + FirstName + "\naddress=" + Address + "\nemail=" + Email + "\ntelephone=" + Telephone;
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

        [Column(Name = "firstname"), NotNull]
        public string FirstName { get; set; }

        [Column(Name = "lastname"), NotNull]
        public string LastName { get; set; }

        [Column(Name = "address"), NotNull]
        public string Address { get; set; }

        [Column(Name = "home"), NotNull]
        public string Telephone { get; set; }

        [Column(Name = "email"), NotNull]
        public string Email { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public string FullName { get; set; } //без private поля

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; } 

        public static List<UserData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from u in db.Users.Where(x=>x.Deprecated == "0000-00-00 00:00:00") select u).ToList(); //use db users
                //db.Close(); //используя using метод выполняется автоматически
            }
        }

        //
        public string AllPhones
        {
            get
            {
                if (allPhones != null || allPhones == "") //поле установлено т.е != null
                    return allPhones;
                else
                    return (CleanUp(Telephone)).Trim(); //при наличии mobilePhone + homePhone + workPhone + Trim удаляем пробелы
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string telephone)
        {
            if (telephone == null)
                return "";
            //return telephone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
            return Regex.Replace(telephone, "[ -()]", "") + "\r\n";
        }
    }
}
