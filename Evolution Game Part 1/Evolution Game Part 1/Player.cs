using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution_Game_Part_1
{
    class Player : Actor
    {
        // Fields:
        // name of player
        private string _name;
        // player age
        private int _age;
        // player type (will always be player)
        private Common.actorType _type;
        // player tags (Will change as the game progresses)
        private List<Common.actorTags> _tagList;
        // the symbol of the player
        private char _symbol;
        // the posistion of the player
        private WorldLocation _position;

        // Properties:
        // gets and sets the players name (the player name does not change so no set command)
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        // gets and sets the age of the player
        public int age
        {
            get { return _age; }
            // this will be used by a time class
            set { _age = value; }
        }
        // gets and sets the actor type (the player does not change type)
        public Common.actorType type
        {
            get { return _type; }
            set { }
        }
        // gets and sets the list of tags for the player
        public List<Common.actorTags> tagList
        {
            get { return _tagList; }
            set { }
        }
        // gets and sets the player symbol
        public char symbol
        {
            get { return _symbol; }
            set { }
        }
        // gets and sets the players position
        public WorldLocation position
        {
            get { return _position; }
            set { }
        }

        // Constructor:
        /// <summary>
        /// Creates the player from input
        /// </summary>
        public Player ()
        {
            // sets the player type to player
            _type = Common.actorType.player;
            // at this point the player starts with no tags.  This will likely change as development continues
            _tagList = new List<Common.actorTags>();
            // sets the player symbol
            _symbol = 'P';
            // sets the players posistion (not final needs changing once consturctor is made)
            _position = new WorldLocation();
        }
    }
}
