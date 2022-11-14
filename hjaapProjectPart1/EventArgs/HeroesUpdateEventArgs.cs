using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hjaapProjectPart2
{
    /// <summary>
    /// Event args used when heroes are spawned when a new game is started
    /// </summary>
    public class HeroesUpdateEventArgs : EventArgs
    {
        List<Hero> heroes = new List<Hero>();

        public HeroesUpdateEventArgs(List<Hero> heroes)
        {
            this.heroes = heroes;
        }

        public List<Hero> Heroes { get => heroes; set => heroes = value; }
    }
}
