using System;

namespace LongestIncreasingSequence
{
    class Program
    {


        static void Main(string[] args)
        {
            int[] arr = { 2, 3, 1, 4, 5, 10, 80 };

            RecLIS recLIS = new RecLIS();
            DPLis dPLis = new DPLis();
            Console.WriteLine($"LIS is {dPLis.GetDPLIS(arr, arr.Length)}");
        }
    }
}
