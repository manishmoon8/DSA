namespace DSA
{
    /// <summary>
    /// https://www.geeksforgeeks.org/problems/word-break-part-23249/1
    /// </summary>
    public partial class BackTracking
    {
        public static void WordBreak()
        {
            var result = new List<string>();
            var input = "catsanddog";
            var dict = new HashSet<string> { "cat", "cats", "and", "sand", "dog" };

            var temp = new List<string>();
            WordBreak(ref input, 0, temp, dict, result);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        private static void WordBreak(ref string input, int index, List<string> temp, HashSet<string> dict, List<string> result)
        {
           if(index == input.Length)
            {
                result.Add(string.Join(" ", temp));
                return;
            }

            var word = string.Empty;
            for (int i = index; i < input.Length; i++)
            {
                word += input[i];
                if (dict.Contains(word))
                {
                    temp.Add(word);
                    WordBreak(ref input, i + 1, temp, dict, result);
                    temp.RemoveAt(temp.Count - 1);
                }
            }
        }
    }
}
