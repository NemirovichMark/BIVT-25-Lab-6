using System.Linq;
using System.Runtime.InteropServices;

namespace Lab6
{
    public class White
    {
        public void Task1(double[] A, double[] B)
        {
            // code here
            
            // البحث عن أكبر عنصر في A
            int biggestIndexA = 0;
            double biggestValueA = A[0];
            for (int i = 1; i < A.Length; i++)
            {
                if (A[i] > biggestValueA)
                {
                    biggestValueA = A[i];
                    biggestIndexA = i;
                }
            }

            // البحث عن أكبر عنصر في B
            int biggestIndexB = 0;
            double biggestValueB = B[0];
            for (int i = 1; i < B.Length; i++)
            {
                if (B[i] > biggestValueB)
                {
                    biggestValueB = B[i];
                    biggestIndexB = i;
                }
            }

            // حساب المسافة من النهاية
            int distanceFromEndA = A.Length - 1 - biggestIndexA;
            int distanceFromEndB = B.Length - 1 - biggestIndexB;

            // تحديد أي مصفوفة نعدلها
            double[] arrayToChange = A;
            int indexToChange = biggestIndexA;

            if (distanceFromEndB > distanceFromEndA)
            {
                arrayToChange = B;
                indexToChange = biggestIndexB;
            }

            // التحقق إذا كان العنصر الأخير
            if (indexToChange == arrayToChange.Length - 1)
            {
                return;
            }

            // حساب المتوسط
            double total = 0;
            int numberOfElements = 0;
            for (int i = indexToChange + 1; i < arrayToChange.Length; i++)
            {
                total += arrayToChange[i];
                numberOfElements++;
            }

            double averageValue = total / numberOfElements;

            // استبدال أكبر عنصر بالمتوسط
            arrayToChange[indexToChange] = averageValue;
            // end
        }

        public void Task2(int[,] A, int[,] B)
        {
            // code here
            // التحقق من نفس الحجم
            if (A.GetLength(0) != B.GetLength(0) || A.GetLength(1) != B.GetLength(1))
            {
                return;
            }

            // البحث عن الصف الذي يحتوي على أكبر عنصر في العمود الأول من A
            int rowWithBiggestA = 0;
            int biggestInFirstColumnA = A[0, 0];
            for (int i = 1; i < A.GetLength(0); i++)
            {
                if (A[i, 0] > biggestInFirstColumnA)
                {
                    biggestInFirstColumnA = A[i, 0];
                    rowWithBiggestA = i;
                }
            }

            // البحث عن الصف الذي يحتوي على أكبر عنصر في العمود الأول من B
            int rowWithBiggestB = 0;
            int biggestInFirstColumnB = B[0, 0];
            for (int i = 1; i < B.GetLength(0); i++)
            {
                if (B[i, 0] > biggestInFirstColumnB)
                {
                    biggestInFirstColumnB = B[i, 0];
                    rowWithBiggestB = i;
                }
            }

            // تبديل الصفوف
            for (int j = 0; j < A.GetLength(1); j++)
            {
                int temp = A[rowWithBiggestA, j];
                A[rowWithBiggestA, j] = B[rowWithBiggestB, j];
                B[rowWithBiggestB, j] = temp;
            }
            // end
        }

        public int Task3(int[,] matrix)
        {
            int answer = 0;
            // code here
            int numberOfRows = matrix.GetLength(0);
            int numberOfColumns = matrix.GetLength(1);
            
            int[] negativeNumbersCount = new int[numberOfRows];
            
            // حساب عدد الأعداد السالبة في كل صف
            for (int i = 0; i < numberOfRows; i++)
            {
                int count = 0;
                for (int j = 0; j < numberOfColumns; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        count++;
                    }
                }
                negativeNumbersCount[i] = count;
            }
            
            // البحث عن الصف الذي يحتوي على أكبر عدد من الأعداد السالبة
            int biggestCount = negativeNumbersCount[0];
            answer = 0;
            
            for (int i = 1; i < numberOfRows; i++)
            {
                if (negativeNumbersCount[i] > biggestCount)
                {
                    biggestCount = negativeNumbersCount[i];
                    answer = i;
                }
            }
            // end
            return answer;
        }

        public void Task4(int[,] A, int[,] B)
        {
            // code here
            // البحث عن أكبر عنصر في A
            int positionA1 = 0, positionA2 = 0;
            int biggestInA = A[0, 0];
            
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    if (A[i, j] > biggestInA)
                    {
                        biggestInA = A[i, j];
                        positionA1 = i;
                        positionA2 = j;
                    }
                }
            }

            // البحث عن أكبر عنصر في B
            int positionB1 = 0, positionB2 = 0;
            int biggestInB = B[0, 0];
            
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    if (B[i, j] > biggestInB)
                    {
                        biggestInB = B[i, j];
                        positionB1 = i;
                        positionB2 = j;
                    }
                }
            }

            // تبديل أكبر عنصرين
            A[positionA1, positionA2] = biggestInB;
            B[positionB1, positionB2] = biggestInA;
            // end
        }

        public void Task5(int[,] A, int[,] B)
        {
            // code here
            // البحث عن أكبر عنصر في A وحفظ موقعه
            int posA1 = 0, posA2 = 0;
            int maxA = A[0, 0];
            
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    if (A[i, j] > maxA)
                    {
                        maxA = A[i, j];
                        posA1 = i;
                        posA2 = j;
                    }
                }
            }

            // البحث عن أكبر عنصر في B وحفظ موقعه
            int posB1 = 0, posB2 = 0;
            int maxB = B[0, 0];
            
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    if (B[i, j] > maxB)
                    {
                        maxB = B[i, j];
                        posB1 = i;
                        posB2 = j;
                    }
                }
            }

            // التحقق من نفس عدد الصفوف
            if (A.GetLength(0) != B.GetLength(0))
            {
                return;
            }

            // تبديل الأعمدة
            for (int i = 0; i < A.GetLength(0); i++)
            {
                int temp = A[i, posA2];
                A[i, posA2] = B[i, posB2];
                B[i, posB2] = temp;
            }
            // end
        }

        public void Task6(int[,] matrix, Sorting sort)
        {
            // code here
            // التحقق إذا كانت المصفوفة مربعة
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }
            
            // تطبيق الدالة المعطاة
            sort(matrix);
            // end
        }

        public long Task7(int n, int k)
        {
            long answer = 0;
            // code here
            if (k > n || n < 0 || k < 0)
            {
                return 0;
            }
            
            // حساب n!
            long nFactorial = 1;
            for (int i = 2; i <= n; i++)
            {
                nFactorial *= i;
            }
            
            // حساب k!
            long kFactorial = 1;
            for (int i = 2; i <= k; i++)
            {
                kFactorial *= i;
            }
            
            // حساب (n-k)!
            long nkFactorial = 1;
            int diff = n - k;
            for (int i = 2; i <= diff; i++)
            {
                nkFactorial *= i;
            }
            
            // حساب C(n,k)
            answer = nFactorial / (kFactorial * nkFactorial);
            // end
            return answer;
        }

        public double Task8(double v, double a, BikeRide ride)
        {
            double answer = 0;
            // code here
            answer = ride(v, a);
            // end
            return answer;
        }

        public int Task9(int[][] array)
        {
            int answer = 0;
            // code here
            if (array.Length % 2 == 0)
            {
                // إذا كان عدد المصفوفات زوجياً
                for (int i = 0; i < array.Length; i++)
                {
                    double[] tempArray = array[i].Select(x => (double)x).ToArray();
                    for (int j = 0; j < tempArray.Length - 1; j += 2)
                    {
                        double temp = tempArray[j];
                        tempArray[j] = tempArray[j + 1];
                        tempArray[j + 1] = temp;
                    }
                }
            }
            else
            {
                // إذا كان عدد المصفوفات فردياً
                for (int i = 0; i < array.Length; i++)
                {
                    double[] tempArray = array[i].Select(x => (double)x).ToArray();
                    for (int j = tempArray.Length - 1; j > 0; j -= 2)
                    {
                        double temp = tempArray[j];
                        tempArray[j] = tempArray[j - 1];
                        tempArray[j - 1] = temp;
                    }
                }
            }
            
            // حساب المجموع في المواقع الفردية (1, 3, 5, ...)
            double sumOfOddPositions = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 == 1) // المواقع الفردية
                {
                    double[] tempArray = array[i].Select(x => (double)x).ToArray();
                    for (int j = 0; j < tempArray.Length; j++)
                    {
                        if (j % 2 == 0) // المواقع الزوجية (0, 2, 4, ...)
                        {
                            sumOfOddPositions += tempArray[j];
                        }
                    }
                }
            }
            
            answer = (int)sumOfOddPositions;
            // end
            return answer;
        }

        public int Task10(int[][] array, Func<int[][], int> func)
        {
            int answer = 0;
            // code here
            answer = func(array);
            // end
            return answer;
        }
    }

    // تعريف الـ Delegates
    public delegate void Sorting(int[,] matrix);
    public delegate double BikeRide(double v, double a);
    public delegate int Finder(int[,] matrix);
    public delegate void SortRowsStyle(int[,] matrix);
    public delegate void ReplaceMaxElements(int[,] matrix, int value);
    public delegate int[,] GetTriangle(int[,] matrix);
    public delegate void SortRowsByMax(int[,] matrix);
    public delegate int FindNegatives(int[,] matrix);
    public delegate double MathInfo(int[,] matrix);
}
