using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Developer -> *
//Software -> OperationsSet(interface)
//Software -> Program -> TextProcessor -> Word
//Software -> Program -> Game -> Sapper
//Software -> Program -> Virus
namespace lab5
{
    class Printer
    {
        public string IAmPrinting(Object obj)
        {
            return obj.ToString();
        }
    }
    interface ITest
    {
        void Move();
    }
    abstract class Moving
    {
        public abstract void Move();
    }
    class Transport : Moving, ITest
    {
        public override void Move()
        {
            Console.WriteLine("Car is moving");
        }
        void ITest.Move()
        {
            Console.WriteLine("Dog is moving");
        }
    }
    interface IFunctions
    {
        void Start();
        void GetStatistics();
        void Close();
    }
    interface IOperations
    {
        string ProgramStatus { get; }
        void Copy();
        void Paste();
        void Undo();
        void Save();
    }
    sealed class Developer
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public Developer()
        {
            Name = "Ivan";
            SurName = "Ivanovich";
        }
        public Developer(string name, string surname)
        {
            Name = name;
            SurName = surname;
        }
        public void Greet()
        {
            Console.WriteLine($"Hello, my name is {Name} {SurName}");
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
    abstract class Program : Software
    {
        public string DeveloperName { get; set; }
        public Program() : base()
        {
            DeveloperName = "NoName";
        }
        public Program(string name, string developerName) : base(name)
        {
            DeveloperName = developerName;
        }
        public override void Info()
        {
            base.Info();
            Console.WriteLine($"Developer: {DeveloperName} ");
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || this.GetType() != obj.GetType())
            {
                return false;
            }
            Program comparedObj = (Program)obj;
            if (comparedObj.DeveloperName == this.DeveloperName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public override string ToString()
        {
            return $"This is an object of {this.GetType()} type, with {this.GetHashCode()} hashcode.\nName of the program is {Name}\ndeveloper: {DeveloperName}";
        }
    }
    class TextProcessor : Program, IOperations
    {
        public string DevelopedStudio { get; set; }
        public string ProgramStatus { get; set; }

        public TextProcessor() : base()
        {
            DevelopedStudio = "Unknown Studio";
            ProgramStatus = "off";
        }
        public TextProcessor(string name, string developerName, string developedStudio) : base(name, developerName)
        {
            DevelopedStudio = developedStudio;
            ProgramStatus = "running...";
        }
        public override void Info()
        {
            base.Info();
            Console.WriteLine($"Developed Studio: {DevelopedStudio} ");
        }

        public void Copy()
        {
            Console.WriteLine("Used Copy function in Text Processor");
        }

        public void Paste()
        {
            Console.WriteLine("Used Paste function in Text Processor");
        }

        public void Undo()
        {
            Console.WriteLine("Used Undo function in Text Processor");
        }

        public void Save()
        {
            Console.WriteLine("Saved Text Processor's file");
        }
        public override string ToString()
        {
            Console.WriteLine(base.ToString());
            return $"Studio developed: {DevelopedStudio}";
        }
    }
    class Word : TextProcessor
    {
        public string SpecificColor { get; set; }
        public Word() : base()
        {
            Name = "Word";//override default field's value
            DevelopedStudio = "Microsoft";
            SpecificColor = "blue";
        }
        public Word(string developerName) : this()
        {
            DeveloperName = developerName;
            ProgramStatus = "running";
        }
        public override void Info()
        {
            base.Info();
            Console.WriteLine($"Specific Color: {SpecificColor} ");
        }
        new public void Copy()
        {
            Console.WriteLine("Used Copy function in Word"); 
        }

        new public void Paste()
        {
            Console.WriteLine("Used Paste function in Word");
        }

        new public void Undo()
        {
            Console.WriteLine("Used Undo function in Word");
        }

        new public void Save()
        {
            Console.WriteLine("Saved Word's file");
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
    class Sapper : Game, IFunctions
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
    class Virus : Program, IFunctions
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

        public void Start()
        {
            Console.WriteLine("VIRUS started working...");
        }

        public void GetStatistics()
        {
            Console.WriteLine("Infected Computers: 17\nDestroyed files: 53");
        }

        public void Close()
        {
            Console.WriteLine("VIRUS stoped working.");
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
            Developer dev1 = new Developer();
            dev1.Greet();

            Developer dev2 = new Developer("Nikita", "Kubarko");
            dev2.Greet();

            Console.WriteLine("--------------");

            Software soft1 = new Software();
            soft1.Info();
            Console.WriteLine();

            Software soft2 = new Software("Software 1");
            soft2.Info();
            Console.WriteLine();

            //Console.WriteLine("---- Class Program ----");
            //Program program1 = new Program("Paint", "Alex");
            //program1.Info();
            //Console.WriteLine();

            //Program program2 = new Program();
            //program2.Info();
            //Console.WriteLine();

            Console.WriteLine("---- Class Text Processor ----");
            TextProcessor Note = new TextProcessor();
            Note.Info();
            Console.WriteLine();

            TextProcessor WordPad = new TextProcessor("WordPad", "Pete", "ProgressiveProgers");
            WordPad.Info();
            Console.WriteLine();

            Console.WriteLine("---- Class Word ----");
            Word Word = new Word();
            Word.Info();
            Console.WriteLine();

            Word Word2 = new Word("John");
            Word2.Info();
            Console.WriteLine();

            Console.WriteLine("---- Class Game ----");
            Game game1 = new Game();
            game1.Info();
            Console.WriteLine();

            Game game2 = new Game("Dota 2", "Valve", "MMORPG");
            game2.Info();
            Console.WriteLine();

            Console.WriteLine("---- Class Sapper ----");
            Sapper sapper1 = new Sapper();
            sapper1.Info();
            Console.WriteLine();

            Sapper sapper2 = new Sapper("Mike Sapperson");
            sapper2.Info();
            Console.WriteLine();

            Console.WriteLine("---- Class Virus ----");
            Virus virus1 = new Virus();
            virus1.Info();
            Console.WriteLine();

            Virus virus2 = new Virus("Chameleon", "...", "Data Base");
            virus2.Info();
            Console.WriteLine();

            Console.WriteLine("---- Interfaces Test ----");

            WordPad.Copy();
            Word2.Copy();

            Note.Save();
            Word.Save();

            virus2.Close();
            sapper1.Close();

            Console.WriteLine();
            Console.WriteLine("---- Same Method's Name in Interface and Abstract Class ----");

            Moving TransportableObj = new Transport();
            TransportableObj.Move();
            ((ITest)TransportableObj).Move();
            ITest TransportableObj2 = new Transport();
            TransportableObj2.Move();
            Console.WriteLine();

            Console.WriteLine("---- Overriding Object's Methods Test ----");

            Console.WriteLine(WordPad.ToString());
            Console.WriteLine();
            Console.WriteLine(Word.ToString());
            Console.WriteLine();
            Console.WriteLine(sapper2.ToString());
            Console.WriteLine();
            Console.WriteLine(virus2.ToString());
            Console.WriteLine();

            Console.Write("Объекты game2 и game3 равны? ");
            Program game3 = new Game("Counter Strike", "Valve", "Shooter");
            Console.WriteLine(game2.Equals(game3));//Developer's Name
            Console.WriteLine();

            Sapper TypeSapperObj = new Sapper("George");
            TypeSapperObj.GetStatistics();
            IFunctions ISapperObj = new Sapper("George");
            ISapperObj.GetStatistics();
            //Проверяем возможности преобазований классов и интерфейсов этих классов
            if (ISapperObj is Sapper)
            {
                Console.WriteLine("ISapperObj(объект интерфейсного типа) можно преобразовать в тип Sapper");
            }
            else
            {
                Console.WriteLine("ISapperObj(объект интерфейсного типа) нельзя преобразовать в тип Sapper");
            }
            if (TypeSapperObj is IFunctions)
            {
                Console.WriteLine("TypeSapperObj(объект типа Sapper) можно преобразовать в интерфейсный тип IFunctios");
            }
            else
            {
                Console.WriteLine("TypeSapperObj(объект типа Sapper) нельзя преобразовать в интерфейсный тип IFunctios");
            }
            Sapper TypeSapperObj2 = ISapperObj as Sapper;
            TypeSapperObj2.Info();//Работает метод класса, хотя для интерфейсного типа он не работал (преобразовали из interface в Sapper)
            IFunctions ISapperObj2 = TypeSapperObj as IFunctions;
            //ISapperObj2.Info(); --> error
            Console.WriteLine();


            Program Pr1, Pr2;
            Pr1 = new Word("Mike");
            TextProcessor textProcessorObjFromPr1 = Pr1 as TextProcessor;
            if (textProcessorObjFromPr1 != null)
            {
                textProcessorObjFromPr1.Info();
            }
            else
            { 
                Console.WriteLine("Невозможно преобразовать Word к TextProcessor");
            }
            Pr2 = new Game("PUBG", "Valve", "Battle Royale");
            Sapper sapperFromGame = Pr2 as Sapper;
            if (sapperFromGame != null)
            {
                sapperFromGame.Info();
            }
            else
            {
                Console.WriteLine("Невозможно преобразовать Game к Sapper");
            }
            Console.WriteLine();

            Printer Printer = new Printer();
            Object[] objectsMas = new Object[] { WordPad, Word2, game3, sapper2, virus1, Printer };
            for (int i = 0; i < objectsMas.Length; i++)
            {
                Console.WriteLine(Printer.IAmPrinting(objectsMas[i])) ;
                Console.WriteLine();
            }
        }
    }
}
