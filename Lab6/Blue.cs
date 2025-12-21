namespace Lab6
{
    public delegate int Finder(int[,] matrix, out int row, out int col);
    public delegate void SortRowsStyle(int[,] matrix, int row);
    public delegate void ReplaceMaxElements(int[,] matrix, int row, int maxValue);
    public delegate int[] GetTriangle(int[,] matrix);
    public delegate void Sorting(double[] array);
    public delegate double BikeRide(double v, double a);

    public class Blue
    {
        public void Task1(ref int[,] matrix)
        {
            if(matrix.GetLength(0)!=matrix.GetLength(1))return;
            int rowIndex=FindDiagonalMaxIndex(matrix);
            RemoveRow(ref matrix, rowIndex);
        }

        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int max=int.MinValue;
            int maxIndex = 0;
            int n=matrix.GetLength(0);
            for(int i = 0; i < n; i++)
            {
                if (matrix[i, i] > max)
                {
                    max=matrix[i,i];
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        public void RemoveRow(ref int[,] matrix, int rowIndex)
        {
            int n=matrix.GetLength(0),m=matrix.GetLength(1);
            int[,] result=new int [n-1,m];
            for(int i = 0; i < rowIndex; i++)
            {

                for(int j = 0; j < m; j++)
                {
                    result[i,j]=matrix[i,j];
                }
            }

            for(int i = rowIndex+1; i < n; i++)
            {

                for(int j = 0; j < m; j++)
                {
                    result[i-1,j]=matrix[i,j];
                }
            }
            matrix = result;
        }

       public void RemoveColumn(ref int[,] matrix, int colToRemove)
{
    int rows = matrix.GetLength(0);
    int cols = matrix.GetLength(1);
    if (cols <= 1 || colToRemove < 0 || colToRemove >= cols) 
    {
        matrix = new int[rows, 0]; // пустая матрица
        return;
    }

    int[,] newMatrix = new int[rows, cols - 1];
    for (int i = 0; i < rows; i++)
    {
        int newJ = 0;
        for (int j = 0; j < cols; j++)
        {
            if (j == colToRemove) continue;
            newMatrix[i, newJ++] = matrix[i, j];
        }
    }
    matrix = newMatrix;
}

        public int FindUpperColIndex(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1)) return -1;
            int n = matrix.GetLength(0);
            int max = int.MinValue, resCol = -1;
            for (int i = 0; i < n; i++)
                for (int j = i + 1; j < n; j++)
                    if (matrix[i, j] > max) { max = matrix[i, j]; resCol = j; }
            return resCol;
        }

        public int FindLowerColIndex(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1)) return -1;
            int n = matrix.GetLength(0);
            int max = int.MinValue, resCol = -1;
            for (int i = 0; i < n; i++)
                for (int j = 0; j <= i; j++)
                    if (matrix[i, j] > max) { max = matrix[i, j]; resCol = j; }
            return resCol;
        }

        public double GetAverageExceptEdges(int[,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int totalElements = n * m;
            double totalSum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    totalSum += matrix[i, j];
                }
            }
            if (totalElements <= 2) return totalSum / totalElements;

            int min = int.MaxValue, max = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int val = matrix[i, j];
                    if (val < min) min = val;
                    if (val > max) max = val;
                }
            }

            double sum = 0;
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int val = matrix[i, j];
                    if (val != min && val != max)
                    {
                        sum += val;
                        count++;
                    }
                }
            }

            return count == 0 ? 0 : sum / count;
        }

        public int Task2(int[,] A, int[,] B, int[,] C)
        {
            int answer = 0; 

            double[] averages = new double[3];
            averages[0] = GetAverageExceptEdges(A);
            averages[1] = GetAverageExceptEdges(B);
            averages[2] = GetAverageExceptEdges(C);

            if (averages[0] < averages[1] && averages[1] < averages[2]) answer = 1;
            else if (averages[0] > averages[1] && averages[1] > averages[2]) answer = -1;
            else answer = 0;

            return answer;
        }

        public int FindMax(int[,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int max = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
            }
            return max;
        }

        public int FindMin(int[,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int min = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                    }
                }
            }
            return min;
        }

        public int FindMax(int[,] matrix, out int row, out int col)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int max = int.MinValue;
            row = -1;
            col = -1;
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
            return max;
        }

        public int FindMin(int[,] matrix, out int row, out int col)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int min = int.MaxValue;
            row = -1;
            col = -1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
            return min;
        }

        public void Task3(ref int[,] matrix, Func<int[,], int> method)
{
    if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1)) return;
    int col = method(matrix);
    if (col >= 0 && col < matrix.GetLength(1))
        RemoveColumn(ref matrix, col);
}

        public bool CheckZerosInColumn(int[,] matrix, int col)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] == 0) return true;
            }
            return false;
        }

        public void Task4(ref int[,] matrix)
        {
            int cols = matrix.GetLength(1);
            int[] toRemove = new int[cols];
            int removeCount = 0;
            for (int j = 0; j < cols; j++)
            {
                if (!CheckZerosInColumn(matrix, j)) toRemove[removeCount++] = j;
            }
            MyReverse(toRemove, 0, removeCount);
            for (int k = 0; k < removeCount; k++) RemoveColumn(ref matrix, toRemove[k]);
        }

        public void Task5(ref int[,] matrix, Finder find)
        {
            int val = find(matrix, out _, out _);
            int rows = matrix.GetLength(0);
            int[] toRemove = new int[rows];
            int removeCount = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == val)
                    {
                        toRemove[removeCount++] = i;
                        break;
                    }
                }
            }
            MySort(toRemove, 0, removeCount);
            MyReverse(toRemove, 0, removeCount);
            for (int k = 0; k < removeCount; k++) RemoveRow(ref matrix, toRemove[k]);
        }

        public void Task6(int[,] matrix, SortRowsStyle sort)
        {
            for (int i = 0; i < matrix.GetLength(0); i += 3)
            {
                sort(matrix, i);
            }
        }

        public void SortRowAscending(int[,] matrix, int row)
        {
            int cols = matrix.GetLength(1);
            int[] arr = new int[cols];
            for (int j = 0; j < cols; j++) arr[j] = matrix[row, j];
            MySort(arr);
            for (int j = 0; j < cols; j++) matrix[row, j] = arr[j];
        }

        public void SortRowDescending(int[,] matrix, int row)
        {
            int cols = matrix.GetLength(1);
            int[] arr = new int[cols];
            for (int j = 0; j < cols; j++) arr[j] = matrix[row, j];
            MySort(arr);
            MyReverse(arr, 0, cols);
            for (int j = 0; j < cols; j++) matrix[row, j] = arr[j];
        }

        public void Task7(int[,] matrix, ReplaceMaxElements transform)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = FindMaxInRow(matrix, i);
                transform(matrix, i, max);
            }
        }

        public int FindMaxInRow(int[,] matrix, int row)
        {
            int max = int.MinValue;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > max) max = matrix[row, j];
            }
            return max;
        }

        public void ReplaceByZero(int[,] matrix, int row, int maxValue)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] == maxValue) matrix[row, j] = 0;
            }
        }

        public void MultiplyByColumn(int[,] matrix, int row, int maxValue)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] == maxValue) matrix[row, j] = maxValue * (j + 1);
            }
        }

        public double[,] Task8(double a, double b, double h, Func<double, double> getSum, Func<double, double> getY)
        {
            int count = (int)Math.Round((b - a) / h) + 1;
            double[,] res = new double[count, 2];
            for (int i = 0; i < count; i++)
            {
                double x = a + i * h;
                res[i, 0] = getSum(x);
                res[i, 1] = getY(x);
            }
            return res;
        }

        public double SumA(double x)
        {
            double s = 1.0, fact = 1.0;
            for (int i = 1; i <= 20; i++) { fact *= i; s += Math.Cos(i * x) / fact; }
            return s;
        }

        public double YA(double x)
        {
            return Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
        }

        public double SumB(double x)
        {
            double S = -2.0 * Math.PI * Math.PI / 3.0, sign = 1, t = 1;

            for (int i = 1; Math.Abs(t) >= 0.000001; i++)
            {
                sign *= -1;
                t = sign * (Math.Cos(i * x) / (i * i));
                S += t;
            }

            return S;
        }

public double YB(double x) => (x * x - 3.0 * Math.PI * Math.PI) / 4.0;

        public int Task9(int[,] matrix, GetTriangle triangle)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1)) return 0;
            int[] arr = triangle(matrix);
            return Sum(arr);
        }

        public int Sum(int[] array)
        {
            int sum = 0;
            foreach (int val in array) sum += val * val;
            return sum;
        }

        private int MySum(int[] array)
        {
            int sum = 0;
            foreach (int val in array) sum += val;
            return sum;
        }

        private void MySort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        private void MySort(int[] arr, int start, int count)
        {
            for (int i = 0; i < count - 1; i++)
            {
                for (int j = start; j < start + count - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        private void MyReverse(int[] arr, int start, int count)
        {
            int end = start + count - 1;
            while (start < end)
            {
                int temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                start++;
                end--;
            }
        }

        public int[] GetUpperTriangle(int[,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int size = Math.Min(n, m);
            int numElements = size * (size + 1) / 2;
            int[] arr = new int[numElements];
            int index = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = i; j < size; j++)
                {
                    arr[index++] = matrix[i, j];
                }
            }
            return arr;
        }

        public int[] GetLowerTriangle(int[,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int size = Math.Min(n, m);
            int numElements = size * (size + 1) / 2;
            int[] arr = new int[numElements];
            int index = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    arr[index++] = matrix[i, j];
                }
            }
            return arr;
        }

        public bool Task10(int[][] array, Predicate<int[][]> func)
        {
            return func(array);
        }

        public bool CheckTransformAbility(int[][] array)
        {
            int count = 0;
            foreach (var a in array) count += a.Length;
            return count % array.Length == 0;
        }

        public bool CheckSumOrder(int[][] array)
        {
            if (array.Length < 2) return true;
            double[] sums = new double[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                sums[i] = MySum(array[i]);
            }
            bool increasing = true, decreasing = true;
            for (int i = 1; i < sums.Length; i++)
            {
                if (sums[i] <= sums[i - 1]) increasing = false;
                if (sums[i] >= sums[i - 1]) decreasing = false;
            }
            return increasing || decreasing;
        }

        public bool CheckArraysOrder(int[][] array)
{
    if (array == null) return false;
    foreach (var sub in array)
    {
        if (sub == null || sub.Length <= 1)
            return true; // пустой или один элемент — упорядочен

        bool asc = true, desc = true;
        for (int i = 1; i < sub.Length; i++)
        {
            if (sub[i] < sub[i - 1]) asc = false;
            if (sub[i] > sub[i - 1]) desc = false;
        }
        if (asc || desc)
            return true;
    }
    return false;
}
}
}
