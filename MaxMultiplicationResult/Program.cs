using System;

namespace MaxMultiplicationResult
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { -5, -3, -3, -2, 7, 1 };
            int[] mult = { -10, -5, 3, 4, 6 };
            memo = new int[mult.Length, mult.Length];
            Console.WriteLine(GetMax(nums, mult, 0, 0));
        }

        static int[,] memo;
        static int GetMax(int[] nums, int[] mult, int i, int k)
        {            
            if (k == (mult.Length))
                return 0;

            int n = nums.Length;
            int j = (n - 1) - (k - i);
            if(memo[k, i] == 0)            
            memo[k, i] = Math.Max(
                (nums[i]*mult[k] + GetMax(nums, mult, i+1, k+1)),
                (nums[j]*mult[k] + GetMax(nums, mult, i, k+1))
                );

            return memo[k, i];
        }
    }
}
