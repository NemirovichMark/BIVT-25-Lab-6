using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

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
            int MaxIndex = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > array[MaxIndex])
                {
                    MaxIndex = i;
                }
            }
            int[] newArray = new int[array.Length - 1];


            for (int i = 0, j = 0; i < array.Length; i++)
            {
                if (i != MaxIndex)
                {
                    newArray[j] = array[i];
                    j++;
                }
            }
            array = newArray;

        }
        public int[] CombineArrays(int[] A, int[] B)
        {
            int[] res = new int[A.Length + B.Length];
            Array.Copy(A, 0, res, 0, A.Length);
            Array.Copy(B, 0, res, A.Length, B.Length);
            return res;
        }


        public void Task2(int[,] matrix, int[] array)
        {


            // code here
            if (array.Length == 0 || matrix.GetLength(0) != array.Length)

            {

                return;
            }
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

        public int FindMaxInRow(int[,] matrix, int row, out int col)
        {
            int max = int.MinValue;
            col = 0;
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



        public void Task3(int[,] matrix)
        {
            // code here

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m)
            {
                return;
            }
            int row, col;
            FindMax(matrix, out row, out col);

            SwapColWithDiagonal(matrix, col);
            // end
        }

        public void FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;



            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int max = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
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


            int n = matrix.GetLength(0);



            for (int i = 0; i < n; i++)
            {
                int temp = matrix[i, i];
                matrix[i, i] = matrix[i, col];
                matrix[i, col] = temp;
            }

        }
        public void Task4(ref int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = n - 1; i >= 0; i--)
            {
                int k = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        k = 1;
                        break;
                    }
                }

                if (k == 1)
                {
                    RemoveRow(ref matrix, i);
                }
            }

            // end


        }
        public void RemoveRow(ref int[,] matrix, int row)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
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
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                answer= GetRowsMinElements(matrix);
            }
            // end
            return answer;
        }
        public int[] GetRowsMinElements(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] res = new int[n];
            for (int i = 0; i < n; i++)
            {
                int min = int.MaxValue;
                for (int j = i; j < m; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                    }
                }
                res[i] = min;
            }
            return res;
        }
        public int[] Task6(int[,] A, int[,] B)
        {
            int[] answer = null;

            // code here
            int[] resA = SumPositiveElementsInColumns(A);
            int[] resB = SumPositiveElementsInColumns(B);
            answer = CombineArrays(resA, resB);
            // end

            return answer;
        }
        public int[] SumPositiveElementsInColumns(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] res = new int[m];
            for (int j = 0; j < m; j++)
            {
                int c = 0;
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, j] > 0)
                    {
                        c += matrix[i, j];
                    }
                }
                res[j] = c;
            }
            return res;
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
        public int Task8(double[] A, double[] B)
        {
            int answer = 0;

            // code here

            double S1 = GeronArea(A[0], A[1], A[2]);
            double S2 = GeronArea(B[0], B[1], B[2]);
            if (S1 > S2)
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
            if (a <= 0 || b <= 0 || c <= 0 || a + b <= c || a + c <= b || b + c <= a)
            {
                return 0;
            }
            double p = (a + b + c) / 2;
            double geron = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return geron;
        }
        public void Task9(int[,] matrix, Action<int[]> sorter)
        {

            // code here

            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i += 2) 
            {
                SortMatrixRow(matrix, i, sorter);
            }
            // end

        }
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
            int k = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int s = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    s += array[i][j];
                }
                if (s == 0)
                {
                    k++;
                }
            }
            return k;
        }
        public double FindMedian(int[][] array)
        {
            int n = 0;
            for (int i = 0; i < array.Length; i++)
            {
                n += array[i].Length;
            }
            int[] result = new int[n];
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    result[index] = array[i][j];
                    index++;
                }
            }
            SortAscending(result);
            if (n % 2 == 1)
            {
                return result[n / 2];
            }
            else
            {
                int median1 = result[n / 2 - 1];
                int median2 = result[n / 2];
                return (median1 + median2) / 2.0;
            }
        }
        public double CountLargeElements(int[][] array)
        {
            int resultk = 0;
            for (int i = 0; i < array.Length; i++)
            {
                double s = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    s += array[i][j];
                }
                s /= array[i].Length;
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] > s)
                    {
                        resultk++;
                    }
                }
            }
            return resultk;
        }
       
    }
}
