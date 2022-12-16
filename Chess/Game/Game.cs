using System.Text.RegularExpressions;
using TableGame;
using static Google.Protobuf.WellKnownTypes.Field.Types;

namespace Game
{
    public class PlayGame
    {
        private Table tableCase = new Table();

        public void Game()
        {
            bool endGame = false;
            do{
                DiplayTable();
                endGame = Player();
            } while (endGame == false);
        }

        // Used to find the specific coordinates of a case
        // Example input A1 output x = 0, y = 0 
        private string CoordinatesTwoArrays(string searchPositionTabCase)
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y <= 7; y++)
                {
                    if (tableCase.TabCase[x,y] == searchPositionTabCase)
                    {
                        //Console.WriteLine(tableau[x, y]);
                        return (x + "-" + y).ToString();
                    }
                }
            }
            return "404";
        }

        // Used to display the table
        private void DiplayTable()
        {
            Console.Clear();
            Console.Write("   ╔═══╦═══╦═══╦═══╦═══╦═══╦═══╦═══╗\n");
            for (int x = 7; x >= 0; x--)
            {
                Console.Write(" " + (x + 1));
                for (int y = 0; y < 8; y++)
                {
                    Console.Write(" ║ ");
                    Console.Write(tableCase.TabPawn[x,y]);
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

        private bool Player()
        {
            string startPosition = Console.ReadLine();

            // If Q > return to the menu else play game
            if ((startPosition != "Q") && (startPosition != "q"))
            {
                string basicPosition = startPosition.Split("-")[0];
                string endPosition = startPosition.Split("-")[1];

                // MessageBox.Show("position de base: " + positionBase + " position de fin: " + positionFin);

                string endPositionnString = endPosition.Substring(1);
                string basicPositioString = basicPosition.Substring(1);

                // Set position of endNum string and position of basicNum string to int
                int endNum = int.Parse(endPositionnString);
                int basicNum = int.Parse(basicPositioString);

                string searchCoordinateA = CoordinatesTwoArrays(basicPosition);
                // Console.WriteLine(a+" Base");

                // Basic Position ex. A2 = x:0 et y:1
                int xBase = int.Parse(searchCoordinateA.Split("-")[0]);
                int yBase = int.Parse(searchCoordinateA.Split("-")[1]);

                string searchCoordinateB = CoordinatesTwoArrays(endPosition);
                // Console.WriteLine(b+" Fin");

                // End Position ex. A2 = x:0 et y:1
                int xFin = int.Parse(searchCoordinateB.Split("-")[0]);
                int yFin = int.Parse(searchCoordinateB.Split("-")[1]);

                // Find the pawn that matches the coordinates
                string basicPawn = tableCase.TabPawn[yBase, xBase];
                string endPawn = tableCase.TabPawn[yFin, xFin];
                //Console.WriteLine(pieceBase+"-"+pieceFin);

                switch (basicPawn)
                {
                    case "P":
                        if (basicNum > endNum)
                        {
                            Console.WriteLine("\nErreur: le pion ne peu pas reculer");
                            Console.ReadKey();
                        }
                        else
                        {
                            if (tableCase.TabPawn[yFin, xFin] == "p" || tableCase.TabPawn[yFin, xFin] == "r" || tableCase.TabPawn[yFin, xFin] == "n" || tableCase.TabPawn[yFin, xFin] == "b" || tableCase.TabPawn[yFin, xFin] == "q" || tableCase.TabPawn[yFin, xFin] == "k")
                            {
                                tableCase.TabPawn[yFin, xFin] = "P";
                                tableCase.TabPawn[yBase, xBase] = " ";
                            }
                            else
                            {
                                if (xFin != xBase)
                                {
                                    Console.WriteLine("\nErreur: le pion ne peut que avancer tout droit");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    //  Si une pièce est devant alors il peut pas avencer
                                    if (endPawn == " ")
                                    {
                                        //Console.WriteLine(yBase + "-" + yFin);
                                        if (yBase == 1 && yFin == 3)
                                        {
                                            tableCase.TabPawn[yFin, xFin] = "P";
                                            tableCase.TabPawn[yBase, xBase] = " ";
                                        }
                                        else
                                        {
                                            if (yBase + 1 == yFin)
                                            {
                                                tableCase.TabPawn[yFin, xFin] = "P";
                                                tableCase.TabPawn[yBase, xBase] = " ";
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
                            }
                        }
                        break;
                }
                return false;
            }
            else
            {
                // Return to the menu
                return true;
            }
        }
    }
}