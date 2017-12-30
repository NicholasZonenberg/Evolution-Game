using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution_Game_Part_1
{
    /// <summary>
    /// Static class with enums used in other classes
    /// </summary>
    public static class Common
    {
        /// <summary>
        /// the type of the actor
        /// </summary>
        public enum actorType
        {
            player,
            techieGuard,
            techie,
            techieScientist,
            predator,
            prey
        };

        /// <summary>
        /// tags for the actor describing them
        /// </summary>
        public enum actorTags
        {
            skilled,
            unique,
            young
        };

        /// <summary>
        /// tags for body parts describing them
        /// </summary>
        public enum bodyPartTags
        {
            vital,
            nonVital
        };

        /// <summary>
        /// tags for describing weapons both natraul and technological
        /// </summary>
        public enum weaponTags
        {
            blunt,
            sharp,
            serrated,
            pircing,
            slashing
        };
    }
}
