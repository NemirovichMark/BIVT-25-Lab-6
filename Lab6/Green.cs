using System.Linq;
using System.Runtime.InteropServices;

namespace Lab6
{
    public class Green
    {
        public void DeleteMaxElement(ref int[] array)
        {
            if (array == null || array.Length == 0)
            {
                return;
            }

            int maxElemIdx = 0;
            int maxElem = array[maxElemIdx];
            for (int i = 0; i < array.Length; ++i)
            {
                if (array[i] > maxElem)
                {
                    maxElem = array[i];
                    maxElemIdx = i;
                }
            }
            int[] arrayWitoutMaxElement = new int[array.Length - 1];
            
            for (int i = 0; i < maxElemIdx; ++i)
            {
                arrayWitoutMaxElement[i] = array[i];
            }
            for (int i = maxElemIdx + 1; i < array.Length; ++i)
            {
                arrayWitoutMaxElement[i - 1] = array[i];
            }
            array = arrayWitoutMaxElement;
        }

        public int[] CombineArrays(int[] A, int[] B)
        {
            if (A == null)
            {
                A = new int[0];
            }
            if (B == null)
            {
                B = new int[0];
            }
        
            int[] combined = new int[A.Length + B.Length];
            
            for (int i = 0; i < A.Length; ++i)
            {
                combined[i] = A[i];
            }
            for (int i = 0; i < B.Length; ++i)
            {
                combined[A.Length + i] = B[i];
            }
            return combined;
        }
        public void Task1(ref int[] A, ref int[] B)
        {
            DeleteMaxElement(ref A);
            DeleteMaxElement(ref B);
            A = CombineArrays(A, B);
        }

        public int FindMaxInRow(int[,] matrix, int row, out int col)
        {
            col = 0;
            if (matrix == null || row < 0 || row >= matrix.GetLength(0))
            {
                return 0;
            }
            
            int maxElem = matrix[row, col];
            for (int i = 0; i < matrix.GetLength(1); ++i)
            {
                if (matrix[row, i] > maxElem)
                {
                    maxElem = matrix[row, i];
                    col = i;
                }
            }
            return maxElem;
        }
        public void Task2(int[,] matrix, int[] array)
        {
            if (array == null || array.Length == 0 || matrix == null || matrix.GetLength(0) != array.Length)
            {
                return;
            }
            int col;
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                if (FindMaxInRow(matrix, i, out col) < array[i])
                {
                    matrix[i, col] = array[i];
                }
            }
        }

        public void FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;
            int maxElem = matrix[row, col];
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    if (matrix[i, j] > maxElem)
                    {
                        maxElem = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
        }

        public void SwapColWithDiagonal(int[,] matrix, int col)
        {
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }
            int size = matrix.GetLength(0);
            
            for (int i = 0; i < size; ++i)
            {
                int temp = matrix[i, col];
                matrix[i, col] = matrix[i, i];
                matrix[i, i] = temp;
            }
        }
        
        public void Task3(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }

            int row, col;
            FindMax(matrix, out row, out col);
            SwapColWithDiagonal(matrix, col);
        }
        
        
        public void RemoveRow(ref int[,] matrix, int row)
        {
            if (matrix == null || row < 0 || row >= matrix.GetLength(0))
            {
                return;
            }
            int oldRows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            int[,] newMatrix = new int[oldRows - 1, cols];
            
            int newRow = 0;
            for (int i = 0; i < oldRows; ++i)
            {
                if (i == row)
                {
                    continue;
                }
                
                for (int j = 0; j < cols; ++j)
                {
                    newMatrix[newRow, j] = matrix[i, j];
                }
                newRow++;
            }
            
            matrix = newMatrix;
        }
        
        public void Task4(ref int[,] matrix)
        {
            if (matrix == null)
            {
                return;
            }
            
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            int i = 0;
            while (i < rows)
            {
                bool hasZero = false;
                for (int j = 0; j < cols; ++j)
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
                    rows = matrix.GetLength(0);
                }
                else
                {
                    i++;
                }
            }
        }

        public int[] GetRowsMinElements(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1))
            {
                return null;
            }
            int[] minElements = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                int minElement = matrix[i, i];
                for (int j = i; j < matrix.GetLength(1); ++j)
                {
                    if (matrix[i, j] < minElement)
                    {
                        minElement = matrix[i, j];
                    }
                }
                minElements[i] = minElement;
            }
            return minElements;
        }
        
        public int[] Task5(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1))
            {
                return null;
            }
            return GetRowsMinElements(matrix);
        }

        public int[] SumPositiveElementsInColumns(int[,] matrix)
        {
            if (matrix == null)
            {
                return new int[0];
            }
            int[] sumPositiveElements = new int[matrix.GetLength(1)];
            for (int j = 0; j < matrix.GetLength(1); ++j)
            {
                sumPositiveElements[j] = 0;
                for (int i = 0; i < matrix.GetLength(0); ++i)
                {
                    sumPositiveElements[j] += matrix[i, j] > 0 ? matrix[i, j] : 0;
                }
            }
            return sumPositiveElements;
        }
        
        public int[] Task6(int[,] A, int[,] B)
        {
            int[] aSums = SumPositiveElementsInColumns(A);
            int[] bSums = SumPositiveElementsInColumns(B);
            return CombineArrays(aSums, bSums);
        }

        private void SelectionSort(int[] array, bool ascending = true)
        {
            if (array == null)
            {
                return;
            }
            int n = array.Length;
        
            for (int i = 0; i < n - 1; ++i)
            {
                int targetIndex = i;
            
                for (int j = i + 1; j < n; ++j)
                {
                    if (ascending)
                    {
                        if (array[j] < array[targetIndex])
                        {
                            targetIndex = j;
                        }
                    }
                    else
                    {
                        if (array[j] > array[targetIndex])
                        {
                            targetIndex = j;
                        }
                    }
                }
            
                if (targetIndex != i)
                {
                    int temp = array[i];
                    array[i] = array[targetIndex];
                    array[targetIndex] = temp;
                }
            }
        }
        
        private int FindMaxIndexInRow(int[,] matrix, int row)
        {
            int maxIdx = 0;
            int cols = matrix.GetLength(1);
        
            for (int j = 1; j < cols; ++j)
            {
                if (matrix[row, j] > matrix[row, maxIdx])
                {
                    maxIdx = j;
                }
            }
        
            return maxIdx;
        }
        
        public void SortEndAscending(int[,] matrix)
        {
            if (matrix == null)
            {
                return;
            }
            
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            for (int i = 0; i < rows; ++i)
            {
                int maxIndex = FindMaxIndexInRow(matrix, i);
                
                if (maxIndex < cols - 1)
                {
                    int sortCount = cols - maxIndex - 1;
                    int[] subArray = new int[sortCount];
                    
                    for (int k = 0; k < sortCount; ++k)
                    {
                        subArray[k] = matrix[i, maxIndex + 1 + k];
                    }
                    
                    SelectionSort(subArray, true/*ascending*/);
                    
                    for (int k = 0; k < sortCount; ++k)
                    {
                        matrix[i, maxIndex + 1 + k] = subArray[k];
                    }
                }
            }
        }
        
        public void SortEndDescending(int[,] matrix)
        {
            if (matrix == null)
            {
                return;
            }
            
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            for (int i = 0; i < rows; i++)
            {
                int maxIndex = FindMaxIndexInRow(matrix, i);
                
                if (maxIndex < cols - 1)
                {
                    int sortCount = cols - maxIndex - 1;
                    int[] subArray = new int[sortCount];
                    
                    for (int k = 0; k < sortCount; ++k)
                    {
                        subArray[k] = matrix[i, maxIndex + 1 + k];
                    }
                    
                    SelectionSort(subArray, false/*ascending*/);
                    
                    for (int k = 0; k < sortCount; ++k)
                    {
                        matrix[i, maxIndex + 1 + k] = subArray[k];
                    }
                }
            }
        }
        
        public delegate void Sorting(int[,] matrix);
        public void Task7(int[,] matrix, Sorting sort)
        {
            if (matrix == null || sort == null)
            {
                return;
            }
            sort(matrix);
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

        public int Task8(double[] A, double[] B)
        {
            double areaA = GeronArea(A[0], A[1], A[2]);
            double areaB = GeronArea(B[0], B[1], B[2]);
            
            if (areaA > areaB)
            {
                return 1;
            }
            return 2;
        }

        public void SortMatrixRow(int[,] matrix, int row, Action<int[]> sorter)
        {
            if (matrix == null || sorter == null)
            {
                return;
            }
            int cols = matrix.GetLength(1);
            int[] rowArray = new int[cols];
            for (int col = 0; col < cols; ++col)
            {
                rowArray[col] = matrix[row, col];
            }
            sorter(rowArray);
            ReplaceRow(matrix, row, rowArray);
        }
        
        public void ReplaceRow(int[,] matrix, int row, int[] array)
        {
            if (matrix == null || array == null)
            {
                return;
            }
            int cols = matrix.GetLength(1);

            if (array.Length != cols || row < 0 || row >= matrix.GetLength(0))
            {
                return;
            }
            
            for (int j = 0; j < cols; ++j)
            {
                matrix[row, j] = array[j];
            }
        }

        public void SortAscending(int[] array)
        {
            SelectionSort(array, true/*ascending*/);
        }

        public void SortDescending(int[] array)
        {
            SelectionSort(array, false/*ascending*/);
        }
        
        public void Task9(int[,] matrix, Action<int[]> sorter)
        {
            if (matrix == null || sorter == null)
            {
                return;
            }

            for (int i = 0; i < matrix.GetLength(0); i += 2)
            {
                SortMatrixRow(matrix, i, sorter);
            }
        }
        
        public delegate double AnalyzeFunc(int[][] array);
        
        public double CountZeroSum(int[][] array)
        {
            if (array == null || array.Length == 0)
            {
                return 0;
            }
            int count = 0;
            for (int i = 0; i < array.Length; ++i)
            {
                if (array[i] == null || array[i].Length == 0)
                {
                    continue;
                }
                    
                int sum = 0;
                for (int j = 0; j < array[i].Length; ++j)
                {
                    sum += array[i][j];
                }

                count += sum == 0 ? 1 : 0;
            }
            return count;
        }
        
        public double FindMedian(int[][] array)
        {
            if (array == null || array.Length == 0)
            {
                return 0;
            }
            
            int totalElements = 0;
            for (int i = 0; i < array.Length; ++i)
            {
                if (array[i] != null)
                {
                    totalElements += array[i].Length;
                }
            }
            
            int[] allElements = new int[totalElements];

            int idx = 0;
            for (int i = 0; i < array.Length; ++i)
            {
                if (array[i] != null)
                {
                    for (int j = 0; j < array[i].Length; ++j)
                    {
                        allElements[idx++] = array[i][j];
                    }
                }
            }
            
            SelectionSort(allElements, true/*ascending*/);
            
            double median;
            if (totalElements % 2 == 1)
            {
                median = allElements[totalElements / 2];
            }
            else
            {
                double middle1 = allElements[totalElements / 2 - 1];
                double middle2 = allElements[totalElements / 2];
                median = (middle1 + middle2) / 2.0;
            }
            return median;
        }
        
        public double CountLargeElements(int[][] array)
        {
            if (array == null || array.Length == 0)
            {
                return 0;
            }
            
            int totalLargeElements = 0;
            for (int i = 0; i < array.Length; ++i)
            {
                if (array[i] == null || array[i].Length == 0)
                {
                    continue;
                }
                
                double sum = 0;
                for (int j = 0; j < array[i].Length; ++j)
                {
                    sum += array[i][j];
                }
                double average = sum / array[i].Length;
                int largeElementsInArr = 0;
                for (int j = 0; j < array[i].Length; ++j)
                {
                    largeElementsInArr += array[i][j] > average ? 1 : 0;
                }
                totalLargeElements += largeElementsInArr;
            }
            return totalLargeElements;
        }
    
        public double Task10(int[][] array, Func<int[][], double> func)
        {
            return func(array);
        }
    }
}