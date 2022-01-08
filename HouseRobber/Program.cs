using System;

namespace HouseRobber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 2, 7, 9, 3, 1};
            int result = Rob2(nums);
            Console.WriteLine(result);
        }

        /// <summary>
        /// Solution with DP and Time Complexity O(n) and Space Complexity also O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int Rob(int[] nums)
        {
            int n = nums.Length;
            int[] dp = new int[n];
            if (n == 0)
                return 0;
            if (n == 1)
                return nums[0];

            dp[0] = nums[0];
            dp[1] = Math.Max(dp[0], nums[0]);
            
            for (int i = 2; i < n; i++)
            {
                dp[i] =Math.Max(dp[i - 2] + nums[i], dp[i-1]);                
            }

            return dp[n-1];
        }

        /// <summary>
        /// Solution with DP and Time Complexity O(n) and Space Complexity also O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int Rob2(int[] nums)
        {
            int n = nums.Length;            
            if (n == 0)
                return 0;
            if (n == 1)
                return nums[0];

            int max = 0;
            int val1 = nums[0];
            int val2 = nums[1];
            
            val2 = max = Math.Max(nums[0], nums[1]);

            for (int i = 2; i < n; i++)
            {                
                max = Math.Max(val1 + nums[i], max);
                val1 = val2;
                val2 = max;
            }

            return val2;
        }
    }
}
