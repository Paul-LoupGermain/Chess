using System;
using System.Threading;
using System.Runtime.CompilerServices;
using Game;
using System.Net.Sockets;
using MySqlConnector;
using System.Xml.Linq;

namespace MenuGame
{

    public class Chess
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                DisplayMenu();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        LoginPlayerOne();
                        LoginPlayerTwo();
                        PlayGame game = new PlayGame();
                        game.Game();
                        break;
                    case "2":
                        Console.WriteLine("\n Work In Progress\n");
                        Console.WriteLine(" Press any key to continue...\n");
                        Console.ReadKey();
                        break;
                    case "3":
                        return;
                }
            }
        }

        static private void DisplayMenu()
        {
            Console.WriteLine("\n ╔═══════════════╗");
            Console.WriteLine(" ║ Play      : 1 ║");
            Console.WriteLine(" ╚═══════════════╝\n");
            Console.WriteLine(" ╔═══════════════╗");
            Console.WriteLine(" ║ Score     : 2 ║");
            Console.WriteLine(" ╚═══════════════╝\n");
            Console.WriteLine(" ╔═══════════════╗");
            Console.WriteLine(" ║ Quit      : 3 ║");
            Console.WriteLine(" ╚═══════════════╝\n");
            Console.Write(" ► ");
        }

        static private void ConnectionDB()
        {
            MySqlConnection openningDB = new MySqlConnection();
            openningDB.ConnectionString = "server = 127.0.0.1; user id = Chess; password = Pa$$W0rd; database = chess";

            try
            {
                openningDB.Open();
                Console.WriteLine("Connection Open!");
                Console.Write(" ► ");
                openningDB.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not open connection ! ");
                Console.Write(" ► ");
            }
        }

        static private void LoginPlayerOne()
        {
            Console.WriteLine("\nLogin player one");

            string loginPlayerOne = Console.ReadLine();

            try
            {
                string MyConnection2 = "server = 127.0.0.1; user id = Chess; password = Pa$$W0rd; database = chess";
                string Query = "INSERT INTO userplayer (NAME) VALUES ('" + loginPlayerOne + "');";

                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();

                MyReader2 = MyCommand2.ExecuteReader();
                Console.WriteLine("Save");
                while (MyReader2.Read())
                {

                }
                MyConn2.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not open connection ! ");
                //Console.WriteLine(ex.Message);
                Console.WriteLine(" Press any key to continue...\n");
                Console.ReadKey();
            }
        }

        static private void LoginPlayerTwo()
        {
            Console.WriteLine("\nLogin player two");

            string loginPlayerTwo = Console.ReadLine();

            try
            {
                string MyConnection2 = "server = 127.0.0.1; user id = Chess; password = Pa$$W0rd; database = chess";
                string Query = "INSERT INTO userplayer (NAME) VALUES ('" + loginPlayerTwo + "');";

                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                
                MyReader2 = MyCommand2.ExecuteReader();
                Console.WriteLine("Save");
                while (MyReader2.Read())
                {

                }
                MyConn2.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not open connection ! ");
                //Console.WriteLine(ex.Message);
                Console.WriteLine(" Press any key to continue...\n");
                Console.ReadKey();
            }
        }
    }
}
