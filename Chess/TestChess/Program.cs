using System;
using System.Threading;
using System.Runtime.CompilerServices;
using GameTest;

public class Program
{
    static void Main(string[] args)
    {
        while (true) {
            Console.Clear();
            AfficherMenu();
            string choix = Console.ReadLine();
            switch (choix)
            {
                case "1":
                    PlayGame game = new PlayGame();
                    game.Game();
                    break;
                case "2":
                    Console.WriteLine("\n En construction\n");
                    Console.WriteLine(" Appuyer sur n'importe quelle touche pour continuer...\n");
                    Console.ReadKey();
                    break;
                case "3":
                    return;
            }
        }
    }

    static private void AfficherMenu()
    {
        Console.WriteLine("\n ╔══════════════╗");
        Console.WriteLine(" ║ Jouer    : 1 ║");
        Console.WriteLine(" ╚══════════════╝\n");
        Console.WriteLine(" ╔══════════════╗");
        Console.WriteLine(" ║ Info     : 2 ║");
        Console.WriteLine(" ╚══════════════╝\n");
        Console.WriteLine(" ╔══════════════╗");
        Console.WriteLine(" ║ Quitter  : 3 ║");
        Console.WriteLine(" ╚══════════════╝\n");
        Console.Write(" ► ");
    }
}
