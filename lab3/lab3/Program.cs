using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    partial class SquareMatrix
    {
        static Random rnd = new Random();
        private int[,] arr;
        private int arrSize;
        public int _arrSize
        {
            get
            {
                return arrSize;
            }
            set
            {
                arrSize = value;
            }
        }
        public void Print()
        {
            for (int i = 0; i < _arrSize; i++)
            {
                for (int j = 0; j < _arrSize; j++)
                {
                    Console.Write(arr[i, j] + " "); ;
                }
                Console.WriteLine();
            }
        }
    }
    partial class SquareMatrix
    {
        public SquareMatrix(int a)
        {
            arr = new int[a, a];
            _arrSize = a;
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    arr[i, j] = rnd.Next(100);
                }
            }
        }
    } 
    class Vector
    {

        private int[] arr;//массив
        public int this[int j]//индексатор
        {
            get
            {
                return arr[j];
            }
            set
            {
                arr[j] = value;
            }
        }
        private int arrSize;
        public int _arrSize
        {
            get
            {
                return arrSize;
            }
        }
        private int errorCode = 0;
        public int _errorCode
        {
            get
            {
                return errorCode;
            }
            set
            {
                errorCode = value;
            }
        }
        public readonly int ID;
        public static int numOfInstances = 0;
        static Random rnd = new Random();
        static Vector()
        {
            Console.WriteLine("Вызвался статический конструктор!");
        }
        public Vector()
        {
            arr = new int[7];
            arrSize = 7;
            for (int i = 0; i < 7; i++)
            {
                arr[i] = 7;
            }
            ID = this.GetHashCode();
            numOfInstances++;
        }
        public Vector(int a)
        {
            arr = new int[a];
            arrSize = a;
            ID = this.GetHashCode();
            numOfInstances++;
        }
        public Vector(int a, int b)
        {
            arr = new int[a];
            arrSize = a;
            arr[0] = b;
            ID = this.GetHashCode();
            numOfInstances++;
        }
        public Vector(int a, int b, bool fill)
        {
            arr = new int[a];
            arrSize = a;
            arr[0] = b;
            if(fill)
            {
                for (int i = 1; i < a; i++)
                {
                    arr[i] = b+i;
                }
            }
            else
            {
                for (int i = 0; i < a; i++)
                {
                    arr[i] = -1;
                }
            }
            ID = this.GetHashCode();
            numOfInstances++;
        }
        public static void GetInfoAboutClass()
        {
            Console.WriteLine("Name: Vector");
            Console.Write("Num of Instances: ");
            Console.WriteLine(Vector.numOfInstances);
            Console.WriteLine("Lab number: 3");
        }
        public void Sum(int a)
        {
            for (int i = 0; i < arrSize; i++)
            {
                arr[i] += a;
            }
        }
        public void Multiply(int a)
        {
            for (int i = 0; i < arrSize; i++)
            {
                arr[i] *= a;
            }
        }
        public void MultiplyX2(ref int a)
        {
            a *= 2;
            for (int i = 0; i < arrSize; i++)
            {
                arr[i] *= a;
            }
        }
        public void SumUndef(out int a)
        {
            a = rnd.Next(20);
            for (int i = 0; i < arrSize; i++)
            {
                arr[i] += a;
            }
        }
        public void Fill()
        {
            for (int i = 0; i < arrSize; i++)
            {
                arr[i] = rnd.Next(100);
            }
        }
        public void Print()
        {
            Console.Write("[ ");
            for (int i = 0; i < arrSize; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("]");
        }
        public bool hasNull()
        {
            for (int i = 0; i < arrSize; i++)
            {
                if (arr[i] == 0)
                {
                    return true;
                }
            }
            return false;
        }
        public double countModule()
        {
            double module = 0;
            for (int i = 0; i < arrSize; i++)
            {
                module += Math.Pow(arr[i], 2);
            }
            return Math.Sqrt(module);
        }
        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return false;
            }
            if(obj.GetType() != this.GetType())
            {
                return false;
            }
            int counter = 0;
            Vector v = (Vector)obj;
            if(v._arrSize != _arrSize)
            {
                return false;
            }
            for (int i = 0; i < _arrSize; i++)
            {
                for (int j = 0; j < v._arrSize; j++)
                {
                    if (arr[i] == v.arr[j])
                    {
                        counter++;
                        continue;
                    }
                }
            }
            return (float)counter >= (float)_arrSize/2 ? true : false;
        }
        public override int GetHashCode()
        {
            int hashCode = (int)countModule();
            return hashCode;
        }
        public override string ToString()
        {
            string toStr = $"Type: {base.ToString()}\nSize: {_arrSize}\nID: {ID}\nHashCode: {GetHashCode()}";
            return toStr;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            Console.Write("Введите размер вектора 1: ");
            int vLen = Convert.ToInt32(Console.ReadLine());
            if (vLen < 1)
            {
                Vector v1 = new Vector(0);
                v1._errorCode = 1;
                Console.WriteLine("Error! Code: " + v1._errorCode);
            }
            else
            {
                Vector v1 = new Vector(vLen);
                v1.Fill();
                Console.Write("Введите число 1: ");
                number = Convert.ToInt32(Console.ReadLine());
                v1.Print();
                v1.Sum(number);
                v1.Print();
            }
            Console.Write("Введите размер вектора 2: ");
            vLen = Convert.ToInt32(Console.ReadLine());
            Vector v2 = new Vector(vLen);
            v2.Fill();
            Console.Write("Введите число 2: ");
            number = Convert.ToInt32(Console.ReadLine());
            v2.Print();
            v2.Multiply(number);
            v2.Print();

            Console.WriteLine("------------------");
            //Console.ReadKey();

            Vector v4 = new Vector();
            v4.Print();

            Vector v3 = new Vector(4, 6);
            v3.Print();

            Vector v5 = new Vector(7, 5, true);
            v5.Print();

            Vector v6 = new Vector(7, 5, false);
            v6.Print();

            Console.WriteLine("------------------");

            Vector refVectorTest = new Vector(6, 3, true);
            int refX = 10;
            Console.WriteLine(refX);
            refVectorTest.MultiplyX2(ref refX);
            refVectorTest.Print();
            Console.WriteLine(refX);

            Vector outVectorTest = new Vector(3, 4, true);
            int outX;
            //Console.WriteLine(outX); <= error
            outVectorTest.SumUndef(out outX);
            outVectorTest.Print();
            Console.WriteLine(outX);

            Console.WriteLine("------------------");

            int vArrLen = 5;
            Vector[] vArr = new Vector[vArrLen];
            for (int i = 0; i < vArrLen; i++)
            {
                vArr[i] = new Vector(5);
                vArr[i].Fill();
                vArr[i].Print();
            }
            bool hasNull = true;
            for (int i = 0; i < vArrLen; i++)
            {
                if (vArr[i].hasNull())
                {
                    if (hasNull)
                    {
                        Console.WriteLine("a) Список векторов, содержащих нули:");
                        hasNull = !hasNull;
                    }
                    vArr[i].Print();
                }
            }
            if (hasNull)
            {
                Console.WriteLine("a) Нет векторов, содержащих 0.");
            }

            int minIndex = 0;
            for (int i = 1; i < vArrLen; i++)
            {
                if(vArr[i].countModule() < vArr[minIndex].countModule())
                {
                    minIndex = i;
                }
            }
            Console.WriteLine("Вектор с наименьшим модулем:");
            vArr[minIndex].Print();
            Console.Write("Модуль: ");
            Console.WriteLine(vArr[minIndex].countModule());

            Console.WriteLine("------------------");

            Console.WriteLine(Vector.numOfInstances);
            Vector.GetInfoAboutClass();

            Console.WriteLine("------------------");

            Console.WriteLine(v4._arrSize);

            Console.WriteLine("------------------");

            SquareMatrix SqMatrix1 = new SquareMatrix(4);
            SqMatrix1.Print();

            Console.WriteLine("------------------");

            Vector eqV1 = new Vector(5, 3, true);
            Vector eqV2 = new Vector(5, 6, true);
            Vector eqV3 = new Vector(5, 3, true);
            eqV1.Print();
            eqV2.Print();
            Console.WriteLine(eqV1.Equals(eqV2));
            Console.WriteLine(eqV1.Equals(eqV1));
            Console.WriteLine("Xеш коды:");
            Console.WriteLine(eqV1.GetHashCode());
            Console.WriteLine(eqV2.GetHashCode());
            Console.WriteLine(eqV3.GetHashCode());
            Vector eqV4 = new Vector(6, -4, true);
            Vector eqV5 = new Vector(3, -4, false);
            Console.WriteLine("К строке:");
            Console.WriteLine(eqV4.ToString());
            Console.WriteLine(eqV5.ToString());

            Console.WriteLine("------------------");

            var nonameType = new
            {
                Name = "Nick",
                Occupy = "Student",
                Age = 18,
            };
            Console.WriteLine(nonameType.GetType());
            Console.WriteLine(nonameType.Name);
            Console.WriteLine(nonameType.Occupy);
            Console.WriteLine(nonameType.Age);
        }
    }
}
