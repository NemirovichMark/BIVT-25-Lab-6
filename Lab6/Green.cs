using System;

namespace Lab6
{
    public delegate void Sorting(int[,] matrix);
    public delegate void Action(int[] array);
    public class Green
    {
        //1
        public void DeleteMaxElement(ref int[] array)
        {
            if (array == null || array.Length == 0)
            {
                array = new int[0];
                return;
            }
            int maxIndex = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > array[maxIndex])
                    maxIndex = i;
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
            if (A == null && B == null) return new int[0];
            if (A == null) return (int[])B.Clone();
            if (B == null) return (int[])A.Clone();
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
        public void Task1(ref int[] A, ref int[] B)
        {

            // code here
            if (A == null || B == null) return;
            DeleteMaxElement(ref A);
            DeleteMaxElement(ref B);
            A = CombineArrays(A, B);
            // end

        }
        //2
        public int FindMaxInRow(int[,] matrix, int row, out int col)
        {
            int max = int.MinValue; col = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > max)
                {
                    max = matrix[row, j];
                    col = j;
                }
            }
            return max;
        }
        public void Task2(int[,] matrix, int[] array)
        {

            // code here

            if (array.Length == 0 || matrix.GetLength(0) != array.Length) { return; }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int maxCol;
                int maxValue = FindMaxInRow(matrix, i, out maxCol);
                if (maxValue < array[i])
                {
                    matrix[i, maxCol] = array[i];
                }
            }
            // end

        }
        //3
        public void FindMax(int[,] matrix, out int row, out int col)
        {
            row = -1;
            col = -1;
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
                return;
            int max = int.MinValue;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }

        }
        public void SwapColWithDiagonal(int[,] matrix, int col)
        {
            if (matrix == null || col < 0 || col >= matrix.GetLength(1)) return;
            int size = Math.Min(matrix.GetLength(0), matrix.GetLength(1));
            for (int i = 0; i < size; i++)
            {
                (matrix[i, i], matrix[i, col]) = (matrix[i, col], matrix[i, i]);
            }
        }
        public void Task3(int[,] matrix)
        {

            // code here
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1))
                return;
            FindMax(matrix, out int row, out int col);
            if (row != -1 && col != -1)
            {
                SwapColWithDiagonal(matrix, col);
            }
            // end
        }
        //4
        public void RemoveRow(ref int[,] matrix, int row)
        {
            int n = matrix.GetLength(0); int m = matrix.GetLength(1);
            int[,] newMatrix = new int[n - 1, m];
            for (int i = 0, c = 0; i < n; i++)
            {
                if (i != row)
                {
                    for (int j = 0; j < m; j++)
                    {
                        newMatrix[c, j] = matrix[i, j];
                    }
                    c++;
                }
            }
            matrix = newMatrix;
        }
        public void Task4(ref int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0); int m = matrix.GetLength(1);
            for (int i = n - 1; i >= 0; i--)
            {
                int k = 0;
                for (int j = 0; j < m; j++)
                {
                    if ((matrix[i, j] == 0))
                    {
                        k = 1;
                        break;
                    }
                }
                if (k == 1) { RemoveRow(ref matrix, i); }
            }
            //end
        }
        //5
        public int[] GetRowsMinElements(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0) return new int[0];
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows != cols) return new int[0];
            int[] result = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                int min = int.MaxValue;
                for (int j = i; j < cols; j++)
                {
                    if (matrix[i, j] < min)
                        min = matrix[i, j];
                }
                result[i] = min;
            }
            return result;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here

            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                answer = GetRowsMinElements(matrix);
            }
            // end

            return answer;
        }
        //6
        public int[] SumPositiveElementsInColumns(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0) return new int[0];
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] sums = new int[cols];
            for (int j = 0; j < cols; j++)
            {
                int sum = 0;
                bool positive = false;
                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        positive = true;
                    }
                }
                sums[j] = positive ? sum : 0;
            }
            return sums;
        }
        //combinearrrays есть в методе 1
        public int[] Task6(int[,] A, int[,] B)
        {
            // code here
            int[] sumsA = SumPositiveElementsInColumns(A);
            int[] sumsB = SumPositiveElementsInColumns(B);
            int[] answer = CombineArrays(sumsA, sumsB);
            return answer;
            // end
        }
        //7
        public void SortEndAscending(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                int maxIndex = 0;
                int maxValue = int.MinValue;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxIndex = j;
                    }
                }
                if (maxIndex < m - 1)
                {
                    int a = m - maxIndex - 1;
                    int[] subArray = new int[a];
                    for (int k = 0; k < a; k++)
                    {
                        subArray[k] = matrix[i, maxIndex + 1 + k];
                    }
                    Array.Sort(subArray);
                    for (int k = 0; k < a; k++)
                    {
                        matrix[i, maxIndex + 1 + k] = subArray[k];
                    }
                }
            }
        }
        public void SortEndDescending(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                int maxIndex = 0;
                int maxValue = int.MinValue;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxIndex = j;
                    }
                }
                if (maxIndex < m - 1)
                {
                    int a = m - maxIndex - 1;
                    int[] subArray = new int[a];
                    for (int k = 0; k < a; k++)
                    {
                        subArray[k] = matrix[i, maxIndex + 1 + k];
                    }
                    Array.Sort(subArray);
                    Array.Reverse(subArray);
                    for (int k = 0; k < a; k++)
                    {
                        matrix[i, maxIndex + 1 + k] = subArray[k];
                    }
                }
            }
        }
        public delegate void Sorting(int[,] matrix);
        public void Task7(int[,] matrix, Sorting sort)
        {

            // code here
            if (matrix == null || sort == null) return;
            sort(matrix);
            // end

        }
        //8 
        public double GeronArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0 || a + b <= c ||
                b + c <= a || a + c <= b) return 0;
            double p = (a + b + c) / 2;
            double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return area;
        }
        public int Task8(double[] A, double[] B)
        {
            int answer = 0;

            // code here
            double Sa = GeronArea(A[0], A[1], A[2]);
            double Sb = GeronArea(B[0], B[1], B[2]);
            if (Sa > Sb)
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
        //9
        public delegate void Action(int[] array);
        public void SortMatrixRow(int[,] matrix, int row, Action<int[]> sorter)
        {
            int n = matrix.GetLength(1);
            int[] res = new int[n];
            for (int j = 0; j < n; j++)
            {
                res[j] = matrix[row, j];
            }
            sorter(res);
            ReplaceRow(matrix, row, res);
        }
        public void ReplaceRow(int[,] matrix, int row, int[] array)
        {
            for (int j = 0; j < array.Length; j++)
            {
                matrix[row, j] = array[j];
            }
        }
        public void SortAscending(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
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
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] < array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
        }
        public void Task9(int[,] matrix, Action<int[]> sorter)
        {

            // code here
            if (matrix == null) return;
            int rows = matrix.GetLength(0);
            for (int i = 0; i < rows; i += 2)
            {
                SortMatrixRow(matrix, i, sorter);
            }
            // end
        }
        public double CountZeroSum(int[][] array)
        {
            return array.Count(subArray => subArray.Sum() == 0);
        }
        public double FindMedian(int[][] array)
        {
            var allElements = array.SelectMany(x => x).ToArray();
            if (allElements.Length == 0)
                return 0;
            var sortedElements = allElements.OrderBy(x => x).ToArray();
            int n = sortedElements.Length;
            if (n%2 !=0)
            {
                return sortedElements[n / 2];
            }
            else
            {
                int middle1 = sortedElements[n / 2 - 1];
                int middle2 = sortedElements[n / 2];
                return (middle1 + middle2) / 2.0;
            }
        }
        public double CountLargeElements(int[][] array)
        {
            double totalCount = 0;
            foreach (var subArray in array)
            {
                if (subArray.Length == 0)
                    continue;
                double avg= subArray.Average();
                totalCount += subArray.Count(x => x > avg);
            }
            return totalCount;
        }
        public double Task10(int[][] array, Func<int[][], double> func)
        {
            double res = 0;

            // code here
            res = func(array);
            // end

            return res;
        }
    }
}
