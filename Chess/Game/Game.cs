using System.Security.Cryptography;
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
                        //pawn
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
                                if (xFin != xBase)
                                {
                                    tableCase.TabPawn[yFin, xFin] = "P";
                                    tableCase.TabPawn[yBase, xBase] = " ";
                                }
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
                                        if (yBase == yFin)
                                        {
                                            Console.WriteLine("\nErreur: le pion ne peu pas ne pas avancer");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nErreur: le pion ne peu pas avancer car il y a une pièce devant");
                                            Console.ReadKey();
                                        }
                                    }
                                }
                            }
                        }
                        break;
                        //tower
                  case "R":
                        if (xBase != xFin && yBase != yFin)
                        {
                            Console.WriteLine("\nErreur: la tour ne peu pas avancer en diagonale");
                            Console.ReadKey();
                        }
                        else
                        {
                            string towerDirection = "";

                            if (xBase == xFin)
                            {
                                if (yBase > yFin)
                                {
                                    towerDirection = "down";
                                }
                                else
                                {
                                    towerDirection = "up";
                                }
                            }
                            else
                            {
                                if (xBase > xFin)
                                {
                                    towerDirection = "left";
                                }
                                else
                                {
                                    towerDirection = "right";
                                }
                            }

                            //Console.WriteLine(towerDirection);
                            //Console.ReadKey();

                            switch (towerDirection)
                            {
                                case "up":
                                 for(int i = yBase + 1; i != yFin; i++)
                                    {
                                        if (tableCase.TabPawn[i, xFin] != " ")
                                        {
                                            Console.WriteLine("\nErreur: la tour ne peu pas avancer car il y a une pièce devant");
                                            Console.ReadKey();
                                            return false;
                                        }
                                    }
                                    break;
                                    
                                case "down":
                                    for (int i = yBase - 1; i != yFin; i--)
                                    {
                                        if (tableCase.TabPawn[i, xFin] != " ")
                                        {
                                            Console.WriteLine("\nErreur: la tour ne peu pas avancer car il y a une pièce devant");
                                            Console.ReadKey();
                                            return false;
                                        }
                                    }

                                    break;
                                    
                                case "right":
                                    for (int i = xBase + 1; i != xFin; i++)
                                    {
                                        if (tableCase.TabPawn[yFin, i] != " ")
                                        {
                                            Console.WriteLine("\nErreur: la tour ne peu pas avancer car il y a une pièce devant");
                                            Console.ReadKey();
                                            return false;
                                        }
                                    }
                                    break;
                                    
                                case "left":
                                    for (int i = xBase - 1; i != xFin; i--)
                                    {
                                        if (tableCase.TabPawn[yFin, i] != " ")
                                        {
                                            Console.WriteLine("\nErreur: la tour ne peu pas avancer car il y a une pièce devant");
                                            Console.ReadKey();
                                            return false;
                                        }
                                    }
                                    break;
                            }
                            if (endPawn == " ")
                            {
                                tableCase.TabPawn[yFin, xFin] = "R";
                                tableCase.TabPawn[yBase, xBase] = " ";
                            }
                            else
                            {
                                if (tableCase.TabPawn[yFin, xFin] == "p" || tableCase.TabPawn[yFin, xFin] == "r" || tableCase.TabPawn[yFin, xFin] == "n" || tableCase.TabPawn[yFin, xFin] == "b" || tableCase.TabPawn[yFin, xFin] == "q" || tableCase.TabPawn[yFin, xFin] == "k")
                                {
                                    tableCase.TabPawn[yFin, xFin] = "R";
                                    tableCase.TabPawn[yBase, xBase] = " ";
                                }
                                else
                                {
                                    Console.WriteLine("\nErreur: Vous pouvez pas manger vos propre pièces");
                                    Console.ReadKey();
                                }
                            }
                        }
                        break;
                        //bishop
                case "B":

                        int diff = 0;
                        string direction = "N";

                        if (xBase < xFin)
                        {
                            diff = xBase - xFin;
                            direction = "DB";

                            if (yBase < yFin)
                            {
                                direction = "DH";
                            }
                        }
                        else
                        {
                            diff = xFin - xBase;
                            direction = "GB";

                            if (yBase < yFin)
                            {
                                direction="GH";   
                            }
                        }
                        //Console.WriteLine(direction);
                        //Console.ReadKey();
                        

                        if ((diff == yFin - yBase)||(diff == yBase - yFin))
                        {
                            int x = xBase;
                            int y = yBase;
                            int end = 0;
                            switch (direction)
                            {
                                case "DB":
                                    while (end != 1)
                                    {
                                        x++;
                                        y--;
                                        if (tableCase.TabPawn[y, x] != " ")
                                        {
                                            Console.WriteLine("\nErreur: le fou ne peu pas sauter par dessus une pièce");
                                            Console.ReadKey();
                                           // end = 1;
                                            return false;
                                        }

                                        if (y != yFin && x != xFin)
                                        {
                                            end = 1;
                                        }
                                    }
                                    break;

                                case "DH":
                                    while (end != 1)
                                    {
                                        x++;
                                        y++;
                                        if (tableCase.TabPawn[y, x] != " ")
                                        {
                                            Console.WriteLine("\nErreur: le fou ne peu pas sauter par dessus une pièce");
                                            Console.ReadKey();
                                            //end = 1;
                                            return false;
                                        }

                                        if (y != yFin && x != xFin)
                                        {
                                            end = 1;
                                        }
                                    }
                                    break;

                                case "GB":
                                    while (end != 1)
                                    {
                                        x--;
                                        y--;
                                        if (tableCase.TabPawn[y, x] != " ")
                                        {
                                            Console.WriteLine("\nErreur: le fou ne peu pas sauter par dessus une pièce");
                                            Console.ReadKey();
                                           // end = 1;
                                            return false;
                                        }

                                        if (y != yFin && x != xFin)
                                        {
                                            end = 1;
                                        }
                                    }
                                    break;

                                case "GH":
                                    while (end != 1)
                                    {
                                        x--;
                                        y++;
                                        if (tableCase.TabPawn[y, x] != " ")
                                        {
                                            Console.WriteLine("\nErreur: le fou ne peu pas sauter par dessus une pièce");
                                            Console.ReadKey();
                                           // end = 1;
                                            return false;
                                        }

                                        if (y != yFin && x != xFin)
                                        {
                                            end = 1;
                                        }
                                    }
                                    break;
                                default:
                                    Console.WriteLine("errreur");
                                    Console.ReadKey();
                                    return false;
                            }

                            if (endPawn == " ")
                            {
                                tableCase.TabPawn[yFin, xFin] = "B";
                                tableCase.TabPawn[yBase, xBase] = " ";
                            }
                            else
                            {
                                if (tableCase.TabPawn[yFin, xFin] == "p" || tableCase.TabPawn[yFin, xFin] == "r" || tableCase.TabPawn[yFin, xFin] == "n" || tableCase.TabPawn[yFin, xFin] == "b" || tableCase.TabPawn[yFin, xFin] == "q" || tableCase.TabPawn[yFin, xFin] == "k")
                                {
                                    tableCase.TabPawn[yFin, xFin] = "B";
                                    tableCase.TabPawn[yBase, xBase] = " ";
                                }
                                else
                                {
                                    Console.WriteLine("\nErreur: Vous pouvez pas manger vos propre pièces");
                                    Console.ReadKey();
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nErreur: Vous pouvez pas ne pas aller en diagonale");
                            Console.ReadKey();
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