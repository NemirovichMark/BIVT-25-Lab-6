// namespace Lab6
// {
//     public class Blue
//     {
//         public delegate int Finder(int[,] matrix, out int row, out int col);
//         public delegate void SortRowsStyle(int[,] matrix, int row);
//
//         public delegate void ReplaceMaxElements(int[,] matrix, int row, int maxValue);
//         public void Task1(ref int[,] matrix)
//         {
//
//             // code here
//             int rows = matrix.GetLength(0);
//             int cols = matrix.GetLength(1);
//
//             if (rows != cols)
//             {
//                 return;
//             }
//             int maxIndex = FindDiagonalMaxIndex(matrix);
//             RemoveRow(ref matrix, maxIndex);
//             // end
//
//         }
//
//         public int FindDiagonalMaxIndex(int[,] matrix)
//         {
//             int rows = matrix.GetLength(0);
//
//             int max = matrix[0, 0];
//             int maxIndex = -1;
//
//             for (int i = 0; i < rows; i++)
//             {
//                 if (matrix[i, i] >  max)
//                 {
//                     max = matrix[i, i];
//                     maxIndex = i;
//                 }
//             }
//             
//             return maxIndex;
//         }
//
//         public void RemoveRow(ref int[,] matrix, int rowIndex)
//         {
//             int n = matrix.GetLength(0);
//
//             int[,] result = new int[n-1, n];
//
//             for (int i = 0; i < rowIndex; i++)
//             {
//                 for (int j = 0; j < n; j++)
//                 {
//                     result[i, j] = matrix[i, j];
//                 }
//             }
//
//             for (int i = rowIndex + 1; i < n; i++)
//             {
//                 for (int j = 0; j < n; j++)
//                 {
//                     result[i-1, j] = matrix[i,j];
//                 }
//             }
//             
//             matrix = result;
//         }
//         public int Task2(int[,] A, int[,] B, int[,] C)
//         {
//             int answer = 0; // 1 - increasing   0 - no sequence   -1 - decreasing
//
//             // code here
//             double averageA = GetAverageExceptEdges(A);
//             double averageB = GetAverageExceptEdges(B);
//             double averageC = GetAverageExceptEdges(C);
//
//             double[] temp = [averageA,averageB,averageC];
//             if (temp[0] > temp[1] && temp[1] > temp[2])
//             {
//                 answer = -1;
//             }
//             esle if (temp[0] < temp[1] && temp[1] < temp[2])
//             {
//                 answer = 1;
//             }
//             else
//             {
//                 answer = 0;
//             }
//             // end
//
//             return answer;
//         }
//
//         public double GetAverageExceptEdges(int[,] matrix)
//         {
//             int rows = matrix.GetLength(0);
//             int cols = matrix.GetLength(1);
//             
//             int max = matrix[0, 0];
//
//             int min = matrix[0, 0];
//
//             int generalSum = 0;
//             
//             for (int i = 0; i < rows; i++)
//             {
//                 for (int j = 0; j < cols; j++)
//                 {
//                     generalSum += matrix[i, j];
//                     if (matrix[i, j] > max)
//                         max = matrix[i, j];
//                     if (matrix[i, j] < min)
//                         min = matrix[i, j];
//                 }
//             }
//
//             double sum = generalSum - max - min;
//             double average = sum / (rows*cols - 2);
//             return average;
//         }
//
//         public void Task3(ref int[,] matrix, Func<int[,], int> method)
//         {
//
//             // code here
//             int rows = matrix.GetLength(0);
//             int cols = matrix.GetLength(1);
//             if (rows != cols)
//                 return;
//             int col = method.Invoke(matrix);
//             RemoveColumn(ref matrix, col);
//
//             // end
//
//         }
//
//         public int FindUpperColIndex(int[,] matrix)
//         {
//             int rows = matrix.GetLength(0);
//             int cols = matrix.GetLength(1);
//
//             int max = matrix[0, 0];
//             int index = -1;
//             
//             for (int i = 0; i < rows; i++)
//             {
//                 for (int j = i+1; j < cols; j++)
//                 {
//                     if (matrix[i, j] > max)
//                     {
//                         max = matrix[i, j];
//                         index = j;
//                     }
//                 }
//             }
//             
//             return index;
//         }
//
//         public int FindLowerColIndex(int[,] matrix)
//         {
//             int rows = matrix.GetLength(0);
//             int cols = matrix.GetLength(1);
//
//             int max = matrix[0, 0];
//             int index = -1;
//             
//             for (int i = 0; i < rows; i++)
//             {
//                 for (int j = 0; j <= i; j++)
//                 {
//                     if (matrix[i, j] > max)
//                     {
//                         max = matrix[i, j];
//                         index = j;
//                     }
//                 }
//             }
//             
//             return index;
//         }
//
//         public void RemoveColumn(ref int[,] matrix, int col)
//         {
//             int rows = matrix.GetLength(0);
//             int cols = matrix.GetLength(1);
//             
//             int[,] temp = new int[rows, cols-1];
//
//             for (int i = 0; i < rows; i++)
//             {
//                 int newJ = 0;
//                 for (int j = 0; j < cols - 1; j++)
//                 {
//                     if (j != col)
//                     {
//                         temp[i, newJ++] = matrix[i, j];
//                     }
//                 }
//             }
//             matrix = temp;
//         }
//
//         public void Task4(ref int[,] matrix)
//         {
//
//             // code here
//             int cols = matrix.GetLength(1);
//
//             for (int j = 0; j < cols; j++)
//             {
//                 if (!CheckZerosInColumn(matrix, j))
//                 {
//                     RemoveColumn(ref matrix, j);
//                 }
//             }
//             // end
//
//         }
//
//         public bool CheckZerosInColumn(int[,] matrix, int col)
//         {
//             int rows = matrix.GetLength(0);
//             
//             for (int i = 0; i < rows; i++)
//             {
//                 if (matrix[i, col] == 0)
//                     return true;
//             }
//             return false;
//         }
//         
//         public void Task5(ref int[,] matrix, Finder find)
//         {
//
//             // code here
//             int value = find(matrix, out int row, out int col);
//             
//             int rows = matrix.GetLength(0);
//             int cols = matrix.GetLength(1);
//             
//             for (int i = rows; i >= 0; i--)
//             {
//                 bool toDelete = false;
//                 for (int j = 0; j < cols; j++)
//                 {
//                     if (matrix[i, j] == value)
//                     {
//                         toDelete = true;
//                         break;
//                     }
//                 }
//                 if (toDelete)
//                 {
//                     RemoveRow(ref matrix, i);
//                 }
//             }
//             // end
//
//         }
//
//         public int FindMax(int[,] matrix, out int row, out int col)
//         {
//             int rows =  matrix.GetLength(0);
//             int cols = matrix.GetLength(1);
//             
//             int max = matrix[0, 0];
//             for (int i = 0; i < rows; i++)
//             {
//                 for (int j = 0; j < cols; j++)
//                 {
//                     if (matrix[i, j] > max)
//                     {
//                         max = matrix[i, j];
//                         row = i;
//                         col = j;
//                     }
//                 }
//             }
//         }
//         
//         public int FindMin(int[,] matrix, out int row, out int col)
//         {
//             int rows =  matrix.GetLength(0);
//             int cols = matrix.GetLength(1);
//             
//             int min = matrix[0, 0];
//             for (int i = 0; i < rows; i++)
//             {
//                 for (int j = 0; j < cols; j++)
//                 {
//                     if (matrix[i, j] < min)
//                     {
//                         min = matrix[i, j];
//                         row = i;
//                         col = j;
//                     }
//                 }
//             }
//         }
//
//         public void Task6(int[,] matrix, SortRowsStyle sort)
//         {
//
//             // code here
//             
//             
//             int rows =  matrix.GetLength(0);
//             int cols = matrix.GetLength(1);
//
//             for (int i = 0; i < rows; i+=3)
//             {
//                 sort(matrix, i);
//             }
//             // end
//
//         }
//
//         public void SortRowAscending(int[,] matrix, int row)
//         {
//             int rows = matrix.GetLength(0);
//             int cols = matrix.GetLength(1);
//
//             for (int i = 0; i < rows; i++)
//             {
//                 for (int j = 0; j < cols-i-1; j++)
//                 {
//                     if (matrix[row, j] > matrix[row, j+1])
//                     {
//                         int temp = matrix[row, j];
//                         matrix[row, j] = matrix[row, j+1];
//                         matrix[row, j+1] = temp;
//                     }
//                 }
//             }
//     }
//         public void SortRowDescending(int[,] matrix, int row)
//         {
//             int rows = matrix.GetLength(0);
//             int cols = matrix.GetLength(1);
//
//             for (int i = 0; i < rows; i++)
//             {
//                 for (int j = 0; j < cols-i-1; j++)
//                 {
//                     if (matrix[row, j] < matrix[row, j+1])
//                     {
//                         int temp = matrix[row, j];
//                         matrix[row, j] = matrix[row, j+1];
//                         matrix[row, j+1] = temp;
//                     }
//                 }
//             }
//         }
//
//         public void Task7(int[,] matrix, ReplaceMaxElements transform)
//         {
//
//             // code here
//
//             // end
//
//         }
//
//         public int FindMaxInRow(int[,] matrix, int row)
//         {
//             int rows = matrix.GetLength(0);
//
//             int max = matrix[row, 0];
//             
//             for (int i = 0; i < rows; i++)
//             {
//                 if (matrix[row, i] > max)
//                     max = matrix[row, i];
//             }
//             
//             return max;
//         }
//
//         public double[,] Task8(double a, double b, double h, Func<double, double> getSum, Func<double, double> getY)
//         {
//             double[,] answer = null;
//
//             // code here
//
//             // end
//
//             return answer;
//         }
//         public int Task9(int[,] matrix, GetTriangle triangle)
//         {
//             int answer = 0;
//
//             // code here
//
//             // end
//
//             return answer;
//         }
//         public bool Task10(int[][] array, Predicate<int[][]> func)
//         {
//             bool res = false;
//
//             // code here
//
//             // end
//
//             return res;
//         }
//     }
// }