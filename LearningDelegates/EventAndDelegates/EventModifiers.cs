using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDelegates.EventAndDelegates
{
    internal class EventModifiers
    {

            // Event Modifiers
            //Like methods, events can be virtual, overridden, abstract, or sealed. Events can also
            //be static:
public class Foo
        {
            public static event EventHandler<EventArgs> StaticEvent;
            public virtual event EventHandler<EventArgs> VirtualEvent;
        }

    }
}
