using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TaskConsoleApp
{
    public class Content
    {
        public string Site { get; set; }
        public int Length { get; set; }
    }
    internal class Program
    {   
        static async Task Main(string[] args)
        {
            Console.WriteLine("Main thread" + Thread.CurrentThread.ManagedThreadId);

            List<string> urlList = new List<string>()
            {
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",
                "https://www.n11.com",
                "https://www.haberturk.com",
            };

            List<Task<Content>> taskList= new List<Task<Content>>();
            urlList.ForEach(x =>
            {
                taskList.Add(GetContentAsync(x));
            });

            

           // Console.WriteLine($"{firtData.Result.Site} - {firtData.Result.Length}");

        }
        public static async Task<Content> GetContentAsync(string url)
        {
            Content content = new Content();
            var data = await new HttpClient().GetStringAsync(url);

            content.Site = url;
            content.Length = data.Length;
            Console.WriteLine("GetContentAsync thread" + Thread.CurrentThread.ManagedThreadId);

            return content; 
        }
    }
     
}
