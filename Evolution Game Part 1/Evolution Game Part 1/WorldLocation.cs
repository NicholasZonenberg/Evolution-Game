using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        // the worldspace that the actor is in.  This might not be needed but could be.
        private string _worldSpace;
        // Addional data that could be added would be further subdivisions of the game world so that the entire game world is not on one huge grid

        // gets and sets the x cordinate of the actor
        public int x
        {
            get { return _x; }
            set { _x = value; }
        }
        // gets and sets y cordinate of the actor
        public int y
        {
            get { return _y; }
            set { _y = value; }
        }
        // gets and sets the z cordinate of the actor
        public int z
        {
            get { return _z; }
            set { _z = value; }
        }
        // gets and sets the worldspace the actor is in
        public string worldSpace
        {
            get { return _worldSpace; }
            set { _worldSpace = value; }
        }

    }
}
