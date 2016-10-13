using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myQuartzNET.example1
{
    class SimpleExample
    {
        public void Run()
        {
            // construct a scheduler factory
            //构造调度工厂
            ISchedulerFactory schedFact = new StdSchedulerFactory();

            // get a scheduler
            //获取一个调度
            IScheduler sched = schedFact.GetScheduler();
            sched.Start();

            // define the job and tie it to our HelloJob class
            IJobDetail job = JobBuilder.Create<HelloJob>()
                .WithIdentity("myJob", "group1")
                .Build();

            // Trigger the job to run now, and then every 40 seconds
            ITrigger trigger = TriggerBuilder.Create()
              .WithIdentity("myTrigger", "group1")
              .StartNow()
              .WithSimpleSchedule(x => x
                  .WithIntervalInSeconds(40)
                  .RepeatForever())
              .Build();

            sched.ScheduleJob(job, trigger);
        }
    }
}
