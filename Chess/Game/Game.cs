using Org.BouncyCastle.Asn1;
using System.Globalization;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
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
            bool endGameTwo = false;
            int resultGame = 3;
            int resultGameTwo = 3;
            do
            {
                DiplayTable();

                if (resultGame == 3)
                {
                    do
                    {
                        resultGame = Player();
                        Console.Clear();
                        DiplayTable();
                    } while (resultGame == 1);
                }

                if (resultGame == 1)
                {
                    do
                    {
                        resultGame = Player();
                        Console.Clear();
                        DiplayTable();
                    } while (resultGame == 0);
                }

                if (resultGame == 0)
                {
                    do
                    {
                        resultGameTwo = PlayerTwo();
                        Console.Clear();
                        DiplayTable();
                    } while (resultGameTwo == 1);
                }

                if (resultGameTwo == 1)
                {
                    do
                    {
                        resultGameTwo = PlayerTwo();
                        Console.Clear();
                        DiplayTable();
                    } while (resultGameTwo == 0);
                }

                if (resultGameTwo == 0)
                {
                    do
                    {
                        resultGame = Player();
                        Console.Clear();
                        DiplayTable();
                    } while (resultGame == 1);
                }

                if (resultGame == 2 || resultGameTwo == 2)
                {
                    endGame = true;
                    endGameTwo = true;
                }

            } while (endGame == false || endGameTwo == false);
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

        private int Player()
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
                        Console.WriteLine("\nError: the pawn cannot retreat");
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
                                return 0;
                            }
                        }
                        else
                        {
                            if (xFin != xBase)
                            {
                                Console.WriteLine("\nError: the pawn can only move forward");
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
                                        return 0;
                                    }
                                    else
                                    {
                                        if (yBase + 1 == yFin)
                                        {
                                            tableCase.TabPawn[yFin, xFin] = "P";
                                            tableCase.TabPawn[yBase, xBase] = " ";
                                            return 0;
                                        }
                                        else
                                        {
                                                error("pawn", 1);
                                            }
                                    }
                                }
                                else
                                {
                                    if (yBase == yFin)
                                    {
                                        Console.WriteLine("\nError: the pawn cannot not advance");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        error("pawn", 1);
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
                        Console.WriteLine("\nError: tower cannot move diagonally");
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
                                        error("tower", 1);
                                        return 1;
                                    }
                                }
                                break;
                                    
                            case "down":
                                for (int i = yBase - 1; i != yFin; i--)
                                {
                                    if (tableCase.TabPawn[i, xFin] != " ")
                                    {
                                        error("tower", 1);
                                        return 1;
                                    }
                                }

                                break;
                                    
                            case "right":
                                for (int i = xBase + 1; i != xFin; i++)
                                {
                                    if (tableCase.TabPawn[yFin, i] != " ")
                                    {
                                        error("tower", 1);
                                        return 1;
                                    }
                                }
                                break;
                                    
                            case "left":
                                for (int i = xBase - 1; i != xFin; i--)
                                {
                                    if (tableCase.TabPawn[yFin, i] != " ")
                                    {
                                        error("tower", 1);
                                        return 1;
                                    }
                                }
                                break;
                        }
                        if (endPawn == " ")
                        {
                            tableCase.TabPawn[yFin, xFin] = "R";
                            tableCase.TabPawn[yBase, xBase] = " ";
                            return 0;
                        }
                        else
                        {
                            if (tableCase.TabPawn[yFin, xFin] == "p" || tableCase.TabPawn[yFin, xFin] == "r" || tableCase.TabPawn[yFin, xFin] == "n" || tableCase.TabPawn[yFin, xFin] == "b" || tableCase.TabPawn[yFin, xFin] == "q" || tableCase.TabPawn[yFin, xFin] == "k")
                            {
                                tableCase.TabPawn[yFin, xFin] = "R";
                                tableCase.TabPawn[yBase, xBase] = " ";
                                return 0;
                            }
                            else
                            {
                                Console.WriteLine("\nError: You can't eat your own coins");
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
                                        error("bishop", 2);
                                        return 1;
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
                                        error("bishop", 2);
                                        return 1;
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
                                        error("bishop",2);                                      
                                        return 1;
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
                                        error("bishop", 2);
                                        return 1;
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
                                return 1;
                        }

                        if (endPawn == " ")
                        {
                            tableCase.TabPawn[yFin, xFin] = "B";
                            tableCase.TabPawn[yBase, xBase] = " ";
                            return 0;
                        }
                        else
                        {
                            if (tableCase.TabPawn[yFin, xFin] == "p" || tableCase.TabPawn[yFin, xFin] == "r" || tableCase.TabPawn[yFin, xFin] == "n" || tableCase.TabPawn[yFin, xFin] == "b" || tableCase.TabPawn[yFin, xFin] == "q" || tableCase.TabPawn[yFin, xFin] == "k")
                            {
                                tableCase.TabPawn[yFin, xFin] = "B";
                                tableCase.TabPawn[yBase, xBase] = " ";
                                return 0;
                            }
                            else
                            {
                                Console.WriteLine("\nError: You can't eat your own coins");
                                Console.ReadKey();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nError: You can't not go diagonally");
                        Console.ReadKey();
                    }
                    break;
                        
                    //king
                case "K":
                    if (xFin == xBase && yFin == yBase)
                    {
                        Console.WriteLine("\nError: You can't stay on the same case");
                        Console.ReadKey();
                        return 0;
                    }
                    else
                    {
                        if (xFin == xBase || yFin == yBase)
                        {
                            if (endPawn == " ")
                            {
                                tableCase.TabPawn[yFin, xFin] = "K";
                                tableCase.TabPawn[yBase, xBase] = " ";   
                            }
                            else
                            {
                                if (tableCase.TabPawn[yFin, xFin] == "p" || tableCase.TabPawn[yFin, xFin] == "r" || tableCase.TabPawn[yFin, xFin] == "n" || tableCase.TabPawn[yFin, xFin] == "b" || tableCase.TabPawn[yFin, xFin] == "q" || tableCase.TabPawn[yFin, xFin] == "k")
                                {
                                    tableCase.TabPawn[yFin, xFin] = "K";
                                    tableCase.TabPawn[yBase, xBase] = " ";
                                }
                                else
                                {
                                    Console.WriteLine("\nError: You can't eat your own coins");
                                    Console.ReadKey();
                                    return 0;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nError: You can't not go diagonally");
                            Console.ReadKey();
                            return 0;
                        }
                    }
                    break;
                        
                    //queen
                case "Q":
                        if (xBase != xFin && yBase != yFin)
                        {
                            int diffQ = 0;
                            string directionQ = "N";

                            if (xBase < xFin)
                            {
                                diffQ = xBase - xFin;
                                directionQ = "DB";

                                if (yBase < yFin)
                                {
                                    directionQ = "DH";
                                }
                            }
                            else
                            {
                                diffQ = xFin - xBase;
                                directionQ = "GB";

                                if (yBase < yFin)
                                {
                                    directionQ = "GH";
                                }
                            }
                            //Console.WriteLine(direction);
                            //Console.ReadKey();


                            if ((diffQ == yFin - yBase) || (diffQ == yBase - yFin))
                            {
                                int x = xBase;
                                int y = yBase;
                                int end = 0;
                                switch (directionQ)
                                {
                                    case "DB":
                                        while (end != 1)
                                        {
                                            x++;
                                            y--;
                                            if (tableCase.TabPawn[y, x] != " ")
                                            {
                                                error("queen",2);
                                                return 1;
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
                                                error("queen",2);
                                                return 1;
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
                                                error("queen",2);
                                                return 1;
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
                                                error("queen",2);
                                                return 1;
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
                                        return 1;
                                }

                                if (endPawn == " ")
                                {
                                    tableCase.TabPawn[yFin, xFin] = "B";
                                    tableCase.TabPawn[yBase, xBase] = " ";
                                    return 0;
                                }
                                else
                                {
                                    if (tableCase.TabPawn[yFin, xFin] == "p" || tableCase.TabPawn[yFin, xFin] == "r" || tableCase.TabPawn[yFin, xFin] == "n" || tableCase.TabPawn[yFin, xFin] == "b" || tableCase.TabPawn[yFin, xFin] == "q" || tableCase.TabPawn[yFin, xFin] == "k")
                                    {
                                        tableCase.TabPawn[yFin, xFin] = "B";
                                        tableCase.TabPawn[yBase, xBase] = " ";
                                        return 0;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nError: You can't eat your own coins");
                                        Console.ReadKey();
                                    }
                                }
                            }
                        }
                        else
                        {
                            string queenDirection = "";

                            if (xBase == xFin)
                            {
                                if (yBase > yFin)
                                {
                                    queenDirection = "down";
                                }
                                else
                                {
                                    queenDirection = "up";
                                }
                            }
                            else
                            {
                                if (xBase > xFin)
                                {
                                    queenDirection = "left";
                                }
                                else
                                {
                                    queenDirection = "right";
                                }
                            }

                            //Console.WriteLine(towerDirection);
                            //Console.ReadKey();

                            switch (queenDirection)
                            {
                                case "up":
                                    for (int i = yBase + 1; i != yFin; i++)
                                    {
                                        if (tableCase.TabPawn[i, xFin] != " ")
                                        {
                                            error("queen",1);
                                            return 1;
                                        }
                                    }
                                    break;

                                case "down":
                                    for (int i = yBase - 1; i != yFin; i--)
                                    {
                                        if (tableCase.TabPawn[i, xFin] != " ")
                                        {
                                            error("queen",1);
                                            return 1;
                                        }
                                    }

                                    break;

                                case "right":
                                    for (int i = xBase + 1; i != xFin; i++)
                                    {
                                        if (tableCase.TabPawn[yFin, i] != " ")
                                        {
                                            error("queen",1);
                                            return 1;
                                        }
                                    }
                                    break;

                                case "left":
                                    for (int i = xBase - 1; i != xFin; i--)
                                    {
                                        if (tableCase.TabPawn[yFin, i] != " ")
                                        {
                                            error("queen",1);
                                            return 1;
                                        }
                                    }
                                    break;
                            }
                            if (endPawn == " ")
                            {
                                tableCase.TabPawn[yFin, xFin] = "Q";
                                tableCase.TabPawn[yBase, xBase] = " ";
                                return 0;
                            }
                            else
                            {
                                if (tableCase.TabPawn[yFin, xFin] == "p" || tableCase.TabPawn[yFin, xFin] == "r" || tableCase.TabPawn[yFin, xFin] == "n" || tableCase.TabPawn[yFin, xFin] == "b" || tableCase.TabPawn[yFin, xFin] == "q" || tableCase.TabPawn[yFin, xFin] == "k")
                                {
                                    tableCase.TabPawn[yFin, xFin] = "Q";
                                    tableCase.TabPawn[yBase, xBase] = " ";
                                    return 0;
                                }
                                else
                                {
                                    Console.WriteLine("\nError: You can't eat your own coins");
                                    Console.ReadKey();
                                }
                            }
                        }
                        break;
                }
                return 1;
            }
            else
            {
                // Return to the menu
                return 2;
            }
        }

        private void error(string piece, int num)
        {
            switch (num)
            {
                case 1:
                    Console.WriteLine("\nError: the "+piece+" cannot move because there is a piece in front");
                    break;
                    
                case 2:
                    Console.WriteLine("\nErreur: the "+piece+ " can't jump over a piece");
                    break;
            }
            Console.ReadKey();
        }

        private int PlayerTwo()
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
                    case "p":
                        if (basicNum < endNum)
                        {
                            Console.WriteLine("\nError: the pawn cannot retreat");
                            Console.ReadKey();
                        }
                        else
                        {
                            if (tableCase.TabPawn[yFin, xFin] == "P" || tableCase.TabPawn[yFin, xFin] == "R" || tableCase.TabPawn[yFin, xFin] == "N" || tableCase.TabPawn[yFin, xFin] == "B" || tableCase.TabPawn[yFin, xFin] == "Q" || tableCase.TabPawn[yFin, xFin] == "K")
                            {
                                if (xFin != xBase)
                                {
                                    tableCase.TabPawn[yFin, xFin] = "p";
                                    tableCase.TabPawn[yBase, xBase] = " ";
                                    return 0;
                                }
                            }
                            else
                            {
                                if (xFin != xBase)
                                {
                                    Console.WriteLine("\nError: the pawn can only move forward");
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
                                            tableCase.TabPawn[yFin, xFin] = "p";
                                            tableCase.TabPawn[yBase, xBase] = " ";
                                            return 0;
                                        }
                                        else
                                        {
                                            if (yBase + 1 != yFin)
                                            {
                                                tableCase.TabPawn[yFin, xFin] = "p";
                                                tableCase.TabPawn[yBase, xBase] = " ";
                                                return 0;
                                            }
                                            else
                                            {
                                                Console.WriteLine("\n\r\nError: the pawn cannot advance more than 2 squares");
                                                Console.ReadKey();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (yBase == yFin)
                                        {
                                            Console.WriteLine("\nError: the pawn cannot not advance");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nError: the pawn cannot move because there is a piece in front");
                                            Console.ReadKey();
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case "r":
                        if (xBase != xFin && yBase != yFin)
                        {
                            Console.WriteLine("\nError: tower cannot move diagonally");
                            Console.ReadKey();
                        }
                        else
                        {
                            if (endPawn == " ")
                            {
                                tableCase.TabPawn[yFin, xFin] = "r";
                                tableCase.TabPawn[yBase, xBase] = " ";
                                return 0;
                            }
                            else
                            {
                                if (tableCase.TabPawn[yFin, xFin] == "P" || tableCase.TabPawn[yFin, xFin] == "R" || tableCase.TabPawn[yFin, xFin] == "N" || tableCase.TabPawn[yFin, xFin] == "B" || tableCase.TabPawn[yFin, xFin] == "Q" || tableCase.TabPawn[yFin, xFin] == "K")
                                {
                                    tableCase.TabPawn[yFin, xFin] = "r";
                                    tableCase.TabPawn[yBase, xBase] = " ";
                                    return 0;
                                }
                                else
                                {
                                    Console.WriteLine("\nError: You can't eat your own coins");
                                    Console.ReadKey();
                                }
                            }
                        }
                        break;
                    case "b":

                        int diff = 0;

                        if (xBase < xFin)
                        {
                            diff = xBase - xFin;
                        }
                        else
                        {
                            diff = xFin - xBase;
                        }

                        if ((diff == yFin - yBase) || (diff == yBase - yFin))
                        {
                            if (endPawn == " ")
                            {
                                tableCase.TabPawn[yFin, xFin] = "b";
                                tableCase.TabPawn[yBase, xBase] = " ";
                                return 0;
                            }
                            else
                            {
                                if (tableCase.TabPawn[yFin, xFin] == "P" || tableCase.TabPawn[yFin, xFin] == "R" || tableCase.TabPawn[yFin, xFin] == "N" || tableCase.TabPawn[yFin, xFin] == "B" || tableCase.TabPawn[yFin, xFin] == "Q" || tableCase.TabPawn[yFin, xFin] == "K")
                                {
                                    tableCase.TabPawn[yFin, xFin] = "b";
                                    tableCase.TabPawn[yBase, xBase] = " ";
                                    return 0;
                                }
                                else
                                {
                                    Console.WriteLine("\nError: You can't eat your own coins");
                                    Console.ReadKey();
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nError: You can't not go diagonally");
                            Console.ReadKey();
                        }
                        break;
                }
                return 1;
            }
            else
            {
                // Return to the menu
                return 2;
            }
        }
    }
}