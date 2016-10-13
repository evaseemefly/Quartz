using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace myQuartzNET.exampleExt
{
    public class JobDemo:IJob
    {
        /// <summary>
        /// 作业调度每次定时执行的方法
        /// </summary>
        /// <param name="context"></param>

        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine(DateTime.Now.ToString("r"));
        }
    }
}
