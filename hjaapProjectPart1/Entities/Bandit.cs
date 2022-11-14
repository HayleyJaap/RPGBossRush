using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hjaapProjectPart2
{
    /// <summary>
    /// Class represents a Bandit type enemy
    /// </summary>
    public class Bandit : Enemy
    {
        public Bandit()
        {
            name = "Bandit";
            strength = 5;
            intelligence = 3;
            defense = 4;
            speed = 8;
            isDefending = false;
            health = 50;
            maxHealth = 50;
            attack = 8;
            sprite = Properties.Resources.Bandit;
        }
    }
}
