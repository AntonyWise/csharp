using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;

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

            List<UserData> users = new List<UserData>(); //пустой список элементов UserData
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
                UserData user = new UserData(firstname, lastname);//конструктор и именем и фамилией в UserData
                users.Add(user);
            }
            return users; //вернули список

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

        public ContactHelper InitUserModification(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).FindElement(By.XPath("//img[@title='Edit']")).Click();
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

        public ContactHelper RemoveUser() // возврат ссылки на сам метод для тестов
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click(); // кнопка и нажатие
            //driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[4]/form[2]/div[2]/input[1]"));
            driver.SwitchTo().Alert().Accept(); // закрытие диалогового окна
            return this;
        }

        public bool UserIsAvailable()
        {
            manager.Navi.OpenHomePage();
            return IsElementPresent(By.XPath("//img[@title='Edit']"));
        }

        public ContactHelper SelectUser(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click(); // передача индекса, а не конкретного элемента
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
            return this;
        }

    }
}
