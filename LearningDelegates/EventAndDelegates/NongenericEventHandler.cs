using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDelegates.EventAndDelegates
{
    internal class NongenericEventHandler
    {


        //        The predefined nongeneric EventHandler delegate can be used when an event
        //doesn’t carry extra information. In this example, we rewrite Stock such that the Pri
        //ceChanged event is fired after the price changes, and no information about the event
        //is necessary, other than it happened. We also make use of the EventArgs.Empty
        //property, in order to avoid unnecessarily instantiating an instance of EventArgs.
        public class Stock
        {
            string symbol;

            decimal price;
            public Stock(string symbol) { 

                this.symbol = symbol; 
            }


            public event EventHandler PriceChanged;
            protected virtual void OnPriceChanged(EventArgs e)
            {
                PriceChanged?.Invoke(this, e);
            }
            public decimal Price
            {
                get { return price; }
                set
                {
                    if (price == value) return;
                    price = value;
                    OnPriceChanged(EventArgs.Empty);
                }
            }
        }
    }
}
