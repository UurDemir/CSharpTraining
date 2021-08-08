using System;
using System.Diagnostics;

namespace KeywordAndConstructor
{
    class Program
    {
        static void Main(string[] args)
        {
            Human human = new()
            {
                Name = "Mustafa",
                LastName = "Köle",
                FirstSeen = "3 million years ago",
                Kind = "Homo",
                PlanetOrigin ="Earth" 
            };

            Bug bug = new()
            {
                FirstSeen = "3 billion years ago",
                Kind = "Bug",
                LegsCount = 8,
                PlanetOrigin = "Mars"
            };

            WriteInfo(human);
            WriteInfo(bug);


            decimal a = 1;
            int b = 2;
            a = b;

            string creatureHumanInfo = human;
            string creatureBugInfo = bug;

            Creature humanCreature = (Creature)creatureHumanInfo;
            Creature bugCreature = (Creature)creatureBugInfo;

        }

        private static void WriteInfo<T>(T obj) where T : Creature
        {
            Console.WriteLine($"Kind : {obj.Kind} FirstSeen : {obj.FirstSeen} PlanetOrigin : {obj.PlanetOrigin}");
        }

        #region Static Constructor
        private static void StaticContructorTest()
        {
            Method1();
            Method2();
        }

        private static void Method1()
        {
            var programInfo = new ProgramInfo();
            Console.WriteLine($"Program Start Date : {ProgramInfo.ProgramStartDate.Ticks} Current Job : {programInfo.CurrentJob}");
        }

        private static void Method2()
        {
            var programInfo = new ProgramInfo();
            Console.WriteLine($"Program Start Date : {ProgramInfo.ProgramStartDate.Ticks} Current Job : {programInfo.CurrentJob}");
        }
        #endregion
    }

    public class ProgramInfo
    {
        public static DateTime ProgramStartDate { get; private set; }
        public string CurrentJob { get; private set; }

        static ProgramInfo()
        {
            ProgramStartDate = DateTime.Now;
        }

        public ProgramInfo()
        {
            StackTrace stackTrace = new StackTrace();
            var first = stackTrace.GetFrame(stackTrace.FrameCount - 2);

            CurrentJob = first.GetMethod().Name;
        }
    }

    class Creature
    {
        public string Kind { get; set; }
        public string FirstSeen { get; set; }
        public string PlanetOrigin { get; set; }

        public static implicit operator string(Creature creature)=> $"{creature.Kind},{creature.FirstSeen},{creature.PlanetOrigin}";
        public static explicit operator Creature(string creatureText)
        {
            Creature creature = new();

            var values = creatureText.Split(',');
            creature.Kind = values[0];
            creature.FirstSeen = values[1];
            creature.PlanetOrigin = values[2];


            return creature;
        }
    }

    class Human : Creature
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }

    class Bug : Creature
    {
        public int LegsCount { get; set; }
    }
}
