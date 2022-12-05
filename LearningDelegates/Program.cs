using LearningDelegates.CarDelegates;
using LearningDelegates.DelegateInvokeCallback;
using LearningDelegates.DelegatesvsInterfaces;
using LearningDelegates.MulticastDelegates;
using static LearningDelegates.DelegateGenericTypes.DelegateGenericType;
using static LearningDelegates.EventAndDelegates.StandardEventPattern;

namespace LearningDelegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello Delegates");
            //UseTransformer.Run();
            //PluginMethods.Run();
            //Test.Run();
            //DelegatesVsInterfaces.Run();

            //TestMe.Run();

            //CarDelegate.Run();
            DelegatesInvokeCallbackfunctions.Run();

            MoreMulticastDelegates.Run();
        }
    }
}