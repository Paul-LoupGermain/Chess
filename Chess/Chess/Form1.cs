using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace Chess
{
    public partial class Form1 : Form
    {

        string[,] tableau = new string[,] { { "A1","A2","A3","A4","A5","A6","A7","A8"},{ "B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8" }, { "C1", "C2","C3", "C4", "C5", "C6", "C7", "C8" }, { "D1", "D2","D3", "D4", "D5", "D6", "D7", "D8" }, { "E1", "E2","E3", "E4", "E5", "E6", "E7", "E8" }, { "F1", "F2","F3", "F4", "F5", "F6", "F7", "F8" }, { "G1", "G2","G3", "G4", "G5", "G6", "G7", "G8" }, { "H1", "H2","H3", "H4", "H5", "H6", "H7", "H8" } };
        string[,] pieces = new string[,] { { "R", "N", "B", "Q", "K", "B", "N", "R" }, { "P", "P", "P", "P", "P", "P", "P", "P" }, { " ", " ", " ", " ", " ", " ", " ", " " }, { " ", " ", " ", " ", " ", " ", " ", " " }, { " ", " ", " ", " ", " ", " ", " ", " " }, { " ", " ", " ", " ", " ", " ", " ", " " }, { "p", "p", "p", "p", "p", "p", "p", "p" }, { "r", "n", "b", "q", "k", "b", "n", "r" } };


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
                MessageBox.Show("erreur de connection avec la DB\n" + ex);
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

            //  MessageBox.Show("position de base: " + positionBase + " position de fin: " + positionFin);

            string positionFinString = positionFin.Substring(1);
            string positionBaseString = positionBase.Substring(1);

            //Définir position de fin string et position de base string en int
            int numFin = int.Parse(positionFinString);
            int numBase = int.Parse(positionBaseString);

            string a = coordonnees(positionBase);
            //MessageBox.Show(a);

            int yBase = int.Parse(a.Split("-")[0]);
            int xBase = int.Parse(a.Split("-")[1]);

            string b = coordonnees(positionFin);
            //MessageBox.Show(b);

            int yFin = int.Parse(b.Split("-")[0]);
            int xFin = int.Parse(b.Split("-")[1]);

            // Trouver la pièce qui correspond au cooronnées
            string pieceBase = pieces[xBase, yBase];
            string pieceFin = pieces[xFin, yFin];
            //MessageBox.Show(pieceBase + "-" + pieceFin);

            switch (pieceBase)
            {
                case "P":
                    if (numBase > numFin)
                    {
                        MessageBox.Show("Erreur: le pion ne peu pas reculer");
                    }
                    else
                    {
                        //MessageBox.Show(xBase+"-"+xFin);
                        if (xBase == 1 && xFin == 3)
                        {
                            pieces[xFin, yFin] = "P";
                            pieces[xBase, yBase] = " ";
                        }
                        else
                        {
                            if (xBase+1 == xFin)
                            {
                                pieces[xFin, yFin] = "P";
                                pieces[xBase, yBase] = "   ";
                            }
                            else
                            {
                                MessageBox.Show("Erreur: le pion ne peu pas avancer de plus de 2 cases");
                            }
                        }
                    }
                    break;
            }
            

        }

        // Trouver les coordonnees d'une case dans un tableau
        // Input string 
        // Output string "x-y"
        public string coordonnees(string pos)
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 7; y++)
                {
                    if (tableau[x, y] == pos)
                    {
                       // MessageBox.Show(tableau[x, y]);
                        return (x+"-"+y).ToString();
                    }
                }
            }
            return "404";
        }

        public void actualiser()
        {
            /*      A1.BackColor = Color.White;
                  A2.BackColor = Color.Black;
                  A3.BackColor = Color.White;
                  A4.BackColor = Color.Black;
                  A5.BackColor = Color.White;
                  A6.BackColor = Color.Black;
                  A7.BackColor = Color.White;
                  A8.BackColor = Color.Black;*/

            for (int x=0;x<8;x++)
            {
                for (int y=0;y<7;y++)
                {
                    if (pieces[x,y]=="P")
                    {
                        
                    }
                }
            }
        }
    }
}