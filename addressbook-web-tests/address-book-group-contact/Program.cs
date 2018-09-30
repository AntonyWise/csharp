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

namespace address_book_group_contact
{
    class Program
    {
        //enum dataType { group, user };

        static void Main(string[] args)
        {
            string type = args[0];
            int count = Convert.ToInt32(args[1]);
            StreamWriter writer = new StreamWriter(args[2]);
            string format = args[3]; 
            
            if (type == "group")
            {
                List<GroupData> groups = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)
                    });
                }
               
                if (format == "xml")
                {
                    WriteToXmlFileGroup(groups, writer);
                }
                else if (format == "json")
                {
                    WriteToJsonFileGroup(groups, writer);
                }
                else
                {
                    Console.Out.Write("Error format " + format);
                }
                writer.Close();
            }
            else if (type == "user")
            {
                {
                    List<UserData> users = new List<UserData>();
                    for (int i = 0; i < count; i++)
                    {
                        users.Add(new UserData(TestBase.GenerateRandomString(10))
                        {
                            LastName = TestBase.GenerateRandomString(10),
                            Address = TestBase.GenerateRandomString(10),
                            Email = TestBase.GenerateRandomString(10),
                            Telephone = TestBase.GenerateRandomString(11),
                            FullName = "Test"
                        });
                    }

                    if (format == "xml")
                    {
                        WriteToXmlFileUser(users, writer);
                    }
                    else if (format == "json")
                    {
                        WriteToJsonFileUser(users, writer);
                    }
                    else
                    {
                        Console.Out.Write("Error format " + format);
                    }
                    writer.Close();
                }
            }
            else
            {
                Console.Out.Write("not available type");
            }
        }

        static void WriteToXmlFileGroup(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups); //Serialize(куда, что)
        }

        static void WriteToJsonFileGroup(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented)); //запись возвращаемой строки
        }

        static void WriteToXmlFileUser(List<UserData> users, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<UserData>)).Serialize(writer, users); //Serialize(куда, что)
        }

        static void WriteToJsonFileUser(List<UserData> users, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(users, Newtonsoft.Json.Formatting.Indented)); //запись возвращаемой строки
        }

    }
}
