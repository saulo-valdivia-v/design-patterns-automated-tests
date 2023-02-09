using ObserverTests.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverTests.Observer
{
    public class BrowserConfiguration
    {
        public BrowserConfiguration()
        {
            Browser = Browser.NotSet;
            BrowserBehavior = BrowserBehavior.RestartEveryTime;
        }

        public BrowserConfiguration(Browser browser, BrowserBehavior browserBehavior)
        {
            Browser = browser;
            BrowserBehavior = browserBehavior;
        }

        public Browser Browser { get; set; }
        public BrowserBehavior BrowserBehavior { get; set; }
    }
}
