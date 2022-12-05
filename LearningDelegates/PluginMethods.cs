using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LearningDelegates
{


    //    A delegate variable is assigned a method at runtime.This is useful for writing plugin methods.In this example, we have a utility method named Transform that
    //applies a transform to each element in an integer array.The Transform method has
    //a delegate parameter, for specifying a plug-in transform.

    public delegate int Transformers(int x);
    internal class PluginMethods
    {


        //plugin methods
        public static void Transform(int[] values, Transformers t)
        {
            for(int i = 0; i < values.Length; i++)
            {
                values[i] = t(values[i]);

            }
        }

        public static void Run()
        {
           int[] values = {1, 2, 3 };

            PluginMethods.Transform(values, Square);
            foreach(int i in values)
                Console.WriteLine(i + " ");
        }

        private static int Square(int x) => x * x;

        //Our Transform method is a higher-order function, because it’s a function that takes
        //a function as an argument. (A method that returns a delegate would also be a
        //higher-order function.)



    }
}
