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
        /// gets a valid int input within a range
        /// </summary>
        /// <param name="max">highest value that is accepted</param>
        /// <param name="min">lowest value that is accepted</param>
        /// <returns>the users input</returns>
        public int validIntInput(int min, int max)
        {
            // Bool for wether the user entered valid input
            bool validInput = false;
            // int to store user input for checking
            int tempInt = 0;
            // loops through until the player has entered valid data
            while (!validInput)
            {
                // lets the user know what is being asked for
                Console.Write("Enter a value between " + min + " and " + max + ": ");
                // gets the users input
                string input = Console.ReadLine();
                // tries to parse the user input to an int
                if (!int.TryParse(input, out tempInt))
                {
                    // if the input is not an int print this
                    Console.WriteLine("Please enter a whole number");
                }
                // checks to see if input is in valid range
                else if (tempInt < min || tempInt > max)
                {
                    // if the user input int is outside of the valid range
                    Console.WriteLine("Please enter a whole number between " + min + " and " + max);
                }
                // exits the loop
                else
                {
                    // exits the loop
                    validInput = true;
                }
            }
            // returns the valid user input
            return tempInt;
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
                    // temp solution will need to work with player speed when implemented
                    player.position.y--;
                    // check if cell change happens from movement.  If cell change does not happen revert check
                    if (!player.position.changeCell(world,display,player))
                    {
                        player.position.y++;
                    }
                    // if player remains within bounds move them
                    if (player.position.y > 0)
                    {
                        player.position.y--;
                    }
                    validInput = true;
                }
                else if (userInput == "a")
                {
                    // temp solution will need to work with player speed when implemented
                    player.position.x--;
                    // check if cell change happens from movement.  If cell change does not happen revert check
                    if (!player.position.changeCell(world,display,player))
                    {
                        player.position.x++;
                    }
                    // if player remains within bounds move them
                    if (player.position.x > 0)
                    {
                        // temp solution will need to work with player speed when implemented
                        player.position.x--;
                    }
                    validInput = true;
                }
                else if (userInput == "s")
                {
                    // temp solution will need to work with player speed when implemented
                    player.position.y++;
                    // check if cell change happens from movement.  If cell change does not happen revert check
                    if (!player.position.changeCell(world,display,player))
                    {
                        player.position.y--;
                    }
                    // if player remains within bounds move them
                    if (player.position.y < world.getCellSize - 1)
                    {
                        // temp solution will need to work with player speed when implemented
                        player.position.y++;
                    }
                    validInput = true;
                }
                else if (userInput == "d")
                {
                    // temp solution will need to work with player speed when implemented
                    player.position.x++;
                    // check if cell change happens from movement.  If cell change does not happen revert check
                    if (!player.position.changeCell(world,display,player))
                    {
                        player.position.x--;
                    }
                    // if player remains within bounds move them
                    if (player.position.x < world.getCellSize - 1)
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
                    display.printWorld(actorList, world, player);
                    Console.WriteLine("Invalid Input");
                }
            }
        }
    }
}
