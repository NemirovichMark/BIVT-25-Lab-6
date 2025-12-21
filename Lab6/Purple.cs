using System;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public class Purple
    {
        public void Print(int[,] matrix)
        {
            Console.WriteLine();
            for(int i = 0;  i < matrix.GetLength(0); i++)
            {
                for(int j = 0;  j < matrix.GetLength(1); j++)
                {
                    Console.Write("\t");
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
        public void Task1(int[,] A, int[,] B)
        {

            // code here
            
            if (A.GetLength(0) != A.GetLength(1)) { return; }
            if (B.GetLength(0) != B.GetLength(1)) { return; }
            if (B.GetLength(0) != A.GetLength(0)) { return; }
            int row = FindDiagonalMaxIndex(A);
            int col = FindDiagonalMaxIndex(B);

            SwapRowColumn(A,row,B,col);

            // end

        }
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int max_index = 0;
            int max_elem = int.MinValue;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i,i] > max_elem) { max_elem = matrix[i,i];max_index = i; }
            }
            return max_index;
        }
        public void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex)
        {

            for (int i=0 ; i < matrix.GetLength(0); i++)
            {
                (matrix[rowIndex, i], B[i, columnIndex]) = (B[i, columnIndex], matrix[rowIndex, i]);
            }

        }

        public void Task2(ref int[,] A, int[,] B)
        {

            // code here

            int n = A.GetLength(0);
            int m = A.GetLength(1);
            int q = B.GetLength(0);

            if(q != m) { return; }


            int maxp_A = 0;
            int maxp_B = 0;
            int maxp_Ai = 0;
            int maxp_Bi = 0;

            for (int i = 0; i < B.GetLength(1); i++)
            {
                int c = CountPositiveElementsInColumn(B, i);
                if (maxp_B < c) { maxp_B = c; maxp_Bi = i; }
            }
            if(maxp_B == 0) { return; }
            for (int i  = 0; i < A.GetLength(0); i++)
            {
                int c = CountPositiveElementsInRow(A, i);
                if (maxp_A < c) {  maxp_A = c; maxp_Ai = i; }
            }
            //Print(A);
            //Print(B);
            InsertColumn(ref A, maxp_Ai, maxp_Bi, B);
            //Print(A);

            // end

        }
        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B)
        {
            int n = A.GetLength(0);
            int m = A.GetLength(1);
            int q = B.GetLength(0);
            int[,] newA = new int[n+1,m];
            //Print(A);
            for(int i =0 ; i < n; i++)
            {
                //Console.WriteLine(i);
                if (i <= rowIndex)
                {
                    for (int j = 0; j < m; j++)
                    {
                        newA[i, j] = A[i, j];
                    }
                }

                else
                {
                    for (int j = 0; j < m; j++)
                    {
                        newA[i+1, j] = A[i, j];
                    }
                }
            }
            //Console.WriteLine(q);
            for (int i = 0; i < q; i++) 
            {
                newA[rowIndex+1,i] = B[i,columnIndex];
            }
            //Print(newA);
            A = newA;
        }
        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(1); i++) 
            {
                if (matrix[row,i] > 0) {  count++; }
            }

            return count;
        }
        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {

            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] > 0) { count++; }
            }

            return count;
        }

        public void Task3(int[,] matrix)
        {

            // code here

          
            ChangeMatrixValues(matrix);
            // end

        }
        public void ChangeMatrixValues(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);


            if (n*m <= 5)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        matrix[i, j] *= 2;
                    }
                }
                return;
            }

            int[] array = new int[n*m];
            int[] maxIndexes = new int[n * m];

            int index = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[index] = matrix[i, j];
                    maxIndexes[index] = index;
                    index++;
                }
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if ((array[j] < array[j + 1]) || (array[j] == array[j + 1] && maxIndexes[j] > maxIndexes[j + 1]))
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        (maxIndexes[j], maxIndexes[j + 1]) = (maxIndexes[j + 1], maxIndexes[j]);
                    }
                }
            }

            bool[] isMaxValue = new bool[array.Length];
            for (int i = 0; i < 5; i++)
            {
                isMaxValue[maxIndexes[i]] = true;
            }

            index = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (isMaxValue[index++])
                        matrix[i, j] *= 2;
                    else
                        matrix[i, j] /= 2;
                }
            }
        }

        public void Task4(int[,] A, int[,] B)
        {

            // code here
            if(A.GetLength(1) != B.GetLength(1)) { return; }
           
            int[] a_c = CountNegativesPerRow(A);
            int[] b_c = CountNegativesPerRow(B);

            int a_maxi = FindMaxIndex(a_c);
            int b_maxi = FindMaxIndex(b_c);

            if (a_c[a_maxi] == 0 || b_c[b_maxi] == 0) { return; }

            for (int i = 0; i < A.GetLength(1); i++)
            {
                (A[a_maxi, i], B[b_maxi, i]) = (B[b_maxi, i], A[a_maxi, i]);
            }



            // end

        }
        public int[] CountNegativesPerRow(int[,] matrix)
        {

            int[] neg_count = new int[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0) { count++; }
                }
                neg_count[i] = count;
            }

            return neg_count;
        }
        public int FindMaxIndex(int[] array)
        {
            int max = int.MinValue;
            int max_index = 0;
            for (int i = 0; i < array.Length; i++) 
            {
                if(array[i] > max)
                {
                    max = array[i];
                    max_index = i;
                }
            }

            return max_index;
        }

        public void Task5(int[] matrix, Sorting sort)
        {

            // code here

            sort(matrix);

            // end

        }
        public delegate void Sorting(int[] matrix);
        public void SortNegativeAscending(int[] matrix)
        {
            int n = matrix.Length;
            int c = 0;
            for(int i = 0; i < n; i++)
             {
                    if(matrix[i] < 0) { c++; }
            }
               if (c == 0) { return; }

               int[] neg= new int[c];

               
            int index = 0;
               for (int i = 0; i < n; i++)
               {
                   if (matrix[i] < 0) {neg[index++] =  matrix[i] ; }
               }

            Array.Sort(neg);
            index = 0;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i] < 0) {  matrix[i] = neg[index++] ; }
            }


        }
        public void SortNegativeDescending(int[] matrix)
        {
            int n = matrix.Length;
            int c = 0;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i] < 0) { c++; }
            }
            if (c == 0) { return; }

            int[] neg = new int[c];


            int index = 0;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i] < 0) { neg[index++] = matrix[i]; }
            }

            Array.Sort(neg);
            Array.Reverse(neg); 
            index = 0;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i] < 0) { matrix[i] = neg[index++]; }
            }

        }

        public void Task6(int[,] matrix, SortRowsByMax sort)
        {

            // code here

            sort(matrix);

            // end

        }
        public delegate void SortRowsByMax(int[,] matrix);
        public void SortRowsByMaxAscending(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int[] max_vals = new int[n]; 

            for (int i = 0; i < n; i++)
            {
                max_vals[i] = GetRowMax(matrix, i);
            }

            int[] max_ind = new int[n];
            for (int i = 0; i < n; i++)
            {

                int max_i = FindMinIndex(max_vals);
                max_ind[i] = max_i;
                max_vals[max_i] = int.MaxValue;

            }

            int[,] new_m = new int[n,m];
            int index = 0;

            foreach (int i in max_ind)
            {
                for (int j = 0; j < m; j++)
                {
                    new_m[index,j] = matrix[i,j];
                }
                index++;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = new_m[i, j];
                }
            }


        }
        public void SortRowsByMaxDescending(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int[] max_vals = new int[n];

            for (int i = 0; i < n; i++)
            {
                max_vals[i] = GetRowMax(matrix, i);
            }

            int[] max_ind = new int[n];
            for (int i = 0; i < n; i++)
            {

                int max_i = FindMaxIndex(max_vals);
                max_ind[i] = max_i;
                max_vals[max_i] = int.MinValue;

            }

            int[,] new_m = new int[n, m];
            int index = 0;

            foreach (int i in max_ind)
            {
                for (int j = 0; j < m; j++)
                {
                    new_m[index, j] = matrix[i, j];
                }
                index++;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = new_m[i, j];
                }
            }

        }
        public int GetRowMax(int[,] matrix, int row)
        {
            int max = int.MinValue;

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[row,i] > max)
                {
                    max = matrix[row, i];
                    
                }
            }

            return max;

        }
        public int FindMinIndex(int[] array)
        {
            int min = int.MaxValue;
            int min_index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] <min)
                {
                    min = array[i];
                    min_index = i;
                }
            }

            return min_index;
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
            int[] res = new int[matrix.GetLength(0)];
            for (int i = 0;i< matrix.GetLength(0); i++)
            {
                int c = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] < 0) { c++; }
                }
                res[i] = c;
            }


            return res;
        }
        public int[] FindMaxNegativePerColumn(int[,] matrix)
        {

            int[] res = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int max = int.MinValue;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] < 0 && matrix[j, i] > max) { max = matrix[j, i]; }
                }
                if (max == int.MinValue) { max = 0; }
                res[i] = max;
            }


            return res;
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
            bool allYEqual = true;
            for (int j = 1; j < matrix.GetLength(1); j++)
            {
                if (matrix[1, j] != matrix[1, j + 1])
                {
                    allYEqual = false;
                    break;
                }
            }
            if (allYEqual)
                return new int[0, 0];

            int seq = 0;
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                double y1 = matrix[1, j]; double y2 = matrix[1, j + 1];
                if (y1 < y2)
                {
                    seq = 1;
                    break;
                }
                else if (y1 > y2)
                {
                    seq = -1;
                    break;
                }
            }

            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                double y1 = matrix[1, j]; double y2 = matrix[1, j + 1];
                if (seq == 1)
                {
                    if (y1 > y2)
                        return new int[1, 1] { { 0 } };
                }
                else if (seq == -1)
                {
                    if (y1 < y2)
                        return new int[1, 1] { { 0 } };
                }
            }

            return new int[1, 1] { { seq } };

            
        }
        public int[,] FindAllSeq(int[,] matrix)
        {


            bool allYEqual = true;
            for (int j = 1; j < matrix.GetLength(1); j++)
            {
                if (matrix[1, j] != matrix[1, j + 1])
                {
                    allYEqual = false;
                    break;
                }
            }
            if (allYEqual)
                return new int[0, 0];

            int count = 0;
            int seqPrev = 0; int seqCurr = 0;

            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                if (matrix[1, j] < matrix[1, j + 1])
                    seqCurr = 1;
                else if (matrix[1, j] > matrix[1, j + 1])
                    seqCurr = -1;

                if (seqCurr != seqPrev)
                {
                    count++;
                    seqPrev = seqCurr;
                }
                else if (seqPrev == 0)
                {
                    seqPrev = seqCurr;
                }
            }

            int[,] allSeq = new int[count, 2];
            int seqIndex = 0; int firstIndex = 0;

            seqPrev = 0;
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                if (matrix[1, j] < matrix[1, j + 1])
                    seqCurr = 1;
                else if (matrix[1, j] > matrix[1, j + 1])
                    seqCurr = -1;

                if (seqPrev == 0)
                {
                    seqPrev = seqCurr;
                    firstIndex = j;
                }
                else if (seqCurr != seqPrev)
                {

                    allSeq[seqIndex, 0] = matrix[0, firstIndex];
                    allSeq[seqIndex, 1] = matrix[0, j];
                    seqIndex++;

                    firstIndex = j;
                    seqPrev = seqCurr;
                }
            }

            allSeq[seqIndex, 0] = matrix[0, firstIndex];
            allSeq[seqIndex, 1] = matrix[0, matrix.GetLength(1) - 1];

            return allSeq;
        }

        public int[,] FindLongestSeq(int[,] matrix)
        {

            int[,] allSeq = FindAllSeq(matrix);

            if (allSeq.GetLength(0) == 0)
                return new int[0, 0];

            int longestLen = allSeq[0, 1] - allSeq[0, 0];
            int longestIndex = 0;

            for (int i = 0; i < allSeq.GetLength(0); i++)
            {
                int currentLen = allSeq[i, 1] - allSeq[i, 0];
                if (currentLen > longestLen)
                {
                    longestLen = currentLen;
                    longestIndex = i;
                }
            }
            return new int[1, 2] { { allSeq[longestIndex, 0], allSeq[longestIndex, 1] } };
        }

        public int Task9(double a, double b, double h, Func<double, double> func)
        {
            int answer = 0;

            // code here
            if (h <= 0){return 0;}

            if (a > b) { (a,b) = (b,a); }

            answer = CountSignFlips(a,b,h,func);

            // end

            return answer;
        }
        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
        {
            int count = 0;

            double x = a;
            double yPrev = func(x);
            int prevSign = Math.Sign(yPrev);

            while (x <= b)
            {
                x += h;

                if (x > b)
                {
                    x = b;
                }

                double y_cur = func(x);
                int cursign = Math.Sign(y_cur);

                if (prevSign != 0 && cursign != 0 && prevSign != cursign)
                {
                    count++;
                }

                if (cursign != 0)
                {
                    prevSign = cursign;
                }

                if (Math.Abs(x - b) < 1e-10)
                {
                    break;
                }
            }

            return count;
        }

        public double FuncA(double x)
        {
            return Math.Pow(x,2) - Math.Sin(x);
        }

        public double FuncB(double x)
        {
            return Math.Exp(x)-1;
        }
        public void Task10(int[][] array, Action<int[][]> func)
        {

            // code here

            //Console.WriteLine();
            //for (int i = 0; i < array.Length; i++)
            //{
            //    for (int j = 0; j < array[i].Length; j++)
            //    {
            //        Console.Write("\t");
            //        Console.Write(array[i][j]);
            //    }
            //    Console.WriteLine();
            //}
            func(array);


            // end

        }
        public void SortInCheckersOrder(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Array.Sort(array[i]);
                    if ( (i%2) != 0) { Array.Reverse(array[i]); }
                }

            }


        }
        public void SortBySumDesc(int[][] array)
        {
            for (int k = 0; k < array.Length - 1; k++)
            {
                for (int i = 0; i < array.Length - 1 - k; i++)
                {
                    int sum1 = 0; int sum2 = 0;

                    for (int j = 0; j < array[i].Length; j++)
                        sum1 += array[i][j];

                    for (int j = 0; j < array[i + 1].Length; j++)
                        sum2 += array[i + 1][j];

                    if (sum1 < sum2)
                        (array[i], array[i + 1]) = (array[i + 1], array[i]);
                }
            }
        }

        public void TotalReverse(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Array.Reverse(array[i]);
            }
            Array.Reverse(array);
        }
    }
}