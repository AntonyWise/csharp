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
            if (driver.Url == baseURL + "/addressbook/")
            {
                return;
            }

            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }

        public void GoToGroupsPage() // страница групп
        {
            // добавляем проверу, находимся ли мы уже на странице групп
            if (driver.Url == baseURL + "/addressbook/group.php" && IsElementPresent(By.Name("new")))
            {
                return;
            }
            // если нет, то находим элемент и кликаем
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToUserAddPage() // страница добавления юзера
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

    }
}
