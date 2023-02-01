using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedingUpTests.Decorator
{
    public abstract class DriverDecorator : Driver
    {
        protected readonly Driver Driver;

        protected DriverDecorator(Driver driver)
        {
            Driver = driver;
        }
        public override Element FindElement(By locator)
        {
            return Driver?.FindElement(locator);
        }

        public override List<Element> FindElements(By locator)
        {
            return Driver?.FindElements(locator);
        }

        public override void GoToURL(string url)
        {
            Driver?.GoToURL(url);
        }

        public override void Quit()
        {
            Driver?.Quit();
        }

        public override void Start(Browser browser)
        {
            Driver?.Start(browser);
        }
    }
}
