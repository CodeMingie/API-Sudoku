using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku2
{
    class Sudoku
    {
        private int?[,] numberMap = new int?[9, 9];

        public string PrintNum(int? number)
        {
            if (!number.HasValue)
                return "[ ]";
            return "[" + number.ToString() + "]";
        }

        public string PrintNumMap()
        {
            string returnString = string.Empty;

            returnString = PrintNum(numberMap[0, 0]) + " " + PrintNum(numberMap[1, 0]) + " " + PrintNum(numberMap[2, 0]) + "|" + PrintNum(numberMap[3, 0]) + " " + PrintNum(numberMap[4, 0]) + " " + PrintNum(numberMap[5, 0]) + "|" + PrintNum(numberMap[6, 0]) + " " + PrintNum(numberMap[7, 0]) + " " + PrintNum(numberMap[8, 0]) + Environment.NewLine;
            returnString += PrintNum(numberMap[0, 1]) + " " + PrintNum(numberMap[1, 1]) + " " + PrintNum(numberMap[2, 1]) + "|" + PrintNum(numberMap[3, 1]) + " " + PrintNum(numberMap[4, 1]) + " " + PrintNum(numberMap[5, 1]) + "|" + PrintNum(numberMap[6, 1]) + " " + PrintNum(numberMap[7, 1]) + " " + PrintNum(numberMap[8, 1]) + Environment.NewLine;
            returnString += PrintNum(numberMap[0, 2]) + " " + PrintNum(numberMap[1, 2]) + " " + PrintNum(numberMap[2, 2]) + "|" + PrintNum(numberMap[3, 2]) + " " + PrintNum(numberMap[4, 2]) + " " + PrintNum(numberMap[5, 2]) + "|" + PrintNum(numberMap[6, 2]) + " " + PrintNum(numberMap[7, 2]) + " " + PrintNum(numberMap[8, 2]) + Environment.NewLine;
            returnString += "-------------------------------------" + Environment.NewLine;
            returnString += PrintNum(numberMap[0, 3]) + " " + PrintNum(numberMap[1, 3]) + " " + PrintNum(numberMap[2, 3]) + "|" + PrintNum(numberMap[3, 3]) + " " + PrintNum(numberMap[4, 3]) + " " + PrintNum(numberMap[5, 3]) + "|" + PrintNum(numberMap[6, 3]) + " " + PrintNum(numberMap[7, 3]) + " " + PrintNum(numberMap[8, 3]) + Environment.NewLine;
            returnString += PrintNum(numberMap[0, 4]) + " " + PrintNum(numberMap[1, 4]) + " " + PrintNum(numberMap[2, 4]) + "|" + PrintNum(numberMap[3, 4]) + " " + PrintNum(numberMap[4, 4]) + " " + PrintNum(numberMap[5, 4]) + "|" + PrintNum(numberMap[6, 4]) + " " + PrintNum(numberMap[7, 4]) + " " + PrintNum(numberMap[8, 4]) + Environment.NewLine;
            returnString += PrintNum(numberMap[0, 5]) + " " + PrintNum(numberMap[1, 5]) + " " + PrintNum(numberMap[2, 5]) + "|" + PrintNum(numberMap[3, 5]) + " " + PrintNum(numberMap[4, 5]) + " " + PrintNum(numberMap[5, 5]) + "|" + PrintNum(numberMap[6, 5]) + " " + PrintNum(numberMap[7, 5]) + " " + PrintNum(numberMap[8, 5]) + Environment.NewLine;
            returnString += "-----------------------------------" + Environment.NewLine;
            returnString += PrintNum(numberMap[0, 6]) + " " + PrintNum(numberMap[1, 6]) + " " + PrintNum(numberMap[2, 6]) + "|" + PrintNum(numberMap[3, 6]) + " " + PrintNum(numberMap[4, 6]) + " " + PrintNum(numberMap[5, 6]) + "|" + PrintNum(numberMap[6, 6]) + " " + PrintNum(numberMap[7, 6]) + " " + PrintNum(numberMap[8, 6]) + Environment.NewLine;
            returnString += PrintNum(numberMap[0, 7]) + " " + PrintNum(numberMap[1, 7]) + " " + PrintNum(numberMap[2, 7]) + "|" + PrintNum(numberMap[3, 7]) + " " + PrintNum(numberMap[4, 7]) + " " + PrintNum(numberMap[5, 7]) + "|" + PrintNum(numberMap[6, 7]) + " " + PrintNum(numberMap[7, 7]) + " " + PrintNum(numberMap[8, 7]) + Environment.NewLine;
            returnString += PrintNum(numberMap[0, 8]) + " " + PrintNum(numberMap[1, 8]) + " " + PrintNum(numberMap[2, 8]) + "|" + PrintNum(numberMap[3, 8]) + " " + PrintNum(numberMap[4, 8]) + " " + PrintNum(numberMap[5, 8]) + "|" + PrintNum(numberMap[6, 8]) + " " + PrintNum(numberMap[7, 8]) + " " + PrintNum(numberMap[8, 8]) + Environment.NewLine;

            return returnString;
        }

        public void PopulateNumMap()
        {
            SetNum(0, 0, 8);
            SetNum(0, 1, 4);
            SetNum(0, 2, 3);
            SetNum(0, 3, 9);
            SetNum(0, 4, 7);
            SetNum(0, 6, 2);
            SetNum(0, 7, 1);

            SetNum(1, 2, 6);
            SetNum(1, 4, 1);

            SetNum(2, 0, 1);
            SetNum(2, 2, 5);
            SetNum(2, 5, 4);
            SetNum(2, 7, 7);

            SetNum(3, 1, 5);
            SetNum(3, 3, 6);

            SetNum(4, 0, 9);
            SetNum(4, 2, 1);
            SetNum(4, 4, 5);
            SetNum(4, 6, 3);
            SetNum(4, 8, 7);

            SetNum(5, 5, 7);
            SetNum(5, 7, 8);

            SetNum(6, 1, 7);
            SetNum(6, 3, 5);
            SetNum(6, 6, 9);
            SetNum(6, 8, 4);

            SetNum(7, 4, 4);
            SetNum(7, 6, 8);

            SetNum(8, 1, 3);
            SetNum(8, 2, 4);
            SetNum(8, 4, 6);
            SetNum(8, 5, 9);
            SetNum(8, 6, 7);
            SetNum(8, 7, 2);
            SetNum(8, 8, 1);
        }

        public bool IsSolved()
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (!numberMap[x, y].HasValue)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void Solve()
        {

            while (!this.IsSolved())
            {
                for (int x = 1; x < 10; x++)
                {
                    List<Tuple<int, int>> l = SolveNum(x);

                    foreach (Tuple<int, int> t in l)
                    {
                        this.numberMap[t.Item1, t.Item2] = x;
                    }
                }

                Console.Out.WriteLine(this.PrintNumMap());
            }
        }

        public List<Tuple<int, int>> SolveNum(int num)
        {
            //Initialize possibility table
            List<Tuple<int, int>> solvedNums = new List<Tuple<int, int>>();

            bool[,] boolMap = new bool[9, 9];

            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    boolMap[x, y] = true;
                }
            }

            //X out rows,columns and region blocks containing number
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (this.numberMap[x,y].HasValue && this.numberMap[x, y].Value == num)
                    {
                        for (int i = 0; i < 9; i++)
                        {    
                            boolMap[i, y] = false;
                            boolMap[x, i] = false;
                        }
                        
                        for (int a = x / 3 * 3; a < x / 3 * 3+ 3; a++)
                        {
                            for (int b = y / 3 * 3; b < y / 3 * 3+ 3; b++)
                            {
                                //Console.Out.WriteLine(a.ToString() + " " + b.ToString());
                                boolMap[a, b] = false;
                            }
                        }
                        
                    }
                    else if (this.numberMap[x, y].HasValue)
                    {
                        boolMap[x, y] = false;
                    }
                }
            }

            //If only one possibility remains in region block, that must be the num. 
            //So add it to solved list
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    int possNumCount = 0;
                    Tuple<int, int> possNum = new Tuple<int, int>(-1, -1);

                    for (int i = x * 3; i < x * 3 + 3; i++)
                    {
                        for (int j = y * 3; j < y* 3 + 3; j++)
                        {
                            if (boolMap[i, j] == true)
                            {
                                possNumCount++;
                                possNum = new Tuple<int, int>(i, j);
                            }
                        }
                    }

                    if (possNumCount == 1)
                        solvedNums.Add(possNum);
                }
            }
            //PrintBoolMap(boolMap);
            
            return solvedNums;
        }

        public void PrintBoolMap(bool[,] map)
        {
            string returnString = string.Empty;

            returnString = PrintBool(map[0, 0]) + " " + PrintBool(map[1, 0]) + " " + PrintBool(map[2, 0]) + "|" + PrintBool(map[3, 0]) + " " + PrintBool(map[4, 0]) + " " + PrintBool(map[5, 0]) + "|" + PrintBool(map[6, 0]) + " " + PrintBool(map[7, 0]) + " " + PrintBool(map[8, 0]) + Environment.NewLine;
            returnString += PrintBool(map[0, 1]) + " " + PrintBool(map[1, 1]) + " " + PrintBool(map[2, 1]) + "|" + PrintBool(map[3, 1]) + " " + PrintBool(map[4, 1]) + " " + PrintBool(map[5, 1]) + "|" + PrintBool(map[6, 1]) + " " + PrintBool(map[7, 1]) + " " + PrintBool(map[8, 1]) + Environment.NewLine;
            returnString += PrintBool(map[0, 2]) + " " + PrintBool(map[1, 2]) + " " + PrintBool(map[2, 2]) + "|" + PrintBool(map[3, 2]) + " " + PrintBool(map[4, 2]) + " " + PrintBool(map[5, 2]) + "|" + PrintBool(map[6, 2]) + " " + PrintBool(map[7, 2]) + " " + PrintBool(map[8, 2]) + Environment.NewLine;
            returnString += "-------------------------------------" + Environment.NewLine;
            returnString += PrintBool(map[0, 3]) + " " + PrintBool(map[1, 3]) + " " + PrintBool(map[2, 3]) + "|" + PrintBool(map[3, 3]) + " " + PrintBool(map[4, 3]) + " " + PrintBool(map[5, 3]) + "|" + PrintBool(map[6, 3]) + " " + PrintBool(map[7, 3]) + " " + PrintBool(map[8, 3]) + Environment.NewLine;
            returnString += PrintBool(map[0, 4]) + " " + PrintBool(map[1, 4]) + " " + PrintBool(map[2, 4]) + "|" + PrintBool(map[3, 4]) + " " + PrintBool(map[4, 4]) + " " + PrintBool(map[5, 4]) + "|" + PrintBool(map[6, 4]) + " " + PrintBool(map[7, 4]) + " " + PrintBool(map[8, 4]) + Environment.NewLine;
            returnString += PrintBool(map[0, 5]) + " " + PrintBool(map[1, 5]) + " " + PrintBool(map[2, 5]) + "|" + PrintBool(map[3, 5]) + " " + PrintBool(map[4, 5]) + " " + PrintBool(map[5, 5]) + "|" + PrintBool(map[6, 5]) + " " + PrintBool(map[7, 5]) + " " + PrintBool(map[8, 5]) + Environment.NewLine;
            returnString += "-----------------------------------" + Environment.NewLine;
            returnString += PrintBool(map[0, 6]) + " " + PrintBool(map[1, 6]) + " " + PrintBool(map[2, 6]) + "|" + PrintBool(map[3, 6]) + " " + PrintBool(map[4, 6]) + " " + PrintBool(map[5, 6]) + "|" + PrintBool(map[6, 6]) + " " + PrintBool(map[7, 6]) + " " + PrintBool(map[8, 6]) + Environment.NewLine;
            returnString += PrintBool(map[0, 7]) + " " + PrintBool(map[1, 7]) + " " + PrintBool(map[2, 7]) + "|" + PrintBool(map[3, 7]) + " " + PrintBool(map[4, 7]) + " " + PrintBool(map[5, 7]) + "|" + PrintBool(map[6, 7]) + " " + PrintBool(map[7, 7]) + " " + PrintBool(map[8, 7]) + Environment.NewLine;
            returnString += PrintBool(map[0, 8]) + " " + PrintBool(map[1, 8]) + " " + PrintBool(map[2, 8]) + "|" + PrintBool(map[3, 8]) + " " + PrintBool(map[4, 8]) + " " + PrintBool(map[5, 8]) + "|" + PrintBool(map[6, 8]) + " " + PrintBool(map[7, 8]) + " " + PrintBool(map[8, 8]) + Environment.NewLine;

            Console.Out.WriteLine(returnString);
        }

        public string PrintBool(bool block)
        {
            if (block)
                return "[1]";
            return "[0]";
        }


        public void SetNum(int x, int y, int value)
        {
            this.numberMap[x, y] = value;
        }

    }
}
