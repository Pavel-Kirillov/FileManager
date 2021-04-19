using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                x = random.Next(0, SIZE_X);
                y = random.Next(0, SIZE_Y);
            } while (!IsCellValid(y, x));
            SetSym(y, x, AI_DOT);
        }

        private static bool CheckWin(char sym)
        {
            for (uint i = 0;i < field.GetLength(0); i++)
            {
                uint winHorizontalLine = 0;
                uint winVerticalLine = 0;
                for (uint j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == sym) winHorizontalLine++;
                    if (field[j, i] == sym) winVerticalLine++;
                    if (winHorizontalLine == 4 || winVerticalLine == 4) return true;
                }
            }
            uint winDiagonalLine = 0;
            uint winDiagonalLineReverse = 0;
            for (int j = -1;j < 2;j++)
                for (uint i = 0; i < field.GetLength(0); i++)
                {
                    int shift = (int)i + j;
                    if (shift >= 0 && shift < field.GetLength(0))
                    {
                        if (field[i, shift] == sym) winDiagonalLine++;
                        if (field[i, 4 - shift] == sym) winDiagonalLineReverse++;
                        if (winDiagonalLine == 4 || winDiagonalLineReverse == 4) return true;
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
