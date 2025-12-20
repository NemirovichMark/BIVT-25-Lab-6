namespace Lab6test
{
    public class Blue
    {
        public void Task1(int[,] A, int[,] B) { }
        public void Task2(ref int[,] A, int[,] B) { }
        public void Task3(int[,] matrix) { }
        public void Task4(int[,] A, int[,] B) { }
        public int Task5(int[,] matrix, System.Func<int[,], int> find) => 0;
        public void Task6(int[,] matrix, System.Action<int[,]> sort) { }
        public int Task7(int[,] matrix, System.Func<int[,], int> find) => 0;
        public double Task8(int n, double x, System.Func<int, double, double> func) => 0;
        public double[] Task9(int[,] matrix, System.Func<int[,], double[]> get) => new double[0];
        public bool Task10(int[,] matrix, System.Func<int[,], bool> check) => false;
    }
}