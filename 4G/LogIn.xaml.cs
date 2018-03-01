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
using MySql.Data.MySqlClient;

namespace _4G
{
    /// <summary>
    /// Interaktionslogik für LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        private MySqlConnection conn;
        private string server = "localhost";
        private string database = "users";
        private string uid = "root";
        private string password = "";
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
            for (int i = 0; i < 2; i++)
            {
                if (IsLogin(user, pass))
                {
                    MessageBox.Show($"Welcome {user}, you're now logged in!");
                    MainWindow win2 = new MainWindow();
                    win2.Show();
                    if (i == 0)
                        win2.b_player.Content = user;
                    
                    else
                        win2.b_player2.Content = user;
                }
                else
                {
                    MessageBox.Show($"Username or Password is wrong!");
                }               
            }
            this.Close();

        }
        public bool Register(string user, string pass)
        {
            string query = $"INSERT INTO user (id, username, password), ('', '{user}', '{pass}')";

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
            else
            {
                MessageBox.Show($"Please try again, something went wrong!");
            }
        }
    }
    
}
