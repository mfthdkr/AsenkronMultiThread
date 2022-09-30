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

        private async void btnReadFile_Click(object sender, EventArgs e)
        {
            #region AwaitHemenKullandık
            //string data = await ReadFileAsync();

            //// burada işlem 15 sn sürse de alt satıra geçmez ama ana thread'i de bloklamaz.

            //richTextBox1.Text = data;
            #endregion

            #region AwaitSonraKullanıpAradaBaskaIslemYaptık
            // asenkron metodların await diyerek sonucu hemen alabilirim yada  arada yapmak istediğimiz işlemler varsa await yapmak istediğimiz işlemden sonra kullanırız.

            //string data = String.Empty;
            //// await kullanmak istemediğimiz için sonucu stringe çekiyoruz.
            //Task<string> reading = ReadFileAsync();
            //// alt satıra geçer, arada başka işlemle yapar.

            //richTextBox2.Text = await new HttpClient().GetStringAsync("https://www.google.com");

            //data = await reading;

            //richTextBox1.Text = data;



            #endregion

            #region AwaitVeAsyncKullanmadık
            // ReadFileAsync2 için
            string data = String.Empty;
            
            Task<string> reading = ReadFileAsync2();
            

            richTextBox2.Text = await new HttpClient().GetStringAsync("https://www.google.com");

            data = await reading;

            richTextBox1.Text = data;

            #endregion


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
