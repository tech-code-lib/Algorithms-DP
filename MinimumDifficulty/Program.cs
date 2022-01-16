using System;

namespace MinimumDifficulty
{
    //https://leetcode.com/problems/minimum-difficulty-of-a-job-schedule/
    class Program
    {
        /// <summary>
        /// index
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine(MinimumDifficulty(new int[]{ 6, 5, 4, 3, 2, 1 }, 3));
        }

        static int MinimumDifficulty(int[] jobDifficulty, int d)
        {
            if (d > jobDifficulty.Length)
                return -1;

            int[,] dp = new int[d+1, jobDifficulty.Length];
            for (int i = 0; i < dp.GetLength(0); i++)
            {
                for (int j = 0; j < dp.GetLength(1); j++)
                {
                    dp[i, j] = -1;
                }
            }
            return dfs(jobDifficulty, d, 0, dp);
        }

        static int dfs(int[] diff, int d, int idx, int[, ] dp)
        {
            if (d == 1)
            {
                int max = 0;
                while (idx < diff.Length)
                {
                    max = Math.Max(max, diff[idx]);
                    idx++;
                }
                return max;
            }
            if (dp[d, idx] != -1)
                return dp[d, idx];
            int result = int.MaxValue;
            int max_v = 0;
            for (int i = idx; i < diff.Length - d + 1; i++)
            {
                max_v = Math.Max(max_v, diff[idx]);
                result = Math.Min(result, max_v + dfs(diff, d - 1, i+1, dp)); 
            }
            dp[d, idx]=result;
            return dp[d, idx];
        }


    }
}
