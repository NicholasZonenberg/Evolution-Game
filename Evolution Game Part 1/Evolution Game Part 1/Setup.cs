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
        Input input;

        /// <summary>
        /// creates the setup class
        /// </summary>
        /// <param name="input">the input class for the program</param>
        public Setup(Input input)
        {
            this.input = input;
        }

        /// <summary>
        /// sets up the game (currently just sets up player name and age
        /// </summary>
        /// <param name="player">the player for the game</param>
        public void setupGame(Player player, Display display)
        {
            // asks for a name
            Console.Write("Enter your name: ");
            // puts the userinput as the players name
            player.name = Console.ReadLine();
            Console.WriteLine("Enter your age");
            // sets the players age within a valid range
            player.age = input.validIntInput(18, 23);
            // sets the displays 
            Console.WriteLine("Enter the size of the display in characters for the x axis");
            display.displaySize[0] = input.validIntInput(1, 3);
            Console.WriteLine("Enter the size of the display in characters for the y axis");
            display.displaySize[1] = input.validIntInput(1, 3);
            // sets player starting location
            player.position.x = 3;
            player.position.y = 3;
            Console.WriteLine("You are " + player.name + " and it has been " + player.age + " years since your birth.");
            Console.Write("Press enter to continue");
            Console.ReadLine();
        }
    }
}
