using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRpg.Characters.Enemy;

namespace ConsoleRpg.Map
{
    public static class LocationFactory
    {
        public static List<Location> GetLocations(string name)
        {
            return new List<Location>
            {
                new Location(
                    "Elderglen Forest",
                    "A mystical woodland where ancient trees whisper secrets and strange lights dance at night.\r\n\r\n",
                    "Gentle Trials",
                    EnemyFactory.CreateForestEnemies(),
                    []
                ),
                new Location(
                    "Frostveil Peaks",
                    "Frozen mountain range where howling winds and icy beasts guard forgotten paths.",
                    "Weathered Struggles",
                    EnemyFactory.CreatePeaksEnemies(),
                    []
                ),
                new Location(
                    "Ashen Wastes",
                    "A barren wasteland where survival is a daily struggle.",
                    "Scorched Peril",
                    EnemyFactory.CreateWastesEnemies(),
                    []
                ),
                new Location(
                    "Miredeep Swamp",
                    "A murky, humid swamp where the ground swallows the careless and the air hums with danger.",
                    "Drowned in Dread",
                    EnemyFactory.CreateSwampEnemies(),
                    []
                ),
            };
        }
    }
}
