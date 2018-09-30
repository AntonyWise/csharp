using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using System.Threading;

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

        //private static ApplicationManager instance; // убрали, запуск в потоках
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>(); // спец.объект между потоком и объектом ApplicationManager

        private ApplicationManager()
        {
            driver = new ChromeDriver();
            baseURL = "http://127.0.0.1";

            loginHelper = new LoginHelper(this); // конструктор хелпера логин
            navigationHelper = new NavigationHelper(this, baseURL); // конструтор хелпера навигации
            groupHelper = new GroupHelper(this); // конструктор хелпера групп
            contactHelper = new ContactHelper(this); // конструктор хелпера контактов
        }

        //деструктор, для избавления от метода Stop()
        ~ApplicationManager() // для деструктора не нужен модификатор доступа !
        {
            try
            {
                //driver.Close();
                driver.Quit();
            }
            catch (Exception)
            {
                //
            }
        }

        // метод не нужен, т.к код в деструкторе
        /*public void Stop()
        {
            try
            {
                //driver.Close();
                driver.Quit();
            }
            catch (Exception ex)
            {
                //
            }
        }*/

        public static ApplicationManager GetInstance() // static - глобальный метод 
        {
            /*if (instance == null)
            {
                instance = new ApplicationManager();
            }

            return instance;
        }*/

            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();

                newInstance.Navi.OpenHomePage(); // всегда открываем стартовую страницу
                //app.Value = new ApplicationManager();
                app.Value = newInstance;
            }

            return app.Value;
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
