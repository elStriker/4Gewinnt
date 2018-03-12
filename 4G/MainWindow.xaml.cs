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
            InitializeComponent(); //Tobi war hier 26.02.2018 //Brian ist immer hier!
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
        }

        private void b_player2_Click(object sender, RoutedEventArgs e)
        {
            localendP = new IPEndPoint(IPAddress.Loopback, 8989);
            b_player2.IsEnabled = false;
        }

        void Senden(Button button)
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
        private void player_Switch(Button button)
        {
            brush1.ImageSource = new BitmapImage(new Uri("Images/Weiß_Punkt.jpg", UriKind.Relative));
            brush2.ImageSource = new BitmapImage(new Uri("Images/Rot_Punkt.jpg", UriKind.Relative));
            brush3.ImageSource = new BitmapImage(new Uri("Images/Gelb_Punkt.jpg", UriKind.Relative));
            if (player == 0)
            {
                button.Background = brush2;
                player++;
                button.IsEnabled = false;
            }
            else if (player == 1)
            {
                button.Background = brush3;
                player--;
                button.IsEnabled = false;
            }
        }
         private void b_11_Click(object sender, RoutedEventArgs e)
        {
            //player_Switch(b_11);
            //if (b_12.Background != brush1)
            //    b_11.IsEnabled = false;
            //Senden(b_11);
        }

        private void b_12_Click(object sender, RoutedEventArgs e)
        {
            //player_Switch(b_12);
            //if (b_13.Background != brush1)
            //    button_belegen(b_12);
            //Senden(b_12);
        }
        private void b_13_Click(object sender, RoutedEventArgs e)
        {
            //player_Switch(b_11);
            //if (b_14.Background != brush1)
            //    button_belegen(b_13);
            //Senden(b_11);
        }
        private void b_14_Click(object sender, RoutedEventArgs e)
        {
            //player_Switch(b_11);
            //if (b_15.Background != brush1)
            //    button_belegen(b_14);
            //Senden(b_11);
        }
        private void b_15_Click(object sender, RoutedEventArgs e)
        {
            //player_Switch(b_11);
            //if (b_12.Background != brush1)
            //    button_belegen(b_15);
            //Senden(b_11);
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
        
        /*  private void b_play_Click(object sender, RoutedEventArgs e)
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
                      Console.WriteLine(player.ToString() + ";" + b_play.IsEnabled);
                  }
                  using (var reader = new StreamReader(stream, Encoding.ASCII, true, 4000, leaveOpen: true))
                  {
                      var teile = reader.ReadLine().Split(';');
                      player = Convert.ToInt32(teile[0]);
                      bool enabled = Convert.ToBoolean(teile[1]);
                      b_play.IsEnabled = enabled;
                  }
              }



              brush1.ImageSource = new BitmapImage(new Uri("./res/Weiß Punkt.jpg", UriKind.Relative));
              brush2.ImageSource = new BitmapImage(new Uri("./res/Rot Punkt.jpg", UriKind.Relative));
              brush3.ImageSource = new BitmapImage(new Uri("./res/Gelb Punkt.jpg", UriKind.Relative));

              b_player.Foreground = Brushes.Red;
              b_player2.Foreground = Brushes.Yellow;
              //l_spieler.Content = "Spieler 1";
              b_11.Background = brush1;
              b_12.Background = brush1;
              b_13.Background = brush1;
              b_14.Background = brush1;
              b_15.Background = brush1;
              b_21.Background = brush1;
              b_22.Background = brush1;
              b_23.Background = brush1;
              b_24.Background = brush1;
              b_25.Background = brush1;
              b_31.Background = brush1;
              b_32.Background = brush1;
              b_33.Background = brush1;
              b_34.Background = brush1;
              b_35.Background = brush1;
              b_41.Background = brush1;
              b_42.Background = brush1;
              b_43.Background = brush1;
              b_44.Background = brush1;
              b_45.Background = brush1;
              b_51.Background = brush1;
              b_52.Background = brush1;
              b_53.Background = brush1;
              b_54.Background = brush1;
              b_55.Background = brush1;
              b_61.Background = brush1;
              b_62.Background = brush1;
              b_63.Background = brush1;
              b_64.Background = brush1;
              b_65.Background = brush1;

              gewonnen = -1;
          }*/
        /* public int spiel_prüfen()
         {
             // senkrecht
             if ((b_11.Background == b_12.Background) && (b_12.Background == b_13.Background) && (b_13.Background == b_14.Background))
             {
                 if (b_11.Background == brush2)
                     return 1;
                 if (b_11.Background == brush3)
                     return 2;
             }

             if ((b_12.Background == b_13.Background) && (b_13.Background == b_14.Background) && (b_14.Background == b_15.Background))
             {
                 if (b_12.Background == brush2)
                     return 1;
                 if (b_12.Background == brush3)
                     return 2;
             }
             if ((b_21.Background == b_22.Background) && (b_22.Background == b_23.Background) && (b_23.Background == b_24.Background))
             {
                 if (b_21.Background == brush2)
                     return 1;
                 if (b_21.Background == brush3)
                     return 2;
             }

             if ((b_22.Background == b_23.Background) && (b_23.Background == b_24.Background) && (b_24.Background == b_25.Background))
             {
                 if (b_22.Background == brush2)
                     return 1;
                 if (b_22.Background == brush3)
                     return 2;
             }
             if ((b_31.Background == b_32.Background) && (b_32.Background == b_33.Background) && (b_33.Background == b_34.Background))
             {
                 if (b_31.Background == brush2)
                     return 1;
                 if (b_31.Background == brush3)
                     return 2;
             }

             if ((b_32.Background == b_33.Background) && (b_33.Background == b_34.Background) && (b_34.Background == b_35.Background))
             {
                 if (b_32.Background == brush2)
                     return 1;
                 if (b_32.Background == brush3)
                     return 2;
             }
             if ((b_41.Background == b_42.Background) && (b_42.Background == b_43.Background) && (b_43.Background == b_44.Background))
             {
                 if (b_41.Background == brush2)
                     return 1;
                 if (b_41.Background == brush3)
                     return 2;
             }

             if ((b_42.Background == b_43.Background) && (b_43.Background == b_44.Background) && (b_44.Background == b_45.Background))
             {
                 if (b_42.Background == brush2)
                     return 1;
                 if (b_42.Background == brush3)
                     return 2;
             }
             if ((b_51.Background == b_52.Background) && (b_52.Background == b_53.Background) && (b_53.Background == b_54.Background))
             {
                 if (b_51.Background == brush2)
                     return 1;
                 if (b_51.Background == brush3)
                     return 2;
             }

             if ((b_52.Background == b_53.Background) && (b_53.Background == b_54.Background) && (b_54.Background == b_55.Background))
             {
                 if (b_52.Background == brush2)
                     return 1;
                 if (b_52.Background == brush3)
                     return 2;
             }
             if ((b_61.Background == b_62.Background) && (b_62.Background == b_63.Background) && (b_63.Background == b_64.Background))
             {
                 if (b_61.Background == brush2)
                     return 1;
                 if (b_61.Background == brush3)
                     return 2;
             }
             if ((b_62.Background == b_63.Background) && (b_63.Background == b_64.Background) && (b_64.Background == b_65.Background))
             {
                 if (b_62.Background == brush2)
                     return 1;
                 if (b_62.Background == brush3)
                     return 2;
             }

             // horizontal
             if ((b_11.Background == b_21.Background) && (b_21.Background == b_31.Background) && (b_31.Background == b_41.Background))
             {
                 if (b_11.Background == brush2)
                     return 1;
                 if (b_11.Background == brush3)
                     return 2;
             }
             if ((b_21.Background == b_31.Background) && (b_31.Background == b_41.Background) && (b_41.Background == b_51.Background))
             {
                 if (b_21.Background == brush2)
                     return 1;
                 if (b_21.Background == brush3)
                     return 2;
             }
             if ((b_31.Background == b_41.Background) && (b_41.Background == b_51.Background) && (b_51.Background == b_61.Background))
             {
                 if (b_31.Background == brush2)
                     return 1;
                 if (b_31.Background == brush3)
                     return 2;
             }
             if ((b_12.Background == b_22.Background) && (b_22.Background == b_32.Background) && (b_32.Background == b_42.Background))
             {
                 if (b_12.Background == brush2)
                     return 1;
                 if (b_12.Background == brush3)
                     return 2;
             }
             if ((b_22.Background == b_32.Background) && (b_32.Background == b_42.Background) && (b_42.Background == b_52.Background))
             {
                 if (b_22.Background == brush2)
                     return 1;
                 if (b_22.Background == brush3)
                     return 2;
             }
             if ((b_32.Background == b_42.Background) && (b_42.Background == b_52.Background) && (b_52.Background == b_62.Background))
             {
                 if (b_32.Background == brush2)
                     return 1;
                 if (b_32.Background == brush3)
                     return 2;
             }
             if ((b_13.Background == b_23.Background) && (b_23.Background == b_33.Background) && (b_33.Background == b_43.Background))
             {
                 if (b_13.Background == brush2)
                     return 1;
                 if (b_13.Background == brush3)
                     return 2;
             }
             if ((b_23.Background == b_33.Background) && (b_33.Background == b_43.Background) && (b_43.Background == b_53.Background))
             {
                 if (b_23.Background == brush2)
                     return 1;
                 if (b_23.Background == brush3)
                     return 2;
             }
             if ((b_33.Background == b_43.Background) && (b_43.Background == b_53.Background) && (b_53.Background == b_63.Background))
             {
                 if (b_33.Background == brush2)
                     return 1;
                 if (b_33.Background == brush3)
                     return 2;
             }
             if ((b_14.Background == b_24.Background) && (b_24.Background == b_34.Background) && (b_34.Background == b_44.Background))
             {
                 if (b_14.Background == brush2)
                     return 1;
                 if (b_14.Background == brush3)
                     return 2;
             }
             if ((b_24.Background == b_34.Background) && (b_34.Background == b_44.Background) && (b_44.Background == b_54.Background))
             {
                 if (b_24.Background == brush2)
                     return 1;
                 if (b_24.Background == brush3)
                     return 2;
             }
             if ((b_34.Background == b_44.Background) && (b_44.Background == b_54.Background) && (b_54.Background == b_64.Background))
             {
                 if (b_34.Background == brush2)
                     return 1;
                 if (b_34.Background == brush3)
                     return 2;
             }
             if ((b_15.Background == b_25.Background) && (b_25.Background == b_35.Background) && (b_35.Background == b_45.Background))
             {
                 if (b_15.Background == brush2)
                     return 1;
                 if (b_15.Background == brush3)
                     return 2;
             }
             if ((b_25.Background == b_35.Background) && (b_35.Background == b_45.Background) && (b_45.Background == b_55.Background))
             {
                 if (b_25.Background == brush2)
                     return 1;
                 if (b_25.Background == brush3)
                     return 2;
             }
             if ((b_35.Background == b_45.Background) && (b_45.Background == b_55.Background) && (b_55.Background == b_65.Background))
             {
                 if (b_35.Background == brush2)
                     return 1;
                 if (b_35.Background == brush3)
                     return 2;
             }

             // diagonal

             if ((b_12.Background == b_23.Background) && (b_23.Background == b_34.Background) && (b_34.Background == b_45.Background))
             {
                 if (b_12.Background == brush2)
                     return 1;
                 if (b_12.Background == brush3)
                     return 2;
             }
             if ((b_11.Background == b_22.Background) && (b_22.Background == b_33.Background) && (b_33.Background == b_44.Background))
             {
                 if (b_11.Background == brush2)
                     return 1;
                 if (b_11.Background == brush3)
                     return 2;
             }
             if ((b_22.Background == b_33.Background) && (b_33.Background == b_44.Background) && (b_44.Background == b_55.Background))
             {
                 if (b_22.Background == brush2)
                     return 1;
                 if (b_22.Background == brush3)
                     return 2;
             }
             if ((b_21.Background == b_32.Background) && (b_32.Background == b_43.Background) && (b_43.Background == b_54.Background))
             {
                 if (b_21.Background == brush2)
                     return 1;
                 if (b_21.Background == brush3)
                     return 2;
             }
             if ((b_32.Background == b_43.Background) && (b_43.Background == b_54.Background) && (b_54.Background == b_65.Background))
             {
                 if (b_21.Background == brush2)
                     return 1;
                 if (b_21.Background == brush3)
                     return 2;
             }
             if ((b_31.Background == b_42.Background) && (b_42.Background == b_53.Background) && (b_53.Background == b_64.Background))
             {
                 if (b_31.Background == brush2)
                     return 1;
                 if (b_31.Background == brush3)
                     return 2;
             }
             if ((b_62.Background == b_53.Background) && (b_53.Background == b_44.Background) && (b_44.Background == b_35.Background))
             {
                 if (b_62.Background == brush2)
                     return 1;
                 if (b_62.Background == brush3)
                     return 2;
             }
             if ((b_61.Background == b_52.Background) && (b_52.Background == b_43.Background) && (b_43.Background == b_34.Background))
             {
                 if (b_61.Background == brush2)
                     return 1;
                 if (b_61.Background == brush3)
                     return 2;
             }
             if ((b_52.Background == b_43.Background) && (b_43.Background == b_34.Background) && (b_34.Background == b_25.Background))
             {
                 if (b_52.Background == brush2)
                     return 1;
                 if (b_52.Background == brush3)
                     return 2;
             }
             if ((b_51.Background == b_42.Background) && (b_42.Background == b_33.Background) && (b_33.Background == b_24.Background))
             {
                 if (b_51.Background == brush2)
                     return 1;
                 if (b_51.Background == brush3)
                     return 2;
             }
             if ((b_42.Background == b_33.Background) && (b_33.Background == b_24.Background) && (b_24.Background == b_15.Background))
             {
                 if (b_42.Background == brush2)
                     return 1;
                 if (b_42.Background == brush3)
                     return 2;
             }
             if ((b_41.Background == b_32.Background) && (b_32.Background == b_23.Background) && (b_23.Background == b_14.Background))
             {
                 if (b_41.Background == brush2)
                     return 1;
                 if (b_41.Background == brush3)
                     return 2;
             }


             if ((b_11.Background != brush1) && (b_12.Background != brush1) && (b_13.Background != brush1) &&
                 (b_14.Background != brush1) && (b_15.Background != brush1) &&
                 (b_21.Background != brush1) && (b_22.Background != brush1) && (b_23.Background != brush1) &&
                 (b_24.Background != brush1) && (b_25.Background != brush1) &&
                 (b_31.Background != brush1) && (b_32.Background != brush1) && (b_33.Background != brush1) &&
                 (b_34.Background != brush1) && (b_35.Background != brush1) &&
                 (b_41.Background != brush1) && (b_42.Background != brush1) && (b_43.Background != brush1) &&
                 (b_44.Background != brush1) && (b_45.Background != brush1) &&
                 (b_51.Background != brush1) && (b_52.Background != brush1) && (b_53.Background != brush1) &&
                 (b_54.Background != brush1) && (b_55.Background != brush1) &&
                 (b_61.Background != brush1) && (b_62.Background != brush1) && (b_63.Background != brush1) &&
                 (b_64.Background != brush1) && (b_65.Background != brush1))
                 return 0;

             return -1;

         }
         public void button_belegen(Button b)
         {
             if ((gewonnen != 1) && (gewonnen != 2))
             {

                 if (b.Background == brush1)     //Button nicht belegt
                 {

                     //Spieler überprüfen
                     if (l_player.Content == "Spieler 1")
                     {
                         b.Background = brush2;
                         b_player2.Foreground = Brushes.Yellow;

                     }


                     else //Spieler 2
                     {
                         b.Background = brush3;
                         b_player.Foreground = Brushes.Red;

                     }

                     //Spiel überprüfen ob fertig
                     gewonnen = spiel_prüfen();

                     //Gewinne ermitteln

                     if (gewonnen == 1)
                     {
                         l_player.Content = "Spieler 1 hat gewonnen";
                     }

                     if (gewonnen == 2)
                     {
                         l_player.Content = "Spieler 2 hat gewonnen";
                     }

                     if (gewonnen == 0)
                     {
                         l_player.Content = "Kein Gewinner";
                     }

                 }

                 else        //Button belegt
                 {
                     MessageBox.Show("Feld bereits belegt!!");
                 }
             }
         }*/

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            player_Switch(btn);
            if (btn.Name[3] == '5' && btn.Background == brush1)
                btn.IsEnabled = false;
            else if (grd_main.FindName("b_" + btn.Name[2] + ((int)btn.Name[3] + 1)) != brush1)
                btn.IsEnabled = false;
        }

    }

}
