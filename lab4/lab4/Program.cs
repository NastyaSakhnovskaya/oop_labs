using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class Mas
    {
        static Random rand = new Random();
        public int[] arr;
        public int ArrSize { get; set; }
        public static int numOfInstances = 0;
        public Mas()
        {
            arr = new int[5];
            ArrSize = 5;
            numOfInstances++;
        }
        public Mas(int a)
        {
            arr = new int[a];
            ArrSize = a;
            numOfInstances++;
        }
        public Mas(int a, bool hasFill)
        {
            arr = new int[a];
            ArrSize = a;
            if(hasFill)
            {
                Fill();
            }
            numOfInstances++;
        }
        public void Fill()
        {
            for (int i = 0; i < ArrSize; i++)
            {
                arr[i] = rand.Next(-15, 15);
            }
        }
        public void Print()
        {
            Console.Write("[");
            for (int i = 0; i < ArrSize; i++)
            {
                Console.Write("{0,4}", arr[i]);
            }
            Console.WriteLine("]");
        }
        public double CountAbs()
        {
            double abs = 0;
            for (int i = 0; i < ArrSize; i++)
            {
                abs += Math.Pow(arr[i], 2);
            }
            return Math.Round(Math.Sqrt(abs), 2);
        }
        public bool CompareDim(Mas m)
        {
            if (ArrSize == m.ArrSize)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Mas operator +(Mas m1, Mas m2)
        {
            Mas resMas = new Mas(m1.ArrSize);
            for (int i = 0; i < m1.ArrSize; i++)
            {
                resMas.arr[i] = m1.arr[i] + m2.arr[i];
            }
            return resMas;
        }
        public static Mas operator -(Mas m1, Mas m2)
        {
            Mas resMas = new Mas(m1.ArrSize);
            for (int i = 0; i < m1.ArrSize; i++)
            {
                resMas.arr[i] = m1.arr[i] - m2.arr[i];
            }
            return resMas;
        }
        public static bool operator >(Mas m1, Mas m2)
        {
            if(m1.CountAbs() > m2.CountAbs())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator <(Mas m1, Mas m2)
        {
            if (m1.CountAbs() < m2.CountAbs())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Mas operator ++(Mas m)
        {
            Mas m2 = m;
            for (int i = 0; i < m.ArrSize; i++)
            {
                m2.arr[i] += 10;
            }
            return m2;
        }
        public static double operator *(Mas m1, Mas m2)
        {
            double multiplyRes = 0;
            for (int i = 0; i < m1.ArrSize; i++)
            {
                multiplyRes += m1.arr[i] * m2.arr[i];
            }
            return multiplyRes;
        }
        public static bool operator true(Mas m)
        {
            for (int i = 0; i < m.ArrSize; i++)
            {
                if (m.arr[i] < 0)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool operator false(Mas m)
        {
            for (int i = 0; i < m.ArrSize; i++)
            {
                if (m.arr[i] < 0)
                {
                    return false;
                }
            }
            return true;
        }
        public static explicit operator int(Mas m)
        {
            return (int)Math.Round(m.CountAbs());
        }
        public static bool operator ==(Mas m1, Mas m2)
        {
            if (m1.CountAbs() == m2.CountAbs()) return true;
            return false;
        }
        public static bool operator !=(Mas m1, Mas m2)
        {
            if (m1.CountAbs() != m2.CountAbs()) return true;
            return false;
        }
        public class Date
        {
            public Mas parent;
            public string DateStr { set; get; }
            public Date()
            {
                DateStr = Convert.ToString(DateTime.Now);
            }
            public Date(Mas parentClass)
            {
                parent = parentClass;
                DateStr = Convert.ToString(DateTime.Now);
            }
        }

        public class Owner
        {
            public Owner()
            {
                ID = 123123;
                Name = "Nikita Kubarko";
                Organization = "BSTU";
            }
            public static int ID { get; set; }
            public static string Name { get; set; }
            public static string Organization { get; set; }
        }
    }
    static class StatisticOperation
    {
        public static Mas Sum(Mas m1, Mas m2)
        {
            Mas resMas = new Mas(m1.ArrSize);
            for (int i = 0; i < m1.ArrSize; i++)
            {
                resMas.arr[i] = m1.arr[i] + m2.arr[i];
            }
            return resMas;
        }
        public static int Difference(Mas m)
        {
            int dif;
            int min = m.arr[0];
            int max = m.arr[0];
            for (int i = 1; i < m.ArrSize; i++)
            {
                if (min > m.arr[i]) min = m.arr[i];
                if (max < m.arr[i]) max = m.arr[i];
            }
            return dif = max - min;
        }
        public static int getNumOfInstances()
        {
            return Mas.numOfInstances;
        }
        public static int howSymbols(this string str, char symbol)
        {
            int n = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if(str[i] == symbol) n++;
            }
            return n;
        }
        public static Mas DeleteNegative(this Mas m)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < m.ArrSize; i++)
            {
                if (m.arr[i] >= 0)
                {
                    list.Add(m.arr[i]);
                }
            }
            int count = list.Count;
            Mas newMas = new Mas(count);
            newMas.arr = list.ToArray<int>();
            return newMas;
        }
        //public static Mas DeleteNegative(this Mas m)
        //{
        //    Mas newMas;
        //    int n = 0;
        //    for (int i = 0; i < m.ArrSize; i++)
        //    {
        //        if (m.arr[i] >= 0) n++;
        //    }
        //    newMas = new Mas(n);
        //    int counter = 0;
        //    for (int i = 0; i < m.ArrSize; i++)
        //    {
        //        if(m.arr[i] >= 0)
        //        {
        //            newMas.arr[counter] = m.arr[i];
        //            counter++;
        //        }
        //    }
        //    return newMas;
        //}
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Тест массива *****");
            Mas m1 = new Mas();
            m1.Print();
            m1.Fill();
            m1.Print();
                
            Console.WriteLine("***** Тест перегрузки операций *****");
            Console.WriteLine("Сумма/разность");
            Mas m2 = new Mas(5, true);
            Mas m3 = new Mas(6, true);
            m2.Print();
            m3.Print();
            if (m2.CompareDim(m3))
            {
                (m2 + m3).Print();
            }
            else
            {
                Console.WriteLine("Ошибка операции. Размеры массивов различны.");
            }

            Mas m4 = new Mas(5, true);
            Mas m5 = new Mas(5, true);
            m4.Print();
            m5.Print();
            if (m4.CompareDim(m4))
            {
                (m4 - m5).Print();
            }
            else
            {
                Console.WriteLine("Ошибка операции. Размеры массивов различны.");
            }
            Console.WriteLine("Умножение массивов");
            Mas m9 = new Mas(5, true);
            Mas m10 = new Mas(5, true);
            m9.Print();
            m10.Print();
            if (m9.CompareDim(m10))
            {
                Console.WriteLine(m9 * m10);
            }
            else
            {
                Console.WriteLine("Ошибка операции. Размеры массивов различны.");
            }
            Console.WriteLine("Сравнение");
            Mas m6 = new Mas(3, true);
            Mas m7 = new Mas(3, true);
            m6.Print();
            m7.Print();
            Console.WriteLine(m6.CountAbs());
            Console.WriteLine(m7.CountAbs());
            Console.WriteLine(m6 > m7);
            Console.WriteLine(m6 < m7);
            Console.WriteLine("Инкремент");
            Mas m8 = new Mas(5, true);
            m8.Print();
            m8++.Print();
            Console.WriteLine("Условные");
            Mas m11 = new Mas(5, true);
            m11.Print();
            if(m11)
            {
                Console.WriteLine("Истина");
            }
            else
            {
                Console.WriteLine("Ложь");
            }
            Console.WriteLine("Преобразование типа");
            Mas m12 = new Mas(4, true);
            m12.Print();
            Console.WriteLine(m12.CountAbs());
            Console.WriteLine((int)m12);
            Console.WriteLine("Сравнение массивов");
            Mas m13 = new Mas(3, false);
            Mas m14 = new Mas(3, false);
            m13.Print();
            Console.WriteLine(m13.CountAbs());
            m14.Print();
            Console.WriteLine(m14.CountAbs());
            if(m13 == m14)
            {
                Console.WriteLine("Массивы равны");
            }
            else
            {
                Console.WriteLine("Массивы не равны");
            }
            Console.WriteLine("***** Тест вложенного класса *****");

            Mas m15 = new Mas(5, true);
            Mas.Date date = new Mas.Date(m15);//передаем объект вмещающего класса, чтобы иметь доступ к родительскому классу
            Console.WriteLine("Дата создания объекта класса Date: " + date.DateStr);
            Console.WriteLine("Вмещающий класс класса Date: " + date.parent);

            Console.WriteLine("***** Статический класс *****");

            Mas m16 = new Mas(5, true);
            Mas m17 = new Mas(5, true);
            m16.Print();
            m17.Print();
            Mas m18 = StatisticOperation.Sum(m16, m17);
            m18.Print();
            Console.WriteLine(StatisticOperation.Difference(m18));
            Console.WriteLine("Число элементов класса: " + StatisticOperation.getNumOfInstances());

            Console.WriteLine("***** Вложенный объект *****");

            Mas.Owner IOwner = new Mas.Owner();
            Console.WriteLine(Mas.Owner.ID);
            Console.WriteLine(Mas.Owner.Name);
            Console.WriteLine(Mas.Owner.Organization);

            Console.WriteLine("***** Методы расширения *****");

            Console.Write("Введите строку: ");
            string extensionStr = Console.ReadLine();
            Console.Write("Введите символ: ");
            char ch = (char)Console.Read();
            Console.WriteLine("Количество символов " + ch + " равно " + extensionStr.howSymbols(ch));

            Mas m19 = new Mas(10, true);
            m19.Print();
            StatisticOperation.DeleteNegative(m19).Print();
        }
    }
}
