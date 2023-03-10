using ObserverTests.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverTests.Observer
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class ExecutionBrowserAttribute : Attribute
    {
        public ExecutionBrowserAttribute(Browser browser, BrowserBehavior browserBehavior)
        {
            BrowserConfiguration = new BrowserConfiguration(browser, browserBehavior);
        }

        public BrowserConfiguration BrowserConfiguration { get; set; }
    }
}
