using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution_Game_Part_1
{
    // this is the generic class for actors.  Not going to be used directly
    interface Actor
    {
        // the name of the actor
        string name
        {
            get;
            set;
        }

        // how old the actor is
        int age
        {
            get;
            set;
        }

        // the ascii symbol of the actor
        char symbol
        {
            get;
            set;
        }

        // space reserved for the body class not yet made that will include the various components and body parts of the actor
        //

        // the type of the actor
        Common.actorType type
        {
            get;
            set;
        }

        // the list of tags for the actor as the actor is likely to have multiple tags
        List<Common.actorTags> tagList
        {
            get;
            set;
        }

        WorldLocation position
        {
            get;
            set;
        }
    }
}
