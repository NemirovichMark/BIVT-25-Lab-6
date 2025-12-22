using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Lab6
{
    public class Program
    {   
        static int[,] GenMatrix(int n, int m = 0,
            int min_val = -5, int max_val = 17)
        {
            if (m == 0)
            {
                m = n;
            }
            int[,] a = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a[i,j] = new Random().Next(min_val, max_val);
                }
            }

            return a;
        }
        static double[] GenDoubleArray(int n = 7,
            int min_val = -5, int max_val = 17)
        {
            var a = new double[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = min_val + new Random().NextDouble() * max_val;
            }
            return a;
        }
        static int[][] GenJagged(int n, int m = 0,
    int min_val = -5, int max_val = 17)
        {
            if (m == 0)
            {
                m = n;
            }
            int[][] a = new int[n][];
            for (int i = 0; i < n; i++)
            {
                int len = new Random().Next(1, m + 1);
                a[i] = new int[len];
                for (int j = 0; j < len; j++)
                {
                    a[i][j] = new Random().Next(min_val, max_val);
                }
            }

            return a;
        }
        static int[] GenIntArray(int n = 7,
            int min_val = -5, int max_val = 17)
        {
            var a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = new Random().Next(min_val, max_val);
            }
            return a;
        }
        static void Print(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write($"{a[i,j], 5}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void Print(double[] a)
        {
            for (int i = 0;i < a.Length; i++)
            {
                Console.Write($"{Math.Round(a[i], 3), 7}");
            }
            Console.WriteLine("\n");
        }
        static void Print(int[][] a)
        {
            foreach (int[] q in a)
            {
                if (q != null)
                {
                    foreach (var elem in q)
                    {
                        Console.Write($"{elem, 5}");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void Print(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write($"{a[i], 5}");
            }
            Console.WriteLine("\n");
        }
        public static void Main()
        {
            White white = new White();
            Console.WriteLine("White\n");

            Console.WriteLine("Task 1\n");
            var a = GenDoubleArray();
            var b = GenDoubleArray(9);
            Print(a); Print(b);
            white.Task1(a, b);
            Print(a); Print(b);

            Console.WriteLine("Task 2\n");
            var c = GenMatrix(5);
            var d = GenMatrix(3, 5);
            Print(c); Print(d);
            white.Task2(c, d);
            Print(c); Print(d);

            Console.WriteLine("Task 3\n");
            var e = GenMatrix(7, 6, -10);
            Print(e);
            int ans3 = white.Task3(e);
            Console.WriteLine($"{ans3}\n");

            Console.WriteLine("Task 4\n");
            c = GenMatrix(4, 2, 0, 10);
            d = GenMatrix(3);
            Print(c); Print(d);
            white.Task4(c, d);
            Print(c); Print(d);

            Console.WriteLine("Task 5\n");
            c = GenMatrix(4, 6);
            d = GenMatrix(4);
            Print(c); Print(d);
            white.Task5(c, d);
            Print(c); Print(d);

            Console.WriteLine("Task 6A\n");
            c = GenMatrix(7);
            Print(c);
            white.Task6(c, white.SortDiagonalAscending);
            Print(c);

            Console.WriteLine("Task 6B\n");
            c = GenMatrix(5);
            Print(c);
            white.Task6(c, white.SortDiagonalDescending);
            Print(c);

            Console.WriteLine("Task 7\n");
            int n7 = 8, k7 = 3;
            var ans7 = white.Task7(n7, k7);
            Console.WriteLine($"C n = {n7} k = {k7}:  ans7 = {ans7}\n");

            Console.WriteLine("Task 10\n");
            var t = GenJagged(5, 8, -20, 50);
            Print(t);
            var ans10_1 = white.Task10(t, white.CountPositive);
            Console.WriteLine($"cnt_pos: {ans10_1}");
            var ans10_2 = white.Task10(t, white.FindMax);
            Console.WriteLine($"max_elem: {ans10_2}");
            var ans10_3 = white.Task10(t, white.FindMaxRowLength);
            Console.WriteLine($"max_row_length: {ans10_3}\n");

            Purple purple = new Purple();
            Console.WriteLine("Purple\n");

            Console.WriteLine("Task 1\n");
            var a1 = GenMatrix(5);
            var b1 = GenMatrix(5);
            Print(a1); Print(b1);
            purple.Task1(a1, b1);
            Print(a1); Print(b1);

            Console.WriteLine("Task 2\n");
            a1 = GenMatrix(4, 5);
            b1 = GenMatrix(5, 3);
            Print(a1); Print(b1);
            purple.Task2(ref a1, b1);
            Print(a1);

            Console.WriteLine("Task 4\n");
            a1 = GenMatrix(4, 5);
            b1 = GenMatrix(6, 5);
            Print(a1); Print(b1);
            purple.Task4(a1, b1);
            Print(a1); Print(b1);

            Console.WriteLine("Task 6A\n");
            a1 = GenMatrix(8, 5);
            Print(a1);
            purple.Task6(a1, purple.SortRowsByMaxAscending);
            Print(a1);

            Console.WriteLine("Task 6B\n");
            a1 = GenMatrix(5, 3);
            Print(a1);
            purple.Task6(a1, purple.SortRowsByMaxDescending);
            Print(a1);

        }
    }
}
