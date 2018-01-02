using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution_Game_Part_1
{
    // handles getting user input
    class Input
    {
        // gets user input
        public string getInput()
        {
            return (Console.ReadLine());
        }

        /// <summary>
        /// handles player movement
        /// </summary>
        /// <param name="player">the player</param>
        /// <param name="world">the world</param>
        public void playerMovement(Player player, World world, Display display, List<Actor> actorList)
        {
            // for ensuring valid user input
            bool validInput = false;
            // string for storing user input
            string userInput;
            while (!validInput)
            {
                Console.Write("Enter movement (wasd): ");
                userInput = Console.ReadLine();
                // handles valid input
                if (userInput == "w")
                {
                    if (player.position.y > 0)
                    {
                        // temp solution will need to work with player speed when implemented
                        player.position.y--;
                    }
                    validInput = true;
                }
                else if (userInput == "a")
                {
                    if (player.position.x > 0)
                    {
                        // temp solution will need to work with player speed when implemented
                        player.position.x--;
                    }
                    validInput = true;
                }
                else if (userInput == "s")
                {
                    if (player.position.y < world.worldMap.GetLength(0) - 1)
                    {
                        // temp solution will need to work with player speed when implemented
                        player.position.y++;
                    }
                    validInput = true;
                }
                else if (userInput == "d")
                {
                    if (player.position.x < world.worldMap.GetLength(1) - 1)
                    {
                        // temp solution will need to work with player speed when implemented
                        player.position.x++;
                    }
                    validInput = true;
                }
                // if input is not valid
                else
                {
                    display.clear();
                    display.printWorld(actorList, world);
                    Console.WriteLine("Invalid Input");
                }
            }
        }
    }
}
