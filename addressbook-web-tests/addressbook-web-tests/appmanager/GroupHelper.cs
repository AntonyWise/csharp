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
    public class GroupHelper : HelperBase //видимость public + все методы в хелпере так же public !
    {

        public GroupHelper(ApplicationManager manager) 
            : base(manager) //конструктор
        {
        }

        private List<GroupData> groupCache = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navi.GoToGroupsPage(); //переходим на страницу групп
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group")); //коллекция элементов страницы по селектору
                Console.Out.Write(elements.Count);
                //преобразование IWebElement в GroupData
                foreach (IWebElement element in elements)
                {                   
                    groupCache.Add(new GroupData(element.Text) //new GroupData(null) либо конструктор без параметров
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value") //поиск элемента в элементе
                    });
                }

                string allGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text;
                string[] parts = allGroupNames.Split('\n');
                int shift = groupCache.Count - parts.Length;
                for (int i = 0; i < groupCache.Count; i++)
                {
                    if (i < shift)
                    {
                        groupCache[i].Name = "";
                    }
                    else
                    {
                        groupCache[i].Name = parts[i-shift].Trim(); //удаляем пробелы ф-ция Trim()
                    }
                }

            }
            return new List<GroupData> (groupCache); //вернули список
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

        public GroupHelper Modify(GroupData group, GroupData newData)
        {
            //manager.Navi.GoToGroupsPage();
            SelectGroup(group.Id);
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

        public GroupHelper Remove(GroupData group)
        {
            manager.Navi.GoToGroupsPage();
            SelectGroup(group.Id);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper RemoveGroup() // возврат ссылки на сам метод для тестов
        {      
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
                driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click(); //передача индекса, а не конкретного элемента
                return this;
        }

        public GroupHelper SelectGroup(String id) //по ид
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='"+ id +"'])")).Click(); //передача ид
            return this;
        }

        public bool GroupIsAvailable()
        {
            manager.Navi.GoToGroupsPage();
            return IsElementPresent(By.XPath("//span[@class='group']"));
        }

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

    }
}
