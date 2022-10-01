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

        static async Task Main(string[] args)
        {
            Task myTask = Task.Run(() =>
            {
                throw new ArgumentException("Bir hata meydana geldi");
            });

            await myTask;

            Console.WriteLine("myTask bitti");
        }
        
    }

}
