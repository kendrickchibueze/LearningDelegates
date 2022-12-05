using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDelegates
{

    public delegate int Transformer(int x);
    internal class UseTransformer
    {


        static int Square(int x ) {
            return x * x;
        }












        public static void Run()
        {
            Transformer t = Square;
            int result = t(3);
            Console.WriteLine(result);

        }
    }

  
}
