namespace Lab6
{
    public class Purple
    {

        const int error_invalid_index = -1;

        public void Task1(int[,] A, int[,] B)
        {
            // code here
            if (!IsSameSize(A, B)) { return; }

            if (!IsSquare(A)) { return; }
            var a_max_item_index = FindDiagonalMaxIndex(A);
            if (error_invalid_index == a_max_item_index) { return; }

            if (!IsSquare(B)) { return; }
            var b_max_item_index = FindDiagonalMaxIndex(A);
            if (error_invalid_index == b_max_item_index) { return; }

            SwapRowColumn(A, a_max_item_index, B, b_max_item_index);
            // end
        }

        static bool IsSquare<T>(T[,] matrix) => matrix.GetLength(0) == matrix.GetLength(1);

        static bool IsSameSize<T>(T[,] A, T[,] B, uint dim) => A.GetLength((int)dim) == B.GetLength((int)dim);

        static bool IsSameSize<T>(T[,] A, T[,] B) => IsSameSize(A, B, 0) && IsSameSize(A, B, 1);

        static void Swap<T>(ref T a, ref T b)
        {
            (a, b) = (b, a);
        }

        static int FindDiagonalMaxIndex<T>(T[,] matrix) where T : IComparable<T>
        {
            int max_index = 0;

            for (var i = 1; i < matrix.GetLength(0); i += 1)
            {
                if (matrix[i, i].CompareTo(matrix[max_index, max_index]) > 0)
                {
                    max_index = i;
                }
            }

            return max_index;
        }

        static void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex)
        {
            var size = matrix.GetLength(0);

            for (var i = 0; i < size; i += 1)
            {
                Swap(ref matrix[rowIndex, i], ref matrix[i, columnIndex]);
            }
        }

        public void Task2(ref int[,] A, int[,] B)
        {

            // code here

            // end

        }
        public void Task3(int[,] matrix)
        {

            // code here

            // end

        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here

            // end

        }
        public void Task5(int[] matrix, Sorting sort)
        {

            // code here

            // end

        }
        public void Task6(int[,] matrix, SortRowsByMax sort)
        {

            // code here

            // end

        }
        public int[] Task7(int[,] matrix, FindNegatives find)
        {
            int[] negatives = null;

            // code here

            // end

            return negatives;
        }
        public int[,] Task8(int[,] matrix, MathInfo info)
        {
            int[,] answer = null;

            // code here

            // end

            return answer;
        }
        public int Task9(double a, double b, double h, Func<double, double> func)
        {
            int answer = 0;

            // code here

            // end

            return answer;
        }
        public void Task10(int[][] array, Action<int[][]> func)
        {

            // code here

            // end

        }
    }
}
