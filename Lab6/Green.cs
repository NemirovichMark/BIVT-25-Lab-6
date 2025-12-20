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
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > array[maxIndex])
                {
                    maxIndex = i;
                }
            }
        
            int[] newArray = new int[array.Length - 1];
            int newIndex = 0;
        
            for (int i = 0; i < array.Length; i++)
            {
                if (i != maxIndex)
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
            int maxValue = int.MinValue;
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
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }
            FindMax(matrix, out int row, out int col);
            int colMax = col;
            SwapColWithDiagonal(matrix, colMax);
            // end
        }
        
        public void FindMax(int[,] matrix, out int row, out int col)
        {
            int maxValue = int.MinValue;
            int rowMax = 0;
            int colMax = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
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

        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;
        
            // code here
            answer = GetRowsMinElements(matrix);
            // end
        
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
                int min = matrix[i, i];
                for (int j = i + 1; j < matrix.GetLength(1); j++)
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

        public int[] Task6(int[,] A, int[,] B)
        {
            int[] answer = null;
        
            // code here
            int[] c = SumPositiveElementsInColumns(A);
            int[] d = SumPositiveElementsInColumns(B);
            // end
            answer = CombineArrays(c, d);
            return answer;
        }
        
        public int[] SumPositiveElementsInColumns(int[,] matrix)
        {
            if (matrix == null) return null;
            int[] array = new int[matrix.GetLength(1)];
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int rowSum = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    if (matrix[row, col] > 0)
                    { 
                        rowSum += matrix[row, col];
                    }
                }
                array[col] = rowSum;
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
                int maxIndex = 0;
                int maxValue = matrix[i, 0];
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxIndex = j;
                    }
                }
        
                if (maxIndex < matrix.GetLength(1) - 1)
                {
                    for (int k = maxIndex + 1; k < matrix.GetLength(1); k++)
                    {
                        for (int l = maxIndex + 1; l < matrix.GetLength(1) - 1; l++)
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
                int maxIndex = 0;
                int maxValue = matrix[i, 0];
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxIndex = j;
                    }
                }
        
                if (maxIndex < matrix.GetLength(1) - 1)
                {
                    for (int k = maxIndex + 1; k < matrix.GetLength(1); k++)
                    {
                        for (int l = maxIndex + 1; l < matrix.GetLength(1) - 1; l++)
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
                if (i % 2 == 0)
                {
                    SortMatrixRow(matrix, i, sorter);
                }
            }
        }
        
        public void SortMatrixRow(int[,] matrix, int row, Action<int[]> sorter)
        {
            int[] rowArray = new int[matrix.GetLength(1)];
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                rowArray[col] = matrix[row, col];
            }
        
            sorter(rowArray);
            ReplaceRow(matrix, row, rowArray);
        }
        
        public void ReplaceRow(int[,] matrix, int row, int[] array)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = array[col];
            }
        }
        
        public void SortDescending(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
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
        
        public void SortAscending(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
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
        
        public delegate void Sort();
        
        public double Task10(int[][] array, Func<int[][], double> func)
        {
            double res = 0;
            res = func(array);
            return res;
        }

        public double CountZeroSum(int[][] array)
        {
            int zeroSumArrays = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (SumArray(array[i]) == 0)
                {
                    zeroSumArrays++;
                }
            }

            return zeroSumArrays;
        }

        public static int SumArray(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public double FindMedian(int[][] array)
        {
            int totalElements = 0;
            for (int i = 0; i < array.Length; i++)
            {
                totalElements += array[i].Length;
            }

            int[] arrayAll = new int[totalElements];
            int index = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    arrayAll[index] = array[i][j];
                    index++;
                }
            }

            SortAscending(arrayAll);

            double med;
            if (arrayAll.Length % 2 != 0)
            {
                med = arrayAll[arrayAll.Length / 2];
            }
            else
            {
                int middleIndex = arrayAll.Length / 2;
                double center1 = arrayAll[middleIndex - 1];
                double center2 = arrayAll[middleIndex];
                med = (center1 + center2) / 2.0;
            }

            return med;
        }

        public double CountLargeElements(int[][] array)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Length == 0) continue;
                double avg = (double)SumArray(array[i]) / array[i].Length;
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] > avg)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
        
        public delegate double Func(int[][] array);
    }
}

