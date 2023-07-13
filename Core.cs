using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper_WinForms
{
    internal class Core
    {
        private int[,] matrix; // this is minefield
        public int MatrixSize { get; set; }
        public int MinesNum { get; set; }

        internal Core(int matrixSize, int minesNum) // size of matrix (n * n) and number of mines on the field
        {
            MatrixSize = matrixSize;
            MinesNum = minesNum;
        }

        internal void GenerateMatrix()
        {
            Random rnd = new();
            matrix = new int[MatrixSize, MatrixSize];
            for (int i = 0; i < MatrixSize; i++)
            {
                for (int j = 0; j < MatrixSize; j++)
                {
                    matrix[i, j] = 0; // generate empty minefield
                }
            }

            List<List<int>> availableCoords = new();
            for (int i = 0; i < MatrixSize; i++)
            {
                for (int j = 0;j < MatrixSize; j++)
                {
                    availableCoords.Add(new List<int>() { i, j }); // generate a list of coords available to place mines
                }
            }

            int c = 0;
            while (c < MinesNum)
            {
                int index = rnd.Next(0, availableCoords.Count); // pick a random set of coords from the list...
                matrix[availableCoords[index][0], availableCoords[index][1]] = -1; // ...place a mine there
                c++;
                for (int i = availableCoords[index][0] - 1; i <= availableCoords[index][0] + 1; i++)
                {
                    for (int j = availableCoords[index][1] - 1; j <= availableCoords[index][1] + 1; j++)
                    {
                        try
                        {
                            if (matrix[i, j] != -1)
                                matrix[i, j] += 1; // update a counter in all the tiles around the new mine
                        }
                        catch (IndexOutOfRangeException)
                        {

                        }
                    }
                }
                availableCoords.RemoveAt(index); // make the coords unavailable
            }

            //for (int i = 0; i < MatrixSize; i++)
            //{
            //    for (int j = 0; j < MatrixSize; j++)
            //    {
            //        Debug.Write($"{matrix[i, j]} ");
            //    }
            //    Debug.Write(Environment.NewLine);
            //}
        }

        //internal bool CheckTile(int row, int column, List<List<int>> result)
        //{
        //    if (matrix[row][column])
        //}
    }
}
