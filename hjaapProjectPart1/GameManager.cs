using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hjaapProjectPart2
{
    /// <summary>
    /// Managing class that handles event subscriptions
    /// </summary>
    public class GameManager
    {
        //instantiate gui and logic classes
        GameGUI gui = new GameGUI();
        GameLogic logic = new GameLogic();

        public GameManager()
        {
            //event subscriptions
            logic.HeroesUpdate += gui.HeroesUpdateHandler;
            logic.EnemiesUpdate += gui.EnemiesUpdateHandler;
            logic.GameUpdate += gui.UpdateHandler;
            gui.Attack += logic.AttackHandler;
            gui.Defend += logic.DefendHandler;
            gui.Special += logic.SpecialHandler;
            gui.EnemyTurn += logic.EnemyTurnHandler;
            logic.Death += gui.DeathHandler;
            gui.Restart += logic.RestartHandler;
            gui.RequestStats += logic.RequestStatsHandler;
            logic.ReturnStats += gui.ReturnStatsHandler;

            //call method to set up game
            logic.InitializeGame();

            //run the gui
            Application.Run(gui);
        }
    }
}
