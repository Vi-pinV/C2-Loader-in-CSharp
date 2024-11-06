using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace socket_server
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            /*Console.WriteLine(IPAddress.Any);
            Console.ReadKey();*/
            IPEndPoint ipe = new IPEndPoint(IPAddress.Any, 1234);
            Socket server_socket = new Socket(IPAddress.Any.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            server_socket.Bind(ipe);
            server_socket.Listen(50);

            Socket client_socket = server_socket.Accept();
            Console.WriteLine("[+] Connection from : {0}",client_socket.RemoteEndPoint);

            Console.WriteLine("Enter message to send:");
            string msg;
            msg= Console.ReadLine();
            client_socket.Send(Encoding.ASCII.GetBytes(msg));
            while (msg !="quit")
            {
                
                byte[] sb = new byte[2048];
                Array.Clear(sb, 0, sb.Length);
                client_socket.Receive(sb);

                Console.WriteLine(Encoding.ASCII.GetString(sb).TrimEnd('\0'));

                Console.WriteLine("Enter message to send:");
                msg = Console.ReadLine();
                client_socket.Send(Encoding.ASCII.GetBytes(msg));
            }
            client_socket.Close();
            server_socket.Close();
            // Console.ReadKey();
        }
    }
}
