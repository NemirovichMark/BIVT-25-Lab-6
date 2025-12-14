using System.Linq;
using System.Runtime.InteropServices;

namespace Lab6
{
    public delegate void Sorting(int[,] matrix);
    // public delegate void Finder();
    // public delegate void SortRowsStyle();
    // public delegate void FindNegatives();
    // public delegate void MathInfo();
    // public delegate void SortRowsByMax();
    // public delegate void BikeRide();
    // public delegate void ReplaceMaxElements();
    // public delegate void GetTriangle();


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
            int[] newArray = new int[array.Length-1]; 
            
            int maxElement = array[0];
            int indexMaxElement = 0;
            
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > maxElement)
                {
                    maxElement = array[i];
                    indexMaxElement = i;
                }
            }

            for (int i = 0; i < indexMaxElement; i++)
            {
                newArray[i] = array[i];
            }

            for (int i = indexMaxElement; i < newArray.Length; i++)
            {
                newArray[i] = array[i + 1];
            }
            
            array = newArray;
        }

        public int[] CombineArrays(int[] A, int[] B)
        {
            int[] result = new int [A.Length + B.Length];

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

            // code here
            int rows = matrix.GetLength(0);
            
            if (array.Length == 0)
                return;
            
            if (rows != array.Length)
                return;
            
            for (int i = 0; i < rows; i++)
            {
                int maxValue = FindMaxInRow(matrix, i, out int col);
                if (maxValue < array[i])
                {
                    matrix[i, col] = array[i];
                }
            }
            // end

        }

        public int FindMaxInRow(int[,] matrix, int row, out int col)
        {
            int cols = matrix.GetLength(1);
            
            int maxElement = matrix[row, 0];
            col = 0;
            
            for (int j = 0; j < cols; j++)
            {
                if (matrix[row, j] > maxElement)
                {
                    maxElement = matrix[row, j];
                    col = j;
                }
            }
            
            return maxElement;
        }

        public void Task3(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            if (rows != cols)
                return;
            
            FindMax(matrix, out int row, out int col);
            SwapColWithDiagonal(matrix, col);
            
            // end

        }

        public void FindMax(int[,] matrix, out int row, out int col)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int maxElement = matrix[0, 0];

            row = 0;
            col = 0;
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > maxElement)
                    {
                        maxElement = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
        }

        public void SwapColWithDiagonal(int[,] matrix, int col)
        {
            int rows = matrix.GetLength(0);
            
            for (int i = 0; i < rows; i++)
            {
                if (i == col)
                    continue;
                
                int temp = matrix[i, i];
                matrix[i, i] = matrix[i, col];
                matrix[i,col] = temp;
            }
        }

        public void Task4(ref int[,] matrix)
        {

            // code here
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
                    RemoveRow(ref matrix, i);
            }

            // end

        }

        public void RemoveRow(ref int[,] matrix, int row)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[,] result = new int[rows - 1, cols];
            
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = matrix[i, j];
                }
            }

            for (int i = row+1; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i-1, j] = matrix[i, j];
                }
            }
            
            matrix = result;
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

        public int[] Task6(int[,] A, int[,] B)
        {
            int[] answer = null;
        
            // code here
            int[] forA = SumPositiveElementsInColumns(A); 
            int[] forB = SumPositiveElementsInColumns(B);
            answer = CombineArrays(forA, forB);
            // end
        
            return answer;
        }
        
        public int[] SumPositiveElementsInColumns(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[] array = new int[cols];
            
            for (int j = 0; j < cols; j++)
            {
                int sum = 0;
                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] > 0)
                        sum += matrix[i, j];
                }
                array[j] = sum;
            }
            return array;

        }
        
        public void Task7(int[,] matrix, Sorting sort)
        {
        
            // code here
            sort?.Invoke(matrix);
            // end

        }
        
        public void SortEndAscending(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                int startValue = FindMaxInRow(matrix, row, out int col);
                for (int i = col+1; i < cols-1; i++)
                {
                    for (int j = col+1; j < cols-1; j++)
                    {
                        if (matrix[row, j] > matrix[row, j+1])
                        {
                            int temp = matrix[row, j+1];
                            matrix[row, j+1] = matrix[row, j];
                            matrix[row, j] = temp;
                        }
                    }
                }
            }
        }

        public void SortEndDescending(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                int startValue = FindMaxInRow(matrix, row, out int col);
                for (int i = col+1; i < cols-1; i++)
                {
                    for (int j = col+1; j < cols-1; j++)
                    {
                        if (matrix[row, j] < matrix[row, j+1])
                        {
                            int temp = matrix[row, j+1];
                            matrix[row, j+1] = matrix[row, j];
                            matrix[row, j] = temp;
                        }
                    }
                }
            }
        }
        public int Task8(double[] A, double[] B)
        {
            int answer = 0;
        
            // code here
            double sA = GeronArea(A[0], A[1], A[2]);
            double sB = GeronArea(B[0], B[1], B[2]);

            if (sA > sB)
                answer = 1;
            else
                answer = 2;
                
            // end
        
            return answer;
        }
        
        public double GeronArea(double a, double b, double c)
        {
            if(a+b<=c || a+c<=b || b+c<=a)
                return 0;

            double p = (a + b + c) / 2;

            double s = Math.Sqrt(p*(p - a)*(p - b)*(p - c));

            return s;
        }

        public void Task9(int[,] matrix, Action<int[]> sorter)
        {
        
            // code here
            int rows = matrix.GetLength(0);

            for (int i = 0; i < rows; i+=2)
            {
                SortMatrixRow(matrix, i, sorter);
            }
            // end
        
        }
        public void SortMatrixRow(int[,] matrix, int row, Action<int[]> sorter)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            int[] array = new int[cols];

            for (int j = 0; j < cols; j++)
            {
                array[j] = matrix[row, j];
            }
            sorter?.Invoke(array);
            ReplaceRow(matrix, row, array);
        }

        public void ReplaceRow(int[,] matrix, int row, int[] array)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int j = 0; j < cols; j++)
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
        
        public double Task10(int[][] array, Func<int[][], double> func)
        {
            double res = 0;
        
            // code here
            res = func.Invoke(array);
            // end
        
            return res;
        }
        
        public double CountZeroSum(int[][] array)
        {
            int count = 0;
            foreach (int[] row in array)
            {
                int sum = 0;
                foreach (int number in row)
                {
                    sum +=  number;
                }

                if (sum == 0)
                    count++;
            }
            return count;
        }

        public double FindMedian(int[][] array)
        {
            int count = 0;
            foreach (int[] row in array)
            {
                count += row.Length;
            }

            int[] aggregated = new int[count];
            
            int index = 0;
            
            foreach (int[] row in array)
            {
                foreach (int number in row)
                {
                    aggregated[index++] = number;
                }
            }

            Array.Sort(aggregated);
            
            if (aggregated.Length % 2 == 0)
            {
                int mid = aggregated.Length / 2;
                return (double)(aggregated[mid] + aggregated[mid - 1])/2;
            }
            return aggregated[aggregated.Length / 2];
        }

        public double CountLargeElements(int[][] array)
        {
            // int count = 0;
            // foreach (int[] row in array)
            // {
            //     int sum = 0;
            //     foreach (int number in row)
            //     {
            //         sum += number;
            //     }
            //     double average = (double)sum/row.Length;
            //     foreach (int number in row)
            //     {
            //         if (number > average)
            //             count++;
            //     }
            // }

            return array.Sum(row => row.Count(n => n > row.Average()));
        }

    }
}