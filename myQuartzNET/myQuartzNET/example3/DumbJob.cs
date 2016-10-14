using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace myQuartzNET.example3
{
    public class DumbJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            JobKey key = context.JobDetail.Key;

            JobDataMap dataMap = context.JobDetail.JobDataMap;

            string jobSays = dataMap.GetString("jobSays");
            float myFloatValue = dataMap.GetFloat("myFloatValue");

            Console.Error.WriteLine("Instance" + key + "of DumbJob says:" + jobSays + ", and val is:" + myFloatValue);
        }
    }
}
