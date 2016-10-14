using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace myQuartzNET.example3
{
    public class DumbJobExt:IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            JobKey key = context.JobDetail.Key;

            JobDataMap dataMap = context.MergedJobDataMap;

            string jobSays = dataMap.GetString("jobSays");

            float myFloatValue = dataMap.GetFloat("myFloatValue");

            IList<DateTimeOffset> state = (IList<DateTimeOffset>)dataMap["myStateData"];

            state.Add(DateTimeOffset.UtcNow);

            Console.Error.WriteLine("Instance" + key + "of DumbJob says:" + jobSays + ", and val is:" + myFloatValue);
        }
        
    }
}
