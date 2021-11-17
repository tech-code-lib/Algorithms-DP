using System;
using System.Collections.Generic;
using System.Text;

namespace LongestIncreasingSequence
{
    public class DPLis
    {
        public int GetDPLIS(int[] arr, int n)
        {
            int[] table = new int[n];
            table[0] = 1;

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j <= i-1; j++)
                {
                    if (arr[j] < arr[i])
                    {
                        table[i] = Math.Max(table[i], (1 + table[j]));
                    }
                }
            }

            int max = 1;
            for (int i = 0; i < n; i++)
            {
                max = Math.Max(max, table[i]);
            }

            return max;
        }
    }
}
