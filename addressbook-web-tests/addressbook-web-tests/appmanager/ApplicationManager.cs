using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        public void Stop()
        {
            try
            {
                driver.Close();
                driver.Quit();
            }
            catch (Exception ex)
            {
                //
            }
        }

        public ApplicationManager()
        {
            driver = new ChromeDriver();
            baseURL = "http://127.0.0.1";

            loginHelper = new LoginHelper(this); // конструктор хелпера логин
            navigationHelper = new NavigationHelper(this, baseURL); // конструтор хелпера навигации
            groupHelper = new GroupHelper(this); // конструктор хелпера групп
            contactHelper = new ContactHelper(this); // конструктор хелпера контактов
        }

        public IWebDriver Driver
        {
            get { return driver; }
        }

        public LoginHelper Auth
        {
            get { return loginHelper; }
        }

        public NavigationHelper Navi
        {
            get { return navigationHelper; }
        }

        public GroupHelper Groups
        {
            get { return groupHelper; }
        }

        public ContactHelper User
        {
            get { return contactHelper; }
        }

    }
}
