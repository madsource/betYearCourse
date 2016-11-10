using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JsonSerialization
{
    class Program
    {
        static void Main(string[] args)
        {

            Game game = new Game("blizzard", "blizardonlinecasino.com", "/onlinecasino.com");

            game.GameInfo.ConnectPlayer("Spas");

            var json = JsonConvert.SerializeObject(game, Formatting.Indented);

            Console.WriteLine(json);

            var newGame = JsonConvert.DeserializeObject<Game>(json);

            Console.WriteLine("is deep copy? "+ (newGame.GameInfo != game.GameInfo));
            Console.WriteLine(newGame.Provider);
        }
    }
}
