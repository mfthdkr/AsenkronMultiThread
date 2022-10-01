﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TaskConsoleApp
{
    internal class Program
    {

        static async Task Main(string[] args)
        {
            Console.WriteLine(GetData());
        }

        public static string GetData()
        {
            var task = new HttpClient().GetStringAsync("https://www.google.com");
            return task.Result;
        }
    }
     
}
