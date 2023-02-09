using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ObserverTests.Observer
{
    public class MsTestExecutionSubject : ITestExecutionSubject
    {
        private readonly List<ITestBehaviorObserver> _testBehaviorObservers;

        public MsTestExecutionSubject()
        {
            _testBehaviorObservers = new List<ITestBehaviorObserver>();
        }

        public void Attach(ITestBehaviorObserver observer)
        {
            _testBehaviorObservers.Add(observer);
        }

        public void Detach(ITestBehaviorObserver observer)
        {
            _testBehaviorObservers.Remove(observer);
        }

        public void PostTestCleanup(TestContext context, MemberInfo memberinfo)
        {
            foreach (var currentObserver in _testBehaviorObservers)
            {
                currentObserver.PostTestCleanup(context, memberinfo);
            }
        }

        public void PostTestInit(TestContext context, MemberInfo memberinfo)
        {
            foreach (var currentObserver in _testBehaviorObservers)
            {
                currentObserver.PostTestInit(context, memberinfo);
            }
        }

        public void PreTestCleanup(TestContext context, MemberInfo memberinfo)
        {
            foreach (var currentObserver in _testBehaviorObservers)
            {
                currentObserver.PreTestCleanup(context, memberinfo);
            }
        }

        public void PreTestInit(TestContext context, MemberInfo memberinfo)
        {
            foreach (var currentObserver in _testBehaviorObservers)
            {
                currentObserver.PreTestInit(context, memberinfo);
            }
        }

        public void TestInstantiated(MemberInfo memberinfo)
        {
            foreach (var currentObserver in _testBehaviorObservers)
            {
                currentObserver.TestInstantiated(memberinfo);
            }
        }
    }
}
