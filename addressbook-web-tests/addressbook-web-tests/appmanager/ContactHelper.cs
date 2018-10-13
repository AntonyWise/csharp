using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using System.Text.RegularExpressions; //for Regex

namespace WebAddressBookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) 
            : base(manager) //конструктор
        {
        }

        private List<UserData> userCache = null;

        public List<UserData> GetUserList()
        {
            if (userCache == null)
            {
                userCache = new List<UserData>();
                manager.Navi.OpenHomePage(); //переходим на страницу юзеров
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name = 'entry']"));
                Console.Out.Write(elements.Count);

                // преобразование IWebElement в UserData
                foreach (IWebElement element in elements)
                {
                    //для перебора значений элемента в ячейках!
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    string firstname = cells[2].Text;
                    string lastname = cells[1].Text;
                    UserData user = new UserData(firstname, lastname); //конструктор с именем и фамилией в UserData                 
                    user.Id = element.FindElement(By.XPath("//input[@name='selected[]']")).GetAttribute("value");
                    userCache.Add(user);
                }
            }
           
            return new List<UserData>(userCache); //вернули копию списка
        }

        public UserData GetContactInformationFromSmallTable(int index)
        {
            manager.Navi.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastname = cells[1].Text;
            string firstname = cells[2].Text;
            //string address = cells[3].Text;
            string email = cells[4].Text;
            //string allPhones = cells[5].Text;

            string fullname = firstname + " " + lastname;

            return new UserData()
            {
                FullName = fullname,
                Email = email
            };
        }

        public UserData GetContactInformationFromTable(int index)
        {
            manager.Navi.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastname = cells[1].Text;
            string firstname = cells[2].Text;
            string address = cells[3].Text;
            string email = cells[4].Text;
            string allPhones = cells[5].Text;

            return new UserData(firstname, lastname)
            {
                Address = address,
                Email = email,
                AllPhones = allPhones
            };
        }

        public UserData GetContactInformationFromEditForm(int index)
        {
            manager.Navi.OpenHomePage();
            _InitUserModification(0);

            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string telephone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            //string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            //string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new UserData(firstname, lastname)
            {
                Address = address,
                Telephone = telephone,
                Email = email,
            };
        }

        public UserData GetContactInformationFromDetails(int index)
        {
            manager.Navi.OpenHomePage();
            _InitUserDetails(0);

            string fullname = driver.FindElement(By.XPath("//*[@id='content']/child::b[1]")).Text;
            //string address = driver.FindElement(By.XPath("//*[@id='content']/child::text[2]")).Text; //?
            string email = driver.FindElement(By.XPath("//*[@id='content']/child::a[1]")).Text;
            string alltext = driver.FindElement(By.XPath("//*[@id='content']")).Text;
            //Console.Out.Write(fullname);
            //Console.Out.Write(address);
            //Console.Out.Write(email);
            Console.Out.Write(alltext);

            /*string pattern = "[ :H]";
            foreach (char ch in alltext)
            {
                Console.Out.Write(Regex.Replace(ch.ToString(), pattern, String.Empty));
            }*/
            //string fields = (Regex.Replace(alltext, "[ :H]", ""));

            return new UserData()
            {
                FullName = fullname,
                Email = email
            };
        }

        public void _InitUserDetails(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6] //details
                .FindElement(By.TagName("a")).Click();
        }

        public void _InitUserModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7] //edit
                .FindElement(By.TagName("a")).Click();
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navi.OpenHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

        public int GetUserCount()
        {
            return driver.FindElements(By.XPath("//tr[@name='entry']")).Count;
        }

        public ContactHelper Create(UserData user)
        {
            manager.Navi.GoToUserAddPage();

            FillUserForm(user);
            SubmitUserCreation();
            ReturnHomePage();
            return this;
        }

        public ContactHelper Modify(int user, UserData newUser)
        {
            manager.Navi.OpenHomePage();

            //SelectUser(user);
            InitUserModification(user);
            FillUserForm(newUser);
            SubmitUserModification();
            ReturnHomePage();
            return this;
        }

        public ContactHelper Modify(UserData user, UserData newUser)
        {
            manager.Navi.OpenHomePage();

            //SelectUser(user);
            InitUserModification(user.Id);
            FillUserForm(newUser);
            SubmitUserModification();
            ReturnHomePage();
            return this;
        }

        public ContactHelper InitUserModification(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).FindElement(By.XPath("//img[@title='Edit']")).Click();
            return this;
        }

        public ContactHelper InitUserModification(String id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).FindElement(By.XPath("//img[@title='Edit']")).Click();
            return this;
        }

        public ContactHelper Remove(int user)
        {
            //manager.Navi.OpenHomePage();
            SelectUser(user);
            RemoveUser();
            //driver.SwitchTo().Alert().Accept();
            ReturnHomePage();
            return this;
        }

        public ContactHelper Remove(UserData user) //удаление по индексу
        {
            //manager.Navi.OpenHomePage();
            SelectUser(user.Id);
            RemoveUser();
            //driver.SwitchTo().Alert().Accept();
            ReturnHomePage();
            return this;
        }

        public ContactHelper RemoveUser() // возврат ссылки на сам метод для тестов
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click(); // кнопка и нажатие
            //driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[4]/form[2]/div[2]/input[1]"));
            driver.SwitchTo().Alert().Accept(); // закрытие диалогового окна
            userCache = null;
            Console.Out.Write("cache clear (RemoveUser)");
            return this;
        }

        public bool UserIsAvailable()
        {
            manager.Navi.OpenHomePage();
            return IsElementPresent(By.XPath("//img[@title='Edit']"));
        }

        public ContactHelper SelectUser(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click(); //передача индекса, а не конкретного элемента
            return this;
        }

        public ContactHelper SelectUser(String id) //по ид
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='"+ id +"'])")).Click(); //передача ид
            return this;
        }

        public ContactHelper FillUserForm(UserData user)
        {
            //driver.FindElement(By.Name("firstname")).Click();
            //driver.FindElement(By.Name("firstname")).Clear();
            //driver.FindElement(By.Name("firstname")).SendKeys(user.FirstName);
            Type(By.Name("firstname"), user.FirstName);

            //driver.FindElement(By.Name("lastname")).Click();
            //driver.FindElement(By.Name("lastname")).Clear();
            //driver.FindElement(By.Name("lastname")).SendKeys(user.LastName);
            Type(By.Name("lastname"), user.LastName);

            //driver.FindElement(By.Name("address")).Click();
            //driver.FindElement(By.Name("address")).Clear();
            //driver.FindElement(By.Name("address")).SendKeys(user.Address);
            Type(By.Name("address"), user.Address);

            //driver.FindElement(By.Name("home")).Click();
            //driver.FindElement(By.Name("home")).Clear();
            //driver.FindElement(By.Name("home")).SendKeys(user.Telephone);
            Type(By.Name("home"), user.Telephone);

            //driver.FindElement(By.Name("email")).Click();
            //driver.FindElement(By.Name("email")).Clear();
            //driver.FindElement(By.Name("email")).SendKeys(user.Email);
            Type(By.Name("email"), user.Email);

            return this;
        }

        public ContactHelper SubmitUserCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            userCache = null; //чистим кэш
            Console.Out.Write("cache clear (SubmitUserCreation)");
            return this;
        }

        public ContactHelper ReturnHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }

        public ContactHelper SubmitUserModification()
        {
            driver.FindElement(By.Name("update")).Click();
            userCache = null;
            Console.Out.Write("cache clear (SubmitUserModification)");
            return this;
        }

    }
}
