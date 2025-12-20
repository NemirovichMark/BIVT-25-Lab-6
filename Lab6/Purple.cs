using System;
using System.Collections.Immutable;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public class Purple
    {
        public delegate int[] Sorting(int[] array);

        public delegate void SortRowsByMax(int[,] matrix);

        public delegate int[] FindNegatives(int[,] matrix);

        public delegate int[,] MathInfo(int[,] array);

        public delegate int Func(int[] array);



        public void Task1(int[,] A, int[,] B)
        {
            // code here 
            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            int rowsB = B.GetLength(0);
            int colsB = B.GetLength(1);

            if (rowsA == colsA && rowsB == colsB)
            {
                int mxA = FindDiagonalMaxIndex(A);
                int mxB = FindDiagonalMaxIndex(B);

                SwapRowColumn(A, mxA, B, mxB);
            }
            // end

        }
        public void Task2(ref int[,] A, int[,] B)
        {

            // code here
            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            int rowsB = B.GetLength(0);
            int colsB = B.GetLength(1);

            if (colsA != rowsB) return;

            bool isMatrixBHasPositiveNumbers = false;
            for (int row = 0; row < rowsB; row++)
            {
                for (int col = 0; col < colsB; col++)
                {
                    if (B[row, col] > 0)
                    {
                        isMatrixBHasPositiveNumbers = true;
                        break;
                    }
                }
            }

            if (isMatrixBHasPositiveNumbers)
            {
                int mxInRow = int.MinValue;
                int imxRow = -1;
                int mxInCol = int.MinValue;
                int imxCol = -1;

                for (int row = 0; row < rowsA; row++)
                {
                    int numOfpositiveNumsInRow = CountPositiveElementsInRow(A, row);
                    if (numOfpositiveNumsInRow > mxInRow)
                    {
                        mxInRow = numOfpositiveNumsInRow;
                        imxRow = row;
                    }
                }

                for (int col = 0; col < colsB; col++)
                {
                    int numOfpositiveNumsInCol = CountPositiveElementsInColumn(B, col);
                    if (numOfpositiveNumsInCol > mxInCol)
                    {
                        mxInCol = numOfpositiveNumsInCol;
                        imxCol = col;
                    }
                }

                InsertColumn(ref A, imxRow, imxCol, B);
            }
            // end

        }
        public void Task3(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows * cols < 6)
            {
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] *= 2;
                    }
                }
            }
            else
            {
                ChangeMatrixValues(matrix);
            }
            // end

        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here
            //int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            //int rowsB = B.GetLength(0);
            int colsB = B.GetLength(1);
            if (colsA != colsB) return;
            int[] negativeRowsInA = CountNegativesPerRow(A);
            int[] negativeRowsInB = CountNegativesPerRow(B);

            int rowAWithMaxNegativeNumsInRow = FindMaxIndex(negativeRowsInA);
            int rowBWithMaxNegativeNumsInRow = FindMaxIndex(negativeRowsInB);

            if (rowAWithMaxNegativeNumsInRow != -1 &&  rowBWithMaxNegativeNumsInRow != -1)
            {
                for (int col = 0; col < colsA; col++)
                    (A[rowAWithMaxNegativeNumsInRow, col], B[rowBWithMaxNegativeNumsInRow, col]) = (B[rowBWithMaxNegativeNumsInRow, col], A[rowAWithMaxNegativeNumsInRow, col]);
            }
            // end

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

        public static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        public int FindDiagonalMaxIndex(int[,] matrix) 
        {
            int mx = int.MinValue;
            int imx = -1;
            int rows = matrix.GetLength(0);

            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, i] > mx)
                {
                    mx = matrix[i, i];
                    imx = i;
                }
            }

            return imx;
        }
        public void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex) 
        {
            int rows = matrix.GetLength(0);
            int colsB = B.GetLength(1);

            if (rows == colsB)
            {
                for (int i = 0; i < rows; i++)
                {
                    (matrix[rowIndex, i], B[i, columnIndex]) = (B[i, columnIndex], matrix[rowIndex, i]);
                }
            }
        }

        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B) 
        {
            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            int colsB = B.GetLength(1);

            int[,] resMatrix = new int[rowsA + 1, colsA];

            for (int row = 0; row < rowIndex + 1; row++)
            {
                for (int col = 0; col < colsA; col++)
                {
                    resMatrix[row, col] = A[row, col];
                }
            }

            int rowB = 0;
            for (int col = 0; col < colsA; col++)
            {
                resMatrix[rowIndex + 1, col] = B[rowB, columnIndex];
                rowB++;
            }

            for (int row = rowIndex + 2; row < rowsA + 1; row++)
            {
                for (int col = 0; col < colsA; col++)
                {
                    resMatrix[row, col] = A[row - 1, col];
                }
            }
            A = resMatrix;
        }
        public int CountPositiveElementsInRow(int[,] matrix, int row) 
        {
            int cols = matrix.GetLength(1);
            int positive = 0;
            for (int col = 0; col < cols; col++)
            {
                if (matrix[row, col] > 0)
                    positive++;
            }

            return positive;
        }

        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {
            int rows = matrix.GetLength(0);
            int positive = 0;
            for (int row = 0; row < rows; row++)
            {
                if (matrix[row, col] > 0)
                    positive++;
            }

            return positive;
        }

        public void ChangeMatrixValues(int[,] matrix)
        {
            int[] array = new int[matrix.Length];
            int lnArray = array.Length;
            int index = 0;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                    array[index++] = matrix[row, col];
            }

            Array.Sort(array);

            int numsOfMaxNums = 5;
            int[] extremumArray = new int[numsOfMaxNums];
            int indexExtremum = 0;

            for (int i = lnArray - 5; i < lnArray; i++)
                extremumArray[indexExtremum++] = array[i];

            int counter = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int curNum = matrix[row, col];
                    if (extremumArray.Contains(curNum) && counter < 5)
                    {
                        int indexOfDeleteNumberOfArray = Array.IndexOf(extremumArray, curNum);
                        extremumArray[indexOfDeleteNumberOfArray] = -100000;
                        matrix[row, col] *= 2;
                        counter++;
                    }
                    else
                    {
                        matrix[row, col] /= 2;
                    }
                }
            }
        }
        public int[] CountNegativesPerRow(int[,] matrix) 
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[] res = new int[rows];
            int index = 0;
            for (int row = 0; row < rows; row++)
            {
                int negativeInRow = 0;
                for(int col = 0; col< cols; col++)
                {
                    if (matrix[row, col] < 0)
                        negativeInRow++;
                }
                res[index++] = negativeInRow;

            }
            return res;

        }

        public int FindMaxIndex(int[] array) 
        {
            int mx = 0;
            int imx = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > mx)
                {
                    mx = array[i];
                    imx = i;
                }
            }
            return imx;
        }

        public int[] SortNegativeAscending(int[] matrix) {

            int lnArrayNEgativeNumbers = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                    lnArrayNEgativeNumbers++;
            }

            int[] arrayNegativeNums = new int[lnArrayNEgativeNumbers];
            int index = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                    arrayNegativeNums[index++] = matrix[i];
            }

            Array.Sort(arrayNegativeNums);

            index = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                    matrix[i] = arrayNegativeNums[index++];
            }
            return matrix;
        }

        public int[] SortNegativeDescending(int[] matrix) 
        {
            int lnArrayNEgativeNumbers = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                    lnArrayNEgativeNumbers++;
            }

            int[] arrayNegativeNums = new int[lnArrayNEgativeNumbers];
            int index = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                    arrayNegativeNums[index++] = matrix[i];
            }

            Array.Sort(arrayNegativeNums);
            Array.Reverse(arrayNegativeNums);

            index = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                    matrix[i] = arrayNegativeNums[index++];
            }
            return matrix;
        }

        public void SortRowsByMaxAscending(int[,] matrix) 
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[] arrayMaxIndexOfElementsInRow = new int[rows];
            int index = 0;

            for (int row = 0; row < rows; row++)
            {
                int mx = int.MinValue;
                int cmx = -1;
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] > mx)
                    {
                        mx = matrix[row, col];
                        cmx = col;
                    }
                }

                arrayMaxIndexOfElementsInRow[index++] = cmx;
            }

            for (int i = 0; i < arrayMaxIndexOfElementsInRow.Length; i++)
            {
                for (int j = 1; j < arrayMaxIndexOfElementsInRow.Length - i; j++)
                {
                    if (matrix[j - 1, arrayMaxIndexOfElementsInRow[j - 1]] > matrix[j, arrayMaxIndexOfElementsInRow[j]])
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            (matrix[j - 1, col], matrix[j, col]) = (matrix[j, col], matrix[j - 1, col]);
                        }
                        (arrayMaxIndexOfElementsInRow[j - 1], arrayMaxIndexOfElementsInRow[j]) = (arrayMaxIndexOfElementsInRow[j], arrayMaxIndexOfElementsInRow[j - 1]);
                    }
                }
            }

        }

        public void SortRowsByMaxDescending(int[,] matrix) {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[] arrayMaxIndexOfElementsInRow = new int[rows];
            int index = 0;

            for (int row = 0; row < rows; row++)
            {
                int mx = int.MinValue;
                int cmx = -1;
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] > mx)
                    {
                        mx = matrix[row, col];
                        cmx = col;
                    }
                }

                arrayMaxIndexOfElementsInRow[index++] = cmx;
            }

            for (int i = 0; i < arrayMaxIndexOfElementsInRow.Length; i++)
            {
                for (int j = 1; j < arrayMaxIndexOfElementsInRow.Length - i; j++)
                {
                    if (matrix[j - 1, arrayMaxIndexOfElementsInRow[j - 1]] < matrix[j, arrayMaxIndexOfElementsInRow[j]])
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            (matrix[j - 1, col], matrix[j, col]) = (matrix[j, col], matrix[j - 1, col]);
                        }
                        (arrayMaxIndexOfElementsInRow[j - 1], arrayMaxIndexOfElementsInRow[j]) = (arrayMaxIndexOfElementsInRow[j], arrayMaxIndexOfElementsInRow[j - 1]);
                    }
                }
            }
        }

        public int GetRowMax(int[,] matrix, int row) {
            int cols = matrix.GetLength(1);

            int mx = int.MinValue;
            for (int col = 0; col < cols; col++)
            {
                if (matrix[row, col] > mx)
                    mx = matrix[row, col];
            }
            return mx;
        }

        public int[] FindNegativeCountPerRow(int[,] matrix) 
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] array = new int[rows];
            int index = 0;

            for (int row = 0; row < rows; row++)
            {
                int countNegativeNumbersInRow = 0;
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] < 0)
                        countNegativeNumbersInRow++;
                }

                array[index++] = countNegativeNumbersInRow;
            }
            return array;
        }

        public int[] FindMaxNegativePerColumn(int[,] matrix) 
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[] array = new int[cols];
            int index = 0;

            for (int col = 0; col < cols; col++)
            {
                bool HasColumnNegativeNums = false;
                int mn = int.MinValue;

                for (int row = 0; row < rows; row++)
                {
                    int el = matrix[row, col];
                    if (el < 0 && el > mn)
                    {
                        mn = el;
                        HasColumnNegativeNums = true;
                    }
                }
                array[index++] = HasColumnNegativeNums ? mn : 0;
            }
            return array;
        }

        public int[,] DefineSeq(int[,] matrix)
        {
            int[,] resMatrix = new int[1, 1];
            int[,] emptyMatrix = new int[0, 0];
            int cols = matrix.GetLength(1);
            int counterForAscending = 0;
            int counterForDecinding = 0;
            if (cols < 2) return emptyMatrix;
            for (int col = 0; col < cols - 1; col++)
            {
                int firstRowElFirstCol = matrix[0, col];
                int secondRowElFirstCol = matrix[1, col];
                int firstRowElSecondCol = matrix[0, col + 1];
                int secondRowElSecondCol = matrix[1, col + 1];

                if (secondRowElFirstCol <= secondRowElSecondCol)
                    counterForAscending++;
                if (secondRowElFirstCol >= secondRowElSecondCol)
                    counterForDecinding++;
            }

            int resNum = 0;
            if (counterForAscending == cols - 1)
                resNum++;
            if (counterForDecinding == cols - 1)
                resNum--;
            
            resMatrix[0, 0] = resNum;
            return resMatrix;

        }

        public int[,] FindAllSeq(int[,] matrix)
        {

            int cols = matrix.GetLength(1);
            int[,] emptyMatrix = new int[0, 0];
            if (cols < 2) return emptyMatrix;
            int rowsInResMAtrix = 0;
            int[] arrayY = new int[cols];
            int index = 0;
            for (int col = 0; col < cols; col++)
            {
                arrayY[index++] = matrix[1, col];
            }
            int l = 0;
            int r = 1;
            for (int col = 0; col < cols; col++)
            {
                if (arrayY[l] <= arrayY[r])
                {
                    int startIndex = l;
                    while (r < cols && l < cols && arrayY[l] <= arrayY[r])
                    {
                        l++;
                        r++;
                    }
                    col = l;
                    rowsInResMAtrix++;
                }
                else if (arrayY[l] >= arrayY[r])
                {
                    int startIndex = l;
                    while (r < cols && l < cols && arrayY[l] >= arrayY[r])
                    {
                        l++;
                        r++;
                    }
                    col = l;
                    rowsInResMAtrix++;
                }
            }

            int[,] resMatrix = new int[rowsInResMAtrix, 2];
            int resRow = 0;
            int resCol = 0;
            l = 0;
            r = 1;
            for (int col = 0; col < cols; col++)
            {
                if (arrayY[l] <= arrayY[r])
                {
                    int startIndex = l;
                    while (r < cols && l < cols && arrayY[l] <= arrayY[r])
                    {
                        l++;
                        r++;
                    }
                    col = l;
                    resMatrix[resRow, resCol] = matrix[0, startIndex];
                    resMatrix[resRow, resCol + 1] = matrix[0, l];
                    resRow++;
                }
                else if (arrayY[l] >= arrayY[r])
                {
                    int startIndex = l;
                    while (r < cols && l < cols && arrayY[l] >= arrayY[r])
                    {
                        l++;
                        r++;
                    }
                    col = l;
                    resMatrix[resRow, resCol] = matrix[0, startIndex];
                    resMatrix[resRow, resCol + 1] = matrix[0, l];
                    resRow++;
                }
            }
            return resMatrix;
        }

        public int[,] FindLongestSeq(int[,] matrix)
        {
            int cols = matrix.GetLength(1);
            int[,] emptyMatrix = new int[0, 0];
            if (cols < 2) return emptyMatrix;

            int[] arrayY = new int[cols];
            int index = 0;
            for (int col = 0; col < cols; col++)
            {
                arrayY[index++] = matrix[1, col];
            }

            int[,] resMatrix = new int[1, 2];
            int l = 0;
            int r = 1;
            int mx = 0;
            for (int col = 0; col < cols; col++)
            {
                int interval;

                if (arrayY[l] <= arrayY[r])
                {
                    int startIndex = l;
                    while (r < cols && l < cols && arrayY[l] <= arrayY[r])
                    {
                        l++;
                        r++;
                    }
                    col = l;
                    interval = Math.Abs(matrix[0, l] - matrix[0, startIndex]);
                    if (interval > mx)
                    {
                        mx = interval;
                        resMatrix[0, 0] = matrix[0, startIndex];
                        resMatrix[0, 1] = matrix[0, l];
                    }
                }
                else if (arrayY[l] >= arrayY[r])
                {
                    int startIndex = l;
                    while (r < cols && l < cols && arrayY[l] >= arrayY[r])
                    {
                        l++;
                        r++;
                    }
                    col = l;

                    interval = Math.Abs(matrix[0, l] - matrix[0, startIndex]);
                    if (interval > mx)
                    {
                        mx = interval;
                        resMatrix[0, 0] = matrix[0, startIndex];
                        resMatrix[0, 1] = matrix[0, l];
                    }
                }
            }
            return resMatrix;
        }

        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
        {
            double firstNum = func(a);
            int sign;
            if (firstNum > 0)
                sign = 1;
            else
                sign = 0;

            bool flP;
            bool flN;
            if (sign == 1)
            {
                flP = false;
                flN = true; ;
            }
            else
            {
                flP = true;
                flN = false;
            }
            Console.WriteLine(firstNum);
            int counter = 0;
            for (double i = a + h; i < b + 0.0001; i += h)
            {
                double el = func(i);
                if (el < 0 && flN)
                {
                    counter++;
                    flP = true;
                    flN = false;
                }

                else if (el > 0 && flP)
                {
                    counter++;
                    flN = true;
                    flP = false;
                }
                if (el == 0)
                    counter--;
            }
            Console.WriteLine(counter);
            return counter;
        }

        public double FuncA(double x) => x * x - Math.Sin(x);


        public double FuncB(double x) => Math.Exp(x) - 1;

        public void SortInCheckersOrder(int[][] array) {
            for (int numOfarr = 0; numOfarr < array.Length; numOfarr++)
            {
                Array.Sort(array[numOfarr]);

                if (numOfarr % 2 != 0)
                {
                    Array.Reverse(array[numOfarr]);    
                }
            }
        }

        public void SortBySumDesc(int[][] array) {
            int ln = array.Length;
            int[] sumsArray = new int[ln];
            int index = 0;
            foreach (int[] arr in array)
            {
                int sumOfArr = 0;
                foreach (int item in arr)
                    sumOfArr += item;

                sumsArray[index++] = sumOfArr;
            }

            for (int i = 0; i < ln; i++)
            {
                for (int j = 1; j < ln; j++)
                {
                    if (sumsArray[j - 1] < sumsArray[j])
                    {
                        (sumsArray[j - 1], sumsArray[j]) = (sumsArray[j], sumsArray[j - 1]);
                        (array[j - 1], array[j]) = (array[j], array[j - 1]);
                    }
                }
            }
        }

        public void TotalReverse(int[][] array)
        {
            
            for (int arr = 0; arr < array.Length; arr++)
            {
                Array.Reverse(array[arr]);
            }
            Array.Reverse(array);
            
        }


    }
}
