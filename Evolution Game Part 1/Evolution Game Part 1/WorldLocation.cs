using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//
//  First thing set this up so it can be added to the Actor interface
//

namespace Evolution_Game_Part_1
{
    /// <summary>
    /// This stores the actor location in the world and what world the player is in if needed
    /// </summary>
    class WorldLocation
    {
        // the x cordinate of the actor
        private int _x;
        // the y cordinate of the actor
        private int _y;
        // the z cordinate of the actor
        private int _z;
        // the x cord of the cell the actor is in
        private int _cellX;
        // the y cord of the cell the actor is in
        private int _cellY;
        // the worldspace that the actor is in.  This might not be needed but could be.
        private string _worldSpace;
        // world that the location is in
        World world = new World();
        // Addional data that could be added would be further subdivisions of the game world so that the entire game world is not on one huge grid

        // gets and sets the x cordinate of the actor
        public int x
        {
            get { return _x; }
            set { _x = value; }
        }
        public int xWithCellX
        {
            get { return (_x + world.getCellSize * cellX); }
        }
        // gets and sets y cordinate of the actor
        public int y
        {
            get { return _y; }
            set { _y = value; }
        }
        public int yWithCellY
        {
            get { return (_y + world.getCellSize * cellY); }
        }
        // gets and sets the z cordinate of the actor
        public int z
        {
            get { return _z; }
            set { _z = value; }
        }

        // gets and sets the x cord of the cell the actor is in
        public int cellX
        {
            get { return _cellX; }
            set { _cellX = value; }
        }
        // gets and sets the y cord of the cell the actor is in
        public int cellY
        {
            get { return _cellY; }
            set { _cellY = value; }
        }

        // gets and sets the worldspace the actor is in
        public string worldSpace
        {
            get { return _worldSpace; }
            set { _worldSpace = value; }
        }

        /// <summary>
        /// Handles moving the actor from one world cell to another
        /// </summary>
        /// <param name="world">the world in use</param>
        /// <returns>true if a cell change happened false otherwise</returns>
        public bool changeCell(World world, Display display, Player player)
        {
            // if the actor is at the right edge of a cell
            if (_x > world.getCellSize - 1)
            {
                // if there is a cell next to it
                if (_cellX < world.worldMap.GetLength(1) - 1)
                {
                    // change the actor cell x cord
                    _cellX++;
                    // reset the actors posistion to 0 within the cell
                    _x = -1;
                    // player cell changed update the loaded cells
                    display.setLoadedCells(world, player);
                    // cell change happened return true
                    return true;
                }
            }
            // if the actor is at the left edge of a cell
            if (_x < 0)
            {
                // if there is a cell next to it
                if (_cellX > 0)
                {
                    // change the actor cell x cord
                    _cellX--;
                    // reset the actors posistion to 0 within the cell
                    _x = world.getCellSize;
                    // player cell changed update the loaded cells
                    display.setLoadedCells(world, player);
                    // cell change happened return true
                    return true;
                }
            }
            // if the actor is at the bottom edge of a cell
            if (_y > world.getCellSize - 1)
            {
                // if there is a cell next to it
                if (_cellY < world.worldMap.GetLength(0) - 1)
                {
                    // change the actor cell y cord
                    _cellY++;
                    // reset the actors posistion to 0 within the cell
                    _y = -1;
                    // player cell changed update the loaded cells
                    display.setLoadedCells(world, player);
                    // cell change happened return true
                    return true;
                }
            }
            // if the actor is at the bottom edge of a cell
            if (_y < 0)
            {
                // if there is a cell next to it
                if (_cellY > 0)
                {
                    // change the actor cell y cord
                    _cellY--;
                    // reset the actors posistion to 0 within the cell
                    _y = world.getCellSize;
                    // player cell changed update the loaded cells
                    display.setLoadedCells(world, player);
                    // cell change happened return true
                    return true;
                }
            }
            return false;
        } 
    }
}
