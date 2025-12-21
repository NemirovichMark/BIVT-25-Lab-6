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
            if (array == null || array.Length == 0)
            {
                return;
            }

            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }

            int indexToRemove = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == max)
                {
                    indexToRemove = i;
                    break;
                }
            }

            int[] newArray = new int[array.Length - 1];
            for (int i = 0; i < indexToRemove; i++)
            {
                newArray[i] = array[i];
            }
            for (int i = indexToRemove; i < newArray.Length; i++)
            {
                newArray[i] = array[i + 1];
            }

            array = newArray;
        }

        public int[] CombineArrays(int[] A, int[] B)
        {
            if (A == null && B == null)
            {
                return new int[0];
            }

            if (A == null)
            {
                int[] result = new int[B.Length];
                for (int i = 0; i < B.Length; i++)
                {
                    result[i] = B[i];
                }
                return result;
            }

            if (B == null)
            {
                int[] result = new int[A.Length];
                for (int i = 0; i < A.Length; i++)
                {
                    result[i] = A[i];
                }
                return result;
            }
            int[] resultArray = new int[A.Length + B.Length];

            for (int i = 0; i < A.Length; i++)
            {
                resultArray[i] = A[i];
            }
            for (int i = 0; i < B.Length; i++)
            {
                resultArray[A.Length + i] = B[i];
            }

            return resultArray;
        }
        /////////////////////////////////////////////////

        public int FindMaxInRow(int[,] matrix, int row, out int col)
        {
            col = 0;

            if (matrix == null || row < 0 || row >= matrix.GetLength(0) || matrix.GetLength(1) == 0)
            {
                return 0;
            }

            int max = matrix[row, 0];
            col = 0;

            for (int j = 1; j < matrix.GetLength(1); j++)
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
            if (matrix == null || array == null)
            {
                return;
            }

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows != array.Length)
            {
                return;
            }

            for (int i = 0; i < rows; i++)
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
        ////////////////////////////////////////////////////////////////

        public void FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;

            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
            {
                row = -1;
                col = -1;
                return;
            }

            int max = matrix[0, 0];
            row = 0;
            col = 0;

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
            if (matrix == null || col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }

            int n = matrix.GetLength(0);

            for (int i = 0; i < n; i++)
            {
                if (i < matrix.GetLength(1))
                {
                    int temp = matrix[i, col];
                    matrix[i, col] = matrix[i, i];
                    matrix[i, i] = temp;
                }
            }
        }

        public void Task3(int[,] matrix)
        {
            // code here
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }
            int row, col;
            FindMax(matrix, out row, out col);
            if (row == -1 || col == -1)
            {
                return;
            }
            SwapColWithDiagonal(matrix, col);
            // end
        }

        /////////////////////////////////////////
        public void RemoveRow(ref int[,] matrix, int row)
        {
            if (matrix == null || row < 0 || row >= matrix.GetLength(0))
            {
                return;
            }

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows == 1)
            {
                matrix = new int[0, cols];
                return;
            }

            int[,] newMatrix = new int[rows - 1, cols];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    newMatrix[i, j] = matrix[i, j];
                }
            }
            for (int i = row + 1; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    newMatrix[i - 1, j] = matrix[i, j];
                }
            }

            matrix = newMatrix;
        }

        public void Task4(ref int[,] matrix)
        {
            // code here
            if (matrix == null)
            {
                return;
            }

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = rows - 1; i >= 0; i--)
            {
                bool hasZero = false;

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
        ////////////////////////////////////////////////

        public int[] GetRowsMinElements(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1))
            {
                return null;
            }

            int n = matrix.GetLength(0);
            int[] result = new int[n];

            for (int i = 0; i < n; i++)
            {
                int min = matrix[i, i];
                for (int j = i; j < n; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                    }
                }

                result[i] = min;
            }

            return result;
        }

        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            answer = GetRowsMinElements(matrix);

            // end
            return answer;
        }
        /////////////////////////////////////

        public int[] SumPositiveElementsInColumns(int[,] matrix)
        {
            if (matrix == null)
            {
                return new int[0];
            }

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] sums = new int[cols];

            for (int j = 0; j < cols; j++)
            {
                int columnSum = 0;
                bool hasPositive = false;

                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] > 0)
                    {
                        columnSum += matrix[i, j];
                        hasPositive = true;
                    }
                }

                if (hasPositive)
                {
                    sums[j] = columnSum;
                }
                else
                {
                    sums[j] = 0;
                }
            }

            return sums;
        }

        public int[] Task6(int[,] A, int[,] B)
        {
            int[] answer = null;

            // code here

            int[] sumsA = SumPositiveElementsInColumns(A);
            int[] sumsB = SumPositiveElementsInColumns(B);

            answer = CombineArrays(sumsA, sumsB);

            // end
            return answer;
        }
        ////////////////////////////////////////////////
        public delegate void Sorting(int[] array);
        public void SortEndAscending(int[] array)
        {
            if (array == null || array.Length <= 1) return;

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
        public void SortEndDescending(int[] array)
        {
            if (array == null || array.Length <= 1) return;

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] < array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
        public void Task7(int[,] matrix, Sorting sorter)
        {
            if (matrix == null || sorter == null) return;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int maxIndex = 0;
                int maxValue = matrix[i, 0];

                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxIndex = j;
                    }
                }
                if (maxIndex < cols - 1)
                {
                    int subArrayLength = cols - maxIndex - 1;
                    int[] subArray = new int[subArrayLength];
                    for (int j = 0; j < subArrayLength; j++)
                    {
                        subArray[j] = matrix[i, maxIndex + 1 + j];
                    }
                    sorter(subArray);
                    for (int j = 0; j < subArrayLength; j++)
                    {
                        matrix[i, maxIndex + 1 + j] = subArray[j];
                    }
                }
            }
        }
        //////////////////////////////////////////////////////////
        public double GeronArea(double a, double b, double c)
        {
            if (a + b <= c || a + c <= b || b + c <= a)
                return 0;

            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public int Task8(double[] A, double[] B)
        {
            double areaA = GeronArea(A[0], A[1], A[2]);
            double areaB = GeronArea(B[0], B[1], B[2]);

            if (areaA > areaB)
                return 1;
            else
                return 2;
        }

        //////////////////////////////////////////////////

        public void Task9(int[,] matrix, Action<int[]> sorter)
        {
            int rows = matrix.GetLength(0);

            for (int i = 0; i < rows; i++)
            {
                if (i % 2 == 0) // чётные строки (0, 2, 4, ...)
                {
                    SortMatrixRow(matrix, i, sorter);
                }
            }
        }

        public void SortMatrixRow(int[,] matrix, int row, Action<int[]> sorter)
        {
            int cols = matrix.GetLength(1);
            int[] temp = new int[cols];

            for (int j = 0; j < cols; j++)
            {
                temp[j] = matrix[row, j];
            }

            sorter(temp);

            ReplaceRow(matrix, row, temp);
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
            Array.Sort(array);
        }

        public void SortDescending(int[] array)
        {
            Array.Sort(array);
            Array.Reverse(array);
        }
        ////////////////////////////////////////////////////////////
        public double Task10(int[][] array, Func<int[][], double> func)
        {
            return func(array);
        }

        // a. количество скомпенсированных массивов (сумма элементов = 0)
        public double CountZeroSum(int[][] array)
        {
            int count = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum += array[i][j];
                }

                if (sum == 0)
                    count++;
            }

            return count;
        }

        // b. медиана среди всех элементов всех массивов
        public double FindMedian(int[][] array)
        {
            List<int> all = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    all.Add(array[i][j]);
                }
            }

            all.Sort();

            int n = all.Count;

            if (n % 2 == 1)
            {
                return all[n / 2];
            }
            else
            {
                return (all[n / 2 - 1] + all[n / 2]) / 2.0;
            }
        }

        // c. количество элементов, превышающих среднее значение своего массива
        public double CountLargeElements(int[][] array)
        {
            int count = 0;

            for (int i = 0; i < array.Length; i++)
            {
                double sum = 0;

                for (int j = 0; j < array[i].Length; j++)
                {
                    sum += array[i][j];
                }

                double avg = sum / array[i].Length;

                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] > avg)
                        count++;
                }
            }

            return count;
        }

        //    public double Task10(int[][] array, Func<int[][], double> func)
        //    {
        //        double res = 0;

        //        // code here

        //        // end

        //        return res;
        //    }
    }
}