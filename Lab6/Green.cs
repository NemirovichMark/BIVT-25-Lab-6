using System.Linq;
using System.Runtime.InteropServices;

namespace Lab6
{
    public class Green
    {
        public void Task1(ref int[] A, ref int[] B)
        {

            DeleteMaxElement(ref A);
            DeleteMaxElement(ref B);
            A = CombineArrays(A, B);

        }

        public void DeleteMaxElement(ref int[] array)
        {
            int maxi = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > array[maxi])
                {
                    maxi = i;
                }
            }

            int[] newArray = new int[array.Length - 1];
            int newIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (i != maxi)
                {
                    newArray[newIndex] = array[i];
                    newIndex++;
                }
            }

            array = newArray;
        }

        public int[] CombineArrays(int[] A, int[] B)
        {
            int[] result = new int[A.Length + B.Length];
            for (int i = 0; i < A.Length; i++)
            {
                result[i] = A[i];
            }

            for (int i = 0; i < B.Length; i++)
            {
                result[A.Length + i] = B[i];
            }

            return result;
        }

        public void Task2(int[,] matrix, int[] array)
        {

             if (matrix == null || array.Length == 0 || matrix.GetLength(0) != array.Length)
            {
                return;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int maxValue = FindMaxInRow(matrix, i, out int col);
                if (maxValue < array[i])
                {
                    matrix[i, col] = array[i];
                }
            }
        }
            public int FindMaxInRow(int[,] matrix, int row, out int col)
        {
            int maxx = int.MinValue;
            col = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > maxx)
                {
                    maxx = matrix[row, j];
                    col = j;
                }
            }
            return maxx;
        }
        public void Task3(int[,] matrix)
        {

            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }
            FindMax(matrix, out int row, out int col);
            int colMax = col;
            SwapColWithDiagonal(matrix, colMax);

        }
        public void FindMax(int[,] matrix, out int row, out int col)
        {
            int maxx = int.MinValue;
            int rowMax = 0;
            int colMax = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxx)
                    {
                        maxx = matrix[i, j];
                        rowMax = i;
                        colMax = j;
                    }
                }
            }
            row = rowMax;
            col = colMax;
        }


        public void SwapColWithDiagonal(int[,] matrix, int col)
        {
            int maxCol = col;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                (matrix[i, i], matrix[i, col]) = (matrix[i, col], matrix[i, i]);
            }
        }


        public void Task4(ref int[,] matrix)
        {

            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                bool F = false;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        F = true;
                        break;
                    }
                }

                if (F)
                {
                    RemoveRow(ref matrix, i);
                }
            }

        }
        public void RemoveRow(ref int[,] matrix, int row)
        {
            if (matrix == null)
                return;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (row < 0 || row >= rows)
                return;

            if (rows == 1)
            {
                matrix = new int[0, cols];
                return;
            }

            int[,] newMatrix = new int[rows - 1, cols];

            int newRowi = 0;

            for (int i = 0; i < rows; i++)
            {
                if (i != row)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        newMatrix[newRowi, j] = matrix[i, j];
                    }
                    newRowi++;
                }
            }
            matrix = newMatrix;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            answer = GetRowsMinElements(matrix);

            return answer;
        }

        public int[] GetRowsMinElements(int[,] matrix)
        {
            if (matrix == null) return null;
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return null;
            }

            int[] result = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int minn = matrix[i, i];
                for (int j = i + 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < minn)
                    {
                        minn = matrix[i, j];
                    }
                }

                result[i] = minn;
            }

            return result;
        }
        public int[] Task6(int[,] A, int[,] B)
        {
            int[] answer = null;

            int[] C = SumPositiveElementsInColumns(A);
            int[] D = SumPositiveElementsInColumns(B);

            answer = CombineArrays(C, D);

            return answer;
        }

        public int[] SumPositiveElementsInColumns(int[,] matrix)
        {
            if (matrix == null) return null;

            int[] array = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int rowSum = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] > 0)
                    {
                        rowSum += matrix[j, i];
                    }
                }
                array[i] = rowSum;
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
            if (matrix == null) return;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int maxi = 0;
                int maxx = matrix[i, 0];
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxx)
                    {
                        maxx = matrix[i, j];
                        maxi = j;
                    }
                }

                if (maxi < matrix.GetLength(1) - 1)
                {
                    for (int k = maxi + 1; k < matrix.GetLength(1); k++)
                    {
                        for (int l = maxi + 1; l < matrix.GetLength(1) - 1; l++)
                        {
                            if (matrix[i, l] > matrix[i, l + 1])
                            {
                                (matrix[i, l], matrix[i, l + 1]) = (matrix[i, l + 1], matrix[i, l]);
                            }
                        }
                    }
                }
            }
        }

        public void SortEndDescending(int[,] matrix)
        {
            if (matrix == null) return;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int maxi = 0;
                int maxx= matrix[i, 0];
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxx)
                    {
                        maxx = matrix[i, j];
                        maxi = j;
                    }
                }

                if (maxi < matrix.GetLength(1) - 1)
                {
                    for (int k = maxi + 1; k < matrix.GetLength(1); k++)
                    {
                        for (int l = maxi + 1; l < matrix.GetLength(1) - 1; l++)
                        {
                            if (matrix[i, l] < matrix[i, l + 1])
                            {
                                (matrix[i, l], matrix[i, l + 1]) = (matrix[i, l + 1], matrix[i, l]);
                            }
                        }
                    }
                }
            }
        }

        public int Task8(double[] A, double[] B)
        {
            int answer = 0;

            double areaA = GeronArea(A[0], A[1], A[2]);
            double areaB = GeronArea(B[0], B[1], B[2]);

            if (areaA > areaB) answer = 1;
            else answer = 2;
            

            return answer;
        }
        public double GeronArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                return 0;
            }
            if (a + b <= c || a + c <= b || b + c <= a)
            {
                return 0;
            }
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        public void Task9(int[,] matrix, Action<int[]> sorter)
        {

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i % 2 == 0) SortMatrixRow(matrix, i, sorter);
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

            if (array == null || func == null)
                return 0;
            res = func(array);

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
        public double FindMedian(int[][] array)
        {
            int n = 0;
            for (int i = 0; i < array.Length; i++)
            {
                n += array[i].Length;
            }

            int[] A = new int[n];
            int k = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    A[k] = array[i][j];
                    k++;
                }
            }
            Array.Sort(A);
            double m = 0.0;
            if (A.Length % 2 == 0)
            {
                m = (double)(A[n / 2 - 1] + A[n / 2]) / 2.0;
            }
            else
            {
                m = (double)A[n / 2];
            }
            return m;
        }
        public double CountLargeElements(int[][] array)
        {
            double c = 0;
            double a = 0;
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
