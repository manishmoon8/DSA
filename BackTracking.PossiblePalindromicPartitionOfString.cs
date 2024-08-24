namespace DSA
{
    /// <summary>
    /// https://www.geeksforgeeks.org/problems/find-all-possible-palindromic-partitions-of-a-string/1
    /// </summary>
    public partial class BackTracking
    {
        public static void PossiblePalindromicPartitionOfString()
        {
            var input = "nitin";
            var result = new List<List<string>>();
            PossiblePalindromicPartitionOfString(ref input, new List<string>(), 0, result);
            foreach (var item in result)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }

        private static void PossiblePalindromicPartitionOfString(ref string input, List<string> list, int index, List<List<string>> result)
        {
            if (index == input.Length)
            {
                result.Add(new List<string>(list));
                return;
            }

            string palindromeString = string.Empty;
            for (int i = index; i < input.Length; i++)
            {
                palindromeString += input[i];
                if (IsPalindrome(palindromeString))
                {
                    list.Add(palindromeString);
                    PossiblePalindromicPartitionOfString(ref input, list, i + 1, result);
                    list.RemoveAt(list.Count - 1);
                }
            }
        }

        private static bool IsPalindrome(string palindromeString)
        {
            int start = 0;
            int end = palindromeString.Length - 1;
            while (start < end)
            {
                if (palindromeString[start] != palindromeString[end])
                {
                    return false;
                }
                start++;
                end--;
            }
            return true;
        }
    }
}
