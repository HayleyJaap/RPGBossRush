using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hjaapProjectPart2
{
    /// <summary>
    /// Event args used for when an enemy character attacks
    /// </summary>
    public class EnemyTurnEventArgs : EventArgs
    {
        Entity attacker;

        public EnemyTurnEventArgs(Entity attacker)
        {
            this.attacker = attacker;
        }

        public Entity Attacker { get => attacker; set => attacker = value; }
    }
}
