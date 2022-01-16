using System;

namespace LongestCommonSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "abcde";
            string str2 = "ace";


            //Console.WriteLine(
            //    LCS(str1.ToCharArray(), str2.ToCharArray(), str1.Length - 1, str2.Length - 1));

            Console.WriteLine(LCSDp(str1.ToCharArray(), str2.ToCharArray()));

        }

        static int LCS(char[] str1, char[] str2, int n, int m)
        {
            if (n < 0 || m < 0)
                return 0;
            if (str1[n] == str2[m])
            {
                return 1 + LCS(str1, str2, n - 1, m - 1);
            }
            else
            {
                return Math.Max(LCS(str1, str2, n - 1, m), LCS(str1, str2, n, m-1));
            }
        }

        
        static int LCSDp(char[] str1, char[] str2)
        {
            int n = str1.Length;
            int m = str2.Length;

            int[,] dp = new int[n+1, m+1];

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    if (i == 0 || j == 0)
                        dp[i, j] = 0;
                    else if (str1[i - 1] == str2[j - 1])
                        dp[i, j] = 1 + dp[i - 1, j - 1];
                    else
                        dp[i, j] = Math.Max(dp[i-1, j], dp[i, j-1]) ;

                }
            }
            return dp[n, m];
        }



    }
}
