using System;

namespace Lab6
{
    public class Green
    {
        public void Task1(ref int[] A, ref int[] B)
        {
            // code here
            if (A == null || B == null) return;

            DeleteMaxElement(ref A);
            DeleteMaxElement(ref B);
            A = CombineArrays(A, B);
            // end
        }

        public void DeleteMaxElement(ref int[] array)
        {
            if (array == null || array.Length == 0) return;

            int ind = 0;
            int m = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > m)
                {
                    m = array[i];
                    ind = i;
                }
            }

            int[] array1 = new int[array.Length - 1];
            for (int i = 0; i < array1.Length; i++)
            {
                if (i < ind)
                    array1[i] = array[i];
                else
                    array1[i] = array[i + 1];
            }

            array = array1;
        }

        public int[] CombineArrays(int[] A, int[] B)
        {
            if (A == null || B == null) return null;

            int[] arrayAB = new int[A.Length + B.Length];

            for (int i = 0; i < A.Length; i++)
                arrayAB[i] = A[i];

            int k = 0;
            for (int i = A.Length; i < arrayAB.Length; i++)
            {
                arrayAB[i] = B[k];
                k++;
            }

            return arrayAB;
        }

        public void Task2(int[,] matrix, int[] array)
        {
            // code here
            if (array == null || matrix == null) return;
            if (array.Length != matrix.GetLength(0)) return;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int j;
                int m = FindMaxInRow(matrix, i, out j);
                if (m < array[i])
                {
                    matrix[i, j] = array[i];
                }
            }
            // end
        }

        public int FindMaxInRow(int[,] matrix, int row, out int col)
        {
            col = 0;
            int max = int.MinValue;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > max)
                {
                    max = matrix[row, j];
                    col = j;
                }
            }

            return max;
        }

        public void Task3(int[,] matrix)
        {
            // code here
            if (matrix == null) return;
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;

            int row, col;
            FindMax(matrix, out row, out col);
            SwapColWithDiagonal(matrix, col);
            // end
        }

        public void FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;

            int max = int.MinValue;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
        }

        public void SwapColWithDiagonal(int[,] matrix, int col)
        {
            if (matrix == null) return;
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            if (col < 0 || col >= matrix.GetLength(1)) return;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int q = matrix[i, i];
                matrix[i, i] = matrix[i, col];
                matrix[i, col] = q;
            }
        }

        public void Task4(ref int[,] matrix)
        {
            // code here
            if (matrix == null) return;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                bool op = false;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        op = true;
                        break;
                    }
                }

                if (op)
                {
                    RemoveRow(ref matrix, i);
                    i--; 
                }
            }
            // end
        }

        public void RemoveRow(ref int[,] matrix, int row)
        {
            if (matrix == null) return;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (row < 0 || row >= rows) return;
            if (rows <= 1)
            {
                matrix = new int[0, cols];
                return;
            }

            int[,] array = new int[rows - 1, cols];

            for (int i = 0, k = 0; i < rows; i++)
            {
                if (i == row) continue;

                for (int j = 0; j < cols; j++)
                    array[k, j] = matrix[i, j];

                k++;
            }

            matrix = array;
        }

        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            if (matrix == null) return null;
            if (matrix.GetLength(0) != matrix.GetLength(1)) return null;

            answer = GetRowsMinElements(matrix);
            // end

            return answer;
        }

        public int[] GetRowsMinElements(int[,] matrix)
        {
            if (matrix == null) return null;

            int[] array = new int[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int min = int.MaxValue;

                for (int j = i; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min)
                        min = matrix[i, j];
                }

                array[i] = min;
            }

            return array;
        }

        public int[] Task6(int[,] A, int[,] B)
        {
            int[] answer = null;

            // code here
            if (A == null || B == null) return null;

            int[] arrayA = SumPositiveElementsInColumns(A);
            int[] arrayB = SumPositiveElementsInColumns(B);
            answer = CombineArrays(arrayA, arrayB);
            // end

            return answer;
        }

        public int[] SumPositiveElementsInColumns(int[,] matrix)
        {
            if (matrix == null) return null;

            int[] massivSUM = new int[matrix.GetLength(1)];

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int s = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] > 0)
                        s += matrix[i, j];
                }
                massivSUM[j] = s;
            }

            return massivSUM;
        }

        public delegate void Sorting(int[,] matrix);

        public void Task7(int[,] matrix, Sorting sort)
        {
            // code here
            if (matrix == null || sort == null) return;
            sort(matrix);
            // end
        }

        public void SortEndAscending(int[,] matrix)
        {
            if (matrix == null) return;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = matrix[i, 0];
                int jj = 0;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        jj = j;
                    }
                }

                if (jj == matrix.GetLength(1) - 1) continue;

                for (int k = jj + 1; k < matrix.GetLength(1) - 1; k++)
                {
                    for (int j = jj + 1; j < matrix.GetLength(1) - 1; j++)
                    {
                        if (matrix[i, j] > matrix[i, j + 1])
                        {
                            (matrix[i, j], matrix[i, j + 1]) = (matrix[i, j + 1], matrix[i, j]);
                        }
                    }
                }
            }
        }

        public void SortEndDescending(int[,] matrix)
        {
            if (matrix == null) return;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = matrix[i, 0];
                int jj = 0;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        jj = j;
                    }
                }

                if (jj == matrix.GetLength(1) - 1) continue;
                for (int k = jj + 1; k < matrix.GetLength(1) - 1; k++)
                {
                    for (int j = jj + 1; j < matrix.GetLength(1) - 1; j++)
                    {
                        if (matrix[i, j] < matrix[i, j + 1])
                        {
                            (matrix[i, j], matrix[i, j + 1]) = (matrix[i, j + 1], matrix[i, j]);
                        }
                    }
                }
            }
        }

        public int Task8(double[] A, double[] B)
        {
            int answer = 0;

            // code here
            if (A == null || B == null || A.Length < 3 || B.Length < 3) return 0;

            double a = GeronArea(A[0], A[1], A[2]);
            double b = GeronArea(B[0], B[1], B[2]);

            if (a == 0 && b == 0) return 0;

            answer = (a >= b) ? 1 : 2;
            // end

            return answer;
        }

        public double GeronArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0) return 0.0;
            if (a + b <= c || b + c <= a || a + c <= b) return 0.0;

            double p = (a + b + c) / 2.0;
            double s2 = p * (p - a) * (p - b) * (p - c);

            return s2 <= 0 ? 0.0 : Math.Sqrt(s2);
        }

        public void Task9(int[,] matrix, Action<int[]> sorter)
        {
            // code here
            if (matrix == null || sorter == null) return;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i % 2 == 0)
                    SortMatrixRow(matrix, i, sorter);
            }
            // end
        }

        public void SortMatrixRow(int[,] matrix, int row, Action<int[]> sorter)
        {
            if (matrix == null || sorter == null) return;
            if (row < 0 || row >= matrix.GetLength(0)) return;

            int[] array = new int[matrix.GetLength(1)];
            for (int j = 0; j < matrix.GetLength(1); j++)
                array[j] = matrix[row, j];

            sorter(array);
            ReplaceRow(matrix, row, array);
        }

        public void ReplaceRow(int[,] matrix, int row, int[] array)
        {
            if (matrix == null || array == null) return;
            if (row < 0 || row >= matrix.GetLength(0)) return;
            if (array.Length != matrix.GetLength(1)) return;

            for (int j = 0; j < matrix.GetLength(1); j++)
                matrix[row, j] = array[j];
        }

        public void SortAscending(int[] array)
        {
            if (array == null) return;
            Array.Sort(array);
        }

        public void SortDescending(int[] array)
        {
            if (array == null) return;
            Array.Sort(array);
            Array.Reverse(array);
        }

        public double Task10(int[][] array, Func<int[][], double> func)
        {
            double res = 0;

            // code here
            if (array == null || func == null) return 0;
            res = func(array);
            // end

            return res;
        }

        public double CountZeroSum(int[][] array)
        {
            if (array == null) return 0;

            double k = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null) continue;

                double s = 0;
                for (int j = 0; j < array[i].Length; j++)
                    s += array[i][j];

                if (s == 0) k++;
            }

            return k;
        }

        public double FindMedian(int[][] array)
        {
            if (array == null) return 0;

            int q = 0;
            for (int i = 0; i < array.Length; i++)
                q += (array[i]?.Length ?? 0);

            if (q == 0) return 0;

            int[] massive = new int[q];
            int k = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int[] row = array[i];
                if (row == null) continue;

                for (int j = 0; j < row.Length; j++)
                    massive[k++] = row[j];
            }

            Array.Sort(massive);

            if (massive.Length % 2 == 0)
                return (massive[q / 2 - 1] + massive[q / 2]) / 2.0;

            return massive[q / 2];
        }

        public double CountLargeElements(int[][] array)
        {
            if (array == null) return 0;

            double k = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int[] row = array[i];
                if (row == null || row.Length == 0) continue;

                double s = 0;
                for (int j = 0; j < row.Length; j++)
                    s += row[j];

                double avg = s / row.Length;

                for (int j = 0; j < row.Length; j++)
                {
                    if (row[j] > avg) k++;
                }
            }

            return k;
        }
    }
}
