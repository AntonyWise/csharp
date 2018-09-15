﻿using System;
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
    public class GroupHelper : HelperBase // видимость public + все методы в хелпере так же public !
    {

        public GroupHelper(ApplicationManager manager) 
            : base(manager) // конструктор
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navi.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this; // возвращает GroupHelper
        }

        public GroupHelper Modify(int group, GroupData newData)
        {
            //manager.Navi.GoToGroupsPage();
            SelectGroup(group);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(int group)
        {
            //manager.Navi.GoToGroupsPage();
                SelectGroup(group);
                RemoveGroup();
                ReturnToGroupsPage();
                return this;
        }

        public GroupHelper RemoveGroup() // возврат ссылки на сам метод для тестов
        {      
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
                driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click(); // передача индекса, а не конкретного элемента
                return this;
        }

        public bool GroupIsAvailable()
        {
            manager.Navi.GoToGroupsPage();
            return IsElementPresent(By.XPath("//span[@class='group']"));
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            //By locator = By.Name("group_name");
            //string text = group.Name;
            Type(By.Name("group_name"), group.Name);

            Type(By.Name("group_header"), group.Header);
            //driver.FindElement(By.Name("group_header")).Clear();
            //driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            Type(By.Name("group_footer"), group.Footer);
            //driver.FindElement(By.Name("group_footer")).Clear();
            //driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
            return this;
        }

        /*public void Type(By locator, string text) // метод перенесен в базовый класс HelperBase
        {
            if (text != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }
        }*/

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

    }
}
