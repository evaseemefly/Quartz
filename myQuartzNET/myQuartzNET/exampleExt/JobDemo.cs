﻿using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace myQuartzNET.exampleExt
{
    public class JobDemo:BaseJobDemo
    {
        public override void ForegroundColor()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }
    }
}
