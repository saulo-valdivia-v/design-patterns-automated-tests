using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ObserverTests.Observer
{
    public interface ITestExecutionSubject
    {
        void Attach(ITestBehaviorObserver observer);
        void Detach(ITestBehaviorObserver observer);
        void PreTestInit(TestContext context, MemberInfo memberinfo);
        void PostTestInit(TestContext context, MemberInfo memberinfo);
        void PreTestCleanup(TestContext context, MemberInfo memberinfo);
        void PostTestCleanup(TestContext context, MemberInfo memberinfo);
        void TestInstantiated(MemberInfo memberinfo);
    }
}
