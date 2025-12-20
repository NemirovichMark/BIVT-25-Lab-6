using System.Linq;
using System.Runtime.InteropServices;

namespace Lab6
{
    public class Green
    {
        public void Task1(ref int[] A, ref int[] B)
        {
            // code here
            DeleteMaxElement(ref A);
            DeleteMaxElement(ref B);
            A = CombineArrays(A, B);
            // end
        }

        public void DeleteMaxElement(ref int[] arr)
        {
            int idxMax = 0;
            for (int k = 1; k < arr.Length; k++)
            {
                if (arr[k] > arr[idxMax])
                {
                    idxMax = k;
                }
            }

            int[] updatedArr = new int[arr.Length - 1];
            int pos = 0;

            for (int m = 0; m < arr.Length; m++)
            {
                if (m != idxMax)
                {
                    updatedArr[pos] = arr[m];
                    pos++;
                }
            }

            arr = updatedArr;
        }

        public int[] CombineArrays(int[] X, int[] Y)
        {
            int[] combined = new int[X.Length + Y.Length];
            for (int p = 0; p < X.Length; p++)
            {
                combined[p] = X[p];
            }

            for (int q = 0; q < Y.Length; q++)
            {
                combined[X.Length + q] = Y[q];
            }

            return combined;
        }

        public void Task2(int[,] matrix, int[] array)
        {
            if (matrix == null || array.Length == 0 || matrix.GetLength(0) != array.Length)
            {
                return;
            }

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                int maxVal = FindMaxInRow(matrix, r, out int c);
                if (maxVal < array[r])
                {
                    matrix[r, c] = array[r];
                }
            }
        }

        public int FindMaxInRow(int[,] mat, int rowIdx, out int colIdx)
        {
            int maxVal = int.MinValue;
            colIdx = 0;
            for (int j = 0; j < mat.GetLength(1); j++)
            {
                if (mat[rowIdx, j] > maxVal)
                {
                    maxVal = mat[rowIdx, j];
                    colIdx = j;
                }
            }
            return maxVal;
        }

        public void Task3(int[,] matrix)
        {
            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }
            FindMax(matrix, out int rowMax, out int colMax);
            int targetCol = colMax;
            SwapColWithDiagonal(matrix, targetCol);
            // end
        }

        public void FindMax(int[,] mat, out int maxRow, out int maxCol)
        {
            int maxValue = int.MinValue;
            int rMax = 0;
            int cMax = 0;
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (mat[i, j] > maxValue)
                    {
                        maxValue = mat[i, j];
                        rMax = i;
                        cMax = j;
                    }
                }
            }
            maxRow = rMax;
            maxCol = cMax;
        }

        public void SwapColWithDiagonal(int[,] mat, int column)
        {
            int colToSwap = column;
            for (int idx = 0; idx < mat.GetLength(0); idx++)
            {
                (mat[idx, idx], mat[idx, colToSwap]) = (mat[idx, colToSwap], mat[idx, idx]);
            }
        }

        public void Task4(ref int[,] matrix)
        {
            // code here
            for (int r = matrix.GetLength(0) - 1; r >= 0; r--)
            {
                bool foundZero = false;
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] == 0)
                    {
                        foundZero = true;
                        break;
                    }
                }

                if (foundZero)
                {
                    RemoveRow(ref matrix, r);
                }
            }
            // end
        }

        public void RemoveRow(ref int[,] mat, int rowToRemove)
        {
            if (mat == null)
                return;

            int rowsCount = mat.GetLength(0);
            int colsCount = mat.GetLength(1);

            if (rowToRemove < 0 || rowToRemove >= rowsCount)
                return;

            if (rowsCount == 1)
            {
                mat = new int[0, colsCount];
                return;
            }

            int[,] newMat = new int[rowsCount - 1, colsCount];

            int newRowIdx = 0;

            for (int i = 0; i < rowsCount; i++)
            {
                if (i != rowToRemove)
                {
                    for (int j = 0; j < colsCount; j++)
                    {
                        newMat[newRowIdx, j] = mat[i, j];
                    }
                    newRowIdx++;
                }
            }
            mat = newMat;
        }

        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            answer = GetRowsMinElements(matrix);
            // end

            return answer;
        }

        public int[] GetRowsMinElements(int[,] mat)
        {
            if (mat == null) return null;
            if (mat.GetLength(0) != mat.GetLength(1))
            {
                return null;
            }

            int[] mins = new int[mat.GetLength(0)];
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                int currentMin = mat[i, i];
                for (int j = i + 1; j < mat.GetLength(1); j++)
                {
                    if (mat[i, j] < currentMin)
                    {
                        currentMin = mat[i, j];
                    }
                }

                mins[i] = currentMin;
            }

            return mins;
        }

        public int[] Task6(int[,] A, int[,] B)
        {
            int[] answer = null;

            // code here
            int[] c = SumPositiveElementsInColumns(A);
            int[] d = SumPositiveElementsInColumns(B);
            // end
            answer = CombineArrays(c, d);
            return answer;
        }

        public int[] SumPositiveElementsInColumns(int[,] mat)
        {
            if (mat == null) return null;
            int[] sums = new int[mat.GetLength(1)];
            for (int col = 0; col < mat.GetLength(1); col++)
            {
                int sum = 0;
                for (int row = 0; row < mat.GetLength(0); row++)
                {
                    if (mat[row, col] > 0)
                    {
                        sum += mat[row, col];
                    }
                }
                sums[col] = sum;
            }
            return sums;
        }

        public void Task7(int[,] matrix, Sorting sort)
        {
            // code here
            sort(matrix);
            // end
        }

        public delegate void Sorting(int[,] matrix);

        public void SortEndAscending(int[,] mat)
        {
            if (mat == null) return;
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                int idxMax = 0;
                int valMax = mat[i, 0];
                for (int j = 1; j < mat.GetLength(1); j++)
                {
                    if (mat[i, j] > valMax)
                    {
                        valMax = mat[i, j];
                        idxMax = j;
                    }
                }

                if (idxMax < mat.GetLength(1) - 1)
                {
                    for (int k = idxMax + 1; k < mat.GetLength(1); k++)
                    {
                        for (int l = idxMax + 1; l < mat.GetLength(1) - 1; l++)
                        {
                            if (mat[i, l] > mat[i, l + 1])
                            {
                                (mat[i, l], mat[i, l + 1]) = (mat[i, l + 1], mat[i, l]);
                            }
                        }
                    }
                }
            }
        }

        public void SortEndDescending(int[,] mat)
        {
            if (mat == null) return;
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                int idxMax = 0;
                int valMax = mat[i, 0];
                for (int j = 1; j < mat.GetLength(1); j++)
                {
                    if (mat[i, j] > valMax)
                    {
                        valMax = mat[i, j];
                        idxMax = j;
                    }
                }

                if (idxMax < mat.GetLength(1) - 1)
                {
                    for (int k = idxMax + 1; k < mat.GetLength(1); k++)
                    {
                        for (int l = idxMax + 1; l < mat.GetLength(1) - 1; l++)
                        {
                            if (mat[i, l] < mat[i, l + 1])
                            {
                                (mat[i, l], mat[i, l + 1]) = (mat[i, l + 1], mat[i, l]);
                            }
                        }
                    }
                }
            }
        }

        public int Task8(double[] A, double[] B)
        {
            int answer = 0;
            double area1 = GeronArea(A[0], A[1], A[2]);
            double area2 = GeronArea(B[0], B[1], B[2]);

            if (area1 > area2) answer = 1;
            else answer = 2;
            return answer;
        }

        public double GeronArea(double side1, double side2, double side3)
        {
            if (side1 <= 0 || side2 <= 0 || side3 <= 0)
            {
                return 0;
            }
            if (side1 + side2 <= side3 || side1 + side3 <= side2 || side2 + side3 <= side1)
            {
                return 0;
            }
            double p = (side1 + side2 + side3) / 2;
            return Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
        }

        public void Task9(int[,] matrix, Action<int[]> sorter)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                if (r % 2 == 0)
                {
                    SortMatrixRow(matrix, r, sorter);
                }
            }
        }

        public void SortMatrixRow(int[,] mat, int rowIdx, Action<int[]> sortFunc)
        {
            int[] rowVals = new int[mat.GetLength(1)];
            for (int c = 0; c < mat.GetLength(1); c++)
            {
                rowVals[c] = mat[rowIdx, c];
            }

            sortFunc(rowVals);
            ReplaceRow(mat, rowIdx, rowVals);
        }

        public void ReplaceRow(int[,] mat, int rowIdx, int[] vals)
        {
            for (int c = 0; c < mat.GetLength(1); c++)
            {
                mat[rowIdx, c] = vals[c];
            }
        }

        public void SortDescending(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    }
                }
            }
        }

        public void SortAscending(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    }
                }
            }
        }

        public delegate void Sort();

        public double Task10(int[][] array, Func<int[][], double> func)
        {
            double res = 0;
            res = func(array);
            return res;
        }

        public double CountZeroSum(int[][] arr)
        {
            int zeroSumCount = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (SumArray(arr[i]) == 0)
                {
                    zeroSumCount++;
                }
            }

            return zeroSumCount;
        }

        public static int SumArray(int[] arr)
        {
            int total = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                total += arr[i];
            }

            return total;
        }

        public double FindMedian(int[][] arr)
        {
            int totalCount = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                totalCount += arr[i].Length;
            }

            int[] allValues = new int[totalCount];
            int pos = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    allValues[pos] = arr[i][j];
                    pos++;
                }
            }

            SortAscending(allValues);

            double median;
            if (allValues.Length % 2 != 0)
            {
                median = allValues[allValues.Length / 2];
            }
            else
            {
                int midIdx = allValues.Length / 2;
                double val1 = allValues[midIdx - 1];
                double val2 = allValues[midIdx];
                median = (val1 + val2) / 2.0;
            }

            return median;
        }

        public double CountLargeElements(int[][] arr)
        {
            int counter = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Length == 0) continue;
                double avg = (double)SumArray(arr[i]) / arr[i].Length;
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] > avg)
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        public delegate double Func(int[][] array);
    }
}
