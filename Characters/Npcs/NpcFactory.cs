using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRpg.Characters.Npcs
{
    public static class NpcFactory
    {
        public static Npc CreateBlacksmith()
        {
            return new Npc(
                "Thoren Ironhand",
                10,
                "Name’s Thoren. Used to swing swords, now I shape them. Spent half my life on battlefields, lost too many friends to blunt steel and poor forging. One day, I dropped my axe and picked up the hammer for good. Now, I build so others can survive… maybe even live.",
                1000,
                [],
                "Ah, another traveler with a blade that's seen better days. Come, let’s give it a new bite."
            );
        }

        public static Npc CreateAlchemist()
        {
            return new Npc(
                "Elira Vinthel",
                10,
                "They call me Elira. Once, I studied alchemy in a tower so tall the clouds kissed its windows. But knowledge without purpose… it burns. I lost much chasing power. Now, I mix to mend, not to control. My brews may fizz and spark, but they heal more than they harm. Usually.",
                1000,
                [],
                "Careful where you step… one wrong move, and your boots might walk on their own. How can I help?"
            );
        }

        public static Npc CreateInnkeeper()
        {
            return new Npc(
                "Marda Hearthpan",
                10,
                "Marda’s the name. Spent years cooking for kings, but their gold never warmed my heart. Lost my dear Tom to the frost, and decided I’d had enough of cold halls and colder people. Opened this little place to feed souls, not just bellies. Around here, everyone gets a second helping — and a second chance.",
                1000,
                [],
                "You look half-starved and twice as tired. Sit down, love — a good stew solves most problems."
            );
        }

        public static Npc CreateOldSage()
        {
            return new Npc("Old Sage", 10, "", 1000, [], "");
        }

        public static Npc CreateCaptain()
        {
            return new Npc(
                "Captain Rynn",
                10,
                "I’m Rynn, Captain of the city guard here in Newhaven",
                1000,
                [],
                "You're safe here, traveler. Newhaven doesn’t tolerate trouble—not from beasts, nor blades, nor beggars with silver tongues. Keep your hands clean, your weapons sheathed, and your eyes open. This city breathes peace, but peace is something we guard with steel."
            );
        }

        public static Npc CreateHealer()
        {
            return new Npc(
                "Brother Eamon",
                10,
                "I am Brother Eamon. I’ve seen too many fall — some from blades, others from burdens. I walked away from war with a satchel of herbs and a vow: to heal, not to judge. This clinic is open to all. No questions, no debts. Just rest, tea… and if needed, a quiet place to breathe again.",
                1000,
                [],
                "Wounds of the body are easy, but if your spirit aches… we have tea and silence too."
            );
        }

        public static Npc CreateGemwright()
        {
            return new Npc(
                "Brelgor Gemwright",
                10,
                "Born to miners, raised by enchanters—what else could I be but a gemwright? I learned to grind gems before I could read. But when I discovered that properly infused crystals could alter one’s very nature, I left the mines. Since then, I’ve helped warriors crush mountains and mages bend storms. Every stat has a stone, if you know how to cut it.",
                1000,
                [],
                "Looking to hit harder? Move faster? Think quicker? Then you've come to the right anvil. I don’t sell jewelry—I sell power."
            );
        }

        public static List<Npc> GetAllNpcs()
        {
            return new List<Npc>
            {
                CreateBlacksmith(),
                CreateAlchemist(),
                CreateInnkeeper(),
                CreateHealer(),
                CreateGemwright(),
                CreateCaptain(),
                CreateOldSage(),
            };
        }
        //public static List<Npc> CreateVillageNpcs()
        //{
        //    return new List<Npc>
        //    {
        //        new Npc(
        //            "Brelgor Gemwright",
        //            10,
        //            "Born to miners, raised by enchanters—what else could I be but a gemwright? I learned to grind gems before I could read. But when I discovered that properly infused crystals could alter one’s very nature, I left the mines. Since then, I’ve helped warriors crush mountains and mages bend storms. Every stat has a stone, if you know how to cut it.",
        //            1000,
        //            [],
        //            "Looking to hit harder? Move faster? Think quicker? Then you've come to the right anvil. I don’t sell jewelry—I sell power."
        //        ),
        //        new Npc(
        //            "Marda Hearthpan",
        //            10,
        //            "Marda’s the name. Spent years cooking for kings, but their gold never warmed my heart. Lost my dear Tom to the frost, and decided I’d had enough of cold halls and colder people. Opened this little place to feed souls, not just bellies. Around here, everyone gets a second helping — and a second chance.",
        //            1000,
        //            [],
        //            "You look half-starved and twice as tired. Sit down, love — a good stew solves most problems."
        //        ),
        //        new Npc(
        //            "Elira Vinthel",
        //            10,
        //            "They call me Elira. Once, I studied alchemy in a tower so tall the clouds kissed its windows. But knowledge without purpose… it burns. I lost much chasing power. Now, I mix to mend, not to control. My brews may fizz and spark, but they heal more than they harm. Usually.",
        //            1000,
        //            [],
        //            "Careful where you step… one wrong move, and your boots might walk on their own. How can I help?"
        //        ),
        //        new Npc(
        //            "Thoren Ironhand",
        //            10,
        //            "Name’s Thoren. Used to swing swords, now I shape them. Spent half my life on battlefields, lost too many friends to blunt steel and poor forging. One day, I dropped my axe and picked up the hammer for good. Now, I build so others can survive… maybe even live.",
        //            1000,
        //            [],
        //            "Ah, another traveler with a blade that's seen better days. Come, let’s give it a new bite."
        //        ),
        //        new Npc(
        //            "Brother Eamon",
        //            10,
        //            "I am Brother Eamon. I’ve seen too many fall — some from blades, others from burdens. I walked away from war with a satchel of herbs and a vow: to heal, not to judge. This clinic is open to all. No questions, no debts. Just rest, tea… and if needed, a quiet place to breathe again.",
        //            1000,
        //            [],
        //            "Wounds of the body are easy, but if your spirit aches… we have tea and silence too."
        //        ),
        //    };
        //}
    }
}
