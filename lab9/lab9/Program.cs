using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    class Program
    {
        delegate void AppNotification(NotifyEventArgs e);
        delegate int MakeCalculations(int x, int y);
        delegate void Action<T>(T obj);
        delegate void Func<T>(T obj);
        delegate void Func<T, T2>(T obj, T2 obj2);
        delegate void Func<T, T2, T3, T4>(T obj, T2 obj2, T3 obj3, T4 obj4);
        class NotifyEventArgs
        {
            public string Who { get; set; }
            public string Message { get; set; }
            public NotifyEventArgs(object obj, string mes)
            {
                Who = Convert.ToString(obj.GetType().Name);
                Message = mes;
            }
        }
        static void Update(NotifyEventArgs e)
        {
            if (e.Who == "User")
            {
                Console.WriteLine($"{e.Who}, {e.Message}");
            }
            else if (e.Who == "Admin")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{e.Who}, {e.Message}");
                Console.ResetColor();
            }
        }
        static void Message(NotifyEventArgs e)//Обработчик события AppNotification
        {
            if(e.Who == "User")
            {
                Console.WriteLine(e.Message);
            }
            else if(e.Who == "Admin")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
        }
        static int Add(int a, int b)//Обработчики событий Calculations
        {
            return a + b;
        }
        static int Multiply(int a, int b)
        {
            return a * b;
        }
        static void ActionNotification(NotifyEventArgs e)
        {
            if (e.Who == "User")
            {
                Console.WriteLine($"{e.Who}: {e.Message}");
            }
            else if (e.Who == "Admin")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{e.Who}: {e.Message}");
                Console.ResetColor();
            }
        }
        


        static void DeleteDots(StringEditor str)
        {
            int length = str.String.Length;
            char[] s = str.String.ToCharArray();
            for (int i = 0; i < length; i++)
            {
                if (s[i] == '.')
                {
                    for (int j = i; j < length; j++)
                    {
                        if (j == length - 1)
                        {
                            break;
                        }
                        s[j] = s[j + 1];
                    }
                    length--;
                    i--;
                }
            }
            char[] newCharArray = new char[length];
            for (int i = 0; i < length; i++)
            {
                newCharArray[i] = s[i];
            }
            str.String = new string(newCharArray);
        }
        static void DeleteDots2(StringEditor str)
        {
            int length = str.String.Length;
            char[] s = str.String.ToCharArray();
            for (int i = 0; i < length; i++)
            {
                if (s[i] == '.')
                {
                    for (int j = i; j < length; j++)
                    {
                        if (j == length - 1)
                        {
                            break;
                        }
                        s[j] = s[j + 1];
                    }
                    length--;
                    i--;
                }
            }
            char[] newCharArray = new char[length];
            for (int i = 0; i < length; i++)
            {
                newCharArray[i] = s[i];
            }
            str.String = new string(newCharArray);
        }
        static void DeleteSpaces2(StringEditor str, Func<StringEditor> delDots)
        {
            delDots(str);
            int length = str.String.Length;
            char[] s = str.String.ToCharArray();
            for (int i = 0; i < length; i++)
            {
                if (s[i] == ' ')
                {
                    for (int j = i; j < length; j++)
                    {
                        if (j == length - 1)
                        {
                            break;
                        }
                        s[j] = s[j + 1];
                    }
                    length--;
                    i--;
                }
            }
            char[] newCharArray = new char[length];
            for (int i = 0; i < length; i++)
            {
                newCharArray[i] = s[i];
            }
            str.String = new string(newCharArray);
        }
        static void AddSymbols2(int pos, string str, StringEditor strObj, Func<StringEditor, Func<StringEditor>> delSpaces)
        {
            delSpaces(strObj, DeleteDots2);
            int len = strObj.String.Length;
            int strLen = str.Length;
            if (pos <= len && pos >= 0)
            {
                char[] charArr = strObj.String.ToCharArray();
                char[] addingCharArr = str.ToCharArray();
                char[] newCharArr = new char[len + strLen];
                int breakIndex = 0;
                for (int i = 0; i < pos; i++)
                {
                    newCharArr[i] = charArr[i];
                    breakIndex = i + 1;
                }
                int j = 0;
                for (int i = pos; i < pos + strLen; i++)
                {
                    newCharArr[i] = addingCharArr[j];
                    j++;
                }
                for (int i = pos + strLen; i < len + strLen; i++)
                {
                    newCharArr[i] = charArr[breakIndex];
                    breakIndex++;
                }
                strObj.String = new string(newCharArr);
            }
            else
            {
                Console.WriteLine("Неверная позиция");
            }
        }
        static void MakeUpperCase2(StringEditor str, Func< int, string, StringEditor, Func<StringEditor, Func<StringEditor>> > addSymbols)
        {
            addSymbols(2, "qwe", str, DeleteSpaces2);
            str.String = str.String.ToUpper();
        }
        static void CutString2(int start, int end, StringEditor str, Func<StringEditor, Func<int, string, StringEditor, Func<StringEditor, Func<StringEditor>>>> makeUpperCase)
        {
            makeUpperCase(str, AddSymbols2);
            str.String = str.String.Remove(start, end);
        }
        static void DeleteSpaces(StringEditor str)
        {
            int length = str.String.Length;
            char[] s = str.String.ToCharArray();
            for (int i = 0; i < length; i++)
            {
                if (s[i] == ' ')
                {
                    for (int j = i; j < length; j++)
                    {
                        if (j == length - 1)
                        {
                            break;
                        }
                        s[j] = s[j + 1];
                    }
                    length--;
                    i--;
                }
            }
            char[] newCharArray = new char[length];
            for (int i = 0; i < length; i++)
            {
                newCharArray[i] = s[i];
            }
            str.String = new string(newCharArray);
        }
        static void AddSymbols(int pos, string str, StringEditor strObj)
        {
            int len = strObj.String.Length;
            int strLen = str.Length;
            if (pos <= len && pos >= 0)
            {
                char[] charArr = strObj.String.ToCharArray();
                char[] addingCharArr = str.ToCharArray();
                char[] newCharArr = new char[len + strLen];
                int breakIndex = 0;
                for (int i = 0; i < pos; i++)
                {
                    newCharArr[i] = charArr[i];
                    breakIndex = i + 1;
                }
                int j = 0;
                for (int i = pos; i < pos + strLen; i++)
                {
                    newCharArr[i] = addingCharArr[j];
                    j++;
                }
                for (int i = pos + strLen; i < len + strLen; i++)
                {
                    newCharArr[i] = charArr[breakIndex];
                    breakIndex++;
                }
                strObj.String = new string(newCharArr);
            }
            else
            {
                Console.WriteLine("Неверная позиция");
            }
        }
        static void MakeUpperCase(StringEditor str)
        {
            str.String = str.String.ToUpper();
        }
        static void CutString(int start, int end, StringEditor str)
        {
            str.String = str.String.Remove(start, end);
        }

        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public Person()
            {

            }
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
        }
        class User : Person
        {
            public event AppNotification Interacted;
            public event MakeCalculations OnComputing;
            public string OS { get; set; }
            public bool isAppLaunched { get; set; }

            public User() : base()
            {
                isAppLaunched = false;
            }
            public User(string os) 
            {
                OS = os;
            }
            public User(string name, int age, string os) : base(name, age)
            {
                OS = os;
            }
            public void LaunchApp()
            {
                isAppLaunched = true;
                Interacted?.Invoke(new NotifyEventArgs(this, "Программа запущена."));
            }
            public void CloseApp()
            {
                isAppLaunched = false;
                Interacted?.Invoke(new NotifyEventArgs(this, "Программа закрыта."));
            }
            public void CheckState()
            {
                Interacted?.Invoke(new NotifyEventArgs(this, $"Программа работает? {isAppLaunched}"));
            }
            public void Calculation(int a, int b)
            {
                int? result;
                if (this.isAppLaunched)
                {
                    result = OnComputing?.Invoke(a, b);
                }
                else
                {
                    result = null;
                }
                Console.WriteLine((result != null) ? Convert.ToString(result) : "null");
            }
            public void Replace(int delta)
            {
                Interacted?.Invoke(new NotifyEventArgs(this, $"Произведено перемещение на {delta} единиц."));
            }
            public void Compress(int ratio)
            {
                Interacted?.Invoke(new NotifyEventArgs(this, $"Произведено сжатие с коэффициентом {ratio}."));
            }
        }
        class Admin : User
        {
            public Admin()
            {

            }
            public Admin(string name, int age, string os) : base (name, age, os)
            {

            }
        }
        class StringEditor
        {
            public string String { get; set; }
            public StringEditor(string str)
            {
                String = str;
            }
            public void GetString()
            {
                Console.WriteLine(String);
            }
        }
        static void Main(string[] args)
        {
            {
                User user1 = new User("Tom", 23, "MacOS");
                user1.Interacted += Message;
                user1.LaunchApp();
                user1.CheckState();
                user1.CloseApp();
                user1.CheckState();
                user1.LaunchApp();
                user1.OnComputing += Add;//Works only if App is launched
                user1.Calculation(7, 7);
                user1.OnComputing += Multiply;
                user1.Calculation(7, 7);

                Console.WriteLine("//////  Разное поведение у разных объектов  /////");

                Admin admin1 = new Admin("Pete", 26, "Windows");
                admin1.Interacted += Message;
                admin1.LaunchApp();
                admin1.CheckState();
                Console.WriteLine();

                User user2 = new User();
                user2.Interacted += Update;
                user2.CheckState();
                user2.CloseApp();
                Console.WriteLine();

                Admin admin2 = new Admin();
                admin2.Interacted += Update;
                admin2.LaunchApp();
                admin2.CheckState();

                Console.WriteLine("////////  Тест задания 1  /////////");
                user2.Interacted += ActionNotification;
                user2.Interacted -= Update;//Снимаем обработчик Update с события Interacted
                user2.Replace(25);

                admin1.Interacted -= Message;//Снимаем обработчик Message с события Interacted
                admin1.Interacted += ActionNotification;
                admin1.Compress(3);


                Console.WriteLine("\n////////  Тест задания 2  /////////\n");

                StringEditor str1 = new StringEditor("Какая-то... прелестная. строка.");
                str1.GetString();
                DeleteDots(str1);
                str1.GetString();
                AddSymbols(0, "qwe", str1);
                str1.GetString();
                AddSymbols(3, "zxc", str1);
                str1.GetString();
                AddSymbols(15, "abc", str1);
                str1.GetString();
                AddSymbols(34, "poi", str1);
                str1.GetString();
                AddSymbols(45, "asd", str1);
                str1.GetString();
                CutString(3, 3, str1);
                str1.GetString();
                MakeUpperCase(str1);
                str1.GetString();
                DeleteSpaces(str1);
                str1.GetString();

                Console.WriteLine("\n////////  Настоящий тест задания 2  /////////\n");

                StringEditor str2 = new StringEditor("П р и в е т . . . м и р");
                Action<StringEditor> strOperations = DeleteDots;
                strOperations(str2);
                strOperations = DeleteSpaces;
                strOperations(str2);
                str2.GetString();
            }

            Console.WriteLine("\n##################\n");
            StringEditor str3 = new StringEditor("My. -.name. -.is.- Nikita.");
            Func<StringEditor> deleteDots = DeleteDots2;
            Func<StringEditor, Func<StringEditor>> deleteSpaces = DeleteSpaces2;
            Func<int, string, StringEditor, Func<StringEditor, Func<StringEditor>>> addSymbols = AddSymbols2;
            Func<StringEditor, Func <int, string, StringEditor, Func<StringEditor, Func<StringEditor> >> > makeUpperCase = MakeUpperCase2;
            Func<int, int, StringEditor, Func<StringEditor, Func<int, string, StringEditor, Func<StringEditor, Func<StringEditor>>>>> cutString = CutString2;
            cutString(4, 7, str3, makeUpperCase);

            str3.GetString();


            Console.Read();
        }
    }
}
