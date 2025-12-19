namespace Lab6
{
    public class Purple
    {
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int size = matrix.GetLength(0);
            if (size != matrix.GetLength(1)) return -1;
            
            int maxIndex = 0;
            for (int i = 1; i < size; i++)
            {
                if (matrix[i, i] > matrix[maxIndex, maxIndex])
                {
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        public void SwapRowColumn(int[,] A, int row, int[,] B, int col)
        {
            int size = A.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                int temp = A[row, i];
                A[row, i] = B[i, col];
                B[i, col] = temp;
            }
        }

        public void Task1(int[,] A, int[,] B)
        {
            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            int rowsB = B.GetLength(0);
            int colsB = B.GetLength(1);
            
            if (rowsA == colsA && rowsB == colsB && rowsA == rowsB)
            {
                int rowIdx = FindDiagonalMaxIndex(A);
                int colIdx = FindDiagonalMaxIndex(B);
                SwapRowColumn(A, rowIdx, B, colIdx);
            }
        }

        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int count = 0;
            int cols = matrix.GetLength(1);
            for (int j = 0; j < cols; j++)
            {
                if (matrix[row, j] > 0) count++;
            }
            return count;
        }

        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {
            int count = 0;
            int rows = matrix.GetLength(0);
            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, col] > 0) count++;
            }
            return count;
        }

        public void InsertColumn(ref int[,] A, int rowIdx, int colIdx, int[,] B)
        {
            int rows = A.GetLength(0);
            int cols = A.GetLength(1);
            int[,] newMatrix = new int[rows + 1, cols];
            
            for (int i = 0; i <= rowIdx; i++)
                for (int j = 0; j < cols; j++)
                    newMatrix[i, j] = A[i, j];
            
            for (int j = 0; j < cols; j++)
                newMatrix[rowIdx + 1, j] = B[j, colIdx];
            
            for (int i = rowIdx + 1; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    newMatrix[i + 1, j] = A[i, j];
            
            A = newMatrix;
        }

        public void Task2(ref int[,] A, int[,] B)
        {
            int rA = A.GetLength(0), cA = A.GetLength(1);
            int rB = B.GetLength(0), cB = B.GetLength(1);
            
            if (cA != rB) return;
            
            int bestRow = 0, maxRow = CountPositiveElementsInRow(A, 0);
            for (int i = 1; i < rA; i++)
            {
                int cur = CountPositiveElementsInRow(A, i);
                if (cur > maxRow) { maxRow = cur; bestRow = i; }
            }
            
            int bestCol = 0, maxCol = CountPositiveElementsInColumn(B, 0);
            for (int j = 1; j < cB; j++)
            {
                int cur = CountPositiveElementsInColumn(B, j);
                if (cur > maxCol) { maxCol = cur; bestCol = j; }
            }
            
            if (maxCol > 0) InsertColumn(ref A, bestRow, bestCol, B);
        }

        public void ChangeMatrixValues(int[,] matrix)
        {
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            int total = rows * cols;

            if (total <= 5)
            {
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        matrix[i, j] *= 2;
                return;
            }

            int[] topValues = new int[5];
            int[] topRows = new int[5];
            int[] topCols = new int[5];
            
            for (int k = 0; k < 5; k++)
            {
                topValues[k] = int.MinValue;
            }
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int value = matrix[i, j];
                    
                    for (int k = 0; k < 5; k++)
                    {
                        if (value > topValues[k])
                        {
                            for (int m = 4; m > k; m--)
                            {
                                topValues[m] = topValues[m - 1];
                                topRows[m] = topRows[m - 1];
                                topCols[m] = topCols[m - 1];
                            }
                            topValues[k] = value;
                            topRows[k] = i;
                            topCols[k] = j;
                            break;
                        }
                    }
                }
            }
            
            bool[,] isTopFive = new bool[rows, cols];
            for (int k = 0; k < 5; k++)
            {
                isTopFive[topRows[k], topCols[k]] = true;
            }
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (isTopFive[i, j])
                    {
                        matrix[i, j] *= 2; 
                    }
                    else
                    {
                        matrix[i, j] /= 2; 
                    }
                }
            }
        }

        public void Task3(int[,] matrix)
        {
            ChangeMatrixValues(matrix);
        }

        public int[] CountNegativesPerRow(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int[] counts = new int[rows];
            
            for (int i = 0; i < rows; i++)
            {
                int cnt = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] < 0) cnt++;
                counts[i] = cnt;
            }
            return counts;
        }

        public int FindMaxIndex(int[] array)
        {
            if (array.Length == 0) return -1;
            int maxIdx = 0;
            for (int i = 1; i < array.Length; i++)
                if (array[i] > array[maxIdx]) maxIdx = i;
            return maxIdx;
        }

        public void Task4(int[,] A, int[,] B)
        {
            if (A.GetLength(1) != B.GetLength(1)) return;
            
            int[] negA = CountNegativesPerRow(A);
            int[] negB = CountNegativesPerRow(B);
            
            int idxA = FindMaxIndex(negA);
            int idxB = FindMaxIndex(negB);
            
            if (negA[idxA] == 0 || negB[idxB] == 0) return;
            
            for (int j = 0; j < A.GetLength(1); j++)
            {
                int temp = A[idxA, j];
                A[idxA, j] = B[idxB, j];
                B[idxB, j] = temp;
            }
        }

        public void SortNegativeAscending(int[] array)
        {
            int n = array.Length;
            
            int negCount = 0;
            for (int i = 0; i < n; i++)
            {
                if (array[i] < 0) negCount++;
            }
            
            int[] negatives = new int[negCount];
            int[] positions = new int[negCount];
            int index = 0;
            
            for (int i = 0; i < n; i++)
            {
                if (array[i] < 0)
                {
                    negatives[index] = array[i];
                    positions[index] = i;
                    index++;
                }
            }
            
            for (int i = 0; i < negCount - 1; i++)
            {
                for (int j = 0; j < negCount - 1 - i; j++)
                {
                    if (negatives[j] > negatives[j + 1])
                    {
                        int temp = negatives[j];
                        negatives[j] = negatives[j + 1];
                        negatives[j + 1] = temp;
                    }
                }
            }
            
            for (int i = 0; i < negCount; i++)
            {
                array[positions[i]] = negatives[i];
            }
        }

        public void SortNegativeDescending(int[] array)
        {
            int n = array.Length;
            
            int negCount = 0;
            for (int i = 0; i < n; i++)
            {
                if (array[i] < 0) negCount++;
            }
            
            int[] negatives = new int[negCount];
            int[] positions = new int[negCount];
            int index = 0;
            
            for (int i = 0; i < n; i++)
            {
                if (array[i] < 0)
                {
                    negatives[index] = array[i];
                    positions[index] = i;
                    index++;
                }
            }
            
            for (int i = 0; i < negCount - 1; i++)
            {
                for (int j = 0; j < negCount - 1 - i; j++)
                {
                    if (negatives[j] < negatives[j + 1])
                    {
                        int temp = negatives[j];
                        negatives[j] = negatives[j + 1];
                        negatives[j + 1] = temp;
                    }
                }
            }
            
            for (int i = 0; i < negCount; i++)
            {
                array[positions[i]] = negatives[i];
            }
        }

        public delegate void Sorting(int[] array);
        
        public void Task5(int[] array, Sorting sort)
        {
            sort(array);
        }

        public int GetRowMax(int[,] matrix, int row)
        {
            int max = matrix[row, 0];
            for (int j = 1; j < matrix.GetLength(1); j++)
                if (matrix[row, j] > max) max = matrix[row, j];
            return max;
        }

        public void SortRowsByMaxAscending(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            int[] maxValues = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                maxValues[i] = GetRowMax(matrix, i);
            }
            
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < rows - 1 - i; j++)
                {
                    if (maxValues[j] > maxValues[j + 1])
                    {
                        int tempMax = maxValues[j];
                        maxValues[j] = maxValues[j + 1];
                        maxValues[j + 1] = tempMax;
                        
                        for (int k = 0; k < cols; k++)
                        {
                            int temp = matrix[j, k];
                            matrix[j, k] = matrix[j + 1, k];
                            matrix[j + 1, k] = temp;
                        }
                    }
                }
            }
        }

        public void SortRowsByMaxDescending(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            int[] maxValues = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                maxValues[i] = GetRowMax(matrix, i);
            }
            
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < rows - 1 - i; j++)
                {
                    if (maxValues[j] < maxValues[j + 1])
                    {
                        int tempMax = maxValues[j];
                        maxValues[j] = maxValues[j + 1];
                        maxValues[j + 1] = tempMax;
                        
                        for (int k = 0; k < cols; k++)
                        {
                            int temp = matrix[j, k];
                            matrix[j, k] = matrix[j + 1, k];
                            matrix[j + 1, k] = temp;
                        }
                    }
                }
            }
        }

        public delegate void SortRowsByMax(int[,] matrix);
        
        public void Task6(int[,] matrix, SortRowsByMax sort)
        {
            sort(matrix);
        }

        public int[] FindNegativeCountPerRow(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int[] counts = new int[rows];
            
            for (int i = 0; i < rows; i++)
            {
                int cnt = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] < 0) cnt++;
                counts[i] = cnt;
            }
            return counts;
        }

        public int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            int cols = matrix.GetLength(1);
            int[] maxNegs = new int[cols];
            
            for (int j = 0; j < cols; j++)
            {
                int max = 0;
                bool found = false;
                
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] < 0)
                    {
                        if (!found || matrix[i, j] > max)
                        {
                            max = matrix[i, j];
                            found = true;
                        }
                    }
                }
                
                maxNegs[j] = found ? max : 0;
            }
            return maxNegs;
        }

        public delegate int[] FindNegatives(int[,] matrix);
        
        public int[] Task7(int[,] matrix, FindNegatives find)
        {
            return find(matrix);
        }

        public int[,] DefineSeq(int[,] matrix)
        {
            bool inc = true, dec = true;
            
            for (int i = 0; i < matrix.GetLength(1) - 1; i++)
            {
                if (matrix[1, i] < matrix[1, i + 1]) dec = false;
                if (matrix[1, i] > matrix[1, i + 1]) inc = false;
            }
            
            if (inc && dec) return new int[0, 0];
            if (inc) return new int[,] { { 1 } };
            if (dec) return new int[,] { { -1 } };
            return new int[,] { { 0 } };
        }

        public int[,] FindAllSeq(int[,] matrix)
        {
            if (matrix.GetLength(1) == 1) return new int[0, 0];
            int flag, prevFlag;
            flag = 1;
            if (matrix[1, 0] > matrix[1, 1]) flag = -1;
            prevFlag = flag;
            
            int n = 1;
            for (int i = 0; i < matrix.GetLength(1) - 1; i++)
            {
                if (matrix[1, i] < matrix[1, i + 1]) flag = 1;
                if (matrix[1, i] > matrix[1, i + 1]) flag = -1;

                if (prevFlag != flag) n++;
                prevFlag = flag;
            }

            int[,] result = new int[n, 2];
            n = 0;
            int count = 0;
            flag = 1;
            if (matrix[1, 0] > matrix[1, 1]) flag = -1;
            prevFlag = flag;
            
            for (int i = 0; i < matrix.GetLength(1) - 1; i++)
            {
                if (matrix[1, i] < matrix[1, i + 1]) flag = 1;
                if (matrix[1, i] > matrix[1, i + 1]) flag = -1;

                if (prevFlag != flag)
                {
                    result[n, 0] = matrix[0, i - count];
                    result[n, 1] = matrix[0, i];
                    n++;
                    count = 0;
                }
                prevFlag = flag;
                count++;
            }
            
            result[n, 0] = matrix[0, matrix.GetLength(1) - 1 - count];
            result[n, 1] = matrix[0, matrix.GetLength(1) - 1];
            
            return result;
        }

        public int[,] FindLongestSeq(int[,] matrix)
        {
            if (matrix.GetLength(1) == 1) return new int[0, 0];
            int flag, prevFlag;
            flag = 1;
            if (matrix[1, 0] > matrix[1, 1]) flag = -1;
            prevFlag = flag;

            int[,] result = new int[1, 2];
            int count = 0, maxcount = 0;
            
            for (int i = 0; i < matrix.GetLength(1) - 1; i++)
            {
                if (matrix[1, i] < matrix[1, i + 1]) flag = 1;
                if (matrix[1, i] > matrix[1, i + 1]) flag = -1;

                if (prevFlag != flag)
                {
                    if (Math.Abs(matrix[0, i - count] - matrix[0, i]) > maxcount)
                    {
                        result[0, 0] = matrix[0, i - count];
                        result[0, 1] = matrix[0, i];
                        maxcount = Math.Abs(matrix[0, i - count] - matrix[0, i]);
                    }
                    count = 0;
                }
                prevFlag = flag;
                count++;
            }
            
            if (Math.Abs(matrix[0, matrix.GetLength(1) - 1 - count] - matrix[0, matrix.GetLength(1) - 1]) > maxcount)
            {
                result[0, 0] = matrix[0, matrix.GetLength(1) - 1 - count];
                result[0, 1] = matrix[0, matrix.GetLength(1) - 1];
            }
            
            return result;
        }

        public delegate int[,] MathInfo(int[,] matrix);
        
        public int[,] Task8(int[,] matrix, MathInfo info)
        {
            return info(matrix);
        }

        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
        {
            double prev = func(a);
            int count = 0;
            
            for (double x = a + h; x <= b + 1e-9; x += h)
            {
                double curr = func(x);
                if ((prev >= 0 && curr < 0) || (prev <= 0 && curr > 0))
                    count++;
                prev = curr;
            }
            
            return count;
        }

        public double FuncA(double x)
        {
            return x * x - Math.Sin(x);
        }

        public double FuncB(double x)
        {
            return Math.Exp(x) - 1;
        }

        public int Task9(double a, double b, double h, Func<double, double> func)
        {
            return CountSignFlips(a, b, h, func);
        }

        public void SortInCheckersOrder(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 == 0)
                {
                    for (int k = 0; k < array[i].Length - 1; k++)
                    {
                        for (int l = 0; l < array[i].Length - 1 - k; l++)
                        {
                            if (array[i][l] > array[i][l + 1])
                            {
                                int temp = array[i][l];
                                array[i][l] = array[i][l + 1];
                                array[i][l + 1] = temp;
                            }
                        }
                    }
                }
                else
                {
                    for (int k = 0; k < array[i].Length - 1; k++)
                    {
                        for (int l = 0; l < array[i].Length - 1 - k; l++)
                        {
                            if (array[i][l] < array[i][l + 1])
                            {
                                int temp = array[i][l];
                                array[i][l] = array[i][l + 1];
                                array[i][l + 1] = temp;
                            }
                        }
                    }
                }
            }
        }

        public void SortBySumDesc(int[][] array)
        {
            int[] sums = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum += array[i][j];
                }
                sums[i] = sum;
            }
            
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (sums[j] < sums[j + 1])
                    {
                        int tempSum = sums[j];
                        sums[j] = sums[j + 1];
                        sums[j + 1] = tempSum;
                        
                        int[] tempArray = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tempArray;
                    }
                }
            }
        }

        public void TotalReverse(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int length = array[i].Length;
                for (int j = 0; j < length / 2; j++)
                {
                    int temp = array[i][j];
                    array[i][j] = array[i][length - 1 - j];
                    array[i][length - 1 - j] = temp;
                }
            }
            
            for (int i = 0; i < array.Length / 2; i++)
            {
                int[] temp = array[i];
                array[i] = array[array.Length - 1 - i];
                array[array.Length - 1 - i] = temp;
            }
        }

        public void Task10(int[][] array, Action<int[][]> func)
        {
            func(array);
        }
    }
}