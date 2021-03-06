﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using _4G;


namespace Server
{
    
    class Program
    {
        
        
        static void Main(string[] args)
        {
            
            TcpClient player;
            TcpClient player2;
            var localEndp = new IPEndPoint(IPAddress.Loopback, 9897);
            TcpListener listener = new TcpListener(localEndp);
            listener.Start();

            Console.WriteLine("Server gestartet");
            player = listener.AcceptTcpClient();
            Console.WriteLine("1st player is Connected");
            player2 = listener.AcceptTcpClient();
            Console.WriteLine("2nd player is Connected");
            Send_Rec(player, player2);
        }

        private static void Send_Rec(TcpClient send, TcpClient rec)
        {
            while (true)
            {
                string msg;
                using (var reader = new StreamReader(rec.GetStream(), Encoding.ASCII, true, 4000, leaveOpen: true))
                {
                    msg = reader.ReadLine();
                }
                Console.WriteLine(msg);
                using (var writer = new StreamWriter(send.GetStream(), Encoding.ASCII, 4000, leaveOpen: true))
                {
                    writer.WriteLine(msg);
                }
                Send_Rec(rec, send);
            }
        }
    }
    
}
