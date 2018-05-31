using System.Collections.Generic;

namespace StarterBot.Entities
{
    public class GameState
    {
        public List<Player> Players { get; set; }
        public CellContainer[][] GameMap { get; set; }
        public GameDetails GameDetails { get; set; }
    }
}