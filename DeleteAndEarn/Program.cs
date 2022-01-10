using System;
using System.Collections.Generic;

namespace DeleteAndEarn
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("[3, 4, 2] " + DeleteAndEarnMethod(new int[]{ 3, 4, 2}));
            //Console.WriteLine("[2, 2, 3, 3, 3, 4] " + DeleteAndEarnMethod(new int[] { 2, 2, 3, 3, 3, 4 }));
            //Console.WriteLine(DPCalMaxPointsHere(new int[] { 3, 4, 2 }));
            Console.WriteLine("[2, 2, 3, 3, 3, 4] " + DPCalMaxPointsHere(new int[] { 1, 1, 1, 2, 4, 5, 5, 5, 6 }));
        }

        static int DeleteAndEarnMethod(int[] nums)
        {
            int result = 0;
            
            int n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                result = Math.Max(result, RecCalMaxPointsHere(nums, i));
            }
            return result;
        }

        /// <summary>
        /// Recursive
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="curr"></param>
        /// <returns></returns>
        static int RecCalMaxPointsHere(int[] nums, int curr)
        {
            if (nums.Length == 0)
                return 0;
            List<int> lstRemaining = new List<int>();
            for (int i=0; i < nums.Length; i++)
            {
                if (i != curr)
                {
                    if (nums[i] != nums[curr] - 1 && nums[i] != nums[curr] + 1)
                        lstRemaining.Add(nums[i]);
                }                
            }
            return nums[curr] + RecCalMaxPointsHere(lstRemaining.ToArray(), 0);
        }

        static int DPCalMaxPointsHere(int[] nums)
        {
            int n = nums.Length;
            if (nums.Length == 0)
                return 0;
            Array.Sort(nums);
            Dictionary<int, int> occurances = new Dictionary<int, int>();
            int i = 0;
            for (i = 0; i < n; i++)
            {
                if (!occurances.ContainsKey(nums[i]))
                    occurances.Add(nums[i], 1);
                else
                    occurances[nums[i]]++;

            }

            int[] dp = new int[occurances.Count];
            int m = occurances.Count;

            i = 0;
            int[] newArr = new int[m];
            foreach (var item in occurances)
            {
                dp[i] = item.Key * item.Value;
                newArr[i] = item.Key;
                i++;
            }
            

            
            //for(int j=2; j < m; j++)
            //{
            //    if (newArr[j-1] + 1 == newArr[j])
            //        dp[j] = Math.Max(dp[j - 1], dp[j - 2] + dp[j]);
            //    else
            //        dp[j] = dp[j - 1] + dp[j];
            //}

            // k1, k2, curr
            int k = 0;
            int k1 = 0; int k2 = 0; int curr = 0;
            foreach (var item in occurances)
            {
                curr = item.Key;
                if (k == 0)
                    k2 = item.Key;
                if (k == 1)
                {
                    curr = item.Key;
                    if (k2 + 1 == curr)
                        dp[k] = Math.Max(dp[k - 1],dp[k]);
                    else
                        dp[k] = dp[k - 1] + dp[k];
                    k1 = k2;
                    k2 = curr;
                }
                    

                if (k > 1)
                {                    
                    if(k2 +1 == curr)
                        dp[k] = Math.Max(dp[k - 1], dp[k - 2] + dp[k]);
                    else
                        dp[k] = dp[k - 1] + dp[k];

                    
                    k1 = k2;
                    k2 = curr;
                }
                k++;
            }

            return dp[m - 1];

        }
    }
}
