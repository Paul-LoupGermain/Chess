using MySql.Data.MySqlClient;
using static System.Net.Mime.MediaTypeNames;

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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string position = textBox1.Text;
            
            string positionBase = position.Split("-")[0];  
            string positionFin = position.Split("-")[1];
            
            MessageBox.Show("position de base: " + positionBase + " position de fin: " + positionFin);

            string test1 = positionFin.Substring(1);
            string test2 = positionBase.Substring(1);

            int num1 = int.Parse(test1);
            int num2 = int.Parse(test2);

            if (num2 < num1)
            {
                //Switch sans fin
                switch (positionFin)
                {
                    case "A3":
                        A3.BackColor = Color.Red;
                        A2.BackColor = Color.White;
                        break;
                    case "A4":
                        A4.BackColor = Color.Red;
                        if (positionBase == "A2")
                        {
                            A2.BackColor = Color.White;
                        }
                        else
                        {
                            A3.BackColor = Color.Black;
                        }
                        break;
                    case "A5":
                        A5.BackColor = Color.Red;
                        A4.BackColor = Color.White;
                        break;
                    case "A6":
                        A6.BackColor = Color.Red;
                        A5.BackColor = Color.Black;
                        break;
                    case "A7":
                        A7.BackColor = Color.Red;
                        A6.BackColor = Color.White;
                        break;
                    case "A8":
                        A8.BackColor = Color.Red;
                        A7.BackColor = Color.Black;
                        break;
                    case "B3":
                        B3.BackColor = Color.Red;
                        B2.BackColor = Color.Black;
                        break;
                    case "B4":
                        if (positionBase == "B2")
                        {
                            B2.BackColor = Color.Black;
                        }
                        else
                        {
                            B3.BackColor = Color.White;
                        }
                        break;
                    case "B5":
                        B5.BackColor = Color.Red;
                        B4.BackColor = Color.Black;
                        break;
                    case "B6":
                        B6.BackColor = Color.Red;
                        B5.BackColor = Color.White;
                        break;
                    case "B7":
                        B7.BackColor = Color.Red;
                        B6.BackColor = Color.Black;
                        break;
                    case "B8":
                        B8.BackColor = Color.Red;
                        B7.BackColor = Color.White;
                        break;
                    case "C3":
                        C3.BackColor = Color.Red;
                        C2.BackColor = Color.White;
                        break;
                    case "C4":
                        if (positionBase == "C2")
                        {
                            C2.BackColor = Color.White;
                        }
                        else
                        {
                            C3.BackColor = Color.Black;
                        }
                        break;
                    case "C5":
                        C5.BackColor = Color.Red;
                        C4.BackColor = Color.White;
                        break;
                    case "C6":
                        C6.BackColor = Color.Red;
                        C5.BackColor = Color.Black;
                        break;
                    case "C7":
                        C7.BackColor = Color.Red;
                        C6.BackColor = Color.White;
                        break;
                    case "C8":
                        C8.BackColor = Color.Red;
                        C7.BackColor = Color.Black;
                        break;
                    case "D3":
                        D3.BackColor = Color.Red;
                        D2.BackColor = Color.Black;
                        break;
                    case "D4":
                        if (positionBase == "D2")
                        {
                            D2.BackColor = Color.Black;
                        }
                        else
                        {
                            D3.BackColor = Color.White;
                        }
                        break;
                    case "D5":
                        D5.BackColor = Color.Red;
                        D4.BackColor = Color.Black;
                        break;
                    case "D6":
                        D6.BackColor = Color.Red;
                        D5.BackColor = Color.White;
                        break;
                    case "D7":
                        D7.BackColor = Color.Red;
                        D6.BackColor = Color.Black;
                        break;
                    case "D8":
                        D8.BackColor = Color.Red;
                        D7.BackColor = Color.White;
                        break;
                    case "E3":
                        E3.BackColor = Color.Red;
                        E2.BackColor = Color.White;
                        break;
                    case "E4":
                        if (positionBase == "E2")
                        {
                            E2.BackColor = Color.White;
                        }
                        else
                        {
                            E3.BackColor = Color.Black;
                        }
                        break;
                    case "E5":
                        E5.BackColor = Color.Red;
                        E4.BackColor = Color.White;
                        break;
                    case "E6":
                        E6.BackColor = Color.Red;
                        E5.BackColor = Color.Black;
                        break;
                    case "E7":
                        E7.BackColor = Color.Red;
                        E6.BackColor = Color.White;
                        break;
                    case "E8":
                        E8.BackColor = Color.Red;
                        E7.BackColor = Color.Black;
                        break;
                    case "F3":
                        F3.BackColor = Color.Red;
                        F2.BackColor = Color.Black;
                        break;
                    case "F4":
                        if (positionBase == "F2")
                        {
                            F2.BackColor = Color.Black;
                        }
                        else
                        {
                            F3.BackColor = Color.White;
                        }
                        break;
                    case "F5":
                        F5.BackColor = Color.Red;
                        F4.BackColor = Color.Black;
                        break;
                    case "F6":
                        F6.BackColor = Color.Red;
                        F5.BackColor = Color.White;
                        break;
                    case "F7":
                        F7.BackColor = Color.Red;
                        F6.BackColor = Color.Black;
                        break;
                    case "F8":
                        F8.BackColor = Color.Red;
                        F7.BackColor = Color.White;
                        break;
                    case "G3":
                        G3.BackColor = Color.Red;
                        G2.BackColor = Color.White;
                        break;
                    case "G4":
                        if (positionBase == "G2")
                        {
                            G2.BackColor = Color.White;
                        }
                        else
                        {
                            G3.BackColor = Color.Black;
                        }
                        break;
                    case "G5":
                        G5.BackColor = Color.Red;
                        G4.BackColor = Color.White;
                        break;
                    case "G6":
                        G6.BackColor = Color.Red;
                        G5.BackColor = Color.Black;
                        break;
                    case "G7":
                        G7.BackColor = Color.Red;
                        G6.BackColor = Color.White;
                        break;
                    case "G8":
                        G8.BackColor = Color.Red;
                        G7.BackColor = Color.Black;
                        break;
                    case "H3":
                        H3.BackColor = Color.Red;
                        H2.BackColor = Color.Black;
                        break;
                    case "H4":
                        if (positionBase == "H2")
                        {
                            H2.BackColor = Color.Black;
                        }
                        else
                        {
                            H3.BackColor = Color.White;
                        }
                        break;
                    case "H5":
                        H5.BackColor = Color.Red;
                        H4.BackColor = Color.Black;
                        break;
                    case "H6":
                        H6.BackColor = Color.Red;
                        H5.BackColor = Color.White;
                        break;
                    case "H7":
                        H7.BackColor = Color.Red;
                        H6.BackColor = Color.Black;
                        break;
                    case "H8":
                        H8.BackColor = Color.Red;
                        H7.BackColor = Color.White;
                        break;
                }   
            }
            else
            {
                MessageBox.Show("pas bien");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}