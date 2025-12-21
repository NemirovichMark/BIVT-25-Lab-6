using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public class Purple
    {
        public bool CheckBox(int[,] matrix)
        {
            if (matrix.GetLength(0) == matrix.GetLength(1)) return true;
            return false;
        }
        public void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex)
        {
            int temp;
            for(int x = 0; x < matrix.GetLength(0); x++)
            {
                temp = matrix[rowIndex, x];
                matrix[rowIndex, x] = B[x, columnIndex];
                B[x, columnIndex] = temp;
            }
        }
        public int FindDiagonalMatrixIndex(int[,] matrix)
        {
            int ind = 0;
            int maxEl = matrix[0, 0];
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                if (matrix[x, x] > maxEl)
                {
                    maxEl = matrix[x, x];
                    ind = x;
                }
                else if (matrix[x, matrix.GetLength(0) - x - 1] > maxEl)
                {
                    maxEl = matrix[x, matrix.GetLength(0) - x - 1];
                    ind = x;
                }
            }
            return ind;
        }
        public void Task1(int[,] A, int[,] B)
        {

            // code here
            if ((CheckBox(A) && CheckBox(B)) && (A.GetLength(0) == B.GetLength(0)))
            {
                int swapXA = FindDiagonalMatrixIndex(A);
                int swapYB = FindDiagonalMatrixIndex(B);
                SwapRowColumn(A, swapXA, B, swapYB);
            }
            //DOOOOOOOOOOOOOOOOOOOO
            // end

        }
        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B)
        {
                    
        }
        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int count = 0;
            for(int x = 0; x < matrix.GetLength(0); x++)
            {
                if (matrix[row, x] > 0) count++;
            }
            return count;
        }
        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {
            int count = 0;
            for (int x = 0; x < matrix.GetLength(1); x++)
            {
                if (matrix[x, col] > 0) count++;
            }
            return count;
        }
        public void Task2(ref int[,] A, int[,] B)
        {

            // code here

            //DOOOOOOOOOOOOOOOOOOOOO
            // end

        }
        public void ChangeMatrixValues(int[,] matrix)
        {
            if (matrix.Length > 5)
            {
                int count = 0;
                int[] maxEls = new int[5];

            }
            else
            {
                for (int x = 0; x < matrix.GetLength(0); x++)
                {
                    for (int y = 0; y < matrix.GetLength(1); y++)
                    {
                        matrix[y, x] *= 2;
                    }
                }
            }
        }
        public void Task3(int[,] matrix)
        {

            // code here
            ChangeMatrixValues(matrix);
            // end

        }
        public int[] CountNegativesPerRow(int[,] matrix)
        {
            return null;
        }
        public int FindMaxIndex(int[] array)
        {
            return 0;
        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here

            // end

        }
        public delegate void Sorting(int[] matrix);
        public void SortNegativeAscending(int[] matrix)
        {

        }
        public void SortNegativeDescending(int[] matrix)
        {

        }
        public void Task5(int[] matrix, Sorting sort)
        {

            // code here
            sort = SortNegativeAscending;
            // end

        }
        //public void Task6(int[,] matrix, SortRowsByMax sort)
        //{

        //    // code here

        //    // end

        //}
        //public int[] Task7(int[,] matrix, FindNegatives find)
        //{
        //    int[] negatives = null;

        //    // code here

        //    // end

        //    return negatives;
        //}
        //public int[,] Task8(int[,] matrix, MathInfo info)
        //{
        //    int[,] answer = null;

        //    // code here

        //    // end

        //    return answer;
        //}
        //public int Task9(double a, double b, double h, Func<double, double> func)
        //{
        //    int answer = 0;

        //    // code here

        //    // end

        //    return answer;
        //}
        //public void Task10(int[][] array, Action<int[][]> func)
        //{

        //    // code here

        //    // end

        //}
    }
}