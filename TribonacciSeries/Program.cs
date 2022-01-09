using System;

namespace TribonacciSeries
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DPOptimizedTribonacci(25));
        }

        /// <summary>
        /// Recursive
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int RecursiveTribonacci(int n)
        {
            if (n == 0)
                return 0;

            if (n == 1 || n == 2)
                return 1;

            return RecursiveTribonacci(n - 1) + RecursiveTribonacci(n - 2) + RecursiveTribonacci(n - 3);

        }
        
        /// <summary>
        /// Using Dynamic programming
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int DPTribonacci(int n)
        {
            if (n == 0)
                return 0;

            if (n == 1 || n == 2)
                return 1;
            int[] dp = new int[n + 1];

            dp[0] = 0;
            dp[1] = 1;
            dp[2] = 1;

            for (int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2] + dp[i - 3];
            }

            return dp[n];

        }

        /// <summary>
        /// Optimized Dynamic programming
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int DPOptimizedTribonacci(int n)
        {
            if (n == 0)
                return 0;
            if (n == 1 || n == 2)
                return 1;



            int val1 = 0;//n-3
            int val2 = 1;//n-2
            int val3 = 1;//n-1

            for (int i = 3; i <= n; i++)
            {
                int val = val3 + val2 + val1;
                val1 = val2;
                val2 = val3;
                val3 = val;
            }

            return val3;

        }
    }
}
