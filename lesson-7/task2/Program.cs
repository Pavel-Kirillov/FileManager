using System;

namespace task2
{
    class Program
    {
        static readonly int SIZE_X = 5;
        static readonly int SIZE_Y = 5;

        static char[,] field = new char[SIZE_Y, SIZE_X];

        static readonly char PLAYER_DOT = 'X';
        static readonly char AI_DOT = 'O';
        static readonly char EMPTY_DOT = '.';

        static Random random = new Random();

        private static void InitField()
        {
            for (int i = 0; i < SIZE_Y; i++)
            {
                for (int j = 0; j < SIZE_X; j++)
                {
                    field[i, j] = EMPTY_DOT;
                }
            }
        }

        private static void PrintField()
        {
            Console.Clear();
            Console.WriteLine("-----------");
            for (int i = 0; i < SIZE_Y; i++)
            {
                Console.Write("|");
                for (int j = 0; j < SIZE_X; j++)
                {
                    Console.Write(field[i, j] + "|");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-----------");
        }

        private static void SetSym(int y, int x, char sym)
        {
            field[y, x] = sym;
        }

        private static bool IsCellValid(int y, int x)
        {
            if (x < 0 || y < 0 || x > SIZE_X - 1 || y > SIZE_Y - 1)
            {
                return false;
            }

            return field[y, x] == EMPTY_DOT;
        }

        private static bool IsFieldFull()
        {
            for (int i = 0; i < SIZE_Y; i++)
            {
                for (int j = 0; j < SIZE_X; j++)
                {
                    if (field[i, j] == EMPTY_DOT)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static void PlayerMove()
        {
            int x, y;
            do
            {
                Console.WriteLine("Координат по строке ");
                Console.WriteLine("Введите координаты вашего хода в диапозоне от 1 до " + SIZE_Y);
                y = Int32.Parse(Console.ReadLine()) - 1;
                Console.WriteLine("Координат по столбцу ");
                Console.WriteLine("Введите координаты вашего хода в диапозоне от 1 до " + SIZE_X);
                x = Int32.Parse(Console.ReadLine()) - 1;
            } while (!IsCellValid(y, x));
            SetSym(y, x, PLAYER_DOT);
        }

        private static void AiMove()
        {
            int x, y;
            do
            {

                for (int i = 0; i < field.GetLength(0); i++)
                {
                    string str1 = "";
                    string str2 = "";
                    for (int j = 0; j < field.GetLength(0); j++)
                    {
                        str1 += field[i, j];
                        str2 += field[j, i];
                    }
                    x = CheckLineWin(str1);
                    if (x != -1)
                    {
                        y = i;
                        SetSym(y, x, AI_DOT);
                        return;
                    }
                    y = CheckLineWin(str2);
                    if (y != -1)
                    {
                        x = i;
                        SetSym(y, x, AI_DOT);
                        return;
                    }
                }

                for (int j = -1; j < 2; j++)
                {
                    string str3 = "";
                    string str4 = "";
                    for (int i = 0; i < field.GetLength(0); i++)
                    {
                        int shift = i + j;
                        if (shift >= 0 && shift < field.GetLength(0))
                        {
                            str3 += field[i, shift];
                            str4 += field[4 - shift, i];
                        }
                    }
                    x = CheckLineWin(str3);
                    if (x != -1)
                    {
                        if (j == -1) SetSym(x + 1, x, AI_DOT);
                        else if (j == 1) SetSym(x, x + 1, AI_DOT);
                        else SetSym(x, x, AI_DOT);
                        return;
                    }
                    x = CheckLineWin(str4);
                    if (x != -1)
                    {
                        if (j == -1) SetSym(field.GetLength(0) - x - 1, x - j, AI_DOT);
                        else if (j == 1) SetSym(field.GetLength(0) - x - 1 - j, x, AI_DOT);
                        else SetSym(field.GetLength(0) - x - 1, x, AI_DOT);
                        return;
                    }

                }

                x = random.Next(0, SIZE_X);
                y = random.Next(0, SIZE_Y);
            } while (!IsCellValid(y, x));
            SetSym(y, x, AI_DOT);
        }

        private static int CheckLineWin(string str)
        {
            int sumX = 0;
            int x = -1;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == PLAYER_DOT) sumX++;
                else if (sumX != 0)
                {
                    if (sumX >= 2)
                    {
                        x = i - 1;
                        break;
                    }
                sumX = 0;
                }
            }
            if (sumX >= 2)
            {
                if (x == -1) x = str.Length - 1;
                int sumXLeft = 0;
                int sumXRight = 0;
                for (int m = x - sumX; m >= 0; m--)
                {
                    if (str[m] != AI_DOT) sumXLeft++;
                    else break;
                }
                for (int m = x + 1; m < str.Length; m++)
                {
                    if (str[m] != AI_DOT) sumXRight++;
                    else break;
                }
                if (sumXLeft + sumXRight + sumX >= 4)
                {
                    if (sumXLeft < sumXRight)
                    {
                        return x + 1;
                    }
                    else
                    {
                        return x - sumX;
                    }
                }
            }

            return -1;
        }


        private static bool CheckWin(char sym)
        {
            for (uint i = 0; i < field.GetLength(0); i++)
            {
                uint winHorizontalLine = 0;
                uint winVerticalLine = 0;
                for (uint j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == sym) winHorizontalLine++;
                    else winHorizontalLine = 0;
                    if (field[j, i] == sym) winVerticalLine++;
                    else winVerticalLine = 0;
                    if (winHorizontalLine == 4 || winVerticalLine == 4) return true;
                }
            }

            for (int j = -1; j < 2; j++)
            {
                uint winDiagonalLine = 0;
                uint winDiagonalLineReverse = 0;
                for (uint i = 0; i < field.GetLength(0); i++)
                {
                    int shift = (int)i + j;
                    if (shift >= 0 && shift < field.GetLength(0))
                    {
                        if (field[i, shift] == sym) winDiagonalLine++;
                        else winDiagonalLine = 0;
                        if (field[4 - i, shift] == sym) winDiagonalLineReverse++;
                        else winDiagonalLineReverse = 0;
                        if (winDiagonalLine == 4 || winDiagonalLineReverse == 4) return true;
                    }
                }
            }
                
            return false;
        }

        static void Main(string[] args)
        {
            InitField();
            PrintField();
            do
            {
                PlayerMove();
                PrintField();
                if (CheckWin(PLAYER_DOT))
                {
                    Console.WriteLine("Вы выиграли");
                    break;
                }
                else if (IsFieldFull()) break;
                AiMove();
                PrintField();
                if (CheckWin(AI_DOT))
                {
                    Console.WriteLine("Вы проиграли");
                    break;
                }
                else if (IsFieldFull()) break;
            } while (true);
            Console.WriteLine("!Конец игры!");
            Console.ReadKey();
        }

    }
}
