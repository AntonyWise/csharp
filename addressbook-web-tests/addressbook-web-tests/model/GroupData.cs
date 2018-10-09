using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LinqToDB.Mapping;

namespace WebAddressBookTests
{
    [Table(Name = "group_list")]

    public class GroupData : IEquatable<GroupData>, IComparable<GroupData> //для объектов определена функция сравнения
    {
        //private string name; убрали, т.к реализовали иначе get set
        //private string header = "";
        //private string footer = "";

        // конструктор
        public GroupData(string name)
        {
            //this.name = name; убрали, т.к реализовали иначе get set
            Name = name;
        }

        public GroupData() //конструктор без параметров для 6.2
        { }

        //стандартный метод сравнения - добавляем!
        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null)) //объект c которым сравниваем = null
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other)) //объект с которым сравниваем он же (совпадают)
            {
                return true;
            }
            return Name.Equals(other.Name); // return Name == other.Name
        }
        
        //стандартный метод сравнения - добавляем!
        public override int GetHashCode() //override т.к переопределяем стандартный метод GetHashCode
        {
            return Name.GetHashCode(); //без оптимизации можно вернуть return = 0;
        }

        //переопределение
        public override string ToString() //возврат строкового представления объектов типо GroupData
        {
            return "name=" + Name + "\nheader=" + Header + "\nfooter=" + Footer;
        }

        public int CompareTo(GroupData other) //определили метод для сравнения IComparable<GroupData>
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        // перегруженный конструктор
        /*public GroupData(string name, string header, string footer)
        {
            this.name = name;
            this.header = header;
            this.footer = footer;
        }*/

        [Column(Name = "group_name"), NotNull] //значение NotNull т.к поле в таблице != 0
        public string Name { get; set; }
        /*{
            get { return name; } убрали, т.к реализовали иначе get set
            set { name = value; }
        }*/

        [Column(Name = "group_header"), NotNull]
        public string Header { get; set; }

        [Column(Name = "group_footer"), NotNull]
        public string Footer { get; set; }

        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public static List<GroupData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups select g).ToList();
                //db.Close(); //используя using метод выполняется автоматически
            }
        }

    }
}
