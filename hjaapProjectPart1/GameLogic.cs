using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hjaapProjectPart2
{
    /// <summary>
    /// Class handles the logic of the RPG game
    /// </summary>
    public class GameLogic
    {
        List<Entity> turnOrder = new List<Entity>();
        List<Hero> heroList = new List<Hero>();
        List<Enemy> enemyList = new List<Enemy>();
        List<Enemy> deadEnemies = new List<Enemy>();
        List<Hero> deadHeroes = new List<Hero>();
        Entity target;
        Warrior warrior;
        Mage mage;
        Cleric cleric;
        string message;
        int numEnemies;
        int currentTurn = 0;
        int roundCount = 1;
        bool won = false;
        bool done = false;
        Random rand = new Random();

        //Events
        public event EventHandler<EnemiesUpdateEventArgs> EnemiesUpdate;
        public event EventHandler<HeroesUpdateEventArgs> HeroesUpdate;
        public event EventHandler<UpdateEventArgs> GameUpdate;
        public event EventHandler<SpecialEventArgs> WarriorSpecial;
        public event EventHandler<SpecialEventArgs> MageSpecial;
        public event EventHandler<SpecialEventArgs> ClericSpecial;
        public event EventHandler<DeathEventArgs> Death;
        public event EventHandler<ReturnStatsEventArgs> ReturnStats;

        /// <summary>
        /// Constructor
        /// </summary>
        public GameLogic()
        {
            
        }

        /// <summary>
        /// Method calls all methods to set up game and trigger an update event
        /// </summary>
        public void InitializeGame()
        {
            HeroesAssemble();
            GenerateEnemies();
            DetermineTurnOrder();
            SubscribeEvents();
            GameUpdated();
        }

        /// <summary>
        /// Method to handle event subscriptions
        /// </summary>
        private void SubscribeEvents()
        {
            WarriorSpecial += warrior.UseSkill;
            MageSpecial += mage.UseSkill;
            ClericSpecial += cleric.UseSkill;
            warrior.ReturnSpecial += ReturnSpecialHandler;
            mage.ReturnSpecial += ReturnSpecialHandler;
            cleric.ReturnSpecial += ReturnSpecialHandler;
        }
        /// <summary>
        /// Method to create instances of the heroes
        /// </summary>
        private void HeroesAssemble()
        {
            heroList.Clear();
            heroList.Add(warrior = new Warrior());
            heroList.Add(mage = new Mage());
            heroList.Add(cleric = new Cleric());

            //trigger heroesUpdate event
            HeroesUpdated();
        }

        /// <summary>
        /// Method to spawn enemies for each encounter
        /// </summary>
        private void GenerateEnemies()
        {
            enemyList.Clear();

            //determine how many enemies to be spawned based on number of rounds
            switch(roundCount)
            {
                case 1:
                    numEnemies = rand.Next(1, 2);
                    break;
                case 2:
                    numEnemies = rand.Next(1, 3);
                    break;
                default:
                    numEnemies = rand.Next(1, 4);
                    break;
            }

            //determine which types of enemies are spawned based on number of rounds
            for (int i = 0; i < numEnemies; i++)
            {
                int enemy;
                switch (roundCount)
                {
                    case 1:
                        enemy = rand.Next(1, 2);
                        break;
                    case 2:
                        enemy = rand.Next(1, 3);
                        break;
                    default:
                        enemy = rand.Next(1, 4);
                        break;
                }
                
                //add enemies to list
                switch(enemy)
                {
                    case 1:
                        enemyList.Add(new Bandit());
                        break;
                    case 2:
                        enemyList.Add(new Ogre());
                        break;
                    case 3:
                        enemyList.Add(new Dragon());
                        break;
                }
                //set tag value
                enemyList[i].Tag = i;
            }

            //trigger enemiesUpdate event
            EnemiesUpdated();
        }

        /// <summary>
        /// Method determines the turn order of characters by speed
        /// </summary>
        private void DetermineTurnOrder()
        {
            turnOrder.Clear();
            turnOrder.AddRange(heroList);
            turnOrder.AddRange(enemyList);
            turnOrder = turnOrder.OrderByDescending(x => x.Speed).ToList();
        }

        /// <summary>
        /// Method to check if any heroes or enemies have died
        /// </summary>
        private void CheckDeath()
        {
            bool death = false;
            deadHeroes.Clear();
            deadEnemies.Clear();

            //check if any heroes have health less than 0
            //if they do set isDead bool and add to list of dead
            for (int i = 0; i < heroList.Count; i++)
            {
                if (heroList[i].Health <= 0)
                {
                    if (!heroList[i].IsDead)
                    {
                        death = true;
                        heroList[i].Health = 0;
                        heroList[i].IsDead = true;
                        deadHeroes.Add(heroList[i]);
                    }
                }
            }
            //repeat same process for enemies as for heroes
            for (int i = 0; i < enemyList.Count; i++)
            {
                if (enemyList[i].Health <= 0)
                {
                    if (!enemyList[i].IsDead)
                    {
                        death = true;
                        enemyList[i].Health = 0;
                        enemyList[i].IsDead = true;
                        deadEnemies.Add(enemyList[i]);
                    }
                }
            }
            //call method to check if game has finished
            CheckDone();

            //trigger death event
            if (death)
            {
                UpdateTurnOrder();
                EntityDied();
            }
        }

        /// <summary>
        /// Method to check if game is finished
        /// </summary>
        private void CheckDone()
        {
            bool enemiesDead = true;
            bool heroesDead = true;

            for (int i = 0; i < enemyList.Count; i++)
            {
                if (!enemyList[i].IsDead)
                {
                    enemiesDead = false;
                }
            }
            for (int i = 0; i < heroList.Count; i++)
            {
                if (!heroList[i].IsDead)
                {
                    heroesDead = false;
                }
            }

            if(enemiesDead)
            {
                won = true;
                done = true;
            }
            else if (heroesDead)
            {
                won = false;
                done = true;
            }
        }

        /// <summary>
        /// Method to remove dead characters from the turn order
        /// </summary>
        private void UpdateTurnOrder()
        {
            //any dead heroes
            if (deadHeroes.Count > 0)
            {
                for (int i = 0; i < deadHeroes.Count; i++)
                {
                    Hero dead = deadHeroes[i];
                    for (int j = 0; j < turnOrder.Count; j++)
                    {
                        //find dead hero in turn order list to remove it
                        if (string.Equals(dead.Name, turnOrder[j].Name))
                        {
                            turnOrder.RemoveAt(j);
                        }
                    }
                }
            }
            //any dead enemies
            if (deadEnemies.Count > 0)
            {
                for (int i = 0; i < deadEnemies.Count; i++)
                {
                    Enemy dead = deadEnemies[i];
                    for (int j = 0; j < turnOrder.Count; j++)
                    {
                        //find dead enemy in turn order list to remove it
                        if (string.Equals(dead.Name, turnOrder[j].Name))
                        {
                            turnOrder.RemoveAt(j);
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Method to save stats to file
        /// </summary>
        private void SaveStats()
        {
            //open file and read in the data
            using StreamReader reader = new StreamReader("Stats.txt");
            string max = reader.ReadLine();
            int intMax = max[0] - 48;

            //if new high score set
            if (roundCount > intMax)
            {
                //write new score to file
                using StreamWriter writer = new("Stats.txt", append: false);
                writer.WriteLine(roundCount);
            }
            
        }

        /// <summary>
        /// Handler method for player attack event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AttackHandler(object sender, AttackEventArgs e)
        {
            //increment turn counter
            currentTurn++;

            //calculate attack
            int attack;
            int damage;

            //mage deals magic damage instead of physical
            if(e.Attacker is Mage)
            {
               attack = e.Attacker.Attack + e.Attacker.Intelligence;
            }
            //all other characters do physical damage by default
            else
            {
                attack = e.Attacker.Attack + e.Attacker.Strength;
            }

            //ogre is weak to magic damage
            if(e.Target is Ogre && e.Attacker is Mage)
            {
                //calculate target's health
                int defense = e.Target.Defense / 2;
                damage = attack - defense;
                e.Target.Health = e.Target.Health - damage;
            }
            else
            {
                //calculate target's health
                damage = attack - e.Target.Defense;
                e.Target.Health = e.Target.Health - damage;
            }
            
            //create update message
            message = $"{e.Attacker.Name} attacked {e.Target.Name} for {damage} points of damage!\n";

            //call method to check if any characters died
            CheckDeath();

            //trigger update event
            GameUpdated();
        }

        /// <summary>
        /// Handler method for an enemy attack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void EnemyTurnHandler(object sender, EnemyTurnEventArgs e)
        {
            int attack = 0;
            bool valid = false;
            Hero target = new Hero();

            if (e.Attacker is Dragon)
            {
                //method to handle dragon turn
                DragonTurnHandler(e);
            }
            else
            {
                //calculate attack and increment turn counter
                attack = e.Attacker.Attack + e.Attacker.Strength;

                while(!valid)
                {
                    //randomly select target 
                    target = heroList[rand.Next(heroList.Count)];

                    //check if target is dead
                    if(!target.IsDead)
                    {
                        valid = true;
                    }
                }

                //check if that hero chose to defnd that turn
                if (target.IsDefending == true)
                {
                    //calculate target's health based on increased defense
                    target.Health = target.Health - (attack - (target.Defense * 2));

                    //update message
                    message = $"{e.Attacker.Name} attacked {target.Name} for {attack - (target.Defense * 2)} points of damage!\n";

                    //target no longer defending
                    target.IsDefending = false;
                }
                else
                {
                    //calculate target's health and create update message
                    target.Health = target.Health - (attack - target.Defense);
                    message = $"{e.Attacker.Name} attacked {target.Name} for {attack - target.Defense} points of damage!\n";
                }
            }
          
            currentTurn++;

            //call method to check if any characters died
            CheckDeath();

            //trigger update event
            GameUpdated();
        }

        /// <summary>
        /// Handler method for a dragon attack
        /// </summary>
        /// <param name="e"></param>
        private void DragonTurnHandler(EnemyTurnEventArgs e)
        {
            int attack;
            int defense;
            int damage;
            bool valid = false;
            Hero target = new Hero();

            //randomly select which attack to perform
            int chooseAttack = rand.Next(2);

            //swipe attack
            if (chooseAttack == 0)
            {
                //calculate attack
                attack = e.Attacker.Attack + e.Attacker.Strength;

                //attack deals damage to each hero character
                for (int i = 0; i < heroList.Count; i++)
                {
                    damage = attack - heroList[i].Defense;
                    heroList[i].Health = heroList[i].Health - damage;
                }
                //update message
                message = $"{e.Attacker.Name} attacked All enemies using swipe attack!\n";
            }
            //breathe fire
            else
            {
                //calculate attack as magic damage
                attack = e.Attacker.Attack + e.Attacker.Intelligence;

                while (!valid)
                {
                    //randomly select target 
                    target = heroList[rand.Next(heroList.Count)];

                    //check if target is already dead
                    if (!target.IsDead)
                    {
                        valid = true;
                    }
                }

                //check if that hero chose to defnd that turn
                if (target.IsDefending == true)
                {
                    damage = (attack - (target.Defense * 2));
                    //calculate target's health based on increased defense
                    target.Health = target.Health - damage;

                    //update message
                    message = $"{e.Attacker.Name} attacked {target.Name} for {damage} points of damage!\n";

                    //target no longer defending
                    target.IsDefending = false;
                }
                else
                {
                    //calculate target's defense
                    //mage has high magic defense
                    if(target is Mage)
                    {
                        defense = target.Defense = target.Intelligence;
                    }
                    else
                    {
                        defense = target.Defense = target.Strength;
                    }

                    //do the damage
                    damage = attack - defense;
                    target.Health = target.Health - damage;
                    message = $"{e.Attacker.Name} attacked {target.Name} for {damage} points of damage using breathe fire!\n";
                }
            }

        }

        /// <summary>
        /// Handler method for a player choosing to defend
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DefendHandler(object sender, EventArgs e)
        {
            //set defense bool to true
            turnOrder[currentTurn].IsDefending = true;

            //update message
            message = $"{turnOrder[currentTurn].Name} defended.\n";

            currentTurn++;

            //trigger update event
            GameUpdated();
        }

        /// <summary>
        /// Handler method for if player chooses to use a special move
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SpecialHandler(object sender, AttackEventArgs e)
        {
            bool skill = false;
            Hero currentHero = heroList[0];
            //find hero that chose to use special
            for (int i = 0; i < heroList.Count; i++)
            {
                if (string.Equals(heroList[i], turnOrder[currentTurn]))
                {
                    currentHero = heroList[i];
                    //check if enough skill points left
                    if (heroList[i].SkillPoints >= 10)
                    {
                        //update skill points
                        heroList[i].SkillPoints = heroList[i].SkillPoints - 10;
                        skill = true;
                    }
                }
            }
            if(skill)
            {
                //check what current entity is to perform their special
                if(currentHero is Warrior)
                {
                    WarriorSkillUsed();
                }
                if (currentHero is Mage)
                {
                    target = e.Target;
                    MageSkillUsed(e.Target);
                }
                if (currentHero is Cleric)
                {
                    target = e.Target;
                    ClericSkillUsed(e.Target);
                }

                //call method to check if any characters died
                CheckDeath();

                currentTurn++;
                GameUpdated();
            }
            
        }

        /// <summary>
        /// Handler method for ReturnSpecial event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReturnSpecialHandler(object sender, ReturnSpecialEventArgs e)
        {
            //calculate enemy's health based on which special was performed
            if (e.Attacker is Warrior)
            {
                for (int i = 0; i < enemyList.Count; i++)
                {
                    enemyList[i].Health = e.Enemies[i].Health;
                }
            }
            //cleric and mage specials only affect one target
            else
            {
                target.Health = e.Target1.Health;
            }

            message = e.Message;
        }

        /// <summary>
        /// Handler method for Restart event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RestartHandler(object sender, RestartEventArgs e)
        {
            //reset values to defaults
            won = false;
            done = false;
            currentTurn = 0;
            message = null;

            //save the stats
            SaveStats();
            roundCount++;

            //restart game
            GenerateEnemies();
            DetermineTurnOrder();
            GameUpdated();
        }

        /// <summary>
        /// Handler method for RequestStats event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RequestStatsHandler(object sender, EventArgs e)
        {
            //read stats from file
            StreamReader reader = new StreamReader("Stats.txt");
            string max = reader.ReadLine();
            int intMax = (int)max[0] - 48;

            //call raising method
            StatsRequested(intMax);
        }

        /// <summary>
        /// Raising method for ReturnStats event
        /// </summary>
        /// <param name="intMax"></param>
        private void StatsRequested(int intMax)
        {
            ReturnStatsEventArgs e = new ReturnStatsEventArgs(intMax);
            OnReturnStats(this, e);
        }

        /// <summary>
        /// Invoking method for ReturnStats event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnReturnStats(object sender, ReturnStatsEventArgs e)
        {
            ReturnStats?.Invoke(sender, e);
        }

        /// <summary>
        /// Raising method for WarriorSpecial event
        /// </summary>
        private void WarriorSkillUsed()
        {
            SpecialEventArgs e = new SpecialEventArgs();
            e.Enemies = enemyList;
            OnWarriorSpecial(this, e);
        }

        /// <summary>
        /// Invoking method for WarriorSpecial event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnWarriorSpecial(object sender, SpecialEventArgs e)
        {
            WarriorSpecial?.Invoke(sender, e);
        }

        /// <summary>
        /// Raising method for MageSpecial event
        /// </summary>
        /// <param name="target"></param>
        private void MageSkillUsed(Entity target)
        {
            SpecialEventArgs e = new SpecialEventArgs();
            e.Target = target;
            OnMageSpecial(this, e);
        }

        /// <summary>
        /// Invoking method for MageSpecial event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnMageSpecial(object sender, SpecialEventArgs e)
        {
            MageSpecial?.Invoke(sender, e);
        }

        /// <summary>
        /// Raising method for ClericSpecial event
        /// </summary>
        /// <param name="target"></param>
        private void ClericSkillUsed(Entity target)
        {
            SpecialEventArgs e = new SpecialEventArgs();
            e.Target = target;
            OnClericSpecial(this, e);
        }

        /// <summary>
        /// Invoking method for ClericSpecial event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnClericSpecial(object sender, SpecialEventArgs e)
        {
            ClericSpecial?.Invoke(sender, e);
        }

        /// <summary>
        /// Raising method for Update event
        /// </summary>
        public void GameUpdated()
        { 
            //reset turn counter if necessary
            if (currentTurn >= turnOrder.Count)
            {
                currentTurn = 0;
            }

            //create event args and call invoking method
            UpdateEventArgs e = new UpdateEventArgs(turnOrder[currentTurn], won, done);
            e.UpdateMessage = message;
            OnGameUpdate(this, e);
        }

        /// <summary>
        /// Invoking method for update event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnGameUpdate(object sender, UpdateEventArgs e)
        {
            GameUpdate?.Invoke(sender, e);
        } 
    
        /// <summary>
        /// Raising method for death event
        /// </summary>
        private void EntityDied()
        {
            DeathEventArgs e = new DeathEventArgs(deadHeroes, deadEnemies);
            OnDeath(this, e);
        }

        /// <summary>
        /// Invoking method for death event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnDeath(object sender, DeathEventArgs e)
        {
            Death?.Invoke(sender, e);
        }

        /// <summary>
        /// Raising method for EnemiesUpdate event
        /// </summary>
        private void EnemiesUpdated()
        {
            EnemiesUpdateEventArgs e = new EnemiesUpdateEventArgs(enemyList, numEnemies);
            OnEnemiesUpdate(this, e);
        }

        /// <summary>
        /// Invoking method for EnemiesUpdate event
        /// </summary>
        private void OnEnemiesUpdate(object sender, EnemiesUpdateEventArgs e)
        {
            EnemiesUpdate?.Invoke(sender, e);
        }

        /// <summary>
        /// Raising methdo for HeroesUpdate event
        /// </summary>
        private void HeroesUpdated()
        {
            HeroesUpdateEventArgs e = new HeroesUpdateEventArgs(heroList);
            OnHeroesUpdate(this, e);
        }

        /// <summary>
        /// Invoking method for HeroesUpdate event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnHeroesUpdate(object sender, HeroesUpdateEventArgs e)
        {
            HeroesUpdate?.Invoke(sender, e);
        }
    }
}
