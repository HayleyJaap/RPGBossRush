using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hjaapProjectPart2
{
    /// <summary>
    /// Event args used to send updated info between classes after every turn is completed
    /// </summary>
    public class UpdateEventArgs : EventArgs
    {
        string updateMessage;
        bool won;
        bool done;
        Entity currentEntity;

        public UpdateEventArgs(Entity currentEntity, bool won, bool done)
        {
            this.currentEntity = currentEntity;
            this.won = won;
            this.done = done;
        }

        public string UpdateMessage { get => updateMessage; set => updateMessage = value; }
        public Entity CurrentEntity { get => currentEntity; set => currentEntity = value; }
        public bool Won { get => won; set => won = value; }
        public bool Done { get => done; set => done = value; }
    }
}
