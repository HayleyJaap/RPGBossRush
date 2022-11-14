using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hjaapProjectPart2
{
    /// <summary>
    /// Event args used when attack is selected by a player character
    /// </summary>
    public class AttackEventArgs : EventArgs
    {
        Entity target;
        Entity attacker;
        int currentTurn;

        public AttackEventArgs(Entity target, Entity attacker)
        {
            this.target = target;
            this.attacker = attacker;
        }

        public Entity Target { get => target; set => target = value; }
        public Entity Attacker { get => attacker; set => attacker = value; }
        public int CurrentTurn { get => currentTurn; set => currentTurn = value; }
    }
}
