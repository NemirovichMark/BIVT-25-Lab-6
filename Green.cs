using System.Linq;
using System.Runtime.InteropServices;

namespace Lab6
{
    public class Green
    {
        public void DeleteMaxElement(ref int[] array)
        {
            int maxii = 0;
            for (int i = 1; i < array.Length; ++i)
            {
                maxii = (array[i] > array[maxii] ? i : maxii);
            }
            int[] ans = new int[array.Length - 1];
            for (int i = 0; i < maxii; ++i)
            {
                ans[i] = array[i];
            }
            for (int i = maxii + 1; i < array.Length; ++i)
            {
                ans[i - 1] = array[i];
            }
            array = new int[ans.Length];
            array = ans;
        }

        public int[] CombineArrays(int[] A, int[] B)
        {
            int[] ans = new int[A.Length + B.Length];
            for (int i = 0; i < A.Length; ++i)
            {
                ans[i] = A[i];
            }
            for (int i = 0; i < B.Length; ++i)
            {
                ans[i + A.Length] = B[i];
            }
            return ans;
        }
        public void Task1(ref int[] A, ref int[] B)
        {

            // code here
            DeleteMaxElement(ref A);
            DeleteMaxElement(ref B);
            A = CombineArrays(A, B);
            // end

        }

        public int FindMaxInRow(int[,] matrix, int row, out int col)
        {
            int ans = matrix[row, 0];
            col = 0;
            for (int j = 1; j < matrix.GetLength(1); ++j)
            {
                if (ans < matrix[row, j])
                {
                    ans = matrix[row, j];
                    col = j;
                }
            }
            return ans;
        }
        public void Task2(int[,] matrix, int[] array)
        {

            // code here
            if (array.Length == matrix.GetLength(0))
            {
                for (int i = 0; i < matrix.GetLength(0); ++i)
                {
                    int maxij = 0;
                    int maxi = FindMaxInRow(matrix, i, out maxij);
                    if (array[i] > matrix[i, maxij])
                    {
                        matrix[i, maxij] = array[i];
                    }
                }
            }
            // end

        }

        public void FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    if (matrix[i, j] > matrix[row, col])
                    {
                        row = i;
                        col = j;
                    }
                }
            }
        }

        public void SwapColWithDiagonal(int[,] matrix, int col)
        {
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                (matrix[i, i], matrix[i, col]) = (matrix[i, col], matrix[i, i]);
            }
        }

        public void Task3(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                int i, j;
                FindMax(matrix, out i, out j);
                SwapColWithDiagonal(matrix, j);
            }
            // end

        }

        public void RemoveRow(ref int[,] matrix, int row)
        {
            int[,] ans = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            for (int i = 0; i < row; ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    ans[i, j] = matrix[i, j];
                }
            }
            for (int i = row + 1; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    ans[i - 1, j] = matrix[i, j];
                }
            }
            matrix = ans;
        }

        public void Task4(ref int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                bool t = false;
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    if (matrix[i, j] == 0)
                    {
                        t = true;
                    }
                }
                if (t == true)
                {
                    RemoveRow(ref matrix, i);
                    --i;
                }
            }
            // end

        }

        public int[] GetRowsMinElements(int[,] matrix)
        {
            int[] ans = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                int mini = matrix[i, i];
                for (int j = i + 1; j < matrix.GetLength(1); ++j)
                {
                    mini = Math.Min(mini, matrix[i, j]);
                }
                ans[i] = mini;
            }
            return ans;
        }

        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                answer = GetRowsMinElements(matrix);
           }
            // end

            return answer;
        }

        public int[] SumPositiveElementsInColumns(int[,] matrix)
        {
            int[] ans = new int[matrix.GetLength(1)];
            for (int j = 0; j < matrix.GetLength(1); ++j)
            {
                int sum = 0;
                for (int i = 0; i < matrix.GetLength(0); ++i)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                    }
                }
                ans[j] = sum;
            }
            return ans;
        }

        public int[] Task6(int[,] A, int[,] B)
        {
            int[] answer = null;

            // code here
            answer = new int[A.GetLength(0) + B.GetLength(0)];
            int[] A1 = SumPositiveElementsInColumns(A), B1 = SumPositiveElementsInColumns(B);
            answer = CombineArrays(A1, B1);
            // end

            return answer;
        }

        public delegate void Sorting(int[,] matrix);

        public void SortEndAscending(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                int maxi_j = 0;
                for (int j = 1; j < matrix.GetLength(1); ++j)
                {
                    if (matrix[i, j] > matrix[i, maxi_j])
                    {
                        maxi_j = j;
                    }
                }
                int[] b = new int[matrix.GetLength(1) - maxi_j - 1];
                for (int j = maxi_j + 1; j < matrix.GetLength(1); ++j)
                {
                    b[j - maxi_j - 1] = matrix[i, j];
                }
                Array.Sort(b);
                for (int j = maxi_j + 1; j < matrix.GetLength(1); ++j)
                {
                    matrix[i, j] = b[j - maxi_j - 1];
                }
            }
        }

        public void SortEndDescending(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                int maxi_j = 0;
                for (int j = 1; j < matrix.GetLength(1); ++j)
                {
                    if (matrix[i, j] > matrix[i, maxi_j])
                    {
                        maxi_j = j;
                    }
                }
                int[] b = new int[matrix.GetLength(1) - maxi_j - 1];
                for (int j = maxi_j + 1; j < matrix.GetLength(1); ++j)
                {
                    b[j - maxi_j - 1] = matrix[i, j];
                }
                Array.Sort(b);
                Array.Reverse(b);
                for (int j = maxi_j + 1; j < matrix.GetLength(1); ++j)
                {
                    matrix[i, j] = b[j - maxi_j - 1];
                }
            }
        }

        public void Task7(int[,] matrix, Sorting sort)
        {

            // code here
            sort(matrix);
            // end

        }

        public double GeronArea(double a, double b, double c)
        {
            double p = (a + b + c) / (double)2;
            if (p * (p - a) * (p - b) * (p - c) <= 0)
            {
                return 0;
            }
            double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return s;
        }

        public int Task8(double[] A, double[] B)
        {
            int answer = 0;

            // code here
            double ans1 = GeronArea(A[0], A[1], A[2]), ans2 = GeronArea(B[0], B[1], B[2]);
            if (ans1 > 0 || ans2 > 0)
            {
                answer = (ans1 > ans2 ? 1 : 2);
            }
            else
            {
                answer = 0;
            }
                // end

            return answer;
        }

        public delegate void Action(int[] array);

        public void ReplaceRow(int[,] matrix, int row, int[] array)
        {
            for (int j = 0; j < matrix.GetLength(1); ++j)
            {
                matrix[row, j] = array[j];
            }
        }

        public void SortMatrixRow(int[,] matrix, int row, Action<int[]> sorter)
        {
            int[] ans = new int[matrix.GetLength(1)];
            for (int j = 0; j < matrix.GetLength(1); ++j)
            {
                ans[j] = matrix[row, j];
            }
            sorter(ans);
            ReplaceRow(matrix, row, ans);
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

        public void Task9(int[,] matrix, Action<int[]> sorter)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i += 2)
            {
                SortMatrixRow(matrix, i, sorter);
            }
            // end

        }

        public delegate double Func(int[][] array);

        public double CountZeroSum(int[][] array)
        {
            double ans = 0;
            for (int i = 0; i < array.Length; ++i)
            {
                double sum = 0;
                for (int j = 0; j < array[i].Length; ++j)
                {
                    sum += array[i][j];
                }
                ans += (sum == 0) ? 1 : 0;
            }
            return ans;
        }

        public double FindMedian(int[][] array)
        {
            int ans = 0;
            for (int i = 0; i < array.Length; ++i)
            {
                ans += array[i].Length;
            }
            double[] ma = new double[ans];
            ans = 0;
            for (int i = 0; i < array.Length; ++i)
            {
                for (int j = 0; j < array[i].Length; ++j)
                {
                    ma[ans++] = array[i][j];
                }
            }
            Array.Sort(ma);
            if (ma.Length % 2 == 0)
            {
                double x = ma[ma.Length / 2] + ma[ma.Length / 2 - 1];
                return (double)(x / 2);
            }
            else
            {
                return ma[ma.Length / 2];
            }
        }

        public double CountLargeElements(int[][] array)
        {
            double ans = 0;
            for (int i = 0; i < array.Length; ++i)
            {
                double sr = 0;
                for (int j = 0; j < array[i].Length; ++j)
                {
                    sr += array[i][j];
                }
                sr /= array[i].Length;
                for (int j = 0; j < array[i].Length; ++j)
                {
                    if (array[i][j] > sr)
                    {
                        ++ans;
                    }
                }
            }
            return ans;
        }

        public double Task10(int[][] array, Func<int[][], double> func)
        {
            double res = 0;

            // code here
            res = func(array);
            // end

            return res;
        }
    }
    }