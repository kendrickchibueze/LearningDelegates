using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDelegates.DelegateGenericTypes
{
    internal class DelegateGenericType
    {

        public delegate T Transformer<T>(T arg);

        public class Util
        {
            public static void Transform<T>(T[] values, Transformer<T> t)
            {
                for (int i = 0; i < values.Length; i++)
                    values[i] = t(values[i]);
            }
        }
        public class Test
        {
            public static void Run()
            {
                int[] values = { 1, 2, 3 };
                Util.Transform(values, Square); // Hook in Square
                foreach (int i in values)
                    Console.Write(i + " "); // 1 4 9
            }
            static int Square(int x) => x * x;
        }
    }
}
