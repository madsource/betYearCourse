using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonSerialization
{
    public class GameInfo
    {
        public Guid Id { get; set; }
        public int PlayersPlaying { get; set; }

        public GameInfo()
        {
            this.Id = Guid.NewGuid();
        }

        public bool ConnectPlayer(string playerName)
        {
            // TODO: connect player
            PlayersPlaying++;
            return true;
        }
    }
}
