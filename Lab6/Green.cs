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
            if (array.Length == 0) return;
            int maxIndex = 0;
            int maxValue = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                    maxIndex = i;
                }
            }
            int[] newArray = new int[array.Length - 1];
            for (int i = 0; i < maxIndex; i++)
                newArray[i] = array[i];
            for (int i = maxIndex + 1; i < array.Length; i++)
                newArray[i - 1] = array[i];
            array = newArray;
        }

        public int[] CombineArrays(int[] A, int[] B)
        {
            int index = 0;
            int[] combinedArray = new int[A.Length + B.Length];
            for (int i = 0; i < combinedArray.Length; i++)
            {
                if (i < A.Length) combinedArray[i] = A[i];
                else
                {
                    combinedArray[i] = B[index];
                    index++;
                }
            }
            return combinedArray;
        }
        public void Task2(int[,] matrix, int[] array)
        {

            // code here
            if (array.Length == 0) return;
            if (matrix.GetLength(0) != array.Length) return;
            for (int row = 0; row < array.Length; row++)
            {
                int maxValue = FindMaxInRow(matrix, row, out int column);
                if (maxValue < array[row]) matrix[row, column] = array[row];
            }
            // end

        }
        public int FindMaxInRow(int[,] matrix, int row, out int col)
        {
            col = 0;
            int maxValue = matrix[row, 0];
            for (int column = 0; column < matrix.GetLength(1); column++)
            {
                if (matrix[row, column] > maxValue)
                {
                    maxValue = matrix[row, column];
                    col = column;
                }
            }
            return maxValue;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            FindMax(matrix, out int row, out int col);
            SwapColWithDiagonal(matrix, col);
            // end

        }

        public void FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int maxValue = matrix[0, 0];
            int maxRow = 0;
            int maxCol = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }
            row = maxRow;
            col = maxCol;
        }

        public void SwapColWithDiagonal(int[,] matrix, int col)
        {
            int size = matrix.GetLength(0);
            if (size != matrix.GetLength(1))
            {
                return;
            }
            for (int i = 0; i < size; i++)
            {
                (matrix[i, i], matrix[i, col]) = (matrix[i, col], matrix[i, i]);
            }
        }

        public void Task4(ref int[,] matrix)
        {

            // code here
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    if (matrix[row, column] == 0)
                    {
                        RemoveRow(ref matrix, row);
                        row--;
                        break;
                    }
                }
            }
            // end

        }

        public void RemoveRow(ref int[,] matrix, int row)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int[,] newMatrix = new int[rows - 1, columns];
            int newRow = 0;
            for (int i = 0; i < rows; i++)
            {
                if (i == row) continue;
                for (int j = 0; j < columns; j++)
                {
                    newMatrix[newRow, j] = matrix[i, j];
                }
                newRow++;
            }
            matrix = newMatrix;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] result = null;

            // code here
            result = GetRowsMinElements(matrix);
            // end

            return result;
        }

        public int[] GetRowsMinElements(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            if (rows != matrix.GetLength(1)) return null;
            int[] result = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                int minValue = matrix[i, i];
                for (int j = i; j < rows; j++)
                {
                    if (matrix[i, j] < minValue) minValue = matrix[i, j];
                }
                result[i] = minValue;
            }
            return result;
        }

        public int[] Task6(int[,] A, int[,] B)
        {
            int[] result = null;

            // code here
            int[] sumArrayA = SumPositiveElementsInColumns(A);
            int[] sumArrayB = SumPositiveElementsInColumns(B);
            result = CombineArrays(sumArrayA, sumArrayB);
            // end

            return result;
        }
        public int[] SumPositiveElementsInColumns(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int[] columnSums = new int[columns];
            for (int column = 0; column < columns; column++)
            {
                int sum = 0;
                for (int row = 0; row < rows; row++)
                {
                    if (matrix[row, column] > 0) sum += matrix[row, column];

                }
                columnSums[column] = sum;
            }
            return columnSums;
        }
        public delegate void Sorting(int[,] matrix);
        public void Task7(int[,] matrix, Sorting sort)
        {

            // code here
            sort(matrix);
            // end

        }

        public void SortEndAscending(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            for (int row = 0; row < rows; row++)
            {
                int maxValue = matrix[row, 0];
                int maxCol = 0;
                for (int column = 0; column < columns; column++)
                {
                    if (matrix[row, column] > maxValue)
                    {
                        maxValue = matrix[row, column];
                        maxCol = column;
                    }
                }
                if (maxCol == columns - 1) continue;
                for (int k = maxCol + 1; k < columns - 1; k++)
                {
                    for (int j = maxCol + 1; j < columns - 1; j++)
                    {
                        if (matrix[row, j] > matrix[row, j + 1]) 
                            (matrix[row, j], matrix[row, j + 1]) = (matrix[row, j + 1], matrix[row, j]);

                    }
                }
            }
        }
        public void SortEndDescending(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            for (int row = 0; row < rows; row++)
            {
                int maxValue = matrix[row, 0];
                int maxCol = 0;
                for (int column = 0; column < columns; column++)
                {
                    if (matrix[row, column] > maxValue)
                    {
                        maxValue = matrix[row, column];
                        maxCol = column;
                    }
                }
                if (maxCol == columns - 1) continue;
                for (int k = maxCol + 1; k < columns - 1; k++)
                {
                    for (int j = maxCol + 1; j < columns - 1; j++)
                    {
                        if (matrix[row, j] < matrix[row, j + 1]) 
                            (matrix[row, j], matrix[row, j + 1]) = (matrix[row, j + 1], matrix[row, j]);

                    }
                }
            }
        }
        public int Task8(double[] A, double[] B)
        {
            int result = 0;

            // code here
            double areaTriangleA = GeronArea(A[0], A[1], A[2]);
            double areaTriangleB = GeronArea(B[0], B[1], B[2]);
            if (areaTriangleA > areaTriangleB) return 1;
            else return 2;
            // end

            return result;
        }

        public double GeronArea(double a, double b, double c)
        {
            if (a + b < c || a + c < b || b + c < a)
            {
                return 0;
            }
            double semiPerimeter = (a + b + c) / 2;
            double area = Math.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));
            return area;
        }
        public void Task9(int[,] matrix, Action<int[]> sorter)
        {

            // code here
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0) SortMatrixRow(matrix, row, sorter);

            }
            // end

        }

        public void SortMatrixRow(int[,] matrix, int row, Action<int[]> sorter)
        {
            int columns = matrix.GetLength(1);
            int[] rowArray = new int[columns];
            for (int column = 0; column < columns; column++)
            {
                rowArray[column] = matrix[row, column];
            }
            sorter(rowArray);
            ReplaceRow(matrix, row, rowArray);
        }

        public void ReplaceRow(int[,] matrix, int row, int[] array)
        {
            for (int column = 0; column < matrix.GetLength(1); column++)
            {
                matrix[row, column] = array[column];
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
        public double Task10(int[][] array, Func<int[][], double> func)
        {
            double result = 0;

            // code here
            result = func(array);
            // end

            return result;
        }

        public double CountZeroSum(int[][] array)
        {
            double count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                double sum = 0;
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
            int totalElements = 0;
            for (int i = 0; i < array.Length; i++)
            {
                totalElements += array[i].Length;
            }

            int[] allElements = new int[totalElements];
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    allElements[index] = array[i][j];
                    index++;
                }
            }
            Array.Sort(allElements);
            double median;
            if (allElements.Length % 2 == 0)
            {
                median = (double)(allElements[totalElements / 2 - 1] + allElements[totalElements / 2]) / 2;
            }
            else
            {
                median = (double)allElements[totalElements / 2];
            }
            return median;
        }

        public double CountLargeElements(int[][] array)
        {
            double count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                double sum = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum += array[i][j];
                }
                double average = sum / array[i].Length;
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] > average)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

    }
}