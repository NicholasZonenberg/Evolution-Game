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
        int[] cordOfTopRightLoadedTile = { 0, 0 };
        char[,] loadedCells;
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
            /*if (!(player.position.x + displaySize[0] > world.worldMap.GetLength(1) - 1) && !(player.position.x - displaySize[0] < 0))
            {
                maxX = player.position.x + displaySize[0];
                minX = player.position.x - displaySize[0];
            }
            if (!(player.position.y + displaySize[1] > world.worldMap.GetLength(0) - 1) && !(player.position.y - displaySize[1] < 0))
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
                        if (actorList[c].position.x == x && actorList[c].position.y == y)
                        {
                            // print the actor instead of the map symbol
                            Console.Write(actorList[c].symbol);
                            actorOnPos = true;
                        }
                        // if there is no actor there print the world char
                        if (!actorOnPos)
                        {
                            Console.Write(world.worldMap[y, x]);
                        }
                    }
                }*/

            for (int y = 0; y < world.getCellSize; y++)
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
                }

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
            loadedCells = new char[cellsToLoad[1] * world.getCellSize, cellsToLoad[0] * world.getCellSize];
        }

        /// <summary>
        /// loads the world cells into the loaded cells array
        /// </summary>
        /// <param name="world">world in use</param>
        /// <param name="player">the player of the game</param>
        public void setLoadedCells(World world, Player player)
        {
            List<intXY> cellsIDToLoad = new List<intXY>();
            int storeX = 0;
            int storeY = 0;
            for(int y = 0; y < cellsToLoad[0]; y++ )
            {
                if (!(player.position.cellY + y + (-1 * cellRadiusToLoad[0]) < 0 || player.position.cellY + y + (-1 * cellRadiusToLoad[0]) > world.worldMap.GetLength(0) - 1))
                {
                    for (int x = 0; x < cellsToLoad[1]; x++)
                    {
                        if(!(player.position.cellX + x + (-1 * cellRadiusToLoad[1]) < 0 || player.position.cellX + x + (-1 * cellRadiusToLoad[1]) > world.worldMap.GetLength(1) - 1))
                        {
                            cellsIDToLoad.Add(new intXY(storeX, storeY, player.position.cellX + x + (-1 * cellRadiusToLoad[1]), player.position.cellY + y + (-1 * cellRadiusToLoad[0])));
                            storeX++;
                        }
                    }
                    storeY++;
                }
                storeX = 0;
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
