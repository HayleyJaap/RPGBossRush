using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hjaapProjectPart2
{
    /// <summary>
    /// Class represents an Ogre type enemey
    /// </summary>
    public class Ogre : Enemy 
    {
        public Ogre()
        {
            name = "Ogre";
            strength = 10;
            intelligence = 1;
            defense = 10;
            speed = 2;
            isDefending = false;
            health = 100;
            maxHealth = 100;
            attack = 12;
            sprite = Properties.Resources.Ogre;
        }
    }
}
