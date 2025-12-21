using System;

namespace Lab6
{
    public class Purple
    {
        public void SortMatrixTwo(int[,] matrix)
        {
            int i = 1, j = 2;
            while (i < matrix.GetLength(1))
            {
                if(i == 0 || matrix[0, i - 1] > matrix[0, i])
                {
                    i = j;
                    j++;
                }
                else
                {
                    (matrix[0, i - 1], matrix[0, i]) = (matrix[0, i], matrix[0, i - 1]);
                    (matrix[1, i - 1], matrix[1, i]) = (matrix[1, i], matrix[1, i - 1]);
                    i--;
                }
            }
        }

        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int mx = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > matrix[mx, mx])
                    mx = i;
            }
            return mx;
        }

        public void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                (matrix[rowIndex, i], B[i, columnIndex]) = (B[i, columnIndex], matrix[rowIndex, i]);                
            }
        }

        public void Task1(int[,] A, int[,] B)
        {
            if (A == null || B == null || A.GetLength(0) != A.GetLength(1) || B.GetLength(0) != B.GetLength(1) || A.GetLength(0) != B.GetLength(0))
            {
                return;
            }
            int a = FindDiagonalMaxIndex(A), b = FindDiagonalMaxIndex(B);
            SwapRowColumn(A, a, B, b);
        }

        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B)
        {
            int[,] answer = new int[A.GetLength(0) + 1, A.GetLength(1)];
            for (int i = 0; i < A.GetLength(0) + 1; i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    if (i < rowIndex + 1)
                    {
                        answer[i, j] = A[i, j];
                    }
                    else if (i == rowIndex + 1)
                    {
                        answer[i, j] = B[j, columnIndex];
                    }
                    else
                    {
                        answer[i, j] = A[i - 1, j];
                    }
                }
            }
            A = answer;
        }

        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int cnt = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > 0) cnt++;
            }
            return cnt;
        }

        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {
            int cnt = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] > 0) cnt++;
            }
            return cnt;
        }

        public void Task2(ref int[,] A, int[,] B)
        {
            int mxa = 0, mxb = 0;
            if (A == null || B == null || A.GetLength(1) != B.GetLength(0))
            {
                return;
            }
            for(int i = 0; i < A.GetLength(0); i++)
            {
                if(CountPositiveElementsInRow(A, i) > CountPositiveElementsInRow(A, mxa))
                {
                    mxa = i;
                }
            }
            for(int i = 0; i < B.GetLength(1); i++)
            {
                if(CountPositiveElementsInColumn(B, i) > CountPositiveElementsInColumn(B, mxb))
                {
                    mxb = i;
                }
            }
            if (CountPositiveElementsInColumn(B, mxb) == 0)
            {
                return;
            }
            InsertColumn(ref A, mxa, mxb, B);
        }

        public void ChangeMatrixValues(int[,] matrix)
        {
            if (matrix == null) return;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int total = rows * cols;

            if (total < 5)
            {
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        matrix[i, j] *= 2;
                return;
            }

            int[,] top = new int[5, 3];
            for (int k = 0; k < 5; k++)
            {
                top[k, 0] = int.MinValue;
                top[k, 1] = -1;
                top[k, 2] = -1;
            }

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    int v = matrix[i, j];
                    for (int k = 0; k < 5; k++)
                        if (v > top[k, 0])
                        {
                            for (int t = 4; t > k; t--)
                            {
                                top[t, 0] = top[t - 1, 0];
                                top[t, 1] = top[t - 1, 1];
                                top[t, 2] = top[t - 1, 2];
                            }
                            top[k, 0] = v;
                            top[k, 1] = i;
                            top[k, 2] = j;
                            break;
                        }
                }

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    bool isTop = false;
                    for (int k = 0; k < 5; k++)
                        if (top[k, 1] == i && top[k, 2] == j)
                        {
                            isTop = true;
                            break;
                        }
                    if (isTop) matrix[i, j] *= 2;
                    else matrix[i, j] /= 2;
                }
        }

        public void Task3(int[,] matrix)
        {
            if (matrix == null)
            {
                return;
            }
            ChangeMatrixValues(matrix);
        }

        public int[] CountNegativesPerRow(int[,] matrix)
        {
            int[] answer = new int[matrix.GetLength(0)]; 
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0) answer[i]++;
                }
            }
            return answer;
        }

        public int FindMaxIndex(int[] array)
        {
            int mx = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > array[mx])
                {
                    mx = i;
                }
            }
            return mx;  
        }

        public void Task4(int[,] A, int[,] B)
        {
            if (A == null || B == null || A.GetLength(1) != B.GetLength(1))
            {
                return;
            }
            int a = FindMaxIndex(CountNegativesPerRow(A));
            int b = FindMaxIndex(CountNegativesPerRow(B));
            int cnta = 0, cntb = 0;
            for (int j = 0; j < A.GetLength(1); j++)
            {
                if (A[a, j] < 0) cnta++;
                if (B[b, j] < 0) cntb++;
            }
            if (cnta == 0 || cntb == 0)
            {
                return;
            }
            for (int j = 0; j < A.GetLength(1); j++)
            {
                (A[a, j], B[b, j]) = (B[b, j], A[a, j]);
            }
        }

        public void SortNegativeAscending(int[] matrix)
        {
            int negCount = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0) negCount++;
            }
            
            int[] negatives = new int[negCount];
            int index = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    negatives[index] = matrix[i];
                    index++;
                }
            }
            
            for (int i = 0; i < negatives.Length - 1; i++)
            {
                for (int j = 0; j < negatives.Length - i - 1; j++)
                {
                    if (negatives[j] > negatives[j + 1])
                    {
                        int temp = negatives[j];
                        negatives[j] = negatives[j + 1];
                        negatives[j + 1] = temp;
                    }
                }
            }
            
            index = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    matrix[i] = negatives[index];
                    index++;
                }
            }
        }

        public void SortNegativeDescending(int[] matrix)
        {
            int negCount = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0) negCount++;
            }
            
            int[] negatives = new int[negCount];
            int index = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    negatives[index] = matrix[i];
                    index++;
                }
            }
            
            for (int i = 0; i < negatives.Length - 1; i++)
            {
                for (int j = 0; j < negatives.Length - i - 1; j++)
                {
                    if (negatives[j] < negatives[j + 1])
                    {
                        int temp = negatives[j];
                        negatives[j] = negatives[j + 1];
                        negatives[j + 1] = temp;
                    }
                }
            }
            
            index = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    matrix[i] = negatives[index];
                    index++;
                }
            }
        }

        public delegate void Sorting(int[] matrix);

        public void Task5(int[] matrix, Sorting sort)
        {
            if (matrix == null)
            {
                return;
            }
            sort(matrix);
        }

        public int GetRowMax(int[,] matrix, int row)
        {
            int mx = matrix[row, 0];
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > mx) mx = matrix[row, j];
            }
            return mx;
        }

        public void SortRowsByMaxAscending(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            int[,] rowData = new int[rows, 2];
            for (int i = 0; i < rows; i++)
            {
                rowData[i, 0] = GetRowMax(matrix, i);
                rowData[i, 1] = i;
            }
            
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < rows - i - 1; j++)
                {
                    if (rowData[j, 0] > rowData[j + 1, 0])
                    {
                        int tempValue = rowData[j, 0];
                        int tempIndex = rowData[j, 1];
                        rowData[j, 0] = rowData[j + 1, 0];
                        rowData[j, 1] = rowData[j + 1, 1];
                        rowData[j + 1, 0] = tempValue;
                        rowData[j + 1, 1] = tempIndex;
                    }
                }
            }
            
            int[,] copy = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    copy[i, j] = matrix[i, j];
                }
            }
            
            for (int i = 0; i < rows; i++)
            {
                int sourceRow = rowData[i, 1];
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = copy[sourceRow, j];
                }
            }
        }

        public void SortRowsByMaxDescending(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            int[,] rowData = new int[rows, 2];
            for (int i = 0; i < rows; i++)
            {
                rowData[i, 0] = GetRowMax(matrix, i);
                rowData[i, 1] = i;
            }
            
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < rows - i - 1; j++)
                {
                    if (rowData[j, 0] < rowData[j + 1, 0])
                    {
                        int tempValue = rowData[j, 0];
                        int tempIndex = rowData[j, 1];
                        rowData[j, 0] = rowData[j + 1, 0];
                        rowData[j, 1] = rowData[j + 1, 1];
                        rowData[j + 1, 0] = tempValue;
                        rowData[j + 1, 1] = tempIndex;
                    }
                }
            }
            
            int[,] copy = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    copy[i, j] = matrix[i, j];
                }
            }
            
            for (int i = 0; i < rows; i++)
            {
                int sourceRow = rowData[i, 1];
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = copy[sourceRow, j];
                }
            }
        }

        public delegate void SortRowsByMax(int[,] matrix);

        public void Task6(int[,] matrix, SortRowsByMax sort)
        {
            if (matrix == null)
            {
                return;
            }
            sort(matrix);
        }

        public delegate int[] FindNegatives(int[,] matrix);

        public int[] FindNegativeCountPerRow(int[,] matrix)
        {
            int[] ret = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0) ret[i]++;
                }
            }
            return ret;
        }

        public int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            int[] ret = new int[matrix.GetLength(1)];
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int maxNeg = 0;
                bool hasNegative = false;
                
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] < 0)
                    {
                        if (!hasNegative)
                        {
                            maxNeg = matrix[i, j];
                            hasNegative = true;
                        }
                        else if (matrix[i, j] > maxNeg)
                        {
                            maxNeg = matrix[i, j];
                        }
                    }
                }
                
                ret[j] = hasNegative ? maxNeg : 0;
            }
            return ret;
        }

        public int[] Task7(int[,] matrix, FindNegatives find)
        {
            if (matrix == null)
            {
                return new int[0];
            }
            return find(matrix);
        }

        public int[,] DefineSeq(int[,] matrix)
        {
            int[,] ans = new int[1, 1] { { 0 } };
            bool up = true, down = true;
            for (int y = 1; y < matrix.GetLength(1); y++)
            {
                if (matrix[1, y] > matrix[1, y - 1])
                    down = false;
                else if (matrix[1, y] < matrix[1, y - 1])
                    up = false;
            }
            if (down)
                ans[0, 0] = -1;
            else if (up)
                ans[0, 0] = 1;
            return ans;
        }
        public int[,] FindAllSeq(int[,] matrix)
        {
            int sign = -1 * Math.Sign(matrix[1, 1] - matrix[1,0]);
            int len = 0;
            for (int y = 1; y<matrix.GetLength(1);y++)
            {
                if ((matrix[1, y] - matrix[1,y-1])*sign >= 0)
                {
                    continue;
                }
                else
                {
                    sign *= -1;
                    len += 1;
                }
            }
            int[,] ans = new int[len,2];
            sign = -1 * Math.Sign(matrix[1, 1] - matrix[1, 0]);
            len = 0;
            for (int y = 1; y < matrix.GetLength(1); y++)
            {
                if ((matrix[1, y] - matrix[1, y - 1]) * sign >= 0)
                {
                    continue;
                }
                else
                {
                    sign *= -1;
                    if (len  >0)
                    {
                        ans[len-1, 1] = matrix[0, y - 1];
                    }
                    ans[len, 0] = matrix[0, y - 1];
                    len++;
                }
            }
            ans[0, 0] = matrix[0, 0];
            ans[ans.GetLength(0) - 1, 1] = matrix[0, matrix.GetLength(1) - 1];
            return ans;
        }
        public int[,] FindLongestSeq(int[,] matrix)
        {
            int[,] ans = new int[1, 2];
            int maxlen = -1;
            int[,] a = FindAllSeq(matrix);
            for (int i = 0; i<a.GetLength(0);i++)
            {
                if (a[i, 1] - a[i,0]>maxlen)
                {
                    ans[0,0] = a[i, 0];
                    ans[0,1] = a[i, 1];
                    maxlen = a[i, 1] - a[i, 0];
                }
            }
            return ans;
        }

        public delegate int[,] MathInfo(int[,] matrix);

        public int[,] Task8(int[,] matrix, MathInfo info)
        {
            int[,] answer = null;

            // code here
            bool allsame = true;
            for (int i = 0; i< matrix.GetLength(1);i++)
            {
                if (matrix[1,i] != matrix[1,0])
                {
                    allsame = false; break;
                }
            }
            if (allsame)
                answer = new int[,] { };
            else
                answer = info(matrix);
            // end

            return answer;
        }

        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
        {
            if (h <= 0) return 0;
            if (a > b) (a, b) = (b, a);
            
            int count = 0;
            double prevValue = func(a);
            
            for (double x = a + h; x <= b + h/2; x += h)
            {
                double currentValue = func(x);
                
                if ((prevValue > 0 && currentValue < 0) || (prevValue < 0 && currentValue > 0))
                {
                    count++;
                }
                
                if (currentValue != 0)
                {
                    prevValue = currentValue;
                }
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
                if ((i + 1) % 2 == 0)
                {
                    SortDescending(array[i]);
                }
                else
                {
                    SortAscending(array[i]);
                }
            }
        }

        public void SortBySumDesc(int[][] array)
        {
            if (array == null || array.Length == 0) return;
            
            int[] sums = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    int sum = 0;
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        sum += array[i][j];
                    }
                    sums[i] = sum;
                }
            }
            
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
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

        public void Reversing(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n / 2; i++)
            {
                (arr[i], arr[n - 1 - i]) = (arr[n - 1 - i], arr[i]);
            }
        }

        public void TotalReverse(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    Reversing(array[i]);
                }
            }
            
            for (int i = 0; i < array.Length / 2; i++)
            {
                int[] temp = array[i];
                array[i] = array[array.Length - 1 - i];
                array[array.Length - 1 - i] = temp;
            }
        }

        public void SortDescending(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    }
                }
            }
        }

        public void SortAscending(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    }
                }
            }
        }

        public void Task10(int[][] array, Action<int[][]> func)
        {
            func(array);
        }
    }
}
