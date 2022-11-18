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
                MessageBox.Show("erreur de connection avec la DB\n"+ex);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int x = P1.Location.X;
            int y = P1.Location.Y;

            int x2 = A3.Location.X;
            int y2 = A3.Location.Y;

            P1.Location = new Point(x2, y2);

            //MessageBox.Show("x: " + x + " y: " + y);
            
        }
    }
}