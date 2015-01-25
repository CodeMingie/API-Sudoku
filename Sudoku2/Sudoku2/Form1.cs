using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku2
{
    public partial class Form1 : Form
    {
        private int[,] matrix = new int[9,9];

        public Form1()
        {
            InitializeComponent();
            InstantiateMatrix();
            PopulateMatrix();

            NumberMap map = new NumberMap(matrix, 6);
            int num = matrix[3,3];
            PrintMatrix(matrix);
        }

        public void InstantiateMatrix()
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    matrix[x,y] = 0;
                }
            }
        }

        public void PrintMatrix(int[,] matrix)
        {
            string returnString = string.Empty;

            returnString = PrintCell(matrix[0,0]) + " " + PrintCell(matrix[0,1]) + " " + PrintCell(matrix[0,2]) + "|" + PrintCell(matrix[0,3]) + " " + PrintCell(matrix[0,4]) + " " + PrintCell(matrix[0,5]) + "|" + PrintCell(matrix[0,6]) + " " + PrintCell(matrix[0,7]) + " " + PrintCell(matrix[0,8]) + Environment.NewLine;
            returnString += PrintCell(matrix[1,0]) + " " + PrintCell(matrix[1,1]) + " " + PrintCell(matrix[1,2]) + "|" + PrintCell(matrix[1,3]) + " " + PrintCell(matrix[1,4]) + " " + PrintCell(matrix[1,5]) + "|" + PrintCell(matrix[1,6]) + " " + PrintCell(matrix[1,7]) + " " + PrintCell(matrix[1,8]) + Environment.NewLine;
            returnString += PrintCell(matrix[2,0]) + " " + PrintCell(matrix[2,1]) + " " + PrintCell(matrix[2,2]) + "|" + PrintCell(matrix[2,3]) + " " + PrintCell(matrix[2,4]) + " " + PrintCell(matrix[2,5]) + "|" + PrintCell(matrix[2,6]) + " " + PrintCell(matrix[2,7]) + " " + PrintCell(matrix[2,8]) + Environment.NewLine;
            returnString += "-------------------------------------" + Environment.NewLine;
            returnString += PrintCell(matrix[3,0]) + " " + PrintCell(matrix[3,1]) + " " + PrintCell(matrix[3,2]) + "|" + PrintCell(matrix[3,3]) + " " + PrintCell(matrix[3,4]) + " " + PrintCell(matrix[3,5]) + "|" + PrintCell(matrix[3,6]) + " " + PrintCell(matrix[3,7]) + " " + PrintCell(matrix[3,8]) + Environment.NewLine;
            returnString += PrintCell(matrix[4,0]) + " " + PrintCell(matrix[4,1]) + " " + PrintCell(matrix[4,2]) + "|" + PrintCell(matrix[4,3]) + " " + PrintCell(matrix[4,4]) + " " + PrintCell(matrix[4,5]) + "|" + PrintCell(matrix[4,6]) + " " + PrintCell(matrix[4,7]) + " " + PrintCell(matrix[4,8]) + Environment.NewLine;
            returnString += PrintCell(matrix[5,0]) + " " + PrintCell(matrix[5,1]) + " " + PrintCell(matrix[5,2]) + "|" + PrintCell(matrix[5,3]) + " " + PrintCell(matrix[5,4]) + " " + PrintCell(matrix[5,5]) + "|" + PrintCell(matrix[5,6]) + " " + PrintCell(matrix[5,7]) + " " + PrintCell(matrix[5,8]) + Environment.NewLine;
            returnString += "-----------------------------------" + Environment.NewLine;
            returnString += PrintCell(matrix[6,0]) + " " + PrintCell(matrix[6,1]) + " " + PrintCell(matrix[6,2]) + "|" + PrintCell(matrix[6,3]) + " " + PrintCell(matrix[6,4]) + " " + PrintCell(matrix[6,5]) + "|" + PrintCell(matrix[6,6]) + " " + PrintCell(matrix[6,7]) + " " + PrintCell(matrix[6,8]) + Environment.NewLine;
            returnString += PrintCell(matrix[7,0]) + " " + PrintCell(matrix[7,1]) + " " + PrintCell(matrix[7,2]) + "|" + PrintCell(matrix[7,3]) + " " + PrintCell(matrix[7,4]) + " " + PrintCell(matrix[7,5]) + "|" + PrintCell(matrix[7,6]) + " " + PrintCell(matrix[7,7]) + " " + PrintCell(matrix[7,8]) + Environment.NewLine;
            returnString += PrintCell(matrix[8,0]) + " " + PrintCell(matrix[8,1]) + " " + PrintCell(matrix[8,2]) + "|" + PrintCell(matrix[8,3]) + " " + PrintCell(matrix[8,4]) + " " + PrintCell(matrix[8,5]) + "|" + PrintCell(matrix[8,6]) + " " + PrintCell(matrix[8,7]) + " " + PrintCell(matrix[8,8]) + Environment.NewLine;
            richTextBox1.Text = returnString;
        }

        public string PrintCell(int number)
        {
            if (number == 0)
                return "[ ]";
            return "[" + number.ToString() + "]";
        }

        public void PopulateMatrix()
        {
            AddValueMatrix(matrix, 1, 1, 2);
            AddValueMatrix(matrix, 2, 2, 4);
            AddValueMatrix(matrix, 3, 3, 6);
        }

        public void AddValueMatrix(int[,] matrix, int x, int y, int value)
        {
            matrix[x,y] = value;
        }
        
    }

    public class NumberMap
    {
        public bool[] row13;
        public bool[] row46;
        public bool[] row79;

        public bool[] col13;
        public bool[] col46;
        public bool[] col79;

        public NumberMap(int[,] matrix, int num)
        {
            row13 = new bool[3];
            row46 = new bool[3];
            row79 = new bool[3];

            col13 = new bool[3];
            col46 = new bool[3];
            col79 = new bool[3];

            for (int x = 0; x < 2; x++)
            {
                row13[x] = false;
                row46[x] = false;
                row79[x] = false;

                for (int y = 0; y < 9; y++)
                {
                    if (matrix[x,y] == num)
                        row13[x] = true;

                    if (matrix[3 + x,y] == num)
                        row46[x] = true;

                    if (matrix[6 + x,y] == num)
                        row79[x] = true;
                }
            }
        }

        //public FindPossibleCoordinatePairs(int[][] matrix, int x, int y)
        //{
            
        //}
    }
}
