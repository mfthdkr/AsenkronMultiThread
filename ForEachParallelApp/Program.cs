using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ForEachParallelApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string picturePath = @"C:\Users\MUHAMMET FATİH DİKER\Desktop\Pictures";

            var files = Directory.GetFiles(picturePath);

            Parallel.ForEach(files, (item) =>
            {
                Console.WriteLine("thread no: " + Thread.CurrentThread.ManagedThreadId);
                Image img = new Bitmap(item);
                var thumbnail = img.GetThumbnailImage(50, 50, () => false, IntPtr.Zero);

                thumbnail.Save(Path.Combine(picturePath,"thumbnail",Path.GetFileName(item)));

            });

            Console.WriteLine("işlem bitti");
        }
    }
}
