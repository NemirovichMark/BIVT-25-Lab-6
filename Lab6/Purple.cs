using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public class Purple
    {
        public void Task1(int[,] A, int[,] B)
        {

            //code here
            SwapRowColumn(A, FindDiagonalMaxIndex(A), B, FindDiagonalMaxIndex(B));
            //end

        }
        public void Task2(ref int[,] A, int[,] B)
        {

            // code here
            int row = -1, MaxPosAmount = -1, col = -1;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                if (CountPositiveElementsInRow(A, i) > MaxPosAmount)
                {
                    row = i;
                    MaxPosAmount = CountPositiveElementsInRow(A, i);
                }
            }
            MaxPosAmount = -1;
            for (int i = 0; i < B.GetLength(1); i++)
            {
                if (CountPositiveElementsInColumn(B, i) > MaxPosAmount)
                {
                    col = i;
                    MaxPosAmount = CountPositiveElementsInColumn(B, i);
                }
            }
            InsertColumn(ref A, row, col, B);
            // end

        }
        public void Task3(int[,] matrix)
        {

            //code here
            ChangeMatrixValues(matrix);
            //end

        }
        public void Task4(int[,] A, int[,] B)
        {

            //code here
            int Arow = FindMaxIndex(CountNegativesPerRow(A));
            int Brow = FindMaxIndex(CountNegativesPerRow(B));
            if (A.GetLength(1) == B.GetLength(1) && CountNegativesPerRow(A)[Arow] > 0 && CountNegativesPerRow(B)[Brow] > 0)
            {
                for (int i = 0; i < A.GetLength(1); i++)
                    (A[Arow, i], B[Brow, i]) = (B[Brow, i], A[Arow, i]);
            }
            //end

        }
        public void Task5(int[] matrix, Sorting sort)
        {

            // code here
            sort(matrix);
            // end

        }
        public void Task6(int[,] matrix, SortRowsByMax sort)
        {

            // code here
            sort(matrix);
            // end

        }
        public int[] Task7(int[,] matrix, FindNegatives find)
        {
            int[] negatives = null;

            // code here
            negatives = find(matrix);
            // end

            return negatives;
        }
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
        public int Task9(double a, double b, double h, Func<double, double> func)
        {
            int answer = 0;

            // code here
            answer = CountSignFlips(a, b, h, func);
            // end

            return answer;
        }
        public void Task10(int[][] array, Action<int[][]> func)
        {

            // code here
            func(array);
            // end

        }
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1))
                return -1;
            else
            {
                int MaxIndex = -1, MaxValue = Int32.MinValue;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, i] > MaxValue)
                    {
                        MaxIndex = i;
                        MaxValue = matrix[i, i];
                    }
                }
                return MaxIndex;
            }

        }
        public void SwapRowColumn(int[,] matrix, int RowIndex, int[,] B, int ColumnIndex)
        {
            if (matrix.GetLength(1) == B.GetLength(0))
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    (matrix[RowIndex, i], B[i, ColumnIndex]) = (B[i, ColumnIndex], matrix[RowIndex, i]);
                }
            }
        }
        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int counter = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[row, i] > 0)
                    counter++;
            }
            return counter;
        }
        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {
            int counter = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] > 0)
                    counter++;
            }
            return counter;
        }
        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B)
        {
            if (A.GetLength(1) == B.GetLength(0))
            {
                int[,] A_new = new int[A.GetLength(0) + 1, A.GetLength(1)];
                for (int i = 0; i < A.GetLength(0) + 1; i++)
                {
                    for (int j = 0; j < A.GetLength(1); j++)
                    {
                        if (i <= rowIndex)
                        {
                            A_new[i, j] = A[i, j];
                        }
                        else if (i == rowIndex + 1)
                        {
                            A_new[i, j] = B[j, columnIndex];
                        }
                        else
                        {
                            A_new[i, j] = A[i - 1, j];
                        }
                    }
                }
                A= A_new;
            }
        }
        private int min(int[] array, out int index)
        {
            index = -1;
            int minvalue = Int32.MaxValue;
            for (int i = 0; i< array.Length; i++)
            {
                if ((array[i] < minvalue))
                {
                    minvalue = array[i];
                    index = i;
                }
            }
            return minvalue;
            
        }
        public void ChangeMatrixValues(int[,] matrix)
        {
            int[] Max5Values = new int[5] { Int32.MinValue, Int32.MinValue, Int32.MinValue, Int32.MinValue, Int32.MinValue};
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int index = 0;
                    if (matrix[i,j] > min(Max5Values, out index))
                    {
                        Max5Values[index] = matrix[i,j];
                    }
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    for (int k =0; k< 5;k++)
                    {
                        if (matrix[i,j]==Max5Values[k])
                        {
                            matrix[i, j] *= 4;
                            Max5Values[k] = 0;
                            break;
                        }
                    }
                    matrix[i, j] /= 2;

                }
            }
        }
        private void BubbleSort(int[] array)
        {
            bool change = true;
            int sorttill = array.Length;
            while (change)
            {
                change = false;
                for (int i = 0; i < sorttill - 1; i++)
                {
                    if (array[i] < array[i + 1])
                    {
                        (array[i], array[i + 1]) = (array[i + 1], array[i]);
                        change = true;
                    }
                }
                sorttill--;
            }
        }
        public int[] CountNegativesPerRow(int[,] matrix)
        {
            int[] negatives = new int[matrix.GetLength(0)];
            for (int i = 0; i < negatives.Length; i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                        negatives[i]++;
                }
            }
            return negatives;
        }
        public int FindMaxIndex(int[] array)
        {
            int MaxIndex = -1, MaxValue = Int32.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > MaxValue)
                {
                    MaxIndex = i;
                    MaxValue = array[i];
                }
            }
            return MaxIndex;
        }
        public delegate void Sorting(int[] array);
        public void SortNegativeAscending(int[] matrix)
        {
            int negs = 0;
            foreach (int i in matrix)
            {
                if (i < 0)
                    negs++;
            }
            int[] sortfor = new int[negs];
            negs = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                    sortfor[negs++] = i;
            }
            bool change = true;
            while (change)
            {
                change = false;
                for (int i = 0; i < sortfor.Length - 1; i++)
                {
                    if (matrix[sortfor[i]] > matrix[sortfor[i + 1]])
                    {
                        (matrix[sortfor[i]], matrix[sortfor[i + 1]]) = (matrix[sortfor[i + 1]], matrix[sortfor[i]]);
                        change = true;
                    }
                }
            }
        }
        public void SortNegativeDescending(int[] matrix)
        {
            int negs = 0;
            foreach (int i in matrix)
            {
                if (i < 0)
                    negs++;
            }
            int[] sortfor = new int[negs];
            negs = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                    sortfor[negs++] = i;
            }
            bool change = true;
            while (change)
            {
                change = false;
                for (int i = 0; i < sortfor.Length - 1; i++)
                {
                    if (matrix[sortfor[i]] < matrix[sortfor[i + 1]])
                    {
                        (matrix[sortfor[i]], matrix[sortfor[i + 1]]) = (matrix[sortfor[i + 1]], matrix[sortfor[i]]);
                        change = true;
                    }
                }
            }
        }
        public int GetRowMax(int[,] matrix, int row)
        {
            int max = Int32.MinValue;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[row, i] > max)
                {
                    max = matrix[row, i];
                }
            }
            return max;
        }
        private void SwapRows(int[,] matrix, int row)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                (matrix[row, col], matrix[row + 1, col]) = (matrix[row + 1, col], matrix[row, col]);
            }
        }
        public delegate void SortRowsByMax(int[,] matrix);
        public void SortRowsByMaxAscending(int[,] matrix)
        {
            bool change = true;
            while (change)
            {
                change = false;
                for (int row = 0; row < matrix.GetLength(0) - 1; row++)
                {
                    if (GetRowMax(matrix, row) > GetRowMax(matrix, row + 1))
                    {
                        change = true;
                        SwapRows(matrix, row);
                    }
                }
            }
        }
        public void SortRowsByMaxDescending(int[,] matrix)
        {
            bool change = true;
            while (change)
            {
                change = false;
                for (int row = 0; row < matrix.GetLength(0) - 1; row++)
                {
                    if (GetRowMax(matrix, row) < GetRowMax(matrix, row + 1))
                    {
                        change = true;
                        SwapRows(matrix, row);
                    }
                }
            }
        }
        public delegate int[] FindNegatives(int[,] matrix);
        public int[] FindNegativeCountPerRow(int[,] matrix)
        {
            int[] answer = new int[matrix.GetLength(0)];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] < 0)
                        answer[row]++;
                }
            }
            return answer;
        }
        public int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            int[] answer = new int[matrix.GetLength(1)];
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    if (matrix[row, col] < 0 && (matrix[row, col] > answer[col] || answer[col] == 0))
                        answer[col] = matrix[row, col];
                }
            }
            return answer;
        }
        public delegate int[,] MathInfo(int[,] matrix);
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
        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
        {
            int sign = Math.Sign(func(a));
            int flips = 0;
            for (double i = a+h; i<=b+1e-6; i+=h)
            {
                if (Math.Sign(func(i)) == -1*sign)
                {
                    flips++;
                    sign = Math.Sign(func(i));
                }
            }
            return flips;
        }
        public double FuncA(double x)
        {
            return x*x-Math.Sin(x);
        }
        public double FuncB(double x)
        {
            return Math.Exp(x)-1;
        }
        private void Reverse(int[] array)
        {
            int left = 0;
            int right = array.Length - 1;
            while (left < right)
            {
                (array[left], array[right]) = (array[right], array[left]);
                left++;
                right--;
            }
        }
        public void SortInCheckersOrder(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                BubbleSort(array[i]);
                if (i % 2 == 0)
                    Reverse(array[i]);
            }
        }
        private int SumArray(int[] array)
        {
            int sum = 0;
            foreach (int i in array)
            {  sum += i; }
            return sum;
        }
        public void SortBySumDesc(int[][] array)
        {
            bool change = true;
            while (change)
            {
                change = false;
                for (int i = 0;i< array.Length-1;i++)
                {
                    if (SumArray(array[i])<SumArray(array[i+1]))
                    {
                        int[] temp = array[i];
                        array[i] = array[i+1];
                        array[i+1] = temp;
                        change = true;
                    }
                }
            }
        }
        public void TotalReverse(int[][] array)
        {
            for (int i = 0;i < array.Length;i++)
            {
                Reverse(array[i]);
            }
            int top = 0;
            int bottom = array.Length - 1;
            while (top < bottom)
            {
                int[] temp = array[top];
                array[top] = array[bottom];
                array[bottom] = temp;
                top++;
                bottom--;
            }
        }
    }
}
