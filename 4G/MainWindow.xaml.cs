﻿using System;
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
        //TcpClient client;
        //IPEndPoint localendP;
        public MainWindow()
        {
            InitializeComponent(); //Tobi war hier 26.02.2018 //Brian ist immer hier!
            brush1.ImageSource = new BitmapImage(new Uri("../../Images/Weiß_Punkt.jpg", UriKind.Relative));
            brush2.ImageSource = new BitmapImage(new Uri("../../Images/Rot_Punkt.jpg", UriKind.Relative));
            brush3.ImageSource = new BitmapImage(new Uri("../../Images/Gelb_Punkt.jpg", UriKind.Relative));
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

        private void b_play_Click(object sender, RoutedEventArgs e)
        {
            l_player.Foreground = Brushes.Red;
            l_player.Content = l_player1.Content;
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
        }

        private void player_Switch(ref Button button)
        {
            if ((gewonnen != 1) && (gewonnen != 2))
            {
                if ((player == 0) && (l_player.Content == l_player1.Content))
                {
                    button.Background = brush2;
                    l_player.Foreground = Brushes.Yellow;
                    l_player.Content = l_player2.Content;
                    player++;
                }
                else if ((player == 1) && (l_player.Content == l_player2.Content))
                {
                    button.Background = brush3;
                    l_player.Foreground = Brushes.Red;
                    l_player.Content = l_player1.Content;
                    player--;
                }

                //Spiel überprüfen ob fertig
                gewonnen = spiel_prüfen();

                //Gewinne ermitteln

                if (gewonnen == 1)
                {
                    l_player.Foreground = Brushes.Green;
                    l_player.Content = "Spieler 1 hat gewonnen";
                }

                if (gewonnen == 2)
                {
                    l_player.Foreground = Brushes.Green;
                    l_player.Content = "Spieler 2 hat gewonnen";
                }

                if (gewonnen == 0)
                {
                    l_player.Foreground = Brushes.Green;
                    l_player.Content = "Kein Gewinner";
                }
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
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        public int spiel_prüfen()
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

        
    }

}
