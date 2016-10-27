using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myQuartzNET.exampleDb
{
    public class SimpleExample
    {
        public static IScheduler scheduler = null;

        public static IScheduler GetScheduler()
        {
            if (scheduler != null)
            {
                return scheduler;
            }
            else
            {
                //1.首先创建一个作业调度池 
                var properties = new System.Collections.Specialized.NameValueCollection();
                //存储类型 
                properties["quartz.jobStore.type"] = "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz";

                //表明前缀 
                properties["quartz.jobStore.tablePrefix"] = "QRTZ_";

                //驱动类型 
                properties["quartz.jobStore.driverDelegateType"] = "Quartz.Impl.AdoJobStore.SqlServerDelegate, Quartz";

                //数据源名称 
                properties["quartz.jobStore.dataSource"] = "PMS20160325";
                //连接字符串
                properties["quartz.dataSource.PMS20160325.connectionString"] = "Data Source=ADMIN-PC;Initial Catalog=PMS20160325;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                //sqlserver版本
                properties["quartz.dataSource.PMS20160325.provider"] = "SqlServer-20";
                //最大链接数 
                //properties["quartz.dataSource.myDS.maxConnections"] = "5"; 
                // First we must get a reference to a scheduler 

                ISchedulerFactory sf = new StdSchedulerFactory(properties); IScheduler sched = sf.GetScheduler();
                return sched;
            }
        }

        public void Run()
        {
            

            var scheduler = GetScheduler();
            IJobDetail job = JobBuilder.Create<HelloJob>()
                                       .WithIdentity("testname", "testgroup")
                                       .Build();

            DateTime dt_now = DateTime.Now;

            var trigger = TriggerBuilder.Create()
                .StartAt(dt_now)
                .EndAt(dt_now.AddSeconds(10))
                .Build();

            scheduler.ScheduleJob(job, trigger);

            scheduler.Start();
        }
    }
}
