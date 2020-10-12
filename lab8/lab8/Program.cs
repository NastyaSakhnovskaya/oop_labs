using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace lab4
{
    abstract class Program
    {
        public string Name { get; set; }
        public Program()
        {
            Name = "undefined";
        }
        public Program(string name)
        {
            Name = name;
        }
        public virtual void Info()
        {
            Console.WriteLine($"Name: {Name} ");
        }
    }
    class Game : Program
    {
        public string Genre { set; get; }
        public string Version { get; set; }
        public Game()
        {
            Genre = "undefined genre";
            Version = "0";
        }
        public Game(string name, string genre, string version) : base(name)
        {
            Genre = genre;
            Version = version;
        }
        public override void Info()
        {
            base.Info();
            Console.WriteLine($"Genre: {Genre}");
            Console.WriteLine($"Version: {Version}");
        }
    }
    interface IGeneral<T>
    {
        void Add(T element);
        void Delete(T element);
        void Check();
    }
    public class GenericList<T> : IGeneral<T> //where T : class
    {
        static Random rand = new Random();
        public List<T> List;
        public static int numOfInstances = 0;
        public GenericList()
        {
            List = new List<T>(5);
            numOfInstances++;
        }
        public GenericList(int a)
        {
            List = new List<T>(a);
            numOfInstances++;
        }
        public void Add(T el)
        {
            List.Add(el);
        }
        public void Delete(T el)
        {
            if (List.Contains(el))
            {
                List.Remove(el);
            }
            else
            {
                throw new ValueException("Такого элемента не существует.");
            }
        }
        public void Check()
        {
            for (int i = 0; i < List.Count; i++)
            {
                //FieldInfo[] myField = this.List.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
                //for (int j = 0; j < myField.Length; j++)
                //{
                //    // Determine whether or not each field is a special name.
                //    //if (myField[j].IsSpecialName)
                //    //{
                //    Console.WriteLine(myField[j].GetValue(this.List.ElementAt(0)));
                //    //}
                //}
                Console.Write(" " + List.ElementAt(i) + " |");
            }
            Console.WriteLine();
        }
        public void Write(string fileName)
        {
            StreamWriter Writer = new StreamWriter("../../../" + fileName + ".txt");
            foreach (T element in List)
            {
                Writer.WriteLine(element);
            }
            Writer.Close();
        }
    }
    class ValueException : Exception
    {
        public string MyMessage { get; set; }
        public ValueException(string message)
        {
            MyMessage = message;
        }
    }
    class Lab
    {
        static void Read(string fileName)
        {
            StreamReader Reader = new StreamReader("../../../" + fileName + ".txt");
            Console.WriteLine(Reader.ReadToEnd());
            Reader.Close();
        }
        static void Main(string[] args)
        {
            
            GenericList<int> List1 = new GenericList<int>(5);
            for (int i = 1; i <= 10; i += 2)
            {
                List1.Add(i);
            }

            GenericList<string> List2 = new GenericList<string>(3);
            List2.Add("abc");
            List2.Add("qw");
            List2.Add("er");
            List2.Add("ty");
            List2.Add("zxc");

            GenericList<Game> List3 = new GenericList<Game>(3);
            Game g;
            g = new Game("Game_1", "Strategy", "1.0.3");
            List3.Add(g);
            g = new Game("Game_Number_Two", "MMORPG", "2.1");
            List3.Add(g);
            g = new Game("Game-3", "Shooter", "3.3.3");
            List3.Add(g);

            List1.Write("file1");
            try
            {
                List1.Delete(5);
                Console.WriteLine("End of Try Section");
            }
            catch (ValueException ex)
            {
                Console.WriteLine(ex.MyMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                List1.Check();
            }

            try
            {
                List2.Write("file2");
                List2.Delete("abcd");
                Console.WriteLine("End of Try Section");
            }
            catch (ValueException ex)
            {
                Console.WriteLine(ex.MyMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            List2.Check();

            List3.Check();

            Read("file1");
            Read("file2");


            Console.Read();
        }
    }
}
