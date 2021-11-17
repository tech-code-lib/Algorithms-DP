using System;
using System.Collections.Generic;
using System.Text;

namespace LongestIncreasingSequence
{
    public class RecLIS
    {
        public int LisEndingHere(int[] arr, int curr)
        {
            if (curr == 0)
                return 1;

            int ans = 1;

            for (int i = 0; i <= curr -1; i++)
            {
                if (arr[i] < arr[curr])
                    ans = Math.Max(ans, (1 + LisEndingHere(arr, i)));
            }

            return ans;
        }
        public int GetRecLIS(int[] arr, int n)
        {
            int max_ans = 1;

            for (int i = 0; i < n; i++)
            {
                max_ans = Math.Max(max_ans, LisEndingHere(arr, i));
            }

            return max_ans;
        }
    }
}
