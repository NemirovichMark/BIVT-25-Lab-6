using System.Data;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

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
            if (A.GetLength(1) == B.GetLength(0)) {
                InsertColumn(ref A, FindMaxIndexByValueProvider(A, CountPositiveElementsInRow, 0), FindMaxIndexByValueProvider(B, CountPositiveElementsInColumn, 1), B);
            }
            // end
        }

        static int FindMaxIndexByValueProvider(int[,] matrix, Func<int[,], int, int> value_provider, int dim) {
            var max_value = int.MinValue;
            var ret = 0;

            ForRange(
                delegate (int i) {
                    var value = value_provider(matrix, i);

                    if (value > max_value) {
                        max_value = value;
                        ret = i;
                    }
                },
                matrix.GetLength(dim)
            );

            return ret;
        }

        public int CountPositiveElementsInRow(int[,] matrix, int row) =>
            CountPositives(matrix.GetLength(1), delegate (int i) { return matrix[row, i]; });

        public int CountPositiveElementsInColumn(int[,] matrix, int col) =>
            CountPositives(matrix.GetLength(0), delegate (int i) { return matrix[i, col]; });

        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B) {
            var rows = A.GetLength(0);
            var cols = A.GetLength(1);
            var ret = new int[rows + 1, cols];
            var a_fixed = A;
            ForRange(delegate (int c) {
                ForRange(delegate (int r) { ret[r, c] = a_fixed[r, c]; }, rowIndex + 1);
                ret[rowIndex + 1, c] = B[c, columnIndex];
                ForRange(delegate (int r) { ret[r + 1, c] = a_fixed[r, c]; }, rows, rowIndex + 1);
            }, cols);
            A = ret;
        }

        static void ForRange(Action<int> on_index_action, int end, int begin = 0, int step = 1) {
            for (var i = begin; i < end; i += step) {
                on_index_action(i);
            }
        }

        static int CountPositives(int len, Func<int, int> item_provider) {
            var ret = 0;
            ForRange(delegate (int i) { if (item_provider(i) > 0) { ret += 1; } }, len);
            return ret;
        }

        //

        public void Task3(int[,] matrix) {
            // code here
            ChangeMatrixValues(matrix);
            // end
        }

        public void ChangeMatrixValues(int[,] matrix) {
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);
            var index = (int)0;
            var array = new int[matrix.Length];
            var max_indices = new int[matrix.Length];
            var is_max = new bool[array.Length];

            void for_this_matrix_btw(Action<int, int> action) => ForMatrix(action, rows, cols);

            if (matrix.Length <= 5) {
                ForMatrix(delegate (int r, int c) { matrix[r, c] *= 2; }, rows, cols);
                return;
            }

            index = 0;
            for_this_matrix_btw(delegate (int r, int c) {
                array[index] = matrix[r, c];
                max_indices[index] = index;
                index += 1;
            });

            var n = array.Length - 1;
            ForRange(delegate (int i) {
                ForRange(delegate (int j) {
                    ref var a0 = ref array[j];
                    ref var a1 = ref array[j + 1];
                    ref var m0 = ref max_indices[j];
                    ref var m1 = ref max_indices[j + 1];

                    if ((a0 < a1) || (a0 == a1 && m0 > m1)) {
                        Swap(ref a0, ref a1);
                        Swap(ref m0, ref m1);
                    }
                }, n - i);
            }, n);

            ForRange(delegate (int i) { is_max[max_indices[i]] = true; }, 5);

            index = 0;
            for_this_matrix_btw(delegate (int r, int c) {
                if (is_max[index]) { matrix[r, c] *= 2; }
                else { matrix[r, c] /= 2; }
                index += 1;
            });
        }

        static void ForMatrix(Action<int, int> action, int rows, int cols) {
            ForRange(
                delegate (int r) {
                    ForRange(
                        delegate (int c) {
                            action(r, c);
                        },
                        cols
                    );
                },
                rows
            );
        }

        //

        public void Task4(int[,] A, int[,] B) {
            // code here
            if (IsSameSize(A, B, 1)) {
                var max_index_a = FindMaxInNegatives(A);
                if (max_index_a == -1) {
                    return;
                }

                var max_index_b = FindMaxInNegatives(B);
                if (max_index_b == -1) {
                    return;
                }

                ForRange(delegate (int i) {
                    Swap(ref A[max_index_a, i], ref B[max_index_b, i]);
                }, A.GetLength(1));
            }
            // end
        }

        int FindMaxInNegatives(int[,] matrix) {
            var negatives = CountNegativesPerRow(matrix);
            var max_index = FindMaxIndex(negatives);
            return negatives[max_index] == 0 ? -1 : max_index;
        }

        public int[] CountNegativesPerRow(int[,] matrix) {
            var rows = matrix.GetLength(0);
            var negatives = new int[rows];

            ForRange(delegate (int r) {
                var count = 0;

                ForRange(delegate (int c) {
                    if (matrix[r, c] < 0) {
                        count += 1;
                    }
                }, matrix.GetLength(1));

                negatives[r] = count;

            }, rows);

            return negatives;
        }
        public int FindMaxIndex(int[] array) {
            var max_index = 0;

            ForRange(delegate (int i) {
                if (array[i] > array[max_index]) {
                    max_index = i;
                }
            }, array.Length);

            return max_index;
        }

        //

        public void Task5(int[] array, Sorting sort) {
            // code here
            sort(array);
            // end
        }

        public delegate void Sorting(int[] array);

        public void SortNegativeAscending(int[] array) =>
            SortNegativeBy(array, delegate (int a, int b) { return a > b; });

        public void SortNegativeDescending(int[] array) =>
            SortNegativeBy(array, delegate (int a, int b) { return a < b; });
        int CountNegatives(int[] array) {
            var ret = 0;

            ForRange(delegate (int i) {
                if (array[i] < 0) {
                    ret += 1;
                }
            }, array.Length);

            return ret;
        }

        void SortNegativeBy(int[] array, Func<int, int, bool> comparator) {
            var count = CountNegatives(array);
            var negatives = new int[count];
            var negatives_indices = new int[count];

            var index = 0;
            ForRange(delegate (int i) {
                if (array[i] >= 0) { return; }
                negatives[index] = array[i];
                negatives_indices[index] = i;
                index += 1;
            }, array.Length);

            for (var i = 0; i < negatives.Length - 1; i += 1) {
                for (var j = 0; j < negatives.Length - 1 - i; j += 1) {
                    if (comparator(negatives[j], negatives[j + 1])) {
                        Swap(ref negatives[j], ref negatives[j + 1]);
                    }
                }
            }

            ForRange(delegate (int i) { array[negatives_indices[i]] = negatives[i]; }, negatives_indices.Length);
        }

        //

        public void Task6(int[,] matrix, SortRowsByMax sort) {
            // code here
            sort(matrix);
            // end
        }

        public delegate void SortRowsByMax(int[,] matirx);

        public void SortRowsByMaxAscending(int[,] matrix) =>
            SortRowsByMaxBy(matrix, delegate (int a, int b) { return a > b; });

        public void SortRowsByMaxDescending(int[,] matrix) =>
            SortRowsByMaxBy(matrix, delegate (int a, int b) { return a < b; });

        void SortRowsByMaxBy(int[,] matrix, Func<int, int, bool> comparator) {
            var n = matrix.GetLength(0) - 1;
            ForRange(delegate (int i) {
                ForRange(delegate (int j) {
                    if (comparator(GetRowMax(matrix, j), GetRowMax(matrix, j + 1))) {
                        ForRange(delegate (int c) { Swap(ref matrix[j, c], ref matrix[j + 1, c]); }, matrix.GetLength(1));
                    }
                }, n - i);
            }, n);
        }

        public int GetRowMax(int[,] matrix, int row) {
            var ret = matrix[row, 0];
            ForRange(delegate (int i) { if (matrix[row, i] > ret) { ret = matrix[row, i]; } }, matrix.GetLength(1));
            return ret;
        }

        //

        public int[] Task7(int[,] matrix, FindNegatives find) {
            int[] negatives = null;
            // code here
            negatives = find(matrix);
            // end
            return negatives;
        }

        public delegate int[] FindNegatives(int[,] matrix);

        public int[] FindNegativeCountPerRow(int[,] matrix) {
            var negatives = new int[matrix.GetLength(0)];

            ForRange(delegate (int i) {
                var count = 0;

                ForRange(delegate (int j) { if (matrix[i, j] < 0) { count += 1; } }, matrix.GetLength(1));

                negatives[i] = count;
            }, matrix.GetLength(0));

            return negatives;
        }
        public int[] FindMaxNegativePerColumn(int[,] matrix) {
            int[] target_negatives = new int[matrix.GetLength(1)];

            ForRange(delegate (int j) {
                var max = int.MinValue;

                ForRange(delegate (int i) { if (IsOutOfRange(matrix[i, j], 0, max)) { max = matrix[i, j]; } }, matrix.GetLength(0));

                target_negatives[j] = max == int.MinValue ? 0 : max;
            }, matrix.GetLength(1));

            return target_negatives;
        }

        static bool IsOutOfRange(int x, int min, int max) => x < min && x > max;

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
