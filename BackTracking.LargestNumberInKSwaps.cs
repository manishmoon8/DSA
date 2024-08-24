namespace DSA
{
    public partial class BackTracking
    {
        /// <summary>
        /// Complexity: Number of nodes * work done at each node
        ///  n^2 * n!/(n-k)!
        /// </summary>
        public static void LargestNumberInKSwaps()
        {
            var input = "1234567";
            var k = 4;
            string result = string.Empty;
            LargestNumberInKSwaps(ref input, k, 0, ref result);
            Console.WriteLine(result);
        }

        private static void LargestNumberInKSwaps(ref string input, int k, int start, ref string result)
        {
            if (k == 0 || start == input.Length - 1)
            {
                return;
            }

            var maxElement = GetMaxNumber(input, start);
            for (int i = start + 1; i < input.Length; i++)
            {
               if (input[start] < input[i] && input[i] == maxElement)
               {
                    input = Swap(input, start, i);
                    if (input.CompareTo(result) > 0)
                    {
                        result = input;
                    }
                    LargestNumberInKSwaps(ref input, k - 1, start + 1, ref result);
                    input = Swap(input, start, i);
               }
            }

            LargestNumberInKSwaps(ref input, k, start + 1, ref result);
        }

        private static char GetMaxNumber(string input, int start)
        {
            var max = input[start];
            for (int i = start + 1; i < input.Length; i++)
            {
                if (input[i] > max)
                {
                    max = input[i];
                }
            }
            return max;
        }
    }
}
