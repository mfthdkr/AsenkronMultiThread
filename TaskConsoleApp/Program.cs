using System;
using System.Collections.Generic;
using System.Globalization;
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
            Console.WriteLine("1.adım");
            var myTask = GetContent();

            Console.WriteLine("2.adım");

            var content = await myTask;

            Console.WriteLine("3.adım:" + content.Length);
        }

        public static async Task<string> GetContent()
        {
            var content = await new HttpClient().GetStringAsync("https://www.google.com");

            return content;
        }

    }

}
