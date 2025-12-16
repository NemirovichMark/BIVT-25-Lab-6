using System.ComponentModel;
using System.Linq;
using System.Runtime.ExceptionServices;
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
            int[] result = CombineArrays(A, B);
            A = result;
            // end

        }

        public void Task2(int[,] matrix, int[] array)
        {
            // code here
            if (array.Length == 0 || matrix.GetLength(0) != array.Length) return;
            for (int i = 0; i < array.Length; i++)
            {
                int maxValue = FindMaxInRow(matrix, i, out int maxCol);
                if (maxValue < array[i])
                {
                    matrix[i, maxCol] = array[i];
                }
            }
            // end
        }

        public void Task3(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            if (rows != cols) return;
            FindMax(matrix, out int row, out int col);
            SwapColWithDiagonal(matrix, col);
            // end

        }

        public void Task4(ref int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            for (int i = rows - 1; i >= 0; i--)
            {
                bool hasZero = false;
                int cols = matrix.GetLength(1);
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        hasZero = true;
                        break;
                    }
                }
                if (hasZero)
                {
                    RemoveRow(ref matrix, i);
                }
            }
            // end

        }

        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            answer = GetRowsMinElements(matrix);
            // end

            return answer;
        }

        public int[] Task6(int[,] A, int[,] B)
        {
            int[] answer = null;

            // code here
            int[] arr1 = SumPositiveElementsInColumns(A);
            int[] arr2 = SumPositiveElementsInColumns(B);
            answer = CombineArrays(arr1, arr2);
            // end

            return answer;
        }

        public void Task7(int[,] matrix, Sorting sort)
        {

            // code here
            sort(matrix);
            // end

        }

        public int Task8(double[] A, double[] B)
        {
            int answer = 0;

            // code here
            if (A.Length != 3 || B.Length != 3) return 0;
            double triangle1 = GeronArea(A[0], A[1], A[2]);
            double triangle2 = GeronArea(B[0], B[1], B[2]);
            if (triangle1 > triangle2) answer = 1;
            else answer = 2;
            // end

            return answer;
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
        public double Task10(int[][] array, Func<int[][], double> func)
        {
            double res = 0;

            // code here
            res = func(array);
            // end

            return res;
        }

        public void DeleteMaxElement(ref int[] array)
        {
            int maxValue = array[0], maxIndex = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                    maxIndex = i;
                }
            }
            int[] newArray = new int[array.Length - 1];
            for (int i = 0; i < newArray.Length; i++)
            {
                if (i < maxIndex)
                {
                    newArray[i] = array[i];
                }
                else
                {
                    newArray[i] = array[i + 1];
                }
            }
            array = newArray;
        }

        public int[] CombineArrays(int[] A, int[] B)
        {
            int[] result = new int[A.Length + B.Length];
            for (int i = 0; i < result.Length; i++)
            {
                if (i < A.Length) result[i] = A[i];
                else result[i] = B[i - A.Length];
            }
            return result;
        }

        public int FindMaxInRow(int[,] matrix, int row, out int col)
        {
            int cols = matrix.GetLength(1);
            int maxValue = matrix[row, 0];
            col = 0;
            for (int j = 1; j < cols; j++)
            {
                if (matrix[row, j] > maxValue)
                {
                    maxValue = matrix[row, j];
                    col = j;
                }
            }
            return maxValue;
        }

        public void FindMax(int[,] matrix, out int row, out int col)
        {
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            int maxValue = matrix[0, 0];
            row = -1; col = -1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
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
                if (i == col) continue;
                int temp = matrix[i, i];
                matrix[i, i] = matrix[i, col];
                matrix[i, col] = temp;
            }
        }

        public void RemoveRow(ref int[,] matrix, int row)
        {
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            int[,] res = new int[rows - 1, cols];
            for (int i = 0; i < rows - 1; i++)
            {
                if (i < row)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        res[i, j] = matrix[i, j];
                    }
                }
                else
                {
                    for (int j = 0; j < cols; j++)
                    {
                        res[i, j] = matrix[i + 1, j];
                    }
                }
            }
            matrix = res;
        }

        public int[] GetRowsMinElements(int[,] matrix)
        {
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            if (rows != cols) return null;
            int[] answer = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                int MinValue = matrix[i, i];
                for (int j = i; j < cols; j++)
                {
                    if (matrix[i, j] < MinValue)
                    {
                        MinValue = matrix[i, j];
                    }
                }
                answer[i] = MinValue;
            }
            return answer;
        }

        
        public int[] SumPositiveElementsInColumns(int[,] matrix)
        {
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            int[] answer = new int[cols];
            for (int j = 0; j < cols; j++)
            {
                int sum = 0;
                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] > 0) sum += matrix[i, j];
                    else sum += 0;
                }
                answer[j] = sum;
            }
            return answer;
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

        public double GeronArea(double a, double b, double c)
        {
            if (a + b < c || a + c < b || b + c < a) return 0;
            double p = (a + b + c) / 2;
            double S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return S;
        }

        public delegate void Action(int[] array);

        public void SortMatrixRow(int[,] matrix, int row, Action<int[]> sorter)
        {
            int cols = matrix.GetLength(1);
            int[] array = new int[cols];
            for (int j = 0; j < cols; j++)
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
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
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
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] < array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
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
            double count = 0, avg;
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
