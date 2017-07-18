using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
            Sudoku s = new Sudoku();
            s.InstantiateMatrix();
            s.PopulateMatrix();
            s.Solve();
            Console.Out.Write(s.PrintMatrix());

            int pause = 1;

            //Application.Run(new Form1());

=======
            Application.Run(new Form1());
>>>>>>> 962319d64dab536877b21f8bf793bec2103e9d3b
        }
    }
}
