using System.Linq;
using System.Runtime.InteropServices;

namespace Lab6
{
    public class Green
    {
        public void Task1(ref int[] A, ref int[] B)
        {

            // code here
            DeleteMaxElement(ref A);
            DeleteMaxElement(ref B);
            A = CombineArrays(A, B);

            // end

        }
        public void DeleteMaxElement(ref int[] array)
        {
            int ind = 0;
            int m = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > m)
                {
                    m = array[i];
                    ind = i;
                }
            }
            int[] array1 = new int[array.Length - 1];
            for (int i = 0; i < array1.Length; i++)
            {
                if (i < ind)
                {
                    array1[i] = array[i];
                }
                else
                {
                    array1[i] = array[i + 1];
                }
            }
            array = array1;
        }
        public int[] CombineArrays(int[] A, int[] B)
        {
            int[] ab = new int[A.Length + B.Length];
            for (int i = 0; i < A.Length; i++)
            {
                ab[i] = A[i];
            }
            int k = 0;
            for (int i = A.Length; i < ab.Length; i++)
            {
                ab[i] = B[k];
                k++;
            }
            return ab;
        }

        public void Task2(int[,] matrix, int[] array)
        {

            // code here
            if (array == null || matrix == null)
            {
                return;
            }
            if (array.Length != matrix.GetLength(0))
            {
                return;
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int j;
                int m = FindMaxInRow(matrix, i, out j);
                if (m < array[i])
                {
                    matrix[i, j] = array[i];
                }
            }
            // end

        }
        public int FindMaxInRow(int[,] matrix, int row, out int col)
        {
            col = 0;
            int m = int.MinValue;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > m)
                {
                    m = matrix[row, j];
                    col = j;
                }
            }
            return m;
        }

        public void Task3(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }
            int row;
            int col;
            FindMax(matrix, out row, out col);
            SwapColWithDiagonal(matrix,  col);

            // end

        }
        public void FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;
            int m = int.MinValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > m)
                    {
                        m = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
        }
        public void SwapColWithDiagonal(int[,] matrix, int col)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }
            for (int i = 0; i <matrix.GetLength(0); i++)
            {
                int t = matrix[i, i];
                matrix[i, i] = matrix[i, col];
                matrix[i, col] = t;
            }
        }

        public void Task4(ref int[,] matrix)
        {

            // code here
            if (matrix == null)
            {
                return;
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                bool z = false;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        z = true;
                        break;
                    }
                }

                if (z)
                {
                    RemoveRow(ref matrix, i);
                    i--;
                }
            }

            // end

        }
        public void RemoveRow(ref int[,] matrix, int row)
        {
            int[,] newMatrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];

            for (int i = 0, k= 0; i < matrix.GetLength(0); i++)
            {
                
                if (i == row) continue;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    newMatrix[k, j] = matrix[i, j];
                }
                k++;
            }

            
            matrix = newMatrix;
        }

        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1) || matrix == null)
            {
                return null;
            }
            answer = GetRowsMinElements(matrix);
            // end

            return answer;
        }
        public int[] GetRowsMinElements(int[,] matrix)
        {
            int[] array = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int m = int.MaxValue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j >= i)
                    {
                        if (matrix[i,j] < m)
                        {
                            m = matrix[i, j];
                            
                        }
                    }
                }
                array[i] = m;
            }
            return array;
        }
        public int[] Task6(int[,] A, int[,] B)
        {
            int[] answer = null;

            // code here
            int[] a = SumPositiveElementsInColumns(A);
            int[] b = SumPositiveElementsInColumns(B);
            answer = CombineArrays(a, b);
            // end

            return answer;
        }
        public int[] SumPositiveElementsInColumns(int[,] matrix)
        {
            int[] s = new int[matrix.GetLength(1)];
            for ( int j = 0; j < matrix.GetLength(1); j++)
            {
                int sum = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i,j] >0)
                    {
                        sum += matrix[i, j];
                    }
                }
                s[j] = sum;
            }
            return s;
        }

        public void Task7(int[,] matrix, Sorting sort)
        {

            // code here
            if (matrix==null)
            {
                return;
            }
            sort(matrix);
            // end

        }
        public void SortEndAscending(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = matrix[i, 0];
                int m = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        m = j;
                    }
                }
                if (m == matrix.GetLength(1) - 1) continue;
                for (int k = m + 1; k < matrix.GetLength(1) - 1; k++)
                {
                    for (int j = m + 1; j < matrix.GetLength(1) - 1; j++)
                    {
                        if (matrix[i, j] > matrix[i, j + 1])
                        {
                            (matrix[i, j], matrix[i, j + 1]) = (matrix[i, j + 1], matrix[i, j]);
                        }

                    }
                }
            }

        }
        public void SortEndDescending(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = matrix[i, 0];
                int m = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        m = j;
                    }
                }
                if (m == matrix.GetLength(1) - 1) continue;
                for (int k = m + 1; k < matrix.GetLength(1) - 1; k++)
                {
                    for (int j = m + 1; j < matrix.GetLength(1) - 1; j++)
                    {
                        if (matrix[i, j] < matrix[i, j + 1])
                        {
                            (matrix[i, j], matrix[i, j + 1]) = (matrix[i, j + 1], matrix[i, j]);
                        }

                    }
                }
            }
            ;
        }
        public delegate void Sorting(int[,] matrix);

        public int Task8(double[] A, double[] B)
        {
            int answer = 0;

            // code here
            double a = GeronArea(A[0], A[1], A[2]);
            double b = GeronArea(B[0], B[1], B[2]);
            if (a>b)
            {
                answer = 1;
            }
            else
            {
                answer = 2;
            }
            // end

            return answer;
        }
        public double GeronArea(double a, double b, double c)
        {
            if (a+b <c ||b+c<a ||a+c<b)
            {
                return 0.0;
            }
            double p = (a + b + c) / 2.0;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        public void Task9(int[,] matrix, Action<int[]> sorter)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i % 2 == 0) SortMatrixRow(matrix, i, sorter);

            }
            // end

        }
        public void SortMatrixRow(int[,]matrix, int row, Action<int[]> sorter)
        {
            int[] array = new int[matrix.GetLength(1)];
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                array[j] = matrix[row, j];
            }
            sorter(array);
            ReplaceRow(matrix, row, array); 
        }
        public void ReplaceRow(int[,] matrix, int row, int[] array)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[row, j] = array[j];
            }
            ;
        }
        public void SortAscending(int[] array)
        {
            Array.Sort(array);
        }
        public void SortDescending(int[] array)
        {
            Array.Sort(array);
            Array.Reverse(array);
        }
        public double Task10(int[][] array, Func<int[][], double> func)
        {
            double res = 0;

            // code here
            if (array == null || func == null)
                return 0;
            res = func(array);
            // end

            return res;
        }
        public double CountZeroSum(int[][] array)
        {
            double c = 0;
            for (int i = 0; i < array.Length; i++)
            {
                double s = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    s += array[i][j];
                }
                if (s == 0)
                {
                    c++;
                }
            }
            return c;
        }
        public double FindMedian(int[][]array)
        {
            int n = 0;
            for (int i = 0; i < array.Length; i++)
            {
                n += array[i].Length;
            }

            int[] ar = new int[n];
            int k = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    ar[k] = array[i][j];
                    k++;
                }
            }
            Array.Sort(ar);
            double m = 0.0;
            if (ar.Length % 2 == 0)
            {
                m = (double)(ar[n / 2 - 1] + ar[n / 2]) / 2.0;
            }
            else
            {
                m = (double)ar[n / 2];
            }
            return m;
        }
        public double CountLargeElements(int[][] array)
        {
            double c = 0;
            double a = 0 ;
            for (int i = 0; i < array.Length; i++)
            {
                double s = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    s += array[i][j];
                }
                a = s / array[i].Length;
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] > a)
                    {
                        c++;
                    }
                }
            }
            return c;
        }
    }
}