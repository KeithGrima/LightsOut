using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LightsOut.Controllers;

namespace UnitTests
{
    [TestClass]
    public class LightsOutTest
    {
        /// <summary>
        /// Check Size of Matrix
        /// </summary>
        [TestMethod]
        public void TestCheckMatrixLength()
        {
            LightMatrixController matrixController = new LightMatrixController();
            var matrix = matrixController.GenerateMatrix(5, 5);
            Assert.IsTrue(matrix.Length == 25);
        }

        /// <summary>
        /// Check Size of Matrix
        /// </summary>
        [TestMethod]
        public void TestMatrixForLitTiles()
        {
            LightMatrixController matrixController = new LightMatrixController();
            var matrix = matrixController.GenerateMatrix(5, 5);

            var hasTrue = false;

            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (matrix[x, y] == true)
                        hasTrue = true;
                }
            }

            Assert.IsTrue(hasTrue);
        }

        /// <summary>
        /// Set all tiles on(true)
        /// </summary>
        [TestMethod]
        public void TestSetAllTrue()
        {
            LightMatrixController matrixController = new LightMatrixController();
            var matrix = matrixController.GenerateMatrix(5, 5);

            matrixController.LightAll();

            var hasTrue = true;

            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (matrix[x, y] == false)
                        hasTrue = false;
                }
            }

            Assert.IsTrue(hasTrue);
        }

        /// <summary>
        /// Check the it is always returning 4 correct addjacent tiles when middle tile is selected
        /// </summary>
        [TestMethod]
        public void TestAddjacentTiles()
        {
            LightMatrixController matrixController = new LightMatrixController();
            var matrix = matrixController.GenerateMatrix(5, 5);

            var addajacentCells = matrixController.GetAdjacentCells(2, 2);

            Assert.IsNotNull(addajacentCells);
            Assert.IsTrue(addajacentCells.Count == 5);

            Assert.IsTrue(addajacentCells[0].Item1 == 2);
            Assert.IsTrue(addajacentCells[0].Item2 == 2);

            Assert.IsTrue(addajacentCells[1].Item1 == 3);
            Assert.IsTrue(addajacentCells[1].Item2 == 2);

            Assert.IsTrue(addajacentCells[2].Item1 == 1);
            Assert.IsTrue(addajacentCells[2].Item2 == 2);

            Assert.IsTrue(addajacentCells[3].Item1 == 2);
            Assert.IsTrue(addajacentCells[3].Item2 == 3);

            Assert.IsTrue(addajacentCells[4].Item1 == 2);
            Assert.IsTrue(addajacentCells[4].Item2 == 1);
        }

        /// <summary>
        /// Test that ValidateBoard only return true whenn all tiles are lit(true)
        /// </summary>
        [TestMethod]
        public void TestValidateNonCompleteBoard()
        {
            LightMatrixController matrixController = new LightMatrixController();
            var matrix = matrixController.GenerateMatrix(5, 5);

            var valid = matrixController.ValidateBoard();

            Assert.IsFalse(valid);
        }

        /// <summary>
        /// Tests that ValidateBoard return true after LightAll is called
        /// </summary>
        [TestMethod]
        public void TestValidateCompleteBoard()
        {
            LightMatrixController matrixController = new LightMatrixController();
            var matrix = matrixController.GenerateMatrix(5, 5);

            matrixController.LightAll();
            var valid = matrixController.ValidateBoard();

            Assert.IsTrue(valid);
        }

        /// <summary>
        /// Test GetCellValue by comparing value from index with value returned from GetCellValue(same index)
        /// </summary>
        [TestMethod]
        public void TestGetCellValue()
        {
            LightMatrixController matrixController = new LightMatrixController();
            var matrix = matrixController.GenerateMatrix(5, 5);

            var value1 = matrix[0, 0];
            var value2 = matrix[1, 2];
            var value3 = matrix[2, 3];
            var value4 = matrix[3, 1];
            var value5 = matrix[4, 4];

            var currentValue1 = matrixController.GetCellValue(0, 0);
            var currentValue2 = matrixController.GetCellValue(1, 2);
            var currentValue3 = matrixController.GetCellValue(2, 3);
            var currentValue4 = matrixController.GetCellValue(3, 1);
            var currentValue5 = matrixController.GetCellValue(4, 4);

            Assert.AreEqual(value1, currentValue1);
            Assert.AreEqual(value2, currentValue2);
            Assert.AreEqual(value3, currentValue3);
            Assert.AreEqual(value4, currentValue4);
            Assert.AreEqual(value5, currentValue5);
        }

        /// <summary>
        /// Test that after a cell if toggled the opposite of its current value is returned
        /// </summary>
        [TestMethod]
        public void TestToggleCell()
        {
            LightMatrixController matrixController = new LightMatrixController();
            var matrix = matrixController.GenerateMatrix(5, 5);

            var value1 = matrix[0, 0];
            var value2 = matrix[1, 2];
            var value3 = matrix[2, 3];
            var value4 = matrix[3, 1];
            var value5 = matrix[4, 4];

            var toggle1 = matrixController.ToggleCell(0, 0);
            var toggle2 = matrixController.ToggleCell(1, 2);
            var toggle3 = matrixController.ToggleCell(2, 3);
            var toggle4 = matrixController.ToggleCell(3, 1);
            var toggle5 = matrixController.ToggleCell(4, 4);

            Assert.AreNotEqual(value1, toggle1);
            Assert.AreNotEqual(value2, toggle2);
            Assert.AreNotEqual(value3, toggle3);
            Assert.AreNotEqual(value4, toggle4);
            Assert.AreNotEqual(value5, toggle5);
        }

        /// <summary>
        /// Test that when calling ToggleCell with an out of range index it return false
        /// This is mainly handled in another method to filter out out of range objects
        /// </summary>
        [TestMethod]
        public void TestOutOfRangeToggle()
        {
            LightMatrixController matrixController = new LightMatrixController();
            var matrix = matrixController.GenerateMatrix(5, 5);

            var range1 = matrixController.ToggleCell(-1, -1);
            var range2 = matrixController.ToggleCell(10, 1);

            Assert.IsFalse(range1);
            Assert.IsFalse(range2);
        }

        /// <summary>
        /// Test GetAddjacent Cells to filter out any cells that are not within the board
        /// Tiles Tested - Upper Left Corner, Lower Left Corner, Upper Right Corner, Lower Right Corner
        /// Center Top Tile, Center Top Tile, Center Left Tile and Center Right Tile
        /// </summary>
        [TestMethod()]
        public void TestAddjacentTileLimitOutOfRange()
        {
            LightMatrixController matrixController = new LightMatrixController();
            var matrix = matrixController.GenerateMatrix(5, 5);

            var addajacentCellsUpperLeft = matrixController.GetAdjacentCells(0, 0);
            var addajacentCellsUpperRight = matrixController.GetAdjacentCells(4, 0);
            var addajacentCellsLowerRight = matrixController.GetAdjacentCells(4, 4);
            var addajacentCellsLowerLeft = matrixController.GetAdjacentCells(0, 4);

            var addajacentCellsCenterUp = matrixController.GetAdjacentCells(2, 0);
            var addajacentCellsCenterDown = matrixController.GetAdjacentCells(0, 2);
            var addajacentCellsCenterRight = matrixController.GetAdjacentCells(4, 2);
            var addajacentCellsCenterLeft = matrixController.GetAdjacentCells(2, 4);

            Assert.IsTrue(addajacentCellsLowerLeft.Count == 3);
            Assert.IsTrue(addajacentCellsUpperRight.Count == 3);
            Assert.IsTrue(addajacentCellsLowerRight.Count == 3);
            Assert.IsTrue(addajacentCellsLowerLeft.Count == 3);

            Assert.IsTrue(addajacentCellsCenterUp.Count == 4);
            Assert.IsTrue(addajacentCellsCenterDown.Count == 4);
            Assert.IsTrue(addajacentCellsCenterRight.Count == 4);
            Assert.IsTrue(addajacentCellsCenterLeft.Count == 4);
        }

        /// <summary>
        /// Test that game ends after final upper left tile is 'clicked'
        /// </summary>
        [TestMethod()]
        public void TestFinalClickUpperLeft()
        {
            LightMatrixController matrixController = new LightMatrixController();
            var matrix = matrixController.GenerateMatrix(5, 5);
            matrixController.LightAll();

            matrixController.ToggleCell(0, 0);
            matrixController.ToggleCell(1, 0);
            matrixController.ToggleCell(0, 1);

            Assert.IsFalse(matrixController.ValidateBoard());

            matrixController.GetAdjacentCells(0, 0);

            Assert.IsTrue(matrixController.ValidateBoard());
        }

        /// <summary>
        /// Test that game ends after final lower left tile is 'clicked'
        /// </summary>
        [TestMethod()]
        public void TestFinalClickLowerLeft()
        {
            LightMatrixController matrixController = new LightMatrixController();
            var matrix = matrixController.GenerateMatrix(5, 5);
            matrixController.LightAll();

            matrixController.ToggleCell(0, 4);
            matrixController.ToggleCell(1, 4);
            matrixController.ToggleCell(0, 3);

            Assert.IsFalse(matrixController.ValidateBoard());

            matrixController.GetAdjacentCells(0, 4);

            Assert.IsTrue(matrixController.ValidateBoard());
        }

        /// <summary>
        /// Test that game ends after final lower right tile is 'clicked'
        /// </summary>
        [TestMethod()]
        public void TestFinalClickLowerRight()
        {
            LightMatrixController matrixController = new LightMatrixController();
            var matrix = matrixController.GenerateMatrix(5, 5);
            matrixController.LightAll();

            matrixController.ToggleCell(4, 4);
            matrixController.ToggleCell(4, 3);
            matrixController.ToggleCell(3, 4);

            Assert.IsFalse(matrixController.ValidateBoard());

            matrixController.GetAdjacentCells(4, 4);

            Assert.IsTrue(matrixController.ValidateBoard());
        }

        /// <summary>
        /// Test that game ends after final upper right tile is 'clicked'
        /// </summary>
        [TestMethod()]
        public void TestFinalClickUpperRight()
        {
            LightMatrixController matrixController = new LightMatrixController();
            var matrix = matrixController.GenerateMatrix(5, 5);
            matrixController.LightAll();

            matrixController.ToggleCell(4, 0);
            matrixController.ToggleCell(3, 0);
            matrixController.ToggleCell(4, 1);

            Assert.IsFalse(matrixController.ValidateBoard());

            matrixController.GetAdjacentCells(4, 0);

            Assert.IsTrue(matrixController.ValidateBoard());
        }

        /// <summary>
        /// Test that game ends after final center tile is 'clicked'
        /// </summary>
        [TestMethod()]
        public void TestFinalClickCenter()
        {
            LightMatrixController matrixController = new LightMatrixController();
            var matrix = matrixController.GenerateMatrix(5, 5);
            matrixController.LightAll();

            matrixController.ToggleCell(2, 1);
            matrixController.ToggleCell(2, 2);
            matrixController.ToggleCell(2, 3);
            matrixController.ToggleCell(1, 2);
            matrixController.ToggleCell(3, 2);

            Assert.IsFalse(matrixController.ValidateBoard());

            matrixController.GetAdjacentCells(2, 2);

            Assert.IsTrue(matrixController.ValidateBoard());
        }
    }
}
