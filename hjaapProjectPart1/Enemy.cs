using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hjaapProjectPart2
{
    /// <summary>
    /// This class represents an enemy type character
    /// </summary>
    public class Enemy : Entity
    {
        protected int tag;

        public int Tag { get => tag; set => tag = value; }
    }
}
