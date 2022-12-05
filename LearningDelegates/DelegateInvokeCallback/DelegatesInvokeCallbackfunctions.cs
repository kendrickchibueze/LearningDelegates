using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDelegates.DelegateInvokeCallback
{

    //Delegates are used to invoke the call-back functions.What it means is we will invoke one function and we will pass the delegate instance as a 
    //parameter to that function and we expect that function to invoke the delegate at some point of time which will invoke
    // the callback method referred by the delegate instance.

    public delegate void CallbackMethodHandler(string message);
    internal class DelegatesInvokeCallbackfunctions
    {

        public static void DoSomework(CallbackMethodHandler del)
        {
            Console.WriteLine("Processing some Task");
            del("Pranaya");
        }
        public void CallbackMethod(string message)
        {
            Console.WriteLine("CallbackMethod Executed");
            Console.WriteLine($"Hello: {message}, Good Morning");
        }



        public static void Run()
        {
            DelegatesInvokeCallbackfunctions obj = new DelegatesInvokeCallbackfunctions();
            CallbackMethodHandler del1 = new CallbackMethodHandler(obj.CallbackMethod);
            //Here, I am calling the DoSomework function and I want the 
            //DoSomework function to call the delegate at some point of time
            //which will invoke the CallbackMethod method
            DoSomework(del1);
            Console.ReadKey();
        }

        //delegates use cases in c#
        //Event Handlers
        //Callbacks
        //Passing Methods as Method Parameters
        //LINQ
        //Multithreading
    }
}
