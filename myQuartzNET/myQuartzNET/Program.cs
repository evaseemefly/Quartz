using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace myQuartzNET
{
    class Program
    {
        static void Main(string[] args)
        {
            // Grab the Scheduler instance from the Factory 
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();

            // and start it off
            scheduler.Start();

            // some sleep to show what's happening
            Thread.Sleep(TimeSpan.FromSeconds(60));

            // and last shut down the scheduler when you are ready to close your program
            scheduler.Shutdown();
        }

        public void QuartzTest1()
        {
            
            //ISchedulerFactory schedFact = new StdSchedulerFactory();

            
            //IScheduler sched = schedFact.GetScheduler();
            //sched.Start();

            //IJobDetail job=JobBuilder.Create<HelloJob>()
        }
    }
}
