using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution_Game_Part_1
{
    /// <summary>
    /// stores the world and provides world based functions
    /// </summary>
    class World
    {
        // the 2D array of chars repersenting the world map (This is very likely to be changed heavily and or deleted later in development)
        public char[,] worldMap;

        /// <summary>
        /// this will set up the world using the procedule generator (Not yet in use)
        /// </summary>
        public void SetupWorld()
        {
            // To be implemented
        }

        /// <summary>
        /// creates the world (Currently Hard Coded.  Not final)
        /// </summary>
        public World()
        {
            worldMap = new char[7, 7]
            {
                {'a','a','a','^','^','~','~' },
                {'a','a','^','^','^','~','~' },
                {'a','^','^','^','~','~','~' },
                {'a','a','a','^','^','+','~' },
                {'z','z','a','a','^','+','+' },
                {'z','z','z','w','^','+','+' },
                {'z','z','w','w','w','~','+' },
            };
        }
    }
}
