using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hjaapProjectPart2
{
    /// <summary>
    /// Event args used anytime a new set of enemies is spawned for an encounter
    /// </summary>
    public class EnemiesUpdateEventArgs : EventArgs
    {
        List<Enemy> enemies = new List<Enemy>();
        int numEnemies;

        public EnemiesUpdateEventArgs(List<Enemy> enemies, int numEnemies)
        {
            this.enemies = enemies;
            this.numEnemies = numEnemies;
        }
        public List<Enemy> Enemies { get => enemies; set => enemies = value; }
        public int NumEnemies { get => numEnemies; set => numEnemies = value; }
    }
}
