using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution_Game_Part_1
{
    /// <summary>
    /// contains commonly used data structures such as enums
    /// </summary>
    interface Common
    {
        actorType type();
    }

    /// <summary>
    /// The type of the actors
    /// </summary>
    public enum actorType
    {
        player,
        techieCivilian,
        techieGuard,
        native,
        predator,
        prey
    };
}
