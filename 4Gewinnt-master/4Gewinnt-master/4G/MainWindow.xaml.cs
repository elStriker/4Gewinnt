using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace _4G
{
    
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        int player;
        TcpClient client;
        IPEndPoint localendP;
        int[,] _fieldArray = new int[6, 5] { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } };

        public MainWindow()
        {
            InitializeComponent(); //Tobi war hier 26.02.2018 //Brian ist immer hier!
            brush1.ImageSource = new BitmapImage(new Uri("../../Images/Weiß_Punkt2.jpg", UriKind.Relative));
            brush2.ImageSource = new BitmapImage(new Uri("../../Images/Rot_Punkt2.jpg", UriKind.Relative));
            brush3.ImageSource = new BitmapImage(new Uri("../../Images/Gelb_Punkt2.jpg", UriKind.Relative));
        }

        // b_11 b_21 b_31 b_41 b_51 b_61
        // b_12 b_22 b_32 b_42 b_52 b_62
        // b_13 b_23 b_33 b_43 b_53 b_63
        // b_14 b_24 b_34 b_44 b_54 b_64
        // b_15 b_25 b_35 b_45 b_55 b_65       

        int gewonnen = -1;
        ImageBrush brush1 = new ImageBrush();
        ImageBrush brush2 = new ImageBrush();
        ImageBrush brush3 = new ImageBrush();               

        private void b_player_Click(object sender, RoutedEventArgs e)
        {            
            localendP = new IPEndPoint(IPAddress.Loopback, 9090);
            b_player.IsEnabled = false;
            b_player2.IsEnabled = false;
            Task.Run(() => Senden((Button)sender));
        }

        private void b_player2_Click(object sender, RoutedEventArgs e)
        {
            localendP = new IPEndPoint(IPAddress.Loopback, 8989);
            b_player2.IsEnabled = false;            
            b_player.IsEnabled = false;
            Task.Run(() => Senden((Button)sender));
        }

        private void TestForWin(List<string> listOfbtnNames)
        {
        }

        void SendField(int[,] fieldArray)
        {
            var remEndP = new IPEndPoint(IPAddress.Loopback, 9898);
            client = new TcpClient(localendP);
            ////client.SendTimeout = 2000;
            ////client.ReceiveTimeout = 2000;
            client.Connect(remEndP);

            foreach (int sendInt in fieldArray)
            {

                using (NetworkStream stream = client.GetStream())
                {
                    using (var writer = new StreamWriter(stream, Encoding.ASCII, 4000, leaveOpen: true))
                    {
                        Console.WriteLine(sendInt);
                    }
                }
            }
        }

        void RecieveField()
        {
            var remEndP = new IPEndPoint(IPAddress.Loopback, 9898);
            client = new TcpClient(localendP);
            ////client.SendTimeout = 2000;
            ////client.ReceiveTimeout = 2000;
            client.Connect(remEndP);

            using (NetworkStream stream = client.GetStream())
            {
                using (var reader = new StreamReader(stream, Encoding.ASCII, true, 4000, leaveOpen: true))
                {
                    var teile = reader.ReadLine();
                    int Ausgabe = Convert.ToInt32(teile);
                    // AUSGABE gibt 0 für kein Spieler gewonnen 1 für Spieler eins gewonnen und 2für SPieler zwei gewonnen-------------------------------------------------------------------------------
                }
            }
        }


        void Senden(Button button)
        {
            var remEndP = new IPEndPoint(IPAddress.Loopback, 9898);
            client = new TcpClient(localendP);
            ////client.SendTimeout = 2000;
            ////client.ReceiveTimeout = 2000;
            client.Connect(remEndP);

            using (NetworkStream stream = client.GetStream())
            {
                using (var writer = new StreamWriter(stream, Encoding.ASCII, 4000, leaveOpen: true))
                {
                    Console.WriteLine(player.ToString() + ";" + button.IsEnabled);

                }
                using (var reader = new StreamReader(stream, Encoding.ASCII, true, 4000, leaveOpen: true))
                {
                    var teile = reader.ReadLine().Split(';');
                    player = Convert.ToInt32(teile[0]);
                    bool enabled = Convert.ToBoolean(teile[1]);
                    button.IsEnabled = enabled;
                }
            }
        }
        private void player_Switch(ref Button button)
        {            
            if (player == 0)
            {
                button.Background = brush2;
                player++;
            }
            else if (player == 1)
            {
                button.Background = brush3;
                player--;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;          
            char one = btn.Name[2];//Wir holen uns dir Column (b_12 die 1 an der 3ten stelle, 3te wgen index bei 0)
            string two = btn.Name[3].ToString();//Wir holen die Column Number (b_12 die 2 an der 4ten stelle, 4te wgen index bei 0)
            string down_name = "b_" + one + (int.Parse(two) + 1);//b_ Am Anfang, dann one(Column) + (1+Column Number, 1+ wegen eins Runter)
            string srcs = btn.Name[3] == '5' ? ((ImageBrush)btn.Background).ImageSource.ToString() : ((ImageBrush)(((Button)grd_main.FindName(down_name)).Background)).ImageSource.ToString();
            //Falls ich schon unten bin (==5) Dann gibt mir den Pfad zum jzigen Bild
            //Sonst zu dem unetr mir
            string src = srcs.Split('/')[srcs.Split('/').Length - 1];
            string src2 = brush1.ImageSource.ToString().Split('/')[brush1.ImageSource.ToString().Split('/').Length - 1];
            //Mich interessiert nich der Pfad sonsern nur das ganz am Ende
            if (btn.Name[3] == '5' ? src == src2 : src != src2)
                player_Switch(ref btn);
            //Falls ich unten bin muss ich weiß sein, sonst darf das unter mir nicht weiß sein

            int playerID = 1; // PlayerID mitgeben -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

           _fieldArray = LoadDataIntoArray(btn, playerID); // -----------------------------------------------------------------------------------------------------------------

            SendField(_fieldArray);
            RecieveField();
        } 

        private int[,] LoadDataIntoArray(Button btn, int playerID)
        {


            if (btn.Name[2] == 1)
            {
                if (btn.Name[3] == 1)
                {
                    _fieldArray[0, 0] = playerID;
                }
                if (btn.Name[3] == 2)
                {
                    _fieldArray[0, 1] = playerID;
                }
                if (btn.Name[3] == 3)
                {
                    _fieldArray[0, 2] = playerID;
                }
                if (btn.Name[3] == 4)
                {
                    _fieldArray[0, 3] = playerID;
                }
                if (btn.Name[3] == 5)
                {
                    _fieldArray[0, 4] = playerID;
                }
            }
            if (btn.Name[2] == 2)
            {
                if (btn.Name[3] == 1)
                {
                    _fieldArray[1, 0] = playerID;
                }
                if (btn.Name[3] == 2)
                {
                    _fieldArray[1, 1] = playerID;
                }
                if (btn.Name[3] == 3)
                {
                    _fieldArray[1, 2] = playerID;
                }
                if (btn.Name[3] == 4)
                {
                    _fieldArray[1, 3] = playerID;
                }
                if (btn.Name[3] == 5)
                {
                    _fieldArray[1, 4] = playerID;
                }
            }
            if (btn.Name[2] == 3)
            {
                if (btn.Name[3] == 1)
                {
                    _fieldArray[2, 0] = playerID;
                }
                if (btn.Name[3] == 2)
                {
                    _fieldArray[2, 1] = playerID;
                }
                if (btn.Name[3] == 3)
                {
                    _fieldArray[2, 2] = playerID;
                }
                if (btn.Name[3] == 4)
                {
                    _fieldArray[2, 3] = playerID;
                }
                if (btn.Name[3] == 5)
                {
                    _fieldArray[2, 4] = playerID;
                }
            }
            if (btn.Name[2] == 4)
            {
                if (btn.Name[3] == 1)
                {
                    _fieldArray[3, 0] = playerID;
                }
                if (btn.Name[3] == 2)
                {
                    _fieldArray[3, 1] = playerID;
                }
                if (btn.Name[3] == 3)
                {
                    _fieldArray[3, 2] = playerID;
                }
                if (btn.Name[3] == 4)
                {
                    _fieldArray[3, 3] = playerID;
                }
                if (btn.Name[3] == 5)
                {
                    _fieldArray[3, 4] = playerID;
                }
            }
            if (btn.Name[2] == 5)
            {
                if (btn.Name[3] == 1)
                {
                    _fieldArray[4, 0] = playerID;
                }
                if (btn.Name[3] == 2)
                {
                    _fieldArray[4, 1] = playerID;
                }
                if (btn.Name[3] == 3)
                {
                    _fieldArray[4, 2] = playerID;
                }
                if (btn.Name[3] == 4)
                {
                    _fieldArray[4, 3] = playerID;
                }
                if (btn.Name[3] == 5)
                {
                    _fieldArray[4, 4] = playerID;
                }
            }
            if (btn.Name[2] == 6)
            {
                if (btn.Name[3] == 1)
                {
                    _fieldArray[5, 0] = playerID;
                }
                if (btn.Name[3] == 2)
                {
                    _fieldArray[5, 1] = playerID;
                }
                if (btn.Name[3] == 3)
                {
                    _fieldArray[5, 2] = playerID;
                }
                if (btn.Name[3] == 4)
                {
                    _fieldArray[5, 3] = playerID;
                }
                if (btn.Name[3] == 5)
                {
                    _fieldArray[5, 4] = playerID;
                }
            }
            return _fieldArray;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }

}
