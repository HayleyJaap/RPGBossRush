using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hjaapProjectPart2
{
    public partial class GameGUI : Form
    {
        PictureBox[] heroPBs = new PictureBox[3];
        PictureBox[] enemyPBs = new PictureBox[3];
        List<Enemy> enemies = new List<Enemy>();
        List<Hero> heroes = new List<Hero>();
        Entity target;
        Entity currentEntity;
        bool gameWon = false;

        //Events
        public event EventHandler<AttackEventArgs> Attack;
        public event EventHandler Defend;
        public event EventHandler<AttackEventArgs> Special;
        public event EventHandler<EnemyTurnEventArgs> EnemyTurn;
        public event EventHandler Restart;
        public event EventHandler RequestStats;

        /// <summary>
        /// Constructor
        /// </summary>
        public GameGUI()
        {
            InitializeComponent();

            //set default button states
            attackBtn.Enabled = false;
            defendBtn.Enabled = false;
            specialBtn.Enabled = false;

            //make picture boxes easily accessable
            heroPBs[0] = heroPB1;
            heroPBs[1] = heroPB2;
            heroPBs[2] = heroPB3;
            enemyPBs[0] = enemyPB1;
            enemyPBs[1] = enemyPB2;
            enemyPBs[2] = enemyPB3;
        }

        /// <summary>
        /// Method updates stat labels
        /// </summary>
        private void UpdateLabels()
        {
            //update labels for hero stats
            heroHP1.Text = $"{heroes[0].Health} / {heroes[0].MaxHealth}";
            heroHP2.Text = $"{heroes[1].Health} / {heroes[1].MaxHealth}";
            heroHP3.Text = $"{heroes[2].Health} / {heroes[2].MaxHealth}";
            heroSP1.Text = $"{heroes[0].SkillPoints} / {heroes[0].MaxSkillPoints}";
            heroSP2.Text = $"{heroes[1].SkillPoints} / {heroes[1].MaxSkillPoints}";
            heroSP3.Text = $"{heroes[2].SkillPoints} / {heroes[2].MaxSkillPoints}";

            //Update health labels for enemies based on number spawned
            switch (enemies.Count)
            {
                case 1:
                    enemyHPLbl1.Text = $"{enemies[0].Health} / {enemies[0].MaxHealth}";
                    enemyHPLbl2.Text = null;
                    enemyHPLbl3.Text = null;
                    break;
                case 2:
                    enemyHPLbl1.Text = $"{enemies[0].Health} / {enemies[0].MaxHealth}";
                    enemyHPLbl2.Text = $"{enemies[1].Health} / {enemies[1].MaxHealth}";
                    enemyHPLbl3.Text = null;
                    break;
                case 3:
                    enemyHPLbl1.Text = $"{enemies[0].Health} / {enemies[0].MaxHealth}";
                    enemyHPLbl2.Text = $"{enemies[1].Health} / {enemies[1].MaxHealth}";
                    enemyHPLbl3.Text = $"{enemies[2].Health} / {enemies[2].MaxHealth}";
                    break;
            }
            
        }

        /// <summary>
        /// Method to restart the game
        /// </summary>
        private void RestartGame()
        {
            //reset to default values
            attackBtn.Enabled = false;
            defendBtn.Enabled = false;
            specialBtn.Enabled = false;
            gameWon = false;

            enemyHPLbl1.Text = null;
            enemyHPLbl2.Text = null;
            enemyHPLbl3.Text = null;

            enemyPBs[0].Image = null;
            enemyPBs[1].Image = null;
            enemyPBs[2].Image = null;

            //clear the battle log
            battleLogText.Clear();

            //raise event
            GameRestarted();
        }

        /// <summary>
        /// Handler method for heroesUpdate event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HeroesUpdateHandler(object sender, HeroesUpdateEventArgs e)
        {
            //grab hero list from event args
            heroes = e.Heroes;

            //Add sprites to gui and add hero tag to picturebox tag
            for (int i = 0; i < e.Heroes.Count; i++)
            {
                heroPBs[i].Image = e.Heroes[i].Sprite;
                heroPBs[i].Tag = e.Heroes[i].Tag;
            }

        }

        /// <summary>
        /// Handler method for EnemiesUpdate event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void EnemiesUpdateHandler(object sender, EnemiesUpdateEventArgs e)
        {
            //grab list of enemies
            enemies = e.Enemies;

            //add enemy sprites to gui and set tag
            for (int i = 0; i < e.NumEnemies; i++)
            {
                enemyPBs[i].Visible = true;
                enemyPBs[i].Image = e.Enemies[i].Sprite;
                enemyPBs[i].Tag = e.Enemies[i].Tag;
            }
        }

        /// <summary>
        /// Handler method for ReturnStats event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ReturnStatsHandler(object sender, ReturnStatsEventArgs e)
        {
            //display stats to screen
            MessageBox.Show($"Highest number of levels completed in one game: {e.Max}");
        }

        /// <summary>
        /// Handler method for Update event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UpdateHandler(object sender, UpdateEventArgs e)
        {
            gameWon = e.Won;

            //reset sprite background colors to transparent
            for (int i = 0; i < enemyPBs.Length; i++)
            {
                enemyPBs[i].BackColor = Color.Transparent;
                heroPBs[i].BackColor = Color.Transparent;
            }

            attackBtn.Enabled = false;
            specialBtn.Enabled = false;
            defendBtn.Enabled = false;

            //update hero stat display on gui
            UpdateLabels();

            //grab data from event args
            battleLogText.AppendText(e.UpdateMessage);
            currentEntity = e.CurrentEntity;

            if (!e.Done)
            {
                //update the battle log
                battleLogText.AppendText($"{e.CurrentEntity.Name}'s turn!\n");
                //if hero/player character turn
                if (e.CurrentEntity is Hero)
                {
                    defendBtn.Enabled = true;
                    //update special button to have name of character
                    specialBtn.Text = $"{e.CurrentEntity.Name}";
                }
                //enemy turn
                else
                {
                    //trigger enemy turn event
                    EnemyAttacked();
                }
            }
            else
            {
                //Check if game was won or lost and restart if necessary
                if (gameWon)
                {
                    battleLogText.AppendText("Game Won!\n");
                    RestartGame();
                }
                else
                {
                    battleLogText.AppendText("Game Lost!\n");
                }
            }
            
        }

        /// <summary>
        /// Handler method for death event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DeathHandler(object sender, DeathEventArgs e)
        {
            //if any dead heroes
            if(e.DeadHeroes.Count > 0)
            {
                for (int i = 0; i < e.DeadHeroes.Count; i++)
                {
                    Hero dead = e.DeadHeroes[i];

                    for (int j = 0; j < heroPBs.Length; j++)
                    {
                        //find matching hero picturebox to reset it
                        if (String.Equals(dead.Tag, heroPBs[j].Tag))
                        {
                            //make dead hero invisible
                            heroPBs[j].Visible = false;

                            //update battle log
                            battleLogText.AppendText($"{dead.Name} died!\n");
                        }
                    }
                }
            }

            //if any dead enemies
            if (e.DeadEnemies.Count > 0)
            {
                for (int i = 0; i < e.DeadEnemies.Count; i++)
                {
                    Enemy dead = e.DeadEnemies[i];

                    for (int j = 0; j < enemyPBs.Length; j++)
                    {
                        //find matching enemy picturebox to reset it
                        if (String.Equals(dead.Tag, enemyPBs[j].Tag))
                        {
                            //make dead enemy invisible
                            enemyPBs[j].Visible = false;
                        }
                    }
                    //update battle log
                    battleLogText.AppendText($"{dead.Name} died!\n");

                }
            }

        }

        /// <summary>
        /// Raising method for EnemyTurn event
        /// </summary>
        private void EnemyAttacked()
        {
            EnemyTurnEventArgs e = new EnemyTurnEventArgs(currentEntity);
            OnEnemyTurn(this, e);
        }

        /// <summary>
        /// Invoking method for EnemyTurn event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnEnemyTurn(object sender, EnemyTurnEventArgs e)
        {
            EnemyTurn?.Invoke(sender, e);
        }

        /// <summary>
        /// Handler for attackBtn click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void attackBtn_Click(object sender, EventArgs e)
        {
            //trigger attack event
            Attacked();
        }

        /// <summary>
        /// Raising method for attack event
        /// </summary>
        private void Attacked()
        {
            AttackEventArgs e = new AttackEventArgs(target, currentEntity);
            OnAttack(this, e);
        }

        /// <summary>
        /// Invoking method for attack event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnAttack(object sender, AttackEventArgs e)
        {
            Attack?.Invoke(sender, e);
        }

        /// <summary>
        /// Handler method for enemy picturebox 1 click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnemyPB1_Click(object sender, EventArgs e)
        {
            //if enemy not dead
            if (enemies[0].Health > 0)
            {
                for (int i = 0; i < enemyPBs.Length; i++)
                {
                    enemyPBs[i].BackColor = Color.Transparent;
                    heroPBs[i].BackColor = Color.Transparent;
                }

                //highlight the enemy and set target
                enemyPB1.BackColor = Color.White;
                target = enemies[0];

                //enable attack and special buttons
                attackBtn.Enabled = true;
                specialBtn.Enabled = true;
            }
           
        }

        /// <summary>
        /// Handler method for enemy picturebox 2 click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnemyPB2_Click(object sender, EventArgs e)
        {
            //if enemy not dead
            if (enemies[1].Health > 0)
            {
                for (int i = 0; i < enemyPBs.Length; i++)
                {
                    enemyPBs[i].BackColor = Color.Transparent;
                    heroPBs[i].BackColor = Color.Transparent;
                }
                //highlight the enemy and set target
                enemyPB2.BackColor = Color.White;
                target = enemies[1];

                //enable attack and special buttons
                attackBtn.Enabled = true;
                specialBtn.Enabled = true;
            }

        }

        /// <summary>
        /// Handler method for enemy picturebox 3 click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnemyPB3_Click(object sender, EventArgs e)
        {
            //if enemy not dead
            if (enemies[2].Health > 0)
            {
                for (int i = 0; i < enemyPBs.Length; i++)
                {
                    enemyPBs[i].BackColor = Color.Transparent;
                    heroPBs[i].BackColor = Color.Transparent;
                }
                //highlight the enemy and set target
                enemyPB3.BackColor = Color.White;
                target = enemies[2];

                //enable attack and special buttons
                attackBtn.Enabled = true;
                specialBtn.Enabled = true;
            }

        }

        /// <summary>
        /// Handler method for hero picturebox 1 click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeroPB1_Click(object sender, EventArgs e)
        {
            //if hero not dead
            if (heroes[0].Health > 0)
            {
                if (!String.Equals(heroes[0].Name, currentEntity.Name))
                {
                    for (int i = 0; i < enemyPBs.Length; i++)
                    {
                        enemyPBs[i].BackColor = Color.Transparent;
                        heroPBs[i].BackColor = Color.Transparent;
                    }
                    //highlight the enemy and set target
                    heroPB1.BackColor = Color.White;
                    target = heroes[0];

                    //enable attack and special buttons
                    attackBtn.Enabled = true;
                    specialBtn.Enabled = true;
                }
                
            }
        }

        /// <summary>
        /// Handler method for hero picturebox 2 click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeroPB2_Click(object sender, EventArgs e)
        {
            //if hero not dead
            if (heroes[1].Health > 0)
            {
                if (!String.Equals(heroes[1].Name, currentEntity.Name))
                {
                    for (int i = 0; i < enemyPBs.Length; i++)
                    {
                        enemyPBs[i].BackColor = Color.Transparent;
                        heroPBs[i].BackColor = Color.Transparent;
                    }
                    //highlight the enemy and set target
                    heroPB2.BackColor = Color.White;
                    target = heroes[1];

                    //enable attack and special buttons
                    attackBtn.Enabled = true;
                    specialBtn.Enabled = true;
                }
               
            }
        }

        /// <summary>
        /// Handler method for hero picturebox 3 click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeroPB3_Click(object sender, EventArgs e)
        {
            //if hero not dead
            if (heroes[2].Health > 0)
            {
                if (!String.Equals(heroes[2].Name, currentEntity.Name))
                {
                    for (int i = 0; i < enemyPBs.Length; i++)
                    {
                        enemyPBs[i].BackColor = Color.Transparent;
                        heroPBs[i].BackColor = Color.Transparent;
                    }
                    //highlight the enemy and set target
                    heroPB3.BackColor = Color.White;
                    target = heroes[2];

                    //enable attack and special buttons
                    attackBtn.Enabled = true;
                    specialBtn.Enabled = true;
                }
                
            }
        }

        /// <summary>
        /// Handler method for defendBtn click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void defendBtn_Click(object sender, EventArgs e)
        {
            OnDefend(this, e);
        }

        /// <summary>
        /// Raising method for defend event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnDefend(object sender, EventArgs e)
        {
            Defend?.Invoke(sender, e);
        }

        /// <summary>
        /// Handler method for specialBtn click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void specialBtn_Click(object sender, EventArgs e)
        {
            AttackEventArgs eventArgs = new AttackEventArgs(target, currentEntity);
            OnSpecial(this, eventArgs);
        }

        /// <summary>
        /// Raising method for special event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnSpecial(object sender, AttackEventArgs e)
        {
            Special?.Invoke(sender, e);
        }

        /// <summary>
        /// Raising method for GameRestart event
        /// </summary>
        private void GameRestarted()
        {
            EventArgs e = new EventArgs();
            OnRestart(this, e);
        }

        /// <summary>
        /// Invoking method for GameRestart event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnRestart(object sender, EventArgs e)
        {
            Restart?.Invoke(sender, e);
        }

        /// <summary>
        /// Handler method for quit menu item click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //quit the program
            Environment.Exit(0);
        }

        /// <summary>
        /// Handler method for high scores menu item click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void highScoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fire event to get stats from logic class
            RequestStats?.Invoke(this, e);
        }

        /// <summary>
        /// Handler method for about menu item click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Programmed by Hayley Jaap for the CS3020 final project");
        }

        /// <summary>
        /// Handler method for instructions menu item click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("It's an RPG fighting game. Figure it out, pleb");
        }
    }
}

