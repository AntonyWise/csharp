using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager) // конструктор
        {
            this.baseURL = baseURL;
        }

        public void OpenHomePage() // домашняя страница
        {
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }

        public void GoToGroupsPage() // страница групп
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToUserAddPage() // страница добавления юзера
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

    }
}
