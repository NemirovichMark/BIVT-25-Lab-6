using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public class Purple
    {
        //for me
        public int Str(int[,] m)
        {
            int str = m.GetLength(0);
            return str;
        }
        //for me
        public int Stolb(int[,] m)
        {
            int str = m.GetLength(1);
            return str;
        }
        //for me
        public int[,] Sort(int[,] matrix)
        {
            int[] arr = new int[Str(matrix) * Stolb(matrix)];

            int k = 0;
            for (int i = 0; i < Str(matrix); i++)
            {
                for (int j = 0; j < Stolb(matrix); j++)
                {
                    arr[k] = matrix[i, j];
                    k++;
                }
            }

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    }

                }
            }

            int[,] mama = new int[Str(matrix), Stolb(matrix)];
            int c = 0;
            for (int i = 0; i < Str(mama); i++)
            {
                for (int j = 0; j < Stolb(mama); j++)
                {
                    mama[i, j] = arr[c];
                    c++;
                }
            }

            return mama;
        }
        //for me
        public void ChangeRows(int[,] A, int row1, int row2)
        {
            for (int i = 0; i < Stolb(A); i++)
            {
                (A[row1, i], A[row2, i]) = (A[row2, i], A[row1, i]);
            }
        }
        //for me
        public int FindMaxNeg(int[,] arr, int col)
        {
            int max = int.MinValue;

            int pol = 0;
            for (int i = 0; i < Str(arr); i++)
            {
                if (arr[i, col] >= 0)
                {
                    pol++;
                }
            }
            if (pol == Str(arr))
            {
                max = 0; ;
                return max;
            }

            for (int i = 0; i < Str(arr); i++)
            {
                if (arr[i, col] < 0)
                {
                    if (arr[i, col] > max)
                    {
                        max = arr[i, col];
                    }
                }
            }

            return max;
        }


        //1
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int str = Str(matrix);
            int stolb = Stolb(matrix);

            int max = int.MinValue;
            int indexM = 0;

            if (str == stolb)
            {
                for (int i = 0; i < str; i++)
                {
                    if (matrix[i, i] > max)
                    {
                        max = matrix[i, i];
                        indexM = i;
                    }
                }
            }

            return indexM;
        }
        //1 
        public void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex)
        {
            int row = Str(matrix);
            int col = Stolb(B);

            if (row != col) return;

            int k = 0;

            int[,] gege = new int[Str(matrix), Stolb(matrix)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    gege[i, j] = matrix[i, j];
                }
            }

            for (int i = 0; i < row; i++)
            {
                matrix[rowIndex, i] = B[i, columnIndex];
            }

            for (int i = 0; i < row; i++)
            {
                B[i, columnIndex] = gege[rowIndex, i];
            }
        }
        
        
        //2
        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int count = 0;
            for (int i = 0; i < Stolb(matrix); i++)
            {
                if (matrix[row, i] > 0) count++;
            }
            return count;
        }
        //2
        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {
            int count = 0;
            for (int i = 0; i < Str(matrix); i++)
            {
                if (matrix[i, col] > 0) count++;
            }
            return count;
        }
        //2
        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B)
        {
            //надо вставить колумн б в роу матрицы а после роуиндекс 

            if (Stolb(A) == Str(B))
            {
                int Index = rowIndex + 1;

                int[,] gege = new int[Str(A) + 1, Stolb(A)];


                for (int i = 0; i < rowIndex + 1; i++)
                {
                    for (int j = 0; j < Stolb(A); j++)
                    {
                        gege[i, j] = A[i, j];
                    }
                }

                int k = Index + 1;
                for (int i = Index; i < Str(A); i++)
                {
                    for (int j = 0; j < Stolb(A); j++)
                    {
                        gege[k, j] = A[i, j];
                    }
                    k++;
                }

                A = gege;

                for (int i = 0; i < Stolb(A); i++)
                {
                    A[Index, i] = B[i, columnIndex];
                }
            }
        }
        
        
        //3
        public void ChangeMatrixValues(int[,] matrix)
        {

            if (Str(matrix) * Stolb(matrix) < 5)
            {
                for (int i = 0; i < Str(matrix); i++)
                {
                    for (int j = 0; j < Stolb(matrix); j++)
                    {
                        matrix[i, j] *= 2;
                    }
                }
                return;
            }

            int[,] ggs = null;
            ggs = Sort(matrix);

            int[] max = new int[5];
            int k = 0;

            for (int i = 0; i < Str(ggs); i++)
            {
                for (int j = 0; j < Stolb(ggs); j++)
                {
                    if (k < 5)
                    {
                        max[k] = ggs[i, j];
                        k++;
                    }
                }
            }

            int[] indX = new int[5];
            int[] indY = new int[5];
            int c = 0;

            int[,] cal = new int[Str(matrix), Stolb(matrix)];

            for (int i = 0; i < Str(matrix); i++)
            {
                for (int j = 0; j < Stolb(matrix); j++)
                {
                    cal[i, j] = matrix[i, j];
                }
            }

            for (int i = 0; i < Str(ggs); i++)
            {
                for (int j = 0; j < Stolb(ggs); j++)
                {
                    for (int h = 0; h < max.Length; h++)
                    {
                        if ((c < 5) && cal[i, j] == max[h])
                        {
                            indX[c] = i;
                            indY[c] = j;
                            c++;
                            max[h] = int.MaxValue;
                            cal[i, j] = int.MinValue;
                        }
                    }
                }
            }

            int[,] ssal = new int[Str(matrix), Stolb(matrix)];

            for (int i = 0; i < Str(matrix); i++)
            {
                for (int j = 0; j < Stolb(matrix); j++)
                {
                    ssal[i, j] = matrix[i, j];
                }
            }

            for (int i = 0; i < Str(matrix); i++)
            {
                for (int j = 0; j < Stolb(matrix); j++)
                {
                    matrix[i, j] /= 2;
                }
            }

            for (int i = 0; i < indX.Length; i++)
            {
                matrix[indX[i], indY[i]] = ssal[indX[i], indY[i]] * 2;
            }
        }
        
        
        //4
        public int[] CountNegativesPerRow(int[,] matrix)
        {
            int[] arr = new int[Str(matrix)];
            
            for (int i = 0; i < Str(matrix); i++)
            {
                int c = 0;
                for (int j = 0; j < Stolb(matrix); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        c++; 
                    }
                }
                arr[i] = c;
            }
            return arr;
        }
        //4
        public int FindMaxIndex(int[] array)
        {
            int max = 0;
            int MaxIndex = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if(array[i] > max)
                {
                    max = array[i];
                    MaxIndex = i;
                }
            }
            return MaxIndex;
        }
        
        
        //5
        public delegate void Sorting(int[] m);
        //5
        public void SortNegativeAscending(int[] matrix)
        {
            int CountNeg = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    CountNeg++;
                }
            }

            int[] arr = new int[CountNeg];
            int h = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    arr[h] = matrix[i];
                    h++;
                }
            }


            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    }

                }
            }

            int k = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    matrix[i] = arr[k];
                    k++;
                }
            }
        }
        //5
        public void SortNegativeDescending(int[] matrix)
        {
            int CountNeg = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    CountNeg++; 
                }
            }

            int[] arr = new int[CountNeg];
            int h = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    arr[h] = matrix[i];
                    h++;
                }
            }


            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    }

                }
            }

            int k = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    matrix[i] = arr[k];
                    k++;
                }
            }
        }


        //6
        public delegate void SortRowsByMax(int[,] m);
        //6
        public void SortRowsByMaxAscending(int[,] matrix)
        {
            for (int i = 0; i < Str(matrix) - 1; i++)
            {
                for (int j = 0; j < Str(matrix) - i - 1; j++)
                {
                    int first = GetRowMax(matrix, j);
                    int second = GetRowMax(matrix, j + 1);
                    //Print(matrix);
                    if (first > second)
                    {
                        ChangeRows(matrix, j, j + 1);
                    }
                }
            }
        }
        //6
        public void SortRowsByMaxDescending(int[,] matrix)
        {
            for (int i = 0; i < Str(matrix) - 1; i++)
            {
                for (int j = 0; j < Str(matrix) - i - 1; j++)
                {
                    int first = GetRowMax(matrix, j);
                    int second = GetRowMax(matrix, j + 1);
                    if (first < second)
                    {
                        ChangeRows(matrix, j + 1, j);
                    }
                }
            }
        }
        //6
        public int GetRowMax(int[,] matrix, int row)
        {
            int max = int.MinValue;
            for (int j = 0; j < Stolb(matrix); j++)
            {
                if (matrix[row, j] > max)
                {
                    max = matrix[row, j];
                }
            }
            return max;
        }


        //7
        public delegate int[] FindNegatives(int[,] m);
        //7
        public int[] FindNegativeCountPerRow(int[,] matrix)
        {
            int[] neg = new int[Str(matrix)];


            for (int i = 0; i < Str(matrix); i++)
            {
                int c = 0;
                for (int j = 0; j < Stolb(matrix); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        c++;
                    }
                }
                neg[i] = c;
            }

            return neg;
        }
        //7
        public int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            int[] neg = new int[Stolb(matrix)];


            for (int i = 0; i < Stolb(matrix); i++)
            {
                neg[i] = FindMaxNeg(matrix, i);
            }

            return neg;
        }


        //8
        public delegate int[,] MathInfo(int[,] m);
        //8
        public int[,] DefineSeq(int[,] matrix)
        {
            int[,] res = new int[1, 1] { { 0 } };

            int[,] gege = new int[Str(matrix), Stolb(matrix)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    gege[i, j] = matrix[i, j];
                }
            }


            for (int i = 0; i < Stolb(gege) - 1; i++)
            {
                for (int j = 0; j < Stolb(gege) - i - 1; j++)
                {
                    if (gege[0, j] > gege[0, j + 1]) {
                        (gege[0, j], gege[0, j + 1]) = (gege[0, j + 1], gege[0, j]);
                    }
                }
            }

            for (int i = 0; i < Stolb(gege) - 1; i++)
            {
                for (int j = 0; j < Stolb(gege) - i - 1; j++)
                {
                    if (gege[1, j] > gege[1, j + 1]) {
                        (gege[1, j], gege[1, j + 1]) = (gege[1, j + 1], gege[1, j]);
                    }
                }
            }

            int[,] down = new int[Str(matrix), Stolb(matrix)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    down[i, j] = matrix[i, j];
                }
            }


            for (int i = 0; i < Stolb(down) - 1; i++)
            {
                for (int j = 0; j < Stolb(down) - i - 1; j++)
                {
                    if (down[0, j] < down[0, j + 1])
                    {
                        (down[0, j], down[0, j + 1]) = (down[0, j + 1], down[0, j]);
                    }
                }
            }

            for (int i = 0; i < Stolb(down) - 1; i++)
            {
                for (int j = 0; j < Stolb(down) - i - 1; j++)
                {
                    if (down[1, j] < down[1, j + 1])
                    {
                        (down[1, j], down[1, j + 1]) = (down[1, j + 1], down[1, j]);
                    }
                }
            }


            int c = 0;
            for (int i = 0; i < Str(matrix); i++)
            {
                for (int j = 0; j < Stolb(matrix); j++)
                {
                    if (matrix[0, j] == gege[0, j] && matrix[1, j] == gege[1, j])
                    {
                        c++;
                    }
                }
            }
            if (c == Stolb(matrix)*2)
            {
                res[0, 0] = 1;
            }

            int k = 0;
            for (int i = 0; i < Str(matrix); i++)
            {
                for (int j = 0; j < Stolb(matrix); j++)
                {
                    if (matrix[0, j] == down[0, j] && matrix[1, j] == down[1, j])
                    {
                        k++;
                    }
                }
            }

            if (k == Stolb(matrix)*2)
            {
                res[0, 0] = -1;
            }


            if (Stolb(matrix) == 1) return new int[0, 0] { };
            
            return res;
        }
        //8
        public int[,] FindAllSeq(int[,] matrix)
        {
            int cols = matrix.GetLength(1);
            if (cols <= 1) return new int[0, 0];

            List<int[]> intervals = new List<int[]>();
            int startX = matrix[0, 0];
            int currentDir = 0;
            int nextDir = 0;
            for (int col = 0; col < cols - 1; col++)
            {

                if (matrix[1, col] < matrix[1, col + 1]) nextDir = 1;
                else if (matrix[1, col] > matrix[1, col + 1]) nextDir = -1;

                if (currentDir != 0 && nextDir != currentDir)
                {
                    intervals.Add(new int[] { startX, matrix[0, col] });
                    startX = matrix[0, col];
                }
                if (currentDir == 0)
                {
                    startX = matrix[0, col];
                }
                currentDir = nextDir;
            }

            intervals.Add(new int[] { startX, matrix[0, cols - 1] });

            var sortedIntervals = intervals.OrderBy(arr => arr[0]).ThenBy(arr => arr[1]).ToList();

            int[,] result = new int[sortedIntervals.Count, 2];
            for (int i = 0; i < sortedIntervals.Count; i++)
            {
                result[i, 0] = sortedIntervals[i][0];
                result[i, 1] = sortedIntervals[i][1];
            }

            return result;
        }
        //8
        public int[,] FindLongestSeq(int[,] matrix)
        {
            int[,] intervals = FindAllSeq(matrix);
            int len = intervals.GetLength(0);

            if (len == 0) return new int[,] { };

            int MaxLen = 0;
            int[,] MaxInterval = new int[1, 2];
            for (int i = 0; i < len; i++)
            {
                if (intervals[i, 1] - intervals[i, 0] > MaxLen)
                {
                    MaxLen = intervals[i, 1] - intervals[i, 0];
                    MaxInterval[0, 0] = intervals[i, 0];
                    MaxInterval[0, 1] = intervals[i, 1];
                }
            }

            return MaxInterval;
        }


        //9
        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
        {
            //функция 
            //шаг
            //отрезок
            int count = 0;
            double sign = func(a) / Math.Abs(func(a));

            for (double i = a; i <= b; i+=h)
            {
                //Math.Round(i, 5);
                double sign2 = func(i) / Math.Abs(func(i));
                if (sign != sign2)
                {
                    sign *= -1;
                    count++; 
                }
            }

            return count;
        }
        //9
        public double FuncA(double x)
        {
            return Math.Pow(x, 2) - Math.Sin(x);
        }
        //9
        public double FuncB(double x)
        {
            return Math.Exp(x) - 1;
        }


        //10
        public void SortInCheckersOrder(int[][] array)
        {

            int str = array.Length;

            for (int i = 0; i < str; i++)
            {
                Array.Sort(array[i]);
                if (i % 2 != 0) Array.Reverse(array[i]);
            }
        }
        //10
        public void SortBySumDesc(int[][] array)
        {
            int str = array.Length;

            for (int i = 0; i < str; i++)
            {
                for (int j = 0; j < str - i - 1; j++)
                {
                    if (array[j].Sum() < array[j + 1].Sum())
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
        }
        //10
        public void TotalReverse(int[][] array)
        {
            int str = array.Length;

            for (int i = 0; i < str; i++)
            {
                Array.Reverse(array[i]);
            }
            Array.Reverse(array);
        }

        public void Task1(int[,] A, int[,] B)
        {

            // code here

            int str = Str(A);
            int col = Stolb(A);
            int strB = Str(B);
            int colB = Stolb(B);


            if (str == col && strB == colB)
            {
                int row = FindDiagonalMaxIndex(A);
                int column = FindDiagonalMaxIndex(B);

                SwapRowColumn(A, row, B, column);
            }
            // done

        }
        public void Task2(ref int[,] A, int[,] B)
        {

            // code here
            int c = 0;
            for (int i = 0; i < Str(A); i++)
            {
                c += CountPositiveElementsInRow(A, i);
            }
            if (c == 0) return;

            int k = 0;
            for (int i = 0; i < Stolb(B); i++)
            {
                k += CountPositiveElementsInColumn(B, i);
            }
            if (k == 0) return;

            int mr = 0;
            int mrc = 0;
            for (int i = 0; i < Str(A); i++)
            {
                if (mr < CountPositiveElementsInRow(A, i))
                {
                    mr = CountPositiveElementsInRow(A, i);
                    mrc = i;
                }
            }

            int mc = 0;
            int mcc = 0;
            for (int i = 0; i < Stolb(B); i++)
            {
                if (mc < CountPositiveElementsInColumn(B, i))
                {
                    mc = CountPositiveElementsInColumn(B, i);
                    mcc = i;
                }
            }

            InsertColumn(ref A, mrc, mcc, B);

            // done

        }
        public void Task3(int[,] matrix)
        {
            // code here
            ChangeMatrixValues(matrix);
            // done

        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here
            int RowA = FindMaxIndex(CountNegativesPerRow(A));
            int RowB = FindMaxIndex(CountNegativesPerRow(B));

            if (Stolb(A) != Stolb(B) || RowA == 0 || RowB == 0) return;

            int k = 0;

            int[,] gege = new int[Str(A), Stolb(A)];

            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    gege[i, j] = A[i, j];
                }
            }

            for (int i = 0; i < Stolb(A); i++)
            {
                A[RowA, i] = B[RowB, i];
            }

            for (int i = 0; i < Stolb(B); i++)
            {
                B[RowB, i] = gege[RowA, i];
            }

            // done

        }
        public void Task5(int[] matrix, Sorting sort)
        {

            // code here
            sort(matrix);
            // done

        }
        public void Task6(int[,] matrix, SortRowsByMax sort)
        {

            // code here

            sort(matrix);

            // done

        }
        public int[] Task7(int[,] matrix, FindNegatives find)
        {
            int[] negatives = null;

            // code here
            negatives = find(matrix);
            // done

            return negatives;
        }
        public int[,] Task8(int[,] matrix, MathInfo info)
        {
            int[,] answer = null;

            // code here

            int[,] Res = new int[0,0];
            if ((matrix.Cast<int>().All(elen => elen == matrix[0, 0]) == true))
            {
                return Res;
            }

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
    }
}
