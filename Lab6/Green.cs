using System.Linq;
using System.Runtime.InteropServices;

namespace Lab6
{
            public delegate void Sorting(int[] row);
    
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
            if (matrix == null || array == null) return;
            int rows= matrix.GetLength(0);
            int cols= matrix.GetLength(1);
            if (array.Length == 0 || rows != array.Length) return;
            for(int i = 0; i < array.Length; i++)
            {
                int max = FindMaxInRow(matrix, i, out int maxcol);
                if (max < array[i])
                    matrix[i, maxcol] = array[i];
            }
            // end

        }
        public void Task3(int[,] matrix)
        {

            // code here
            if (matrix == null) return;
            int rows= matrix.GetLength(0);
            int cols= matrix.GetLength(1);
            if (rows != cols) return;
            int row;
            int col;
            FindMax(matrix, out row, out col);
            SwapColWithDiagonal(matrix, col);
            // end

        }
        public void Task4(ref int[,] matrix)
        {

            // code here
            if (matrix == null) return;
            int rows= matrix.GetLength(0);
            for(int i=rows-1;i>=0;i--)
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
            if (A == null || B == null) return null;
            int[] sA = SumPositiveElementsInColumns(A);
            int[] sB = SumPositiveElementsInColumns(B);
            answer = CombineArrays(sA, sB);
            // end

            return answer;
        }
        public void Task7(int[,] matrix, Sorting sort)
        {

            // code here
            if (matrix == null || sort == null) return;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                int[] rowArr = new int[cols];
                for (int j = 0; j < cols; j++) rowArr[j] = matrix[i, j];
                sort(rowArr);
                for (int j = 0; j < cols; j++) matrix[i, j] = rowArr[j];
            }
            // end

        }
        public int Task8(double[] A, double[] B)
        {
            int answer = 0;

            // code here
            if (A.Length != 3 || B.Length != 3) return 0;
            double triangle1 = GeronArea(A[0], A[1], A[2]);
            double triangle2 = GeronArea(B[0], B[1], B[2]);
            if (triangle1 > triangle2) 
                answer = 1;
            else 
                answer = 2;
            // end

            return answer;
        }
        public void Task9(int[,] matrix, Action<int[]> sorter)
        {

            // code here
            if (matrix == null || sorter == null) return;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i += 2)
            {
                int[] row = new int[cols];
                for (int j = 0; j < cols; j++) row[j] = matrix[i, j];
                sorter(row);
                ReplaceRow(matrix, i, row);
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
            if (array == null) return;
            if (array.Length == 0) return;
            int max = array[0];
            int ind = 0;
            for (int i= 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max=array[i];
                    ind = i;
                }
            }
            int[] arr = new int[array.Length - 1];
            for(int i=0;i< arr.Length; i++)
            {
                if (i < ind)
                    arr[i] = array[i];
                else
                    arr[i] = array[i + 1];
            }
            array = arr;

        }
        public int[] CombineArrays(int[] A, int[] B)
        {
            if (A == null || B == null) return null;
            int[] rez=new int[A.Length+B.Length];
            for(int i = 0; i < rez.Length; i++)
            {
                if(i<A.Length)
                    rez[i]=A[i];
                else
                    rez[i]=B[i-A.Length];
            }
            return rez;
        }
        public int FindMaxInRow(int[,] matrix, int row, out int col)
        {
            int cols=matrix.GetLength(1);
            int max = matrix[row, 0];
            col = 0;
            for (int j = 1; j < cols; j++)
            {
                if (matrix[row, j] > max)
                {
                    col = j;
                    max = matrix[row, j];
                }
            }
            return max;
        }
        public void FindMax(int[,] matrix,out int row, out int col)
        {
            row = 0;
            col = 0;
            int rows=matrix.GetLength(0);
            int cols=matrix.GetLength(1);
            int max = matrix[0, 0];
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0;j< cols; j++)
                {
                    if(matrix[i, j] > max)
                    {
                        max=matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
        }
        public void SwapColWithDiagonal(int[,]matrix, int col)
        {
            int rows=matrix.GetLength (0);
            int cols=matrix.GetLength (1);
            if (rows != cols || col < 0 || col >= cols) return;
            for(int i = 0;i < rows; i++)
            {
                int temp = matrix[i, i];
                matrix[i, i] = matrix[i, col];
                matrix[i, col] = temp;
            }
        }
        public void RemoveRow(ref int[,] matrix, int row)
        {
            if (matrix == null) return;
            int rows=matrix.GetLength (0);
            int cols=matrix.GetLength (1);
            if (row < 0 || row >= rows) return;
            int[,] rez = new int[rows - 1, cols];
            for(int i = 0; i < rows-1; i++)
            {
                if (i < row)
                {
                    for(int j=0; j < cols; j++)
                    {
                        rez[i,j]= matrix[i, j];
                    }
                }
                else
                {
                    for(int j=0;j<cols;j++)
                        rez[i, j]= matrix[i+1, j];
                }
            }
            matrix = rez;
        }
        public int[] GetRowsMinElements(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows != cols) return null;
            int[] mins = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                int min = matrix[i, i];
                for (int j = i; j < cols; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                    }
                }
                mins[i] = min;
            }
            return mins;
        }
        public int[] SumPositiveElementsInColumns(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] res = new int[cols];
            for (int j = 0; j < cols; j++)
            {
                int s = 0;
                for (int i = 0; i < rows; i++) if (matrix[i, j] > 0) s += matrix[i, j];
                res[j] = s;
            }
            return res;
        }
        public void SortEndAscending(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                int maxIndex = 0;
                int max = matrix[i, 0];
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        maxIndex = j;
                        max = matrix[i, j];
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
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                int maxIndex = 0;
                int max = matrix[i, 0];
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        maxIndex = j;
                        max = matrix[i, j];
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
        public void ReplaceRow(int[,] matrix, int row, int[] array)
        {
            if (matrix == null || array == null) return;
            int cols = matrix.GetLength(1);
            if (row < 0 || row >= matrix.GetLength(0) || array.Length != cols) return;
            for (int j = 0; j < cols; j++) matrix[row, j] = array[j];
        }
        public void SortAscending(int[] arr)
        {
            if (arr == null) return;
            System.Array.Sort(arr);
        }
        public void SortDescending(int[] arr)
        {
            if (arr == null) return;
            System.Array.Sort(arr);
            System.Array.Reverse(arr);
        }
        public void SortMatrixRow(int[,] matrix, int row, Action<int[]> sorter)
        {
            if (matrix == null || sorter == null) return;
            if (row < 0 || row >= matrix.GetLength(0)) return;
            int cols = matrix.GetLength(1);
            int[] tmp = new int[cols];
            for (int j = 0; j < cols; j++) tmp[j] = matrix[row, j];
            sorter(tmp);
            for (int j = 0; j < cols; j++) matrix[row, j] = tmp[j];
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

