using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TaskConsoleApp
{
    internal class Program
    {
        public static void Calis(Task<string> data)
        {   
            // 100 satırlık kod
            Console.WriteLine("data uzunluk : " + data.Result.Length);
        }
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var myTask= new HttpClient().GetStringAsync("https://google.com").ContinueWith(Calis);


            Console.WriteLine("Arada yapılacak işlemeler");
            await myTask;
            

        }
    }
}
