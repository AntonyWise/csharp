using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebAddressBookTests;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace address_book_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.Out.Write("test");

            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            string format = args[2]; //у меня ошибка args[3]

            List<GroupData> groups = new List<GroupData>();

            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)
                });

                /*writer.WriteLine(String.Format("${0},${1},${2}",
                    TestBase.GenerateRandomString(10),
                    TestBase.GenerateRandomString(10),
                    TestBase.GenerateRandomString(10)));*/
            }

            if (format == "csv")
            {
                WriteGroupsCoCsvFile(groups, writer);
            }
            else if (format == "xml")
            {
                WriteToXmlFile(groups, writer);
            }
            else if (format == "json")
            {
                WriteToJsonFile(groups, writer);
            }
            else
            {
                Console.Out.Write("Error format " + format);
            }

            writer.Close(); //закрыть т.к создается пустой файл иначе
        }

        static void WriteGroupsCoCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        static void WriteToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups); //Serialize(куда, что)
        }

        static void WriteToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented)); //запись возвращаемой строки
        }

    }
}
