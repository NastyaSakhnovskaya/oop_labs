using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
//Developer -> *
//Software -> OperationsSet(interface)
//Software -> Program -> TextProcessor -> Word
//Software -> Program -> Game -> Sapper
//Software -> Program -> Virus
namespace lab6
{
    static class Computer
    {
        static public List<Program> Programs = new List<Program>(3);

        static public void Add(Program obj)
        {
            Programs.Add(obj);
        }
        static public void Delete(Program obj)
        {
            Programs.Remove(obj);
        }
        static public void Print()
        {
            foreach(Program p in Programs)
            {
                p.Info();
                Console.WriteLine();
            }
        }
    }
    static class Controller
    {
        public enum Genres
        {
            MMORPG,
            Strategy,
            Shooter,
        }
        static public List<Program> FindGamesByType()
        {
            Console.WriteLine("Choose game genre:");
            FieldInfo[] genres = typeof(Genres).GetFields();
            for( int i = 1; i < genres.Length; i++)
            {
                Console.Write(genres[i].Name + " --- " + i);
                Console.WriteLine();
            }
            int genreIndex = Convert.ToInt32(Console.ReadLine());

            List<Program> Games = new List<Program>();
            foreach(Program p in Computer.Programs)
            {
                if (genreIndex > 0 && genreIndex < genres.Length)
                {
                    if (p.GetType() == typeof(Game)){
                        Game game = p as Game;
                        if (game.Genre == genres[genreIndex].Name)
                        {
                            Games.Add(game);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Error");
                    return Games;
                }
            }
            return Games;
        }
        static public List<Program> TextProcessorVersion()
        {
            bool isFounded = false;
            Console.WriteLine("Enter version:");
            string version = Console.ReadLine();

            List<Program> TextProcessors = new List<Program>();
            
foreach (Program p in Computer.Programs)
            {
                if (p.GetType() == typeof(TextProcessor))
                {
                    TextProcessor t = p as TextProcessor;
                    if (t.Version == version)
                    {
                        isFounded = true;
                        TextProcessors.Add(t);
                    }
                }
            }
            if (!isFounded)
            {
                Console.WriteLine("Nothing founded :(");
            }
            return TextProcessors;
        }
        static public List<Program> SortByName()
        {
            Program temp = null;
            List<Program> ProgramsBuffer = new List<Program>();
            for (int i = 0; i < Computer.Programs.Count; i++)
            {
                ProgramsBuffer.Add(Computer.Programs[i]);
            }
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 1; i < ProgramsBuffer.Count; i++)
                {
                    int result = String.Compare(ProgramsBuffer[i - 1].Name, ProgramsBuffer[i].Name);
                    if (result > 0)//swap
                    {
                        temp = ProgramsBuffer[i - 1];
                        ProgramsBuffer[i - 1] = ProgramsBuffer[i];
                        ProgramsBuffer[i] = temp;
                        flag = true;
                    }
                }
            }
            return ProgramsBuffer;
        }
    }

    class Software
    {
        public string Name { get; set; }
        public Software()
        {
            Name = "undefined";
        }
        public Software(string name)
        {
            Name = name;
        }
        public virtual void Info()
        {
            Console.WriteLine($"Name: {Name} ");
        }
    }
    abstract partial class Program : Software
    {
        public string DeveloperName { get; set; }
        public ProgramState State { get; set; }
        public Program() : base()
        {
            DeveloperName = "NoName";
            State = ProgramState.Off;
        }
        public Program(string name, string developerName) : base(name)
        {
            DeveloperName = developerName;
        }
        public enum ProgramState
        {
            Off,
            Loading,
            Ready
        }
        public void GetState()
        {
            Console.WriteLine($"Состояние программы: {State}");
        }
        public struct Properties
        {
            public string version;
            public string lastModifiedBy;

            public void Log()
            {
                Console.WriteLine($"Version of program: {version}\nLast Edit By: {lastModifiedBy}");
            }
        }
    }
    class TextProcessor : Program
    {
        public string Version { get; set; }

        public TextProcessor() : base()
        {
            Version = "1.0.0";
        }
        public TextProcessor(string name, string developerName, string version) : base(name, developerName)
        {
            Version = version;
        }
        public override void Info()
        {
            base.Info();
            Console.WriteLine($"Version: {Version} ");
        }
        public override string ToString()
        {
            Console.WriteLine(base.ToString());
            return $"Version: {Version}";
        }
    }
    class Word : TextProcessor
    {
        public string SpecificColor { get; set; }
        public Word() : base()
        {
            Name = "Word";//override default field's value
            SpecificColor = "blue";
        }
        public Word(string developerName, string version) : this()
        {
            DeveloperName = developerName;
            Version = version;
        }
        public override void Info()
        {
            base.Info();
            Console.WriteLine($"Specific Color: {SpecificColor} ");
        }
        public override string ToString()
        {
            Console.WriteLine(base.ToString());
            return $"Specific color: {SpecificColor}";
        }
    }
    class Game : Program
    {
        public string Genre { set; get; }
        public Game()
        {
            Genre = "undefined genre";
        }
        public Game(string name, string developerName, string genre) : base(name, developerName)
        {
            Genre = genre;
        }
        public override void Info()
        {
            base.Info();
            Console.WriteLine($"Genre: {Genre}");
        }
        public override string ToString()
        {
            Console.WriteLine(base.ToString());
            return $"genre: {Genre}";
        }
    }
    class Sapper : Game
    {
        public bool IsOnline { set; get; }
        public Sapper() : base()
        {
            Name = "Sapper";
            Genre = "Puzzle";
            IsOnline = false;
        }
        public Sapper(string developerName) : this()
        {
            DeveloperName = developerName;
        }
        public override void Info()
        {
            base.Info();
            Console.WriteLine($"Is online: {IsOnline}");
        }
        public void Start()
        {
            Console.WriteLine("Sapper is ready to play...");
        }

        public void GetStatistics()
        {
            Console.WriteLine("Wins: 28\nAchievements: 25");
        }

        public void Close()
        {
            Console.WriteLine("Are you sure to exit Sapper?");
        }
    }
    class Virus : Program
    {
        public string Target { get; set; }
        public Virus() : base()
        {
            Target = "Operating System (default)";
        }
        public Virus(string name, string developer, string target) : base(name, developer)
        {
            Target = target;
        }
        public override void Info()
        {
            base.Info();
            Console.WriteLine($"Target: {Target}");
        }        
        public override string ToString()
        {
            Console.WriteLine(base.ToString());
            return $"target: {Target}";
        }
    }
    class Laba
    {
        static void Main(string[] args)
        {
            Console.WriteLine("///////// Partial Class in Different files test");
            Virus virus2 = new Virus("Chameleon", "Yura", "Data Base");
            virus2.Info();
            Console.WriteLine();
            Virus virus1 = new Virus("qwe", "Yura", "OS");
            virus1.Info();
            Console.Write("Are objects equal?  ");
            if (virus1.Equals(virus2)) {
                Console.WriteLine("Yes");
            }
            else {
                Console.WriteLine("No!");
            }

            Console.WriteLine();
            Console.WriteLine("///////// Enum test");
            Game Dota2 = new Game("Dota 2", "Valve", "MMORPG");
            Dota2.Info();
            Dota2.GetState();
            Console.WriteLine("Включаем программу...");
            Dota2.State = Program.ProgramState.Loading;
            Dota2.GetState();
            Dota2.State = Program.ProgramState.Ready;
            Dota2.GetState();


            Console.WriteLine();
            Console.WriteLine("///////// Struct test");

            Virus structVirus = new Virus();
            Virus.Properties props = new Virus.Properties
            {
                version = "1.0.2",
                lastModifiedBy = "Kubarko"
            };
            props.Log();


            Console.WriteLine();
            Console.WriteLine("///////// Class-Container test");

            Word wordProgram = new Word();
            Sapper sapperProgram = new Sapper();
            Game gameProgram = new Game("Dota 2", "Valve", "MMORPG");
            Computer.Add(wordProgram);
            Computer.Add(sapperProgram);
            Computer.Add(gameProgram);
            Computer.Add(new Game("Crusader Kings 3", "Paradox", "Strategy"));
            Console.WriteLine("\n*** Printing all objects before deleting ***");
            Computer.Print();
            Computer.Delete(gameProgram);
            Console.WriteLine("\n*** Printing all objects after deleting ***");
            Computer.Print();



            Console.WriteLine("///////// Class-Controller test");
            Console.WriteLine();
            Game gameController1 = new Game("Dota 2", "Valve", "MMORPG");
            Game gameController2 = new Game("Dota 3", "Ubisoft", "MMORPG");
            Game gameController3 = new Game("Dota 15", "Paradox", "MMORPG");
            Game gameController4 = new Game("Counter-Strike", "Valve", "Shooter");
            Computer.Add(gameController1);
            Computer.Add(gameController2);
            Computer.Add(gameController3);
            Computer.Add(gameController4);
            

            List<Program> GamesSortedByGenre = Controller.FindGamesByType();
            foreach(Game p in GamesSortedByGenre)
            {
                p.Info();
                Console.WriteLine();
            }

            Console.WriteLine("///////// Class-Controller test 2");
            Console.WriteLine();
            TextProcessor tController1 = new TextProcessor("Texter", "Ivan", "1.0.0");
            TextProcessor tController2 = new TextProcessor("Edit Me", "Helen Frolova", "1.2.0");
            TextProcessor tController3 = new TextProcessor();
            Word tController4 = new Word("John Worder", "1.0.1");
            Word tController5 = new Word();
            Computer.Add(tController1);
            Computer.Add(tController2);
            Computer.Add(tController3);
            Computer.Add(tController4);
            Computer.Add(tController5);

            List<Program> TextProcessorsFilteredByVersion = Controller.TextProcessorVersion();
            foreach (TextProcessor t in TextProcessorsFilteredByVersion)
            {
                t.Info();
                Console.WriteLine();
            }

            Console.WriteLine("//////////// Sorting Test");
            Console.WriteLine("Before Sorting: ");
            foreach (Program p in Computer.Programs)
            {
                p.Info();
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("After Sorting: ");
            List<Program> SortedPrograms = Controller.SortByName();
            foreach (Program p in SortedPrograms)
            {
                p.Info();
                Console.WriteLine();
            }
        }
    }
}
