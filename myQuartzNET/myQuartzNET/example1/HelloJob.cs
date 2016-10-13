using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using Quartz;

namespace myQuartzNET.example1
{
    public class HelloJob:IJob
    {
        private static ILog _log = LogManager.GetLogger(typeof(HelloJob));

        public HelloJob()
        {
        }

        public virtual void Execute(IJobExecutionContext context)
        {

            // Say Hello to the World and display the date/time
            _log.Info(string.Format("Hello World! - {0}", System.DateTime.Now.ToString("r")));
        }
    }
}
