using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LearningDelegates.DelegateGenericTypes
{


    // This generic delegate can represent any method
    // returning void and taking a single parameter of type T.
    public delegate void MyGenericDelegate<T>(T arg);

    internal class MoreDelegateGenerics
    {


        // Create an instance of MyGenericDelegate<T>
        // with string as the type parameter.
         MyGenericDelegate<string> strTarget = StringTarget;

       // strTarget("Some string data");


        static void StringTarget(string arg)
        {
            Console.WriteLine(
            "arg in uppercase is: {0}", arg.ToUpper());
        }
    }

                    //    you have seen that when you want to use delegates to enable callbacks in 
                    //your applications, you typically follow the steps shown here:
                    //1. Define a custom delegate that matches the format of the method being
                    //pointed to.
                    //2. Create an instance of your custom delegate, passing in a method name as a
                    //constructor argument.
                    //3. Invoke the method indirectly, via a call to Invoke() on the delegate object.



}
