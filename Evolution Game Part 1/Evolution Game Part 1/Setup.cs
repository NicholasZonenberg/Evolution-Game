using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution_Game_Part_1
{
    /// <summary>
    /// handles game set up
    /// </summary>
    class Setup
    {
        /// <summary>
        /// sets up the game (currently just sets up player name and age
        /// </summary>
        /// <param name="player">the player for the game</param>
        public void setupGame(Player player)
        {
            // asks for a name
            Console.Write("Enter your name: ");
            // puts the userinput as the players name
            player.name = Console.ReadLine();
            // Bool for wether the user entered valid input
            bool validInput = false;
            // int to store user input for checking
            int tempInt = 0;
            // loops through until the player has entered valid data
            while (!validInput)
            {
                // lets the user know what is being asked for
                Console.Write("Enter an age between 18 and 24: ");
                // gets the users input
                string input = Console.ReadLine();
                // tries to parse the user input to an int
                if (!int.TryParse(input, out tempInt))
                {
                    // if the input is not an int print this
                    Console.WriteLine("Please enter a whole number");
                }
                // checks to see if input is in valid range
                else if (tempInt < 18 || tempInt > 24)
                {
                    // if the user input int is outside of the valid range
                    Console.WriteLine("Please enter a whole number between 18 and 24");
                }
                // exits the loop
                else
                {
                    // exits the loop
                    validInput = true;
                    // sets the players age
                    player.age = tempInt;
                }
            }
            // sets player starting location
            player.position.x = 3;
            player.position.y = 3;
            Console.WriteLine("You are " + player.name + " and it has been " + player.age + " years since your birth.");
            Console.Write("Press enter to continue");
            Console.ReadLine();
        }
    }
}
