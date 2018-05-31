using System;
using System.IO;
using Newtonsoft.Json;
using StarterBot.Entities;

namespace StarterBot
{
    public class Program
    {
        private static string commandFileName = "command.txt";
        private static string stateFileName = "state.json";

        static void Main(string[] args)
        {
            var gameState = JsonConvert.DeserializeObject<GameState>(File.ReadAllText(stateFileName));

            var command = new Bot(gameState).Run();

            File.WriteAllText(commandFileName, command);
        }
    }
}