using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;


namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient cu;
            TcpClient sq;
            var localEndp = new IPEndPoint(IPAddress.Loopback, 9898);
            TcpListener listener = new TcpListener(localEndp);
            listener.Start();

            Console.WriteLine("Server gestartet");
            while (true)
            {
                using (sq = listener.AcceptTcpClient())
                {
                    using (cu = listener.AcceptTcpClient())
                        Send_Rec(cu, sq);
                }
            }
        }

        private static void Send_Rec(TcpClient send, TcpClient rec)
        {
            string msg;
            using (var reader = new StreamReader(rec.GetStream(), Encoding.ASCII, true, 4000, leaveOpen: true))
            {
                msg = reader.ReadLine();
            }
            using (var writer = new StreamWriter(send.GetStream(), Encoding.ASCII, 4000, leaveOpen: true))
            {
                writer.WriteLine(msg);
            }
            Send_Rec(rec, send);
        }
    }
    }
}
