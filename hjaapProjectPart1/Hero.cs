using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hjaapProjectPart2
{
    /// <summary>
    /// This class represents a hero or player type character
    /// </summary>
    public class Hero : Entity
    {
        protected int skillPoints;
        protected int tag;
        public int SkillPoints { get => skillPoints; set => skillPoints = value; }
        public int Tag { get => tag; set => tag = value; }
    }
}
