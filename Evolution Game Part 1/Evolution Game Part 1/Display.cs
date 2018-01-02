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
        /// <summary>
        /// Prints the section of the world the player is in (currently just prints whole world but that wont work for the full game)
        /// </summary>
        /// <param name="actorList">list of all actors in the game</param>
        /// <param name="world">the world in use</param>
        public void printWorld(List<Actor> actorList, World world)
        {
            // temp fix as some situations will allow more than one actor on a location at a time
            // if there is an actor there do not print the map char instead use actor char
            bool actorOnPos = false;
            // loops through each data point in the map
            for (int a = 0; a < world.worldMap.GetLength(0); a++)
            {
                for (int b = 0; b < world.worldMap.GetLength(1); b++)
                {
                    // resets to false for each tile
                    actorOnPos = false;
                    // checks if there is an actor there
                    // This is inneficient but will do for now
                    for (int c = 0; c < actorList.Count; c++)
                    {
                        // if there is an actor at that posistion
                        if (actorList[c].position.x == b && actorList[c].position.y == a)
                        {
                            // print the actor instead of the map symbol
                            Console.Write(actorList[c].symbol);
                            actorOnPos = true;
                        }
                        // if there is no actor there print the world char
                        if (!actorOnPos)
                        {
                            Console.Write(world.worldMap[a, b]);
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
    }
}
