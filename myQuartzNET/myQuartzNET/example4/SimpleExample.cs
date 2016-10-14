using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl.Calendar;
using Quartz.Impl;

namespace myQuartzNET.example4
{
    class SimpleExample
    {
        public void Run()
        {
            //构造调度工厂
            ISchedulerFactory schedFact = new StdSchedulerFactory();

            // get a scheduler
            //获取一个调度
            IScheduler sched = schedFact.GetScheduler();

            HolidayCalendar cal = new HolidayCalendar();

            //1 定义一个job实例
            IJobDetail job = JobBuilder.Create<HelloJob>()
                .WithIdentity("myJob", "group1")
                .Build();

            DateTime dt_target = DateTime.Now.AddSeconds(5);
            cal.AddExcludedDate(dt_target);

            sched.AddCalendar("myHolidays", cal,false,false);

            //3 定义一个触发器
            ITrigger t = TriggerBuilder.Create()
                                     .WithIdentity("myJobTrigger")
                                     .ForJob("myJob", "group1") //注意此处在创建IJobDetail时若定义了jobName与jobGroup此处也需要这两个参数
                                     .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(dt_target.AddMinutes(1).Hour, dt_target.AddMinutes(1).Minute))
                                     .Build();

            sched.ScheduleJob(job, t);

            sched.Start();


        }
    }
}
