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
                //ConnectionDB();
                string menuChoise = Console.ReadLine();
                switch (menuChoise)
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
                        Console.Clear();
                        DisplayRules();

                        switch (Console.ReadLine())
                        {
                            case "1":
                                Console.Clear();
                                DisplayRulesMore();
                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        Console.Clear();
                                        DisplayPawn();
                                        Console.ReadKey();
                                        break;
                                    case "2":
                                        Console.Clear();
                                        DisplayTower();
                                        Console.ReadKey();
                                        break;
                                    case "3":
                                        Console.Clear();
                                        DisplayKnight();
                                        Console.ReadKey();
                                        break;
                                    case "4":
                                        Console.Clear();
                                        DisplayBishop();
                                        Console.ReadKey();
                                        break;
                                    case "5":
                                        Console.Clear();
                                        DisplayQueen();
                                        Console.ReadKey();
                                        break;
                                    case "6":
                                        Console.Clear();
                                        DisplayKing();
                                        Console.ReadKey();
                                        break;
                                    case "7":
                                        Console.Clear();
                                        DisplayRules();
                                        break;
                                }
                                break;
                        }
                        break;
                    case "4":
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
            Console.WriteLine(" ║ Rules     : 3 ║");
            Console.WriteLine(" ╚═══════════════╝\n");
            Console.WriteLine(" ╔═══════════════╗");
            Console.WriteLine(" ║ Quit      : 4 ║");
            Console.WriteLine(" ╚═══════════════╝\n");
            Console.Write(" ► ");
        }

        static void DisplayRules()
        {
            Console.WriteLine(" ╔═══════════════╗");
            Console.WriteLine(" ║     Rules     ║");
            Console.WriteLine(" ╚═══════════════╝\n");
            Console.WriteLine(" 1: Enter the coordinates in this format A1-A2 or A1 A2. \n A1 is the starting position and A2 is the ending position.");
            Console.WriteLine("\n ╔═══════════════╗");
            Console.WriteLine(" ║ More ?    :1  ║");
            Console.WriteLine(" ╚═══════════════╝\n");
            Console.WriteLine(" ╔═══════════════╗");
            Console.WriteLine(" ║ Quit      :2  ║");
            Console.WriteLine(" ╚═══════════════╝\n");
            Console.Write(" ► ");
        }

        static void DisplayRulesMore() { 
            Console.WriteLine(" ╔═══════════════╗");
            Console.WriteLine(" ║ Pawn      :1  ║");
            Console.WriteLine(" ╚═══════════════╝\n");
            Console.WriteLine(" ╔═══════════════╗");
            Console.WriteLine(" ║ Tower     :2  ║");
            Console.WriteLine(" ╚═══════════════╝\n");
            Console.WriteLine(" ╔═══════════════╗");
            Console.WriteLine(" ║ Knight    :3  ║");
            Console.WriteLine(" ╚═══════════════╝\n");
            Console.WriteLine(" ╔═══════════════╗");
            Console.WriteLine(" ║ Bishop    :4  ║");
            Console.WriteLine(" ╚═══════════════╝\n");
            Console.WriteLine(" ╔═══════════════╗");
            Console.WriteLine(" ║ Queen     :5  ║");
            Console.WriteLine(" ╚═══════════════╝\n");
            Console.WriteLine(" ╔═══════════════╗");
            Console.WriteLine(" ║ King      :6  ║");
            Console.WriteLine(" ╚═══════════════╝\n");
            Console.Write(" ► ");
        }

        static void DisplayPawn()
        {
            Console.WriteLine("   ╔═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╗");
            Console.WriteLine(" 8 ║   ║   ║   ║   ║   ║   ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 7 ║   ║   ║   ║   ║   ║   ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 6 ║   ║   ║   ║   ║   ║   ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 5 ║   ║   ║   ║ █ ║   ║   ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 4 ║   ║   ║   ║ P ║   ║   ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 3 ║   ║   ║   ║   ║   ║   ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 2 ║   ║   ║   ║   ║   ║   ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 1 ║   ║   ║   ║   ║   ║   ║   ║   ║");
            Console.WriteLine("   ╚═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╝");
            Console.WriteLine("     A   B   C   D   E   F   G   H  \n");
        }

        static void DisplayTower()
        {
            Console.WriteLine("   ╔═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╗");
            Console.WriteLine(" 8 ║   ║   ║   ║ █ ║   ║   ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 7 ║   ║   ║   ║ █ ║   ║   ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 6 ║   ║   ║   ║ █ ║   ║   ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 5 ║   ║   ║   ║ █ ║   ║   ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 4 ║ █ ║ █ ║ █ ║ R ║ █ ║ █ ║ █ ║ █ ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 3 ║   ║   ║   ║ █ ║   ║   ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 2 ║   ║   ║   ║ █ ║   ║   ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 1 ║   ║   ║   ║ █ ║   ║   ║   ║   ║");
            Console.WriteLine("   ╚═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╝");
            Console.WriteLine("     A   B   C   D   E   F   G   H  \n");
        }

        static void DisplayKnight()
        {
            Console.WriteLine("   ╔═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╗");
            Console.WriteLine(" 8 ║   ║   ║   ║   ║   ║   ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 7 ║   ║   ║   ║   ║   ║   ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 6 ║   ║   ║ █ ║   ║ █ ║   ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 5 ║   ║ █ ║   ║   ║   ║ █ ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 4 ║   ║   ║   ║ N ║   ║   ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 3 ║   ║ █ ║   ║   ║   ║ █ ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 2 ║   ║   ║ █ ║   ║ █ ║   ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 1 ║   ║   ║   ║   ║   ║   ║   ║   ║");
            Console.WriteLine("   ╚═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╝");
            Console.WriteLine("     A   B   C   D   E   F   G   H  \n");
        }

        static void DisplayBishop()
        {
            Console.WriteLine("   ╔═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╗");
            Console.WriteLine(" 8 ║   ║   ║   ║   ║   ║   ║   ║ █ ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 7 ║ █ ║   ║   ║   ║   ║   ║ █ ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 6 ║   ║ █ ║   ║   ║   ║ █ ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 5 ║   ║   ║ █ ║   ║ █ ║   ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 4 ║   ║   ║   ║ B ║   ║   ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 3 ║   ║   ║ █ ║   ║ █ ║   ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 2 ║   ║ █ ║   ║   ║   ║ █ ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 1 ║ █ ║   ║   ║   ║   ║   ║ █ ║   ║");
            Console.WriteLine("   ╚═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╝");
            Console.WriteLine("     A   B   C   D   E   F   G   H  \n");
        }

        static void DisplayQueen()
        {
            Console.WriteLine("   ╔═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╗");
            Console.WriteLine(" 8 ║   ║   ║   ║ █ ║   ║   ║   ║ █ ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 7 ║ █ ║   ║   ║ █ ║   ║   ║ █ ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 6 ║   ║ █ ║   ║ █ ║   ║ █ ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 5 ║   ║   ║ █ ║ █ ║ █ ║   ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 4 ║ █ ║ █ ║ █ ║ Q ║ █ ║ █ ║ █ ║ █ ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 3 ║   ║   ║ █ ║ █ ║ █ ║   ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 2 ║   ║ █ ║   ║ █ ║   ║ █ ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 1 ║ █ ║   ║   ║ █ ║   ║   ║ █ ║   ║");
            Console.WriteLine("   ╚═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╝");
            Console.WriteLine("     A   B   C   D   E   F   G   H  \n");
        }

        static void DisplayKing()
        {
            Console.WriteLine("   ╔═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╗");
            Console.WriteLine(" 8 ║   ║   ║   ║   ║   ║   ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 7 ║   ║   ║   ║   ║   ║   ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 6 ║   ║   ║   ║   ║   ║   ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 5 ║   ║   ║ █ ║ █ ║ █ ║   ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 4 ║   ║   ║ █ ║ K ║ █ ║   ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 3 ║   ║   ║ █ ║ █ ║ █ ║   ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 2 ║   ║   ║   ║   ║   ║   ║   ║   ║");
            Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            Console.WriteLine(" 1 ║   ║   ║   ║   ║   ║   ║   ║   ║");
            Console.WriteLine("   ╚═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╝");
            Console.WriteLine("     A   B   C   D   E   F   G   H  \n");
        }

        static private void LoginPlayerOne()
        {
            Console.Clear();
            Console.WriteLine("\nLogin player one");
            Console.Write(" ► ");

            string loginPlayerOne = Console.ReadLine();

            try
            {
                string myInfoConnection = "server = 127.0.0.1; user id = Chess; password = Pa$$W0rd; database = chess";
                string query = "INSERT INTO userplayer (NAME) VALUES ('" + loginPlayerOne + "');";

                MySqlConnection myConnection = new MySqlConnection(myInfoConnection);
                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                MySqlDataReader myReader;
                myConnection.Open();
                myReader = myCommand.ExecuteReader();
                Console.WriteLine("Save");

                while (myReader.Read())
                {

                }
                myReader.Close();
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
            Console.Clear();
            Console.WriteLine("\nLogin player two");
            Console.Write(" ► ");
            string loginPlayerTwo = Console.ReadLine();

            try
            {
                string myInfoConnection = "server = 127.0.0.1; user id = Chess; password = Pa$$W0rd; database = chess";
                string query = "INSERT INTO userplayer (NAME) VALUES ('" + loginPlayerTwo + "');";

                MySqlConnection myConnection = new MySqlConnection(myInfoConnection);
                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                MySqlDataReader myReader;
                myConnection.Open();

                myReader = myCommand.ExecuteReader();
                Console.WriteLine("Save");
                while (myReader.Read())
                {

                }
                myReader.Close();
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
