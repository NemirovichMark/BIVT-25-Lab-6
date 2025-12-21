namespace Lab6
{
    public class Blue
    {   //1
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int indmax = int.MinValue;
            for(int i=0;  i<matrix.GetLength(0); i++)
            {
                if (matrix[i, i] >= indmax) indmax = i;
            }
            return indmax;
        }
        public void RemoveRow(ref int[,] matrix, int rowIndex)
        {
            int str= matrix.GetLength(0);
            int sto = matrix.GetLength(1);
            int[,] nov = new int[str - 1, sto];
            for (int i = 0; i < str; i++)
            {
                if (i < rowIndex)
                {
                    for (int j = 0; j < sto; j++) nov[i,j]=matrix[i,j];
                }
                else if (i > rowIndex)
                {
                    for (int j = 0; j < sto; j++) nov[i - 1, j] = matrix[i, j];
                }
            }
            matrix = nov;
        }
        //2
        public double GetAverageExceptEdges(int[,] matrix)
        {
            int str = matrix.GetLength(0);
            int sto = matrix.GetLength(1);
            int razm = str * sto;
            if (razm < 3) return 0;
            int max = int.MinValue, min = int.MaxValue;
            double s = 0;
            for(int i = 0; i < str; i++)
            {
                for(int j = 0;j < sto; j++)
                {
                    s += matrix[i, j];
                    if (matrix[i,j] > max) max = matrix[i,j];
                    if (matrix[i, j] < min) min = matrix[i, j];
                }
            }
            double sr = (s - min - max) / (razm - 2);
            return sr;
        }
        //3
        public int FindUpperColIndex(int[,] matrix)
        {
            int max = int.MinValue;
            int indmax = 0;
            int str=matrix.GetLength(0);
            int el = 1;
            for(int i = 0; i < str; i++)
            {
                for(int j = i + 1; j < str; j++)
                {
                    if(matrix[i,j] > max) {max = matrix[i,j]; indmax = j;}
                }
                el++;
            }
            return indmax;
        }
        public int FindLowerColIndex(int[,] matrix)
        {
            int indmax = int.MinValue;
            int str = matrix.GetLength(0);
            for (int i = 0; i < str; i++)
            {
                for (int j = 0; j < i+1; j++)
                {
                    if (matrix[i, j] > indmax) indmax = j;
                }
            }
            return indmax;
        }
        public void RemoveColumn(ref int[,] matrix, int col)
        {
            int str = matrix.GetLength(0);
            int sto = matrix.GetLength(1);

            int[,] nov = new int[str, sto - 1];
            for (int i = 0; i < str; i++)
            {
                for (int j = 0; j < sto; j++)
                {
                    if (j < col) nov[i, j] = matrix[i, j];
                    else if (j > col) nov[i, j - 1] = matrix[i, j];
                }
            }
            matrix = nov;
        }
        //4
        public bool CheckZerosInColumn(int[,] matrix, int col)
        {
            for (int i = 0; i < matrix.GetLength(0); i++) if (matrix[i, col] == 0) return true;
            return false;
        }
        public void RemoveCol(ref int[,] matrix,int col)
        {
            RemoveColumn(ref matrix, col);
        }
        //5
        public delegate int Finder(int[,] matrix, out int row, out int col);
        public int FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0; col = 0;
            int maxe = int.MinValue;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j=0;j<matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxe)
                    {
                        maxe = matrix[i, j];
                        row = i; col = j;
                    }
                }
            }
            return maxe;
        }
        public int FindMin(int[,] matrix, out int row, out int col)
        {
            row = 0; col = 0;
            int mine = int.MaxValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < mine)
                    {
                        mine = matrix[i, j];
                        row = i; col = j;
                    }
                }
            }
            return mine;
        }
        //6
        public delegate void SortRowsStyle(int[,] matrix, int row);
        public void SortRowAscending(int[,] matrix, int row)
        {
            for(int i=0;i< matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(1)-1; j++)
                {
                    if (matrix[row, j] > matrix[row,j+1]) (matrix[row, j + 1], matrix[row, j]) = (matrix[row, j], matrix[row,j+1]);
                }
            } 
        }
        public void SortRowDescending(int[,] matrix, int row)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[row, j] < matrix[row, j + 1]) (matrix[row, j + 1], matrix[row, j]) = (matrix[row, j], matrix[row, j + 1]);
                }
            }
        }
        //7
        public delegate void ReplaceMaxElements(int[,] matrix, int row, int maxValue);
        public int FindMaxInRow(int[,]matrix, int row)
        {
            int maxs = int.MinValue;
            for(int j=0;j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > maxs) maxs = matrix[row, j];
            }
            return maxs;
        }
        public void ReplaceByZero(int[,] matrix, int row, int maxValue)
        {
            for(int j=0;j< matrix.GetLength(1); j++)
            {
                if (matrix[row, j] == maxValue) matrix[row, j] = 0;
            }
        }
        public void MultiplyByColumn(int[,] matrix, int row, int maxValue)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] == maxValue) matrix[row, j] *= (j+1);
            }
        }
        //8
        public double[,] GetSumAndY(double a, double b, double h, Func<double, double> sum, Func<double, double> y)
        {
            if (sum == null || y == null) return null;
            if (h == 0) return null;
            if (a < b && h < 0) h = -h;
            if (a > b && h > 0) h = -h;
            double steps = (b - a) / h;
            int n = (int)Math.Round(steps) + 1;
            if (n <= 0) return null;
            double[,] res = new double[n, 2];
            for (int i = 0; i < n; i++)
            {
                double x = a + i * h;
                res[i, 0] = sum(x);
                res[i, 1] = y(x);
            }
            return res;
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
        public double YA(double x)
        {
            return Math.Pow(Math.E, Math.Cos(x)) * Math.Cos(Math.Sin(x));
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
        public double YB(double x)
        {
            return (x * x) / 4.0 - 3.0 * (Math.PI * Math.PI) / 4.0;
        }
        //9
        public delegate int[] GetTriangle(int[,] matrix);
        public int Sum(int[] array)
        {
            int s = 0;
            for(int i=0;i<array.Length;i++) s+= (array[i]*array[i]);
            return s;
        }
        public int GetSum(GetTriangle transformer, int[,] matrix)
        {
            int[] tri = transformer(matrix);
            int s = Sum(tri);
            return s;
        }
        public int[] GetUpperTriangle(int[,] matrix)
        {
            int s = 0;
            for(int i = matrix.GetLength(0), t = matrix.GetLength(1); i > -1; i--, t--)
            {
                s += t;
            }
            int[] upt = new int[s];
            int sch = 0;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j=i;j<matrix.GetLength(1); j++) upt[sch++]=matrix[i,j];
            }
            return upt;
        }
        public int[] GetLowerTriangle(int[,] matrix)
        {
            int s = 0;
            for (int i = matrix.GetLength(0), t = matrix.GetLength(1); i > -1; i--, t--)
            {
                s += t;
            }
            int[] lot = new int[s];
            int sch = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < i+1; j++) lot[sch++] = matrix[i, j];
            }
            return lot;
        }
        //10
        delegate bool Predicate(int[][] array);
        public bool CheckTransformAbility(int[][] array)
        {
            int sch = 0;
            for(int i=0; i< array.GetLength(0); i++)
            {
                sch += array[i].Length;
            }
            if (sch % array.GetLength(0) == 0) return true;
            return false;
        }
        public bool CheckSumOrder(int[][] array)
        {
            int s= 0;
            for (int j = 0; j < array[0].Length; j++) s += array[0][j];
            bool a = true, b = true;
            for (int i = 1; i < array.Length; i++)
            {
                int t = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    s += array[i][j];
                }
                if (t <= s) a = false;
                if (t >= s) b = false;
                s = t;
            }
            if (a || b) return true;
            return false;
        }
        public bool CheckArraysOrder(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int[] t = array[i];
                if (t.Length < 2) return true;
                bool a = true, b = true;
                for (int j = 1; j < t.Length; j++)
                {
                    if (t[j] < t[j - 1]) a = false;
                    if (t[j] > t[j - 1]) b = false;
                }
                if (a || b) return true;
            }
            return false;
        }
        //
        public void Task1(ref int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            int indm = FindDiagonalMaxIndex(matrix);
            RemoveRow(ref matrix, indm);
            // end

        }
        public int Task2(int[,] A, int[,] B, int[,] C)
        {
            int answer = 0; // 1 - increasing   0 - no sequence   -1 - decreasing

            // code here
            double srA = GetAverageExceptEdges(A), srB = GetAverageExceptEdges(B), srC = GetAverageExceptEdges(C);
            double[] srABC = {srA,srB,srC};
            if (srA > srB && srB > srC) answer = -1;
            else if (srA < srB && srB < srC) answer = 1;
            else answer = 0;
                // end

                return answer;
        }
        public void Task3(ref int[,] matrix, Func<int[,], int> method)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            int k = method(matrix);
            RemoveColumn(ref matrix, k);
            // end

        }
        public void Task4(ref int[,] matrix)
        {

            // code here
            int k = matrix.GetLength(1);
            for (int j = k - 1; j >= 0; j--)
            {
                if (CheckZerosInColumn(matrix, j) == false) RemoveCol(ref matrix, j);
            }

            // end

        }
        public void Task5(ref int[,] matrix, Finder find)
        {

            // code here
            int el = find(matrix,out int str, out int sto);
            for( int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == el) { RemoveRow(ref matrix, i); break; }
                }
            }
            // end

        }
        public void Task6(int[,] matrix, SortRowsStyle sort)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i += 3)
                sort(matrix, i);
            // end

        }
        public void Task7(int[,] matrix, ReplaceMaxElements transform)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int maxs = FindMaxInRow(matrix, i);
                transform(matrix, i, maxs);
            }
            // end

        }
        public double[,] Task8(double a, double b, double h, Func<double, double> getSum, Func<double, double> getY)
        {
            double[,] answer = null;

            // code here
            answer = GetSumAndY(a, b, h, getSum, getY);
            // end

            return answer;
        }
        public int Task9(int[,] matrix, GetTriangle triangle)
        {
            int answer = 0;

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1)) return 0;
            answer = GetSum(triangle, matrix);
            // end

            return answer;
        }
        public bool Task10(int[][] array, Predicate<int[][]> func)
        {
            bool res = false;

            // code here
            if (array == null || func == null) return false;
            res = func(array);
            // end

            return res;
        }
    }
}
