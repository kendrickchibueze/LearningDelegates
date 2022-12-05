using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static LearningDelegates.CarDelegates.CarDelegate;

namespace LearningDelegates.DelegateGenericTypes
{

    //    The generic Action<> delegate is defined in the System namespace, and you can use this generic
    //delegate to “point to” a method that takes up to 16 arguments (that ought to be enough!) and returns void. 
    //Now recall, because Action<> is a generic delegate, you will need to specify the underlying types of each
    //parameter as well.
    internal class ActionAndFuncDelegates
    {
        // This is a target for the Action<> delegate.
        static void DisplayMessage(string msg, ConsoleColor txtColor, int printCount)
        {
            // Set color of console text.
            ConsoleColor previous = Console.ForegroundColor;
            Console.ForegroundColor = txtColor;

            for (int i = 0; i < printCount; i++)
            {
                Console.WriteLine(msg);
            }
            // Restore color.
            Console.ForegroundColor = previous;
        }

        // Target for the Func<> delegate.
        static int Add(int x, int y)
        {
            return x + y;
        }


        static string SumToString(int x, int y)
        {
            return (x + y).ToString();
        }



        public void Run()
        {
            //Now, rather than building a custom delegate manually to pass the program’s flow to the
            //DisplayMessage() method, you can use the out-of - the - box Action <> delegate, as so:


            Console.WriteLine("***** Fun with Action and Func *****");
            // Use the Action<> delegate to point to DisplayMessage.
            Action<string, ConsoleColor, int> actionTarget = DisplayMessage;
            actionTarget("Action Message!", ConsoleColor.Yellow, 5);
            Console.ReadLine();




            //As you can see, using the Action<> delegate saves you the bother of defining a custom delegate type.
            //However, recall that the Action<> delegate type can point only to methods that take a void return value.If
            //you want to point to a method that does have a return value(and don’t want to bother writing the custom
            //delegate yourself), you can use Func<>.
            //The generic Func<> delegate can point to methods that(like Action<>) take up to 16 parameters and a
            //custom return value




            Func<int, int, int> funcTarget = Add;

            int result = funcTarget.Invoke(40, 40);

            Console.WriteLine("40 + 40 = {0}", result);

            Func<int, int, string> funcTarget2 = SumToString;

            string sum = funcTarget2(90, 300);

            Console.WriteLine(sum);
        }
    }
}
