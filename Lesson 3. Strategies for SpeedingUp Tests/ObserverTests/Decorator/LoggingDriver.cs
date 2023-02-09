using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverTests.Decorator
{
    public class LoggingDriver : DriverDecorator
    {
        public LoggingDriver(Driver driver) : base(driver)
        {
        }

        public override Element FindElement(By locator)
        {
            Console.WriteLine("Find Element");
            return Driver?.FindElement(locator);
        }

        public override List<Element> FindElements(By locator)
        {
            Console.WriteLine("Find Elements");
            return Driver?.FindElements(locator);
        }

        public override void GoToURL(string url)
        {
            Console.WriteLine($"Go to URL = {url}");
            Driver?.GoToURL(url);
        }

        public override void Quit()
        {
            Console.WriteLine("Close browser");
            Driver?.Quit();
        }

        public override void Start(Browser browser)
        {
            Console.WriteLine($"Start browser = {Enum.GetName(typeof(Browser), browser)}");
            Driver?.Start(browser);
        }

        public override void WaitForAjax()
        {
            Console.WriteLine("Waiting for AJAX");
            Driver?.WaitForAjax();
        }

        public override void WaitUntilPageLoadsCompletely()
        {
            Console.WriteLine("Waiting for Page Reload");
            Driver?.WaitUntilPageLoadsCompletely();
        }

        public override void DeleteAllCookies()
        {
            Console.WriteLine("Delete Cookies");
            Driver?.DeleteAllCookies();
        }
    }
}
