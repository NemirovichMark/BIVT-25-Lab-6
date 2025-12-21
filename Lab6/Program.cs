using System.Globalization;

namespace Lab6
{
    public class Program
    {
        public static void Main()
        {
            Purple purp = new Purple();
        }
        public static void ShowMatrix(int[,] m)
        {
            for(int y = 0; y < m.GetLength(0); y++)
            {
                for(int x = 0; x < m.GetLength(1); x++)
                {
                    Console.Write($"{m[y, x]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
