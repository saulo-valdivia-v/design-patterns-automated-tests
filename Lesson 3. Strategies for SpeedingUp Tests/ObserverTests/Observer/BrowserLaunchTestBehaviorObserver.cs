using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using ObserverTests.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ObserverTests.Observer
{
    public class BrowserLaunchTestBehaviorObserver : BaseTestBehaviorObserver
    {
        private readonly Driver _driver;
        private BrowserConfiguration _currentBrowserConfiguration;
        private BrowserConfiguration _previousBrowserConfiguration;

        public BrowserLaunchTestBehaviorObserver(ITestExecutionSubject testExecutionSubject, Driver driver)
            : base(testExecutionSubject)
        {
            _driver = driver;
        }

        public override void PreTestInit(TestContext context, MemberInfo memberInfo)
        {
            _currentBrowserConfiguration = GetBrowserConfiguration(memberInfo);

            bool shouldRestartBrowser = ShouldRestartBrowser(_currentBrowserConfiguration);

            if (shouldRestartBrowser)
            {
                RestartBrowser();
            }
            else
            {
                _driver.DeleteAllCookies();
            }

            _previousBrowserConfiguration = _currentBrowserConfiguration;
        }

        private void RestartBrowser()
        {
            _driver.Quit();
            _driver.Start(_currentBrowserConfiguration.Browser);
        }

        public override void PostTestCleanup(TestContext context, MemberInfo memberInfo)
        {
            if (_currentBrowserConfiguration.BrowserBehavior == BrowserBehavior.RestartOnFail && context.CurrentTestOutcome.Equals(TestOutcome.Failed))
            {
                RestartBrowser();
            }
            else
            {
                _driver.DeleteAllCookies();
            }
        }

        private bool ShouldRestartBrowser(BrowserConfiguration browserConfiguration)
        {
            if (_previousBrowserConfiguration == null)
            {
                return true;
            }

            bool shouldRestartBrowser =
                browserConfiguration.BrowserBehavior == BrowserBehavior.RestartEveryTime || browserConfiguration.Browser == Browser.NotSet;

            return shouldRestartBrowser;
        }

        private BrowserConfiguration GetBrowserConfiguration(MemberInfo memberInfo)
        {
            var result = new BrowserConfiguration();
            var classBrowserType = GetExecutionBrowserClassLevel(memberInfo.DeclaringType);
            var methodBrowserType = GetExecutionBrowserMethodLevel(memberInfo);
            if (methodBrowserType != null)
            {
                result = methodBrowserType;
            }
            else if (classBrowserType != null)
            {
                result = classBrowserType;
            }

            return result;
        }

        private BrowserConfiguration GetExecutionBrowserMethodLevel(MemberInfo memberInfo)
        {
            var executionBrowserAttribute = memberInfo.GetCustomAttribute<ExecutionBrowserAttribute>(true);
            return executionBrowserAttribute?.BrowserConfiguration;
        }

        private BrowserConfiguration GetExecutionBrowserClassLevel(Type type)
        {
            var executionBrowserAttribute = type.GetCustomAttribute<ExecutionBrowserAttribute>(true);
            return executionBrowserAttribute?.BrowserConfiguration;
        }
    }
}
