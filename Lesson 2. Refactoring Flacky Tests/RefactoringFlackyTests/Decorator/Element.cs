﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringFlackyTests.Decorator
{
    // COMPONENT
    // Implementing decorator pattern for IWebElement so that we can optimize web elements actions.    
    public abstract class Element
    {
        public abstract By By { get; set; }
        public abstract string Text { get; set; }
        public abstract bool? Enabled { get; set; }
        public abstract bool? Displayed { get; set; }
        public abstract void TypeText(string text);
        public abstract void Click();
        public abstract string GetAttribute(string attributeName);
    }
}
