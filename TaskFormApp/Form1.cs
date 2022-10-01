using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskFormApp
{
    public partial class Form1 : Form
    {
        public  int Counter { get; set; } = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private  void btnReadFile_Click(object sender, EventArgs e)
        {   
            
            var myTask = new HttpClient().GetStringAsync("https://www.sahibinden.com");

            string data = myTask.Result;

        }

        private void btnCounter_Click(object sender, EventArgs e)
        {
            textBoxCounter.Text = Counter++.ToString();
        }

        // senkron
        private string ReadFile()
        {
            string data = string.Empty;
            using (StreamReader sr = new StreamReader("dosya.txt"))
            {   
                // thread yavaşlatmak için  
                Thread.Sleep(5000); // ana thread'i blokladık.
                data = sr.ReadToEnd();
            }
            return data;

        }

        private async Task<string> ReadFileAsync()
        {
            string data = string.Empty;
            using (StreamReader sr = new StreamReader("dosya.txt"))
            {
                Task<string> myTask =  sr.ReadToEndAsync();

                 // bu arada başka işlemler yapılabilir.
                await Task.Delay(5000);
                // 5 sn. boyunca bekle aşağı satıra inme

                data = await myTask;

                return data;
            }
        }
        // async ve await kullanmadan
        private Task<string> ReadFileAsync2()
        {
            StreamReader sr = new StreamReader("dosya.txt");
            
                return sr.ReadToEndAsync();
            
        }

    }
}
