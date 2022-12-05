using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDelegates.EventAndDelegates
{
//            Events
//        When using delegates, two emergent roles commonly appear: broadcaster and sub‐
//        scriber.
//        The broadcaster is a type that contains a delegate field.The broadcaster decides
//        when to broadcast, by invoking the delegate.
//        The subscribers are the method target recipients.A subscriber decides when to start
//        and stop listening, by calling += and -= on the broadcaster’s delegate. A subscriber
//        does not know about, or interfere with, other subscribers.
//        Events are a language feature that formalizes this pattern.An event is a construct
//        that exposes just the subset of delegate features required for the broadcaster/
//        subscriber model. The main purpose of events is to prevent subscribers from inter‐
//        fering with one another
    internal class EventDelegates
    {


        public delegate void PriceChangedHandler(decimal oldPrice, decimal newPrice);
        public class Stock
        {
            string symbol;
            decimal price;

            public Stock(string symbol) { 
                this.symbol = symbol; 
            }


            public event PriceChangedHandler PriceChanged;


            public decimal Price
            {
                get { return price; }
                set
                {
                    if (price == value) return; // Exit if nothing has changed
                    decimal oldPrice = price;
                    price = value;

                    if (PriceChanged != null) // If invocation list not
                        PriceChanged(oldPrice, price); // empty, fire event.
                }
            }
        }
    }
}

