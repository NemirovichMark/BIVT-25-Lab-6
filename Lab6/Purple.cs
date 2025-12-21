using System.Runtime.InteropServices;
using System.Xml;

namespace Lab6
{
    public class Purple
    {
        public void Print(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],4}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }


        public void Task1(int[,] A, int[,] B)
        {

            // code here

            if (A.GetLength(0) != A.GetLength(1) || B.GetLength(0) != B.GetLength(1) || A.GetLength(1) != B.GetLength(0))
            {
                return;
            }
            //Print(A); Print(B);

            int indexMaxA = FindDiagonalMaxIndex(A);
            int indexMaxB = FindDiagonalMaxIndex(B);

            SwapRowColumn(A, indexMaxA, B, indexMaxB);
            //Print(A); Print(B);

            // end

        }
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int max = int.MinValue;
            int imax = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    imax = i;
                }
            }
            return imax;
        }
        public void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex)
        {
            int temp = 0;
            for (int i = 0; i < B.GetLength(0); i++)
            {
                temp = matrix[rowIndex, i];
                matrix[rowIndex, i] = B[i, columnIndex];
                B[i, columnIndex] = temp;
            }
        }


        public void Task2(ref int[,] A, int[,] B)
        {

            // code here

            //Print(A); Print(B);

            int maxIndexB = -1;
            int maxIndexA = -1;
            int max = 0;

            for (int i = 0; i < B.GetLength(1); i++)
            {
                int currentCount = CountPositiveElementsInColumn(B, i);
                if (currentCount > max)
                {
                    max = currentCount;
                    maxIndexB = i;
                }
            }

            if (maxIndexB == -1 || A.GetLength(1) != B.GetLength(0))
                return;

            max = 0;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                int currentCount = CountPositiveElementsInRow(B, i);
                if (currentCount > max)
                {
                    max = currentCount;
                    maxIndexA = i;
                }

            }

            InsertColumn(ref A, maxIndexA, maxIndexB, B);

            //Print(A);

            // end

        }
        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int count = 0;

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[row, i] > 0)
                {
                    count++;
                }
            }

            return count;
        }
        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {
            int count = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] > 0)
                {
                    count++;
                }
            }

            return count;
        }
        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B)
        {
            int[,] matrix = new int[A.GetLength(0) + 1, A.GetLength(1)];

            for (int i = 0; i < A.GetLength(0) + 1; i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    if (i <= rowIndex)
                    {
                        matrix[i, j] = A[i, j];
                    }
                    else if (i == rowIndex + 1)
                    {
                        matrix[i, j] = B[j, columnIndex];
                    }
                    else
                    {
                        matrix[i, j] = A[i - 1, j];
                    }
                }
            }

            A = matrix;
        }


        public void Task3(int[,] matrix)
        {

            // code here
            ChangeMatrixValues(matrix);
            // end

        }
        public void ChangeMatrixValues(int[,] matrix)
        {
            int count = 5;
            int[] sorted = ConvertMatrixToArray(matrix);
            Array.Sort(sorted);
            int[] array;
            if (sorted.Length >= 5)
            {
                array = new int[5] {sorted[sorted.Length-1],
                                    sorted[sorted.Length-2],
                                    sorted[sorted.Length-3],
                                    sorted[sorted.Length-4],
                                    sorted[sorted.Length-5]};
            }
            else
            {
                array = sorted;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (Array.Exists(array, elem => elem == matrix[i, j]))
                    {
                        ArrayDeleteNumber(ref array, matrix[i, j]);
                        matrix[i, j] = 2 * matrix[i, j];
                    }
                    else
                    {
                        matrix[i, j] = matrix[i, j] / 2;
                    }
                }
            }
        }
        public int[] ConvertMatrixToArray(int[,] matrix)
        {
            int[] array = new int[matrix.Length];
            int k = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    array[k] = matrix[i, j];
                    k++;
                }
            }
            return array;
        }
        public void ArrayDeleteNumber(ref int[] array, int n)
        {
            int[] newArray = new int[array.Length - 1];
            int f = 1;
            for (int i = 0; i < newArray.Length; i++)
            {
                if (array[i] == n && f != 0)
                {
                    f *= 0;
                }
                if (f == 1)
                {
                    newArray[i] = array[i];
                }
                else
                {
                    newArray[i] = array[i + 1];
                }

            }
            array = newArray;
        }


        public void Task4(int[,] A, int[,] B)
        {

            // code here

            if (A.GetLength(1) != B.GetLength(1))
            {
                return;
            }

            int maxA = Int32.MinValue; int maxB = Int32.MinValue;
            int maxIndexA = -1; int maxIndexB = -1;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                if (ReallyCountNegativesPerRow(A, i) > maxA)
                {
                    maxA = ReallyCountNegativesPerRow(A, i);
                }
            }
            for (int i = 0; i < B.GetLength(0); i++)
            {
                if (ReallyCountNegativesPerRow(B, i) > maxB)
                {
                    maxB = ReallyCountNegativesPerRow(B, i);
                }
            }

            if (maxA == 0 || maxB == 0)
            {
                return;
            }

            for (int i = 0; i < A.GetLength(0); i++)
            {
                if (ReallyCountNegativesPerRow(A, i) == maxA)
                {
                    maxIndexA = i;
                    break;
                }
            }
            for (int i = 0; i < B.GetLength(0); i++)
            {
                if (ReallyCountNegativesPerRow(B, i) == maxB)
                {
                    maxIndexB = i;
                    break;
                }
            }

            SwapRows(A, maxIndexA, B, maxIndexB);

            // end

        }
        public int[] CountNegativesPerRow(int[,] matrix)
        {
            int[] negative = null;
            int count = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        count++;
                    }
                }
            }

            negative = new int[count];
            count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        negative[count++] = matrix[i, j];
                    }
                }
            }

            return negative;
        }
        public int FindMaxIndex(int[] array)
        {
            int max = int.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = Math.Abs(array[i]);
                }
            }
            return max;
        }
        public int ReallyCountNegativesPerRow(int[,] matrix, int index)
        {
            int count = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[index, i] < 0)
                {
                    count++;
                }
            }

            return count;
        }
        public void SwapRows(int[,] A, int iA, int[,] B, int iB)
        {
            int[] temp = new int[A.GetLength(1)];
            for (int i = 0; i < A.GetLength(1); i++)
            {
                temp[i] = A[iA, i];
                A[iA, i] = B[iB, i];
            }
            for (int i = 0; i < A.GetLength(1); i++)
            {
                B[iB, i] = temp[i];
            }
            return;
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
            int count = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                    count++;
            }

            int[] negatives = new int[count];
            int[] negativesIndex = new int[count];

            int index = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    negatives[index] = matrix[i];
                    negativesIndex[index] = i;
                    index++;
                }
            }

            for (int i = 0; i < negatives.Length - 1; i++)
            {
                for (int j = 0; j < negatives.Length - 1 - i; j++)
                {
                    if (negatives[j] > negatives[j + 1])
                        (negatives[j], negatives[j + 1]) = (negatives[j + 1], negatives[j]);
                }
            }

            for (int i = 0; i < negativesIndex.Length; i++)
            {
                matrix[negativesIndex[i]] = negatives[i];
            }
        }
        public void SortNegativeDescending(int[] matrix)
        {
            int count = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                    count++;
            }

            int[] negatives = new int[count];
            int[] negativesIndex = new int[count];

            int index = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    negatives[index] = matrix[i];
                    negativesIndex[index] = i;
                    index++;
                }
            }

            for (int i = 0; i < negatives.Length - 1; i++)
            {
                for (int j = 0; j < negatives.Length - 1 - i; j++)
                {
                    if (negatives[j] < negatives[j + 1])
                        (negatives[j], negatives[j + 1]) = (negatives[j + 1], negatives[j]);
                }
            }

            for (int i = 0; i < negativesIndex.Length; i++)
            {
                matrix[negativesIndex[i]] = negatives[i];
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
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(0) - 1 - i; j++)
                {
                    if (GetRowMax(matrix, j) > GetRowMax(matrix, j + 1))
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            (matrix[j, col], matrix[j + 1, col]) = (matrix[j + 1, col], matrix[j, col]);
                        }
                    }
                }
            }
        }
        public void SortRowsByMaxDescending(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(0) - 1 - i; j++)
                {
                    if (GetRowMax(matrix, j) < GetRowMax(matrix, j + 1))
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            (matrix[j, col], matrix[j + 1, col]) = (matrix[j + 1, col], matrix[j, col]);
                        }
                    }
                }
            }
        }
        public int GetRowMax(int[,] matrix, int row)
        {
            int max = Int32.MinValue;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[row, i]  > max)
                {
                    max = matrix[row, i];
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
            int[] negatives = new int[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                        count++;
                }
                negatives[i] = count;
            }
            return negatives;
        }
        public int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            int[] negatives = new int[matrix.GetLength(1)];

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int max = int.MinValue;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] > max && matrix[i, j] < 0)
                        max = matrix[i, j];
                }
                if (max == int.MinValue)
                    negatives[j] = 0;
                else
                    negatives[j] = max;
            }
            return negatives;
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
            bool equal = true;
            for (int j = 1; j < matrix.GetLength(1); j++)
            {
                if (matrix[1, j] != matrix[1, j + 1])
                {
                    equal = false;
                    break;
                }
            }
            if (equal)
                return new int[0, 0];

            int seq = 0;
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                double y1 = matrix[1, j]; double y2 = matrix[1, j + 1];
                if (y1 < y2)
                {
                    seq = 1;
                    break;
                }
                else if (y1 > y2)
                {
                    seq = -1;
                    break;
                }
            }

            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                double y1 = matrix[1, j]; double y2 = matrix[1, j + 1];
                if (seq == 1)
                {
                    if (y1 > y2)
                        return new int[1, 1] { { 0 } };
                }
                else if (seq == -1)
                {
                    if (y1 < y2)
                        return new int[1, 1] { { 0 } };
                }
            }

            return new int[1, 1] { { seq } };
        }
        public int[,] FindAllSeq(int[,] matrix)
        {
            bool equal = true;
            for (int j = 1; j < matrix.GetLength(1); j++)
            {
                if (matrix[1, j] != matrix[1, j + 1])
                {
                    equal = false;
                    break;
                }
            }
            if (equal)
                return new int[0, 0];

            int count = 0;
            int seqPrevious = 0; int seqCurrent = 0;

            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                if (matrix[1, j] < matrix[1, j + 1])
                    seqCurrent = 1;
                else if (matrix[1, j] > matrix[1, j + 1])
                    seqCurrent = -1;

                if (seqCurrent != seqPrevious)
                {
                    count++;
                    seqPrevious = seqCurrent;
                }
                else if (seqPrevious == 0)
                {
                    seqPrevious = seqCurrent;
                }
            }

            int[,] all = new int[count, 2];
            int seqIndex = 0; int firstIndex = 0;

            seqPrevious = 0;
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                if (matrix[1, j] < matrix[1, j + 1])
                    seqCurrent = 1;
                else if (matrix[1, j] > matrix[1, j + 1])
                    seqCurrent = -1;

                if (seqPrevious == 0)
                {
                    seqPrevious = seqCurrent;
                    firstIndex = j;
                }
                else if (seqCurrent != seqPrevious)
                {

                    all[seqIndex, 0] = matrix[0, firstIndex];
                    all[seqIndex, 1] = matrix[0, j];
                    seqIndex++;

                    firstIndex = j;
                    seqPrevious = seqCurrent;
                }
            }

            all[seqIndex, 0] = matrix[0, firstIndex];
            all[seqIndex, 1] = matrix[0, matrix.GetLength(1) - 1];

            return all;
        }
        public int[,] FindLongestSeq(int[,] matrix)
        {
            int[,] all = FindAllSeq(matrix);

            if (all.GetLength(0) == 0)
                return new int[0, 0];

            int longestLen = all[0, 1] - all[0, 0];
            int longestIndex = 0;

            for (int i = 0; i < all.GetLength(0); i++)
            {
                int currentLen = all[i, 1] - all[i, 0];
                if (currentLen > longestLen)
                {
                    longestLen = currentLen;
                    longestIndex = i;
                }
            }
            return new int[1, 2] { { all[longestIndex, 0], all[longestIndex, 1] } };
        }

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
            double previous = func(a);
            int count = 0;

            for (double x = a + h; x <= b + 1e-9; x += h)
            {
                double current = func(x);
                if ((previous >= 0 && current < 0) || (previous <= 0 && current > 0))
                    count++;
                previous = current;
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


        public void Task10(int[][] array, Action<int[][]> func)
        {

            // code here
            func(array);
            // end

        }
        public void SortInCheckersOrder(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 == 0)
                    Array.Sort(array[i]);
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
                for (int i = 0; i < array.Length - 1 - k; i++)
                {
                    int sum1 = 0; int sum2 = 0;

                    for (int j = 0; j < array[i].Length; j++)
                        sum1 += array[i][j];

                    for (int j = 0; j < array[i + 1].Length; j++)
                        sum2 += array[i + 1][j];

                    if (sum1 < sum2)
                        (array[i], array[i + 1]) = (array[i + 1], array[i]);
                }
            }
        }
        public void TotalReverse(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Array.Reverse(array[i]);
            }
            Array.Reverse(array);
        }
    }
}
