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
using System.Windows.Shapes;

namespace figma
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        private SqlConnection conn;
        public Main(SqlConnection conn, string id)
        {
            InitializeComponent();
            this.conn = conn;
            this.id = id;
            WriteName();
        }
        private string id;
        private void WriteName()
        {
            SqlCommand cmd = new SqlCommand("select FirstNameUser from Users where id="+id, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            myNickname.Text = reader[0].ToString();
            reader.Close();
        }

        private void profileWin_Click(object sender, RoutedEventArgs e)
        {
            
            profile profile = new profile(conn, id);
            profile.Show();
            this.Close();
        }
    }
}
