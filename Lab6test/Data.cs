﻿namespace Lab6test
{
    internal class Data
    {
        int[,] input1 = {
                { 1, 2, 3, 4, 5, 6, 7 },
                { 5, 6, 7, 8, 9, 10, 11 },
                { 9, 10, 11, 12, 13, 14, 15 },
                { 13, 14, 15, 16, 17, 18, 19 },
                { 0, 1, 2, 3, 4, 5, 6 }
            };
        int[,] input2 = {
                { 1 },
                { 5 },
                { 9 },
                { 13 }
        };

        int[,] input3 = {
                { 1, 2, 3, 4, 5, 6 },
                { 5, 6, 7, 8, 9, 11 },
                { 0, 2, 3, 4, 5, 6 }
            };

        int[,] input4 = {
                { 1, 2, 4, 6 },
                { 5, -6, 7, 11 },
                { -1, 4, -5, 6 },
                { 1, 4, 5, 6 }
            };

        int[,] input5 = {
                { 1, 2, 3, 4, 5, 6, 7 },
                { 5, 6, 7, 8, -9, 10, 11 },
                { 9, 10, -11, -12, -13, -14, -15 },
                { -13, -14, 15, 16, 17, 18, -19 }
            };
        int[,] input6 = {
                { 1, 2, 3 },
                { 5, 11, -17},
                { 0, -2, -3 }
            };
        int[,] input7 = {
                { -9, -10, -11, -14, -15, 6 }
            };
        int[,] input8 = {
                { 1, 2, 3, 4, -5, -6, -7 },
                { 5, 11, -17, 11, -10, 6, 5 },
                { -9, -10, -11, -14, -15, -16, 1 },
                { -9, -10, -11, -14, -15, -6, -2 },
                { -9, -10, -11, -14, -15, 6, 4 }
            };
        int[,] input9 = {
                { 1, 2, 3, 4, -5, -6, -7 },
                { 5, 11, -17, 11, -10, 6, 5 },
                { -9, -10, -11, -14, -15, -16, 1 },
                { -9, -10, -11, -14, 15, -6, -2 },
                { -9, -10, -11, -14, -15, 6, 4 },
                { 5, 11, -17, 11, -10, 6, -5 },
                { 1, 1, -2, 3, -4, 0, 0 },
                { 0, -2, -3, -4, -5, 0, 5 }
            };
        int[,] input10 = {
                { 1, 2, 3, 4, -5 },
                { 5, 11, -17, 11, 7 },
                { -9, -10, -11, -14, -15 },
                { -9, -10, -11, -14, -6 },
                { 0, -2, -3, -4, -5 }
            };
        int[][] inputArray1 = new[]
        {
            new int[] { 2, 1, 3, 3, 5, 6, 3, 4 },
            new int[] { 5, 2, 8, 1, 9, 3, 7, 4, 6, 0  },
            new int[] { 5, 2, 8, 1, 9, 0, 7, 4, 6, 10  },
            new int[] { 5, 2, -8, 1, 9, 3, 7, 4, 6 },
            new int[] { 12, 1, 3, 3, 5, 6, 3, 4 },
            new int[] { 2, 1, 3, 4 },
            new int[] { -2, -1, -3, -4 },
            new int[] { 5 },
            new int[] { 0, 0, 0, 0, 0 },
            new int[] { 1, 1, 1 },
            new int[] { -5, -2, -8, -1, -9, -3, -7, -4, -6, -2 },
            new int[] { 0, 2, 4, 6, 8 }
        };
        int[][] inputArray2 = new[]
        {
            new int[] { 2, 1, 3, 3, 5 },
            new int[] { 5, 2, 8, 1, 9  },
            new int[] { 5, 2, 8, 1, 9  },
            new int[] { 5, 2,-8, 1, 9 },
            new int[] {12, 1, 3, 0, 5 },
            new int[] { 2, 1, 3, 4, 5 },
            new int[] {-2,-1,-3,-4,-5 },
            new int[] { 0, 0, 0, 0, 0 },
            new int[] {-5, 2,-8, 1,-9 },
            new int[] { 0, 2, 4, 6, 8 }
        };
        int[][] inputArray3 = new[]
        {
            new int[] { -2, 1, 3, 3, 0, 5, -6, 3, 4 }
        };
        int[][] inputArray4 = new[]
        {
            new int[] { 2 },
            new int[] { -2 },
            new int[] { 5 },
            new int[] { 0 }
        };
        int[][] inputArray5 = new[]
        {
            new int[] { 2, 1, 3, 3, 5, 6, 3, 4 },
            new int[] { 5, 2, 8, 1, 9, 3, 7, 4, 6, 0  },
            new int[] { 5, 2, 8, 1, 9, 0, 7, 4, 6, 10  },
            new int[] { 5, 2, -8, 1, 9, 3, 7, 4, 6 },
            new int[] { 12, 1, 3, 3, 5, 6, 3, 4 },
            new int[] { -5, -2, -8, -1, -9, -3, -7, -4, -6, -2 }
        };
        internal int[][,] GetMatrixes()
        {
            return new int[][,]
            {
                input1.Clone() as int[,],
                input2.Clone() as int[,],
                input3.Clone() as int[,],
                input4.Clone() as int[,],
                input5.Clone() as int[,],
                input6.Clone() as int[,],
                input7.Clone() as int[,],
                input8.Clone() as int[,],
                input9.Clone() as int[,],
                input10.Clone() as int[,]
            };
        }
        internal int[][][] GetArrayArrays()
        {
            return new int[][][]
            {
                inputArray1.Clone() as int[][],
                inputArray2.Clone() as int[][],
                inputArray3.Clone() as int[][],
                inputArray4.Clone() as int[][],
                inputArray5.Clone() as int[][]
            };
        }
    }
}