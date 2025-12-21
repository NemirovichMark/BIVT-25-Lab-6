using System.Globalization;

namespace Lab6
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(Task1(10,10,10));
        }

        
        static int Task1(int a,int b, int c)
        {   
            int s=0;
            int[] ar={a,b,c};
            foreach(int i in ar)
            {
                s+=CountDivision(i);
            }
            return s;
        }
        static int CountDivision(int num)
        {   int f=0;
            for(int i = 1; i < Math.Floor(Math.Sqrt(num))+1; i++)
            {
                if (num % i == 0)
                {
                    if (i != num/i)
                    {
                        f++;
                    }    
                    f++; 
                } 
            }
            return f;
        }
    }
}
