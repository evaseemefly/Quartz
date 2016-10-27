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

            //QuartzTest1();

            //example4.SimpleExample example = new example4.SimpleExample();
            //example.Run();


            exampleDb.SimpleExample example = new exampleDb.SimpleExample();
            example.Run();

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
            IJobDetail job = JobBuilder.Create<JobDemo>().Build();

            //3 创建并配置一个触发器
            ISimpleTrigger trigger = (ISimpleTrigger)TriggerBuilder.Create().WithSimpleSchedule(x => x.WithIntervalInSeconds(3).WithRepeatCount(int.MaxValue)).Build();

            //4 加入作业调度池中
            sched.ScheduleJob(job, trigger);

            //5 开始运行
            sched.Start();

            Console.ReadKey();
        }
    }
}
