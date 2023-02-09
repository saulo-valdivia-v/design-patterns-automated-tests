using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ObserverTests.Decorator
{
    public abstract class Driver
    {
        public abstract void Start(Browser browser);
        public abstract void Quit();
        public abstract void GoToURL(string url);
        public abstract Element FindElement(By locator);
        public abstract List<Element> FindElements(By locator);
        public abstract void WaitForAjax();
        public abstract void WaitUntilPageLoadsCompletely();
        public abstract void DeleteAllCookies();
    }

    public enum Browser
    {
        NotSet,
        Chrome,
        Firefox,
        Edge,
        Opera,
        Safari,
        InternetExplorer
    }

    public enum BrowserBehavior
    {
        NotSet = 0,
        ReuseIfStarted = 1,
        RestartEveryTime = 2,
        RestartOnFail = 3,
    }
}
