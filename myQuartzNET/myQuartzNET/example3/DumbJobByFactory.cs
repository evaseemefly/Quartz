using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace myQuartzNET.example3
{
    class DumbJobByFactory : IJob
    {
        public string JobSays { private get; set; }

        public float FloatValue { private get; set; }

        public void Execute(IJobExecutionContext context)
        {
            JobKey key = context.JobDetail.Key;

            JobDataMap dataMap = context.MergedJobDataMap;

            IList<DateTimeOffset> state = (IList<DateTimeOffset>)dataMap["myStateData"];

            state.Add(DateTimeOffset.UtcNow);

            Console.Error.WriteLine("Instance" + key + "of DumbJob says:" + JobSays + ", and val is:" + FloatValue);
        }
    }
}
