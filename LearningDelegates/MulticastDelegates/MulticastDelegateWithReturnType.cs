using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDelegates.MulticastDelegates
{

    public delegate int SampleDelegate();
    internal class MulticastDelegateWithReturnType
    {

        // This method returns one
        public static int MethodOne()
        {
            Console.WriteLine("MethodOne is Executed");
            return 1;
        }
        // This method returns two
        public static int MethodTwo()
        {
            Console.WriteLine("MethodTwo is Executed");
            return 2;
        }


        public static void Run()
        {
            SampleDelegate del = new SampleDelegate(MethodOne);
            del += MethodTwo;

            // The Value Returned By Delegate will be 2, returned by the MethodTwo(),
            // as it is the last method in the invocation list.
            int ValueReturnedByDelegate = del();
            Console.WriteLine($"Returned Value = {ValueReturnedByDelegate}");
            Console.ReadKey();
        }
    }
}
