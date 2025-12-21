using System;

namespace Lab6
{
    public class White
    {
        public int FindMaxIndex(double[] array)
        {
            if (array == null || array.Length == 0) return -1;
            
            int max_i = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > array[max_i])
                {
                    max_i = i;
                }
            }
            return max_i;
        }
        
        public void Task1(double[] A, double[] B)
        {
            int max_in_a = FindMaxIndex(A);
            int max_in_b = FindMaxIndex(B);
            if (max_in_a == -1 || max_in_b == -1) return;
            
            int distanceA = (A.Length - 1) - max_in_a;
            int distanceB = (B.Length - 1) - max_in_b;
            double[] targetArray = null;
            int targetIndex = -1;
            
            if (distanceA > distanceB)
            {
                targetArray = A;
                targetIndex = max_in_a;
            }
            else if (distanceB > distanceA)
            {
                targetArray = B;
                targetIndex = max_in_b;
            }
            else
            {
                targetArray = A;
                targetIndex = max_in_a;
            }
            if (targetIndex == targetArray.Length - 1)
                return;
            double sum = 0;
            int count = 0;
            for (int i = targetIndex + 1; i < targetArray.Length; i++)
            {
                sum += targetArray[i];
                count++;
            }
            
            if (count > 0)
                targetArray[targetIndex] = sum / count;
        }
        public int FindMaxRowIndexInColumn(int[,] matrix, int col)
        {
            if (matrix == null || matrix.GetLength(0) == 0) return -1;
            
            int max_i = 0;
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] > matrix[max_i, col])
                {
                    max_i = i;
                }
            }
            return max_i;
        }
        
        public void Task2(int[,] A, int[,] B)
        {
            if (A.GetLength(0) == B.GetLength(0) && A.GetLength(1) == B.GetLength(1))
            {
                int h_a = FindMaxRowIndexInColumn(A, 1);
                int h_b = FindMaxRowIndexInColumn(B, 1);
                if (h_a != -1 && h_b != -1)
                {
                    for (int j = 0; j < A.GetLength(1); j++)
                    {
                        (A[h_a, j], B[h_b, j]) = (B[h_b, j], A[h_a, j]);
                    }
                }
            }
        }
        public int[] GetNegativeCountPerRow(int[,] matrix)
        {
            if (matrix == null) return new int[0];
            
            int[] ans = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int cnt = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                        cnt++;
                }
                ans[i] = cnt;
            }
            return ans;
        }
        
        public int Task3(int[,] matrix)
        {
            int answer = -1;
            
            int[] row = GetNegativeCountPerRow(matrix);
            if (row.Length == 0) return -1;
            
            int maxi = 0;
            for (int i = 1; i < row.Length; i++)
            {
                if (row[i] > row[maxi])
                {
                    maxi = i;
                }
            }
            answer = maxi;
            
            return answer;
        }
        public int FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;
            
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
            {
                row = -1;
                col = -1;
                return 0;
            }
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[row, col])
                    {
                        row = i;
                        col = j;
                    }
                }
            }
            return matrix[row, col];
        }
        
        public void Task4(int[,] A, int[,] B)
        {
            int i_a, j_a, i_b, j_b;
            
            int maxi_a = FindMax(A, out i_a, out j_a);
            int maxi_b = FindMax(B, out i_b, out j_b);
            if (i_a != -1 && i_b != -1)
            {
                (A[i_a, j_a], B[i_b, j_b]) = (B[i_b, j_b], A[i_a, j_a]);
            }
        }
        public void SwapColumns(int[,] A, int colIndexA, int[,] B, int colIndexB)
        {
            if (colIndexA >= A.GetLength(1) || colIndexB >= B.GetLength(1))
                return;
            
            for (int i = 0; i < A.GetLength(0); i++)
            {
                (A[i, colIndexA], B[i, colIndexB]) = (B[i, colIndexB], A[i, colIndexA]);
            }
        }
        
        public void Task5(int[,] A, int[,] B)
        {
            if (A.GetLength(0) == B.GetLength(0))
            {
                int i_a, j_a, i_b, j_b;
                int max_A = FindMax(A, out i_a, out j_a);
                int max_B = FindMax(B, out i_b, out j_b);
                
                if (i_a != -1 && i_b != -1)
                {
                    SwapColumns(A, j_a, B, j_b);
                }
            }
        }
        public void Task6(int[,] matrix, Sorting sort)
        {
            if (matrix == null || sort == null) return;
            
            if (matrix.GetLength(0) == matrix.GetLength(1) && matrix.GetLength(0) > 0)
            {
                sort(matrix);
            }
        }
        public long Task7(int n, int k)
        {
            long answer = 0;
            
            // Проверки
            if (n < 0 || k < 0 || k > n) return 0;
            if (n > 20) return 0; )
            answer = Factorial(n) / (Factorial(k) * Factorial(n - k));
            
            return answer;
        }
        public double GetTime(double v, double a)
        {
            if (v <= 0 && a <= 0) return 0;
            
            double s = 0;
            double currentV = v;
            double time = 0;
            
            while (s < 100)
            {
                s += currentV;
                currentV += a;
                time += 1;
                
                if (time > 10000) break;
            }
            
            return time;
        }
        
        public double Task8(double v, double a, BikeRide ride)
        {
            double answer = 0;
            
            if (ride == null) return 0;
            answer = ride(v, a);
            
            return answer;
        }
        
        public int Task9(int[][] array)
        {
            int answer = 0;
            
            if (array == null) return 0;
            
            Swapper op;
            if (array.Length % 2 == 1)
                op = SwapFromRight;
            else
                op = SwapFromLeft;
            
            for (int i = 0; i < array.Length; ++i)
            {
                if (array[i] == null) continue;
                
                op(array[i]);
                answer += GetSum(array[i]);
            }
            
            return answer;
        }
        
        
        public int Task10(int[][] array, Func<int[][], int> func)
        {
            answer = func(array);
            
            return answer;
        }
    }
}
