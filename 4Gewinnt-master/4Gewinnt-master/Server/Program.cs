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
            TcpClient player;
            TcpClient player2;
            var localEndp = new IPEndPoint(IPAddress.Loopback, 9898);
            TcpListener listener = new TcpListener(localEndp);
            listener.Start();

            Console.WriteLine("Server gestartet");
            player = listener.AcceptTcpClient();
            Console.WriteLine("Player1 Connected");
            player2 = listener.AcceptTcpClient();
            Send_Rec(player, player2);
        }

        public int CheckForWin(int[,] field)
        {
            int h = CheckHorizontal(field);
            if (h == 0)
            {
                int v = CheckVertical(field);
                if (v == 0)
                {
                    int dlr = CheckDiagonalLR(field);
                    if (dlr == 0)
                    {
                        return CheckDiagonalRL(field);
                    }
                    else
                    {
                        return dlr;
                    }
                }
                else
                {
                    return v;
                }
            }
            else
            {
                return h;
            }
        }

        private int CheckHorizontal(int[,] field)
        {
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (field[x, y] == 1 && field[x + 1, y] == 1 && field[x + 2, y] == 1 && field[x + 3, y] == 1)
                    {
                        return 1;
                    }
                    if (field[x, y] == 2 && field[x + 1, y] == 2 && field[x + 2, y] == 2 && field[x + 3, y] == 2)
                    {
                        return 2;
                    }
                }
            }
            return 0;
        }

        private int CheckVertical(int[,] field)
        {
            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < 6; x++)
                {
                    if (field[x, y] == 1 && field[x, y + 1] == 1 && field[x, y + 2] == 1 && field[x, y + 3] == 1)
                    {
                        return 1;
                    }
                    if (field[x, y] == 2 && field[x, y + 1] == 2 && field[x, y + 2] == 2 && field[x, y + 3] == 2)
                    {
                        return 2;
                    }
                }
            }
            return 0;
        }

        private int CheckDiagonalLR(int[,] field)
        {
            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (field[x, y] == 1 && field[x + 1, y + 1] == 1 && field[x + 2, y + 2] == 1 && field[x + 3, y + 3] == 1)
                    {
                        return 1;
                    }
                    if (field[x, y] == 2 && field[x + 1, y + 1] == 2 && field[x + 2, y + 2] == 2 && field[x + 3, y + 3] == 2)
                    {
                        return 2;
                    }
                }
            }
            return 0;
        }

        private int CheckDiagonalRL(int[,] field)
        {
            for (int y = 0; y < 2; y++)
            {
                for (int x = 5; x > 2; x++)
                {
                    if (field[x, y] == 1 && field[x - 1, y + 1] == 1 && field[x - 2, y + 2] == 1 && field[x - 3, y + 3] == 1)
                    {
                        return 1;
                    }
                    if (field[x, y] == 2 && field[x - 1, y + 1] == 2 && field[x - 2, y + 2] == 2 && field[x - 3, y + 3] == 2)
                    {
                        return 2;
                    }

                }
            }
            return 0;
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
