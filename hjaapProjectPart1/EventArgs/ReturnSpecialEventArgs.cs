using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hjaapProjectPart2
{
    /// <summary>
    /// Event args to return info from when a special skill has been used
    /// </summary>
    public class ReturnSpecialEventArgs : EventArgs
    {
        string message;
        Hero attacker;
        List<Enemy> enemies = new List<Enemy>();
        Entity Target = new Entity();

        public ReturnSpecialEventArgs(string message, Hero attacker)
        {
            this.message = message;
            this.attacker = attacker;
        }
        public string Message { get => message; set => message = value; }
        public List<Enemy> Enemies { get => enemies; set => enemies = value; }
        public Entity Target1 { get => Target; set => Target = value; }
        public Hero Attacker { get => attacker; set => attacker = value; }
    }
}
