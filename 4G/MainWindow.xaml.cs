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
        public MainWindow()
        {
            InitializeComponent(); //Tobi war hier 26.02.2018
        }

       /* private void btn_send_Click(object sender, RoutedEventArgs e)
        {
            var remEndP = new IPEndPoint(IPAddress.Loopback, 9898);
            client = new TcpClient(localendP);
            client.SendTimeout = 2000;
            client.ReceiveTimeout = 2000;
            client.Connect(remEndP);

            using (NetworkStream stream = client.GetStream())
            {
                using (var writer = new StreamWriter(stream, Encoding.ASCII, 4000, leaveOpen: true))
                {
                    Console.WriteLine(player.ToString() + ";" + btn_send.IsEnabled);
                }
                using (var reader = new StreamReader(stream, Encoding.ASCII, true, 4000, leaveOpen: true))
                {
                    var teile = reader.ReadLine().Split(';');
                    player = Convert.ToInt32(teile[0]);
                    bool enabled = Convert.ToBoolean(teile[1]);
                    btn_send.IsEnabled = enabled;
                }
            }
        }*/

        private void b_player_Click(object sender, RoutedEventArgs e)
        {

        }

        private void b_player2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void b_11_Click(object sender, RoutedEventArgs e)
        {

        }

        private void b_12_Click(object sender, RoutedEventArgs e)
        {

        }
        private void b_13_Click(object sender, RoutedEventArgs e)
        {

        }
        private void b_14_Click(object sender, RoutedEventArgs e)
        {

        }
        private void b_15_Click(object sender, RoutedEventArgs e)
        {

        }
        private void b_21_Click(object sender, RoutedEventArgs e)
        {

        }
        private void b_22_Click(object sender, RoutedEventArgs e)
        {

        }
        private void b_23_Click(object sender, RoutedEventArgs e)
        {

        }
        private void b_24_Click(object sender, RoutedEventArgs e)
        {

        }
        private void b_25_Click(object sender, RoutedEventArgs e)
        {

        }
        private void b_31_Click(object sender, RoutedEventArgs e)
        {

        }
        private void b_32_Click(object sender, RoutedEventArgs e)
        {

        }
        private void b_33_Click(object sender, RoutedEventArgs e)
        {

        }
        private void b_34_Click(object sender, RoutedEventArgs e)
        {

        }
        private void b_35_Click(object sender, RoutedEventArgs e)
        {

        }
        private void b_41_Click(object sender, RoutedEventArgs e)
        {

        }
        private void b_42_Click(object sender, RoutedEventArgs e)
        {

        }
        private void b_43_Click(object sender, RoutedEventArgs e)
        {

        }
        private void b_44_Click(object sender, RoutedEventArgs e)
        {

        }
        private void b_45_Click(object sender, RoutedEventArgs e)
        {

        }
        private void b_51_Click(object sender, RoutedEventArgs e)
        {

        }
        private void b_52_Click(object sender, RoutedEventArgs e)
        {

        }
        private void b_53_Click(object sender, RoutedEventArgs e)
        {

        }
        private void b_54_Click(object sender, RoutedEventArgs e)
        {

        }
        private void b_55_Click(object sender, RoutedEventArgs e)
        {

        }
        private void b_61_Click(object sender, RoutedEventArgs e)
        {

        }
        private void b_62_Click(object sender, RoutedEventArgs e)
        {

        }
        private void b_63_Click(object sender, RoutedEventArgs e)
        {

        }
        private void b_64_Click(object sender, RoutedEventArgs e)
        {

        }
        private void b_65_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
