using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LearningDelegates.EventAndDelegates.MoreEventDelegateExample;

namespace LearningDelegates.EventAndDelegates
{


    //So, what we are going to do is, how we can create our custom EventArgs class and how we can use that custom EventArgs class in our delegate and events to pass data
    //To use the custom EventArgs class, the delegate signature must reference the class in its signature.
    //So, the first parameter is the sender of the event and the second parameter is our custom EventArgs
    internal class WorkPerformedEventArgs:EventArgs
    {
        public int Hours { get; set; }
        public WorkType WorkType { get; set; }
    }



    //The.NET Framework includes a generic EventHandler<T> class, that can be used instead of
    //a custom delegate where T represents the EventArgs.So, instead of using our own 
    //delegate WorkPerformedHandler while creating the event, 
    //we can directly use the generic EventHandler<T> delegate





    //Step1: Define one delegate
    //Custom Delegate
    //public delegate void WorkPerformedHandler(object sender, WorkPerformedEventArgs)    //this custom delegates is no longer needed






    //We have already discussed that the delegate method signature and event handler method signature should
    //and must be the same otherwise the event handler method will not get the data from the delegate or pipeline




    //In .NET Framework, we can use the += operator to attach an event with an event handler.

    public class Worker
    {
        //Step2: Define one event to notify the work progress using the custom delegate
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;       //generic EventHandler<T> delegate
        //Step2: Define another event to notify when the work is completed using buil-in EventHandler delegate
        public event EventHandler WorkCompleted;
        public void DoWork(int hours, WorkType workType)
        {
            //Do Work here and notify the consumer that work has been performed
            for (int i = 0; i < hours; i++)
            {
                OnWorkPerformed(i+1, workType);
                Thread.Sleep(3000);
            }
            //Notify the consumer that work has been completed
            OnWorkCompleted();
        }
        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            //Raising Events only if Listeners are attached
            //Approach1
            if (WorkPerformed != null)
            {
                WorkPerformedEventArgs e = new WorkPerformedEventArgs()
                {
                    Hours = hours,
                    WorkType = workType
                };
                WorkPerformed(this, e);
            }
            //Approach2
            //EventHandler<WorkPerformedEventArgs> del1 = WorkPerformed as EventHandler<WorkPerformedEventArgs;
            //if (del1 != null)
            //{
            //    WorkPerformedEventArgs e = new WorkPerformedEventArgs()
            //    {
            //        Hours = hours,
            //        WorkType = workType
            //    };
            //    del1(this, e);
            //}
            //Approach3
            //if (WorkPerformed is EventHandler<WorkPerformedEventArgs> del2)
            //{
            //    WorkPerformedEventArgs e = new WorkPerformedEventArgs()
            //    {
            //        Hours = hours,
            //        WorkType = workType
            //    };
            //    del2(this, e);
            //}
        }
        protected virtual void OnWorkCompleted()
        {
            //Raising the Event
            //Approach1
            //EventHandler delegate takes two parameters i.e. object sender, EventArgs e
            //Sender is the current class i.e. this keyword and we do not need to pass any data


            //So, we need to pass Empty EventArgs
            //WorkCompleted?.Invoke(this, EventArgs.Empty);


            //Approach2
            if (WorkCompleted is EventHandler del)
            {
                del(this, EventArgs.Empty);
            }
            //Note: You can also use other two Approaches
        }

        //Event Handler Method or Event Listener Method
        static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine($"Worker work {e.Hours} Hours compelted for {e.WorkType}");
        }
        //Event Handler Method or Event Listener Method
        static void Worker_WorkCompleted(object sender, EventArgs e)
        {
            Console.WriteLine($"Worker Work Completed");
        }

        public static void Run()
        {
            Worker worker = new Worker();

            //Attaching Worker_WorkPerformed with WorkPerformed Event

            worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(Worker_WorkPerformed);

            //Attaching Worker_WorkCompleted with WorkCompleted Event

            worker.WorkCompleted +=  new EventHandler(Worker_WorkCompleted);

            worker.DoWork(4, WorkType.GenerateReports);

            Console.ReadKey();
        }


        public static void RunWithAnonymousMethods()
        {
            //Worker worker = new Worker();
            ////Attaching Worker_WorkPerformed with WorkPerformed Event
            //worker.WorkPerformed += delegate (object sender, WorkPerformedEventArgs e)
            //{
            //    Console.WriteLine($"Worker work {e.Hours} Hours compelted for {e.WorkType}");
            //};
            ////Attaching Worker_WorkCompleted with WorkCompleted Event
            //worker.WorkCompleted += delegate (object sender, EventArgs e)
            //{
            //    Console.WriteLine($"Worker Work Completed");
            //};
            //worker.DoWork(4, WorkType.GenerateReports);
            //Console.ReadKey();

        }

    
    }
    public enum WorkType
    {
        Golf,
        GotoMeetings,
        GenerateReports
    }
}
