using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace LearningDelegates.CarDelegates
{

    // 1.Define a new delegate type that will be used to send notifications to the caller.
    //2. Declare a member variable of this delegate in the Car class.
    //3. Create a helper function on the Car that allows the caller to specify the method to
    //call back on.
    //4. Implement the Accelerate() method to invoke the delegate’s invocation list
    //under the correct circumstances.
    internal class CarDelegate
    {
        //1) Define a delegate type.
        public delegate void CarEngineHandler(string msgForCaller);

        public class Car
        {
            // Internal state data.
            public int CurrentSpeed { get; set; }
            public int MaxSpeed { get; set; } = 100;
            public string PetName { get; set; }

            // Is the car alive or dead?
            private bool _carIsDead;


            // Class constructors.
            public Car() { }
            public Car(string name, int maxSp, int currSp)
            {
                CurrentSpeed = currSp;
                MaxSpeed = maxSp;
                PetName = name;
            }


            // 2) Define a member variable of this delegate.
            private CarEngineHandler _listOfHandlers;


            // 3) Add registration function for the caller.
            public void RegisterWithCarEngine(CarEngineHandler methodToCall)
            {
                _listOfHandlers = methodToCall;
            }

            // 4) Implement the Accelerate() method to invoke the delegate's
            // invocation list under the correct circumstances.
            public void Accelerate(int delta)
            {
                // If this car is "dead," send dead message.
                if (_carIsDead)
                {
                    _listOfHandlers?.Invoke("Sorry, this car is dead...");
                }
                else
                {
                    CurrentSpeed += delta;

                }
              
                // Is this car "almost dead"?
                if (10 == (MaxSpeed - CurrentSpeed))
                {
                    _listOfHandlers?.Invoke("Careful buddy! Gonna blow!");
                }
                if (CurrentSpeed >= MaxSpeed)
                {
                    _carIsDead = true;
                }
                else
                {
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
                }
            }
          

        }
          public static void Run()
            {
                Console.WriteLine("** Delegates as event enablers **\n");
                // First, make a Car object.
                Car c1 = new Car("SlugBug", 100, 10);
                // Now, tell the car which method to call
                // when it wants to send us messages.
                c1.RegisterWithCarEngine(new CarEngineHandler(OnCarEngineEvent));
                // Speed up (this will trigger the events).
                Console.WriteLine("***** Speeding up *****");
                for (int i = 0; i < 6; i++)
                {
                    c1.Accelerate(20);
                }
                Console.ReadLine();
                // This is the target for incoming events.
                static void OnCarEngineEvent(string msg)
                {
                    Console.WriteLine("\n*** Message From Car Object ***");
                    Console.WriteLine("=> {0}", msg);
                    Console.WriteLine("********************\n");
                }
            }

       
    }


}