using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hjaapProjectPart2
{
    /// <summary>
    /// Event args used to pass info to character class to perform a special skill
    /// </summary>
    public class SpecialEventArgs : EventArgs
    {
        List<Enemy> enemies = new List<Enemy>();
        Entity target = new Entity();

        public List<Enemy> Enemies { get => enemies; set => enemies = value; }
        public Entity Target { get => target; set => target = value; }
    }
}
