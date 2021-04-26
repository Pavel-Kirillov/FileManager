using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileManager
{
    class Program
    {
        static int numberItems = 10;
        static int pos = 0;
        static void Main()
        {



            Console.Clear();
            int width = Console.WindowWidth;
            int height = numberItems + 6;
            Console.SetWindowSize(width + 1, height);
            Console.SetBufferSize(width + 1, height);

            //рисуем рамку
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    if ((i == 0 && j == 0) || (i == 0 && j == height - 1) ||
                        (i == width - 1 && j == 0) || (i == width - 1 && j == height - 1)) PrintSym(i, j, '+');
                    if (i > 0 && i < width - 1 && (j == 0 || j == height - 1)) PrintSym(i, j, '=');
                    if (j > 0 && j < height - 1 && (i == 0 || i == width - 1)) PrintSym(i, j, '|');
                    if (i > 0 && i < width - 1 && (j == 2 || j == height - 3)) PrintSym(i, j, '-');
                }

            string[] listFiles = ChageDir();
            string[] list = PrintList(listFiles);

            int posTmp = 0;
            int shift = 0;
            //навигация
            while (true)
            {
                if (shift >= listFiles.Length - list.Length) shift = listFiles.Length - list.Length;
                if (shift <= 0) shift = 1;
                if (posTmp != pos)
                {
                    if (pos < 0)
                    {
                        if (list.First() != "..")
                            list = PrintList(listFiles, --shift);
                        pos = 0;
                    }
                    else if (pos >= list.Length)
                    {
                        if (list.Last() != listFiles.Last().Split('\\').Last())
                            list = PrintList(listFiles, ++shift);
                        pos = list.Length - 1;
                    }


                    PrintLine(1, 3 + posTmp, list[posTmp], list[posTmp].Length);
                    PrintLine(1, 3 + pos, list[pos], list[pos].Length, true);
                }

                posTmp = pos;

                Console.SetCursorPosition(1, height - 2);
                Console.CursorVisible = true;
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.F10) return;
                else if (key.Key == ConsoleKey.DownArrow) pos++;
                else if (key.Key == ConsoleKey.UpArrow) pos--;
                else if (key.Key == ConsoleKey.PageDown)
                {
                    if (pos != 0)
                    {
                        shift += pos;
                        pos = list.Length;
                    }
                    else pos = list.Length - 1;
                }
                else if (key.Key == ConsoleKey.PageUp)
                {
                    if (pos != list.Length - 1)
                    {
                        shift -= list.Length - pos;
                        pos = -1;
                    }
                    else pos = 0;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    //if (Directory.GetParent(Directory.GetCurrentDirectory()) != null)
                    {
                        listFiles = ChageDir(list[pos]);
                        list = PrintList(listFiles);
                        posTmp = pos;
                        shift = 0;
                    }

                }
                Console.CursorVisible = false;
            }




        }
        static void ClearArea()
        {
            for (int i = 3; i < Console.BufferHeight - 3; i++)
                for (int j = 1; j < Console.BufferWidth - 2; j++)
                    PrintSym(j, i, ' ');


        }
        static string[] ChageDir(string dir = "")
        {
            DirectoryInfo currentDir;
            if (dir == "..") currentDir = new DirectoryInfo(Directory.GetParent(Directory.GetCurrentDirectory()).FullName);
            else
            {
                currentDir = new DirectoryInfo(Directory.GetCurrentDirectory() + '\\' + dir);
                pos = 0;
            }

            Directory.SetCurrentDirectory(currentDir.FullName);
            PrintLine(1, 1, currentDir.FullName, Console.BufferWidth - 3);
            string[] listFiles = Directory.GetFileSystemEntries(currentDir.FullName);


            return listFiles;
        }
        static string[] PrintList(string[] listFiles, int shift = 0)
        {
            ClearArea();
            int count = listFiles.Length - shift;
            string[] listForPrint = new string[(numberItems - 1 > count ? count : numberItems - 1) + 1];
            for (int i = 0; i < listForPrint.Length; i++)
            {
                if (i == 0 && shift == 0) listForPrint[0] = "..";
                else
                    listForPrint[i] = listFiles[i - 1 + shift].Split('\\').Last();
                bool selectLine;
                if (i == pos) selectLine = true;
                else selectLine = false;
                PrintLine(1, 3 + i, listForPrint[i], listForPrint[i].Length, selectLine);
            }
            return listForPrint;
        }
        static void PrintSym(int x, int y, char sym)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }
        static void PrintLine(int x, int y, string line, int length, bool select = false)
        {
            Console.SetCursorPosition(x, y);
            if (select)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            for (int i = 0; i < length; i++)
            {
                if (i < line.Length) Console.Write(line[i]);
                else Console.Write(" ");
            }
            Console.ResetColor();
        }
    }
}
