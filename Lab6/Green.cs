using System.Globalization;

namespace Lab6;

public class Green
{
    public void DeleteMaxElement(ref int[] array)
    {
        int maxElement = array[0];
        int maxIndex = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > maxElement)
            {
                maxElement = array[i];
                maxIndex = i;
            }
        }
        int[] newArray = new int[array.Length - 1];
        int newIndex = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (i != maxIndex)
            {
                newArray[newIndex] = array[i];
                newIndex++;
            }
        }
        array = newArray;
    }
    public int[] CombineArrays(int[] A, int[] B)
    {
        int[] comb = new int[A.Length + B.Length];
        int index = 0;
        for (int i = 0; i < A.Length; i++)
        {
            comb[index] = A[i];
            index++;
        }
        for (int i = 0; i < B.Length; i++)
        {
            comb[index] = B[i];
            index++;
        }
        return comb;
    }
    public void Task1(ref int[] A, ref int[] B)
    {

        // code here
        DeleteMaxElement(ref A);
        DeleteMaxElement(ref B);
        int[] newArray = CombineArrays(A, B);
        A = newArray;
        // end

    }
    public int FindMaxInRow(int[,] matrix, int row, out int col)
    {
        int max = matrix[row, 0];
        col = 0;
        for (int j = 1; j < matrix.GetLength(1); j++)
        {
            if (matrix[row, j] > max)
            {
                max = matrix[row, j];
                col = j;
            }
        }
        return max;
    }
    public void Task2(int[,] matrix, int[] array)
    {

        // code here
        if (matrix.GetLength(0) != array.Length)
        {
            return;
        }
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int maxr, maxc;
            maxr = FindMaxInRow(matrix, i, out maxc);
            if (maxr < array[i])
            {
                matrix[i, maxc] = array[i];
            }
        }
        // end

    }
    public void FindMax(int[,] matrix, out int row, out int col)
    {
        if (matrix.GetLength(0) != matrix.GetLength(1))
        {

        }
        int mx = matrix[0, 0];
        row = 0;
        col = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > mx)
                {
                    mx = matrix[i, j];
                    row = i;
                    col = j;
                }
            }
        }
    }
    public void SwapColWithDiagonal(int[,] matrix, int colToSwap)
    {
        if (matrix.GetLength(0) != matrix.GetLength(1))
        {

        }
        int n = matrix.GetLength(0);
        if (colToSwap < 0 || colToSwap >= n)
        {

        }
        for (int i = 0; i < n; i++)
        {
            int temp = matrix[i, colToSwap];
            matrix[i, colToSwap] = matrix[i, i];
            matrix[i, i] = temp;
        }
    }
    public void Task3(int[,] matrix)
    {

        // code here
        if (matrix.GetLength(0) != matrix.GetLength(1))
        {

        }
        else
        {
            int row, col;
            FindMax(matrix, out row, out col);
            SwapColWithDiagonal(matrix, col);
        }
        // end

    }
    public void RemoveRow(ref int[,] matrix, int rowToRemove)
    {
        int ctrow = matrix.GetLength(0) - 1;
        int ctcol = matrix.GetLength(1);
        int[,] newMatrix = new int[ctrow, ctcol];
        int index = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (i != rowToRemove)
            {
                for (int j = 0; j < ctcol; j++)
                {
                    newMatrix[index, j] = matrix[i, j];
                }
                index++;
            }
        }
        matrix = newMatrix;
    }
    public void Task4(ref int[,] matrix)
    {

        // code here
        for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
        {
            bool zero = false;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 0)
                {
                    zero = true;
                    break;
                }
            }
            if (zero)
            {
                RemoveRow(ref matrix, i);
            }
        }
        // end

    }
    public int[] GetRowsMinElements(int[,] matrix)
    {
        if (matrix.GetLength(0) != matrix.GetLength(1))
        {

        }

        int size = matrix.GetLength(0);
        int[] res = new int[size];
        int resind = 0;
        for (int i = 0; i < size; i++)
        {
            int min = 1000000000;
            bool elem = false;

            for (int j = i; j < size; j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                    elem = true;
                }
            }
            if (elem)
            {
                res[resind++] = min;
            }
        }
        if (resind < size)
        {
            int[] asw = new int[resind];
            Array.Copy(res, asw, resind);
            return asw;
        }
        else
        {
            return res;
        }
    }
    public int[] Task5(int[,] matrix)
    {
        int[] answer = null;

        // code here
        if (matrix.GetLength(0) != matrix.GetLength(1))
        {

        }
        else
        {
            answer = GetRowsMinElements(matrix);
        }
        // end

        return answer;
    }
    public int[] SumPositiveElementsInColumns(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int[] sums = new int[cols];
        for (int j = 0; j < cols; j++)
        {
            int sum = 0;
            bool pos = false;
            for (int i = 0; i < rows; i++)
            {
                int elem = matrix[i, j];
                if (elem > 0)
                {
                    sum += elem;
                    pos = true;
                }
            }
            sums[j] = sum;
        }
        return sums;
    }
    public int[] Task6(int[,] A, int[,] B)
    {
        int[] answer = null;

        // code here
        int[] sums1 = SumPositiveElementsInColumns(A);
        int[] sums2 = SumPositiveElementsInColumns(B);
        answer = CombineArrays(sums1, sums2);
        // end

        return answer;
    }
    public delegate void Sorting(int[,] matrix);

    public void SortEndAscending(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            int max = -10000000;
            int maxindex = -1;
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    maxindex = j;
                }
            }
            if (maxindex != -1 && maxindex < cols - 1)
            {
                int[] elems = new int[cols - 1 - maxindex];
                for (int k = 0; k < elems.Length; k++)
                {
                    elems[k] = matrix[i, maxindex + 1 + k];
                }
                Array.Sort(elems);
                for (int k = 0; k < elems.Length; k++)
                {
                    matrix[i, maxindex + 1 + k] = elems[k];
                }
            }
        }
    }
    public void SortEndDescending(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            int max = -10000000;
            int maxindex = -1;
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    maxindex = j;
                }
            }
            if (maxindex != -1 && maxindex < cols - 1)
            {
                int[] elems = new int[cols - 1 - maxindex];
                for (int k = 0; k < elems.Length; k++)
                {
                    elems[k] = matrix[i, maxindex + 1 + k];
                }
                Array.Sort(elems);
                Array.Reverse(elems);

                for (int k = 0; k < elems.Length; k++)
                {
                    matrix[i, maxindex + 1 + k] = elems[k];
                }
            }
        }
    }
    public void Task7(int[,] matrix, Sorting sort)
    {

        // code here
        Sorting asc = SortEndAscending;
        Sorting desc = SortEndDescending;
        sort(matrix);
        // end

    }
    public double GeronArea(double a, double b, double c)
    {
        if (a <= 0 || b <= 0 || c <= 0 || a + b <= c || a + c <= b || b + c <= a)
        {
            return 0;
        }
        double p = (a + b + c) / 2.0;
        double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

        return s;
    }
    public int Task8(double[] A, double[] B)
    {
        int answer = 0;

        // code here
        if (GeronArea(A[0], A[1], A[2]) > GeronArea(B[0], B[1], B[2]))
        {
            answer = 1;
        }
        else
        {
            answer = 2;
        }
        // end

        return answer;
    }
    public int[] SortMatrixRow(int[,] matrix, int row)
    {
        int cols = matrix.GetLength(1);
        int[] rowarr = new int[cols];

        for (int col = 0; col < cols; col++)
        {
            rowarr[col] = matrix[row, col];
        }
        return rowarr;
    }
    public void ReplaceRow(int[,] matrix, int row, int[] array)
    {
        int cols = matrix.GetLength(1);

        for (int col = 0; col < cols; col++)
        {
            matrix[row, col] = array[col];
        }
    }
    public void SortAscending(int[] array)
    {
        Array.Sort(array);
    }
    public void SortDescending(int[] array)
    {
        Array.Sort(array);
        Array.Reverse(array);
    }
    public void Task9(int[,] matrix, Action<int[]> sorter)
    {

        // code here
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            if (row % 2 == 0)
            {
                int[] rowc = SortMatrixRow(matrix, row);
                sorter(rowc);
                ReplaceRow(matrix, row, rowc);
            }
        }
        // end

    }
    public double CountZeroSum(int[][] array)
    {
        int count = 0;
        for (int i = 0; i < array.Length; i++)
        {
            var pdm = array[i];
            if (pdm != null && pdm.Sum() == 0)
            {
                count++;
            }
        }
        return count;
    }
    public double FindMedian(int[][] array)
    {
        int elems = 0;
        for (int i = 0; i < array.Length; i++)
        {
            elems += array[i].Length;
        }
        if (elems == 0)
        {
            return 0;
        }
        int[] mass = new int[elems];
        int index = 0;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array[i].Length; j++)
            {
                mass[index++] = array[i][j];
            }
        }
        Array.Sort(mass);
        if (elems % 2 == 0)
        {
            int avg1 = mass[elems / 2 - 1];
            int avg2 = mass[elems / 2];
            return (double)(avg1 + avg2) / 2.0;
        }
        else
        {
            return mass[elems / 2];
        }
    }
    public double CountLargeElements(int[][] array)
    {
        double ct = 0;
        for (int i = 0; i < array.Length; i++)
        {
            long sum = 0;
            for (int j = 0; j < array[i].Length; j++)
            {
                sum += array[i][j];
            }
            double avg = (double)sum / array[i].Length;
            for (int j = 0; j < array[i].Length; j++)
            {
                if (array[i][j] > avg)
                {
                    ct++;
                }
            }
        }
        return ct;
    }
    public double Task10(int[][] array, Func<int[][], double> func)
    {
        double res = 0;

        // code here
        res = func(array);
        // end

        return res;
    }
}