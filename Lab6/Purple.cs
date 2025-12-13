using System;
using System.Globalization;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public class Purple
    {
        public void Task1(int[,] A, int[,] B)
        {

            // code here
            int lenA=A.GetLength(0), lenB=B.GetLength(0);
            if (lenA!=A.GetLength(1) || lenB!=B.GetLength(1) || lenA!=lenB) return;
            int indexA=FindDiagonalMaxIndex(A);
            int indexB=FindDiagonalMaxIndex(B);
            SwapRowColumn(A,indexA,B,indexB);
            // end

        }
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int indexMax=0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                if (matrix[i,i]>matrix[indexMax,indexMax]) indexMax=i;
            return indexMax;
        }
        public void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex)
        {
            int lenA=matrix.GetLength(0);
            for (int i = 0; i < lenA; i++)
            {
                int p=matrix[rowIndex,i];
                matrix[rowIndex,i]=B[i,columnIndex];
                B[i,columnIndex]=p;
            }
        }
        public void Task2(ref int[,] A, int[,] B)
        {

            // code here
            int rowA=A.GetLength(0),colA=A.GetLength(1),rowB=B.GetLength(0),colB=B.GetLength(1);
            if (colA!=rowB) return;
            int maxCountRow=int.MinValue,maxCountCol=int.MinValue;
            int rowIndex=0,colIndex=0;
            for (int i = 0; i < rowA; i++)
            {
                int countA = CountPositiveElementsInRow(A,i);
                if (countA > maxCountRow)
                {
                    maxCountRow=countA; 
                    rowIndex=i;
                } 
                int countB = CountPositiveElementsInColumn(B,i);
                if (countB > maxCountCol)
                {
                    maxCountCol=countB;
                    colIndex=i;
                } 
            }
            if (maxCountCol==0) return;
            InsertColumn(ref A,rowIndex,colIndex,B);
            // end

        }
        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int n=matrix.GetLength(1);
            int count=Enumerable.Range(0,n)
                        .Select(j=>matrix[row,j])
                        .Count(x=>x>0);
            return count;
        }
        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {
            int m=matrix.GetLength(0);
            int count=Enumerable.Range(0,m)
                        .Select(i=>matrix[i,col])
                        .Count(x=>x>0);
            return count;
        }
        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B)
        {
            int row=A.GetLength(0),col=A.GetLength(1);
            int[,] aA=A;
            A = new int [row+1,col];
            for (int i = 0; i < row+1; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (i<=rowIndex) A[i,j]=aA[i,j];
                    if (i==rowIndex+1) A[i,j]=B[j,columnIndex];
                    if (i>rowIndex+1) A[i,j]=aA[i-1,j];
                }
            }

            
        }
        public void Task3(int[,] matrix)
        {

            // code here
            ChangeMatrixValues(matrix);
            // end

        }
        public  void ChangeMatrixValues(int[,] matrix)
        {
            int len=matrix.Length,rows=matrix.GetLength(0),cols=matrix.GetLength(1);
            int[] array=new int[len],indexI=new int[len],indexJ=new int[len],order=new int[len];

            len=0;
            for (int i=0;i<rows;i++)
                for (int j = 0; j < cols; j++)
                {
                    array[len]=matrix[i,j];
                    order[len]=len;
                    indexI[len]=i;
                    indexJ[len]=j;
                    len++;
                }

            int l=1;
            len=matrix.Length;
            while (l < len)
            {
                if (l == 0)
                {
                    l++;
                    continue;
                }
                bool checkOrder=array[l]<array[l-1] || (array[l]==array[l-1] && order[l]>order[l-1]);
                if (checkOrder) l++;
                else
                {
                    (array[l],array[l-1])=(array[l-1],array[l]);
                    (order[l],order[l-1])=(order[l-1],order[l]);
                    (indexI[l],indexI[l-1])=(indexI[l-1],indexI[l]);
                    (indexJ[l],indexJ[l-1])=(indexJ[l-1],indexJ[l]);
                    l--;
                }
            }
            
            bool[,] mark=new bool[rows,cols];
            int count = Math.Min(5,len);
            for (int i=0;i<count;i++)
                mark[indexI[i],indexJ[i]]=true;
            
            for (int i=0;i<rows;i++)
                for (int j = 0; j < cols; j++)
                {
                    if (mark[i,j]) matrix[i,j]*=2;
                    else matrix[i,j]/=2;
                }
        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here
            int colsA=A.GetLength(1),colsB=B.GetLength(1);
            if (colsA!=colsB) return;

            int[] arrA = CountNegativesPerRow(A);
            int[] arrB = CountNegativesPerRow(B);
            bool check=CheckArrays(arrA,arrB);
            if (!check) return;

            int indexA=FindMaxIndex(arrA);
            int indexB=FindMaxIndex(arrB);

            for (int j=0;j<colsA;j++)
                (A[indexA,j],B[indexB,j])=(B[indexB,j],A[indexA,j]);
            // end

        }
        public bool CheckArrays (int[] a,int[] b)
        {
            int lenA=a.Length,lenB=b.Length,sumA=0,sumB=0;

            for (int i = 0; i < lenA; i++)
                sumA+=a[i];
            for (int i=0;i<lenB;i++)
                sumB+=b[i];

            if (sumA>0 && sumB>0) return true;
            return false;
        }
        public  int[] CountNegativesPerRow(int[,] matrix)
        {
            int rows=matrix.GetLength(0),cols=matrix.GetLength(1);
            int[] result=new int[rows];
            for (int i = 0; i < rows; i++)
            {
                int count=0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i,j]<0) count++;
                }
                result[i]=count;
            }
            return result;
        }
        public int FindMaxIndex(int[] array)
        {
            int len=array.Length,maxIndex=0;
            for (int i=0;i<len;i++)
                if (array[i]>array[maxIndex]) maxIndex=i;
            return maxIndex;
        }
        public void Task5(int[] matrix, Sorting sort)
        {

            // code here
            int[] negatives = matrix.Where(x => x < 0).ToArray();
            if (negatives.Length == 0) return;
            sort(matrix);
            // end

        }
        public delegate void Sorting (int[] matrix);
        public void SortNegativeAscending(int[] matrix)
        {
            int[] result = matrix.Where(x=>x<0).OrderBy(x=>x).ToArray();
            int l=0;
            for (int i = 0; i < matrix.Length; i++)
                if (matrix[i]<0)matrix[i]=result[l++];
        }
        public void SortNegativeDescending(int[] matrix)
        {
            int[] result = matrix.Where(x=>x<0).OrderByDescending(x=>x).ToArray();
            int l=0;
            for (int i = 0; i < matrix.Length; i++)
                if (matrix[i]<0)matrix[i]=result[l++];
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
            //выборка максимальных элементов
            int rows=matrix.GetLength(0),cols=matrix.GetLength(1);
            int[] arrayMaxElements=new int [rows];
            for (int i = 0; i < rows; i++)
            {
                int maxRowElement=GetRowMax(matrix,i);
                arrayMaxElements[i]=maxRowElement;
            }
            //их сортировка
            int l=1;
            while (l < rows)
            {
                if (l==0 || arrayMaxElements[l-1]<=arrayMaxElements[l]) l++;
                else
                {
                    (arrayMaxElements[l-1],arrayMaxElements[l])=(arrayMaxElements[l],arrayMaxElements[l-1]);
                    for (int j=0;j<cols;j++)
                        (matrix[l-1,j],matrix[l,j])=(matrix[l,j],matrix[l-1,j]);
                    l--;
                }
            }
        }
        public void SortRowsByMaxDescending(int[,] matrix)
        {
            //выборка максимальных элементов
            int rows=matrix.GetLength(0),cols=matrix.GetLength(1);
            int[] arrayMaxElements=new int [rows];
            for (int i = 0; i < rows; i++)
            {
                int maxRowElement=GetRowMax(matrix,i);
                arrayMaxElements[i]=maxRowElement;
            }
            //их сортировка
            int l=1;
            while (l < rows)
            {
                if (l==0 || arrayMaxElements[l-1]>=arrayMaxElements[l]) l++;
                else
                {
                    (arrayMaxElements[l-1],arrayMaxElements[l])=(arrayMaxElements[l],arrayMaxElements[l-1]);
                    for (int j=0;j<cols;j++)
                        (matrix[l-1,j],matrix[l,j])=(matrix[l,j],matrix[l-1,j]);
                    l--;
                }
            }
        }
        public  int GetRowMax(int[,] matrix, int row)
        {
            int cols=matrix.GetLength(1);
            int maxElement=Enumerable.Range(0,cols)
                            .Select(j=>matrix[row,j])
                            .ToArray().Max();
            return maxElement;
        }
        public int[] Task7(int[,] matrix, FindNegatives find)
        {
            int[] negatives = null;

            // code here
            negatives=find(matrix);
            // end

            return negatives;
        }
        public delegate int[] FindNegatives (int[,] matrix);
        public int[] FindNegativeCountPerRow(int[,] matrix)
        {
            int rows=matrix.GetLength(0), cols=matrix.GetLength(1);
            int[] answer=new int[rows];
            for (int i = 0; i < rows; i++)
                answer[i]=Enumerable.Range(0,cols)
                            .Select(j=>matrix[i,j])
                            .Count(x=>x<0);  
            return answer;
        }
        public int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            int rows=matrix.GetLength(0), cols=matrix.GetLength(1);
            int[] answer=new int[cols];
            for (int j = 0; j < cols; j++)
                answer[j]=Enumerable.Range(0,rows)
                            .Select(i=>matrix[i,j])
                            .OrderByDescending(x=>x)
                            .FirstOrDefault(x=>x<0);
            return answer;
        }
        public int[,] Task8(int[,] matrix, MathInfo info)
        {
            int[,] answer = null;

            // code here
            answer = info(matrix);
            // end

            return answer;
        }
        public delegate int[,] MathInfo (int[,] matrix);
        public int[,] DefineSeq(int[,] matrix)
        {
            if (CheckYEqual(matrix))
                return new int[0,0];

            int rows=matrix.GetLength(0),cols=matrix.GetLength(1);
            int[]checkArray1=Enumerable.Range(0,cols).Select(j=>matrix[1,j]).OrderBy(x=>x).ToArray();
            int[]checkArray2=Enumerable.Range(0,cols).Select(j=>matrix[1,j]).OrderByDescending(x=>x).ToArray();
            
            bool check1=true;
            for (int j = 0; j < cols; j++)
                if (matrix[1,j]!=checkArray1[j]) check1=false;
            
            bool check2=true;
            for (int j = 0; j < cols; j++)
                if (matrix[1,j]!=checkArray2[j]) check2=false;
            
            if (check1)
            {
                int[,]answer={{1}};
                return answer;
            }
            else if (check2)
            {
                int[,]answer={{-1}};
                return answer;
            }
            else
            {
                int[,]answer={{0}};
                return answer;
            }
        }
        public int[,] FindAllSeq(int[,] matrix)
        {
            int cols = matrix.GetLength(1);

            // если меньше 2 точек — нет интервалов
            if (cols < 2 || CheckYEqual(matrix))
                return new int[0, 0];

            int[] start = new int[cols];
            int[] end = new int[cols];
            int count = 0;

            int startIndex = 0;

            int prevDiff = matrix[1, 1] - matrix[1, 0];
            int direction = Math.Sign(prevDiff);

            for (int j = 1; j < cols - 1; j++)
            {
                int diff = matrix[1, j + 1] - matrix[1, j];
                int currentDir = Math.Sign(diff);

                // 0 не ломает монотонность
                if (currentDir == 0)
                    continue;

                if (direction == 0)
                {
                    direction = currentDir;
                    continue;
                }

                if (currentDir != direction)
                {
                    start[count] = matrix[0, startIndex];
                    end[count] = matrix[0, j];
                    count++;

                    startIndex = j;
                    direction = currentDir;
                }
            }

            // последний интервал
            start[count] = matrix[0, startIndex];
            end[count] = matrix[0, cols - 1];
            count++;

            int[,] result = new int[count, 2];
            for (int i = 0; i < count; i++)
            {
                result[i, 0] = start[i];
                result[i, 1] = end[i];
            }

            return result;
        }
        public int[,] FindLongestSeq(int[,] matrix)
        {
            int cols = matrix.GetLength(1);
            if (cols < 2 || CheckYEqual(matrix))
                return new int[0, 0];

            int[,] allSeq = FindAllSeq(matrix);
            int rows = allSeq.GetLength(0);

            if (rows == 0)
                return new int[0, 0];

            int bestStart = allSeq[0, 0];
            int bestEnd = allSeq[0, 1];
            int bestSpan = bestEnd - bestStart;

            for (int i = 1; i < rows; i++)
            {
                int xStart = allSeq[i, 0];
                int xEnd = allSeq[i, 1];

                int span = xEnd - xStart; 

                if (span > bestSpan)
                {
                    bestSpan = span;
                    bestStart = xStart;
                    bestEnd = xEnd;
                }
            }
            return new int[,] { { bestStart, bestEnd } };
        }

        public bool CheckYEqual(int[,] matrix)
        {
            int cols = matrix.GetLength(1);
            int first = matrix[1, 0];

            for (int j = 1; j < cols; j++)
                if (matrix[1, j] != first) return false;

            return true; 
        }
        public int Task9(double a, double b, double h, Func<double, double> func)
        {
            int answer = 0;

            // code here
            return CountSignFlips(a,b,h,func);
            // end

            return answer;
        }
        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
        {
            int count =0;

            double x=a;
            double prev= func(x);

            x+=h;

            while (x <= b)
            {
                double cur=func(x);
                if (cur*prev<0) count++;
                prev=cur;
                x+=h;
            }
            return count;
        }
        public double FuncA(double x)
        {
            return x*x -Math.Sin(x);
        }
        public double FuncB(double x)
        {
            return Math.Exp(x)-1;
        }
        public void Task10(int[][] array, Action<int[][]> func)
        {

            // code here
            func(array);
            // end

        }
        public void SortInCheckersOrder(int[][] array)
        {
            int rows=array.Length;
            for (int i = 0; i < rows; i++)
            {
                int cols=array[i].Length;
                if (i % 2 == 0)
                {
                    int[] row=Enumerable.Range(0,cols)
                                .Select(j=>array[i][j])
                                .OrderBy(x=>x).ToArray();
                    for (int j=0;j<cols;j++)
                        array[i][j]=row[j];
                }
                else
                {
                    int[] row=Enumerable.Range(0,cols)
                                .Select(j=>array[i][j])
                                .OrderByDescending(x=>x).ToArray();
                    for (int j=0;j<cols;j++)
                        array[i][j]=row[j];
                }
            }
        }

        public void SortBySumDesc(int[][] array)
        {
            int[][] sorted = array.OrderByDescending(row=>row.Sum()).ToArray();
            int rows=array.Length;
            for (int i = 0; i < rows; i++)
                array[i]= new int [sorted[i].Length];
            
            for (int i = 0; i < rows; i++)
            {
                int cols=array[i].Length;
                for (int j = 0; j < cols; j++)
                    array[i][j]=sorted[i][j];
            }
        }

        public void TotalReverse(int[][] array)
        {
            int[][] reverse = array.Reverse().ToArray();
            int rows=array.Length;
            for (int i = 0; i < rows; i++)
            {
                int[]row=reverse[i].Reverse().ToArray();
                int cols=reverse[i].Length;
                for (int j=0;j<cols;j++)
                    reverse[i][j]=row[j];
            }

            for (int i = 0; i < reverse.Length; i++)
            {
                int cols=reverse[i].Length;
                array[i] = new int [cols];
                for (int j = 0; j < cols; j++)
                    array[i][j]=reverse[i][j];
            }
        }
    }
}