using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myQuartzNET.exampleExt
{
    public class JobDemo2:BaseJobDemo
    {
        public override void ForegroundColor()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }
    }
}
