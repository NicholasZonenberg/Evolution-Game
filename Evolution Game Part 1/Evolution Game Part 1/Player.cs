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

        // Properties:
        // gets and sets the players name (the player name does not change so no set command)
        public string name
        {
            get { return _name; }
            set { }
        }
        // gets and sets the age of the player
        public int age
        {
            get { return _age; }
            // this will be used by a time class
            set { }
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
    }
}
