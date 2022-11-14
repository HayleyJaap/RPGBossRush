using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hjaapProjectPart2
{
    /// <summary>
    /// Class represents a warrior type player character
    /// </summary>
    public class Warrior : Hero 
    {
        public event EventHandler<ReturnSpecialEventArgs> ReturnSpecial;
        string message;
        public Warrior()
        {
            name = "Warrior";
            strength = 10;
            intelligence = 1;
            defense = 10;
            speed = 10;
            isDefending = false;
            maxHealth = 100;
            health = 100;
            skillPoints = 50;
            maxSkillPoints = 50;
            attack = 15;
            tag = 1;
            sprite = Properties.Resources.Fighter;
        }
        
        /// <summary>
        /// Method to use Warrior's special skill
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UseSkill(object sender, SpecialEventArgs e)
        {
            //deal damage to each enemy, mitigating their defense
            for (int i = 0; i < e.Enemies.Count; i++)
            {
                e.Enemies[i].Health = e.Enemies[i].Health - (attack * 3);
            }

            //update message and trigger update event
            message = $"{name} used spatula slap and attacked all enemies!\n";
            ReturnedSpecial(e.Enemies);
        }

        /// <summary>
        /// Raising method for ReturnSpecial event
        /// </summary>
        /// <param name="enemies"></param>
        private void ReturnedSpecial(List<Enemy> enemies)
        {
            ReturnSpecialEventArgs e = new ReturnSpecialEventArgs(message, this);
            e.Enemies = enemies;
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
