using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hjaapProjectPart2
{
    /// <summary>
    /// Class is used to pass information back to gui when stas requested
    /// </summary>
    public class ReturnStatsEventArgs : EventArgs
    {
        int max;

        public ReturnStatsEventArgs(int max)
        {
            this.max = max;
        }

        public int Max { get => max; set => max = value; }
    }
}
