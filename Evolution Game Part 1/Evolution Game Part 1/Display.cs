using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution_Game_Part_1
{
    // handles displaying data to the console
    class Display
    {
        // the size of the world that is displayed
        public int[] displaySize = { 0, 0 };
        int[] cordOfTopLeftLoadedTile = { 0, 0 };
        int[] cellCordOfTopLeftLoadedCell = { 0, 0 };
        List<List<char>> loadedCells = new List<List<char>>();
        int[] cellsToLoad = { 0, 0 };
        int[] cellRadiusToLoad = { 0, 0 };
        int maxX = 0;
        int minX = 0;
        int maxY = 0;
        int minY = 0;
        /// <summary>
        /// Prints the section of the world the player is in (currently just prints whole world but that wont work for the full game)
        /// </summary>
        /// <param name="actorList">list of all actors in the game</param>
        /// <param name="world">the world in use</param>
        public void printWorld(List<Actor> actorList, World world, Player player)
        {
            // temp fix as some situations will allow more than one actor on a location at a time
            // if there is an actor there do not print the map char instead use actor char
            bool actorOnPos = false;
            if (!(player.position.xWithCellX + displaySize[0] > world.worldMap.GetLength(1)*world.getCellSize - 1) && !(player.position.xWithCellX - displaySize[0] < 0))
            {
                maxX = player.position.x + displaySize[0];
                minX = player.position.x - displaySize[0];
            }
            if (!(player.position.yWithCellY + displaySize[1] > world.worldMap.GetLength(0)*world.getCellSize - 1) && !(player.position.yWithCellY - displaySize[1] < 0))
            {
                maxY = player.position.y + displaySize[1];
                minY = player.position.y - displaySize[1];
            }

            // loops through each data point in the map
            for (int y = minY; y <= maxY; y++)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    // resets to false for each tile
                    actorOnPos = false;
                    // checks if there is an actor there
                    // This is inneficient but will do for now
                    for (int c = 0; c < actorList.Count; c++)
                    {
                        // if there is an actor at that posistion
                        if (actorList[c].position.xWithCellX - cordOfTopLeftLoadedTile[0] == x + player.position.cellX * world.getCellSize - cordOfTopLeftLoadedTile[0] && actorList[c].position.yWithCellY - cordOfTopLeftLoadedTile[1] == y + player.position.cellY * world.getCellSize - cordOfTopLeftLoadedTile[1])
                        {
                            // print the actor instead of the map symbol
                            Console.Write(actorList[c].symbol);
                            actorOnPos = true;
                        }
                        // if there is no actor there print the world char
                        if (!actorOnPos)
                        {
                            Console.Write(loadedCells[y + player.position.cellY * world.getCellSize - cordOfTopLeftLoadedTile[1]][x + player.position.cellX * world.getCellSize - cordOfTopLeftLoadedTile[0]]);
                        }
                    }
                }
            

            /*for (int y = 0; y < world.getCellSize; y++)
            {
                for (int x = 0; x < world.getCellSize; x++)
                {
                    // resets to false for each tile
                    actorOnPos = false;
                    // checks if there is an actor there
                    // This is inneficient but will do for now
                    for (int c = 0; c < actorList.Count; c++)
                    {
                        // if there is an actor at that posistion
                        if (actorList[c].position.x == x && actorList[c].position.y == y)
                        {
                            // print the actor instead of the map symbol
                            Console.Write(actorList[c].symbol);
                            actorOnPos = true;
                        }
                        // if there is no actor there print the world char
                        if (!actorOnPos)
                        {
                            Console.Write(world.worldMap[player.position.cellY, player.position.cellX][y, x]);
                        }
                    }
                }*/

                

                // goes to next line
                Console.WriteLine();
            }
        }

        /// <summary>
        /// clears the console
        /// </summary>
        public void clear()
        {
            Console.Clear();
        }

        /// <summary>
        /// This sets the size of the loaded cell array and needs to be called before any displaying happens
        /// </summary>
        /// <param name="world">the world in use by the game</param>
        public void setLoadedCellsSize(World world)
        {
            // sets the number of cells to load in the x axis so there is a buffer of one cell beyond the view range
            cellRadiusToLoad[0] = (displaySize[0] / world.getCellSize + 1);
            cellsToLoad[0] = ((int)(displaySize[0] / world.getCellSize + 1)) * 2 + 1;
            // sets the number of cells to load in the x axis so there is a buffer of one cell beyond the view range
            cellRadiusToLoad[1] = (displaySize[1] / world.getCellSize + 1);
            cellsToLoad[1] = ((int)(displaySize[1] / world.getCellSize + 1)) * 2 + 1;

            // sets the size of the loaded cell 2D array
            //loadedCells = new char[cellsToLoad[1] * world.getCellSize, cellsToLoad[0] * world.getCellSize];
        }

        /// <summary>
        /// loads the world cells into the loaded cells array
        /// </summary>
        /// <param name="world">world in use</param>
        /// <param name="player">the player of the game</param>
        public void setLoadedCells(World world, Player player)
        {
            // list of the cells to load and their location
            List<intXY> cellsIDToLoad = new List<intXY>();
            // bool for if the cord of the top left tile in the top left cell is set
            bool topLeftDefined = true;
            // inilizes values for storing width and heigh in cells for the loaded cell array
            int cellsIDToLoadWidth = 0;
            int cellsIDToLoadHeight = 0;
            // the x value that gets stored in the cellIDToLoad
            int storeX = 0;
            int storeY = 0;
            // fings the IDs of all the cells to load
            for(int y = 0; y < cellsToLoad[0]; y++ )
            {
                // if the cell is a real cell load it
                if (!(player.position.cellY + y + (-1 * cellRadiusToLoad[0]) < 0 || player.position.cellY + y + (-1 * cellRadiusToLoad[0]) > world.worldMap.GetLength(0) - 1))
                {
                    // finds all of the cells in the x dimension
                    for (int x = 0; x < cellsToLoad[1]; x++)
                    {
                        // if the cell is a real cell load it
                        if(!(player.position.cellX + x + (-1 * cellRadiusToLoad[1]) < 0 || player.position.cellX + x + (-1 * cellRadiusToLoad[1]) > world.worldMap.GetLength(1) - 1))
                        {
                            // sets the cord of the top left tile of the top left cell
                            if (topLeftDefined)
                            {
                                topLeftDefined = false;
                                // sets the cell cord to the cell cord of the cell
                                cellCordOfTopLeftLoadedCell[0] = player.position.cellX + x + (-1 * cellRadiusToLoad[0]);
                                cellCordOfTopLeftLoadedCell[1] = player.position.cellY + y + (-1 * cellRadiusToLoad[1]);
                                // sets the cord to the cord of the top left tile in the top left cell
                                cordOfTopLeftLoadedTile[0] = (player.position.cellX + x + (-1 * cellRadiusToLoad[0])) * world.getCellSize;
                                cordOfTopLeftLoadedTile[1] = (player.position.cellY + y + (-1 * cellRadiusToLoad[1])) * world.getCellSize;
                            }
                            // adds the cell to the cells ID to load array
                            cellsIDToLoad.Add(new intXY(storeX, storeY, player.position.cellX + x + (-1 * cellRadiusToLoad[1]), player.position.cellY + y + (-1 * cellRadiusToLoad[0])));
                            storeX++;
                        }
                    }
                    storeY++;
                    // stores the width and height of the cellID array
                    cellsIDToLoadWidth = storeX;
                    cellsIDToLoadHeight = storeY;
                }
                storeX = 0;
            }
            // clears the loaded cell array
            loadedCells.Clear();
            // initilizes the loaded cells array to the correct size
            for (int y = 0; y < cellsIDToLoadHeight * world.getCellSize; y++)
            {
                loadedCells.Add(new List<char>());
                for (int x = 0; x < cellsIDToLoadWidth * world.getCellSize; x++)
                {
                    loadedCells[y].Add(' ');
                }
            }
            // adding the tiles from the cells to the loaded cell array
            for (int cellY = 0; cellY < cellsIDToLoadHeight; cellY++)
            {
                for (int cellX = 0; cellX < cellsIDToLoadWidth; cellX++)
                {
                    for (int y = 0; y < world.getCellSize; y++)
                    {
                        for (int x = 0; x < world.getCellSize; x++)
                        {
                            loadedCells[cellY * world.getCellSize + y][cellX * world.getCellSize + x] = world.worldMap[cellCordOfTopLeftLoadedCell[1] + cellY, cellCordOfTopLeftLoadedCell[0] + cellX][y, x];
                        }
                    }
                }
            }
        }
    }

    class intXY
    {
        int x;
        int y;
        int cellX;
        int cellY;
        public intXY(int x, int y, int cellX, int cellY)
        {
            this.x = x;
            this.y = y;
            this.cellX = cellX;
            this.cellY = cellY;
        }
    }
}
