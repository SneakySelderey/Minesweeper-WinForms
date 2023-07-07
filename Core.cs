using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper_WinForms
{
    internal class Core
    {
        private bool[,] matrix;  // this is minefield
        public int MatrixSize { get; set; }
        public int MinesNum { get; set; }

        internal Core(int matrixSize, int minesNum)  // size of matrix (n * n) and number of mines on the field
        {
            MatrixSize = matrixSize;
            MinesNum = minesNum;
        }

        public void GenerateMatrix()
        {
            Random rnd = new();
            matrix = new bool[MatrixSize, MatrixSize];
            for (int i = 0; i < MatrixSize; i++)
            {
                for (int j = 0; j < MatrixSize; j++)
                {
                    matrix[i, j] = false;  // generate empty minefield
                }
            }
            int c = 0;
            while (c < MinesNum)
            {
                List<int> mineCoord = new() { rnd.Next(0, MatrixSize), rnd.Next(0, MatrixSize) };
                if (matrix[mineCoord[0], mineCoord[1]] == false)
                {
                    matrix[mineCoord[0], mineCoord[1]] = true;  // generate a given number of mines in random tiles of the field
                    c++;
                }
            }
        }
    }
}
