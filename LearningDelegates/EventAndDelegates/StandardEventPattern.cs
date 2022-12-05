using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LearningDelegates.EventAndDelegates
{


        //    For reusability, the EventArgs subclass is named according to the information it
        //contains(rather than the event for which it will be used). It typically exposes data as
        //properties or as read-only fields

        //    With an EventArgs subclass in place, the next step is to choose or define a delegate
        //for the event. There are three rules:
        //• It must have a void return type.
        //• It must accept two arguments: the first of type object, and the second a sub‐
        //class of EventArgs.The first argument indicates the event broadcaster, and the
        //second argument contains the extra information to convey.
        //• Its name must end with EventHandler.


        //Finally, the pattern requires that you write a protected virtual method that fires the
        //event. The name must match the name of the event, prefixed with the word On, and
        //then accept a single EventArgs argument
    internal class StandardEventPattern
    {



        public class PriceChangedEventArgs : EventArgs
        {
            public readonly decimal LastPrice;
            public readonly decimal NewPrice;
            public PriceChangedEventArgs(decimal lastPrice, decimal newPrice)
            {
                LastPrice = lastPrice; 
                NewPrice = newPrice;
            }
        }
        public class Stock
        {
            string symbol;
            decimal price;

            public Stock(string symbol) { 

                this.symbol = symbol;
            }


            //we  define an event of the chosen delegate type. Here, we use the
            //generic EventHandler delegate:


            public event EventHandler<PriceChangedEventArgs> PriceChanged;


            //Finally, the pattern requires that you write a protected virtual method that fires the
            //event. The name must match the name of the event, prefixed with the word On, and
            //then accept a single EventArgs argument:

            protected virtual void OnPriceChanged(PriceChangedEventArgs e)
            {
                PriceChanged?.Invoke(this, e); //if priceChanged (Event handler delegate under the scene)is null, invoke else do nothing
            }
            public decimal Price
            {
                get { return price; }
                set
                {
                    if (price == value) return;
                    decimal oldPrice = price;
                    price = value;
                    OnPriceChanged(new PriceChangedEventArgs(oldPrice, price));
                }



            }
        }
        public class TestMe
        {
            public static void Run()
            {
                Stock stock = new Stock("THPW");
                stock.Price = 27.10M;
                // Register with the PriceChanged event
                stock.PriceChanged += stock_PriceChanged;
                stock.Price = 31.59M;
            }
            static void stock_PriceChanged(object sender, PriceChangedEventArgs e)
            {
                if ((e.NewPrice - e.LastPrice) / e.LastPrice > 0.1M)
                    Console.WriteLine("Alert, 10% stock price increase!");
            }
        }


    }
}
