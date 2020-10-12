using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;
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
            foreach (Program p in Programs)
            {
                p.Info();
                Console.WriteLine();
            }
        }
        static public void DeleteByIndex(int index)
        {
            if(index > Programs.Count || index < 0)
            {
                throw new MyCustomOutOfRangeException(
                    "Попытка удалить несуществующий элемент (кастомное исключение 1)", 
                    "Обращение к null (кастомное исключение 1)"
                );

            }
            else
            {
                Programs.RemoveAt(index);
            }
        }
        static public void UpdateGame(Program program)
        {
            Game game = program as Game;
            if(game == null)
            {
                throw new MyGameUpdateException(
                    "Попытка обновить не игру (кастомное исключение 2)",
                    "Невозможно преобразовать входящий тип (кастомное исключение 2)"
                    );
            }
            else
            {
                Console.WriteLine("Game was updated!");
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
            for (int i = 1; i < genres.Length; i++)
            {
                Console.Write(genres[i].Name + " --- " + i);
                Console.WriteLine();
            }
            int genreIndex = Convert.ToInt32(Console.ReadLine());

            List<Program> Games = new List<Program>();
            foreach (Program p in Computer.Programs)
            {
                if (genreIndex > 0 && genreIndex < genres.Length)
                {
                    if (p.GetType() == typeof(Game))
                    {
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
    abstract /*partial*/ class Program : Software
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
        //public struct Properties
        //{
        //    public string version;
        //    public string lastModifiedBy;

        //    public void Log()
        //    {
        //        Console.WriteLine($"Version of program: {version}\nLast Edit By: {lastModifiedBy}");
        //    }
        //}

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
        public int NumberOfOpens { get; set; }
        public int NumberOfErroredOpens { get; set; }
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
        public Word(int numOfOpens, int numOfErroredOpens)
        {
            Debug.Assert(numOfOpens > -1 && numOfErroredOpens > -1, "Uncorrect values");
            
            NumberOfOpens = numOfOpens;
            NumberOfErroredOpens = numOfErroredOpens;
        }
        public override void Info()
        {
            base.Info();
            Console.WriteLine($"Specific Color: {SpecificColor} ");
        }
        public void GetInfoAboutOpens()
        {
            Console.WriteLine($"Запусков с ошибкой: {NumberOfErroredOpens}\nВсего запусков: {NumberOfOpens}");
        }
        public override string ToString()
        {
            Console.WriteLine(base.ToString());
            return $"Specific color: {SpecificColor}";
        }
        public float PercentOfErroredOpens()
        {
            float result = (NumberOfErroredOpens / NumberOfOpens);
            result = ((float)NumberOfErroredOpens / (float)NumberOfOpens);
            return result;
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
    class MyCustomOutOfRangeException : NullReferenceException
    {
        public string Cause { get; set; }
        public string ExcName { get; set; }
        public string Date { get; set; }
        public MyCustomOutOfRangeException(string name, string message)
        {
            Cause = message;
            ExcName = name;
            Date = DateTime.Now.ToLongTimeString();
        }
        public string MyExcCause()
        {
            return Cause;
        }
        public string MyExcName()
        {
            return ExcName;
        }
        public string MyExcDate()
        {
            return Date + " (кастомное исключение 1)";
        }
    }
    class MyGameUpdateException : InvalidCastException
    {
        public string Cause { get; set; }
        public string ExcName { get; set; }
        public string Date { get; set; }
        public MyGameUpdateException(string name, string message)
        {
            Cause = message;
            ExcName = name;
            Date = DateTime.Now.ToLongTimeString() + " (кастомное исключение 2)";
        }
        public void Info()
        {
            Console.WriteLine($"Error Name: {ExcName}\nReason: {Cause}\nTime: {Date}");
        }
    }
    class Laba
    {
        static void Main(string[] args)
        {
            Game myGameException = new Game();
            Game myGameException2 = new Game("Dota 2", "Valve", "MMORPG");
            Game myGameException3 = new Game("CK3", "Paradox", "Strategy");
            Virus myVirusException = new Virus();
            Computer.Programs.Add(myGameException);


            Console.WriteLine("\n   ####### Имитируем обработку кастомного исключения 1\n");
            try
            {
                Computer.DeleteByIndex(-1);//Вызовется кастомное исключение 1
            }
            catch (MyCustomOutOfRangeException ex)
            {
                Console.WriteLine($"Error Name: {ex.MyExcName()}");
                Console.WriteLine($"Reason: {ex.MyExcCause()}");
                Console.WriteLine($"Time: {ex.MyExcDate()}");
            }

            Console.WriteLine("\n   ####### Имитируем обработку кастомного исключения 2\n");
            try
            {
                Computer.UpdateGame(myVirusException);//Вызовется кастомное исключение 2
                //Computer.UpdateGame(myGameException);//Не вызовется кастомное исключение 2
            }
            catch (MyGameUpdateException ex)
            {
                ex.Info();
            }

            Console.WriteLine("\n   ####### Имитируем обработку исключения 1\n");
            try
            {
                Computer.Programs.Insert(-1, new Word());
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Error: {ex.Message}\nErrored parameter: {ex.ParamName}\nTarget Site: {ex.TargetSite}");
            }



            Console.WriteLine("\n   ####### Имитируем обработку исключения 2\n");
            try
            {
                Console.WriteLine("Сколько раз Word запускался с ошибкой?");
                int numOfErrors = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Сколько всего раз вы запускали Word?");
                int numOfOpens = Convert.ToInt32(Console.ReadLine());
                Word myWordDivideByZeroException = new Word(numOfOpens, numOfErrors);
                myWordDivideByZeroException.GetInfoAboutOpens();

                Console.WriteLine(myWordDivideByZeroException.PercentOfErroredOpens());//Вызовется если numOfOpens == 0
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: {ex.Message}\nTarget Site: {ex.TargetSite}");
            }
            catch(FormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}\nTarget Site: {ex.TargetSite}");
            }
            finally
            {
                Console.WriteLine("Блок Finally...");
            }

            Console.ReadKey();
        }
    }
}
