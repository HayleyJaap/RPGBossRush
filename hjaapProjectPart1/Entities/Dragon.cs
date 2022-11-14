using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hjaapProjectPart2
{
    /// <summary>
    /// Class represents a dragon type enemy
    /// </summary>
    public class Dragon : Enemy
    {
        public Dragon()
        {
            name = "Dragon";
            strength = 11;
            intelligence = 10;
            defense = 10;
            speed = 4;
            isDefending = false;
            health = 200;
            maxHealth = 200;
            attack = 15;
            sprite = Properties.Resources.Dragon;
        }
    }
}
