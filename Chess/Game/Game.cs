using TableTest;

namespace GameTest
{
    public class PlayGame
    {
        private Table tableCase = new Table();

        public void Game()
        {
            bool fin = false;
            do{
                Afficher();
                string position = Console.ReadLine();
                
                if ((position != "Q")&&(position!="q"))
                {
                    string positionBase = position.Split("-")[0];
                    string positionFin = position.Split("-")[1];

                    //MessageBox.Show("position de base: " + positionBase + " position de fin: " + positionFin);

                    string positionFinString = positionFin.Substring(1);
                    string positionBaseString = positionBase.Substring(1);

                    //  Définir position de fin string et position de base string en int
                    int numFin = int.Parse(positionFinString);
                    int numBase = int.Parse(positionBaseString);

                    string a = Coordonnees(positionBase);
                    //Console.WriteLine(a+" Base");

                    //  Position de Base ex. A2 = x:0 et y:1
                    int xBase = int.Parse(a.Split("-")[0]);
                    int yBase = int.Parse(a.Split("-")[1]);

                    string b = Coordonnees(positionFin);
                    //Console.WriteLine(b+" Fin");

                    //  Position de Fin ex. A2 = x:0 et y:1
                    int xFin = int.Parse(b.Split("-")[0]);
                    int yFin = int.Parse(b.Split("-")[1]);

                    //  Trouver la pièce qui correspond au cooronnées
                    string pieceBase = tableCase.TabPawn[yBase, xBase];
                    string pieceFin = tableCase.TabPawn[yFin, xFin];
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
                                //  Si une pièce est devant alors il peut pas avencer
                                if (pieceFin == " ")
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
                        break;
                    }
                }
                else
                {
                    fin = true;
                }
            } while (fin == false);
        }

        private string Coordonnees(string pos)
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 7; y++)
                {
                    if (tableCase.TabCase[x,y] == pos)
                    {
                        //Console.WriteLine(tableau[x, y]);
                        return (x + "-" + y).ToString();
                    }
                }
            }
            return "404";
        }

        private void Afficher()
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
    }
}