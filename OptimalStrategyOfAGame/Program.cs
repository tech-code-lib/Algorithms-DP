using System;
namespace OptimalStrategyOfAGame
{
    class Program
    {
        static void Main(string[] args)
        {            
            int[] nums = new int[] { 3, 12, 11, 7 };
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }

            int result = GetMax(nums, sum, 0, nums.Length - 1);

            memo = new int[nums.Length, nums.Length];
            for (int i = 0; i < memo.GetLength(0); i++)
            {
                for (int j = 0; j < memo.GetLength(1); j++)
                {
                    memo[i, j] = -1;
                }
            }

            int optimizedResult = GetMaxOptimized(nums, sum, 0, nums.Length - 1);

            Console.WriteLine(optimizedResult);
        }

        static int GetMax(int[]nums, int sum, int i, int j)
        {
            if (j == i + 1)
                return Math.Max(nums[i], nums[j]);
            return Math.Max((
                    sum - GetMax(nums, sum - nums[i], i+1, j)                    
                ),
                (
                    sum - GetMax(nums, sum - nums[j], i, j -1)
                ));
        }
        static int[,] memo;
        static int GetMaxOptimized(int[] nums, int sum, int i, int j)
        {            
            if (j == i + 1)
                memo[i,j] = Math.Max(nums[i], nums[j]);
            
            if (memo[i, j] != -1)
                return memo[i, j];

            memo[i, j] = Math.Max((
                    sum - GetMaxOptimized(nums, sum - nums[i], i + 1, j)
                ),
                (
                    sum - GetMaxOptimized(nums, sum - nums[j], i, j - 1)
                ));

            return memo[i, j];
        }
    }
}
