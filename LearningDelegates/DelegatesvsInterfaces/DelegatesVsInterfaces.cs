using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LearningDelegates.DelegateGenericTypes.DelegateGenericType;

namespace LearningDelegates.DelegatesvsInterfaces
{
    internal class DelegatesVsInterfaces
    {

        // A  problem that can be solved with a delegate can also be solved with an interface.



        //A delegate design may be a better choice than an interface design if one or more of
        //these conditions are true:
        //• The interface defines only a single method.
        //• Multicast capability is needed.
        //• The subscriber needs to implement the interface multiple times




        //In the ITransformer example, we don’t need to multicast.However, the interface
        //defines only a single method.Furthermore, our subscriber may need to implement
        //ITransformer multiple times, to support different transforms, such as square or
        //cube.With interfaces, we’re forced into writing a separate type per transform, since
        //Test can implement ITransformer only once.This is quite cumbersome:

        public class Util
        {
            public static void TransformAll(int[] values, ITransformer t)
            {
                for (int i = 0; i < values.Length; i++)
                    values[i] = t.Transform(values[i]);
            }

        }

        class Squarer : ITransformer
        {
            public int Transform(int x) => x * x;
        }

        public static void Run()
        {
            int[] values = { 1, 2, 3 };
            Util.TransformAll(values, new Squarer());
            foreach (int i in values)
                Console.WriteLine(i);

        }

    }
}
