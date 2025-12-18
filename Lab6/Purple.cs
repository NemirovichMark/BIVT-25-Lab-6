namespace Lab6
{
    public class Purple
    {
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            if (matrix.GetLength(0)!=matrix.GetLength(1)) return -1;
            int index = 0;
            int side = matrix.GetLength(0);
            for (int i = 0; i < side; i++)
            {
                if (matrix[i,i]>matrix[index,index]) index=i;
            }
            return index;
        }
        public void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex)
        {
            if (matrix.GetLength(0)!=B.GetLength(1)) return;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int temp = matrix[rowIndex,i];
                matrix[rowIndex, i] = B[i,columnIndex];
                B[i,columnIndex]=temp;
            }
        }
        public void Task1(int[,] A, int[,] B)
        {

            // code here
            int rA=A.GetLength(0), cA=A.GetLength(1);
            int rB=B.GetLength(0), cB=B.GetLength(1);
            if (rA==cA && rB==cB && rA == rB)
            {
                int rowIndex = FindDiagonalMaxIndex(A);
                int columnIndex = FindDiagonalMaxIndex(B);
                SwapRowColumn(A,rowIndex,B,columnIndex);
            }
            // end
        }
        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int count = 0, len = matrix.GetLength(1);
            for (int i = 0; i < len; i++)
            {
                if (matrix[row,i]>0) count++;
            }
            return count;
        }

        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {
            int count = 0, len = matrix.GetLength(0);
            for (int i = 0; i < len; i++)
            {
                if (matrix[i,col]>0) count++;
            }
            return count;
        }
        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B)
        {
            int rA=A.GetLength(0), cA=A.GetLength(1);
            //int rB=B.GetLength(0), cB=B.GetLength(1);
            int[,] newMatrix = new int[rA+1,cA];
            for (int i = 0; i < rA+1; i++)
            {
                for (int j = 0; j < cA; j++)
                {
                    if (i <= rowIndex)
                    {
                        newMatrix[i,j]=A[i,j];
                    }
                    if (i == rowIndex + 1)
                    {
                        newMatrix[i,j]=B[j,columnIndex];
                    }
                    if (i > rowIndex + 1)
                    {
                        newMatrix[i,j]=A[i-1,j];
                    }
                }
            }
            A = new int[rA+1,cA];
            for (int i =0; i< rA+1; i++)
            {
                for (int j = 0; j < cA; j++)
                {
                    A[i,j]=newMatrix[i,j];
                }
            }
        }
        public void Task2(ref int[,] A, int[,] B)
        {

            // code here
            int rA=A.GetLength(0), cA=A.GetLength(1);
            int rB=B.GetLength(0), cB=B.GetLength(1);
            if (cA == rB)
            {
                int rowIndex =0, columnIndex=0;
                int count = 0;
                for (int i = 0; i < rA; i++)
                {
                    if (CountPositiveElementsInRow(A,i)>count) 
                    {
                        count=CountPositiveElementsInRow(A,i);
                        rowIndex=i;
                    }
                }
                count=0;
                for (int i = 0; i < cB; i++)
                {
                    if (CountPositiveElementsInColumn(B,i)>count)
                    {
                        count=CountPositiveElementsInColumn(B,i);
                        columnIndex=i;
                    }
                }
                if (count > 0)
                {
                    InsertColumn(ref A, rowIndex,columnIndex,B);
                }
            }
            // end

        }

        public void ChangeMatrixValues(int[,] matrix)
        {
            int rows=matrix.GetLength(0), cols=matrix.GetLength(1);
            //int[] maxval = new int[5];
            int[,] nmatrix=new int[rows,cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    nmatrix[i,j]=matrix[i,j];
                }
            }
            for (int n = 0; n < 5; n++)
            {
                int max_i=0, max_j=0;
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (nmatrix[i, j] > nmatrix[max_i,max_j])
                        {
                            max_i=i;
                            max_j=j;
                        }
                    }
                }
                //maxval[n]=Math.Abs(matrix[max_i,max_j])*4;
                nmatrix[max_i,max_j]=int.MinValue;
            }
            
            //
            int k = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i,j]!=nmatrix[i,j])
                    {
                        matrix[i,j]=(matrix[i,j])*4;
                    }
                    matrix[i,j]/=2;
                }
            }

        }
        public void Task3(int[,] matrix)
        {

            // code here
            int rows=matrix.GetLength(0), cols=matrix.GetLength(1);
            if (rows * cols <= 5)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        matrix[i,j]=matrix[i,j]*2;
                    }
                }
            }
            else
            {
                ChangeMatrixValues(matrix);
            }
            // end

        }
        public int[] CountNegativesPerRow(int[,] matrix)
        {
            int rows=matrix.GetLength(0), cols=matrix.GetLength(1);
            int[] neg_count = new int[rows];
            for (int i = 0; i < rows; i++)
                {
                    int count=0;
                    for (int j = 0; j < cols; j++)
                    {
                        if (matrix[i,j]<0) count++;
                    }
                    neg_count[i]=count;
                }
            return neg_count;
        }

        public int FindMaxIndex(int[] array)
        {
            int answer = Array.IndexOf(array, array.Max());
            return answer;
        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here
            int[] neg_count_A = CountNegativesPerRow(A), neg_count_B = CountNegativesPerRow(B);
            int max_count_index_A=FindMaxIndex(neg_count_A), max_count_index_B=FindMaxIndex(neg_count_B);
            if (A.GetLength(1) == B.GetLength(1) && max_count_index_A!=0 && max_count_index_B!=0)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    int temp = A[max_count_index_A,j];
                    A[max_count_index_A,j] = B[max_count_index_B,j];
                    B[max_count_index_B,j] = temp;
                }
            }
            // end

        }
        public void SortNegativeAscending(int[] matrix)
        {
            int neg_count=0;
            for (int i = 0; i < matrix.Length; i++) neg_count = matrix[i]<0 ? neg_count+1 : neg_count;
            int[] negatives = new int[neg_count];
            int k = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i]<0)
                {
                    negatives[k]=matrix[i];
                    k++;
                }
            }
            for (int i = 0; i < negatives.Length; i++)
            {
                bool swap = false;
                for (int j = 0; j < negatives.Length - 1 - i; j++)
                {
                    
                    if (negatives[j] > negatives[j + 1])
                    {
                        (negatives[j],negatives[j+1])=(negatives[j+1], negatives[j]);
                        swap=true;
                    }
                    
                }
                if (swap==false) break;
            }
            k=0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    matrix[i]=negatives[k];
                    k++;
                }
            }
        }
        public void SortNegativeDescending(int[] matrix)
        {
            int neg_count=0;
            for (int i = 0; i < matrix.Length; i++) neg_count = matrix[i]<0 ? neg_count+1 : neg_count;
            int[] negatives = new int[neg_count];
            int k = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i]<0)
                {
                    negatives[k]=matrix[i];
                    k++;
                }
            }
            for (int i = 0; i < negatives.Length; i++)
            {
                bool swap = false;
                for (int j = 0; j < negatives.Length - 1 - i; j++)
                {
                    
                    if (negatives[j] < negatives[j + 1])
                    {
                        (negatives[j],negatives[j+1])=(negatives[j+1], negatives[j]);
                        swap=true;
                    }
                    
                }
                if (swap==false) break;
            }
            k=0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    matrix[i]=negatives[k];
                    k++;
                }
            }
        }
        public delegate void Sorting (int[] maxtrix);
        public void Task5(int[] matrix, Sorting sort)
        {

            // code here
            sort(matrix);
            // end

        }

        public int GetRowMax(int[,] matrix, int row)
        {
            int columns = matrix.GetLength(1);
            int max_j = 0;
            for (int j = 0; j < columns; j++)
            {
                if (matrix[row,j]>matrix[row,max_j]) max_j=j;
            }
            return matrix[row,max_j];
        }
        public void SortRowsByMaxAscending(int[,] matrix)
        {
            int rows = matrix.GetLength(0), columns = matrix.GetLength(1);
            int[] max_elements= new int[rows];
            for (int i = 0; i < rows; i++)
            {
                max_elements[i]=GetRowMax(matrix,i);
            }
            for (int i = 0; i < rows; i++)
            {
                bool swap = false;
                for (int j = 0; j < rows - 1 - i; j++)
                {
                    if (max_elements[j] > max_elements[j + 1])
                    {
                        (max_elements[j], max_elements[j+1]) = (max_elements[j+1], max_elements[j]);
                        for (int col = 0; col < columns; col++) //swapping rows in matrix
                        {
                            int temp = matrix[j,col];
                            matrix[j,col] = matrix[j+1,col];
                            matrix[j+1,col] = temp;
                        }
                        swap = true;
                    }
                }
                if (swap == false) break;
            }
        }
        public void SortRowsByMaxDescending(int[,] matrix)
        {
            int rows = matrix.GetLength(0), columns = matrix.GetLength(1);
            int[] max_elements= new int[rows];
            for (int i = 0; i < rows; i++)
            {
                max_elements[i]=GetRowMax(matrix,i);
            }
            for (int i = 0; i < rows; i++)
            {
                bool swap = false;
                for (int j = 0; j < rows - 1 - i; j++)
                {
                    if (max_elements[j] < max_elements[j + 1])
                    {
                        (max_elements[j], max_elements[j+1]) = (max_elements[j+1], max_elements[j]);
                        for (int col = 0; col < columns; col++) //swapping rows in matrix
                        {
                            int temp = matrix[j,col];
                            matrix[j,col] = matrix[j+1,col];
                            matrix[j+1,col] = temp;
                        }
                        swap = true;
                    }
                }
                if (swap == false) break;
            }
        }
        
        public delegate void SortRowsByMax(int[,] matrix);
        public void Task6(int[,] matrix, SortRowsByMax sort)
        {

            // code here
            sort(matrix);
            // end

        }
        public int[] FindNegativeCountPerRow(int[,] matrix)
        {
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            int[] negatives = new  int[rows];
            for (int i = 0; i < rows; i++)
            {
                int count = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i,j]<0) count++;
                }
                negatives[i]=count;
            }
            return negatives;
        }
                public int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            int[] negatives = new  int[cols];
            for (int j = 0; j < cols; j++)
            {
                int max = int.MinValue;
                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i,j]<0 && matrix[i,j]>max) max=matrix[i,j];
                }
                if (max==int.MinValue) max=0;
                negatives[j]=max;
            }
            return negatives;
        }
        public delegate int[] FindNegatives(int[,] matrix); 
        public int[] Task7(int[,] matrix, FindNegatives find)
        {
            int[] negatives = null;

            // code here
            negatives=find(matrix);
            // end

            return negatives;
        }
        public int[,] DefineSeq(int[,] matrix)
        {
            bool is_increasing=true, is_decreasing=true;
            for (int i = 0; i < matrix.GetLength(1)-1; i++)
            {
                if (matrix[1,i]<matrix[1,i+1]) is_decreasing=false;
                if (matrix[1,i]>matrix[1,i+1]) is_increasing=false;
            }
            if (is_increasing==false&&is_decreasing==false) return new int[,] {{0}};
            else if (is_increasing==true&&is_decreasing==true) return new int[0,0];
            else if (is_increasing==true&&is_decreasing==false) return new int[,] {{1}};
            else return new int[,] {{-1}};
        }
        public int[,] FindAllSeq(int[,] matrix)
        {
            if (matrix.GetLength(1)==1) return new int[0,0];
            int flag, pflag;
            flag = 1;
            if (matrix[1, 0] > matrix[1, 1]) flag = -1;
            pflag=flag;
            int n = 1;
            for (int i = 0; i < matrix.GetLength(1)-1; i++)
            {
                if (matrix[1, i] < matrix[1, i + 1]) flag =  1;
                if (matrix[1, i] > matrix[1, i + 1]) flag = -1;
                
                if (pflag != flag)
                {
                    n++;
                }
                pflag=flag;
            }
            
            int[,] answer=new int[n,2];
            n=0;
            int count=0;
            flag = 1;
            if (matrix[1, 0] > matrix[1, 1]) flag = -1;
            pflag=flag;
            for (int i = 0; i < matrix.GetLength(1)-1; i++)
            {
                if (matrix[1, i] < matrix[1, i + 1]) flag =  1;
                if (matrix[1, i] > matrix[1, i + 1]) flag = -1;
                
                if (pflag != flag)
                {
                    answer[n,0]=matrix[0,i-count];
                    answer[n,1]=matrix[0,i];
                    n++;
                    count=0;
                }
                pflag=flag;
                count++;

            }
            answer[n,0]=matrix[0,matrix.GetLength(1)-1-count];
            answer[n,1]=matrix[0,matrix.GetLength(1)-1];
            return answer;
        }
        public int[,] FindLongestSeq(int[,] matrix)
        {
            if (matrix.GetLength(1)==1) return new int[0,0];
            int flag, pflag;
            flag = 1;
            if (matrix[1, 0] > matrix[1, 1]) flag = -1;
            pflag=flag;
            //int n = 1;
            // for (int i = 0; i < matrix.GetLength(1)-1; i++)
            // {
            //     if (matrix[1, i] < matrix[1, i + 1]) flag =  1;
            //     if (matrix[1, i] > matrix[1, i + 1]) flag = -1;
                
            //     if (pflag != flag)
            //     {
            //         n++;
            //     }
            //     pflag=flag;
            // }
            
            int[,] answer=new int[1,2];
            // int n=0;
            int count=0, maxcount=0;
            for (int i = 0; i < matrix.GetLength(1)-1; i++)
            {
                if (matrix[1, i] < matrix[1, i + 1]) flag =  1;
                if (matrix[1, i] > matrix[1, i + 1]) flag = -1;
                
                if (pflag != flag)
                {
                    if (Math.Abs(matrix[0, i - count] - matrix[0, i]) > maxcount)
                    {
                        answer[0,0]=matrix[0,i-count];
                        answer[0,1]=matrix[0,i];
                        maxcount=Math.Abs(matrix[0, i - count] - matrix[0, i]);
                    }
                    // n++;
                    count=0;
                }
                pflag=flag;
                count++;

            }
            if (Math.Abs(matrix[0, matrix.GetLength(1)-1 - count] - matrix[0, matrix.GetLength(1)-1]) > maxcount)
            {
                answer[0,0]=matrix[0, matrix.GetLength(1)-1 - count];
                answer[0,1]=matrix[0, matrix.GetLength(1)-1];
                //maxcount=Math.Abs(matrix[0, matrix.GetLength(1)-1 - count] - matrix[0, matrix.GetLength(1)-1]);
            }
            return answer;
        }
        public delegate int[,] MathInfo(int[,] matrix);
        public int[,] Task8(int[,] matrix, MathInfo info)
        {
            int[,] answer = null;

            // code here
            answer = info(matrix);
            // end

            return answer;
        }

        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
        {
            double y0 = func(a);
            int count = 0;
            for (double x = a+h; x <= b; x+=h)
            {
                double y = func(x);
                if ((y0>=0 && y<0)||(y0<=0 && y>0)) count++;
                y0 = y;
            }
            
            return count;
        }
        public double FuncA(double x)
        {
            double y = x*x - Math.Sin(x);
            return y;
        }
        public double FuncB(double x)
        {
            double y = Math.Pow(Math.E,x) - 1;
            return y;
        }
        //public delegate double Func(double x);
        public int Task9(double a, double b, double h, Func<double, double>  func)
        {
            int answer = 0;

            // code here
            answer = CountSignFlips(a,b,h,func);
            // end

            return answer;
        }

        public void SortInCheckersOrder(int[][] array)
        {
            for (int n = 0; n < array.Length; n++)
            {
                if (n % 2 == 0) //even
                {
                    for (int i = 0; i < array[n].Length - 1; i++)
                    {
                        bool swap = false;
                        for (int j = 0; j < array[n].Length - 1 - i; j++)
                        {
                            if (array[n][j]>array[n][j+1]) //increasing
                            {
                                (array[n][j],array[n][j+1])=(array[n][j+1],array[n][j]);
                                swap=true;
                            }
                        }
                        if (swap==false) break;
                    }
                }
                else //odd
                {
                    for (int i = 0; i < array[n].Length - 1; i++)
                    {
                        bool swap = false;
                        for (int j = 0; j < array[n].Length - 1 - i; j++)
                        {
                            if (array[n][j]<array[n][j+1]) //decreasing
                            {
                                (array[n][j],array[n][j+1])=(array[n][j+1],array[n][j]);
                                swap=true;
                            }
                        }
                        if (swap==false) break;
                    }
                }
            }
        }
        public void SortBySumDesc(int[][] array)
        {
            int[][] new_arr = new int[array.Length][];
            int[] sums=new int[array.Length];
            for (int n = 0; n < array.Length; n++)
            {
                int sum = array[n].Sum();
                sums[n]=sum;
            }
            // for (int n = 0; n < array.Length; n++)
            // {
                for (int i = 0; i < sums.Length - 1; i++)
                {
                    bool swap = false;
                    for (int j = 0; j < sums.Length - 1 - i; j++)
                    {
                        if (sums[j]<sums[j+1]) //decreasing
                        {
                            (sums[j], sums[j+1])=(sums[j+1], sums[j]);
                            (array[j], array[j+1])=(array[j+1],array[j]);
                            swap=true;
                        }
                    }
                    if (swap==false) break;
                }
            // }

        }
        public void TotalReverse(int[][] array)
        {
            Array.Reverse(array);
            for (int i = 0; i < array.Length; i++)
            {
                Array.Reverse(array[i]);
            }
        }
        public void Task10(int[][] array, Action<int[][]> func)
        {

            // code here
            func(array);
            // end

        }
    }
}