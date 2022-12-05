using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LearningDelegates.MulticastDelegates
{


    //All delegate instances have multicast capability. This means that a delegate instance
    //can reference not just a single target method, but also a list of target methods.The +
    //and += operators combine delegate instances.
    //Delegates are immutable, so when you call += or -=, you’re in
    //fact creating a new delegate instance and assigning it to the
    //existing variable


    public delegate int ProgressReporter(int PercentageComplete);
    internal class multicastdelegates
    {

        public static void Hardwork(ProgressReporter p)
        {
            for (int i = 0; i < 10; i++)
            {
                p(i * 10); //invoking a delegate

                Thread.Sleep(100); //simulate hardwork


            }




        }
        // The Run method creates a multicast delegate instance p, such
        //that progress is monitored by two independent methods
        public static void Run()
        {
            ProgressReporter p = WriteProgressToConsole;
            p += WriteProgressToFile;
            Hardwork(p);
        }

        static int WriteProgressToConsole(int percentComplete)
        {
            return percentComplete;
        }

        static int WriteProgressToFile(int percentComplete)
        {
            return percentComplete;

        }
    }
}
