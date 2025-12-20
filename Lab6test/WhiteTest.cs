namespace Lab6test
{
    public class White
    {
        public void Task1(int[,] A, int[,] B) { }
        public void Task2(ref int[,] A, int[,] B) { }
        public void Task3(int[,] matrix) { }
        public void Task4(int[,] A, int[,] B) { }
        public void Task5(int[] array, System.Action<int[]> sort) { }
        public void Task6(int[,] matrix, System.Action<int[,]> sort) { }
        public int Task7(int[,] matrix, System.Func<int[,], int> find) => 0;
        public int[,] Task8(int[,] matrix, System.Func<int[,], int[,]> info) => new int[0,0];
        public int Task9(double a, double b, double h, System.Func<double, double> func) => 0;
        public void Task10(int[][] array, System.Action<int[][]> func) { }
    }
}