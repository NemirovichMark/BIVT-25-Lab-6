using System;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public delegate void Sorting(int[] array);

    public delegate void SortRowsByMax(int[,] matrix);

    public delegate int[] FindNegatives(int[,] matrix);

    public delegate int[,] MathInfo(int[,] matrix);
    
    public class Purple
    {
        public void Task1(int[,] A, int[,] B)
        {

            // code here

            if (A.GetLength(0) != A.GetLength(1) || B.GetLength(0) != B.GetLength(1) || A.Length != B.Length) return;

            SwapRowColumn(A, FindDiagonalMaxIndex(A), B, FindDiagonalMaxIndex(B));
            // end

        }

        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int imax = 0;
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > matrix[imax, imax])
                {
                    imax = i;
                }
            }

            return imax;
        }

        public void SwapRowColumn(int[,] A, int rowIndexA, int[,] B, int colIndexB)
        {
            if (A.GetLength(0) != A.GetLength(1) || B.GetLength(0) != B.GetLength(1) || A.Length != B.Length) return;

            for (int i = 0; i < A.GetLength(0); i++)
            {
                (A[rowIndexA, i], B[i, colIndexB]) = (B[i, colIndexB], A[rowIndexA, i]);
            }
        }

        public void Task2(ref int[,] A, int[,] B)
        {

            // code here

            if (A.GetLength(1) != B.GetLength(0)) return;

            int imax_row_count_pos_elems = 0, max_row_count_pos_elems = 0;
            
            for (int i = 0; i < A.GetLength(0); i++)
            {
                int count = CountPositiveElementsInRow(A, i);

                if (count > max_row_count_pos_elems)
                {
                    max_row_count_pos_elems = count;
                    imax_row_count_pos_elems = i;
                }
            }

            int imax_col_count_pos_elems = 0, max_col_count_pos_elems = 0;
            
            for (int j = 0; j < B.GetLength(1); j++)
            {
                int count = CountPositiveElementsInColumn(B, j);

                if (count > max_col_count_pos_elems)
                {
                    max_col_count_pos_elems = count;
                    imax_col_count_pos_elems = j;
                }
            }

            if (max_col_count_pos_elems == 0) return;

            InsertColumn(ref A, imax_row_count_pos_elems, imax_col_count_pos_elems, B);
            // end

        }

        public void InsertColumn(ref int[,] A, int rowAfter, int colIndexB, int[,] B)
        {
            int[,] C = new int[A.GetLength(0) + 1, A.GetLength(1)];
            rowAfter += 1;

            for (int i = 0; i < C.GetLength(0); i++)
            {
                if (i < rowAfter)
                {
                    for (int j = 0; j < C.GetLength(1); j++)
                    {
                        C[i, j] = A[i, j];
                    }
                } else if (i == rowAfter)
                {
                    for (int j = 0; j < C.GetLength(1); j++)
                    {
                        C[i, j] = B[j, colIndexB];
                    }
                } else
                {
                    for (int j = 0; j < C.GetLength(1); j++)
                    {
                        C[i, j] = A[i - 1, j];
                    }
                }
            }

            A = C;
        }

        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int count = 0;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > 0)
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

        public void Task3(int[,] matrix)
        {

            // code here

            ChangeMatrixValues(matrix);
            // end

        }

        public void ChangeMatrixValues(int[,] A)
        {
            if (A == null || A.Length == 0) return;

            if (A.Length <= 5)
            {
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    for (int j = 0; j < A.GetLength(1); j++)
                    {
                        A[i, j] *= 2;
                    }
                }

                return;
            }

            int[] val = new int[A.Length];
            int[] pos = new int[A.Length];
            int k = 0;

            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    val[k] = A[i, j];
                    pos[k] = k;
                    k++;
                }
            }

            for (int i = 0; i < val.Length - 1; i++)
            {
                for (int j = 0; j < val.Length - 1 - i; j++)
                {
                    if (val[j] < val[j + 1] || (val[j] == val[j + 1] && pos[j] > pos[j + 1]))
                    {
                        (val[j], val[j + 1]) = (val[j + 1], val[j]);
                        (pos[j], pos[j + 1]) = (pos[j + 1], pos[j]);
                    }
                }
            }

            bool[] top = new bool[A.Length];
            for (int i = 0; i < 5; i++)
            {
                top[pos[i]] = true;
            }

            int c = 0;
        
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    if (top[c])
                    {
                        A[i, j] *= 2;
                    } else
                    {
                        A[i, j] /= 2;
                    }
                    c++;
                }
            }
        }

        public void Task4(int[,] A, int[,] B)
        {
            if (A.GetLength(1) != B.GetLength(1)) return;

            int[] negA = CountNegativesPerRow(A);
            int[] negB = CountNegativesPerRow(B);

            bool hasNegA = false, hasNegB = false;

            for (int i = 0; i < negA.Length; i++)
                if (negA[i] > 0) hasNegA = true;

            for (int i = 0; i < negB.Length; i++)
                if (negB[i] > 0) hasNegB = true;

            if (!hasNegA || !hasNegB) return;

            int rowA = FindMaxIndex(negA);
            int rowB = FindMaxIndex(negB);

            for (int j = 0; j < A.GetLength(1); j++)
                (A[rowA, j], B[rowB, j]) = (B[rowB, j], A[rowA, j]);
        }

        public int[] CountNegativesPerRow(int[,] matrix)
        {
            int[] array = new int[matrix.GetLength(0)];
            int k = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int count = 0;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        count++;
                    }
                }

                array[k++] = count;
            }

            return array;
        }
        public int FindMaxIndex(int[] arr)
        {
            int imax = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > arr[imax])
                {
                    imax = i;
                }
            }

            return imax;
        }
        public void Task5(int[] matrix, Sorting sort)
        {

            // code here
            // end

            sort(matrix);
        }

        public delegate void Sorting(int[] matrix);

        public void SortNegativeAscending(int[] matrix)
        {
            int how_many_neg = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i] < 0)
                {
                    how_many_neg++;
                }
            }

            int[] neg = new int[how_many_neg];
            int k = 0;
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i] < 0)
                {
                    neg[k++] = matrix[i];
                }
            }

            for (int i = 0; i < neg.Length - 1; i++)
            {
                for (int j = 0; j < neg.Length - 1 - i; j++)
                {
                    if (neg[j] > neg[j + 1])
                    {
                        (neg[j], neg[j + 1]) = (neg[j + 1], neg[j]);
                    }
                }
            }

            k = 0;
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i] < 0)
                {
                    matrix[i] = neg[k++];
                }
            }
        }
        public void SortNegativeDescending(int[] matrix)
        {
            int how_many_neg = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i] < 0)
                {
                    how_many_neg++;
                }
            }

            int[] neg = new int[how_many_neg];
            int k = 0;
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i] < 0)
                {
                    neg[k++] = matrix[i];
                }
            }

            for (int i = 0; i < neg.Length - 1; i++)
            {
                for (int j = 0; j < neg.Length - 1 - i; j++)
                {
                    if (neg[j] < neg[j + 1])
                    {
                        (neg[j], neg[j + 1]) = (neg[j + 1], neg[j]);
                    }
                }
            }

            k = 0;
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i] < 0)
                {
                    matrix[i] = neg[k++];
                }
            }
        }
        public void Task6(int[,] matrix, SortRowsByMax sort)
        {

            // code here
            // end

            sort(matrix);
        }

        public delegate void SortRowsByMax(int[,] matrix);

        public void SortRowsByMaxAscending(int[,] matrix)
        {
            int[] array = new int[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                array[i] = GetRowMax(matrix, i);
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);

                        for (int k = 0; k < matrix.GetLength(1); k++)
                        {
                            (matrix[j, k], matrix[j + 1, k]) = (matrix[j + 1, k], matrix[j, k]);
                        }
                    }
                }
            }
        }
        public void SortRowsByMaxDescending(int[,] matrix)
        {
            int[] array = new int[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                array[i] = GetRowMax(matrix, i);
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] < array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);

                        for (int k = 0; k < matrix.GetLength(1); k++)
                        {
                            (matrix[j, k], matrix[j + 1, k]) = (matrix[j + 1, k], matrix[j, k]);
                        }
                    }
                }
            }
        }
        public int GetRowMax(int[,] matrix, int rowIndex)
        {
            int max = matrix[rowIndex, 0];

            for (int j = 1; j < matrix.GetLength(1); j++)
            {
                max = Math.Max(max, matrix[rowIndex, j]);
            }

            return max;
        }
        public int[] Task7(int[,] matrix, FindNegatives find)
        {
            int[] negatives = null;

            // code here

            negatives = find(matrix);
            // end

            return negatives;
        }

        public delegate int[] FindNegatives(int[,] matrix);

        public int[] FindNegativeCountPerRow(int[,] matrix)
        {
            int[] array = new int[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int count = 0;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        count++;
                    }
                }

                array[i] = count;
            }

            return array;
        }
        public int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            int[] array = new int[matrix.GetLength(1)];

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int max = 0;

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] < 0 && max == 0)
                    {
                        max = matrix[i, j];
                    } else if (max < 0 && matrix[i, j] < 0 && matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }

                array[j] = max;
            }

            return array;
        }
        public int[,] Task8(int[,] matrix, MathInfo info)
        {
            int[,] answer = null;

            // code here

            answer = info(matrix);
            // end

            return answer;
        }

        public delegate int[,] MathInfo(int[,] matrix);

        public int[,] DefineSeq(int[,] matrix)
        {
            bool mon_ass = true, mon_des = true;

            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                if (matrix[1, j] < matrix[1, j + 1])
                {
                    mon_des = false;
                }
                if (matrix[1, j] > matrix[1, j + 1])
                {
                    mon_ass = false;
                }
            }

            if (mon_ass && mon_des)
            {
                return new int[0, 0];
            } else if (mon_ass)
            {
                return new int[,] { { 1 } };
            } else if (mon_des)
            {
                return new int[,] { { -1 } };
            } else
            {
                return new int[,] { { 0 } };
            }
        }
        public int[,] FindAllSeq(int[,] matrix)
        {
            int n = matrix.GetLength(1);
            if (n <= 1) return new int[0, 0];

            bool allEqual = true;
            for (int j = 0; j < n - 1; j++)
            {
                if (matrix[1, j] != matrix[1, j + 1])
                {
                    allEqual = false;
                    break;
                }
            }
            if (allEqual) return new int[0, 0];

            int count = 0;
            int trend = 0;
            for (int j = 0; j < n - 1; j++)
            {
                int dy = matrix[1, j + 1] - matrix[1, j];
                if (dy == 0) continue;

                int newTrend = dy > 0 ? 1 : -1;

                if (trend == 0)
                {
                    trend = newTrend;
                    count = 1;
                }
                else if (newTrend != trend)
                {
                    count++;
                    trend = newTrend;
                }
            }

            int[,] result = new int[count, 2];

            int idx = 0;
            int startIndex = 0;
            trend = 0;

            for (int j = 0; j < n - 1; j++)
            {
                int dy = matrix[1, j + 1] - matrix[1, j];
                if (dy == 0) continue;

                int newTrend = dy > 0 ? 1 : -1;

                if (trend == 0)
                {
                    trend = newTrend;
                }
                else if (newTrend != trend)
                {
                    result[idx, 0] = matrix[0, startIndex];
                    result[idx, 1] = matrix[0, j];
                    idx++;

                    startIndex = j;
                    trend = newTrend;
                }
            }

            result[idx, 0] = matrix[0, startIndex];
            result[idx, 1] = matrix[0, n - 1];

            return result;
        }

        public int[,] FindLongestSeq(int[,] matrix)
        {
            int[,] all = FindAllSeq(matrix);
            int rows = all.GetLength(0);
            if (rows == 0) return new int[0, 0];

            int best = 0;
            int bestLen = all[0, 1] - all[0, 0];

            for (int i = 1; i < rows; i++)
            {
                int len = all[i, 1] - all[i, 0];
                if (len > bestLen)
                {
                    bestLen = len;
                    best = i;
                }
            }

            return new int[,] { { all[best, 0], all[best, 1] } };
        }
        public int Task9(double a, double b, double h, Func<double, double> func)
        {
            int answer = 0;

            // code here

            answer = CountSignFlips(a, b, h, func);
            // end

            return answer;
        }

        public delegate double Func (double x);

        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
        {
            int count = 0;

            double y1 = func(a);

            for (double x = a; x + h <= b; x += h)
            {
                double y2 = func(x + h);

                if (y1 * y2 < 0)
                {
                    count++;
                }

                y1 = y2;
            }

            return count;
        }
        public double FuncA(double x)
        {
            return x * x - Math.Sin(x);
        }
        public double FuncB(double x)
        {
            return Math.Pow(Math.E, x) - 1;
        }
        public void Task10(int[][] array, Action<int[][]> func)
        {

            // code here

            func(array);
            // end

        }

        public void SortInCheckersOrder(int[][] array)
        {
            for (int row = 0; row < array.Length; row++)
            {
                if (row % 2 == 0)
                {
                    Array.Sort(array[row]);  
                } else
                {
                    Array.Sort(array[row], (x, y) => y.CompareTo(x));
                }
            }
        }
        public void SortBySumDesc(int[][] array)
        {
            if (array == null) return;

            int Sum(int[] r)
            {
                int s = 0;
                for (int i = 0; i < r.Length; i++) s += r[i];
                return s;
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (Sum(array[j]) < Sum(array[j + 1]))
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }


        public void TotalReverse(int[][] array)
        {
            Array.Reverse(array);
            for (int i = 0; i < array.Length; i++)
                Array.Reverse(array[i]);
        }

    }
}
