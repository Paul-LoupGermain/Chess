using System;
using System.Threading;
using System.Runtime.CompilerServices;
using Game;
using MySql.Data.MySqlClient;
using System.Net.Sockets;

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
            openningDB.ConnectionString = "server = 127.0.0.1; user id = root; password = Pa$$w0rd; database = chess";

            try
            {
                openningDB.Open();
                Console.WriteLine("Connection Open!");
                openningDB.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not open connection ! ");
            }
        }
    }
}
