using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.IO.Pipelines;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public class Purple
    {
        public void Task1(int[,] A, int[,] B)
        {
            // code here
            int n_a = A.GetLength(0), n_b = B.GetLength(0), m_a = A.GetLength(1), m_b = B.GetLength(1);
            if ((n_a == m_a) && (n_b == m_b) && (n_a == n_b))
            {
                int ind_row_in_A = FindDiagonalMaxIndex(A);
                int ind_col_in_B = FindDiagonalMaxIndex(B);
                SwapRowColumn(A, ind_row_in_A, B, ind_col_in_B);
            }
            // end
        }

        public void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex)
        {
            for (int k = 0; k < matrix.GetLength(0); k++)
                {
                    (matrix[rowIndex, k], B[k, columnIndex]) = (B[k, columnIndex], matrix[rowIndex, k]);
                }
        }
        
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int mx = int.MinValue;
            int ind = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > mx)
                {
                    mx = matrix[i, i];
                    ind = i;
                }
                else if (matrix[matrix.GetLength(0) - i - 1, matrix.GetLength(0) - i - 1] > mx)
                {
                    mx = matrix[matrix.GetLength(0) - i - 1, matrix.GetLength(0) - i - 1];
                    ind = matrix.GetLength(0) - 1 - i;
                }
            }
            return ind;
        }

        public void Task2(ref int[,] A, int[,] B)
        {

            // code here
            if (A.GetLength(1) == B.GetLength(0))
            {
                int row_with_max_pos = -1;
                int col_with_max_pos = -1;
                int MaxPosRow = -1;
                int MaxPosCol = -1;
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    int temp_r = CountPositiveElementsInRow(A, i);
                    if (temp_r > MaxPosRow)
                    {
                        row_with_max_pos = i;
                        MaxPosRow = temp_r;
                    }
                }
                for (int j = 0 ; j < A.GetLength(1); j++)
                {
                    int temp_c = CountPositiveElementsInColumn(B, j);
                    if (temp_c > MaxPosCol)
                    {
                        MaxPosCol = temp_c;
                        col_with_max_pos = j;
                    }
                }
                if ((row_with_max_pos > -1) && (col_with_max_pos > -1))
                {
                    InsertColumn(ref A, row_with_max_pos, col_with_max_pos, B);
                }
            }
            // end

        }
        public int CountPositiveElementsInRow(int[,] matrix, int row)
            {
                int cnt = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[row, j] > 0)
                    {
                        cnt++;
                    }
                }
                return cnt;
            }
         public int CountPositiveElementsInColumn(int[,] matrix, int col)
            {
                int cnt = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, col] > 0)
                    {
                        cnt++;
                    }
                }
                return cnt;
            }

        public void InsertColumn (ref int[,] A, int rowIndex, int columnIndex, int[,] B)
        {
            int n = A.GetLength(0) + 1, m = A.GetLength(1);
            int[,] arr = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                if (rowIndex + 1 == i)
                {
                    for (int B_row = 0; B_row < B.GetLength(0); B_row++)
                    {
                        arr[i, B_row] = B[B_row, columnIndex];
                    }
                }
                else if (rowIndex + 1 < i)
                {
                    for (int j = 0; j < A.GetLength(1); j++)
                    {
                        arr[i, j] = A[i - 1, j];
                    }
                }
                else
                {
                    for (int j = 0; j < A.GetLength(1); j++)
                    {
                        arr[i, j] = A[i, j];

                    }
                 }
            }
            A = arr;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            if (matrix.Length >= 5)
            {
                ChangeMatrixValues(matrix);
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        matrix[i, j] *= 2;
                    }
                }
            }
        }
            // end
        public void ChangeMatrixValues(int[,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int[] OneDarr = new int[n * m];
            int k = 0;

            // from 2d to 1d
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    OneDarr[k++] = matrix[i, j];
                }
            }

            // sorting
            int[][] indexArr = new int[5][];
            for (int i = 0; i < n * m - 1; i++)
            {
                for (int j = 0; j < n * m - i - 1; j++)
                {
                    if (OneDarr[j] < OneDarr[j + 1])
                    {
                        (OneDarr[j], OneDarr[j + 1]) = (OneDarr[j + 1], OneDarr[j]);
                    }
                }
            }          
            for (int q = 0; q < 5; q++)
            {
                bool changed = false;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i, j] == OneDarr[q])
                        {
                            matrix[i, j] *= 2;
                            indexArr[q] = [i, j];
                            changed = true;
                            break;
                        }
                    }
                    if (changed)
                    {
                        break;
                    }
                }
            }  

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    bool changed = false;
                    for (int q = 0; q < 5; q++)
                    {
                        if (i == indexArr[q][0] && j == indexArr[q][1])
                        {
                            changed = true;
                            break;
                        }
                    }
                    if (!changed)
                    {
                        matrix[i, j] /= 2;
                    }
                }
            }
        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here
            int[] result_A = CountNegativesPerRow(A);
            int[] result_B = CountNegativesPerRow(B);
            if (!((result_A == null) || (result_B == null)))
            {
                int mx_ind_A = FindMaxIndex(result_A);
                int mx_ind_B = FindMaxIndex(result_B);
                if (A.GetLength(1) == B.GetLength(1))
                {
                    for (int j = 0; j < A.GetLength(1); j++)
                    {
                        (A[mx_ind_A, j], B[mx_ind_B, j]) = (B[mx_ind_B, j], A[mx_ind_A, j]);
                    }
                }
            }
            // end
        }

        public int[] CountNegativesPerRow(int[,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int[] result = new int[n];
            int total = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        result[i] += 1;
                        total++;
                    }
                }
            }
            if (total == 0)
            {
                return null;
            }
            return result;
        }

        public int FindMaxIndex(int[] array)
        {
            if (array != null)
            {
                int mx_ind = 0;
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[mx_ind] < array[i])
                    {
                        mx_ind = i;
                    }
                }
                return mx_ind;
            }
            return -1;
        }

        public void Task5(int[] matrix, Sorting sort)
        {

            // code here
            sort(matrix);
            // end

        }
        public void SortNegativeAscending(int[] matrix)
        {
            int n = matrix.Length;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i] < 0)
                {
                    int ind_mn = i;
                    for (int j = i + 1; j < n; j++)
                    {
                        if ((matrix[j] < 0) && (matrix[j] < matrix[ind_mn]))
                        {
                            ind_mn = j;
                        }
                    }
                    (matrix[ind_mn], matrix[i]) = (matrix[i], matrix[ind_mn]);
                }
            }
        }
        public void SortNegativeDescending(int[] matrix)
        {
            int n = matrix.Length;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i] < 0)
                {
                    int ind_mx = i;
                    for (int j = i + 1; j < n; j++)
                    {
                        if ((matrix[j] < 0) && (matrix[j] > matrix[ind_mx]))
                        {
                            ind_mx = j;
                        }
                    }
                    (matrix[ind_mx], matrix[i]) = (matrix[i], matrix[ind_mx]);
                }
            }
        }
        public delegate void Sorting(int[] matrix);
        public void Task6(int[,] matrix, SortRowsStyle sort)
        {

            // code here
            sort(matrix);
            // end

        }

        public delegate void SortRowsStyle(int[,] matrix);
        public void SortRowsByMaxAscending(int[,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (GetRowMax(matrix, j) > GetRowMax(matrix, j + 1))
                    {
                        for (int k = 0; k < m; k++)
                        {
                            (matrix[j, k], matrix[j + 1, k]) = (matrix[j + 1, k], matrix[j, k]);
                        }
                    }
                }
            }
        }
        public void SortRowsByMaxDescending(int[,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (GetRowMax(matrix, j) < GetRowMax(matrix, j + 1))
                    {
                        for (int k = 0; k < m; k++)
                        {
                            (matrix[j, k], matrix[j + 1, k]) = (matrix[j + 1, k], matrix[j, k]);
                        }
                    }
                }
            }
        }

         public int GetRowMax(int[,] matrix, int row)
        {
            int mx = int.MinValue;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > mx)
                {
                    mx = matrix[row, j];
                }
            }
            return mx;
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
            int[] result = new int[matrix.GetLength(0)];
            int cnt = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        cnt++;
                    }
                }
                result[i] = cnt;
                cnt = 0;
            }
        return result;
        }

        public int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            int[] result = new int[matrix.GetLength(1)];
            int max_neg = int.MinValue;
            bool changed = false;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if ((matrix[i, j] < 0) && (matrix[i, j] > max_neg))
                    {
                        max_neg = matrix[i, j];
                        changed = true;
                    }
                }

                if (changed)
                {
                    result[j] = max_neg;
                }
                else
                {
                    result[j] = 0;
                }
                max_neg = int.MinValue;
                changed = false;
            }
            return result;
        }
        public int[,] Task8(int[,] matrix, MathInfo info)
        {
            int[,] answer;
            // code here

            if (matrix.GetLength(1) == 1)
            {
                answer = new int[0, 0];
                return answer;
            }

            int cnt = 0;

            if (matrix[1, 0] == matrix[1, 1]) {cnt++;}

            for (int j = 1; j < matrix.GetLength(1) - 1; j++)
            {
                if (matrix[1, j] == matrix[1, j + 1])
                {
                    cnt++;
                }
            }
            if (cnt == matrix.GetLength(1) - 1)
            {
                answer = new int[0, 0];
                return answer;
            }

            return info(matrix);

            // end
        }


        public int[,] DefineSeq(int[,] matrix)
        {
            int[,] result = new int[0, 0];
            if (matrix.GetLength(0) == 1)
            {
                return result;
            }

            int cnt_pos = 0;
            int cnt_neg = 0;


            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                if (matrix[0, j] < matrix[0, j + 1])
                {
                    if (matrix[1, j] <= matrix[1, j + 1])
                    {
                        cnt_pos++;
                    }
                    else if (matrix[1, j] >= matrix[1, j + 1])
                    {
                        cnt_neg++;
                    }
                }
            }
            result = new int[1, 1];
            if (cnt_pos == matrix.GetLength(1) - 1)
            {
                result[0, 0] = 1;
            }
            else if (cnt_neg == matrix.GetLength(1) - 1)
            {
                result[0, 0] = -1;
            }
            else
            {
                result[0, 0] = 0;
            }
            return result;
        }
        public int[,] FindAllSeq(int[,] matrix)
        {
            if (matrix.GetLength(0) < 2 || matrix.GetLength(1) < 2) {return new int[0, 0];}
            int n = matrix.GetLength(1);

        int[,] tempArr = new int[n, 2];
        int cnt = 0;
    
        int start = 0;
        int sign = 0;    
        for (int i = 1; i < n; i++)
        {
            int last = matrix[1, i - 1];
            int cur = matrix[1, i];
            
            int temp;
            if (cur > last) 
                temp = 1;
            else if (cur < last) 
                temp = -1;
            else 
                temp = sign;
            
            if (sign != 0 && temp != sign)
            {
                tempArr[cnt, 0] = matrix[0, start];
                tempArr[cnt, 1] = matrix[0, i - 1];
                cnt++;
                start = i - 1;
                sign = temp;
            }
            
            if (sign == 0 && temp != 0)
            {
                sign = temp;
                if (start == 0 && i == 1)
                    start = 0;
            }
        }
        if (sign != 0 && start < n - 1)
        {
            tempArr[cnt, 0] = matrix[0, start];
            tempArr[cnt, 1] = matrix[0, n - 1];
            cnt++;
        }
        
        if (cnt == 0)
            return new int[0, 0];
        
        int[,] result = new int[cnt, 2];
        for (int i = 0; i < cnt; i++)
        {
            result[i, 0] = tempArr[i, 0];
            result[i, 1] = tempArr[i, 1];
        }
        
        return result;
    }       
        public int[,] FindLongestSeq(int[,] matrix)
    {
        int[,] seqs = FindAllSeq(matrix);
        
        if (seqs.GetLength(0) == 0)
            return new int[0, 0];
        
        int mxInd = 0, mxLn = 0;
        
        for (int i = 0; i < seqs.GetLength(0); i++)
        {
            int ln = Math.Abs(seqs[i, 1] - seqs[i, 0]);
            if (ln > mxLn)
            {
                mxLn = ln;
                mxInd = i;
            }
        }
        
        int[,] result = new int[1, 2];
        result[0, 0] = seqs[mxInd, 0];
        result[0, 1] = seqs[mxInd, 1];
        
        return result;
    }   

        public delegate int[,] MathInfo(int[,] matrix);
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
            int iterations = (int) Math.Abs((b - a) / h);
            int swaps = 0;
            if (iterations == 0)
            {
                return 0;
            }
            for (int i = 0; i < iterations; i++)
            {
                if (func(a) * func(a + h) < 0) {
                    swaps++;
                }
                a += h;
            }
            return swaps;
        }

        public delegate double Func(double x);
        
        public double FuncA(double x)
        {
            return x * x  - Math.Sin(x);
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
        public delegate void Action(int[][] array);

        public void SortInCheckersOrder(int[][] array)
        {
            int m = 0;
            for (int i = 0; i < array.Length; i += 2)
            {
                m = array[i].Length;
                for (int k = 0; k < m - 1; k++)
                {
                    for (int j = 0; j < m - 1 - k; j++)
                    {
                        if (array[i][j] > array[i][j + 1])
                        {
                            (array[i][j], array[i][j + 1]) = (array[i][j + 1], array[i][j]);
                        }
                    }
                }
            }
            for (int i = 1; i < array.Length; i += 2)
            {
                m = array[i].Length;
                for (int k = 0; k < m - 1; k++)
                {
                    for (int j = 0; j < m - 1 - k; j++)
                    {
                        if (array[i][j] < array[i][j + 1])
                        {
                            (array[i][j], array[i][j + 1]) = (array[i][j + 1], array[i][j]);
                        }
                    }
                }
            }
        }

        public void SortBySumDesc(int[][] array)
        {
            int n = array.Length;
            int[] sumArr = new int[n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    sumArr[i] += array[i][j];
                }
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (sumArr[j] < sumArr[j + 1])
                    {
                        (sumArr[j + 1], sumArr[j]) = (sumArr[j], sumArr[j + 1]);
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
        }

        public void TotalReverse(int[][] array)
        {
            int n = array.Length;
            for (int i = 0; i < (n + 1) / 2; i++)
            {
                for (int j = 0; j < array[i].Length / 2; j++)
                {
                    int opposite_j = array[i].Length - j - 1;
                    (array[i][j], array[i][opposite_j]) = (array[i][opposite_j], array[i][j]);
                }
                int opposite = n - i - 1;
                if (opposite != i)
                {
                    for (int j = 0; j < array[opposite].Length / 2; j++)
                    {
                        int opposite_j = array[opposite].Length - j - 1;
                        (array[opposite][j], array[opposite][opposite_j]) = (array[opposite][opposite_j], array[opposite][j]);
                    }
                    (array[i], array[opposite]) = (array[opposite], array[i]);
                }
            }
        }
    }
}