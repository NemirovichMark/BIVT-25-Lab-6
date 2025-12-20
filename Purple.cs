using System;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;
//using System.Linq;

namespace Lab6
{
    public class Purple
    {
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int mx = matrix[0, 0];
            int ans = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > mx)
                {
                    mx = matrix[i, i];
                    ans = i;
                }
            }
            return ans;
        }
        public void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex)
        {
            int[] vs = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                vs[i] = matrix[rowIndex, i];
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[rowIndex, i] = B[i, columnIndex];
            }
            for (int i = 0; i < B.GetLength(0); i++)
            {
                B[i, columnIndex] = vs[i];
            }
        }
        public void Task1(int[,] A, int[,] B)
        {

            // code here
            if (A.GetLength(0) != B.GetLength(0))
            {
                return;
            }
            if (A.GetLength(1) != A.GetLength(0))
            {
                return;
            }
            if (B.GetLength(0) != B.GetLength(1))
            {
                return;
            }
            int rowIndex = FindDiagonalMaxIndex(A);
            int columnIndex = FindDiagonalMaxIndex(B);
            SwapRowColumn(A, rowIndex, B, columnIndex);
            // end

        }
        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int ans = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[row,i] > 0)
                {
                    ans++;
                }
            }
            return ans;
        }
        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {
            int ans = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] > 0)
                {
                    ans++;
                }
            }
            return ans;
        }
        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B)
        {
            int[,] v_A = new int[A.GetLength(0)+1, A.GetLength(1)];
            for (int i = 0; i <= rowIndex; i++)
            {
                for (int j = 0; j<A.GetLength(1); j++)
                {
                    v_A[i,j] = A[i, j];
                }
            }
            for (int i = 0;i<A.GetLength(1); i++)
            {
                v_A[rowIndex+1, i] = B[i, columnIndex];
            }
            for (int i = rowIndex+2; i<A.GetLength(0)+1; i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    v_A[i, j] = A[i-1, j];
                }
            }
            A = v_A;
        }

        public void Task2(ref int[,] A, int[,] B)
        {
            // code here
            if (A.GetLength(1) != B.GetLength(0)) return;

            int i_A = 0;
            int mx_A = 0;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                if (CountPositiveElementsInRow(A,i) > mx_A)
                {
                    i_A = i;
                    mx_A = CountPositiveElementsInRow(A, i);
                }
            }
            int i_B = -1;
            int mx_B = 0;
            for (int i = 0; i < B.GetLength(1); i++)
            {
                if (CountPositiveElementsInColumn(B,i) > mx_B)
                {
                    i_B = i;
                    mx_B = CountPositiveElementsInColumn(B, i);
                }
            }
            if (i_B == -1)
            {
                return;
            }
            InsertColumn(ref A, i_A, i_B, B);


            // end
        }

        public void ChangeMatrixValues(int[,] matrix)
        {
            int a = matrix.GetLength(0);
            int b = matrix.GetLength(1);
            int[] elems = new int[a * b];
            int ind = 0;
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    elems[ind++] = matrix[i, j];
                }
            }
            Array.Sort(elems);
            Array.Reverse(elems);

            if (elems.Length <= 5)
            {
                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < b; j++)
                    {
                        matrix[i, j] *= 2;
                    }
                }
            }
            else
            {
                for (int k = 0; k < 5; k++)
                {
                    bool f = false;
                    for (int i = 0; i < a; i++)
                    {
                        for (int j = 0; j < b; j++)
                        {
                            if (matrix[i, j] == elems[k])
                            {
                                matrix[i, j] *= 2;
                                f = true;
                                break;
                            }
                        }
                        if (f) break;
                    }
                }
                
                int[] elems2 = new int[elems.Length - 5];
                ind = 0;
                for (int i = 5; i < elems.Length; i++)
                {
                    elems2[ind++] = elems[i];
                }
                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < b; j++)
                    {
                        for (int k = 0; k < elems2.Length; k++)
                        {
                            if (matrix[i, j] == elems2[k])
                            {
                                matrix[i, j] /= 2; break;
                            }
                        }
                    }
                }
            }
        }
        public void Task3(int[,] matrix)
        {

            // code here
            ChangeMatrixValues(matrix);
            // end

        }
        public int[] CountNegativesPerRow(int[,] matrix)
        {
            int[] ans = new int[matrix.GetLength(0)];
            
            for (int i = 0; i<matrix.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j<matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0) count++;
                
                }
                ans[i] = count;
            }
            return ans;
        }
        public int FindMaxIndex(int[] array)
        {
            if (array.Sum() == 0) return -1;
            int max = array[0];
            int ans = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    ans = i;
                }
            }
            return ans;
        }

        public void Task4(int[,] A, int[,] B)
        {

            // code here
            if (A.GetLength(1) != B.GetLength(1)) return;
            int i_A = FindMaxIndex(CountNegativesPerRow(A));
            int i_B = FindMaxIndex(CountNegativesPerRow(B));
            if (i_A == -1 || i_B == -1) return;
            else
            {
                int[] vs = new int[A.GetLength(1)];
                for (int i = 0; i<B.GetLength(1); i++)
                {
                    vs[i] = B[i_B, i];
                }
                for (int i = 0; i < B.GetLength(1); i++)
                {
                    B[i_B, i] = A[i_A, i] ;
                }
                for (int i = 0; i < B.GetLength(1); i++)
                {
                    A[i_A, i] = vs[i];
                }
            }
            // end

        }

        public delegate void Sorting(int[] matrix);
        public void SortNegativeAscending(int[] matrix)
        {
            int count = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0) {
                    count++;
                }
            }
            int[] arr = new int[count];
            int ind = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    arr[ind++] = matrix[i];
                }
            }
            Array.Sort(arr);
            ind = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    matrix[i] = arr[ind++];
                }
            }
        }
        public void SortNegativeDescending(int[] matrix)
        {
            int count = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    count++;
                }
            }
            int[] arr = new int[count];
            int ind = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    arr[ind++] = matrix[i];
                }
            }
            Array.Sort(arr);
            Array.Reverse(arr);
            ind = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    matrix[i] = arr[ind++];
                }
            }
        }

        public void Task5(int[] matrix, Sorting sort)
        {

            // code here
            sort(matrix);
            // end
        }













        public delegate void SortRowsByMax(int[,] matrix);
        public int GetRowMax(int[,] matrix, int row)
        {
            int max = -10000;
            for (int i = 0; i < matrix.GetLength(1); i++) 
            { 
                if (matrix[row,i] > max) max = matrix[row,i];
            }
            return max;
        }
        public void SortRowsByMaxAscending(int[,] matrix)
        {
            for (int i = 0; i<matrix.GetLength(0)-1; i++)
            {
                for (int j = 0; j < matrix.GetLength(0) - i - 1; j++)
                {
                    if (GetRowMax(matrix, j) > GetRowMax(matrix, j + 1))
                    {
                        for (int k = 0; k< matrix.GetLength(1); k++)
                        {
                            (matrix[j, k], matrix[j + 1, k]) = (matrix[j + 1, k], matrix[j, k]);
                        }
                    }
                }
            }
        }
        public void SortRowsByMaxDescending(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(0) - i - 1; j++)
                {
                    if (GetRowMax(matrix, j) < GetRowMax(matrix, j + 1))
                    {
                        for (int k = 0; k < matrix.GetLength(1); k++)
                        {
                            (matrix[j, k], matrix[j + 1, k]) = (matrix[j + 1, k], matrix[j, k]);
                        }
                    }
                }
            }
        }
        public void Task6(int[,] matrix, SortRowsByMax sort)
        {
            sort(matrix);
        }


        




        public delegate int[] FindNegatives (int[,] matrix);
        public int[] FindNegativeCountPerRow(int[,] matrix)
        {
            int[] ans = new int[matrix.GetLength(0)];
            for (int i = 0; i<matrix.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0;j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0) count++;
                }
                ans[i] = count;
            }
            return ans;
        }
        public int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            int[] ans = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int mx = -1000000;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] > mx && matrix[j, i] < 0)
                    {
                        mx = matrix[j, i];
                    }
                }
                if (mx == -1000000) ans[i] = 0;
                else ans[i] = mx;
            }
            return ans;
        }

        public int[] Task7(int[,] matrix, FindNegatives find)
        {
            int[] negatives = null;

            // code here
            negatives = find(matrix);
            // end

            return negatives;
        }






        public delegate int[,] MathInfo(int[,] matrix);

        public int[,] DefineSeq(int[,] matrix)
        {
            bool hasIncrease = false;  
            bool hasDecrease = false; 

            for (int i = 1; i < matrix.GetLength(1); i++)
            {
                if (matrix[1, i] > matrix[1, i - 1]) hasIncrease = true;
                else if (matrix[1, i] < matrix[1, i - 1]) hasDecrease = true;
            }
            if (!hasIncrease && !hasDecrease) return new int[,] { };
            if (!hasDecrease) return new int[,] { { 1 } };
            if (!hasIncrease) return new int[,] { { -1 } };

            return new int[,] { { 0 } };
        }
        public int[,] FindAllSeq(int[,] matrix)
        {
            int cols = matrix.GetLength(1);

            if (cols < 2) return new int[,] { };

            int count = 0;
            int direction = 0;

            for (int i = 1; i < cols; i++)
            {
                int currentDir;
                if (matrix[1, i] > matrix[1, i - 1]) currentDir = 1;
                else if (matrix[1, i] < matrix[1, i - 1]) currentDir = -1;
                else currentDir = direction;

                if (direction == 0)
                {
                    direction = currentDir;
                }
                else if (currentDir != 0 && currentDir != direction)
                {
                    count++;
                    direction = currentDir;
                }
            }
            if (direction != 0) count++;

            if (count == 0) return new int[,] { };


            int[,] result = new int[count, 2];
            int index = 0;
            int start = 0;
            direction = 0;

            for (int i = 1; i < cols; i++)
            {
                int currentDir;
                if (matrix[1, i] > matrix[1, i - 1]) currentDir = 1;
                else if (matrix[1, i] < matrix[1, i - 1]) currentDir = -1;
                else currentDir = direction;

                if (direction == 0)
                {
                    direction = currentDir;
                }
                else if (currentDir != 0 && currentDir != direction)
                {
                    result[index, 0] = matrix[0, start];
                    result[index, 1] = matrix[0, i - 1];
                    index++;
                    start = i - 1;
                    direction = currentDir;
                }
            }


            if (index < count)
            {
                result[index, 0] = matrix[0, start];
                result[index, 1] = matrix[0, cols - 1];
            }

            return result;
        }

        public int[,] FindLongestSeq(int[,] matrix)
        {
            int[,] allIntervals = FindAllSeq(matrix);

            if (allIntervals.GetLength(0) == 0) return new int[,] { };

            int maxLength = 0;
            int maxStart = 0;
            int maxEnd = 0;

            for (int i = 0; i < allIntervals.GetLength(0); i++)
            {
                int length = allIntervals[i, 1] - allIntervals[i, 0];
                if (length > maxLength)
                {
                    maxLength = length;
                    maxStart = allIntervals[i, 0];
                    maxEnd = allIntervals[i, 1];
                }
            }

            return new int[,] { { maxStart, maxEnd } };
        }
        public int[,] Task8(int[,] matrix, MathInfo info)
        {
            int[,] answer = null;

            // code here
            answer = info(matrix);
            // end

            return answer;
        }


        public double FuncA(double x)
        {
            return x * x - Math.Sin(x);
        }
        public double FuncB(double x)
        {
            return Math.Exp(x) - 1;
        }
        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
        {
            int count = 0;
            double k = func(a);
            for (double i = a+h; i<=b; i += h)
            {
                if (func(i) * k < 0) count++;
                else if (func(i) == 0) continue;
                k = func(i);
            }
            return count;
        }
        public int Task9(double a, double b, double h, Func<double, double> func)
        {
            int answer = 0;

            // code here
            answer = CountSignFlips(a, b, h, func);
            // end

            return answer;
        }




        public void SortInCheckersOrder(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 != 0)
                {
                    Array.Sort(array[i]);
                    Array.Reverse(array[i]);
                }
                else
                {
                    Array.Sort(array[i]);
                }
            }
        }
        public int Sum(int[] array)
        {
            int ans = 0;
            for (int i = 0; i<array.Length; i++)
            {
                ans += array[i];
            }
            return ans;
        }
        public void SortBySumDesc(int[][] array)
        { 
            for (int i = 0; i< array.Length; i++)
            {
                for (int j = 0; j<array.Length-i-1; j++)
                {
                    if (Sum(array[j]) < Sum(array[j+1]))
                    {
                        (array[j + 1], array[j]) = (array[j], array[j + 1]);
                    }
                }
            }
        }
        public void TotalReverse(int[][] array)
        {

            for (int i = 0; i < array.Length; i++)
            {
                Reverse(array[i]);
            }

            for (int i = 0; i < array.Length / 2; i++)
            {
                (array[i], array[array.Length - 1 - i]) = (array[array.Length - 1 - i], array[i]);
            }
        }

        private void Reverse(int[] arr)
        {
            for (int i = 0; i < arr.Length / 2; i++)
            {
                (arr[i], arr[arr.Length - 1 - i]) = (arr[arr.Length - 1 - i], arr[i]);
            }
        }
        public void Task10(int[][] array, Action<int[][]> func)
        {

            // code here
            func(array);
            // end

        }
    }
}
