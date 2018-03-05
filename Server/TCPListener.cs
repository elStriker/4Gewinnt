using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Server
{
    public class TCPListener
    {

        IPAddress _Address;
        IPEndPoint _EndPoint;
        Socket _Socket;

      /*  public void Listen()
        {
            Console.WriteLine("Das spielt beginnt!");
            while (true)
            {
                Socket communicationSocket = null;
                try
                {
                    communicationSocket = _Socket.Accept(); // Prüft ob Verbindung aufgebaut wurde
                }
                catch (SocketException)
                {

                }

                if (communicationSocket.Connected)
                {

                    byte[] buffer1 = new byte[1024];
                    communicationSocket.Receive(buffer1);
                    string command = Encoding.ASCII.GetString(buffer1);
                    TicTacToe ticTacTo = new TicTacToe(command);
                    ThreadStart ts = new ThreadStart(ticTacTo.DoShit);
                    Thread t = new Thread(ts);
                    t.Start();



                }
            }*/
        }

        public TCPListener()
        {
            _Address = IPAddress.Loopback;
            _EndPoint = new IPEndPoint(_Address, 4200);
            _Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _Socket.Bind(_EndPoint);
            _Socket.Listen(10);
        }
    }
}
