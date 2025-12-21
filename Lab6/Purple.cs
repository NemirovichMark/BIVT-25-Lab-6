using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.IO.Pipelines;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public class Purple
    {
        public int FindDiagonalMaxIndex(int[,] matrix){
            int n = matrix.GetLength(0);
            int ma = matrix[0, 0], indma = 0;
            for (int i = 0; i < n;i++){
                if (matrix[i, i] > ma){
                    ma = matrix[i, i];
                    indma = i;
                }
            }
            return indma;
        }
        public void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex){
            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i++){
                (matrix[rowIndex, i], B[i, columnIndex]) = (B[i, columnIndex], matrix[rowIndex, i]);
            }
        }
        public void Task1(int[,] A, int[,] B)
        {
            if ((A.GetLength(0) == A.GetLength(1)) &&  (A.GetLength(0) == B.GetLength(1)) && (B.GetLength(0) == B.GetLength(1)) && (A.GetLength(0) != 0)){
                int rowIndex = FindDiagonalMaxIndex(A), columnIndex = FindDiagonalMaxIndex(B);
                SwapRowColumn(A, rowIndex, B, columnIndex);
            }

        }

        public int CountPositiveElementsInRow(int[,] matrix, int row){
            int n1 = matrix.GetLength(1);
            int kpol = 0;
            for (int j = 0; j < n1; j++){
                if(matrix[row, j]>0){
                    kpol++;
                }
            }
            return kpol;
        }
        public int CountPositiveElementsInColumn(int[,] matrix, int col){
            int n = matrix.GetLength(0);
            int kpol = 0;
            for (int i = 0; i < n; i++){
                if (matrix[i, col] > 0){
                    kpol++;;
                }
            }
            return kpol;
        }
        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B){
            int n = A.GetLength(0)+1, n1 = A.GetLength(1);
            int[,] A1 = new int[n, n1];
            int i1 = -1;
            for(int i = 0; i < n; i++){
                i1++;
                if (i != rowIndex+1){
                    for (int j = 0; j < n1; j++){
                        A1[i, j] = A[i1, j];
                    }
                }
                else{
                    int t = B.GetLength(0);
                    i1--;
                    for(int j = 0; j < t; j++){
                        A1[i, j] = B[j, columnIndex];
                    }
                }
            }
            A = A1;
        }
        public void Task2(ref int[,] A, int[,] B)
        {
            if (A.GetLength(1) == B.GetLength(0)){
                int n = A.GetLength(0), pol = 0, ind = -1;
                for (int i = 0; i < n; i++){
                    int t = CountPositiveElementsInRow(A, i);
                    if(pol < t){
                        (pol, ind) = (t, i);
                    }
                }
                int n1 = B.GetLength(1);
                int pol1 = 0, ind1 = -1;
                for (int j = 0; j < n1; j++){
                    int t1 = CountPositiveElementsInColumn(B, j);
                    if (t1 > pol1){
                        (pol1, ind1) = (t1, j);
                    }    
                }
                if (ind > -1 && ind1 > -1){
                    InsertColumn(ref A, ind, ind1, B);
                }

            }

        }
        public void ChangeMatrixValues(int[,] matrix){
            int[] ma = new int[matrix.Length];
            int n = matrix.GetLength(0), n1 = matrix.GetLength(1);
            int i1 = 0;

            for (int i = 0; i < n; i++){
                for (int j = 0; j < n1; j++){
                    ma[i1++] = matrix[i, j];
                }
            }
 
            int l = ma.Length;
            for(int i = 0; i < l-1; i++){
                for(int j = 0; j < l-i-1; j++){
                    if (ma[j] < ma[j+1]){
                        (ma[j], ma[j+1]) = (ma[j+1], ma[j]);
                    }
                }
            }

            int[,] ArrayOfIndexes = new int[5, 2];
            for (int i = 0; i < ArrayOfIndexes.GetLength(0); i++) {
                for (int j = 0; j < ArrayOfIndexes.GetLength(1); j++) {
                    ArrayOfIndexes[i, j] = -1;
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++) {
                for (int  j = 0; j < matrix.GetLength(1); j++) {
                    for (int k = 0; k < 5; k++) {
                        if ((ma[k] == matrix[i, j]) && (ArrayOfIndexes[k, 0] == -1) && (ArrayOfIndexes[k, 1] == -1)) {
                        ArrayOfIndexes[k, 0] = i;
                        ArrayOfIndexes[k, 1] = j;
                        break;
                        }
                    }
                }
            }


            for(int i = 0; i < matrix.GetLength(0); i++) {
                for (int j = 0; j < matrix.GetLength(1); j++) {
                    bool changed = false;
                    for (int k = 0; k < 5; k++) {
                        if ((ArrayOfIndexes[k, 0] == i) && (ArrayOfIndexes[k, 1] == j)) {
                            matrix[i, j] *= 2;
                            changed = true;
                            break;  
                        }
                    }
                    if (changed == false) {
                        matrix[i, j] /= 2;
                    }
                }
            }
        }
        public void Task3(int[,] matrix)
        {
            if (matrix.Length < 5){
                int n = matrix.GetLength(0), n1 = matrix.GetLength(1);
                for(int i = 0; i < n; i++){
                    for(int j = 0; j < n1; j++){
                        matrix[i, j] *= 2;
                    }
                }
            }
            else{
                ChangeMatrixValues(matrix);
            }

        }
        public int[] CountNegativesPerRow(int[,] matrix){
            int n = matrix.GetLength(0), n1 = matrix.GetLength(1);
            int[] arr = new int[n];
            for(int i = 0; i < n; i++){
                int otr = 0;
                for (int j = 0; j < n1; j++){
                    if (matrix[i, j] < 0){
                        otr++;
                    }
                }
                arr[i] = otr;
            }
            return arr;
        }
        public int FindMaxIndex(int[] array){
            int ma = 0, indma = -1;
            int n = array.Length;
            for (int i = 0; i < n; i++){
                if (ma < array[i]){
                    ma = array[i];
                    indma = i;
                }
            }
            return indma;
        }
        public void Task4(int[,] A, int[,] B)
        {

            if (A.GetLength(1) == B.GetLength(1)){
                int a = FindMaxIndex(CountNegativesPerRow(A)), b = FindMaxIndex(CountNegativesPerRow(B));
                if (a > -1 && b > -1){
                    int n1 = A.GetLength(1);
                    for (int j = 0; j < n1; j++){
                        (A[a, j], B[b, j]) = (B[b, j], A[a, j]);
                    }
                }
            }

        }
        public delegate void Sorting(int[] matrix);
        public void SortNegativeAscending(int[] matrix){
            int kotr = 0;
            foreach(int x in matrix){
                if (x < 0){
                    kotr++;
                }
            }
            if(kotr > 0){
                int[] otr = new int[kotr];
                int i1 = 0;
                foreach(int x in matrix){
                    if(x < 0){
                        otr[i1++] = x;
                    }
                }
                for(int i = 0; i < i1-1; i++){
                    for(int j = 0; j < i1-i-1; j++){
                        if (otr[j+1] < otr[j]){
                            (otr[j+1], otr[j]) = (otr[j], otr[j+1]);
                        }
                    }
                }
                int n = matrix.Length;
                i1 = 0;
                for(int i = 0; i < n; i++){
                    if(matrix[i] < 0){
                        matrix[i] = otr[i1++];
                    }
                }
            }

        }
        public void SortNegativeDescending(int[] matrix){
            int kotr = 0;
            foreach(int x in matrix){
                if (x < 0){
                    kotr++;
                }
            }
            if(kotr > 0){
                int[] otr = new int[kotr];
                int i1 = 0;
                foreach(int x in matrix){
                    if(x < 0){
                        otr[i1++] = x;
                    }
                }
                for(int i = 0; i < i1-1; i++){
                    for(int j = 0; j < i1-i-1; j++){
                        if (otr[j+1] > otr[j]){
                            (otr[j+1], otr[j]) = (otr[j], otr[j+1]);
                        }
                    }
                }
                int n = matrix.Length;
                i1 = 0;
                for(int i = 0; i < n; i++){
                    if(matrix[i] < 0){
                        matrix[i] = otr[i1++];
                    }
                }
            }

        }
        public void Task5(int[] matrix, Sorting sort)
        {

            sort(matrix);

        }

        public delegate void SortRowsByMax(int[,] matrix);
        public void SortRowsByMaxAscending(int[,] matrix){
            int n = matrix.GetLength(0), n1 = matrix.GetLength(1), i1 = 0;
            int[,] ma = new int[n, 2];
            for (int i = 0; i < n; i++){
                ma[i1, 0] = GetRowMax(matrix, i);
                ma[i1++, 1] = i;
            }
            for (int i = 0; i < i1-1; i++){
                for(int j =0; j < i1-i-1; j++){
                    if(ma[j, 0] > ma[j+1, 0]){
                        (ma[j, 0], ma[j, 1], ma[j+1, 0], ma[j+1, 1]) = (ma[j+1, 0], ma[j+1, 1], ma[j, 0], ma[j, 1]);
                    }
                }
            }
            int[,] matr = new int[n, n1];
            for (int i = 0; i < n; i++){
                for(int j = 0; j < n1; j++){
                    matr[i, j] = matrix[ma[i, 1], j];
                }
            }
            for (int i = 0; i < n; i++){
                for (int j = 0; j < n1; j++){
                    matrix[i, j] = matr[i, j];
                }
            }
        }
        public void SortRowsByMaxDescending(int[,] matrix){
            int n = matrix.GetLength(0), n1 = matrix.GetLength(1), i1 = 0;
            int[,] ma = new int[n, 2];
            for (int i = 0; i < n; i++){
                ma[i1, 0] = GetRowMax(matrix, i);
                ma[i1++, 1] = i;
            }
            for (int i = 0; i < i1-1; i++){
                for(int j =0; j < i1-i-1; j++){
                    if(ma[j+1, 0] > ma[j, 0]){
                        (ma[j, 0], ma[j, 1], ma[j+1, 0], ma[j+1, 1]) = (ma[j+1, 0], ma[j+1, 1], ma[j, 0], ma[j, 1]);
                    }
                }
            }
            int[,] matr = new int[n, n1];
            for (int i = 0; i < n; i++){
                for(int j = 0; j < n1; j++){
                    matr[i, j] = matrix[ma[i, 1], j];
                }
            }
            for (int i = 0; i < n; i++){
                for (int j = 0; j < n1; j++){
                    matrix[i, j] = matr[i, j];
                }
            }
        }
        public int GetRowMax(int[,] matrix, int row){
            int n = matrix.GetLength(1);
            int ma = matrix[row, 0];
            for(int i = 0; i < n; i++){
                if (matrix[row, i] > ma){
                    ma = matrix[row, i];
                }
            }
            return ma;
        }
        public void Task6(int[,] matrix, SortRowsByMax sort)
        {

            sort(matrix);

        }

        public delegate int[] FindNegatives(int[,] matrix);
        public int[] FindNegativeCountPerRow(int[,] matrix){
            int n = matrix.GetLength(0), n1 = matrix.GetLength(1);
            int[] arr = new int[n];
            for (int i = 0; i < n; i++){
                int kol = 0;
                for (int j = 0; j < n1; j++){
                    if (matrix[i, j] < 0){
                        kol++;
                    }
                }
                arr[i] = kol;
            }
            return arr;
        }
        public int[] FindMaxNegativePerColumn(int[,] matrix){
            int n = matrix.GetLength(0), n1 = matrix.GetLength(1);
            int[] arr = new int[n1];
            for (int j = 0; j < n1; j++){
                int k = 0;
                for (int i = 0; i < n; i++){
                    if(matrix[i, j] < 0){
                        if(k == 0){
                            k = matrix[i, j];
                        }
                        else if(k < matrix[i, j]){
                            k = matrix[i, j];
                        }
                    }
                }
                arr[j] = k;
            }
            return arr;
        }
        public int[] Task7(int[,] matrix, FindNegatives find)
        {
            int[] negatives = find(matrix);

            return negatives;
        }

        public delegate int[,] MathInfo(int[,] matrix);
        public int[,] DefineSeq(int[,] matrix){
            int n = matrix.GetLength(0), n1 = matrix.GetLength(1);
            int[,] arr;
            int k = -2;
            for (int j = 0; j < n1-1; j++){
                if (k == -2){
                    if (matrix[1, j] < matrix[1, j+1]){
                        k = 1;
                    }
                    else if(matrix[1, j] > matrix[1, j+1]){
                        k = -1;
                    }
                }
                else if(((matrix[1, j] < matrix[1, j+1]) && (k == -1)) || ((matrix[1, j] > matrix[1, j+1]) && (k == 1))){
                    k = 0;
                    break;
                }
            }
            if (k == -2){
                return new int[0, 0];
            }
            arr = new int[1, 1];
            arr[0, 0] = k;
            return arr;
        }
        public int[,] FindAllSeq(int[,] matrix){
            if (matrix.GetLength(0) < 2 || matrix.GetLength(1) < 2) return new int[0, 0];
            
            int cols = matrix.GetLength(1);
            int[,] buffer = new int[cols, 2];
            int count = 0;
            
            int start = 0;
            int dir = 0;
            
            for (int i = 1; i < cols; i++)
            {
                int prev = matrix[1, i - 1];
                int curr = matrix[1, i];
                
                int newDir;
                if (curr > prev) 
                    newDir = 1;
                else if (curr < prev) 
                    newDir = -1;
                else 
                    newDir = dir;
                
                if (dir != 0 && newDir != dir)
                {
                    buffer[count, 0] = matrix[0, start];
                    buffer[count, 1] = matrix[0, i - 1];
                    count++;
                    start = i - 1;
                    dir = newDir;
                }
                
                if (dir == 0 && newDir != 0)
                {
                    dir = newDir; 
                }
            }
            
            if (dir != 0 && start < cols - 1)
            {
                buffer[count, 0] = matrix[0, start];
                buffer[count, 1] = matrix[0, cols - 1];
                count++;
            }
            
            if (count == 0) return new int[0, 0];
            
            int[,] result = new int[count, 2];
            for (int i = 0; i < count; i++)
            {
                result[i, 0] = buffer[i, 0];
                result[i, 1] = buffer[i, 1];
            }
            
            return result;
        }

        public int[,] FindLongestSeq(int[,] matrix){
            int[,] arr = FindAllSeq(matrix);
            int[,] ar;
            if (arr.Length == 0){
                return new int[0, 0];
            }
            else{
                ar = new int[1, 2];
            }
            int n = arr.GetLength(0);
            int ma = arr[0, 1] - arr[0, 0], indma = 0;
            for(int i = 0; i < n; i++){
                if (arr[i, 1] - arr[i, 0] > ma){
                    ma = arr[i, 1] - arr[i, 0];
                    indma = i;
                }
            }
            (ar[0, 0], ar[0, 1]) = (arr[indma, 0], arr[indma, 1]);
            return ar;
        }
        public int[,] Task8(int[,] matrix, MathInfo info)
        {
            int[,] answer = info(matrix);

            return answer;
        }
        
        public delegate double Func(double x);
        
        public double FuncA(double x)
        {
            return x * x  - Math.Sin(x);
        }

        public double FuncB(double x)
        {
            return Math.Exp(x) - 1;
        }
        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
{
    // Защита от некорректных входных данных
    if (Math.Abs(h) < double.Epsilon) // h близко к 0
        return 0;
        
    if (Math.Abs(b - a) < double.Epsilon) // интервал нулевой длины
        return 0;
        
    // Определяем направление движения
    double start = a;
    double end = b;
    double step = h;
    
    if (a > b)
    {
        start = b;
        end = a;
        step = -h; // идем в обратном направлении
    }
    
    // Более точное вычисление количества шагов
    int steps = (int)Math.Floor(Math.Abs((end - start) / Math.Abs(step)));
    int flipCount = 0;
    
    double current = start;
    
    for (int i = 0; i < steps; i++)
    {
        double next = current + step;
        
        // Проверяем смену знака
        double value1 = func(current);
        double value2 = func(next);
        
        // Учитываем случаи, когда функция равна 0
        if (value1 * value2 < 0)
        {
            flipCount++;
        }
        
        current = next;
    }
    
    return flipCount;
}
        public int Task9(double a, double b, double h, Func<double, double> func)
        {
            int answer = CountSignFlips(a, b, h, func);

            return answer;
        }
        public void SortInCheckersOrder(int[][] matrix)
        {
            int rowLength = 0;
            
            for (int row = 0; row < matrix.Length; row += 2)
            {
                rowLength = matrix[row].Length;
                for (int pass = 0; pass < rowLength - 1; pass++)
                {
                    for (int col = 0; col < rowLength - 1 - pass; col++)
                    {
                        if (matrix[row][col] > matrix[row][col + 1])
                        {
                            (matrix[row][col], matrix[row][col + 1]) = (matrix[row][col + 1], matrix[row][col]);
                        }
                    }
                }
            }
            
            for (int row = 1; row < matrix.Length; row += 2)
            {
                rowLength = matrix[row].Length;
                for (int pass = 0; pass < rowLength - 1; pass++)
                {
                    for (int col = 0; col < rowLength - 1 - pass; col++)
                    {
                        if (matrix[row][col] < matrix[row][col + 1])
                        {
                            (matrix[row][col], matrix[row][col + 1]) = (matrix[row][col + 1], matrix[row][col]);
                        }
                    }
                }
            }
        }

        public void SortBySumDesc(int[][] matrix)
        {
            int rowCount = matrix.Length;
            int[] rowSums = new int[rowCount];
            
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    rowSums[row] += matrix[row][col];
                }
            }

            for (int pass = 0; pass < rowCount - 1; pass++)
            {
                for (int current = 0; current < rowCount - 1 - pass; current++)
                {
                    if (rowSums[current] < rowSums[current + 1])
                    {
                        (rowSums[current + 1], rowSums[current]) = (rowSums[current], rowSums[current + 1]);
                        (matrix[current], matrix[current + 1]) = (matrix[current + 1], matrix[current]);
                    }
                }
            }
        }
        public void TotalReverse(int[][] matrix)
        {
            int rowCount = matrix.Length;
            for (int currentRow = 0; currentRow < (rowCount + 1) / 2; currentRow++)
            {
                for (int colIndex = 0; colIndex < matrix[currentRow].Length / 2; colIndex++)
                {
                    int oppositeColIndex = matrix[currentRow].Length - colIndex - 1;
                    (matrix[currentRow][colIndex], matrix[currentRow][oppositeColIndex]) = (matrix[currentRow][oppositeColIndex], matrix[currentRow][colIndex]);
                }
                int oppositeRow = rowCount - currentRow - 1;
                if (oppositeRow != currentRow)
                {
                    for (int colIndex = 0; colIndex < matrix[oppositeRow].Length / 2; colIndex++)
                    {
                        int oppositeColIndex = matrix[oppositeRow].Length - colIndex - 1;
                        (matrix[oppositeRow][colIndex], matrix[oppositeRow][oppositeColIndex]) = (matrix[oppositeRow][oppositeColIndex], matrix[oppositeRow][colIndex]);
                    }
                    (matrix[currentRow], matrix[oppositeRow]) = (matrix[oppositeRow], matrix[currentRow]);
                }
            }
        }
        public void Task10(int[][] array, Action<int[][]> func)
        {
            func(array);

        }
    }
}