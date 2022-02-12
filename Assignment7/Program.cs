// See https://aka.ms/new-console-template for more information
using System;
namespace ConsoleApp1
{

    static class Program
    {
        public static void Main()
        {
            
            //int[] numbers = GenerateNumbers(20);
            //Reverse(numbers);
            //Console.WriteLine("\n");
            //PrintNumbers(numbers);
            Fibonacci(8);
        }

        public static int[] GenerateNumbers(int n)
        {
            //int Ran = new Random();
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                //int Ran = new Random();
                Console.WriteLine(i);

                numbers[i] = i+1;
            }
            return numbers;

        }
        public static void Reverse(int[] array)
        {
            for (int i = 0,j = array.Length - 1;i < j;i++,j--)
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        public static void PrintNumbers(int[] numbers)
        {
            foreach(var num in numbers)
            {
                Console.WriteLine(num);
            }
        }

        //Question2
        public static int Fibonacci(int n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }
            int a = 1, b = 1, c = 0;
            for (int j = 3; j <= n; j++)
            {
                c = a + b;
                a = b;
                b = c;
            }
            Console.WriteLine(c);
            return c;
            

        }
    }
}