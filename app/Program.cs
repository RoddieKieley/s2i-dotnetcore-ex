﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.AspNetCore;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Logging;
using System.Threading;

namespace app
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //BuildWebHost(args).Run();
            while (true)
            {
                Console.WriteLine("Hello OpenShift World!");
                Thread.Sleep(10000);
            }
        }

        //public static IWebHost BuildWebHost(string[] args) =>
            //WebHost.CreateDefaultBuilder(args)
                //.UseStartup<Startup>()
                //.Build();
    }
}
