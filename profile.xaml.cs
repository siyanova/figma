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
    /// Логика взаимодействия для profile.xaml
    /// </summary>
    public partial class profile : Window
    {
        private SqlConnection conn;
        private string id;
        public profile(SqlConnection conn, string id)
        {
            InitializeComponent();
            this.conn = conn;
            this.id = id;
            WriteData();
        }
        private void WriteData()
        {
            SqlCommand cmd = new SqlCommand("select FirstNameUser, "+" LastNameUser, "+" NumberPhone, "+" Statuss, "+" ImageProfile from Users where id =" + id, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            FirstName.Text = reader[0].ToString();
            LastName.Text = reader[1].ToString();
            NumberPhone.Text = reader[2].ToString();
            Status.Text = reader[3].ToString();

        }
    }
}
