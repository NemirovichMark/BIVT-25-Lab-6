using System;

namespace Lab6
{
  public class Blue
  {

    public void Write(int n)
    {
      Console.WriteLine($"{n}\n");
    }

    public void Write(int[] array)
    {
      int n = array.Length;
      for (int i = 0; i < n; i++)
        Console.Write(array[i] + "\t"); 
      Console.WriteLine("\n");
    }

    public void Write(bool[] array)
    {
      int n = array.Length;
      for (int i = 0; i < n; i++)
        Console.Write(array[i] + "\t");
      Console.WriteLine("\n");
    }

    public void Write(int[,] matrix)
    {
      int n = matrix.GetLength(0), m = matrix.GetLength(1);
      for (int i = 0; i < n; i++)
      {
        for (int j = 0; j < m; j++)
          Console.Write(matrix[i,j] + "\t");
        Console.WriteLine();
      }
      Console.WriteLine();
    }

    public void Write(int[][] array)
    {
      for (int i = 0; i < array.Length; i++)
      {
        for (int j = 0; j < array[i].Length; j++)
          Console.Write(array[i][j] + "\t");
        Console.WriteLine();
      }
      Console.WriteLine();
    }

    public void Write(double[,] matrix)
    {
      int n = matrix.GetLength(0), m = matrix.GetLength(1);
      for (int i = 0; i < n; i++)
      {
        for (int j = 0; j < m; j++)
          Console.Write(matrix[i, j] + "\t");
        Console.WriteLine();
      }
      Console.WriteLine();
    }

        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int rowIndex = 0;
            int max = 0;
            int sch = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        if (matrix[i, j] > max)
                        {
                            rowIndex = sch;
                            max = matrix[i, j];
                        }
                        sch++;

                    }
                }
            }
            return rowIndex;
        }

        public void RemoveRow(ref int[,] matrix, int rowIndex)
        {
            int[,] Matrix2 = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            int a = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i != rowIndex)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Matrix2[i - a, j] = matrix[i, j];
                    }
                }
                else
                {
                    a++;
                }
            }
            matrix = Matrix2;
        }

        public void Task1(ref int[,] matrix)
        {
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {

                // code here
                RemoveRow(ref matrix, FindDiagonalMaxIndex(matrix));

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write($"{matrix[i, j],3}, ");
                    }
                    Console.WriteLine();
                }

            }
            // end

        }

        public double GetAverageExceptEdges(int[,] matrix)
    {
      double sum = 0;
      int n = matrix.GetLength(0), m = matrix.GetLength(1), mx = matrix[0, 0], mn = matrix[0, 0];
      for (int i = 0; i < n; i++)
        for (int j = 0; j < m; j++)
        {
          if (matrix[i, j] > mx)
            mx = matrix[i, j];
          if (matrix[i, j] < mn)
            mn = matrix[i, j];
          sum += matrix[i, j];
        }
      return ((sum - mx - mn) / (n * m - 2));
    }

    public int Task2(int[,] A, int[,] B, int[,] C)
    {
      int answer = 0; // 1 - increasing   0 - no sequence   -1 - decreasing

      // code here
      double[] arr = new double[3];
      arr[0] = GetAverageExceptEdges(A);
      arr[1] = GetAverageExceptEdges(B);
      arr[2] = GetAverageExceptEdges(C);
      if (arr[0] < arr[1] && arr[1] < arr[2])
        answer = 1;
      else if (arr[0] > arr[1] && arr[1] > arr[2])
        answer = -1;
      // end

      return answer;
    }

    public int FindUpperColIndex(int[,] matrix)
    {
      int imx = 0, jmx = 1, n = matrix.GetLength(0), m = matrix.GetLength(1);
      for (int i = 0; i < n; i++)
        for (int j = 0; j < m; j++)
          if (i < j)
            if (matrix[i, j] > matrix[imx, jmx])
              (imx, jmx) = (i, j);
      return jmx;
    }

    public int FindLowerColIndex(int[,] matrix)
    {
      int imx = 0, jmx = 0, n = matrix.GetLength(0), m = matrix.GetLength(1);
      for (int i = 0; i < n; i++)
        for (int j = 0; j < m; j++)
          if (i >= j)
            if (matrix[i, j] > matrix[imx, jmx])
              (imx, jmx) = (i, j);
      return jmx;
    }

    public void RemoveColumn(ref int[,] matrix, int col)
    {
      int n = matrix.GetLength(0), m = matrix.GetLength(1);
      int[,] answer = new int[n, m - 1];
      for (int i = 0; i < n; i++)
      {
        int jj = 0;
        for (int j = 0; j < m; j++)
          if (j != col)
            answer[i, jj++] = matrix[i, j];
      }
      matrix = answer;
    }

    public void Task3(ref int[,] matrix, Func<int[,], int> method)
    {

      // code here
      int n = matrix.GetLength(0), m = matrix.GetLength(1);
      if (method == null) return;
      if (n != m) return;
      int col = method(matrix);
      RemoveColumn(ref matrix, col);
      // end

    }

    public bool CheckZerosInColumn(int[,] matrix, int col)
    {
      bool flag = false;
      int n = matrix.GetLength(0), m = matrix.GetLength(1);
      for (int i = 0; i < n; i++)
        if (matrix[i, col] == 0)
          flag = true;
      return flag;
    }

    public void Task4(ref int[,] matrix)
    {

      // code here
      int m = matrix.GetLength(1);
      for (int j = m - 1; j >= 0; j--)
        if (!CheckZerosInColumn(matrix, j))
          RemoveColumn(ref matrix, j);
      // end

    }

    public delegate int Finder(int[,] matrix, out int row, out int col);

    public int FindMax(int[,] matrix)
    {
      int row, col;
      return FindMax(matrix, out row, out col);
    }

    public int FindMin(int[,] matrix)
    {
      int row, col;
      return FindMin(matrix, out row, out col);
    }

    public int FindMax(int[,] matrix, out int row, out int col)
    {
      int n = matrix.GetLength(0), m = matrix.GetLength(1);
      int mx = matrix[0, 0]; row = 0; col = 0;
      for (int i = 0; i < n; i++)
        for (int j = 0; j < m; j++)
          if (matrix[i, j] > matrix[row, col])
            (row, col, mx) = (i, j, matrix[i, j]);
      return mx;
    }

    public int FindMin(int[,] matrix, out int row, out int col)
    {
      int n = matrix.GetLength(0), m = matrix.GetLength(1);
      int mn = matrix[0, 0]; row = 0; col = 0;
      for (int i = 0; i < n; i++)
        for (int j = 0; j < m; j++)
          if (matrix[i, j] < matrix[row, col])
            (row, col, mn) = (i, j, matrix[i, j]);
      return mn;
    }

    public void Task5(ref int[,] matrix, Finder find)
    {

      // code here
      if (find == null) return;
      int row, col;
      int a = find(matrix, out row, out col);
      int n = matrix.GetLength(0), m = matrix.GetLength(1);
      for (int i = 0; i < n; i++)
      {
        bool flag = false;
        for (int j = 0; j < m; j++)
          if (matrix[i,j] == a)
            flag = true;
        if (flag)
        {
          RemoveRow(ref matrix, i);
          n--;
        }
      }
      // end

    }

    public delegate void SortRowsStyle(int[,] matrix, int row);

    public void SortRowAscending(int[,] matrix, int row)
    {
      int m = matrix.GetLength(1), j = 0;
      while (j < m)
        if ((j == 0) || (matrix[row, j] >= matrix[row, j - 1]))
          j++;
        else
        {
          (matrix[row, j], matrix[row, j - 1]) = (matrix[row, j - 1], matrix[row, j]);
          j--;
        }
    }

    public void SortRowDescending(int[,] matrix, int row)
    {
      int m = matrix.GetLength(1), j = 0;
      while (j < m)
        if ((j == 0) || (matrix[row, j] <= matrix[row, j - 1]))
          j++;
        else
        {
          (matrix[row, j], matrix[row, j - 1]) = (matrix[row, j - 1], matrix[row, j]);
          j--;
        }
    }

    public void Task6(int[,] matrix, SortRowsStyle sort)
    {

      // code here
      if (sort == null) return;
      int row;
      int n = matrix.GetLength(0), m = matrix.GetLength(1);
      for (int i = 0; i < n; i++)
        if (i % 3 == 0)
        {
          sort(matrix, i);
        }
      // end

    }

    public delegate void ReplaceMaxElements(int[,] matrix, int row, int maxValue);

    public int FindMaxInRow(int[,] matrix, int row)
    {
      int mx = int.MinValue, m = matrix.GetLength(1);
      for (int j = 0; j < m; j++)
        if (matrix[row, j] > mx)
          mx = matrix[row, j];
      return mx;
    }

    public void ReplaceByZero(int[,] matrix, int row, int maxValue)
    {
      int m = matrix.GetLength(1);
      for (int j = 0; j < m; j++)
        if (matrix[row, j] == maxValue)
          matrix[row, j] = 0;
    }

    public void MultiplyByColumn(int[,] matrix, int row, int maxValue)
    {
      int m = matrix.GetLength(1);
      for (int j = 0; j < m; j++)
        if (matrix[row, j] == maxValue)
          matrix[row, j] *= (j + 1);
    }

    public void Task7(int[,] matrix, ReplaceMaxElements transform)
    {

      // code here
      int n = matrix.GetLength(0);
      for (int i = 0; i < n; i++)
        transform(matrix, i, FindMaxInRow(matrix, i));
      // end

    }

    public double SumA(double x)
    {
      double S = 1, del = 1;
      for (int i = 1; i <= 10; i++)
      {
        del *= i;
        S += (Math.Cos(i * x) / del);
      }
      return S;
    }

    public double YA(double x)
    {
      return (Math.Pow(Math.E, Math.Cos(x)) * Math.Cos(Math.Sin(x)));
    }

    public double SumB(double x)
    {
      double S = -2.0 * Math.PI * Math.PI / 3.0, sign = 1, t = 1;
      for (int i = 1; Math.Abs(t) >= 0.000001; i++)
      {
        sign *= -1;
        t = sign * (Math.Cos(i * x) / (i * i));
        S += t;
      }
      return S;
    }

    public double YB(double x)
    {
      return (((x * x) / 4) - (3 * (Math.PI * Math.PI) / 4));
    }

    public double[,] GetSumAndY(double a, double b, double h, Func<double, double> sum, Func<double, double> y)
    {
      if (sum == null || y == null) return null;
      if (h == 0) return null;
      if (((a < b) && (h < 0)) || ((a > b) && (h > 0))) h = -h;
      int count = 0;
      for (double x = a; x <= b; x = Math.Round(x + h, 7))
        count++;
      double[,] arr2 = new double[count, 2];
      count = 0;
      for (double x = a; x <= b; x = Math.Round(x + h, 7))
        (arr2[count, 0], arr2[count++, 1]) = (sum(x), y(x));
      return arr2;
    }

    public double[,] Task8(double a, double b, double h, Func<double, double> getSum, Func<double, double> getY)
    {
      double[,] answer = null;

      // code here
      answer = GetSumAndY(a, b, h, getSum, getY);
      // end

      return answer;
    }

    public delegate int[] GetTriangle(int[,] matrix);

    public int Sum(int[] array)
    {
      int answer = 0;
      foreach (int i in array)
        answer += (i * i);
      return answer;
    }

    public int[] GetUpperTriangle(int[,] matrix)
    {
      int count = 0, n = matrix.GetLength(0), m = matrix.GetLength(1);
      for (int i = 0; i < n; i++)
        for (int j = 0; j < m; j++)
          if (i <= j)
          count++;
      int[] answer = new int[count];
      count = 0;
      for (int i = 0; i < n; i++)
        for (int j = 0; j < m; j++)
          if (i <= j)
            answer[count++] = matrix[i, j];
      return answer;
    }

    public int[] GetLowerTriangle(int[,] matrix)
    {
      int count = 0, n = matrix.GetLength(0), m = matrix.GetLength(1);
      for (int i = 0; i < n; i++)
        for (int j = 0; j < m; j++)
          if (i >= j)
            count++;
      int[] answer = new int[count];
      count = 0;
      for (int i = 0; i < n; i++)
        for (int j = 0; j < m; j++)
          if (i >= j)
            answer[count++] = matrix[i, j];
      return answer;
    }

    public int GetSum(GetTriangle transformer, int[,] matrix)
    {
      return Sum(transformer(matrix));
    }

    public int Task9(int[,] matrix, GetTriangle triangle)
    {
      int answer = 0;

      // code here
      int n = matrix.GetLength(0), m = matrix.GetLength(1);
      if (n != m) return answer;
      answer = GetSum(triangle, matrix);
      // end

      return answer;
    }

    public delegate bool Predicate(int[][] array);

    public bool CheckTransformAbility(int[][] array)
    {
      bool flag = false;
      double s = 0;
      for (int i = 0; i < array.Length; i++)
        s += array[i].Length;
      s /= array.Length;
      if (Math.Floor(s) == s)
        flag = true;
      return flag;
    }

    public bool CheckSumOrder(int[][] array)
    {
      int flagInt = 0;
      int[] arr = new int[array.Length];
      for (int i = 0; i < array.Length; i++)
        for (int j = 0; j < array[i].Length; j++)
          arr[i] += array[i][j];
      for (int i = 1; i < arr.Length; i++)
        if (arr[i - 1] < arr[i])
          flagInt++;
      if (flagInt == arr.Length - 1)
        return true;
      flagInt = 0;
      for (int i = 1; i < arr.Length; i++)
        if (arr[i - 1] > arr[i])
          flagInt++;
      if (flagInt == arr.Length - 1)
        return true;
      return false;
    }

    public bool CheckArraysOrder(int[][] array)
    {
      bool[] arr = new bool[array.Length];
      for (int i = 0; i < array.Length; i++)
      {
        int flagInt = 0;
        for (int j = 1; j < array[i].Length; j++)
          if (array[i][j - 1] < array[i][j])
            flagInt++;
        if (flagInt == array[i].Length - 1)
        {
          arr[i] = true;
          continue;
        }
        flagInt = 0;
        for (int j = 1; j < array[i].Length; j++)
          if (array[i][j - 1] > array[i][j])
            flagInt++;
        if (flagInt == array[i].Length - 1)
        {
          arr[i] = true;
          continue;
        }
        arr[i] = false;
      }
      bool flag = false;
      for (int i = 0; i < arr.Length; i++)
        if (arr[i])
          flag = true;
      return flag;
    }

public bool Task10(int[][] array, Predicate<int[][]> func)
    {
      bool res = false;

      // code here
      res = func(array);
      // end

      return res;
    }
  }
}
