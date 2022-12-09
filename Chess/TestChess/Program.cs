using System;
using System.Threading;
using System.Runtime.CompilerServices;
using Table;

public class Program
{
    
   static string[,] tabCases = new string[,] { { "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8" }, { "B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8" }, { "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8" }, { "D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8" }, { "E1", "E2", "E3", "E4", "E5", "E6", "E7", "E8" }, { "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8" }, { "G1", "G2", "G3", "G4", "G5", "G6", "G7", "G8" }, { "H1", "H2", "H3", "H4", "H5", "H6", "H7", "H8" } };
   static string[,] tabPawn = new string[,] { { "R", "N", "B", "Q", "K", "B", "N", "R" }, { "P", "P", "P", "P", "P", "P", "P", "P" }, { " ", " ", " ", " ", " ", " ", " ", " " }, { " ", " ", " ", " ", " ", " ", " ", " " }, { " ", " ", " ", " ", " ", " ", " ", " " }, { " ", " ", " ", " ", " ", " ", " ", " " }, { "p", "p", "p", "p", "p", "p", "p", "p" }, { "r", "n", "b", "q", "k", "b", "n", "r" } };

    static void Main(string[] args)
    {
        for (int i = 0;i<=10;i++) { 
        afficher();
        pion();
        }

    }
    
    static private void pion()
    {
        string position = Console.ReadLine();

        string positionBase = position.Split("-")[0];
        string positionFin = position.Split("-")[1];

        //  MessageBox.Show("position de base: " + positionBase + " position de fin: " + positionFin);

        string positionFinString = positionFin.Substring(1);
        string positionBaseString = positionBase.Substring(1);

        //Définir position de fin string et position de base string en int
        int numFin = int.Parse(positionFinString);
        int numBase = int.Parse(positionBaseString);

        string a = coordonnees(positionBase);
        //Console.WriteLine(a+" Base");

        // Position de Base ex. A2 = x:0 et y:1
        int xBase = int.Parse(a.Split("-")[0]);
        int yBase = int.Parse(a.Split("-")[1]);

        string b = coordonnees(positionFin);
        //Console.WriteLine(b+" Fin");

        // Position de Fin ex. A2 = x:0 et y:1
        int xFin = int.Parse(b.Split("-")[0]);
        int yFin = int.Parse(b.Split("-")[1]);
        
        //Trouver la pièce qui correspond au cooronnées
        string pieceBase = tabPawn[yBase, xBase];
        string pieceFin = tabPawn[yFin, xFin];
        //Console.WriteLine(pieceBase+"-"+pieceFin);

        switch (pieceBase)
        {
            case "P":
                if (numBase > numFin)
                {
                    Console.WriteLine("\nErreur: le pion ne peu pas reculer");
                    Console.ReadKey();
                }
                else
                {
                    //Si une pièce est devant alors il peut pas avencer
                    if(pieceFin==" ") { 
                        //Console.WriteLine(yBase + "-" + yFin);
                        if (yBase == 1 && yFin == 3)
                        {
                            tabPawn[yFin, xFin] = "P";
                            tabPawn[yBase, xBase] = " ";
                        }
                        else
                        {
                            if (yBase + 1 == yFin)
                            {
                                tabPawn[yFin, xFin] = "P";
                                tabPawn[yBase, xBase] = " ";
                            }
                            else
                            {
                                Console.WriteLine("\nErreur: le pion ne peu pas avancer de plus de 2 cases");
                                Console.ReadKey();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nErreur: le pion ne peu pas avancer car il y a une pièce devant");
                        Console.ReadKey();
                    }
                }
                break;
        }
    }
    static private string coordonnees(string pos)
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 7; y++)
            {
                if (tabCases[x, y] == pos)
                {
                    //Console.WriteLine(tableau[x, y]);
                    return (x + "-" + y).ToString();
                }
            }
        }
        return "404";
    }

    static private void afficher()
    {
        Console.Clear();
        Console.Write("   ╔═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╗\n");
        for (int x = 7; x >= 0; x--)
        {
            Console.Write(" "+(x+1));
            for (int y = 0; y < 8; y++)
            {
                Console.Write(" ║ ");
                Console.Write(tabPawn[x,y]);
            }
            Console.WriteLine(" ║");
            if (x != 0)
            {
                Console.WriteLine("   ╠═══╬═══╬═══╬═══╬═══╬═══╬═══╬═══╣");
            }
        }
        Console.Write("   ╚═══╩═══╩═══╩═══╩═══╩═══╩═══╩═══╝\n");
        Console.Write("     A   B   C   D   E   F   G   H  \n");
        Console.Write("\n ► ");
    }
}
