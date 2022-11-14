using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hjaapProjectPart2
{
    /// <summary>
    /// Class represents a Cleric type player character
    /// </summary>
    public class Cleric : Hero
    {
        //event to return to logic
        public event EventHandler<ReturnSpecialEventArgs> ReturnSpecial;

        string message;

        public Cleric()
        {
            name = "Cleric";
            strength = 4;
            intelligence = 10;
            defense = 10;
            speed = 5;
            isDefending = false;
            health = 100;
            maxHealth = 100;
            skillPoints = 75;
            maxSkillPoints = 75;
            attack = 8;
            tag = 3;
            sprite = Properties.Resources.Cleric;
        }

        /// <summary>
        /// Method to use Cleric's skill
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UseSkill(object sender, SpecialEventArgs e)
        {
            //heal target
            e.Target.Health = e.Target.Health + ((intelligence * 2) + strength);

            //health can't be more than maxHealth
            if(e.Target.Health > e.Target.MaxHealth)
            {
                e.Target.Health = e.Target.MaxHealth;
            }
            //update message
            message = $"{name} force fed {e.Target.Name} waffles and healed them by {intelligence + strength} health points!\n";
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
