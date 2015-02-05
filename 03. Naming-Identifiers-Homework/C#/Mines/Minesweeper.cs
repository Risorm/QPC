using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Minesweeper;

namespace Mines
{
    public class Minesweeper
    {
        private static void Main(string[] аргументи)
        {
            string command = string.Empty;
            char[,] field = CreateGameField();
            char[,] bombs = PlantBombs();
            int counter = 0;
            bool bang = false;
            List<Score> champions = new List<Score>(6);
            int row = 0;
            int column = 0;
            bool flag = true;
            const int max = 35;
            bool flag2 = false;

            do
            {
                if (flag)
                {
                    Console.WriteLine(
                        "Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki."
                        + " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    Dump(field);
                    flag = false;
                }

                Console.Write("Daj row i column : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out column)
                        && row <= field.GetLength(0) && column <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        Chart(champions);
                        break;
                    case "restart":
                        field = CreateGameField();
                        bombs = PlantBombs();
                        Dump(field);
                        bang = false;
                        flag = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (bombs[row, column] != '*')
                        {
                            if (bombs[row, column] == '-')
                            {
                                NextMove(field, bombs, row, column);
                                counter++;
                            }

                            if (max == counter)
                            {
                                flag2 = true;
                            }
                            else
                            {
                                Dump(field);
                            }
                        }
                        else
                        {
                            bang = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }

                if (bang)
                {
                    Dump(bombs);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " + "Daj si nickname: ", counter);
                    string nickname = Console.ReadLine();
                    Score t = new Score(nickname, counter);
                    if (champions.Count < 5)
                    {
                        champions.Add(t);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Points < t.Points)
                            {
                                champions.Insert(i, t);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((Score r1, Score r2) => r2.Player.CompareTo(r1.Player));
                    champions.Sort((Score r1, Score r2) => r2.Points.CompareTo(r1.Points));
                    Chart(champions);

                    field = CreateGameField();
                    bombs = PlantBombs();
                    counter = 0;
                    bang = false;
                    flag = true;
                }

                if (flag2)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    Dump(bombs);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string name = Console.ReadLine();
                    Score points = new Score(name, counter);
                    champions.Add(points);
                    Chart(champions);
                    field = CreateGameField();
                    bombs = PlantBombs();
                    counter = 0;
                    flag2 = false;
                    flag = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void Chart(List<Score> points)
        {
            Console.WriteLine("\nTo4KI:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii", i + 1, points[i].Player, points[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void NextMove(char[,] firld, char[,] bombs, int row, int column)
        {
            char bombsCount = Score(bombs, row, column);
            bombs[row, column] = bombsCount;
            firld[row, column] = bombsCount;
        }

        private static void Dump(char[,] board)
        {
            int RRR = board.GetLength(0);
            int KKK = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < RRR; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < KKK; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PlantBombs()
        {
            int rows = 5;
            int columns = 10;
            char[,] gameField = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    gameField[i, j] = '-';
                }
            }

            List<int> r3 = new List<int>();
            while (r3.Count < 15)
            {
                Random random = new Random();
                int asfd = random.Next(50);
                if (!r3.Contains(asfd))
                {
                    r3.Add(asfd);
                }
            }

            foreach (int i2 in r3)
            {
                int column = i2 / columns;
                int row = i2 % columns;
                if (row == 0 && i2 != 0)
                {
                    column--;
                    row = columns;
                }
                else
                {
                    row++;
                }

                gameField[column, row - 1] = '*';
            }

            return gameField;
        }

        private static void Calculations(char[,] field)
        {
            int column = field.GetLength(0);
            int row = field.GetLength(1);

            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (field[i, j] != '*')
                    {
                        char kolkoo = Score(field, i, j);
                        field[i, j] = kolkoo;
                    }
                }
            }
        }

        private static char Score(char[,] r, int rr, int rrr)
        {
            int counter = 0;
            int rows = r.GetLength(0);
            int columns = r.GetLength(1);

            if (rr - 1 >= 0)
            {
                if (r[rr - 1, rrr] == '*')
                {
                    counter++;
                }
            }

            if (rr + 1 < rows)
            {
                if (r[rr + 1, rrr] == '*')
                {
                    counter++;
                }
            }

            if (rrr - 1 >= 0)
            {
                if (r[rr, rrr - 1] == '*')
                {
                    counter++;
                }
            }

            if (rrr + 1 < columns)
            {
                if (r[rr, rrr + 1] == '*')
                {
                    counter++;
                }
            }

            if ((rr - 1 >= 0) && (rrr - 1 >= 0))
            {
                if (r[rr - 1, rrr - 1] == '*')
                {
                    counter++;
                }
            }

            if ((rr - 1 >= 0) && (rrr + 1 < columns))
            {
                if (r[rr - 1, rrr + 1] == '*')
                {
                    counter++;
                }
            }

            if ((rr + 1 < rows) && (rrr - 1 >= 0))
            {
                if (r[rr + 1, rrr - 1] == '*')
                {
                    counter++;
                }
            }

            if ((rr + 1 < rows) && (rrr + 1 < columns))
            {
                if (r[rr + 1, rrr + 1] == '*')
                {
                    counter++;
                }
            }

            return char.Parse(counter.ToString());
        }
    }
}