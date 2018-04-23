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
using System.Windows.Shapes;
using MySql.Data;
using System.Net;
using System.Net.Sockets;
using System.IO;
using MySql.Data.MySqlClient;

namespace _4G
{
    /// <summary>
    /// Interaktionslogik für LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        int player;
        TcpClient client;
        IPEndPoint localendP;
        MainWindow win2 = new MainWindow();
        //MainWindow win3 = new MainWindow();
        private MySqlConnection conn;
        private string server = "localhost";
        private string database = "users";
        private string uid = "root";
        private string password = "";
        public int i = 0;
        public LogIn()
        {

            string cString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            conn = new MySqlConnection(cString);

            InitializeComponent();
        }
        private void b_login_Click(object sender, RoutedEventArgs e)
        {
            string user = tb_username.Text;
            string pass = pb_password.ToString();
            
                if (IsLogin(user, pass))
                { 
                
                    if (i == 0)
                    {
                        MessageBox.Show($"Welcome {user}, you're now logged in!");
                        win2.l_player1.Content = user;
                        i++;
                        localendP = new IPEndPoint(IPAddress.Loopback, 9090);
                        win2.l_player1.IsEnabled = false;
                        win2.l_player2.IsEnabled = false;
                    Task.Run(() => Senden(win2.l_player1));
                        //win2.Show();
                    }
                                            
                    else
                    {
                        MessageBox.Show($"Welcome {user}, you're now logged in!");
                        win2.l_player2.Content = user;
                        localendP = new IPEndPoint(IPAddress.Loopback, 8989);
                        win2.l_player2.IsEnabled = false;
                        win2.l_player1.IsEnabled = false;
                        Task.Run(() => Senden(win2.l_player2));
                        this.Close();
                        win2.Show();
                        
                        
                    }
                        
                } 
                //else
                //{
                //    MessageBox.Show($"Username or Password is wrong!");
                    
                //}               
        }
        void Senden(Label label)
        {
            var remEndP = new IPEndPoint(IPAddress.Loopback, 9897);
            client = new TcpClient(localendP);
            ////client.SendTimeout = 2000;
            ////client.ReceiveTimeout = 2000;
            client.Connect(remEndP);

            NetworkStream stream = client.GetStream();
            
                using (var writer = new StreamWriter(stream, Encoding.ASCII, 4000, leaveOpen: true))
                {
                    Console.WriteLine(player.ToString() + ";" + label.IsEnabled);
                }
                using (var reader = new StreamReader(stream, Encoding.ASCII, true, 4000, leaveOpen: true))
                {
                    var teile = reader.ReadLine().Split(';');
                    player = Convert.ToInt32(teile[0]);
                    bool enabled = Convert.ToBoolean(teile[1]);
                    label.IsEnabled = enabled;
                }
            
        }


        public bool Register(string user, string pass)
        {
            string query = $"INSERT INTO user (id, username, password, siege, verluste) VALUES ('', '{user}', '{pass}', '', '')";

            try
            {
                if (OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                return false;
            }
        }
        public bool IsLogin(string user, string pass)
        {
            string query = $"SELECT * FROM user WHERE username ='{user}' && password = '{pass}'";

            try
            {
                if (OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        reader.Close();
                        conn.Close();
                        return true;
                    }
                    else
                    {
                        reader.Close();
                        conn.Close();
                        return false;
                    }
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
            catch(Exception ex)
            {
                conn.Close();
                return false;
            }
        }
        private bool OpenConnection()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("No server connection!");
                        break;
                    case 1045:
                        MessageBox.Show("Input is wrong!");
                        break;
                }
                return false;
            }
        }
    

            

        private void b_s_login_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win2 = new MainWindow();
            win2.Show();
            this.Close();
        }

        private void b_reg_Click(object sender, RoutedEventArgs e)
        {
            string user = tb_username.Text;
            string pass = pb_password.ToString();

            if (Register(user, pass))
            {
                MessageBox.Show($"User {user}, was created. Now LogIn please!");
                /*MainWindow win2 = new MainWindow();
                win2.Show();
                this.Close();
                win2.b_player.Content = user;*/
            }
            //else
            //{
            //    MessageBox.Show($"Please try again, something went wrong!");
            //}
        }
    }
    
}
