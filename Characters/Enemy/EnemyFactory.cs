using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRpg.Characters.Enemy
{
    public static class EnemyFactory
    {
        public static List<Enemy> CreateForestEnemies()
        {
            return new List<Enemy>
            {
                new Enemy(
                    "Goblin",
                    1,
                    "A small, green-skinned creature with a mischievous grin.",
                    5,
                    []
                ),
                new Enemy("Wolf", 2, "A wild beast with sharp teeth and a cunning gaze.", 10, []),
                new Enemy(
                    "Bandit",
                    2,
                    "A ruthless outlaw with a scarred face and a wicked blade.",
                    15,
                    []
                ),
                new Enemy(
                    "Orc",
                    3,
                    "A hulking brute with green skin and a battle-worn axe.",
                    20,
                    []
                ),
            };
        }

        public static List<Enemy> CreatePeaksEnemies()
        {
            return new List<Enemy>
            {
                new Enemy(
                    "Mountain Troll",
                    4,
                    "A massive creature with thick skin and a club.",
                    25,
                    []
                ),
                new Enemy("Ice Elemental", 5, "A being of pure ice, cold and deadly.", 30, []),
                new Enemy(
                    "Snow Leopard",
                    3,
                    "A stealthy predator with sharp claws and keen senses.",
                    20,
                    []
                ),
                new Enemy(
                    "Yeti",
                    5,
                    "A legendary beast of the mountains, feared by all who dare to climb.",
                    30,
                    []
                ),
            };
        }

        public static List<Enemy> CreateWastesEnemies()
        {
            return new List<Enemy>
            {
                new Enemy(
                    "Scavenger",
                    4,
                    "A desperate survivor in the wasteland, armed with makeshift weapons.",
                    10,
                    []
                ),
                new Enemy(
                    "Mutant",
                    5,
                    "A twisted creature, deformed by the harsh environment.",
                    35,
                    []
                ),
                new Enemy(
                    "Sand Beast",
                    6,
                    "A massive creature that burrows through the sands, striking without warning.",
                    50,
                    []
                ),
                new Enemy(
                    "Wasteland Raider",
                    5,
                    "A ruthless bandit who preys on the weak in the desolate lands.",
                    35,
                    []
                ),
            };
        }

        public static List<Enemy> CreateSwampEnemies()
        {
            return new List<Enemy>
            {
                new Enemy(
                    "Swamp Creature",
                    6,
                    "A slimy, amphibious beast that lurks in the murky waters.",
                    50,
                    []
                ),
                new Enemy(
                    "Poisonous Frog",
                    7,
                    "A small but deadly creature with toxic skin.",
                    60,
                    []
                ),
                new Enemy(
                    "Giant Mosquito",
                    7,
                    "A bloodsucking insect that drains its victims dry.",
                    80,
                    []
                ),
                new Enemy(
                    "Swamp Witch",
                    8,
                    "A mysterious figure who uses dark magic to control the swamp.",
                    100,
                    []
                ),
            };
        }
    }
}
