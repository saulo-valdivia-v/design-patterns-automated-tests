using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ObserverTests.Observer
{
    public class BaseTestBehaviorObserver : ITestBehaviorObserver
    {
        private readonly ITestExecutionSubject _testExecutionSubject;

        public BaseTestBehaviorObserver(ITestExecutionSubject testExecutionSubject)
        {
            _testExecutionSubject = testExecutionSubject;
            testExecutionSubject.Attach(this);
        }

        public virtual void PostTestCleanup(TestContext context, MemberInfo memberinfo)
        {
        }

        public virtual void PostTestInit(TestContext context, MemberInfo memberinfo)
        {
        }

        public virtual void PreTestCleanup(TestContext context, MemberInfo memberinfo)
        {
        }

        public virtual void PreTestInit(TestContext context, MemberInfo memberinfo)
        {
        }

        public virtual void TestInstantiated(MemberInfo memberinfo)
        {
        }
    }
}
