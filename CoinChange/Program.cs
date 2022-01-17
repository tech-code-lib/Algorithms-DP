using System;

namespace CoinChange
{
    class Program
    {
        //N = 4 and S = {1,2,3}, there are four solutions: {1,1,1,1},{1,1,2},{2,2},{1,3}. So output should be 4. 
        static void Main(string[] args)
        {
            int[] nums = new int[] { 2, 4, 3 };
            int N = 8;
            Console.WriteLine(OptimizedGetMaxCount(nums, N));
        }
        
        static int GetMaxCount(int[] nums, int N, int i)
        {
            if (i == nums.Length)
                return 0;
            if (N == 0)
                return 1;
            if (N < 0)
                return 0;
            return GetMaxCount(nums, N - nums[i], i) + GetMaxCount(nums, N, i+1);
        }

        static int OptimizedGetMaxCount(int[] nums, int N)
        {
            int n = nums.Length;
            int[] dp = new int[N+1];
            dp[0] = 1;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = nums[i]; j <= N; j++)
                {
                    dp[j] += dp[j - nums[i]];
                }
            }

            return dp[N];
        }

    }
}
