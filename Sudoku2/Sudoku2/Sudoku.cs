using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku2
{
    class Sudoku
    {
        private int?[,] matrix = new int?[9, 9];

        public string PrintCell(int? number)
        {
            if (!number.HasValue)
                return "[ ]";
            return "[" + number.ToString() + "]";
        }

        public string PrintMatrix()
        {
            string returnString = string.Empty;

            returnString = PrintCell(matrix[0, 0]) + " " + PrintCell(matrix[1, 0]) + " " + PrintCell(matrix[2, 0]) + "|" + PrintCell(matrix[3, 0]) + " " + PrintCell(matrix[4, 0]) + " " + PrintCell(matrix[5, 0]) + "|" + PrintCell(matrix[6, 0]) + " " + PrintCell(matrix[7, 0]) + " " + PrintCell(matrix[8, 0]) + Environment.NewLine;
            returnString += PrintCell(matrix[0, 1]) + " " + PrintCell(matrix[1, 1]) + " " + PrintCell(matrix[2, 1]) + "|" + PrintCell(matrix[3, 1]) + " " + PrintCell(matrix[4, 1]) + " " + PrintCell(matrix[5, 1]) + "|" + PrintCell(matrix[6, 1]) + " " + PrintCell(matrix[7, 1]) + " " + PrintCell(matrix[8, 1]) + Environment.NewLine;
            returnString += PrintCell(matrix[0, 2]) + " " + PrintCell(matrix[1, 2]) + " " + PrintCell(matrix[2, 2]) + "|" + PrintCell(matrix[3, 2]) + " " + PrintCell(matrix[4, 2]) + " " + PrintCell(matrix[5, 2]) + "|" + PrintCell(matrix[6, 2]) + " " + PrintCell(matrix[7, 2]) + " " + PrintCell(matrix[8, 2]) + Environment.NewLine;
            returnString += "-------------------------------------" + Environment.NewLine;
            returnString += PrintCell(matrix[0, 3]) + " " + PrintCell(matrix[1, 3]) + " " + PrintCell(matrix[2, 3]) + "|" + PrintCell(matrix[3, 3]) + " " + PrintCell(matrix[4, 3]) + " " + PrintCell(matrix[5, 3]) + "|" + PrintCell(matrix[6, 3]) + " " + PrintCell(matrix[7, 3]) + " " + PrintCell(matrix[8, 3]) + Environment.NewLine;
            returnString += PrintCell(matrix[0, 4]) + " " + PrintCell(matrix[1, 4]) + " " + PrintCell(matrix[2, 4]) + "|" + PrintCell(matrix[3, 4]) + " " + PrintCell(matrix[4, 4]) + " " + PrintCell(matrix[5, 4]) + "|" + PrintCell(matrix[6, 4]) + " " + PrintCell(matrix[7, 4]) + " " + PrintCell(matrix[8, 4]) + Environment.NewLine;
            returnString += PrintCell(matrix[0, 5]) + " " + PrintCell(matrix[1, 5]) + " " + PrintCell(matrix[2, 5]) + "|" + PrintCell(matrix[3, 5]) + " " + PrintCell(matrix[4, 5]) + " " + PrintCell(matrix[5, 5]) + "|" + PrintCell(matrix[6, 5]) + " " + PrintCell(matrix[7, 5]) + " " + PrintCell(matrix[8, 5]) + Environment.NewLine;
            returnString += "-----------------------------------" + Environment.NewLine;
            returnString += PrintCell(matrix[0, 6]) + " " + PrintCell(matrix[1, 6]) + " " + PrintCell(matrix[2, 6]) + "|" + PrintCell(matrix[3, 6]) + " " + PrintCell(matrix[4, 6]) + " " + PrintCell(matrix[5, 6]) + "|" + PrintCell(matrix[6, 6]) + " " + PrintCell(matrix[7, 6]) + " " + PrintCell(matrix[8, 6]) + Environment.NewLine;
            returnString += PrintCell(matrix[0, 7]) + " " + PrintCell(matrix[1, 7]) + " " + PrintCell(matrix[2, 7]) + "|" + PrintCell(matrix[3, 7]) + " " + PrintCell(matrix[4, 7]) + " " + PrintCell(matrix[5, 7]) + "|" + PrintCell(matrix[6, 7]) + " " + PrintCell(matrix[7, 7]) + " " + PrintCell(matrix[8, 7]) + Environment.NewLine;
            returnString += PrintCell(matrix[0, 8]) + " " + PrintCell(matrix[1, 8]) + " " + PrintCell(matrix[2, 8]) + "|" + PrintCell(matrix[3, 8]) + " " + PrintCell(matrix[4, 8]) + " " + PrintCell(matrix[5, 8]) + "|" + PrintCell(matrix[6, 8]) + " " + PrintCell(matrix[7, 8]) + " " + PrintCell(matrix[8, 8]) + Environment.NewLine;

            return returnString;
        }

        public void PopulateMatrix()
        {
            AddValueMatrix(0, 0, 8);
            AddValueMatrix(0, 1, 4);
            AddValueMatrix(0, 2, 3);
            AddValueMatrix(0, 3, 9);
            AddValueMatrix(0, 4, 7);
            AddValueMatrix(0, 6, 2);
            AddValueMatrix(0, 7, 1);

            AddValueMatrix(1, 2, 6);
            AddValueMatrix(1, 4, 1);

            AddValueMatrix(2, 0, 1);
            AddValueMatrix(2, 2, 5);
            AddValueMatrix(2, 5, 4);
            AddValueMatrix(2, 7, 7);

            AddValueMatrix(3, 1, 5);
            AddValueMatrix(3, 3, 6);

            AddValueMatrix(4, 0, 9);
            AddValueMatrix(4, 2, 1);
            AddValueMatrix(4, 4, 5);
            AddValueMatrix(4, 6, 3);
            AddValueMatrix(4, 8, 7);

            AddValueMatrix(5, 5, 7);
            AddValueMatrix(5, 7, 8);

            AddValueMatrix(6, 1, 7);
            AddValueMatrix(6, 3, 5);
            AddValueMatrix(6, 6, 9);
            AddValueMatrix(6, 8, 4);

            AddValueMatrix(7, 4, 4);
            AddValueMatrix(7, 6, 8);

            AddValueMatrix(8, 1, 3);
            AddValueMatrix(8, 2, 4);
            AddValueMatrix(8, 4, 6);
            AddValueMatrix(8, 5, 9);
            AddValueMatrix(8, 6, 7);
            AddValueMatrix(8, 7, 2);
            AddValueMatrix(8, 8, 1);
        }

        public bool IsSolved()
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (!matrix[x, y].HasValue)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void Solve()
        {
            List<Tuple<int, int>> l = SolveNum(7);

        }

        public List<Tuple<int, int>> SolveNum(int num)
        {
            List<Tuple<int, int>> solveNums = new List<Tuple<int, int>>();

            bool[,] map = new bool[9, 9];

            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    map[x, y] = true;
                }
            }

            PrintMap(map);



            return solveNums;
        }

        public void PrintMap(bool[,] map)
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


        public void AddValueMatrix(int x, int y, int value)
        {
            this.matrix[x, y] = value;
        }

    }
}
