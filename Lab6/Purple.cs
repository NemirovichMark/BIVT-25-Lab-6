using System;
using System.Reflection;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public class Purple
    {
        public void Task1(int[,] A, int[,] B)
        {

            // code here
            int indexA, indexB;
            indexA = FindDiagonalMaxIndex(A);
            indexB = FindDiagonalMaxIndex(B);
            SwapRowColumn(A, indexA, B, indexB);
            // end

        }

        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int max = int.MinValue;
            int index = -1;
            for (int i = 0; i < matrix.GetLength(0);)
            {
                for (int j = 0; j < matrix.GetLength(1); i++, j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        index = i;
                    }
                }
            }
            return index;
        }

        public void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex)
        {
            if ((matrix.GetLength(0) == B.GetLength(0)) && (matrix.GetLength(1) == B.GetLength(1)) && (B.GetLength(0) == B.GetLength(1)))
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    (matrix[rowIndex, i], B[i, columnIndex]) = (B[i, columnIndex], matrix[rowIndex, i]);
                }
            }
        }

        public void Task2(ref int[,] A, int[,] B)
        {

            // code here
            int rowIndex = -1;
            int rowHowPositive = 0;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                if (rowHowPositive < CountPositiveElementsInRow(A, i))
                {
                    rowHowPositive = CountPositiveElementsInRow(A, i);
                    rowIndex = i;
                }
            }
            int colIndex = -1;
            int colHowPositive = 0;
            for (int i = 0; i < B.GetLength(1); i++)
            {
                if (colHowPositive < CountPositiveElementsInColumn(B, i))
                {
                    colHowPositive = CountPositiveElementsInColumn(B, i);
                    colIndex = i;
                }
            }
            if ((rowIndex != -1) && (colIndex != -1))
            {
                InsertColumn(ref A, rowIndex, colIndex, B);
            }
            // end

        }

        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B)
        {
            int[,] newA = new int[A.GetLength(0) + 1, A.GetLength(1)];
            int i = 0;
            if (A.GetLength(1) == B.GetLength(0))
            {
                while (i <= rowIndex)
                {
                    for (int j = 0; j < A.GetLength(1); j++)
                    {
                        newA[i, j] = A[i, j];
                    }
                    i++;
                }
                for (int j = 0; j < B.GetLength(0); j++)
                {
                    newA[i, j] = B[j, columnIndex];
                }
                i++;
                while (i < A.GetLength(0) + 1)
                {
                    for (int j = 0; j < A.GetLength(1); j++)
                    {
                        newA[i, j] = A[i - 1, j];
                    }
                    i++;
                }
                A = newA;
            }
        }

        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int PositiveCount = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > 0) PositiveCount++;
            }

            return PositiveCount;
        }

        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {
            int PositiveCount = 0;
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                if (matrix[j, col] > 0) PositiveCount++;
            }

            return PositiveCount;
        }

        public void Task3(int[,] matrix)
        {

            // code here
            if (matrix == null)
            {
                return;
            }
            ChangeMatrixValues(matrix);
            // end

        }

        public void ChangeMatrixValues(int[,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            if (n * m <= 5)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        matrix[i, j] *= 2;
                    }
                }
                return;
            }
            else
            {
                int[] max = new int[5];
                for (int i = 0; i < 5; i++)
                {
                    max[i] = int.MinValue;
                }
                int tempk = 4;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        tempk = 4;
                        for (int k = 0; k < 5; k++)
                        {
                            if (matrix[i, j] >= max[k])
                            {
                                while (tempk > k)
                                {
                                    max[tempk] = max[tempk - 1];
                                    tempk--;
                                }
                                max[k] = matrix[i, j];
                                break;
                            }
                        }
                    }
                }
                int flag = 0;
                int changed = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (flag == 5)
                        {
                            matrix[i, j] /= 2;
                        }
                        else
                        {
                            changed = 0;
                            for (int k = 0; k < 5; k++)
                            {
                                if (matrix[i, j] == max[k])
                                {
                                    max[k] = max[0];
                                    matrix[i, j] *= 2;
                                    flag++;
                                    changed = 1;
                                    break;
                                }
                            }
                            if (changed == 0)
                            {
                                matrix[i, j] /= 2;
                            }
                        }
                    }
                }
            }
        }

        public void Task4(int[,] A, int[,] B)
        {

            // code here
            int[] NegativesA = CountNegativesPerRow(A);
            int[] NegativesB = CountNegativesPerRow(B);
            int IndexA = FindMaxIndex(NegativesA), IndexB = FindMaxIndex(NegativesB);
            if ((IndexA != -1) && (IndexB != -1) && (A.GetLength(1) == B.GetLength(1)))
            {
                for (int i = 0; i < A.GetLength(1); i++)
                {
                    (A[IndexA, i], B[IndexB, i]) = (B[IndexB, i], A[IndexA, i]);
                }
            }
            // end

        }

        public int[] CountNegativesPerRow(int[,] matrix)
        {
            int[] NegativePerRow = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        NegativePerRow[i]++;
                    }
                }
            }
            return NegativePerRow;
        }

        public int FindMaxIndex(int[] array)
        {
            int max = array[0];
            int foundIndex = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    foundIndex = i;
                }
            }
            if ((foundIndex == 0) && (array[0] == 0))
            {
                return -1;
            }
            return foundIndex;
        }

        public delegate void Sorting(int[] matrix);

        public void Task5(int[] matrix, Sorting sort)
        {

            // code here
            sort(matrix);
            // end

        }

        public void SortNegativeAscending(int[] matrix)
        {
            int negatives = 0;
            int length = matrix.Length;
            for (int i = 0; i < length; i++)
            {
                if (matrix[i] < 0)
                {
                    negatives++;
                }
            }
            int[] minus = new int[negatives];
            negatives = 0;
            for (int i = 0; i < length; i++)
            {
                if (matrix[i] < 0)
                {
                    minus[negatives++] = matrix[i];
                }
            }
            negatives = 0;
            while (negatives < minus.Length)
            {
                if ((negatives == 0) || (minus[negatives] >= minus[negatives - 1]))
                {
                    negatives++;
                }
                else
                {
                    (minus[negatives], minus[negatives - 1]) = (minus[negatives - 1], minus[negatives]);
                    negatives--;
                }
            }
            negatives = 0;
            for (int i = 0; i < length; i++)
            {
                if (matrix[i] < 0)
                {
                    matrix[i] = minus[negatives++];
                }
            }
        }

        public void SortNegativeDescending(int[] matrix)
        {
            int negatives = 0;
            int length = matrix.Length;
            for (int i = 0; i < length; i++)
            {
                if (matrix[i] < 0)
                {
                    negatives++;
                }
            }
            int[] minus = new int[negatives];
            negatives = 0;
            for (int i = 0; i < length; i++)
            {
                if (matrix[i] < 0)
                {
                    minus[negatives] = matrix[i];
                    negatives++;
                }
            }
            negatives = 0;
            while (negatives < minus.Length)
            {
                if ((negatives == 0) || (minus[negatives] <= minus[negatives - 1]))
                {
                    negatives++;
                }
                else
                {
                    (minus[negatives], minus[negatives - 1]) = (minus[negatives - 1], minus[negatives]);
                    negatives--;
                }
            }
            negatives = 0;
            for (int i = 0; i < length; i++)
            {
                if (matrix[i] < 0)
                {
                    matrix[i] = minus[negatives];
                    negatives++;
                }
            }
        }

        public delegate void SortRowsByMax(int[,] matrix);

        public void Task6(int[,] matrix, SortRowsByMax sort)
        {

            // code here
            sort(matrix);
            // end

        }

        public void SortRowsByMaxAscending(int[,] matrix)
        {
            int[] max = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                max[i] = GetRowMax(matrix, i);
            }
            int tempi = 0, length = max.Length;
            while (tempi < length)
            {
                if ((tempi == 0) || (max[tempi] >= max[tempi - 1]))
                {
                    tempi++;
                }
                else
                {
                    (max[tempi], max[tempi - 1]) = (max[tempi - 1], max[tempi]);
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        (matrix[tempi, j], matrix[tempi - 1, j]) = (matrix[tempi - 1, j], matrix[tempi, j]);
                    }
                    tempi--;
                }
            }
        }

        public void SortRowsByMaxDescending(int[,] matrix)
        {
            int[] max = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                max[i] = GetRowMax(matrix, i);
            }
            int tempi = 0, length = max.Length;
            while (tempi < length)
            {
                if ((tempi == 0) || (max[tempi] <= max[tempi - 1]))
                {
                    tempi++;
                }
                else
                {
                    (max[tempi], max[tempi - 1]) = (max[tempi - 1], max[tempi]);
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        (matrix[tempi, j], matrix[tempi - 1, j]) = (matrix[tempi - 1, j], matrix[tempi, j]);
                    }
                    tempi--;
                }
            }
        }

        public int GetRowMax(int[,] matrix, int row)
        {
            int max = int.MinValue;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > max)
                {
                    max = matrix[row, j];
                }
            }
            return max;
        }

        public delegate int[] FindNegatives(int[,] matrix);

        public int[] Task7(int[,] matrix, FindNegatives find)
        {
            int[] negatives = null;

            // code here
            negatives = find(matrix);
            // end

            return negatives;
        }

        public int[] FindNegativeCountPerRow(int[,] matrix)
        {
            int[] CountPerRow = new int[matrix.GetLength(0)];
            int currentcount;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                currentcount = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        currentcount++;
                    }
                }
                CountPerRow[i] = currentcount;
            }
            return CountPerRow;
        }

        public int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            int[] MaxNegativeColumn = new int[matrix.GetLength(1)];
            int currentmax;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                currentmax = int.MinValue;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if ((matrix[i, j] < 0) && (matrix[i, j] > currentmax))
                    {
                        currentmax = matrix[i, j];
                    }
                }
                if (currentmax == int.MinValue)
                {
                    currentmax = 0;
                }
                MaxNegativeColumn[j] = currentmax;
            }
            return MaxNegativeColumn;
        }

        public delegate int[,] MathInfo(int[,] matrix);

        public int[,] Task8(int[,] matrix, MathInfo info)
        {
            int[,] answer = null;

            // code here
            answer = info(matrix);
            // end

            return answer;
        }

        public int[,] DefineSeq(int[,] matrix)
        {
            int[,] answer;
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            if (n == 2)
            {
                int tempj = 0;
                while (tempj < m)
                {
                    if ((tempj == 0) || (matrix[0, tempj] >= matrix[0, tempj - 1]))
                    {
                        tempj++;
                    }
                    else
                    {
                        (matrix[0, tempj], matrix[0, tempj - 1]) = (matrix[0, tempj - 1], matrix[0, tempj]);
                        (matrix[1, tempj], matrix[1, tempj - 1]) = (matrix[1, tempj - 1], matrix[1, tempj]);
                        tempj--;
                    }
                }
                int flag = 0;
                for (int j = 1; j < m; j++)
                {
                    if (matrix[1, j] > matrix[1, j - 1])
                    {
                        if (flag == -1)
                        {
                            answer = new int[,] { { 0 } };
                            return answer;
                        }
                        flag = 1;
                    }
                    else if (matrix[1, j] < matrix[1, j - 1])
                    {
                        if (flag == 1)
                        {
                            answer = new int[,] { { 0 } };
                            return answer;
                        }
                        flag = -1;
                    }
                }
                if (flag != 0)
                {
                    answer = new int[,] { { flag } };
                }
                else
                {
                    answer = new int[,] { };
                }
                return answer;
            }
            else
            {
                answer = new int[,] { };
                return answer;
            }
        }

        public int[,] FindAllSeq(int[,] matrix)
        {
            int[,] answer;
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            if ((n == 2) && (m > 1))
            {
                int tempj = 0;
                while (tempj < m)
                {
                    if ((tempj == 0) || (matrix[0, tempj] >= matrix[0, tempj - 1]))
                    {
                        tempj++;
                    }
                    else
                    {
                        (matrix[0, tempj], matrix[0, tempj - 1]) = (matrix[0, tempj - 1], matrix[0, tempj]);
                        (matrix[1, tempj], matrix[1, tempj - 1]) = (matrix[1, tempj - 1], matrix[1, tempj]);
                        tempj--;
                    }
                }
                int flag = 0;
                int lastx = matrix[0, 0];
                int count = 0;
                for (int j = 1; j < m; j++)
                {
                    if (matrix[1, j] > matrix[1, j - 1])
                    {
                        if (flag == -1)
                        {
                            count++;
                        }
                        flag = 1;
                    }
                    else if (matrix[1, j] < matrix[1, j - 1])
                    {
                        if (flag == 1)
                        {
                            count++;
                        }
                        flag = -1;
                    }
                }
                if (flag != 0)
                {
                    count++;
                }
                answer = new int[count, 2];
                flag = 0;
                count = 0;
                for (int j = 1; j < m; j++)
                {
                    if (matrix[1, j] > matrix[1, j - 1])
                    {
                        if (flag == -1)
                        {
                            answer[count, 0] = lastx;
                            lastx = matrix[0, j - 1];
                            answer[count, 1] = lastx;
                            count++;
                            flag = 0;
                        }
                        flag = 1;
                    }
                    else if (matrix[1, j] < matrix[1, j - 1])
                    {
                        if (flag == 1)
                        {
                            answer[count, 0] = lastx;
                            lastx = matrix[0, j - 1];
                            answer[count, 1] = lastx;
                            count++;
                            flag = 0;
                        }
                        flag = -1;
                    }
                }
                if (flag != 0)
                {
                    answer[count, 0] = lastx;
                    lastx = matrix[0, m - 1];
                    answer[count, 1] = lastx;
                    count++;
                    flag = 0;
                }
                return answer;
            }
            else
            {
                answer = new int[,] { };
                return answer;
            }
        }

        public int[,] FindLongestSeq(int[,] matrix)
        {
            int[,] AllSeq;
            AllSeq = FindAllSeq(matrix);
            int max = 0;
            int[,] answer;
            if (AllSeq.GetLength(1) >= 1)
            {
                answer = new int[,] { { AllSeq[max, 0], AllSeq[max, 1] } };
                for (int i = 0; i < AllSeq.GetLength(0); i++)
                {
                    if ((AllSeq[i, 1] - AllSeq[i, 0]) > (AllSeq[max, 1] - AllSeq[max, 0]))
                    {
                        max = i;
                        answer[0, 0] = AllSeq[max, 0]; answer[0, 1] = AllSeq[max, 1];
                    }
                }
            }
            else
            {
                answer = new int[,] { };
            }
            return answer;
        }

        public delegate double Func(double x);

        public int Task9(double a, double b, double h, Func<double, double> func)
        {
            int answer = 0;

            // code here
            answer = CountSignFlips(a, b, h, func);
            // end

            return answer;
        }

        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
        {
            int count = 0;
            double x = a, y = func(x);
            while ((x < b) && (Math.Abs(y) < 0.0001))
            {
                x += h;
                y = func(x);
            }
            x += h;
            double new_y;
            while (x < (b + h / 2))
            {
                new_y = func(x);
                if (Math.Abs(new_y) < 0.0001)
                {
                    new_y = 0;
                }
                if ((y != 0) && (new_y != 0) && ((y < 0 && new_y > 0) || (y > 0 && new_y < 0)))
                {
                    count++;
                }
                if (new_y != 0)
                {
                    y = new_y;
                }
                x += h;
            }
            return count;
        }

        public double FuncA(double x)
        {
            return (x * x - Math.Sin(x));
        }

        public double FuncB(double x)
        {
            return Math.Exp(x) - 1;
        }

        public delegate void Action(int[][] array);

        public void Task10(int[][] array, Action<int[][]> func)
        {

            // code here
            func(array);
            // end

        }

        public void SortInCheckersOrder(int[][] array)
        {
            int n = array.Length;
            int temp;
            for (int i = 0; i < n; i++)
            {
                temp = 0;
                int m = array[i].Length;
                if ((i / 2) * 2 == i)
                {
                    while (temp < m)
                    {
                        if (temp == 0 || array[i][temp] >= array[i][temp - 1])
                        {
                            temp++;
                        }
                        else
                        {
                            (array[i][temp], array[i][temp - 1]) = (array[i][temp - 1], array[i][temp]);
                            temp--;
                        }
                    }
                }
                else
                {
                    while (temp < m)
                    {
                        if (temp == 0 || array[i][temp] <= array[i][temp - 1])
                        {
                            temp++;
                        }
                        else
                        {
                            (array[i][temp], array[i][temp - 1]) = (array[i][temp - 1], array[i][temp]);
                            temp--;
                        }
                    }
                }
            }
        }

        public void SortBySumDesc(int[][] array)
        {
            int n = array.Length;
            int[] sums = new int[n];
            int m;
            for (int i = 0; i < n; i++)
            {
                m = array[i].Length;
                for (int j = 0; j < m; j++)
                {
                    sums[i] += array[i][j];
                }
            }
            int temp = 0;
            while (temp < n)
            {
                if ((temp == 0) || (sums[temp] <= sums[temp - 1]))
                {
                    temp++;
                }
                else
                {
                    (array[temp], array[temp - 1]) = (array[temp - 1], array[temp]);
                    (sums[temp], sums[temp - 1]) = (sums[temp - 1], sums[temp]);
                    temp--;
                }
            }
        }

        public void TotalReverse(int[][] array)
        {
            int length = array.Length;
            for (int i = 0; i < length; i++)
            {
                Array.Reverse(array[i]);
            }
            for (int i = 0; i < length / 2; i++)
            {
                (array[i], array[length - 1 - i]) = (array[length - i - 1], array[i]);
            }
        }
    }
}
