using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Security.Cryptography;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public class Purple
    {
        public bool CheckBox(int[,] matrix)
        {
            if (matrix.GetLength(0) == matrix.GetLength(1)) return true;
            return false;
        }
        public void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex)
        {
            if ((CheckBox(matrix) && CheckBox(B)) && (matrix.GetLength(0) == B.GetLength(0)))
            {
                int temp;
                for(int x = 0; x < matrix.GetLength(0); x++)
                {
                    temp = matrix[rowIndex, x];
                    matrix[rowIndex, x] = B[x, columnIndex];
                    B[x, columnIndex] = temp;
                }
            }
        }
        public int FindDiagonalMatrixIndex(int[,] matrix)
        {
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                int ind = 0;
                int maxEl = matrix[0, 0];
                for (int x = 0; x < matrix.GetLength(0); x++)
                {
                    if (matrix[x, x] > maxEl)
                    {
                        maxEl = matrix[x, x];
                        ind = x;
                    }
                }
                Console.WriteLine(ind);
                return ind;
            }
            return 0;
        }
        public void Task1(int[,] A, int[,] B)
        {

            // code here
            int swapXA = FindDiagonalMatrixIndex(A);
            int swapYB = FindDiagonalMatrixIndex(B);
            SwapRowColumn(A, swapXA, B, swapYB);
            // end
            //YES

        }
        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B)
        {
            if (A.GetLength(1) == B.GetLength(0))
            {
                int n = A.GetLength(0); int m = A.GetLength(1);
                int[,] newA = new int[n + 1, m];

                for (int y = 0; y < rowIndex + 1; y++)
                {
                    for (int x = 0; x < m; x++)
                    {
                        newA[y, x] = A[y, x];
                    }
                }

                for (int j = 0; j < m; j++)
                {
                    if (j < B.GetLength(0))
                        newA[rowIndex + 1, j] = B[j, columnIndex];
                    else
                        newA[rowIndex + 1, j] = 0;
                }

                for (int i = rowIndex + 1; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        newA[i + 1, j] = A[i, j];
                    }
                }

                A = newA;
            }
        }
        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int count = 0;
            for(int x = 0; x < matrix.GetLength(1); x++)
            {
                if (matrix[row, x] > 0) count++;
            }
            return count;
        }
        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {
            int count = 0;
            for (int y = 0; y < matrix.GetLength(0); y++)
            {
                if (matrix[y, col] > 0) count++;
            }
            return count;
        }
        public void Task2(ref int[,] A, int[,] B)
        {

            // code here
            int maxPositiveCountRow = int.MinValue; int rowIndex = 0;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                int PositiveCountRow = CountPositiveElementsInRow(A, i);
                if (PositiveCountRow > maxPositiveCountRow)
                {
                    maxPositiveCountRow = PositiveCountRow;
                    rowIndex = i;
                }
            }

            int maxPositiveCountCol = int.MinValue; int columnIndex = 0;
            for (int j = 0; j < B.GetLength(1); j++)
            {
                int PositiveCountCol = CountPositiveElementsInColumn(B, j);
                if (PositiveCountCol > maxPositiveCountCol)
                {
                    maxPositiveCountCol = PositiveCountCol;
                    columnIndex = j;
                }
            }

            InsertColumn(ref A, rowIndex, columnIndex, B);
            // end
            //YES

        }
        public void ChangeMatrixValues(int[,] matrix)
        {
            int n = matrix.GetLength(0); int m = matrix.GetLength(1);

            if (matrix.Length <= 5)
            {
                for (int y = 0; y < matrix.GetLength(0); y++)
                {
                    for (int x = 0; x < matrix.GetLength(1); x++)
                    {
                        matrix[y, x] *= 2;
                    }
                }
                return;
            }

            int[] array = new int[matrix.Length];
            int[] maxIndexes = new int[matrix.Length];

            int index = 0;

            for (int y = 0; y < matrix.GetLength(0); y++)
            {
                for (int x = 0; x < matrix.GetLength(1); x++)
                {
                    array[index] = matrix[y, x];
                    maxIndexes[index] = index;
                    index++;
                }
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if ((array[j] < array[j + 1]) || (array[j] == array[j + 1] && maxIndexes[j] > maxIndexes[j + 1]))
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        (maxIndexes[j], maxIndexes[j + 1]) = (maxIndexes[j + 1], maxIndexes[j]);
                    }
                }
            }

            bool[] isMaxValue = new bool[array.Length];
            for (int i = 0; i < 5; i++)
            {
                isMaxValue[maxIndexes[i]] = true;
            }

            index = 0;
            for (int y = 0; y < matrix.GetLength(0); y++)
            {
                for (int x = 0; x < matrix.GetLength(1); x++)
                {
                    if (isMaxValue[index++])
                        matrix[y, x] *= 2;
                    else
                        matrix[y, x] /= 2;
                }
            }
        }
        public void Task3(int[,] matrix)
        {

            // code here
            ChangeMatrixValues(matrix);
            // end
            //YES

        }
        public int[] CountNegativesPerRow(int[,] matrix)
        {
            int[] negatives = new int[matrix.GetLength(0)];
            int k = 0;

            for (int y = 0; y < matrix.GetLength(0); y++)
            {
                int count = 0;
                for (int x = 0; x < matrix.GetLength(1); x++)
                {
                    if (matrix[y, x] < 0)
                    {
                        count++;
                    }
                }
                negatives[k++] = count;
            }

            return negatives;
        }
        public int FindMaxIndex(int[] array)
        {
            int imax = 0;
            for (int x = 0; x < array.Length; x++)
            {
                if (array[x] > array[imax])
                {
                    imax = x;
                }
            }
            return imax;
        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here
            if (A.GetLength(1) != B.GetLength(1)) return;

            int[] negA = CountNegativesPerRow(A);
            int[] negB = CountNegativesPerRow(B);
            bool isA = false, isB = false;
            int rowA = FindMaxIndex(negA);
            int rowB = FindMaxIndex(negB);

            for (int i = 0; i < negA.Length; i++) if (negA[i] > 0) isA = true;
            for (int i = 0; i < negB.Length; i++) if (negB[i] > 0) isB = true;
            if (!isA || !isB) return;
            
            for (int x = 0; x < A.GetLength(1); x++) (A[rowA, x], B[rowB, x]) = (B[rowB, x], A[rowA, x]);
            // end
            //YES

        }
        public delegate void Sorting(int[] matrix);
        public void SortNegativeAscending(int[] matrix)
        {
            int i = 0;
            for (int x = 0; x < matrix.Length; x++)
                if (matrix[x] < 0) x++;
            int count = 0;
            int[] negInd = new int[i];
            int[] neg = new int[i];
            for (int x = 0; x < matrix.Length; x++)
            {
                if (matrix[x] < 0)
                {
                    neg[count] = matrix[x];
                    negInd[count] = x;
                    count++;
                }
            }
            Array.Sort(neg);
            count = 0;
            foreach (int el in negInd)
            {
                matrix[el] = neg[count];
                count++;
            }
        }
        public void SortNegativeDescending(int[] matrix)
        {
            int i = 0;
            for (int x = 0; x < matrix.Length; x++) if (matrix[x] < 0) x++;
            int count = 0;
            int[] neg = new int[i];
            int[] negInd = new int[i];
            for (int x = 0; x < matrix.Length; x++)
            {
                if (matrix[x] < 0)
                {
                    negInd[count] = x;
                    neg[count] = matrix[x];
                    count++;
                }
            }
            Array.Sort(neg);
            Array.Reverse(neg);
            count = 0;
            foreach (int el in negInd)
            {
                matrix[el] = neg[count];
                count++;
            }
        }
        public void Task5(int[] matrix, Sorting sort)
        {

            // code here
            sort(matrix);
            // end
            //YES

        }
        public delegate void SortRowsByMax(int[,] matrix);
        public int GetRowMax(int[,] matrix, int rowIndex)
        {
            int max = matrix[rowIndex, 0];
            for (int x = 1; x < matrix.GetLength(1); x++) max = Math.Max(max, matrix[rowIndex, x]);
            return max;
        }
        public void SortRowsByMaxDescending(int[,] matrix)
        {
            int[] array = new int[matrix.GetLength(0)];

            for (int x = 0; x < matrix.GetLength(0); x++) array[x] = GetRowMax(matrix, x);

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int y = 0; y < array.Length - 1 - i; y++)
                {
                    if (array[y] < array[y + 1])
                    {
                        (array[y], array[y + 1]) = (array[y + 1], array[y]);

                        for (int x = 0; x < matrix.GetLength(1); x++)
                        {
                            (matrix[y, x], matrix[y + 1, x]) = (matrix[y + 1, x], matrix[y, x]);
                        }
                    }
                }
            }
        }
        public void SortRowsByMaxAscending(int[,] matrix)
        {
            int[] array = new int[matrix.GetLength(0)];

            for (int x = 0; x < matrix.GetLength(0); x++) array[x] = GetRowMax(matrix, x);
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int y = 0; y < array.Length - 1 - i; y++)
                {
                    if (array[y] > array[y + 1])
                    {
                        (array[y], array[y + 1]) = (array[y + 1], array[y]);

                        for (int x = 0; x < matrix.GetLength(1); x++)
                        {
                            (matrix[y, x], matrix[y + 1, x]) = (matrix[y + 1, x], matrix[y, x]);
                        }
                    }
                }
            }
        }
        public void Task6(int[,] matrix, SortRowsByMax sort)
        {

            // code here
            sort(matrix);
            // end
            //YES

        }
        public delegate int[] FindNegatives(int[,] matrix);
        public int[] FindNegativeCountPerRow(int[,] matrix)
        {
            int count;
            int[] neg = new int[matrix.GetLength(0)];
            for (int y = 0; y < matrix.GetLength(0); y++)
            {
                count = 0;
                for (int x = 0; x < matrix.GetLength(1); x++)
                {
                    if (matrix[y, x] < 0) count++;
                }
                neg[y] = count;
            }
            return neg;
        }
        public int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            int max;
            int[] maxNeg = new int[matrix.GetLength(1)];
            for (int x = 0; x < matrix.GetLength(1); x++)
            {
                max = 0;
                for (int y = 0; y < matrix.GetLength(0); y++)
                {
                    if (matrix[y, x] < 0 && max == 0) max = matrix[y, x];
                    else if (matrix[y, x] < 0 && matrix[y, x] > max) max = matrix[y, x];
                }
                maxNeg[x] = max;
            }
            return maxNeg;
        }
        public int[] Task7(int[,] matrix, FindNegatives find)
        {
            int[] negatives = null;

            // code here
            negatives = find(matrix);
            // end
            //YES

            return negatives;
        }
        public delegate int[,] MathInfo(int[,] matrix);
        public int[,] DefineSeq(int[,] matrix)
        {
            if (matrix.GetLength(1) < 2) return new int[0, 0];

            bool flag = true;
            for (int x = 1; x < matrix.GetLength(1); x++)
            {
                if (matrix[1, x] != matrix[1, 0])
                {
                    flag = false;
                    break;
                }
            }
            if (flag) return new int[0, 0];

            bool increasing = true;
            bool decreasing = true;
            for (int x = 0; x < matrix.GetLength(1) - 1; x++)
            {
                if (matrix[1, x] < matrix[1, x + 1]) decreasing = false;
                else if (matrix[1, x] > matrix[1, x + 1]) increasing = false;
            }
            if (increasing) return new int[,] { { 1 } };
            if (decreasing) return new int[,] { { -1 } };
            return new int[,] { { 0 } };
        }
        public int[,] FindAllSeq(int[,] matrix)
        {
            if (matrix.GetLength(1) < 2) return new int[0, 0];

            int[,] defSeq = DefineSeq(matrix);
            if (defSeq.GetLength(0) == 0) return new int[0, 0];
            if (defSeq[0, 0] != 0) return new int[,] { { matrix[0, 0], matrix[0, matrix.GetLength(1) - 1] } };


            int changes = 0;
            int direction = 0;

            for (int x = 1; x < matrix.GetLength(1); x++)
            {
                int diff = matrix[1, x] - matrix[1, x - 1];
                if (diff == 0) continue;

                int sign = diff > 0 ? 1 : -1;

                if (direction == 0) direction = sign;
                else if (sign != direction)
                {
                    changes++;
                    direction = sign;
                }
            }
            int[,] result = new int[changes + 1, 2];

            int start = 0;
            changes = 0;
            direction = 0;

            for (int x = 1; x < matrix.GetLength(1); x++)
            {
                int diff = matrix[1, x] - matrix[1, x - 1];
                if (diff == 0) continue;

                int sign = diff > 0 ? 1 : -1;

                if (direction == 0) direction = sign;
                else if (direction != sign)
                {
                    result[changes, 0] = matrix[0, start];
                    result[changes, 1] = matrix[0, x - 1];
                    start = x - 1;
                    changes++;
                    direction = sign;

                }
            }
            result[changes, 0] = matrix[0, start];
            result[changes, 1] = matrix[0, matrix.GetLength(1) - 1];


            return result;
        }
        public int[,] FindLongestSeq(int[,] matrix)
        {
            matrix = FindAllSeq(matrix);
            int[,] result = new int[1, 2];
            if (matrix.GetLength(0) == 0) return new int[0, 0];

            int diff = matrix[0, 1] - matrix[0, 0];
            result[0, 0] = matrix[0, 0];
            result[0, 1] = matrix[0, 1];

            for (int y = 1; y < matrix.GetLength(0); y++)
            {
                if (diff < matrix[y, 1] - matrix[y, 0])
                {
                    diff = matrix[y, 1] - matrix[y, 0];
                    result[0, 0] = matrix[y, 0];
                    result[0, 1] = matrix[y, 1];
                }
            }
            return result;
        }

        public int[,] Task8(int[,] matrix, MathInfo info)
        {
            int[,] answer = null;

            // code here
            answer = info(matrix);
            // end
            //YES

            return answer;
        }

        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
        {
            int count = 0;
            for (double x = a; x <= b - h; x += h)
            {
                double y1 = func(x);
                double y2 = func(x + h);
                if ((y1 > 0 && y2 < 0) || (y1 < 0 && y2 > 0)) count++;
            }
            return count;
        }
        public double FuncA(double x)
        {
            return Math.Pow(x, 2) - Math.Sin(x);
        }
        public double FuncB(double x)
        {
            return Math.Exp(x) - 1;
        }

        public int Task9(double a, double b, double h, Func<double, double> func)
        {
            int answer = 0;

            // code here
            answer = CountSignFlips(a, b, h, func);
            // end
            //YES

            return answer;
        }
        public void SortInCheckersOrder(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 == 0) Array.Sort(array[i]);
                else
                {
                    Array.Sort(array[i]);
                    Array.Reverse(array[i]);
                }
            }
        }
        public void SortBySumDesc(int[][] array)
        {
            for (int k = 0; k < array.Length - 1; k++)
            {
                for (int y = 0; y < array.Length - 1 - k; y++)
                {
                    int sum1 = 0; int sum2 = 0;

                    for (int x = 0; x < array[y].Length; x++) sum1 += array[y][x];
                    for (int x = 0; x < array[y + 1].Length; x++) sum2 += array[y + 1][x];
                    if (sum1 < sum2) (array[y], array[y + 1]) = (array[y + 1], array[y]);
                }
            }
        }
        public void TotalReverse(int[][] array)
        {
            for (int i = 0; i < array.Length; i++) Array.Reverse(array[i]);
            Array.Reverse(array);
        }
        public void Task10(int[][] array, Action<int[][]> func)
        {

            // code here
            func(array);
            // end
            //YES
        }
    }
}