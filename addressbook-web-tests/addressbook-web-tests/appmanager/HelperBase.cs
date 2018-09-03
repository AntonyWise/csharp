using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    public class HelperBase
    {
        protected IWebDriver driver; // поле доступно в классах - наследниках т.к protected

        public HelperBase(IWebDriver driver)
        {
            this.driver = driver;
        }

    }
}