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
            if (matrix == null || array == null)
                return;

            int rows = matrix.GetLength(0);

            if (rows != array.Length)
                return;

            for (int i = 0; i < rows; i++)
            {
                int maxCol;
                int max = FindMaxInRow(matrix, i, out maxCol);

                if (max < array[i])
                {
                    matrix[i, maxCol] = array[i];
                }
            }

            // end

        }

        public void Task3(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return;

            int row, col;
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
                    if (matrix[i, j] == 0)
                    {
                        hasZero = true;
                        break;
                    }

                if (hasZero)
                    RemoveRow(ref matrix, i);
            }
            // end

        }

        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return answer;

            answer = GetRowsMinElements(matrix);
            // end

            return answer;
        }

        public int[] Task6(int[,] A, int[,] B)
        {
            int[] answer = null;

            // code here
            answer = CombineArrays(SumPositiveElementsInColumns(A), SumPositiveElementsInColumns(B));
            // end

            return answer;
        }

        public delegate void Sorting(int[,] array);

        public void Task7(int[,] matrix, Sorting sort)
        {

            // code here
            if (matrix == null || sort == null)
                return;

            sort(matrix);
            // end

        }

        public int Task8(double[] A, double[] B)
        {
            if (A.Length != 3 || B.Length != 3)
                return 0;

            double areaA = GeronArea(A[0], A[1], A[2]);
            double areaB = GeronArea(B[0], B[1], B[2]);

            
            if (areaA > areaB) return 1;
            if (areaB >= areaA) return 2;

            return 0;
        }

        public void Task9(int[,] matrix, Action<int[]> sorter)
        {

            // code here
            if (matrix == null || sorter == null)
                return;

            int rows = matrix.GetLength(0);

            for (int i = 0; i < rows; i += 2)
            {
                SortMatrixRow(matrix, i, sorter);
            }
            // end

        }

        public double Task10(int[][] array, Func<int[][], double> func)
        {

            // code here
            if (array == null || func == null)
                return 0;

            return func(array);
            // end

        }



        public void DeleteMaxElement(ref int[] array)
        {
            if (array == null || array.Length == 0)
                return;

            int max = array.Max();
            int maxindex = Array.IndexOf(array, max);
            array = array
                .Where((x, i) => i != maxindex)
                .ToArray();
        }

        public int[] CombineArrays(int[] A, int[] B)
        {
            int[] C = new int[A.Length + B.Length];
            int j = 0;

            for (int i = 0; i < A.Length; i++)
            {
                C[j] = A[i];
                j++;
            }

            for (int i = 0; i < B.Length; i++)
            {
                C[j] = B[i];
                j++;
            }

            return C;
        }

        public int FindMaxInRow(int[,] matrix, int row, out int col)
        {
            int cols = matrix.GetLength(1);

            int max = matrix[row, 0];
            col = 0;

            for (int j = 1; j < cols; j++)
            {
                if (matrix[row, j] > max)
                {
                    max = matrix[row, j];
                    col = j;
                }
            }

            return max;
        }

        public void FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;
            int max = matrix[0, 0];

            for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
                if (max < matrix[i, j])
                {
                    row = i;
                    col = j;
                    max = matrix[i, j];
                }


        }

        public void SwapColWithDiagonal(int[,] matrix, int col)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                (matrix[i, col], matrix[i, i]) = (matrix[i, i], matrix[i, col]);
            }
        }

        public void RemoveRow(ref int[,] matrix, int row)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[,] newMatrix = new int[rows - 1, cols];
            int k = 0;
            for (int i = 0; i < rows; i++)
            {
                if (i == row)
                {
                    continue;
                }

                for (int j = 0; j < cols; j++)
                {
                    newMatrix[k, j] = matrix[i, j];
                }

                k++;
            }

            matrix = newMatrix;
        }

        public int[] GetRowsMinElements(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] resp = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                int min = matrix[i, i];
                for (int j = i; j < cols; j++)
                {
                    if (min > matrix[i, j])
                    {
                        min = matrix[i, j];
                    }
                }

                resp[i] = min;
            }

            return resp;
        }

        public int[] SumPositiveElementsInColumns(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] ans = new int[cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        ans[j] += matrix[i, j];
                    }
                }
            }

            return ans;
        }

        public void SortEndAscending(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int maxindex = 0;
                int max = matrix[i, 0];

                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxindex = j;
                    }
                }

                int len = matrix.GetLength(1) - (maxindex + 1);
                if (len > 0)
                {
                    int[] tail = new int[len];
                    for (int j = 0; j < len; j++)
                        tail[j] = matrix[i, maxindex + 1 + j];

                    tail = Sort(tail); 

                    for (int j = 0; j < len; j++)
                        matrix[i, maxindex + 1 + j] = tail[j];
                }
            }
        }
        public void SortEndDescending(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int maxindex = 0;
                int max = matrix[i, 0];

                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxindex = j;
                    }
                }

                int len = matrix.GetLength(1) - (maxindex + 1);
                if (len > 0)
                {
                    int[] tail = new int[len];
                    for (int j = 0; j < len; j++)
                        tail[j] = matrix[i, maxindex + 1 + j];

                    tail = Sortrev(tail); 

                    for (int j = 0; j < len; j++)
                        matrix[i, maxindex + 1 + j] = tail[j];
                }
            }
            
        }

        public int[] Sort(int[] array)
        {
            return array.OrderBy(x => x).ToArray();
        }
        public int[] Sortrev(int[] array)
        {
            return array.OrderByDescending(x => x).ToArray();
        }


        public double GeronArea(double a, double b, double c)
        {
            if (a + b <= c || a + c <= b || b + c <= a)
                return 0;

            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

         public void SortMatrixRow(int[,] matrix, int row, Action<int[]> sorter)
        {
            if (matrix == null || sorter == null)
                return;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (row < 0 || row >= rows)
                return;

            int[] temp = new int[cols];
            for (int j = 0; j < cols; j++)
                temp[j] = matrix[row, j];

            sorter(temp);                
            ReplaceRow(matrix, row, temp); 
        }

        public void ReplaceRow(int[,] matrix, int row, int[] array)
        {
            if (matrix == null || array == null)
                return;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (row < 0 || row >= rows)
                return;

            int len = Math.Min(cols, array.Length);
            for (int j = 0; j < len; j++)
                matrix[row, j] = array[j];
        }

        public void SortAscending(int[] array)
        {
            if (array == null)
                return;

            Array.Sort(array);
        }

        public void SortDescending(int[] array)
        {
            if (array == null)
                return;

            Array.Sort(array);
            Array.Reverse(array);
        }


        public double CountZeroSum(int[][] array)
        {
            if (array == null)
                return 0;

            int count = 0;
            foreach (var row in array)
            {
                if (row == null)
                    continue;

                if (row.Sum() == 0)
                    count++;
            }

            return count;
        }

        public double FindMedian(int[][] array)
        {
            if (array == null)
                return 0;

            List<int> list = new List<int>();
            foreach (var row in array)
            {
                if (row != null)
                    list.AddRange(row);
            }

            if (list.Count == 0)
                return 0;

            list.Sort();
            int n = list.Count;
            if (n % 2 == 1)
                return list[n / 2];

            return (list[n / 2 - 1] + list[n / 2]) / 2.0;
        }

        public double CountLargeElements(int[][] array)
        {
            if (array == null)
                return 0;

            int count = 0;

            foreach (var row in array)
            {
                if (row == null || row.Length == 0)
                    continue;

                double avg = row.Average();
                foreach (var x in row)
                {
                    if (x > avg)
                        count++;
                }
            }

            return count;
        }
    }
    
}
