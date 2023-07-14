using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper_WinForms
{
    internal class Core
    {
        public int[,] Matrix { get; set; } // this is minefield
        public int[,] MatrixEnabledDisabled { get; set; } // this is minefield's enabled and disabled tiles, where 1 means enabled, 0 - disabled tile
        public int MatrixSize { get; set; }
        public int MinesNum { get; set; }
        public int DisabledTiles { get; set; }

        internal Core(int matrixSize, int minesNum) // size of matrix (n * n) and number of mines on the field
        {
            MatrixSize = matrixSize;
            MinesNum = minesNum;
        }

        internal void GenerateMatrix()
        {
            Random rnd = new();
            Matrix = new int[MatrixSize, MatrixSize];
            MatrixEnabledDisabled = new int[MatrixSize, MatrixSize];
            for (int i = 0; i < MatrixSize; i++)
            {
                for (int j = 0; j < MatrixSize; j++)
                {
                    Matrix[i, j] = 0; // generate empty minefield
                    MatrixEnabledDisabled[i, j] = 1; // generate enabled tiles
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
                Matrix[availableCoords[index][0], availableCoords[index][1]] = -1; // ...place a mine there
                c++;
                for (int i = availableCoords[index][0] - 1; i <= availableCoords[index][0] + 1; i++)
                {
                    for (int j = availableCoords[index][1] - 1; j <= availableCoords[index][1] + 1; j++)
                    {
                        try
                        {
                            if (Matrix[i, j] != -1)
                                Matrix[i, j] += 1; // update a counter in all the tiles around the new mine
                        }
                        catch (IndexOutOfRangeException)
                        {

                        }
                    }
                }
                availableCoords.RemoveAt(index); // make the coords unavailable
            }

            for (int i = 0; i < MatrixSize; i++)
            {
                for (int j = 0; j < MatrixSize; j++)
                {
                    Debug.Write($"{Matrix[i, j]} ");
                }
                Debug.Write(Environment.NewLine);
            }
        }

        internal bool CheckGameLost(int row, int column) // return true if game os lost, else false
        {
            if (Matrix[row, column] == -1)
                return true;
            else
                return false;
        }

        internal bool CheckGameWon()
        {
            if (DisabledTiles == MatrixSize * MatrixSize)
                return true;
            else
                return false;
        }

        internal List<List<int>> CheckTiles(int row, int column, List<List<int>> changedCells)
        {
            try
            {
                if (changedCells.Contains(new List<int> { row, column }) == false && MatrixEnabledDisabled[row, column] == 1)
                {
                    changedCells.Add(new List<int> { row, column });
                    MatrixEnabledDisabled[row, column] = 0;
                    if (Matrix[row, column] == 0)
                    {
                        for (int i = row - 1; i <= row + 1; i++)
                        {
                            for (int j = column - 1; j <= column + 1; j++)
                            {
                                CheckTiles(i, j, changedCells);
                            }
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {

            }
            return changedCells;
        }
    }
}
