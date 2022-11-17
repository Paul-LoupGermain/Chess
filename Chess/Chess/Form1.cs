using MySql.Data.MySqlClient;

namespace Chess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connection = "server=localhost;user=root;database=chess;port=3306;password=Pa$$w0rd";
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connection;
                conn.Open();
                string sql = "SELECT * FROM users";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MessageBox.Show("Name: " + reader["name"]);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("erreur\n"+ex);
            }
        }
    }
}