using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution_Game_Part_1
{
    class Program
    { 
        static void Main(string[] args)
        {
            // the list that contains all the actors in the game
            List<Actor> actorList = new List<Actor>();
            // creates the player
            Player player = new Player();
            // the input object which will handle player input
            Input input = new Input();
            // the setup object which is used for setting up the game
            Setup gameSetup = new Setup(input);
            // creates the display class that will handle displaying the game
            Display display = new Display();
            // sets up the world for the game
            World world = new World();
            // adds the player to the actor list
            actorList.Add(player);
            // calls the Setup setup game function to set up the game
            gameSetup.setupGame(player, display);
            // sets initial display settings
            display.setLoadedCellsSize(world);
            display.setLoadedCells(world, player);

            // game loop:
            while (true)
            {
                // clears the screen
                display.clear();
                // prints the world
                display.printWorld(actorList, world, player);
                // gets and moves the player
                input.playerMovement(player, world, display, actorList);
            }
        }
    }
}
