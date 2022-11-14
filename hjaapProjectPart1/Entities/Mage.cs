using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hjaapProjectPart2
{
    /// <summary>
    /// Class represents a mage type player character
    /// </summary>
    public class Mage : Hero
    {
        public event EventHandler<ReturnSpecialEventArgs> ReturnSpecial;

        string message;
        public Mage()
        {
            name = "Mage";
            strength = 4;
            intelligence = 10;
            defense = 5;
            speed = 3;
            isDefending = false;
            health = 100;
            maxHealth = 100;
            skillPoints = 50;
            maxSkillPoints = 50;
            attack = 10;
            tag = 2;
            sprite = Properties.Resources.Mage;
        }

        /// <summary>
        /// Method to use Mage's special skill
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UseSkill(object sender, SpecialEventArgs e)
        {
            //calculate damage done
            e.Target.Health = e.Target.Health - (attack * (intelligence / 2));

            //update message
            message = $"{name} used grease splatter and attacked {e.Target.Name} for {attack * (intelligence / 2)} points of damage!\n";
            ReturnedSpecial(e.Target);
        }

        /// <summary>
        /// Raising method for ReturnSpecial event
        /// </summary>
        /// <param name="target"></param>
        private void ReturnedSpecial(Entity target)
        {
            ReturnSpecialEventArgs e = new ReturnSpecialEventArgs(message, this);
            e.Target1 = target;
            OnReturnSpecial(this, e);
        }

        /// <summary>
        /// Invoking method for ReturnSpecial event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnReturnSpecial(object sender, ReturnSpecialEventArgs e)
        {
            ReturnSpecial?.Invoke(sender, e);
        }
    }
}
