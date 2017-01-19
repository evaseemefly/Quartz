using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using System.Threading;

namespace myQuartzNET.exampleExt
{
    public abstract class BaseJobDemo:IJob
    {
        static int index = 0;
        /// <summary>
        /// 作业调度每次定时执行的方法
        /// </summary>
        /// <param name="context"></param>

        public void Execute(IJobExecutionContext context)
        {
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            var msg = dataMap.GetString("msg");
            var secs = dataMap.GetInt("secs");
            ForegroundColor();
            Console.WriteLine("作业名" + msg + "开始休眠，" + secs + "ms后唤醒Zzzz...");
            Thread.Sleep(secs);
            Console.WriteLine("作业名" + msg + "||时间:" + DateTime.Now.ToString("r")+"计数"+index++);
        }

        public abstract void ForegroundColor();
    }
}
