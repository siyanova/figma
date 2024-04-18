using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace figma
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlConnection conn;
        public MainWindow()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source = 3205EC01; Initial Catalog = figma; Integrated Security = SSPI;");
            conn.Open();
        }

        private void inputButton_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select idUser from [LoginUser] where Login = '"+loginBox.Text+"' and Password = '"+passwordBox.Text+"';", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                var id = reader[0].ToString();
                reader.Close();
                Main main = new Main(conn,id);
                main.Show();
                this.Close();
            }


        }
    }
}
