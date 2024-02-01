using System;

namespace Task3_2
{
    abstract class ArrayBase
    {
        protected bool user;//способ ввода
        protected int n;//длина массива

        public ArrayBase(bool user, int n)
        {
            this.user = user;
            this.n = n;
        }


        public abstract int[] UserCreate();
        public abstract int[] RndCreate();


        public abstract decimal Average();

        public abstract void Print();
    }


    sealed class OneDimArray : ArrayBase
    {
        int[] array;

        public OneDimArray(bool user, int n) : base(user, n)
        {
            if (user == true)
            {
                array = UserCreate();
            }
            else
            {
                array = RndCreate();
            }
        }

        public override int[] UserCreate()
        {
            int[] l = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите элемент {i + 1}");
                int d = int.Parse(Console.ReadLine());
                l.SetValue(d, i);
            }
            return l;
        }
        public override int[] RndCreate()
        {
            Random rnd = new Random();
            int[] mas = new int[n];
            for (int i = 0; i < n; i++)
            {
                int r = rnd.Next(1, 200);
                mas.SetValue(r, i);
            }
            return mas;
        }

        public void DeleteAbs()
        {
            int n = array.Length;
            int[] d = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (Math.Abs(array[i]) <= 100)
                {
                    d.SetValue(array[i], i);

                }
            }

            array = d;
        }

        public void DeleteSame()
        {
            int n = array.Length;
            int[] res = new int[n];
            int k = 0;
            bool f;
            foreach (int i in array)
            {
                f = true;
                for (int j = 0; j < k; j++)
                {
                    if (i == res[j])
                    {
                        f = false;
                    }
                }
                if (f)
                {
                    res[k] = i;
                    k += 1;
                }
            }
            array = res;
        }
        public override decimal Average()
        {
            int[] l = array;
            decimal summ = 0;
            decimal sred = 0;
            for (int i = 0; i < l.Length; i++)
            {
                summ += array[i];
                int len = l.Length;
                sred = summ / len;
            }

            return sred;
        }

        public override void Print()
        {
            Console.WriteLine("Одномерный массив: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
        }
    }

    sealed class TwoDimArray : ArrayBase
    {
        int[,] array;


    }
        


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Напишите true если хотите ввод с клавиатуры, если хотите с помощью рандома, напишите false");
            bool user = bool.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество элементов в одномерной массиве");
            int n = int.Parse(Console.ReadLine());
            OneDimArray array = new OneDimArray(user, n);
            decimal s = array.Average();
            Console.WriteLine($"Среднее кол-во элементов в массиве: {s}");
            array.Average();

            Console.WriteLine("Без повторов:");
            array.DeleteSame();
            array.Print();

            Console.WriteLine("Массив без чисел больше 100:");
            array.DeleteAbs();
            array.Print();
        }
    }
}


