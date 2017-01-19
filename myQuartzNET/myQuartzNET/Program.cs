using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using myQuartzNET.exampleExt;

namespace myQuartzNET
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.ToString("r"));

            QuartzTest1();

            //example1.SimpleExample example1 = new myQuartzNET.example1.SimpleExample();
            //example1.Run();

            //exampleDb.SimpleExample example = new exampleDb.SimpleExample();
            //example.Run();
            //example.ResumeJob("testname", "testgroup");


            //example4.SimpleExample example = new example4.SimpleExample();
            //example.Run();

            // Grab the Scheduler instance from the Factory 
            //IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();

            //// and start it off
            //scheduler.Start();

            //// some sleep to show what's happening
            //Thread.Sleep(TimeSpan.FromSeconds(60));

            //// and last shut down the scheduler when you are ready to close your program
            //scheduler.Shutdown();
        }

        static void QuartzTest1()
        {
            //1 创建调度池
            ISchedulerFactory schedFact = new StdSchedulerFactory();
            IScheduler sched = schedFact.GetScheduler();

            //2 创建具体的作业
            IJobDetail job1 = JobBuilder.Create<JobDemo>()
                .UsingJobData("msg", "job1")
                .UsingJobData("secs", 0)
                .Build();

            IJobDetail job2 = JobBuilder.Create<JobDemo3>()
                .UsingJobData("msg","job2")
                .UsingJobData("secs", 3000)
                .Build();

            IJobDetail job3= JobBuilder.Create<JobDemo2>()
                .UsingJobData("msg", "job3")
                .UsingJobData("secs", 500)
                .Build();

            //3 创建并配置一个触发器
            //ISimpleTrigger trigger1 = (ISimpleTrigger)TriggerBuilder.Create()

            //    .WithSimpleSchedule(x => x.WithIntervalInSeconds(1)
            //    .WithRepeatCount(50))
            //    .Build();
            var trigger1 = TriggerBuilder.Create()
                //.WithIdentity("trigger1","test1")                
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(1)
                .WithRepeatCount(4))
                .ForJob(job1)
                .Build();

            var trigger = TriggerBuilder.Create()
                .WithIdentity("trigger3", "group1")
                 // .StartAt(myTimeToStartFiring) 
                 // if a start time is not given (if this line were omitted), "now" is implied
                 .WithSimpleSchedule(x => x
                .WithIntervalInSeconds(1)
                .WithRepeatCount(4)) // note that 10 repeats will give a total of 11 firings
                                     //.ForJob(job1); // identify job with handle to its JobDetail itself 8 .Build();
                .Build();

            ISimpleTrigger trigger2 = (ISimpleTrigger)TriggerBuilder.Create()
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(1)
                .WithRepeatCount(4))
                .Build();

            ISimpleTrigger trigger3 = (ISimpleTrigger)TriggerBuilder.Create()
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(1)
                .WithRepeatCount(4))
                .Build();

            //4 加入作业调度池中
            sched.ScheduleJob(job1, trigger);

            //sched.ScheduleJob(trigger1);

            sched.ScheduleJob(job2, trigger2);

            sched.ScheduleJob(job3, trigger3);

            //通过以上方式可以看出，两个作业，同事工作时并没有冲突

            //5 开始运行
            sched.Start();

            Console.ReadKey();
        }
    }
}
