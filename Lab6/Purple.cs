using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public class Purple
    {
        /*[Текст песни «Гимн Дахака»]

        [Припев]
        Я бы хотел, чтобы меня называли все талант
        Но, уже есть один талант под псевдонимом Травоман

        [Куплет]
        Я в замесе жму скиллы, как пулемёт
        Снова fight руинит Dendi долбоёб
        Почему с него слетел опять эвойд?
        Почему Лехенда, блядь, опять со мной?
        Я Lone Druid, на тебя нажал rightclick, и ты убит
        У врагов тильт по-по-посгорали пердаки
        Я ломаю mid не задефаться никак
        Мне тиммейты говорят: «Спасибо за Daxak»

        [Бридж]
        Меч-мерек-мемек-шмек-шмек
        Меч-мерек-мекс-векс-чмермек
        И мекс-мекс-чмермек
        И меке-шмек-мек-мек-шмермек
        Та-чипи-меч-шмерме
        Не понял?

        [Припев]
        Я бы хотел, что бы меня называли все талант
        Но, уже есть один талант под псевдонимом Травоман
        See upcoming rap shows
        Get tickets for your favorite artists
        You might also like
        ТИЛЬТ (TILT)
        СЕРЕГА ПИРАТ (SEREGA PIRAT)
        Мой байк (My Bike)
        СЕРЕГА ПИРАТ (SEREGA PIRAT)
        тп на аме (tp on am)
        СЕРЕГА ПИРАТ (SEREGA PIRAT)
        [Аутро]
        Называли все талант
        Называли все талант
        Называли все талант
        Называли все талант*/

        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int v = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > matrix[v, v])
                {
                    v = i;
                }
            }
            return v;
        }
        public void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                (matrix[rowIndex, i], B[i, columnIndex]) = (B[i, columnIndex], matrix[rowIndex, i]);
            }
        }
        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B)
        {
            int[,] matrix = new int[A.GetLength(0), A.GetLength(1)];
            matrix = A;
            A = new int[A.GetLength(0) + 1, A.GetLength(1)];
            for (int i = 0; i <= rowIndex; i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    A[i, j] = matrix[i, j];
                }
            }
            for (int i = 0; i < A.GetLength(1); i++)
            {
                A[rowIndex + 1, i] = B[i, columnIndex];
            }
            for (int i = rowIndex + 2; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    A[i, j] = matrix[i - 1, j];
                }
            }

        }
        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int c = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[row, i] > 0)
                {
                    c++;
                }
            }
            return c;
        }
        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {
            int c = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] > 0)
                {
                    c++;
                }
            }
            return c;
        }
        public int[] CountNegativesPerRow(int[,] matrix)
        {
            int[] ans = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((matrix[i, j] < 0))
                    {
                        ans[i]++;
                    }
                }
            }
            return ans;
        }
        public int FindMaxIndex(int[] array)
        {
            int ans = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > array[ans])
                {
                    ans = i;
                }
            }
            return ans;
        }
        public void ChangeMatrixValues(int[,] matrix)
        {
            if (matrix.GetLength(0) * matrix.GetLength(1) < 5)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = matrix[i, j] * 2;
                    }
                }
            }
            else
            {
                int[] array = new int[matrix.GetLength(0) * matrix.GetLength(1)];
                int t = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        array[t] = matrix[i, j];
                        t++;
                    }
                }
                int n = 1, k = array.Length;
                while (n < k)
                {
                    if (n == 0 || array[n] <= array[n - 1])
                    {
                        n++;
                    }
                    else
                    {
                        (array[n], array[n - 1]) = (array[n - 1], array[n]);
                        n--;
                    }
                }
                int count = 0, k1 = 0, k2 = 0, k3 = 0, k4 = 0, k5 = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (k1 == 0 && count < 5 && matrix[i, j] == array[0])
                        {
                            matrix[i, j] = matrix[i, j] * 2;
                            count++;
                            k1 = 1;
                        }
                        else if (k2 == 0 && count < 5 && matrix[i, j] == array[1])
                        {
                            matrix[i, j] = matrix[i, j] * 2;
                            count++;
                            k2 = 1;
                        }
                        else if (k3 == 0 && count < 5 && matrix[i, j] == array[2])
                        {
                            matrix[i, j] = matrix[i, j] * 2;
                            count++;
                            k3 = 1;
                        }
                        else if (k4 == 0 && count < 5 && matrix[i, j] == array[3])
                        {
                            matrix[i, j] = matrix[i, j] * 2;
                            count++;
                            k4 = 1;
                        }
                        else if (k5 == 0 && count < 5 && matrix[i, j] == array[4])
                        {
                            matrix[i, j] = matrix[i, j] * 2;
                            count++;
                            k5 = 1;
                        }
                        else
                            matrix[i, j] = matrix[i, j] / 2;
                    }
                }
            }
        }
        public void SortNegativeAscending(int[] matrix)
        {
            int[] neg = new int[matrix.Count(n => n < 0)];
            int k = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    neg[k++] = matrix[i];
                }
            }
            Array.Sort(neg);
            k = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    matrix[i] = neg[k++];
                }
            }
        }
        public void SortNegativeDescending(int[] matrix)
        {
            int[] neg = new int[matrix.Count(n => n < 0)];
            int k = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    neg[k++] = matrix[i];
                }
            }
            Array.Sort(neg, (a, b) => b.CompareTo(a));
            k = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    matrix[i] = neg[k++];
                }
            }
        }
        public int GetRowMax(int[,] matrix, int row)
        {
            int max = Enumerable.Range(0, matrix.GetLength(1)).Max(j => matrix[row, j]);
            return max;
        }
        public void SortRowsByMaxAscending(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows - 1; i++)
            {
                for (int k = 0; k < rows - i - 1; k++)
                {
                    int max1 = GetRowMax(matrix, k);
                    int max2 = GetRowMax(matrix, k + 1);

                    if (max1 > max2)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            (matrix[k, j], matrix[k + 1, j]) =
                            (matrix[k + 1, j], matrix[k, j]);
                        }
                    }
                }
            }
        }
        public void SortRowsByMaxDescending(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows - 1; i++)
            {
                for (int k = 0; k < rows - i - 1; k++)
                {
                    int max1 = GetRowMax(matrix, k);
                    int max2 = GetRowMax(matrix, k + 1);
                    if (max1 < max2)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            (matrix[k, j], matrix[k + 1, j]) =
                            (matrix[k + 1, j], matrix[k, j]);
                        }
                    }
                }
            }
        }
        public int[] FindNegativeCountPerRow(int[,] matrix)
        {
            int[] ans = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                ans[i] = Enumerable.Range(0, matrix.GetLength(1)).Count(j => matrix[i, j] < 0);
            }

            return ans;
        }
        public int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            int[] ans = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                ans[i] = Enumerable.Range(0, matrix.GetLength(0)).Select(j => matrix[j, i]).Where(x => x < 0).Any() ? Enumerable.Range(0, matrix.GetLength(0)).Select(j => matrix[j, i]).Where(x => x < 0).Max() : 0;
            }

            return ans;
        }
        public int[,] DefineSeq(int[,] matrix)
        {
            int n = matrix.GetLength(1);

            bool inc = true;
            bool dec = true;

            for (int i = 0; i < n - 1; i++)
            {
                if (matrix[1, i] > matrix[1, i + 1])
                    inc = false;

                if (matrix[1, i] < matrix[1, i + 1])
                    dec = false;
            }

            int[,] result = new int[1, 1];

            if (inc && !dec)
                result[0, 0] = 1;
            else if (!inc && dec)
                result[0, 0] = -1;
            else
                result[0, 0] = 0;

            return result;
        }
        public int[,] FindAllSeq(int[,] matrix)
        {
            int n = matrix.GetLength(1);

            int[] dir = Enumerable.Range(0, n - 1)
                .Select(i =>
                    matrix[1, i + 1] > matrix[1, i] ? 1 :
                    matrix[1, i + 1] < matrix[1, i] ? -1 : 0)
                .ToArray();

            int count = 0;
            for (int i = 0; i < dir.Length; i++)
                if (dir[i] != 0 && (i == 0 || dir[i] != dir[i - 1]))
                    count++;

            int[,] result = new int[count, 2];

            int row = -1;
            int start = 0;

            for (int i = 0; i < dir.Length; i++)
            {
                if (dir[i] != 0 && (i == 0 || dir[i] != dir[i - 1]))
                {
                    if (row >= 0)
                    {
                        result[row, 1] = matrix[0, i];
                    }

                    row++;
                    result[row, 0] = matrix[0, i];
                    start = i;
                }
            }

            if (row >= 0)
                result[row, 1] = matrix[0, n - 1];

            return result;
        }
        public int[,] FindLongestSeq(int[,] matrix)
        {
            int[,] all = FindAllSeq(matrix);

            if (all.GetLength(0) == 0)
                return new int[0, 0];

            int maxLen = all[0, 1] - all[0, 0];
            int index = 0;

            for (int i = 1; i < all.GetLength(0); i++)
            {
                int len = all[i, 1] - all[i, 0];
                if (len > maxLen)
                {
                    maxLen = len;
                    index = i;
                }
            }

            int[,] result = new int[1, 2];
            result[0, 0] = all[index, 0];
            result[0, 1] = all[index, 1];

            return result;
        }
        public double FuncA(double x)
        {
            return x * x - Math.Sin(x);
        }
        public double FuncB(double x)
        {
            return Math.Pow(Math.E, x) - 1;
        }
        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
        {
            int prev = Math.Sign(func(a));
            int ans = 0;
            for (double x = a; x <= b; x += h)
            {
                int sign = Math.Sign(func(x));
                
                if (sign == 0)
                {
                    sign = prev;
                }
                if (prev == 0) 
                {
                    prev = sign;
                }
                else if (sign != 0 && sign != prev)
                {
                    ans++;
                    prev = sign;
                }
                
            }

            return ans;
        }
        public void SortInCheckersOrder(int[][] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Array.Sort(array[i]);
                if (i % 2 == 1)
                {
                    Array.Reverse(array[i]);
                }
            }
        }
        public void SortBySumDesc(int[][] array)
        {
            int rows = array.GetLength(0);
            for (int i = 0; i < rows - 1; i++)
            {
                for (int k = 0; k < rows - i - 1; k++)
                {
                    int sum1 = array[k].Sum();
                    int sum2 = array[k + 1].Sum();

                    if (sum1 < sum2)
                    {
                        (array[k], array[k + 1]) = (array[k + 1], array[k]);
                    }
                }
            }
        }
        public void TotalReverse(int[][] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Array.Reverse(array[i]);
            }
            Array.Reverse(array);
        }

        public delegate void Sorting(int[] matrix);
        public delegate void SortRowsByMax(int[,] matrix);
        public delegate int[] FindNegatives(int[,] matrix);
        public delegate int[,] MathInfo(int[,] matrix);


        public void Task1(int[,] A, int[,] B)
        {
            if (A.GetLength(0) == A.GetLength(1) && B.GetLength(0) == B.GetLength(1) && A.GetLength(0) == B.GetLength(0))
            {
                int r1, r2;
                r1 = FindDiagonalMaxIndex(A);
                r2 = FindDiagonalMaxIndex(B);

                SwapRowColumn(A, r1, B, r2);
            }
        }
        public void Task2(ref int[,] A, int[,] B)
        {
            if (A.GetLength(1) == B.GetLength(0))
            {
                int r1 = 0, r2 = 0;
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    if (CountPositiveElementsInRow(A, i) > CountPositiveElementsInRow(A, r1))
                    {
                        r1 = i;
                    }
                }
                for (int i = 0; i < B.GetLength(1); i++)
                {
                    if (CountPositiveElementsInColumn(B, i) > CountPositiveElementsInColumn(B, r2))
                    {
                        r2 = i;
                    }
                }
                InsertColumn(ref A, r1, r2, B);
            }




        }
        public void Task3(int[,] matrix)
        {

            ChangeMatrixValues(matrix);

        }
        public void Task4(int[,] A, int[,] B)
        {
            if (A.GetLength(1) == B.GetLength(1))
            {
                int r1, r2;
                r1 = FindMaxIndex(CountNegativesPerRow(A));
                r2 = FindMaxIndex(CountNegativesPerRow(B));

                if (CountNegativesPerRow(A)[r1] != 0 && CountNegativesPerRow(B)[r2] != 0)
                {
                    for (int i = 0; i < A.GetLength(1); i++)
                    {
                        (A[r1, i], B[r2, i]) = (B[r2, i], A[r1, i]);
                    }
                }
            }

        }
        public void Task5(int[] matrix, Sorting sort)
        {
            sort(matrix);
        }
        public void Task6(int[,] matrix, SortRowsByMax sort)
        {
            sort(matrix);
        }
        public int[] Task7(int[,] matrix, FindNegatives find)
        {
            int[] negatives = find(matrix);
            return negatives;
        }
        public int[,] Task8(int[,] matrix, MathInfo info)
        {
            if (Enumerable.Range(1, matrix.GetLength(1) - 1).All(i => matrix[1, i] == matrix[1, 0]))
            {
                return new int[0, 0];
            }
            int[,] seq = info(matrix);
            return seq;
        }
        public int Task9(double a, double b, double h, Func<double, double> func)
        {
            int answer = CountSignFlips(a, b, h, func);
            return answer;
        }
        public void Task10(int[][] array, Action<int[][]> func)
        {
            func(array);
        }


    }
}