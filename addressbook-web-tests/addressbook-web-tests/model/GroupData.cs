using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    public class GroupData : IEquatable<GroupData> // для объектов определена функция сравнения
    {
        private string name;
        private string header = "";
        private string footer = "";

        // конструктор
        public GroupData(string name)
        {
            this.name = name;
        }
        
        public bool Equals(GroupData other) // стандартный метод сравнения
        {
            if (Object.ReferenceEquals(other, null)) // c null
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other)) // сам с собой
            {
                return true;
            }
            return Name == other.Name;
        }

        public int GetHashCode()
        {
            return Name.GetHashCode();
        }

        // перегруженный конструктор
        /*public GroupData(string name, string header, string footer)
        {
            this.name = name;
            this.header = header;
            this.footer = footer;
        }*/

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Header
        {
            get { return header; }
            set { header = value; }
        }

        public string Footer
        {
            get { return footer; }
            set { footer = value; }
        }

    }
}
