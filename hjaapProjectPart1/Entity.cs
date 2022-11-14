using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hjaapProjectPart2
{
    /// <summary>
    /// This class represents an "entity" or character which contains stats for both types of characters
    /// </summary>
    public class Entity
    {
        protected string name;
        protected int speed;
        protected int strength;
        protected int intelligence;
        protected int defense;
        protected int health;
        protected int attack;
        protected Bitmap sprite;
        protected bool isDefending;
        protected bool isDead;
        protected int maxHealth;
        protected int maxSkillPoints;

        public int MaxHealth { get => maxHealth; }
        public string Name { get => name; set => name = value; }
        public int Speed { get => speed; set => speed = value; }
        public int Strength { get => strength; set => strength = value; }
        public int Intelligence { get => intelligence; set => intelligence = value; }
        public int Defense { get => defense; set => defense = value; }
        public int Health { get => health; set => health = value; }
        public Bitmap Sprite { get => sprite; set => sprite = value; }
        public bool IsDefending { get => isDefending; set => isDefending = value; }
        public int Attack { get => attack; set => attack = value; }
        public int MaxSkillPoints { get => maxSkillPoints; set => maxSkillPoints = value; }
        public bool IsDead { get => isDead; set => isDead = value; }
    }
}
