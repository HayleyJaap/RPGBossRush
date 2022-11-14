using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hjaapProjectPart2
{
    /// <summary>
    /// Event args used for when a character (enemy or hero) dies
    /// </summary>
    public class DeathEventArgs : EventArgs
    {
        List<Hero> deadHeroes = new List<Hero>();
        List<Enemy> deadEnemies = new List<Enemy>();

        public DeathEventArgs(List<Hero> deadHeroes, List<Enemy> deadEnemies)
        {
            this.deadHeroes = deadHeroes;
            this.DeadEnemies = deadEnemies;
        }

        public List<Hero> DeadHeroes { get => deadHeroes; set => deadHeroes = value; }
        public List<Enemy> DeadEnemies { get => deadEnemies; set => deadEnemies = value; }
    }
}
