using System.Reflection;

namespace ObserverTests.Observer
{
    public interface ITestBehaviorObserver
    {
        void PreTestInit(TestContext context, MemberInfo memberinfo);
        void PostTestInit(TestContext context, MemberInfo memberinfo);
        void PreTestCleanup(TestContext context, MemberInfo memberinfo);
        void PostTestCleanup(TestContext context, MemberInfo memberinfo);
        void TestInstantiated(MemberInfo memberinfo);
    }
}