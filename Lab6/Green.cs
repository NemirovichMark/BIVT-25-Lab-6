using System.Collections.Specialized;
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

        public int[] CombineArrays(int[] A, int[] B)
        {
            int[] ans = new int[A.Length + B.Length];
            int i1 = 0;
            for (int i = 0; i < ans.Length; i++)
            {
                if (i < A.Length)
                {
                    ans[i] = A[i];
                }
                else
                {
                    ans[i] = B[i1];
                    i1++;
                }
            }

            return ans;
        }
        public void DeleteMaxElement(ref int[] array)
        {
            int imax = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > array[imax])
                {
                    imax = i;
                }
            }

            int[] ans = new int[array.Length - 1];
            for (int i = 0; i < ans.Length; i++)
            {
                if (i < imax)
                {
                    ans[i] = array[i];
                }
                else
                {
                    ans[i] = array[i + 1];
                }
            }

            array = new int[array.Length - 1];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = ans[i];
            }
        }
        public void Task2(int[,] matrix, int[] array)
        {

            // code here
            if (array.Length == matrix.GetLength(0))
            {
                int col;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    int max_elem = FindMaxInRow(matrix, i, out col);
                    if (max_elem < array[i])
                    {
                        matrix[i, col] = array[i];
                    }
                }
            }
            // end

        }

        public int FindMaxInRow(int[,] matrix, int row, out int col)
        {
            int max_elem = matrix[row, 0];
            col = 0;
            for (int j = 1; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > matrix[row, col])
                {
                    max_elem = matrix[row, j];
                    col = j;
                }
            }

            return max_elem;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                int row, col;
                FindMax(matrix,out row,out col);
                SwapColWithDiagonal(matrix,col);
            }
            // end

        }

        public void SwapColWithDiagonal(int[,] matrix, int col)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int tmp = matrix[i, i];
                matrix[i, i] = matrix[i, col];
                matrix[i, col] = tmp;
            }
        }
        public void FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[row, col])
                    {
                        row = i;
                        col = j;
                    }
                }
            }
        }
        public void Task4(ref int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        RemoveRow(ref matrix, i);
                        i--;
                        n--;
                        break;
                    }
                }
            }
            // end

        }

        public void RemoveRow(ref int[,] matrix, int row)
        {
            int[,] ans = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            for (int i = 0; i < ans.GetLength(0); i++)
            {
                for (int j = 0; j < ans.GetLength(1); j++)
                {
                    if (i < row)
                    {
                        ans[i, j] = matrix[i, j];
                    }
                    else
                    {
                        ans[i, j] = matrix[i + 1, j];
                    }
                }
            }

            matrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = ans[i, j];
                }
            }
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            if (matrix.GetLength(0) == matrix.GetLength(1) && matrix.GetLength(0)!=1)
            {
                answer = GetRowsMinElements(matrix);
            }
            // end

            return answer;
        }

        public int[] GetRowsMinElements(int[,] matrix)
        {
            int[] array = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int min_elem = matrix[i, i];
                for (int j = i + 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min_elem)
                    {
                        min_elem = matrix[i, j];
                    }
                }

                array[i] = min_elem;
            }

            return array;
        }
        public int[] Task6(int[,] A, int[,] B)
        {
            int[] answer = null;

            // code here
            int[] arrayA = SumPositiveElementsInColumns(A);
            int[] arrayB = SumPositiveElementsInColumns(B);
            answer = CombineArrays(arrayA, arrayB);
            // end

            return answer;
        }

        public int[] SumPositiveElementsInColumns(int[,] matrix)
        {
            int[] array = new int[matrix.GetLength(1)];
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int sum = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                    }
                }

                array[j] = sum;
            }

            return array;
        }
        public void Task7(int[,] matrix, Sorting sort)
        {

            // code here
            sort(matrix);
            // end

        }

        public delegate void Sorting(int[,] matrix);

        public void SortEndAscending(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int jmax = 0;
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[i, jmax])
                    {
                        jmax = j;
                    }
                }

                int j1 = jmax + 1;
                while (j1 < matrix.GetLength(1))
                {
                    if (j1 == jmax + 1 || matrix[i, j1] >= matrix[i, j1 - 1])
                    {
                        j1++;
                    }
                    else
                    {
                        int tmp = matrix[i, j1];
                        matrix[i, j1] = matrix[i, j1 - 1];
                        matrix[i, j1 - 1] = tmp;
                        j1--;
                    }
                }
            }
        }

        public void SortEndDescending(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int jmax = 0;
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[i, jmax])
                    {
                        jmax = j;
                    }
                }

                int j1 = jmax + 1;
                while (j1 < matrix.GetLength(1))
                {
                    if (j1 == jmax + 1 || matrix[i, j1] <= matrix[i, j1 - 1])
                    {
                        j1++;
                    }
                    else
                    {
                        int tmp = matrix[i, j1];
                        matrix[i, j1] = matrix[i, j1 - 1];
                        matrix[i, j1 - 1] = tmp;
                        j1--;
                    }
                }
            }
        }
        public int Task8(double[] A, double[] B)
        {
            int answer = 0;

            // code here
            double areaA = GeronArea(A[0], A[1], A[2]);
            double areaB = GeronArea(B[0], B[1], B[2]);
            answer = (areaA > areaB) ? 1 : 2;
            // end

            return answer;
        }

        public double GeronArea(double a, double b, double c)
        {
            if (!(a + b >= c && a + c >= b && b + c >= a)) return 0;
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        public void Task9(int[,] matrix, Action<int[]> sorter)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i+=2)
            {
                SortMatrixRow(matrix,i,sorter);
            }
            // end

        }

        public void ReplaceRow(int[,] matrix, int row, int[] array)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[row, j] = array[j];
            }
        }
        public void SortMatrixRow(int[,] matrix, int row, Action<int[]> sorter)
        {
            int[] array = new int[matrix.GetLength(1)];
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                array[j] = matrix[row, j];
            }

            sorter(array);
            ReplaceRow(matrix,row,array);
        }
        public void SortAscending(int[] array)
        {
            int i = 0;
            while (i < array.Length)
            {
                if (i == 0 || array[i] >= array[i - 1])
                {
                    i++;
                }
                else
                {
                    int tmp = array[i];
                    array[i] = array[i - 1];
                    array[i - 1] = tmp;
                    i--;
                }
            }
        }
        public void SortDescending(int[] array)
        {
            int i = 0;
            while (i < array.Length)
            {
                if (i == 0 || array[i] <= array[i - 1])
                {
                    i++;
                }
                else
                {
                    int tmp = array[i];
                    array[i] = array[i - 1];
                    array[i - 1] = tmp;
                    i--;
                }
            }
        }
        public double Task10(int[][] array, Func<int[][], double> func)
        {
            double res = 0;

            // code here
            res = func(array);
            // end

            return res;
        }

        public double CountZeroSum(int[][] array)
        {
            double count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                double sum = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum += array[i][j];
                }

                if (sum == 0)
                {
                    count++;
                }
            }

            return count;
        }

        public double FindMedian(int[][] array)
        {
            int n = 0;
            for (int i = 0; i < array.Length; i++)
            {
                n += array[i].Length;
            }

            int[] array1 = new int[n];
            int i1 = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    array1[i1] = array[i][j];
                    i1++;
                }
            }

            i1 = 0;
            while (i1 < array1.Length)
            {
                if (i1 == 0 || array1[i1] >= array1[i1 - 1])
                {
                    i1++;
                }
                else
                {
                    int tmp = array1[i1];
                    array1[i1] = array1[i1 - 1];
                    array1[i1 - 1] = tmp;
                    i1--;
                }
            }

            double ans = (n % 2 == 0) ? (array1[(n - 1) / 2] + array1[(n - 1) / 2 + 1]) / 2.0 : array1[(n - 1) / 2];
            return ans;
        }

        public double CountLargeElements(int[][] array)
        {
            double count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                double tb = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    tb += array[i][j];
                }

                tb = tb / array[i].Length;
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] > tb)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
