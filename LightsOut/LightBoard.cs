using LightsOut.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
using LightsOut.Controllers;

namespace LightsOut
{
    public partial class LightBoard : Form
    {
        #region Settings
        //Length of tile(buttons)
        private const int tileHeight = 50;
        //Width of tiles(buttons)
        private const int tileWidth = 50;
        //Start Time for Count
        private DateTime startTime = new DateTime();
        //TableLayout for Board
        private TableLayoutPanel tlpGrid = null;
        //MatrixController
        private LightMatrixController matrixController = null;
        //Dimension
        private int dimension = 5;
        #endregion

        public LightBoard()
        {
            InitializeComponent();
        }

        #region Events
        private void Form1_Load(object sender, EventArgs e)
        {
            //Start Setup of Matrix and UI
            SetupGrid();
        }

        /// <summary>
        /// This method is called when any of the buttons is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToggleClick(object sender, EventArgs e)
        {
            var btnClicked = (TileButton)sender;
            var x = btnClicked.xAxis;
            var y = btnClicked.yAxis;

            //Get Addjacent Cells of this Button
            var cellsToToggle = matrixController.GetAdjacentCells(x, y);

            //Loop through all addjacent cells and turn ON/OFF
            foreach (var cell in cellsToToggle)
            {
                Toggle(cell.Item1, cell.Item2, cell.Item3);
            }

            //Validate Board after every click
            ValidateBoard();
        }

        /// <summary>
        /// Used mostly to generate Custom Boards using value suppied in txtSize
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //Read txtSize, if no value is supplied or is not a number simply set default;
            var dimensionStr = txtSize.Text;
            int customDimension = 0; int.TryParse(dimensionStr, out customDimension);

            if (customDimension == 0)
                dimension = 5;
            else
                dimension = customDimension;

            SetupGrid();
        }

        /// <summary>
        /// Light all tiles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLightAll_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < dimension; y++)
            {
                for (int x = 0; x < dimension; x++)
                {
                    var btnTile = tlpGrid.GetControlFromPosition(x, y);
                    btnTile.BackColor = Color.Lime;
                }
            }

            //Call LightAll to set all values in array to true
            matrixController.LightAll();
            //ValidateBoard to end game
            ValidateBoard();
        }
        #endregion

        #region Methods

        /// <summary>
        /// The Setup method which is called on every completion or restart of the game
        /// Sets up array structure and UI
        /// Starts Timer
        /// </summary>
        /// <param name="dimension">This parameter will determine how big the form is setup</param>
        private void SetupGrid()
        {
            //Start/Restart Setup of UI & Matrix
            matrixController = new LightMatrixController();
            tlpGrid = new TableLayoutPanel();
            tlpGrid.AutoSize = true;
            tlpGrid.Visible = false;
            grpBoxGrid.Controls.Clear();
            grpBoxGrid.Controls.Add(tlpGrid);

            //Generate Matrix, use matrix supplied to generate UI
            var grid = matrixController.GenerateMatrix(dimension, dimension);

            for (int x = 0; x < dimension; x++)
            {
                for (int y = 0; y < dimension; y++)
                {
                    var isOn = grid[x, y];
                    var btnTile = SetupButton(x, y, isOn);
                    tlpGrid.Controls.Add(btnTile, x, y);
                }
            }

            //Force Resize in case dimension is reduced
            tlpGrid.Visible = true;
            this.Size = new Size(0, 0);
            startTime = DateTime.Now;
        }

        /// <summary>
        /// Initialize TileButton(Button) for each Cell
        /// TileButton is an extension of buttons, was created to add 2 extra paramters to keep track of which button was clicked
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="isOn">Used to determine if tile's state should be on(lime) or off(green)</param>
        /// <returns></returns>
        private TileButton SetupButton(int x, int y, bool isOn)
        {
            TileButton btnTile = new TileButton();
            btnTile.Width = tileWidth;
            btnTile.Height = tileHeight;
            btnTile.Left = tileWidth * x;
            btnTile.Top = tileHeight * y;
            btnTile.BackColor = isOn == true ? Color.Lime : Color.Green;
            btnTile.xAxis = x;
            btnTile.yAxis = y;
            btnTile.Click += (s, e) => { ToggleClick(s, e); };
            return btnTile;
        }

        /// <summary>
        /// Toggle Buttons color/state
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="isOn">Toggle Buttons color/state</param>
        private void Toggle(int x, int y, bool isOn)
        {
            var btnTile = tlpGrid.GetControlFromPosition(x, y);
            btnTile.BackColor = isOn == true ? Color.Lime : Color.Green;
        }

        /// <summary>
        /// Validate Board is used to check if all tiles are lit, if yes end game, prompt alert and restart
        /// </summary>
        private void ValidateBoard()
        {
            var isValid = matrixController.ValidateBoard();

            if (isValid)
            {
                MessageBox.Show("You Win !!!. Click OK to restart game.");
                SetupGrid();
            }
        }

        /// <summary>
        /// Timer used to keep track of how many seconds have passed during a game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrCount_Tick(object sender, EventArgs e)
        {
            var secondsPassed = DateTime.Now.Subtract(startTime).TotalSeconds;
            lblSecondsValue.Text = secondsPassed.ToString("n0");
        }

        #endregion
    }
}
