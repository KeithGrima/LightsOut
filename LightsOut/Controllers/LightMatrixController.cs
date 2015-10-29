using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LightsOut.Controllers
{
    public class LightMatrixController
    {
        #region Properties
        private bool[,] matrix = null;
        private int xAxisLength = 0;
        private int yAxisLength = 0;

        int tickSeed = (int)DateTime.Now.Ticks;
        Random random = null;
        #endregion

        public LightMatrixController()
        {
        }

        /// <summary>
        /// Generate Matrix(2d array) using x and y
        /// </summary>
        /// <param name="xAxis"></param>
        /// <param name="yAxis"></param>
        /// <returns></returns>
        public bool[,] GenerateMatrix(int xAxis, int yAxis)
        {
            matrix = new bool[xAxis, yAxis];
            xAxisLength = xAxis;
            yAxisLength = yAxis;
            random = new Random(tickSeed);

            //Continues retrying in case none are lit
            var enabled = false;
            do
            {
                for (int x = 0; x < xAxis; x++)
                {
                    for (int y = 0; y < yAxis; y++)
                    {
                        var result = RandomBool();
                        matrix[x, y] = result;

                        if (result == true)
                            enabled = result;
                    }
                }
            } while (enabled == false);

            return matrix;
        }

        /// <summary>
        /// Loop Matrix to check if all values within 2d array are true
        /// </summary>
        /// <returns></returns>
        public bool ValidateBoard()
        {
            for (int x = 0; x < xAxisLength; x++)
            {
                for (int y = 0; y < yAxisLength; y++)
                {
                    var isLight = matrix[x, y];
                    if (isLight == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Gets all addjacent cell of the cell that has been clicked
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public List<Tuple<int, int, bool>> GetAddjacentCells(int x, int y)
        {
            List<Tuple<int, int, bool>> liIndex = new List<Tuple<int, int, bool>>();

            //Center(Clicked Cell)
            liIndex.Add(new Tuple<int, int, bool>(x, y, ToggleCell(x, y)));
            //Right
            liIndex.Add(new Tuple<int, int, bool>((x + 1), y, ToggleCell((x + 1), y)));
            //Left
            liIndex.Add(new Tuple<int, int, bool>((x - 1), y, ToggleCell((x - 1), y)));
            //Up
            liIndex.Add(new Tuple<int, int, bool>(x, (y + 1), ToggleCell(x, (y + 1))));
            //Down
            liIndex.Add(new Tuple<int, int, bool>(x, (y - 1), ToggleCell(x, (y - 1))));
            //Remove any cells that exceed the board size (array size)
            liIndex = liIndex.Where(index => index.Item1 >= 0 && index.Item1 <= (xAxisLength - 1) && index.Item2 >= 0 && index.Item2 <= (yAxisLength - 1)).ToList();
            return liIndex;
        }

        /// <summary>
        /// Retrieves a value of a specific sell from te matrix
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool GetCellValue(int x, int y)
        {
            return matrix[x, y];
        }

        /// <summary>
        /// Sets all values of the matrix to true
        /// </summary>
        public void LightAll()
        {
            for (int x = 0; x < xAxisLength; x++)
            {
                for (int y = 0; y < yAxisLength; y++)
                {
                    matrix[x, y] = true;
                }
            }
        }

        /// <summary>
        /// Switched the state of a Cell/Tile from On to Off / Off to On
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool ToggleCell(int x, int y)
        {
            if (x >= 0 && x <= (xAxisLength - 1) && y >= 0 && y <= (yAxisLength - 1))
            {
                matrix[x, y] = !matrix[x, y];
                return matrix[x, y];
            }

            return false;
        }

        /// <summary>
        /// Determines which tiles will be lit
        /// has a 10% chance
        /// </summary>
        /// <returns></returns>
        private bool RandomBool()
        {
            int rndNumber = random.Next(0, 100);

            if (rndNumber > 10)
                return false;
            else
                return true;
        }
    }
}
