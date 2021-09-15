using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Global
    {
        public static bool game = true;
        public static char[,] board = new char[3, 3] { { ' ',' ',' ' }, //important: only works with ' and does not with " !!!! 
                                                { ' ',' ',' ' },
                                                { ' ',' ',' ' } }; //2 dimensonal array, all empty

    }
    class Program
    {
        static void Main(string[] args)
        {

            
            int p = 0;
            
            while (Global.game)
            {
                Read:
                    string inp = Console.ReadLine();

                int x = Convert.ToInt16(inp.Substring(0, 1)) - 1;
                int y = Convert.ToInt16(inp.Substring(inp.Length - 1)) - 1;
                if ( x < 3 && y < 3 && Global.board[x,y] == ' ')
                {
                    switch (p % 2)
                    {
                        case 0:
                            Global.board[x, y] = 'X';
                            break;
                        case 1:
                            Global.board[x, y] = 'O';
                            break;
                    }
                }
                else
                {
                    goto Read;
                }
                Console.WriteLine($"| {Global.board[0, 0]} | {Global.board[1, 0]} | {Global.board[2, 0]} |\n| {Global.board[0, 1]} | {Global.board[1, 1]} | {Global.board[2, 1]} |\n| {Global.board[0, 2]} | {Global.board[1, 2]} | {Global.board[2, 2]} |");
                Check();
                p++;
            }
            Console.WriteLine("Do you want to play again? (y/n)");
            if (Console.ReadLine().Contains("y"))
            {
                Global.game = true;
                Main(args);
            }
            
        }

        private static void Check()
        {
            int sm = 0; //stalemate
            List<char> ch = new List<char>();
            bool x = false; //x got 3
            bool o = false; // o got 3
            for (int j = 0; j < 3; j++) //vertical
            {
                ch.Clear(); //clear checking list
                for (int i = 0; i < 3; i++)
                {
                    ch.Add(Global.board[i, j]);
                }
                x = ch.TrueForAll(IsX); //check x
                o = ch.TrueForAll(IsO); //check o
                if (x)
                {
                    End("P1");
                }
                else if (o)
                {
                    End("P2");
                }
            }
            for (int j = 0; j < 3; j++) //horizontal
            {
                ch.Clear();
                for (int i = 0; i < 3; i++)
                {
                    ch.Add(Global.board[j, i]);
                }
                x = ch.TrueForAll(IsX);
                o = ch.TrueForAll(IsO);
                if (x)
                {
                    End("P1");
                }
                else if (o)
                {
                    End("P2");
                }
            }
            ch.Clear();
            for (int i = 0; i < 3; i++) // \ diagonal
            {
                ch.Add(Global.board[i, i]);
            }
            x = ch.TrueForAll(IsX);
            o = ch.TrueForAll(IsO);
            if (x)
            {
                End("P1");
            }
            else if (o)
            {
                End("P2");
            }
            ch.Clear();
            for (int i = 0; i < 3; i++) // / diagonal
            {
                ch.Add(Global.board[2-i, i]);
            }
            x = ch.TrueForAll(IsX);
            o = ch.TrueForAll(IsO);
            if (x)
            {
                End("P1");
            }
            else if (o)
            {
                End("P2");
            }
            foreach (char c in Global.board) // check for stalemate
            {
                if (c != ' ')
                {
                    sm++;
                }
            }
            if (sm == 9)
            {
                End("Nobody");
            }
            
        }
        private static bool IsX(char c)
        {
            return c == 'X';
        }
        private static bool IsO(char c)
        {
            return c == 'O';
        }
        private static void End(String P)
        {
            Console.WriteLine($"{P} WINS!");
            Global.game = false;
            Global.board = new char[3, 3] { { ' ',' ',' ' },
                                            { ' ',' ',' ' },
                                            { ' ',' ',' ' } };
        }
    }
}
