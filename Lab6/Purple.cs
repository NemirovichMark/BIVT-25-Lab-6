using System;
using System.ComponentModel.Design;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public class Purple
    {
        public void Task1(int[,] A, int[,] B)
        {

            // code here
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    Console.Write(A[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            if (A.GetLength(0) == A.GetLength(1) && B.GetLength(0) == B.GetLength(1) && A.GetLength(0) == B.GetLength(0))
            {
                int ind_a = FindDiagonalMaxIndex(A), ind_b = FindDiagonalMaxIndex(B);
                SwapRowColumn(A, ind_a, B, ind_b);
            }
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    Console.Write(A[i, j] + " ");
                }
                Console.WriteLine();
            }
            // end

        }
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int mx = matrix[0, 0], ind_mx = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > mx)
                {
                    ind_mx = i;
                    mx = matrix[i, i];
                }
            }
            return ind_mx;
        }
        public void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                (matrix[rowIndex, i], B[i, columnIndex]) = (B[i, columnIndex], matrix[rowIndex, i]);
            }

        }
        public void Task2(ref int[,] A, int[,] B)
        {

            // code here
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    Console.Write(A[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    Console.Write(B[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            int mx_st = int.MinValue, ind_A = -1;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                int kol = CountPositiveElementsInRow(A, i);
                if (kol > mx_st)
                {
                    mx_st = kol;
                    ind_A = i;
                }
            }

            int mx_r = int.MinValue, ind_B = -1;
            for (int i = 0; i < B.GetLength(1); i++)
            {
                int kol = CountPositiveElementsInColumn(B, i);
                if (kol > mx_r)
                {
                    mx_r = kol;
                    ind_B = i;
                }
            }

            if (ind_B != -1 && ind_A != -1 && A.GetLength(1) == B.GetLength(0))
            {
                InsertColumn(ref A, ind_A, ind_B, B);
            }
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    Console.Write(A[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("_____________");
            // end

        }

        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int k = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[row, i] > 0)
                {
                    k++;
                }
            }
            return k;
        }
        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {
            int k = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] > 0)
                {
                    k++;
                }
            }
            return k;
        }
        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B)
        {
            int[,] A_clone = new int[A.GetLength(0) + 1, A.GetLength(1)];
            for (int i = 0; i <= rowIndex; i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    A_clone[i, j] = A[i, j];
                }
            }
            for (int j = 0; j < A.GetLength(1); j++)
            {
                A_clone[rowIndex + 1, j] = B[j, columnIndex];
            }
            for (int i = rowIndex + 1; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    A_clone[i + 1, j] = A[i, j];
                }
            }
            A = new int[A.GetLength(0) + 1, A.GetLength(1)];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    A[i, j] = A_clone[i, j];
                }
            }
        }

        public void Task3(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            ChangeMatrixValues(matrix);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            // end

        }
        public void ChangeMatrixValues(int[,] matrix)
        {

            int k = 0;
            int mx_i_p = int.MaxValue;
            int[] mx = new int[5];
            int[,] mat = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    mat[i, j] = matrix[i, j];
                }
            }
            int mx_i = matrix[0, 0], ind_i = 0, ind_j = 0;
            while (k < Math.Min(5, matrix.GetLength(0) * matrix.GetLength(1)))
            {
                mx_i = matrix[0, 0];
                ind_i = 0;
                ind_j = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {

                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] > mx_i)
                        {
                            if (matrix[i, j] <= mx_i_p)
                            {
                                mx_i = matrix[i, j];
                                ind_i = i;
                                ind_j = j;
                            }
                        }

                    }
                }
                mx_i_p = mx_i;
                mx[k] = mx_i_p;
                matrix[ind_i, ind_j] = matrix[ind_i, ind_j] * 2;
                k += 1;
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (mat[i, j] > 0)
                    {
                        if (matrix[i, j] <= mx_i_p && (i != ind_i || j != ind_j))
                        {
                            matrix[i, j] = matrix[i, j] / 2;
                        }
                    }
                    else
                    {
                        if (mat[i, j] <= mx_i_p && (i != ind_i || j != ind_j))
                        {
                            matrix[i, j] = matrix[i, j] / 2;
                        }
                    }
                }

            }

        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here
            int ind_A = FindMaxIndex(CountNegativesPerRow(A)), ind_B = FindMaxIndex(CountNegativesPerRow(B));
            if (A.GetLength(1) == B.GetLength(1))
            {
                if (ind_A != -1 && ind_B != -1)
                {
                    for (int i = 0; i < A.GetLength(1); i++)
                    {
                        (A[ind_A, i], B[ind_B, i]) = (B[ind_B, i], A[ind_A, i]);
                    }
                }
            }
            // end

        }
        public int[] CountNegativesPerRow(int[,] matrix)
        {
            int[] array = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int k = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        k += 1;
                    }
                }
                array[i] = k;
            }
            return array;
        }
        public int FindMaxIndex(int[] array)
        {
            int mx = array[0], ind = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > mx)
                {
                    ind = i;
                    mx = array[i];
                }

            }
            return ind;
        }
        public void Task5(int[] matrix, Sorting sort)
        {

            // code here
            sort(matrix);
            // end

        }
        public delegate void Sorting(int[] matrix);
        public void SortNegativeAscending(int[] matrix)
        {
            int k = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                    k += 1;
            }
            int[] sort = new int[k];
            k = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    sort[k] = matrix[i];
                    k++;
                }
            }
            Array.Sort(sort);
            int c = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    matrix[i] = sort[c];
                    c++;
                }
            }
        }
        public void SortNegativeDescending(int[] matrix)
        {
            int k = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                    k += 1;
            }
            int[] sort = new int[k];
            k = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    sort[k] = matrix[i];
                    k++;
                }
            }
            Array.Sort(sort);
            Array.Reverse(sort);
            int c = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    matrix[i] = sort[c];
                    c++;
                }
            }
        }
        public void Task6(int[,] matrix, SortRowsByMax sort)
        {

            // code here
            sort(matrix);
            // end

        }
        public delegate void SortRowsByMax(int[,] matrix);
        public void SortRowsByMaxAscending(int[,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int i1 = 0; i1 < n - i - 1; i1++)
                {
                    int max_el_st1 = GetRowMax(matrix, i1), max_el_st2 = GetRowMax(matrix, i1 + 1);

                    if (max_el_st1 > max_el_st2)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            (matrix[i1, j], matrix[i1 + 1, j]) = (matrix[i1 + 1, j], matrix[i1, j]);
                        }
                    }
                }
            }
        }
        public void SortRowsByMaxDescending(int[,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int i1 = 0; i1 < n - i - 1; i1++)
                {
                    int max_el_st1 = GetRowMax(matrix, i1), max_el_st2 = GetRowMax(matrix, i1 + 1);

                    if (max_el_st1 < max_el_st2)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            (matrix[i1, j], matrix[i1 + 1, j]) = (matrix[i1 + 1, j], matrix[i1, j]);
                        }
                    }
                }
            }
        }
        public int GetRowMax(int[,] matrix, int row)
        {
            int makc = matrix[row, 0];
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > makc)
                {
                    makc = matrix[row, j];
                }
            }
            return makc;
        }
        public int[] Task7(int[,] matrix, FindNegatives find)
        {
            int[] negatives = null;

            // code here
            negatives = find(matrix);
            // end

            return negatives;
        }
        public delegate int[] FindNegatives(int[,] matrix);
        public int[] FindNegativeCountPerRow(int[,] matrix)
        {
            int[] ans = new int[matrix.GetLength(0)];
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                int k = 0;
                for (int j = 0; (j < m); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        k++;
                    }
                }
                ans[i] = k;
            }
            return ans;
        }
        public int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            int[] ans = new int[matrix.GetLength(1)];
            int n = matrix.GetLength(0), m = matrix.GetLength(1);

            for (int j = 0; (j < m); j++)
            {
                int k = int.MinValue;
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, j] < 0 && matrix[i, j] > k)
                    {
                        k = matrix[i, j];
                    }
                }
                if (k != int.MinValue)
                    ans[j] = k;
                else
                    ans[j] = 0;
            }
            return ans;
        }
        public int[,] Task8(int[,] matrix, MathInfo info)
        {
            int[,] answer = null;

            // code here
            answer = info(matrix);
            // end

            return answer;
        }
        public delegate int[,] MathInfo(int[,] matrix);

        public int[,] DefineSeq(int[,] matrix)
        {
            if (matrix.GetLength(0) == 2 && matrix.GetLength(1) >= 2)
            {
                int k = 0;
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[1, j] != matrix[1, j + 1])
                    {
                        k = 1;
                        break;
                    }
                }
                if (k == 0)
                {
                    return new int[0, 0];
                }
                int napr = 0;
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[1, j] < matrix[1, j + 1])
                    {
                        napr = 1;
                        break;
                    }
                    else if (matrix[1, j] > matrix[1, j + 1])
                    {
                        napr = -1;
                        break;
                    }
                }
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (napr == 1)
                    {
                        if (matrix[1, j] > matrix[1, j + 1])
                        {
                            return new int[1, 1] { { 0 } };
                        }
                    }
                    else if (napr == -1)
                    {
                        if (matrix[1, j] < matrix[1, j + 1])
                        {
                            return new int[1, 1] { { 0 } };
                        }
                    }
                }
                return new int[1, 1] { { napr } };
            }
            else
                return new int[0, 0];
        }
        public int[,] FindAllSeq(int[,] matrix)
        {


            if (matrix.GetLength(0) == 2 && matrix.GetLength(1) >= 2)
            {
                int k = 0;
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[1, j] != matrix[1, j + 1])
                    {
                        k = 1;
                        break;
                    }
                }
                if (k == 0)
                {
                    return new int[0, 0];
                }
                int napr1 = 0, napr2 = 0;
                k = 0;
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[1, j] < matrix[1, j + 1])
                    {
                        napr1 = 1;
                    }
                    else if (matrix[1, j] > matrix[1, j + 1])
                    {
                        napr1 = -1;

                    }
                    if (napr1 != napr2)
                    {
                        k++;
                        napr2 = napr1;
                    }
                    else if (napr2 == 0)
                    {
                        napr2 = napr1;
                        k++;
                    }
                }
                int c = 0;
                napr2 = 0;
                int el_1 = matrix[0, 0];
                int[,] ans = new int[k, 2];
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[1, j] < matrix[1, j + 1])
                    {
                        napr1 = 1;
                    }
                    else if (matrix[1, j] > matrix[1, j + 1])
                    {
                        napr1 = -1;
                    }
                    if (napr2 == 0)
                    {
                        napr2 = napr1;
                        el_1 = matrix[0, j];
                    }
                    else if (napr1 != napr2)
                    {
                        ans[c, 0] = el_1;
                        ans[c, 1] = matrix[0, j];
                        c++;
                        el_1 = matrix[0, j];
                        napr2 = napr1;

                    }
                }
                ans[c, 0] = el_1;
                ans[c, 1] = matrix[0, matrix.GetLength(1) - 1];
                return ans;
            }
            else
                return new int[0, 0];

        }

        public int[,] FindLongestSeq(int[,] matrix)
        {
            int[,] ans = new int[1, 2];
            int[,] mon = FindAllSeq(matrix);
            int mx = 0;
            if (mon.Length != 0)
            {
                for (int i = 0; i < mon.GetLength(0); i++)
                {

                    int raz = mon[i, 1] - mon[i, 0];
                    if (raz > mx)
                    {
                        mx = raz;
                        ans[0, 0] = mon[i, 0];
                        ans[0, 1] = mon[i, 1];

                    }
                }

                for (int i = 0; i < ans.GetLength(0); i++)
                {
                    for (int j = 0; j < ans.GetLength(1); j++)
                    {
                        Console.Write(ans[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("______________________");
                return ans;
            }
            else
                return new int[0, 0];
        }
        public int Task9(double a, double b, double h, Func<double, double> func)
        {
            int answer = 0;

            // code here
            answer = CountSignFlips(a,b,h, func);
            
            // end

            return answer;
        }
        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
        {
            int k = 0;
            for (double i =  a; i <= b-h; i+=h)
            {
                double x = func(i);
                double y = func(i+h);
                Console.WriteLine($"{x} {y}");
                if (x * y < 0)
                {
                    k++;
                }
            }
            Console.WriteLine("___________");
            return k;

        }
        public double FuncA(double x)
        {
            return Math.Pow(x, 2)- Math.Sin(x);
        }
        public double FuncB(double x)
        {
            return Math.Exp(x)- 1;
        }
        public delegate double Func( double x);
        public void Task10(int[][] array, Action<int[][]> func)
        {

            // code here
            func(array);
            // end

        }
        public delegate void Acrion(int[][] array);
        public void TotalReverse(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Array.Reverse(array[i]);
            }
            Array.Reverse(array);
        }
        public void SortBySumDesc(int[][] array)
        {
            int GetSum(int[] arr)
            {
                if (arr == null) 
                    return 0;
                int sum = 0;
                for (int i = 0; i < arr.Length; i++)
                    sum += arr[i];
                return sum;
            }
            for (int i = 0; i < array.Length-1; i++)
            {
                for (int j = 0; j < array.Length-i-1; j++)
                {
                    int sum1 = GetSum(array[j]);
                    int sum2 = GetSum(array[j+1]);
                    if (sum1 < sum2)
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
                    

            }

        }
        public void SortInCheckersOrder(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(string.Join(", ", array[i]));
            }
            Console.WriteLine();
            for (int i = 0; i < array.Length; i++)
            {
                if ((i%2)!= 0)
                {
                    Array.Sort(array[i]);
                    Array.Reverse(array[i]);
                }
                else
                {
                    Array.Sort(array[i]);
                }
            }
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(string.Join(", ", array[i]));
            }
            Console.WriteLine("____________");
        }
    }
}
