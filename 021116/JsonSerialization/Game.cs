using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonSerialization
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Provider { get; set; }
        public string ProviderGameUrl { get; set; }
        public string GameUrl { get; set; }
        public GameInfo GameInfo { get; set; }

        public Game(string provider, string providerGameUrl, string gameUrl)
        {
            this.Provider = provider;
            this.ProviderGameUrl = providerGameUrl;
            this.GameUrl = gameUrl;
            this.Id = Guid.NewGuid(); // generate unique Global Unique ID
            this.GameInfo = new GameInfo();
        }
    }
}
