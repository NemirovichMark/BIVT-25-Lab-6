using System.ComponentModel.DataAnnotations;
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
        public void Task2(int[,] matrix, int[] array)
        {

            // code here
            if (matrix.GetLength(0) != array.Length) return;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int col;
                if (FindMaxInRow(matrix, i, out col) < array[i])
                {
                    matrix[i, col] = array[i];
                }
            }

            // end

        }
        public void Task3(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }
            int col = 0;
            int row = 0;
            FindMax(matrix, out row, out col);
            SwapColWithDiagonal(matrix, col);

            // end

        }
        public void Task4(ref int[,] matrix)
        {

            // code here
            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                bool hasZero = false;
                for (int j = 0; j < matrix.GetLength(1); j++)
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
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return answer;
            return GetRowsMinElements(matrix);
            // end

            return answer;
        }
        public int[] Task6(int[,] A, int[,] B)
        {
            int[] answer = null;

            // code here
            int[] Aa = SumPositiveElementsInColumns(A); 
            int[] Bb = SumPositiveElementsInColumns(B);
            answer = CombineArrays(Aa, Bb);
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
            double SA = GeronArea(A[0], A[1], A[2]);
            double SB = GeronArea(B[0], B[1], B[2]);

            if (SA > SB) { answer = 1; }
            else { answer = 2; }
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
            int MaxElem = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > array[MaxElem])
                {
                    MaxElem = i;
                }
            }
            int[] Array2 = new int[array.Length - 1];
            Array.Copy(array, 0, Array2, 0, MaxElem);
            Array.Copy(array, MaxElem + 1, Array2, MaxElem, array.Length - MaxElem - 1);
            array = Array2;
        }
        public int[] CombineArrays(int[] A, int[] B)
        {
            int[] answer = new int[A.Length + B.Length];
            Array.Copy(A, 0, answer, 0, A.Length);
            Array.Copy(B, 0, answer, A.Length, B.Length);
            return answer;
        }
        public int FindMaxInRow(int[,] matrix, int row, out int col)
        {
            int[] arr = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                arr[i] = matrix[row, i];
            }
            col = 0;
            int maxel = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > arr[col])
                {
                    col = i;
                    maxel = arr[i];
                }
            }
            return maxel;
        }
        public void FindMax(int[,] matrix, out int row, out int col)
        {
            col = 0;
            row = 0;
            int Max = matrix[col, row];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > Max)
                    {
                        Max = matrix[i, j];
                        col = j;
                        row = i;
                    }
                }
            }
        }
        public void SwapColWithDiagonal(int[,] matrix, int col)
        {
            int[] column = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                column[i] = matrix[i, col];
            }
            int maxlen = int.Max(matrix.GetLength(0), matrix.GetLength(1));
            int[] diog = new int[maxlen];
            for (int i = 0; i < maxlen; i++)
            {
                diog[i] = matrix[i, i];
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, col] = diog[i];
            }
            for (int i = 0; i < maxlen; i++)
            {
                matrix[i, i] = column[i];
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
        
            int newRowIndex = 0;
        
            for (int i = 0; i < rows; i++)
            {
                if (i != row)  
                {
                    for (int j = 0; j < cols; j++)
                    {
                        newMatrix[newRowIndex, j] = matrix[i, j];
                    }
                    newRowIndex++;
                }
            }
            matrix = newMatrix;
        }
        public int[] GetRowsMinElements(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            
            int n = rows;
            
            int[] array = new int[n];
            
            for (int i = 0; i < n; i++)
            {
                int minElement = matrix[i, i]; 
                for (int j = i; j < n; j++)
                {
                    if (matrix[i, j] < minElement)
                        minElement = matrix[i, j];
                }
                array[i] = minElement;
            }
            
            return array;
        }
        public int[] SumPositiveElementsInColumns(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] answer = new int[m];
            for (int j = 0; j < m; j++)
            {
                int sum = 0;
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                    }
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
                            (matrix[i, k], matrix[i, k + 1]) = (matrix[i, k + 1], matrix[i, k]);
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
                            (matrix[i, k], matrix[i, k + 1]) = (matrix[i, k + 1], matrix[i, k]);
                        }
                    }
                }
            }
        }
        public double GeronArea(double a, double b, double c)
        {
            if (a + b <= c || a + c <= b || b + c <= a) { return 0; }

            double p = (a + b + c) / 2;
            double S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            return S;
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
            Array.Sort(array);
        }
        public void SortDescending(int[] array)
        {
            Array.Sort(array);
            array.Reverse();
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