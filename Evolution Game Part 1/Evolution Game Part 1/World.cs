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
        public char[,][,] worldMap;

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
            worldMap = new char[3, 3][,];
            worldMap[0, 0] = new char[5, 5]
            {
                {'=','=','=','-','-' },
                {'=','=','=','=','-' },
                {'=','=','=','=','-' },
                {'=','=','=','=','=' },
                {'~','~','=','=','-' }
            };
            worldMap[1, 0] = new char[5, 5]
            {
                {'~','~','=','=','-' },
                {'~','~','=','-','-' },
                {'~','~','~','-','-' },
                {'~','-','-','-','-' },
                {'~','~','~','^','-' }
            };
            worldMap[2, 0] = new char[5, 5]
            {
                {'~','~','^','^','^' },
                {'~','~','^','^','^' },
                {'~','~','^','^','^' },
                {'~','^','^','^','#' },
                {'^','^','#','#','#' }
            };
            worldMap[0, 1] = new char[5, 5]
            {
                {'-','*','*','*','*' },
                {'-','*','*','H','*' },
                {'-','-','H','H','H' },
                {'-','-','H','H','H' },
                {'-','-','-','H','H' }
            };
            worldMap[0, 2] = new char[5, 5]
            {
                {'*','*','*','*','*' },
                {'*','*','*','H','H' },
                {'*','*','H','H','H' },
                {'H','H','H','@','H' },
                {'H','@','@','@','@' }
            };
            worldMap[1, 1] = new char[5, 5]
            {
                {'-','-','O','H','H' },
                {'-','-','O','H','H' },
                {'-','O','O','H','H' },
                {'-','-','O','O','H' },
                {'^','-','O','O','O' }
            };
            worldMap[1, 2] = new char[5, 5]
            {
                {'H','H','@','@','@' },
                {'H','H','M','@','@' },
                {'H','O','M','M','M' },
                {'O','O','O','M','M' },
                {'O','O','O','M','~' }
            };
            worldMap[2, 1] = new char[5, 5]
            {
                {'^','-','-','O','O' },
                {'^','^','-','X','O' },
                {'#','^','X','X','X' },
                {'#','#','#','X','X' },
                {'#','#','#','#','#' }
            };
            worldMap[2, 2] = new char[5, 5]
            {
                {'O','O','M','~','~' },
                {'X','O','O','~','~' },
                {'X','X','#','~','~' },
                {'X','#','#','#','~' },
                {'#','#','#','#','#' }
            };
        }
    }
}
