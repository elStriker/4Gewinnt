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

namespace _4G
{
    /// <summary>
    /// Interaktionslogik für LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            private MySqlConnection conn;
            private string server = "localhost";
            private string database = "";
            private string uid = "root";
            private string password = "";

            string cString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";

            conn = new MySqlConnection(cString);
            InitializeComponent();

        private void b_login_Click(object sender, RoutedEventArgs e)
        {
            string query = $"SELECT * FROM users WHERE username ='{tb_username.Text}' && password = '{pb_password.ToString()}'";

            try
            {
                if (OpenConnection() == true)
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
            catch
                
        }
        private bool OpenConnection()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (Exception ex)
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
    }
    
}
