using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedingUpTests.Decorator
{
    public class WebElement : Element
    {
        private readonly IWebDriver _webDriver;
        private readonly IWebElement _webElement;
        private readonly By _by;

        public WebElement(IWebDriver webDriver, IWebElement webElement, By by)
        {
            _webDriver = webDriver;
            _webElement = webElement;
            _by = by;
        }

        public override By By
        {
            get
            {
                return _by;
            }
            set
            {
            }
        }

        public override string Text
        {
            get
            {
                return _webElement?.Text;
            }
            set
            {
            }
        }
        public override bool? Enabled
        {
            get
            {
                return _webElement?.Enabled;
            }
            set
            {
            }
        }

        public override bool? Displayed
        {
            get
            {
                return _webElement?.Displayed;
            }
            set
            {
            }
        }

        public override void Click()
        {
            WaitToBeClickable(By);
            _webElement?.Click();
        }

        public override string GetAttribute(string attributeName)
        {
            return _webElement?.GetAttribute(attributeName);
        }

        public override void TypeText(string text)
        {
            _webElement?.Clear();
            _webElement?.SendKeys(text);
        }

        private void WaitToBeClickable(By by)
        {
            var webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
            webDriverWait.Until(ExpectedConditions.ElementToBeClickable(by));
        }
    }
}
