using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V107.Browser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringFlackyTests.Decorator
{
    public abstract class Driver
    {
        public abstract void Start(Browser browser);
        public abstract void Quit();
        public abstract void GoToURL(string url);
        public abstract Element FindElement(By locator);
        public abstract List<Element> FindElements(By locator);
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
}
