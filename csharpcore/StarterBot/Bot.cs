using System;
using System.Linq;
using StarterBot.Entities;
using StarterBot.Enums;

namespace StarterBot
{
    public class Bot
    {
        private readonly GameState gameState;

        private readonly BuildingStats attackBuilding;
        private readonly BuildingStats defencebuilding;
        private readonly BuildingStats energyBuilding;

        private readonly int mapWidth;
        private readonly int mapHeight;
        private readonly Player me;
        private readonly Random random;

        public Bot(GameState gameState)
        {
            this.gameState = gameState;
            this.mapHeight = gameState.GameDetails.MapHeight;
            this.mapWidth = gameState.GameDetails.MapWidth;

            this.attackBuilding = gameState.GameDetails.BuildingsStats[BuildingType.Attack];
            this.defencebuilding = gameState.GameDetails.BuildingsStats[BuildingType.Defense];
            this.energyBuilding = gameState.GameDetails.BuildingsStats[BuildingType.Energy];

            this.random = new Random((int)DateTime.Now.Ticks);

            me = gameState.Players.Single(x => x.PlayerType == PlayerType.A);
        }

        public string Run()
        {

            if (me.Energy < attackBuilding.Price || me.Energy < defencebuilding.Price || me.Energy < energyBuilding.Price)
            {
                return "";
            }

            var row = 0;

            if (row <= 0)
            {
                return GainEnergy();
            }

            return Deffence();

        }

        private string GainEnergy()
        {
            var emptyRow = gameState.GameMap.Select(row => row.First()).Where(cell => cell.Buildings.Count == 0).ToList();

            if (emptyRow.Count > 0)
            {
                var xRandom = random.Next(mapWidth / 2);
                var yRandom = random.Next(mapHeight);
                var btRandom = random.Next(Enum.GetNames(typeof(BuildingType)).Length);

                while (emptyRow.Any(x => x.X == xRandom && x.Y == yRandom && x.Buildings.Any()))
                {
                    xRandom = random.Next(mapWidth / 2);
                    yRandom = random.Next(mapHeight);
                }

                return $"{xRandom},{yRandom},{btRandom}";
            }
            else
            {
                return "E";
            }
        }

        private string Attack()
        {
            var emptyRow = gameState.GameMap.Select(row => row.First()).Where(cell => cell.Buildings.Count == 0).ToList();

            if (emptyRow.Count > 0)
            {
                var xRandom = random.Next(mapWidth / 2);
                var yRandom = random.Next(mapHeight);
                var btRandom = random.Next(Enum.GetNames(typeof(BuildingType)).Length);

                while (emptyRow.Any(x => x.X == xRandom && x.Y == yRandom && x.Buildings.Any()))
                {
                    xRandom = random.Next(mapWidth / 2);
                    yRandom = random.Next(mapHeight);
                }

                return $"{xRandom},{yRandom},{btRandom}";
            }
            else
            {
                return "A";
            }
        }

        private string Deffence()
        {
            var emptyRow = gameState.GameMap.Select(row => row.First()).Where(cell => cell.Buildings.Count == 0).ToList();

            if (emptyRow.Count > 0)
            {
                var xRandom = random.Next(mapWidth / 2);
                var yRandom = random.Next(mapHeight);
                var btRandom = random.Next(Enum.GetNames(typeof(BuildingType)).Length);

                while (emptyRow.Any(x => x.X == xRandom && x.Y == yRandom && x.Buildings.Any()))
                {
                    xRandom = random.Next(mapWidth / 2);
                    yRandom = random.Next(mapHeight);
                }

                return $"{xRandom},{yRandom},{btRandom}";
            }
            else
            {
                return "D";
            }
        }
    }
}