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
            int maxIndex = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > array[maxIndex])
                {
                    maxIndex = i;
                }
            }

            int[] newArray = new int[array.Length - 1];
            for (int i = 0; i < maxIndex; i++)
            {
                newArray[i] = array[i];
            }
            for (int i = maxIndex + 1; i < array.Length; i++)
            {
                newArray[i - 1] = array[i];
            }

            array = newArray;
        }

        public int[] CombineArrays(int[] A, int[] B)
        {
            if (A == null) A = new int[0];
            if (B == null) B = new int[0];

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

            // code here
            if (array.Length == 0 || matrix.GetLength(0) != array.Length) { return; }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int maxValue = FindMaxInRow(matrix, i, out int col);
                if (maxValue < array[i])
                {
                    matrix[i, col] = array[i];
                }
            }
            // end

        }

        public int FindMaxInRow(int[,] matrix, int row, out int col)
        {
            int maxValue = int.MinValue;
            int cols = matrix.GetLength(1);
            col = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > maxValue)
                {
                    maxValue = matrix[row, j];
                    col = j;
                }
            }
            return maxValue;
        }

        public void Task3(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1)) { return; }
            FindMax(matrix, out int row, out int col);
            SwapColWithDiagonal(matrix, col);
            // end

        }

        public void FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;
            int maxValue = int.MinValue;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
        }

        public void SwapColWithDiagonal(int[,] matrix, int col)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int temp = matrix[i, i];
                matrix[i, i] = matrix[i, col];
                matrix[i, col] = temp;
            }
        }

        public void Task4(ref int[,] matrix)
        {

            // code here
            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                bool flag = false;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag) { RemoveRow(ref matrix, i); }
            }
            // end

        }

        public void RemoveRow(ref int[,] matrix, int row)
        {
            int[,] res = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    res[i, j] = matrix[i, j];
                }
            }

            for (int i = row + 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    res[i - 1, j] = matrix[i, j];
                }
            }

            matrix = res;
        }

        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return answer;
            return GetRowsMinElements(matrix);
            // end

            return answer;
        }

        public int[] GetRowsMinElements(int[,] matrix)
        {
            int[] array = new int[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int minValue = int.MaxValue;
                for (int j = i; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < minValue)
                    {
                        minValue = matrix[i, j];
                    }
                }
                array[i] = minValue;
            }

            return array;
        }

        public int[] Task6(int[,] A, int[,] B)
        {
            int[] answer = null;

            // code here
            int[] newA = SumPositiveElementsInColumns(A);
            int[] newB = SumPositiveElementsInColumns(B);
            answer = CombineArrays(newA, newB);
            // end

            return answer;
        }

        public int[] SumPositiveElementsInColumns(int[,] matrix)
        {
            int[] array = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int SumCol = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] > 0)
                    { SumCol += matrix[j, i]; }
                }
                array[i] = SumCol;
                SumCol = 0;
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
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                int maxIndex = 0;
                int maxValue = matrix[i, 0];
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxIndex = j;
                        maxValue = matrix[i, j];
                    }
                }

                for (int j = maxIndex + 1; j < cols; j++)
                {
                    for (int k = maxIndex + 1; k < cols - j + maxIndex; k++)
                    {
                        if (matrix[i, k] > matrix[i, k + 1])
                        {
                            int temp = matrix[i, k];
                            matrix[i, k] = matrix[i, k + 1];
                            matrix[i, k + 1] = temp;
                        }
                    }
                }
            }
        }

        public void SortEndDescending(int[,] matrix)
        {
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                int maxIndex = 0;
                int maxValue = matrix[i, 0];
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxIndex = j;
                        maxValue = matrix[i, j];
                    }
                }

                for (int j = maxIndex + 1; j < cols; j++)
                {
                    for (int k = maxIndex + 1; k < cols - j + maxIndex; k++)
                    {
                        if (matrix[i, k] < matrix[i, k + 1])
                        {
                            int temp = matrix[i, k];
                            matrix[i, k] = matrix[i, k + 1];
                            matrix[i, k + 1] = temp;
                        }
                    }
                }
            }
        }

        public int Task8(double[] A, double[] B)
        {
            int answer = 0;

            // code here
            double SA = GeronArea(A[0], A[1], A[2]);
            double SB = GeronArea(B[0], B[1], B[2]);

            if (SA > SB) { answer = 1; }
            else { answer = 2; }
            // end

            return answer;
        }

        public double GeronArea(double a, double b, double c)
        {
            if (a + b <= c || a + c <= b || b + c <= a) { return 0; }

            double p = (a + b + c) / 2;
            double S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            return S;
        }

        public void Task9(int[,] matrix, Action<int[]> sorter)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i % 2 == 0)
                {
                    SortMatrixRow(matrix, i, sorter);
                }
            }
            // end

        }

        public delegate void Action(int[] array);

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
        }

        public void SortAscending(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
        }

        public void SortDescending(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] < array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
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

        public delegate int[][] Func(int[][] array);

        public double CountZeroSum(int[][] array)
        {
            double count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum += array[i][j];
                }
                if (sum == 0) count++;
            }
            return count;
        }

        public double FindMedian(int[][] array)
        {
            double median;
            int len = 0;
            for (int i = 0; i < array.Length; i++)
            {
                len += array[i].Length;
            }

            int[] arr = new int[len];
            for (int i = 0, k = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    arr[k++] = array[i][j];
                }
            }
            SortAscending(arr);
            if (arr.Length % 2 == 0)
            {
                median = (double)(arr[len / 2 - 1] + arr[len / 2]) / 2;
            }
            else median = arr[len / 2];
            return median;
        }

        public double CountLargeElements(int[][] array)
        {
            double count = 0;
            double avg;
            for (int i = 0; i < array.Length; i++)
            {
                double sum = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum += array[i][j];
                }
                avg = sum / array[i].Length;
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] > avg) count++;
                }
            }
            return count;
        }
    }
}