using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDelegates.DelegateGenericTypes
{


    // But in this case, while creating the instance of generic delegates,
    // instead of the methods, we are using lambda expressions and
    // when we invoke the delegate, the respective lambda expression is going to be executed.
    internal class GenericDelegatesWithLamdaExpressions
    {

        public static bool CheckLength(string name)
        {
            if (name.Length > 5)
                return true;
            return false;
        }



        public static void Run()
        {
            Func<int, float, double, double> obj1 = (x, y, z) =>
            {
                return x + y + z;
            };

            double Result = obj1.Invoke(100, 125.45f, 456.789);

            Console.WriteLine(Result);

            Action<int, float, double> obj2 = (x, y, z) =>
            {
                Console.WriteLine(x + y + z);
            };

            obj2.Invoke(50, 255.45f, 123.456);

            Predicate<string> obj3 = new Predicate<string>(CheckLength);

            bool Status = obj3.Invoke("Pranaya");

            Console.WriteLine(Status);

            Console.ReadKey();
        }
    }
}
