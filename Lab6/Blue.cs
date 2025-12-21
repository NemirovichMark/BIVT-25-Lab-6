using System.Runtime.InteropServices;

namespace Lab6
{
    public class Blue
    {
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int RowIndex = 0;
            int maxzn = matrix[0, 0];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > maxzn)
                {
                    maxzn = matrix[i, i];
                    RowIndex = i;
                }
            }
            return RowIndex;
        }
        public void RemoveRow(ref int[,] matrix, int RowIndex)
        {
            int[,] newmatrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            for(int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(i < RowIndex)
                    {
                        newmatrix[i, j] = matrix[i, j];
                    }
                    else
                    {
                        newmatrix[i, j] = matrix[i + 1, j];
                    }
                }
            }
            matrix = newmatrix;
        }
        public void Task1(ref int[,] matrix)
        {
            if (matrix.Length == 0) return;
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            Blue program = new Blue();
            int MaxInd = program.FindDiagonalMaxIndex(matrix);
            program.RemoveRow(ref matrix, program.FindDiagonalMaxIndex(matrix));   
        }
        public double GetAverageExceptEdges(int[,] matrix)
        {
            if(matrix.Length <= 2) return 0.0;
            double sum = 0.0;
            int maxzn = int.MinValue;
            int minzn = int.MaxValue;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxzn)
                    {
                        maxzn = matrix[i, j];
                    }
                    if (matrix[i, j] < minzn)
                    {
                        minzn = matrix[i, j];
                    }
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != maxzn && matrix[i, j] != minzn)
                    {
                        sum += matrix[i, j];
                    }
                }
            }
            return sum / (matrix.Length - 2);
        }
        public int Task2(int[,] A, int[,] B, int[,] C)
        {
            int answer = 0; // 1 - increasing   0 - no sequence   -1 - decreasing

            // code here
            Blue program = new Blue();
            double mid1 = program.GetAverageExceptEdges(A);
            double mid2 = program.GetAverageExceptEdges(B);
            double mid3 = program.GetAverageExceptEdges(C);
            double[] arr1 = { mid1, mid2, mid3 };
            int FU = 0, FV = 0;
            for(int i = 0; i < arr1.Length - 1; i++)
            {
                if (arr1[i] > arr1[i + 1]) FU++;
                if (arr1[i] < arr1[i + 1]) FV++;

            }
            if (FU == 2 && FV == 2) answer = 0;
            else if (FU == 2) answer = -1;
            else if (FV == 2) answer = 1;
            else answer = 0;
                // end

            return answer;
        }
        public delegate int FindColIndex(int[,] matrix);

        public int FindUpperColIndex(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1)) return 0;
            int maxzn = int.MinValue;
            int ind = 0;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(j > i)
                    {
                        if (matrix[i, j] > maxzn)
                        {
                            maxzn = matrix[i, j];
                            ind = j;
                        }
                    }
                }
            }
            return ind;
        }
        public int FindLowerColIndex(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1)) return 0;
            int maxzn = int.MinValue;
            int ind = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j <= i)
                    {
                        if (matrix[i, j] > maxzn)
                        {
                            maxzn = matrix[i, j];
                            ind = j;
                        }
                    }
                }
            }
            return ind;
        }
        public void RemoveColumn(ref int[,] matrix, int col)
        {
            int[,] newmatrix = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if(j < col)
                    {
                        newmatrix[i, j] = matrix[i, j];
                    }
                    else
                    {
                        newmatrix[i, j] = matrix[i, j + 1];
                    }
                }
            }
            matrix = newmatrix;
            return;
        }
        public void Task3(ref int[,] matrix, Func<int[,], int> method)
        {
            if (matrix.Length == 0) return;
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            // code here
            Blue program = new Blue();
            int colind = method(matrix);
            RemoveColumn(ref matrix, colind);
            // end

        }
        public bool CheckZerosInColumn(int[,] matrix, int col)
        {
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] == 0) return true;
            }
            return false;
        }
        public void Task4(ref int[,] matrix)
        {

            // code here
            if (matrix.Length == 0) return;
            Blue program = new Blue();
            for(int j = matrix.GetLength(1) - 1; j >= 0; j--)
            {
                if(!program.CheckZerosInColumn(matrix, j))
                {
                    program.RemoveColumn(ref matrix, j);
                }
            }

            // end

        }
        public delegate int Finder(int[,] matrix, out int row, out int col);
        public int FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;
            int maxzn = int.MinValue;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxzn)
                    {
                        maxzn = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
            return maxzn;
        }
        public int FindMin(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;
            int minzn = int.MaxValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < minzn)
                    {
                        minzn = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
            return minzn;
        }
        public void Task5(ref int[,] matrix, Finder find)
        {
            if (matrix.Length == 0) return;
            // code here
            int row, col;
            int del = find(matrix, out row, out col);
            for(int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                bool fl = false;
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == del)
                    {
                        fl = true;
                        break;
                    }
                }
                if (fl)
                {
                    RemoveRow(ref matrix, i);
                }
            }


            // end

        }
        public delegate void SortRowsStyle(int[,] matrix, int row);
        public void SortRowAscending(int[,] matrix, int row)
        {
            int[] arr = new int[matrix.GetLength(1)];
            for(int i = 0; i < matrix.GetLength(1); i++)
            {
                arr[i] = matrix[row, i];
            }
            Array.Sort(arr);
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                matrix[row, i] = arr[i];
            }
            return;
        }
        public void SortRowDescending(int[,] matrix, int row)
        {
            int[] arr = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                arr[i] = matrix[row, i];
            }
            Array.Sort(arr);
            Array.Reverse(arr);
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                matrix[row, i] = arr[i];
            }
            return;
        }
        public void Task6(int[,] matrix, SortRowsStyle sort)
        {
            if (matrix.Length == 0) return;
            // code here

            for(int i = 0; i < matrix.GetLength(0); i += 3)
            {
                sort(matrix, i);
            }

            // end

        }
        public int FindMaxInRow(int[,] matrix, int row)
        {
            int maxzn = int.MinValue;
            for(int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[row, i] > maxzn) maxzn = matrix[row, i];
            }
            return maxzn;
        }
        public delegate void ReplaceMaxElements(int[,] matrix, int row, int maxValue);
        public void ReplaceByZero(int[,] matrix, int row, int maxValue)
        {
            for(int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[row, i] == maxValue) matrix[row, i] = 0;
            }
            return;
        }
        public void MultiplyByColumn(int[,] matrix, int row, int maxValue)
        {
            for(int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[row, i] == maxValue) matrix[row, i] = matrix[row, i] * (i + 1);
            }
            return;
        }
        public void Task7(int[,] matrix, ReplaceMaxElements transform)
        {
            if (matrix.Length == 0) return;
            // code here
            Blue pr = new Blue();
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                int el = pr.FindMaxInRow(matrix, i);
                transform(matrix, i, el);
            }
            // end

        }
        //public double[,] GetSumAndY(double a, double b, double h, Func<double, double> sum, Func<double, double> y)
        //{
        //    if (h <= 0 || b < a) return new double[0, 2];
        //    int cnt = (int)Math.Round((b - a) / h) + 1;
        //    double[,] arr = new double[2, cnt];
        //    cnt = 0;
        //    for(double x = a; x <= b + 1e-9; x += h)
        //    {
        //        arr[cnt, 0] = sum(x);
        //        arr[cnt, 1] = y(x);
        //        cnt++;
        //    }

        //    return arr;
        //}
        //public double SumA(double x)
        //{
        //    double sum = 1, fact = 1;
        //    for(int i = 1; i <= 20; i++)
        //    {
        //        fact *= i;
        //        sum += Math.Cos(i * x) / fact;
        //    }
        //    return sum;
        //}
        //public double YA(double x)
        //{
        //    return Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
        //}
        //public double SumB(double x)
        //{
        //    double mn = -1;
        //    double sum = 0.0;
        //    for(int i = 1; i <= 20; i++)
        //    {
        //        sum += (mn * Math.Cos(i * x)) / (i * i);
        //        mn = -mn;
        //    }
        //    return sum;
        //}
        //public double YB(double x)
        //{
        //    return (Math.Pow(x, 2) / 4.0) - (Math.Pow(Math.PI, 2) / 12.0);
        //}
        //public double[,] Task8(double a, double b, double h, Func<double, double> getSum, Func<double, double> getY)
        //{
        //    double[,] answer = GetSumAndY(a, b, h, getSum, getY);

        //    // code here

        //    // end

        //    return answer;
        //}
        public double[,] Task8(double a, double b, double h, Func<double, double> getSum, Func<double, double> getY)
        {
            double[,] answer = null;

            // code here

            answer = GetSumAndY(a, b, h, getSum, getY);
            // end

            return answer;
        }

        public double[,] GetSumAndY(double a, double b, double h, Func<double, double> sum, Func<double, double> y)
        {
            int n = (int)((b - a) / h) + 1;

            int k = 0;

            double[,] answer = new double[n, 2];

            for (double x = a; x <= b + 1e-9; x += h)
            {
                answer[k, 0] = sum(x);
                answer[k, 1] = y(x);
                k++;
            }

            return answer;
        }

        public double SumA(double x)
        {
            double sum = 1.0;
            double fact = 1.0;
            for (int i = 1; i <= 10; i++)
            {
                fact *= i;
                sum += Math.Cos(i * x) / fact;
            }

            return sum;
        }

        public double SumB(double x)
        {
            double s = -2.0 * Math.PI * Math.PI / 3.0;

            for (double i = 1; ; i += 1.0)
            {
                double sign = (i % 2 == 0) ? 1.0 : -1.0;
                s += sign * Math.Cos(i * x) / (i * i);

                if (Math.Abs(sign * Math.Cos(i * x) / (i * i)) < 0.000001) break;
            }

            return s;
        }

        public double YA(double x)
        {
            return Math.Pow(Math.E, Math.Cos(x)) * Math.Cos(Math.Sin(x));
        }

        public double YB(double x)
        {
            return (x * x) / 4.0 - 3.0 * (Math.PI * Math.PI) / 4.0;
        }
        public delegate int[] GetTriangle(int[,] matrix);
        public int Sum(int[] array)
        {
            int sum = 0;
            for(int i = 0; i < array.Length; i++)
            {
                sum += array[i] * array[i];
            }
            return sum;
        }
        public int GetSum(GetTriangle transformer, int[,] matrix)
        {
            int[] arr = transformer(matrix);
            int sum = Sum(arr);
            return sum;
        }
        public int[] GetUpperTriangle(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1)) return null;
            int cnt = 0;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = i; j < matrix.GetLength(1); j++)
                {
                    cnt++;
                }
            }
            int[] arr = new int[cnt];
            cnt = 0;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = i; j < matrix.GetLength(0); j++)
                {
                    arr[cnt++] = matrix[i, j];
                }
            }
            return arr;
        }
        public int[] GetLowerTriangle(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1)) return null;
            int cnt = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    cnt++;
                }
            }
            int[] arr = new int[cnt];
            cnt = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    arr[cnt++] = matrix[i, j];
                }
            }
            return arr;
        }
        public int Task9(int[,] matrix, GetTriangle triangle)
        {
            int answer = 0;

            // code here
            if (matrix.Length == 0) return 0;
            if (matrix.GetLength(0) != matrix.GetLength(1)) return 0;
            answer = GetSum(triangle, matrix);

            // end

            return answer;
        }
        public delegate bool JaggedPredicate(int[][] array);
        public bool CheckTransformAbility(int[][] array)
        {
            bool ans = false;
            int cnt = 0;
            for(int i = 0; i < array.GetLength(0); i++)
            {
                if (array[i].Length == 0) return false;
                cnt += array[i].Length;
            }
            if (cnt % array.GetLength(0) == 0) ans = true;
            return ans;
        }
        public bool CheckSumOrder(int[][] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] == null) return false;
            }
            if (array.Length == 1) return true;
            int sum = 0;
            for(int i = 0; i < array[0].Length; i++)
            {
                sum += array[0][i];
            }
            bool f1 = true, f2 = true;
            for(int i = 1; i < array.Length; i++)
            {
                int s = 0;
                for(int j = 0; j < array[i].Length; j++)
                {
                    s += array[i][j];
                }
                if (s <= sum) f1 = false;
                if (s >= sum) f2 = false;
                sum = s;
            }
            if (f1 || f2) return true;
            return false;
        }
        public bool CheckArraysOrder(int[][] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                int[] arr = array[i];
                if (arr.Length == 0) return false;
                if (arr.Length == 1) return true;
                bool f1 = true, f2 = true;
                for (int j = 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[j - 1]) f1 = false;
                    if (arr[j] > arr[j - 1]) f2 = false;
                }
                if (f1 || f2) return true;
                {
                    
                }
            }
            return false;
        }
        public bool Task10(int[][] array, Predicate<int[][]> func)
        {
            bool res = false;

            // code here
            if (array.Length == 0) return false;
            res = func(array);
            // end

            return res;
        }
    }
}
