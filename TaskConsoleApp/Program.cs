using System;
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
        public static int CacheData { get; set; } = 150;
        static async Task Main(string[] args)
        {
            var myTask = GetData();
            

        }

        public static ValueTask<int> GetData()
        {
            return new ValueTask<int>(CacheData);
        }
    }

}
