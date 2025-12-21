namespace Lab6 {
    public class Purple {


        public void Task1(int[,] A, int[,] B) {
            // code here
            if (IsSameSize(A, B) && IsSquare(A) && IsSquare(B)) {
                SwapRowColumn(A, FindDiagonalMaxIndex(A), B, FindDiagonalMaxIndex(B));
            }
            // end
        }

        public int FindDiagonalMaxIndex(int[,] matrix) {
            var max_index = 0;

            for (var i = 1; i < matrix.GetLength(0); i += 1) {
                if (matrix[i, i] > matrix[max_index, max_index]) {
                    max_index = i;
                }
            }

            return max_index;
        }

        public void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex) {
            var size = matrix.GetLength(0);

            for (var i = 0; i < size; i += 1) {
                Swap(ref matrix[rowIndex, i], ref B[i, columnIndex]);
            }
        }

        static bool IsSquare<T>(T[,] matrix) => matrix.GetLength(0) == matrix.GetLength(1);

        static bool IsSameSize<T>(T[,] A, T[,] B, uint dim) => A.GetLength((int)dim) == B.GetLength((int)dim);

        static bool IsSameSize<T>(T[,] A, T[,] B) => IsSameSize(A, B, 0) && IsSameSize(A, B, 1);

        static void Swap<T>(ref T a, ref T b) {
            (a, b) = (b, a);
        }

        //

        public void Task2(ref int[,] A, int[,] B) {

            // code here

            // end

        }

        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B) {

        }

        public int CountPositiveElementsInRow(int[,] matrix, int row) { return 0; }

        public int CountPositiveElementsInColumn(int[,] matrix, int col) { return 0; }

        //

        public void Task3(int[,] matrix) {

            // code here

            // end

        }


        public void ChangeMatrixValues(int[,] matrix) { }

        //

        public void Task4(int[,] A, int[,] B) {

            // code here

            // end

        }

        public int[] CountNegativesPerRow(int[,] matrix) { return null; }

        public int FindMaxIndex(int[] array) { return 0; }

        //

        public void Task5(int[] matrix, Sorting sort) {

            // code here

            // end

        }
        public delegate void Sorting(int[] matrix);

        public void SortNegativeAscending(int[] matrix) { }

        public void SortNegativeDescending(int[] matrix) { }

        //

        public void Task6(int[,] matrix, SortRowsByMax sort) {

            // code here

            // end

        }

        public delegate void SortRowsByMax(int[,] matirx);

        public void SortRowsByMaxAscending(int[,] matrix) { }

        public void SortRowsByMaxDescending(int[,] matrix) { }

        public int GetRowMax(int[,] matrix, int row) { return 0; }

        //

        public int[] Task7(int[,] matrix, FindNegatives find) {
            int[] negatives = null;

            // code here

            // end

            return negatives;
        }

        public delegate int[] FindNegatives(int[,] matrix);

        public int[] FindNegativeCountPerRow(int[,] matrix) { return []; }

        public int[] FindMaxNegativePerColumn(int[,] matrix) { return []; }

        //

        public int[,] Task8(int[,] matrix, MathInfo info) {
            int[,] answer = null;

            // code here

            // end

            return answer;
        }

        public delegate int[,] MathInfo(int[,] matrix);

        public int[,] DefineSeq(int[,] matrix) { return null; }

        public int[,] FindAllSeq(int[,] matrix) { return null; }

        public int[,] FindLongestSeq(int[,] matrix) { return null; }

        //

        public int Task9(double a, double b, double h, Func<double, double> func) {
            int answer = 0;

            // code here

            // end

            return answer;
        }

        public int CountSignFlips(double a, double b, double h, Func<double, double> func) { return 0; }

        public double FuncA(double x) { return 0; }

        public double FuncB(double x) { return 0; }

        //

        public void Task10(int[][] array, Action<int[][]> func) {

            // code here

            // end

        }

        public void SortInCheckersOrder(int[][] array) { }

        public void SortBySumDesc(int[][] array) { }

        public void TotalReverse(int[][] array) { }
    }
}
