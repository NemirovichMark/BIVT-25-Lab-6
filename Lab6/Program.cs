using System.Globalization;

namespace Lab6
{
    public class Program
    {
        public static void Main()
        {
            Purple purp = new Purple();
            int[,] matrix1 = {
                    {1, 2, 4, 6},
                    {5, -6, 7, 11},
                    {-1, 4, -5, 6},
                    {1, 4, 5, 6},
                };
            int[,] matrix2 = {
                    {1, 2, 4, 6},
                    {5, -6, 7, 11},
                    {-1, 4, -5, 6},
                    {1, 4, 5, 6},
                };
            purp.Task1(matrix1, matrix2);
            ShowMatrix(matrix1);
            Console.WriteLine();
            ShowMatrix(matrix2);
        }
        public static void ShowMatrix(int[,] m)
        {
            for(int x = 0; x < m.GetLength(0); x++)
            {
                for(int y = 0; y < m.GetLength(1); y++)
                {
                    Console.Write($"{m[y, x]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
