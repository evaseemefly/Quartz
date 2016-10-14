using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myQuartzNET.example4
{
    public class HelloJob:IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Hello Job is Execute,this time is{0}",DateTime.Now.ToShortTimeString());
        }
    }
}
