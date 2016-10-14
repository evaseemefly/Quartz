using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace myQuartzNET.example3
{
    class SimpleExample
    {
        public void Run()
        {
            JobDataMap dataMap = new JobDataMap();
            dataMap.Add("name", "smssystem");

            //1 定义一个job实例
            IJobDetail job = JobBuilder.Create<HelloJob>()
                                     .SetJobData(dataMap)
                                     .WithIdentity("myJob", "group1")
                                     .Build();

            //2 创建计时器
            ITrigger trigger = TriggerBuilder.Create()
                                             .WithIdentity("myJobTrigger", "group1")
                                             .StartNow()
                                             .WithSimpleSchedule(x => x.WithIntervalInSeconds(40)
                                             .RepeatForever())
                                             .Build();



        }
    }
}
